using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using System.Collections.Generic;

namespace BagShop.BLL.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return unitOfWork.ShoppingItemRepository.GetAll();
        }

        public ShoppingItem GetItem(int id)
        {
            return unitOfWork.ShoppingItemRepository.FindById(id);
        }

        public void AddItem(ShoppingItem item)
        {
            unitOfWork.ShoppingItemRepository.Add(item);
        }
    }
}
