using System;
using System.Collections.Generic;

namespace BagShop.Common.Entities
{
    public class Order
    {
        private ICollection<OrderState> states;

        public int ID { get; set; }

        public User Customer { get; set; }

        public string DeliveryAddress { get; set; }

        public ICollection<OrderItem> Items { get; set; }

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
