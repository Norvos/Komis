using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Komis.Infrastructure.Commands.Car
{
    public class AddVehicle :ICommand
    {
       
        public Core.Models.Car Car { get ;set;}

        [Required(ErrorMessage = "Wybierz minimum jedno zdjęcie")]
        [MaxLength(6,ErrorMessage ="Możesz wybrać maksymalnie 6 zdjęć")]
        public IFormFile[] Images { set; get; }
    }
}

