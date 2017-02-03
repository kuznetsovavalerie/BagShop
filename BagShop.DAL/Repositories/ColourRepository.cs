using BagShop.Common.Entities;
using System.Linq;

namespace BagShop.DAL.Repositories
{
    internal class ColourRepository : Repository<Colour>
    {
        internal ColourRepository(BagShopContext context)
            : base(context)
        {
        }

        public override Colour FindById(object id)
        {
            return Set.Where(si => si.ID == (int)id).SingleOrDefault();
        }
    }
}

