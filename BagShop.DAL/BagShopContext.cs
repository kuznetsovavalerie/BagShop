using BagShop.Common.Entities;
using BagShop.DAL.Configuration;
using System.Data.Entity;

namespace BagShop.DAL
{
    public class BagShopContext : DbContext
    {
        public BagShopContext(string connectionStr) : base(connectionStr) { }

        internal IDbSet<User> Users { get; set; }
        internal IDbSet<Role> Roles { get; set; }
        internal IDbSet<ExternalLogin> Logins { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingItem> Items { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());

            modelBuilder.Entity<ShoppingItem>().HasMany(si => si.Colours).WithRequired(c => c.ShoppingItem).HasForeignKey<int>(c => c.ShoppingItemId);

            modelBuilder.Entity<Colour>()
                .ToTable("Colours")
                .HasRequired(c => c.ShoppingItem)
                .WithMany(si => si.Colours)
                .HasForeignKey<int>(c => c.ShoppingItemId);
        }
    }
}
