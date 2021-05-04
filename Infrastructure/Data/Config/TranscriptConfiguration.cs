using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TranscriptConfiguration : IEntityTypeConfiguration<TranscriptRequest>
    {
        public void Configure(EntityTypeBuilder<TranscriptRequest> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.MatricNumber).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ForwardingName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.ForwardingAddress).IsRequired().HasMaxLength(250);
            builder.Property(p => p.CourierType).IsRequired().HasMaxLength(50);


        }
    }
}