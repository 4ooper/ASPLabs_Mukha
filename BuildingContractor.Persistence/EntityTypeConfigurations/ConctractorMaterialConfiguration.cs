using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class ConctractorMaterialConfiguration : IEntityTypeConfiguration<ConctractorMaterial>
    {
        public void Configure(EntityTypeBuilder<ConctractorMaterial> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.name).HasMaxLength(100).IsRequired();
            builder.Property(note => note.createdDate).IsRequired();
            builder.Property(note => note.validaty).IsRequired();
            builder.Property(note => note.producerID).IsRequired();
        }
    }
}
