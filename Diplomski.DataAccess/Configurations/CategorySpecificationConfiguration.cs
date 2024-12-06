using Diplomski.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.DataAccess.Configurations
{
    internal class CategorySpecificationConfiguration : EntityConfiguration<CategorySpecification>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CategorySpecification> builder)
        {
            builder.HasOne(x => x.Category).WithMany(x => x.CategorySpecifications).HasForeignKey(x => x.CategoryId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(x => x.Specification).WithMany(x => x.CategorySpecifications).HasForeignKey(x => x.SpecificationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            
        }
    }
}
