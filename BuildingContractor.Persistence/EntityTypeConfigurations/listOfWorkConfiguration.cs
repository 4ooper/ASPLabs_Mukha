using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class listOfWorkConfiguration : IEntityTypeConfiguration<listOfWork>
    {
        public void Configure(EntityTypeBuilder<listOfWork> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.name).HasMaxLength(50).IsRequired();
            builder.Property(note => note.licenseID).IsRequired();
        }
    }
}
