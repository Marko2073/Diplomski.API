using Diplomski.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.DataAccess.Configurations
{
    internal class CategoryConfiguration : EntityConfiguration<Category>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).HasDefaultValue(null);
            builder.HasOne(x => x.Parent).WithMany(x => x.Childrens).HasForeignKey(x => x.ParentId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            

        }
    }
}
