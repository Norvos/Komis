using System;
using System.ComponentModel.DataAnnotations;

namespace Komis.Core.Models
{
    public class FeedbackViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public Guid OpinionID { get; set; }

        [Required(ErrorMessage = "Odpowiedź nie może być pusta")]
        public string Feedback { get; set; }
    }
}
