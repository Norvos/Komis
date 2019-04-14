using System;
using Komis.Infrastructure.Commands.Opinion;

namespace Komis.Core.Models
{
    public class Opinion
    {
        public Guid ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool WaitingForAnAnswer { get; set; }

        public Opinion(string email, string username, string message, bool waitingforananswer)
        {
            ID = Guid.NewGuid();
            Username = username;
            Email = email;
            Message = message;
            WaitingForAnAnswer = waitingforananswer;
        }

        public static explicit operator Opinion(AddOpinion v)
        {
            Opinion opinion = new Opinion()
            {
                Email = v.Email,
                ID = Guid.NewGuid(),
                Message=v.Message,
                Username=v.Username,
                WaitingForAnAnswer=v.WaitingForAnAnswer,
             };

            return opinion;
        }

        public Opinion() { }
        
    }
}
