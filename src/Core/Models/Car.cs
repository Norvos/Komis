using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Komis.Core.Models
{
    public class Car
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Wprowadź markę")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Wprowadź model")]
        public string Model { get; set; }

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

        public IEnumerable<Image> Images
        {
            get { return _images; }
            set { _images = new HashSet<Image>(value); }
        }

        private ISet<Image> _images = new HashSet<Image>();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Car(Guid id, string brand, string model, int yearofproduction, string milage, string capacity, 
            string fueltype, string power, string description, decimal price, string pictureurl, IEnumerable<Image> images=null)
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
            Images = images;
        }

        public Car() { }

        public void AddImage(string url,string name,Guid imgID)
        {
            var image = _images.SingleOrDefault(x => x.ID == imgID);

            if (image != null)
            {
                throw new Exception("This image already exists");
            }

            var img = new Image()
            {
                CarID = this.ID,
                URL = url,
                ID = imgID,
                Name = name
            };

            _images.Add(img);
    
        }

        public void AddImage(Image img)
        {
            if (img == null)
            {
                throw new Exception("Image cannot be null");
            }
            _images.Add(img);
        }

        public void DeleteImage(Guid id)
        {
            var img = Images.SingleOrDefault(x => x.ID == id);

            if (img != null)
            {
                _images.Remove(img);
            }
        }

    }
}
