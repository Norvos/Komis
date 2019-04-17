using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Komis.Infrastructure.Commands.Car
{
    public class AddVehicle :ICommand
    {
       
        public Core.Models.Car Car { get ;set;}

        [Required(ErrorMessage = "Wybierz minimum jedno zdjęcie")]
        [MaxLength(5,ErrorMessage ="Możesz wybrać maksymalnie 5 zdjęć")]
        public IFormFile[] Images { set; get; }
    }
}

