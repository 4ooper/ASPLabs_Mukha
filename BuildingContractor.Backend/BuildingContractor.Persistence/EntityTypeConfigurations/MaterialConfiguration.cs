using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Name).HasMaxLength(100).IsRequired();
            builder.Property(note => note.CreationDate).IsRequired();
            builder.Property(note => note.Valid).IsRequired();
            builder.Property(note => note.ProducerId);
        }
    }
}
