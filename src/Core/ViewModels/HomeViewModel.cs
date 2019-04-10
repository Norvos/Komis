using Komis.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Komis.Core.ViewModels
{
    public class HomeViewModel
    {
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public List<Car> CarList { get; set; }
    }
}
