using Diplomski.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.DataAccess.Configurations
{
    internal class ConfigurationConfiguration : EntityConfiguration<Configuration>
    {
        public override void ConfigureEntity(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Configuration> builder)
        {
            builder.HasOne(x => x.User)
                 .WithMany(x => x.Configurations)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
    
}
