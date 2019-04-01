using Komis.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;


namespace Komis.Core.Models
{
    public class Opinion : ICommand
    {
        [BindNever]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email is too long")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(5000, ErrorMessage = "Mesage is too long")]
        public string Message { get; set; }


        public bool WaitingForAnAnswer { get; set; }

        public Opinion(string email, string username, string message, bool waitingforananswer)
        {
            ID = new Guid();
            Username = username;
            Email = email;
            Message = message;
            WaitingForAnAnswer = waitingforananswer;
        }

        public Opinion()
        {

        }
    }
}
