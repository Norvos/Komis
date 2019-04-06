using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

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
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
