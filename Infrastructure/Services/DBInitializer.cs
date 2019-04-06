using Komis.Core.Models;
using Komis.Infrastructure.EF;
using System;
using System.Linq;

namespace Komis.Infrastructure.Services
{
    public static class DBInitializer
    {
        public static void Seed(DBContext context)
        {
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                     new Car(Guid.NewGuid(), "Ford", "Focus", 2015, "30 000 km", "1 500 cm3", "benzyna", "160 KM", "Super autko, hamulce do wymiany. Przegląd do 2020!",
                     30000M, "../images/fordFocusFull.jpg", "../images/fordFocusMiniatura.jpg", false, false),

                       new Car(Guid.NewGuid(), "Volkswagen", "Golf IV", 2001, "320 000 km", "1 400 cm3", "benzyna", "140 KM", "Auto sprowadzone z Niemiec. Pierwszy właściciel. Okazja!",
                     15000M, "../images/golfIV.jpg", "../images/golfIV.jpg", false, false),

                        new Car(Guid.NewGuid(), "Fiat", "Seicento", 2002, "300 000 km", "1 000 cm3", "benzyna", "40 KM", "Śmiga, aż miło. Trochę gniją nadkoła. Cena do negocjacji",
                     1500M, "../images/seicento.jpg", "../images/seicento.jpg", false, false),

                    new Car(Guid.NewGuid(), "Seat", "Ibiza III", 2004, "140 000 km", "1 200 cm3", "benzyna", "120 KM", "Auto sprawne, jeździ do przodu, tyłu, hamuje i skręca. POLECAM",
                    12000M, "../images/ibiza.jpg", "../images/ibiza.jpg", false, false)); ;
            }
            context.SaveChanges();
            
        }
    }
}
