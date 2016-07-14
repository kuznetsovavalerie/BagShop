﻿using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BagShop.DAL.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(BagShopContext context)
            : base(context)
        {
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }

        public User FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            throw new NotImplementedException();
        }
    }
}
