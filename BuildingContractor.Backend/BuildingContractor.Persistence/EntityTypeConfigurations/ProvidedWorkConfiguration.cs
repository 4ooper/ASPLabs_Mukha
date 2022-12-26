using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class ProvidedWorkConfiguration : IEntityTypeConfiguration<ProvidedWork>
    {
        public void Configure(EntityTypeBuilder<ProvidedWork> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Description).HasMaxLength(300).IsRequired();
            builder.Property(note => note.Price).IsRequired();
            builder.Property(note => note.Discount).IsRequired();
            builder.Property(note => note.BuildingId).IsRequired();
        }
    }
}
