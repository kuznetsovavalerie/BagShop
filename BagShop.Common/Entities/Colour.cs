using System.Collections.Generic;

namespace BagShop.Common.Entities
{
    public class Colour
    {
        public int ID { get; set; }

        public int ShoppingItemId { get; set; }

        public ShoppingItem ShoppingItem { get; set; }

        public string Name { get; set; }

        public string PreviewImage { get; set; }

        public IEnumerable<string> Images { get; set; }
    }
}
