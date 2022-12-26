using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Name).IsRequired();
            builder.Property(note => note.ContractorId);
            builder.Property(note => note.CustomerId);
            builder.Property(note => note.ConclusionDate).IsRequired();
            builder.Property(note => note.DeliveryDate).IsRequired();
            builder.Property(note => note.ComissioningDate).IsRequired();
        }
    }
}
