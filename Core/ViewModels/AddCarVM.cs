using Komis.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Core.ViewModels
{
    public class AddCarVM
    {
        [BindProperty]
        public Car Car { get ;set;}

        [BindProperty]
        [Required(ErrorMessage = "Wybierz zdjęcie")]
        public IFormFile Image { set; get; }
    }
}

