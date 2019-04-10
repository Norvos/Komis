using System.ComponentModel.DataAnnotations;

namespace Komis.Infrastructure.Commands.User
{
    public class CreateUser : ICommand
    { 

        [Required]
        [Display(Name = "Nazwa użytkownika")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage ="Hasło musi zawierać minimum 5 znaków")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
