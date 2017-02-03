using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using BagShop.Common.Interfaces.Services;
using System;

namespace BagShop.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public User Get(Guid id)
        {
            return unitOfWork.UserRepository.FindById(id);
        }

        public void Update(User user)
        {
            unitOfWork.UserRepository.Update(user);
            unitOfWork.SaveChanges();
        }
    }
}
