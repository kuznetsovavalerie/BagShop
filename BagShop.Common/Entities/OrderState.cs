using BagShop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShop.Common.Entities
{
    public class OrderState
    {
        public int ID { get; set; }

        public OrderStateType Type { get; set; }

        public Order Order { get; set; }

        public DateTime ChangeDate { get; set; }

        public User StateManager { get; set; }

        public string Description { get; set; }
    }
}
