using System.Collections.Generic;

namespace BagShop.Models
{
    public class ProductPreviewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string TitleImage { get; set; }

        public IEnumerable<ColourPreviewModel> Colours { get; set; }
    }
}