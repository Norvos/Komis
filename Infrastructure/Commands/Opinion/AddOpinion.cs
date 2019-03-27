using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Commands.Opinion
{
    public class AddOpinion : ICommand
    {
        public Guid ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public bool WaitingForAnAnswer { get; set; }
    }
}
