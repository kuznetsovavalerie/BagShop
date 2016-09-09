using BagShop.Common.Entities;
using System;
using System.Collections.Generic;

namespace BagShop.Common.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllItems();

        Order GetItem(int id);

        void AddItem(Order item, Guid customerId);
    }
}
