using Komis.Core.Models;
using System.Collections.Generic;

namespace Komis.Core.ViewModels
{
    public class HomeViewModel
    {
        public string Tytul { get; set; }

        public List<Car> ListaSamochodow { get; set; }
    }
}
