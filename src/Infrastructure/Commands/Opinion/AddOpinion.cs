using Komis.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;


namespace Komis.Infrastructure.Commands.Opinion
{
    public class AddOpinion : ICommand
    {
        
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [StringLength(100, ErrorMessage = "Adres e-mail jest za długi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wiadomość jest wymagana")]
        [StringLength(5000, ErrorMessage = "Wiadomość jest za długa")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Temat jest wymagany")]
        [StringLength(200, ErrorMessage = "Temat jest za długi")]
        public string Topic { get; set; }

        public bool WaitingForAnAnswer { get; set; }

        public AddOpinion(string email, string username, string message, bool waitingforananswer,string topic)
        {
            Username = username;
            Email = email;
            Message = message;
            WaitingForAnAnswer = waitingforananswer;
            Topic = topic;
        }

        public AddOpinion()
        {

        }
    }
}
