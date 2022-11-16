using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.Role).HasMaxLength(20).IsRequired();
        }
    }
}
