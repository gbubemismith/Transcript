using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<SchoolDepartment>
    {
        public void Configure(EntityTypeBuilder<SchoolDepartment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(p => p.School).WithMany()
                    .HasForeignKey(p => p.SchoolId);
            builder.HasOne(p => p.SchoolFaculty).WithMany()
                    .HasForeignKey(p => p.SchoolFacultyId);
            builder.Property(p => p.CreateDate).IsRequired();
        }
    }
}