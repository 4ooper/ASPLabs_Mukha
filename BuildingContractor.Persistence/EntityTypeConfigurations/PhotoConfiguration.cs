using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    internal class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.url).HasMaxLength(50);
        }
    }
}
