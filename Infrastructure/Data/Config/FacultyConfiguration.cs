using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class FacultyConfiguration : IEntityTypeConfiguration<SchoolFaculty>
    {
        public void Configure(EntityTypeBuilder<SchoolFaculty> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(p => p.School)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(p => p.SchoolId)
                    .IsRequired();
            builder.HasOne(p => p.TranscriptRequests)
                    .WithOne(p => p.Faculty)
                    .HasForeignKey<TranscriptRequest>(t => t.FacultyId);
            builder.Property(p => p.CreateDate).IsRequired();
        }
    }
}