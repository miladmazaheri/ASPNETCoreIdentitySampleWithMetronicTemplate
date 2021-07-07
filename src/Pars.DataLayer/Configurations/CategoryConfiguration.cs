using Pars.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pars.DataLayer.Mappings
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        private const int KeyMaxLength = 64;
        private const int StringMaxLength = 128;
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(KeyMaxLength);
            builder.Property(category => category.Name).HasMaxLength(StringMaxLength).IsRequired();
            builder.Property(category => category.Title).HasMaxLength(StringMaxLength);
        }
    }
}