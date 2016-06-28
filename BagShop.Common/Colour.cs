using System.Collections.Generic;

namespace BagShop.Common
{
    public class Colour
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PreviewImage { get; set; }

        public string TitleImage { get; set; }

        public IEnumerable<string> Images { get; set; }
    }
}
