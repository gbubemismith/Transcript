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

            builder.HasOne(p => p.School)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(p => p.SchoolId)
                    .IsRequired();

            builder.HasOne(p => p.SchoolFaculty)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(p => p.SchoolFacultyId)
                    .IsRequired();

            builder.HasOne(p => p.TranscriptRequests)
                    .WithOne(p => p.Department)
                    .HasForeignKey<TranscriptRequest>(t => t.DepartmentId);
            builder.Property(p => p.CreateDate).IsRequired();
        }
    }
}