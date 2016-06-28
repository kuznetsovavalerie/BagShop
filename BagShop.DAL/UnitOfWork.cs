using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using BagShop.DAL.Repositories;
using System;

namespace BagShop.DAL
{
    class UnitOfWork
    {
        private BagShopContext context;
        private OrderRepository orderRepository;

        public UnitOfWork(string connectionString)
        {
            context = new BagShopContext(connectionString);
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(context);

                return orderRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
