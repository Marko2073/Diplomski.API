using Diplomski.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.DataAccess.Configurations
{
    internal class ComponentConfiguration : EntityConfiguration<Component>
    {
        public override void ConfigureEntity(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Component> builder)
        {
            builder.HasOne(x => x.ModelVersion)
                .WithMany(x => x.Components)
                .HasForeignKey(x => x.ModelVersionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.Configuration).WithMany(x => x.Components).HasForeignKey(x => x.ConfigurationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
