using BagShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShop.DAL.Configuration
{
    internal class ShoppingItemConfiguration : EntityTypeConfiguration<ShoppingItem>
    {
        internal ShoppingItemConfiguration()
        {
            ToTable("ShoppingItems");

            //HasKey(x => x.ClaimId)
            //    .Property(x => x.ClaimId)
            //    .HasColumnName("ClaimId")
            //    .HasColumnType("int")
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            //    .IsRequired();

            //HasMany<>


            //Property(x => x.ClaimType)
            //    .HasColumnName("ClaimType")
            //    .HasColumnType("nvarchar")
            //    .IsMaxLength()
            //    .IsOptional();

            //Property(x => x.ClaimValue)
            //    .HasColumnName("ClaimValue")
            //    .HasColumnType("nvarchar")
            //    .IsMaxLength()
            //    .IsOptional();

            //HasRequired(x => x.User)
            //    .WithMany(x => x.Claims)
            //    .HasForeignKey(x => x.UserId);
        }
    }
}
