using BagShop.Common.Interfaces;

namespace BagShop.BLL.Services
{
    public class BaseService
    {
        protected IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }
    }
}
