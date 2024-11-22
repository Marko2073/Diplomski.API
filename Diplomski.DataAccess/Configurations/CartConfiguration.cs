using Diplomski.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.DataAccess.Configurations
{
    internal class CartConfiguration : EntityConfiguration<Cart>
    {
        public override void ConfigureEntity(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cart> builder)
        {
            builder.HasOne(x => x.User)
                 .WithMany(x => x.Carts)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
    
}
