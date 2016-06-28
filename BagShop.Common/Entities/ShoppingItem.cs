using System.Collections.Generic;

namespace BagShop.Common.Entities
{
    public class ShoppingItem
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Dictionary<string, int> Composition { get; set; }

        public string Care { get; set; }

        public double Price { get; set; }

        public IEnumerable<Colour> Colours { get; set; }
    }
}
