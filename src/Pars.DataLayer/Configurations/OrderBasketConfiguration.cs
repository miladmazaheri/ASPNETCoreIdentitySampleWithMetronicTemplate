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
    public class OrderBasketConfiguration : IEntityTypeConfiguration<OrderBasket>
    {
        private const int KeyMaxLength = 64;
        private const int StringMaxLength = 128;
        public void Configure(EntityTypeBuilder<OrderBasket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId).HasMaxLength(KeyMaxLength).IsRequired();
            builder.Property(product => product.Name).HasMaxLength(StringMaxLength).IsRequired();
            builder.HasIndex(i => new { i.UserId, i.ProductId }).IsUnique();
        }
    }
}
