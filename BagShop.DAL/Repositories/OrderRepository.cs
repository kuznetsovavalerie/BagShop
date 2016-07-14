using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BagShop.DAL.Repositories
{
    public class OrderRepository
    {
        private BagShopContext context;

        public OrderRepository(BagShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders;
        }

        public Order Get(int id)
        {
            return context.Orders.Find(id);
        }

        public void Create(Order book)
        {
            context.Orders.Add(book);
        }

        public void Update(Order book)
        {
            context.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return context.Orders.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order book = context.Orders.Find(id);
            if (book != null)
                context.Orders.Remove(book);
        }
    }
}
