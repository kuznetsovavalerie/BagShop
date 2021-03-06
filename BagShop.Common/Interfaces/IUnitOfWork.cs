﻿using BagShop.Common.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BagShop.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> OrderRepository { get; }
        IRepository<BlogPost> BlogPostRepository { get; }
        IRepository<ShoppingItem> ProductRepository { get; }
        IRepository<Colour> ColourRepository { get; }
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
