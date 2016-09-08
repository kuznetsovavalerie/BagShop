using BagShop.Common.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace BagShop.DAL.Repositories
{
    internal class ProductRepository : Repository<ShoppingItem>
    {
        internal ProductRepository(BagShopContext context)
            : base(context)
        {
        }

        public override ShoppingItem FindById(object id)
        {
            return Set.Where(si => si.ID == (int)id)
                .Include(si => si.Colours.Select(cp => cp.Preview))
                .Include(si => si.Colours.Select(c => c.Photos))
                .SingleOrDefault();
        }
    }
}
