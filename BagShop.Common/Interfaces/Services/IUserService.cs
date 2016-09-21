using BagShop.Common.Entities;
using System;

namespace BagShop.Common.Interfaces.Services
{
    public interface IUserService
    {
        User Get(Guid id);

        void Update(User item);
    }
}
