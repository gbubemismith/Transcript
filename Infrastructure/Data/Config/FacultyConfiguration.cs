using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class FacultyConfiguration : IEntityTypeConfiguration<SchoolFaculty>
    {
        public void Configure(EntityTypeBuilder<SchoolFaculty> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(p => p.School).WithMany()
                    .HasForeignKey(p => p.SchoolId);
            builder.Property(p => p.CreateDate).IsRequired();
        }
    }
}