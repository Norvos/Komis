using System;

namespace Komis.Core.Models
{
    public class Car
    {
        public Guid ID { get; set; }
        public string Brand { get; set; }
        public string Model  { get; set; }
        public int YearOfProduction { get; set; }
        public string Milage { get; set; }
        public string Capacity { get; set; }
        public string FuelType { get; set; }
        public string Power { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public string ThumbnailURL { get; set; }
        public bool IsCarOfTheWeek { get; set; }
        public bool IsInACentral { get; set; }

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
            IsCarOfTheWeek = iscaroftheweek;
            IsInACentral = isinacentral;
        }
        public Car() { }
    }
}
