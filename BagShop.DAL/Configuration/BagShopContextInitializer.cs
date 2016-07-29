using System.Data.Entity;

namespace BagShop.DAL.Configuration
{
    public class BagShopContextInitializer : DropCreateDatabaseIfModelChanges<BagShopContext>
    {
        protected override void Seed(BagShopContext dbContext)
        {
            base.Seed(dbContext);
        }
    }
}
