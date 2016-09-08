using System.Collections.Generic;

namespace BagShop.Common.Entities
{
    public class Colour
    {
        public int ID { get; set; }

        public ColourPreview Preview { get; set; }

        public ShoppingItem ShoppingItem { get; set; }

        public ICollection<ColourPhoto> Photos { get; set; }
    }
}
