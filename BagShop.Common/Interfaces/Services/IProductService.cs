using BagShop.Common.Entities;
using System.Collections.Generic;

namespace BagShop.Common.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ShoppingItem> GetAllItems();

        ShoppingItem GetItem(int id);

        Colour GetColour(int id);

        void AddItem(ShoppingItem item);
    }
}
