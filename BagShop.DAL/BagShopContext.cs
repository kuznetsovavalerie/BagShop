using BagShop.Common.Entities;
using System.Data.Entity;

namespace BagShop.DAL
{
    public class BagShopContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public BagShopContext(string connectionStr) : base(connectionStr) { }
    }
}
