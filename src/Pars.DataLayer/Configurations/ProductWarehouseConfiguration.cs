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

    public class ProductWarehouseConfiguration : IEntityTypeConfiguration<ProductWarehouse>
    {
        private const int KeyMaxLength = 64;
        public void Configure(EntityTypeBuilder<ProductWarehouse> builder)
        {
            builder.HasKey(x => new {x.ProductId, x.WarehouseId});
            builder.Property(x => x.ProductId).HasMaxLength(KeyMaxLength).IsRequired();
            builder.Property(x => x.WarehouseId).HasMaxLength(KeyMaxLength).IsRequired();
        }
    }
}
