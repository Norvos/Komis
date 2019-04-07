using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Komis.Core.Models
{
    public class Car
    {
        [BindNever]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Wprowadź markę")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Wprowadź model")]
        public string Model  { get; set; }

        [Required(ErrorMessage = "Wprowadź rok produkcji")]
        public int YearOfProduction { get; set; }

        [Required(ErrorMessage = "Wprowadź przebieg")]
        public string Milage { get; set; }

        [Required(ErrorMessage = "Wprowadź pojemność")]
        public string Capacity { get; set; }

        [Required(ErrorMessage = "Wybierz typ paliwa")]
        public string FuelType { get; set; }

        [Required(ErrorMessage = "Wprowadź moc")]
        public string Power { get; set; }

        [Required(ErrorMessage = "Wprowadź opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Podaj cenę")]
        public decimal Price { get; set; }

        [BindNever]
        public string PictureURL { get; set; }

        [BindNever]
        public string ThumbnailURL { get; set; }


        public Car(Guid id, string brand, string model, int yearofproduction, string milage, string capacity, string fueltype, string power, string description, decimal price, string pictureurl, string thumbnailurl, bool iscaroftheweek, bool isinacentral)
        {
            ID = id;
            Brand = brand;
            Model = model;
            YearOfProduction = yearofproduction;
            Milage = milage;
            Capacity = capacity;
            FuelType = fueltype;
            Power = power;
            Description = description;
            Price = price;
            PictureURL = pictureurl;
            ThumbnailURL = thumbnailurl;
        }

        public Car() { }
    }
}
