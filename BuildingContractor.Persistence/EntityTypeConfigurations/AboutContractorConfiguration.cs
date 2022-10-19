using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class AboutContractorConfiguration : IEntityTypeConfiguration<AboutContractor>
    {
        public void Configure(EntityTypeBuilder<AboutContractor> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.contractorTechniquesID);
            builder.Property(note => note.contractorID).IsRequired();
            builder.Property(note => note.contractorStockID);
        }
    }
}
