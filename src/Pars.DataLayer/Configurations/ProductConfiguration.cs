using Pars.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pars.DataLayer.Mappings
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private const int KeyMaxLength = 64;
        private const int StringMaxLength = 128;
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(KeyMaxLength);
            builder.Property(x => x.CategoryId).HasMaxLength(KeyMaxLength).IsRequired();

            builder.Property(product => product.Name).HasMaxLength(StringMaxLength).IsRequired();
            builder.Property(product => product.Size).HasMaxLength(StringMaxLength);
            builder.Property(product => product.Code).HasMaxLength(StringMaxLength);
            builder.Property(product => product.CountInBox).HasMaxLength(StringMaxLength);
            builder.Property(product => product.Material).HasMaxLength(StringMaxLength);
            builder.Property(product => product.Usage).HasMaxLength(StringMaxLength);
            builder.Property(product => product.BranchSize).HasMaxLength(StringMaxLength);
            builder.Property(product => product.Color).HasMaxLength(StringMaxLength);
            builder.Property(product => product.Thickness).HasMaxLength(StringMaxLength);
            builder.Property(product => product.BoxWeight).HasMaxLength(StringMaxLength);

            builder.HasOne(product => product.Category)
                   .WithMany(category => category.Products).HasForeignKey(x => x.CategoryId).IsRequired(false);
        }
    }
}