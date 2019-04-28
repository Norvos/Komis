using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Komis.Infrastructure.Commands.Car
{
    public class EditVehicleGallery : ICommand
    {
        [BindProperty]
        public Core.Models.Car Car { get; set; }

        [MinLength(1,ErrorMessage = "Wybierz zdjęcie")]
        public IFormFile[] Images { set; get; }
    }
}
