using System;
using System.Collections.Generic;

namespace BagShop.Common.Entities
{
    public class Order
    {
        private ICollection<OrderState> states;
        private ICollection<OrderItem> items;

        public int ID { get; set; }

        public User Customer { get; set; }

        public string DeliveryAddress { get; set; }

        public ICollection<OrderItem> Items
        {
            get
            {
                if (items == null)
                {
                    items = new List<OrderItem>();
                }

                return items;
            }
            set { }
        }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderState> States {
            get
            {
                if (states == null)
                {
                    states = new List<OrderState>();
                }

                return states;
            }
            set { }
        }
    }
}
