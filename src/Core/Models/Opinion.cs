﻿using System;
using Komis.Infrastructure.Commands.Opinion;

namespace Komis.Core.Models
{
    public class Opinion
    {
        public Guid ID { get; set; }

        public string Username { get; set; }

        public string Topic { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool WaitingForAnAnswer { get; set; }

        public Opinion(string email, string username, string message, bool waitingforananswer,string topic)
        {
            ID = Guid.NewGuid();
            Username = username;
            Email = email;
            Message = message;
            WaitingForAnAnswer = waitingforananswer;
            Topic = topic;
        }

        public Opinion() { }
        
    }
}
