using Core.Entities;
using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(180);
            builder.Property(p => p.State).IsRequired().HasMaxLength(180);
            builder.Property(p => p.Country).IsRequired().HasMaxLength(180);
            builder.Property(p => p.CreateDate).IsRequired();

            builder.HasOne(p => p.User)
                    .WithOne(p => p.Schools)
                    .HasForeignKey<User>(u => u.SchoolId);

        }
    }
}