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
                     new Car(Guid.NewGuid(), "Ford", "Focus", 1997, "14 000 km", "2 000 cm3", "benzyna", "420 KM", "Super autko, igła",
                     160000M, "../images/fordFocusFull.jpg", "../images/fordFocusMiniatura.jpg", false, false));
            }
            context.SaveChanges();
        }
    }
}
