using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Komis.Infrastructure.Commands.Car
{
    public class AddVehicle :ICommand
    {
       
        public Core.Models.Car Car { get ;set;}

        [Required(ErrorMessage = "Wybierz zdjęcie")]
        public IFormFile Image { set; get; }
    }
}

