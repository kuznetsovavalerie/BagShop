﻿using System.Collections.Generic;

namespace BagShop.Common.Entities
{
    public class Colour
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PreviewImage { get; set; }

        public virtual ICollection<string> Images { get; set; }
    }
}
