using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pars.Entities;

namespace Pars.DataLayer.Configurations
{

    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        private const int KeyMaxLength = 64;
        private const int StringMaxLength = 128;
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(KeyMaxLength);
            builder.Property(product => product.Name).HasMaxLength(StringMaxLength).IsRequired();

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired(false);
        }
    }
}
