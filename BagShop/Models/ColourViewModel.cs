using System.Collections.Generic;

namespace BagShop.Models
{
    public class ColourViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PreviewImage { get; set; }

        public IEnumerable<string> Images { get; set; }
    }
}