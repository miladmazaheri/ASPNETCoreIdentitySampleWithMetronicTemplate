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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        private const int StringMaxLength = 128;
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(product => product.Title).HasMaxLength(StringMaxLength).IsRequired();
            builder.Property(product => product.DriverName).HasMaxLength(StringMaxLength);
            builder.Property(product => product.DriverPhoneNumber).HasMaxLength(StringMaxLength);
            builder.Property(product => product.FreightName).HasMaxLength(StringMaxLength);
            builder.Property(product => product.FreightPhoneNumber).HasMaxLength(StringMaxLength);

            builder.HasOne(x=>x.User).WithMany().HasForeignKey(x=>x.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=>x.ReferralUser).WithMany().HasForeignKey(x=>x.ReferralUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        private const int KeyMaxLength = 64;
        private const int StringMaxLength = 128;
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.ProductId).HasMaxLength(KeyMaxLength).IsRequired();
            builder.HasOne(x => x.Order).WithMany(x=>x.OrderItems).HasForeignKey(x => x.OrderId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class OrderCheckoutConfiguration : IEntityTypeConfiguration<OrderCheckout>
    {
        private const int StringMaxLength = 128;
        public void Configure(EntityTypeBuilder<OrderCheckout> builder)
        {
            builder.Property(x => x.BankName).HasMaxLength(StringMaxLength).IsRequired();
            builder.Property(x => x.ReferenceNumber).HasMaxLength(StringMaxLength).IsRequired();
            builder.HasOne(x => x.Order).WithMany(x => x.OrderCheckouts).HasForeignKey(x => x.OrderId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
