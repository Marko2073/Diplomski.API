using Diplomski.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.DataAccess.Configurations
{
    internal class CartItemConfiguration : EntityConfiguration<CartItem>
    {
        public override void ConfigureEntity(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CartItem> builder)
        {
            builder.HasOne(x => x.ModelVersion)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.ModelVersionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
