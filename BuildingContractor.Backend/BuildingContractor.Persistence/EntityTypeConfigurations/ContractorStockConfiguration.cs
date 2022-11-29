using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class ContractorStockConfiguration : IEntityTypeConfiguration<ContractorStock>
    {
        public void Configure(EntityTypeBuilder<ContractorStock> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.count).IsRequired();
            builder.Property(note => note.price).IsRequired();
            builder.Property(note => note.contractorMaterialID).IsRequired();
        }
    }
}
