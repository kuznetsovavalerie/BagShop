﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BagShop.Common.Entities
{
    public class ShoppingItem
    {
        private ICollection<Colour> colours;

        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Composition { get; set; }

        public string Care { get; set; }

        public double Price { get; set; }

        public string TitleImage { get; set; }

        public virtual ICollection<Colour> Colours { get; set; }
    }
}
