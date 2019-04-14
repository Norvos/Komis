using Komis.Core.Models;
using System.Collections.Generic;

namespace Komis.Core.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }

        public List<Car> CarList { get; set; }
    }
}
