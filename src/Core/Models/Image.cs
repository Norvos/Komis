using System;

namespace Komis.Core.Models
{
    public class Image
    {
       
        public Guid ID { get; set; }

        public string URL { get; set; }

        public string Name { get; set; }

        public Guid CarID { get; set; }

        public Image() { }

    }
}
