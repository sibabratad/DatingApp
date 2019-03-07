using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingAppRepository : IDatingAppRepository
    {
        private readonly DataContext _dataContext;

        public DatingAppRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.Users.Include(p => p.Photos).FirstOrDefaultAsync(u=> u.Id == id);
            return user;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            var users = await _dataContext.Users.Include(p=> p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _dataContext.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            var photo = await _dataContext.Photos.Where(x=> x.UserId == userId)
                .FirstOrDefaultAsync(p=> p.IsMain);
            return photo;
        }
    }
}