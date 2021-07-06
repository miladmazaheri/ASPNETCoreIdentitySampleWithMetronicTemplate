using Pars.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pars.DataLayer.Mappings
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.UniqueCode)
                .HasComputedColumnSql("RIGHT('000000'+CAST([Id] AS VARCHAR(20)),6)").IsRequired();
            builder.HasOne(x => x.ReferralUser).WithMany().HasForeignKey(x => x.ReferralUserId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
    }
}