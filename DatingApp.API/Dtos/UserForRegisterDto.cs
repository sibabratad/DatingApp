using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Password length must be between 5 to 10.")]
        public string Password {get; set;}
    }
}