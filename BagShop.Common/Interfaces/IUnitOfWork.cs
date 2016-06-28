using BagShop.Common.Entities;
using System;

namespace BagShop.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> Orders { get; }
        void Save();
    }
}
