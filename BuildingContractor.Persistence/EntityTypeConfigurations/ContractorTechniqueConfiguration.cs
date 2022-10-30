using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class ContractorTechniqueConfiguration : IEntityTypeConfiguration<ContractorTechniques>
    { 
        public void Configure(EntityTypeBuilder<ContractorTechniques> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.name).HasMaxLength(100).IsRequired();
            builder.Property(note => note.buyDate).HasMaxLength(100).IsRequired();
            builder.Property(note => note.validaty).HasMaxLength(100).IsRequired();
        }
    }
}