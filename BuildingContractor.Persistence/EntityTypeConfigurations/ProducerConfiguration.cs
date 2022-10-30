using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.name).HasMaxLength(100).IsRequired();
        }
    }
}
