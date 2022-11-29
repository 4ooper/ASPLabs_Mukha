using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Domain;
using BuildingContractor.Persistence.EntityTypeConfigurations;

namespace BuildingContractor.Persistence
{
    public class AppDbContext : DbContext, INotesDbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<Contractor> contractors { get; set; }
        public DbSet<Producer> producers { get; set; }
        public DbSet<ContractorTechniques> contractorTechniques { get; set; }
        public DbSet<ContractorStock> contractorStock { get; set; }
        public DbSet<ConctractorMaterial> conctractorMaterials { get; set; }
        public DbSet<License> licenses { get; set; }
        public DbSet<listOfWork> listOfWorks { get; set; }
        public DbSet<AboutContractor> aboutContractor { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            builder.ApplyConfiguration(new ContractorConfiguration());
            builder.ApplyConfiguration(new ContractorTechniqueConfiguration());
            builder.ApplyConfiguration(new ConctractorMaterialConfiguration());
            builder.ApplyConfiguration(new ProducerConfiguration());
            builder.ApplyConfiguration(new LicenseConfiguration());
            builder.ApplyConfiguration(new listOfWorkConfiguration());
            builder.ApplyConfiguration(new AboutContractorConfiguration());
            builder.ApplyConfiguration(new ContractorStockConfiguration());
            builder.Entity<ConctractorMaterial>().HasOne(u => u.producer).WithMany(u => u.conctractorMaterials).HasForeignKey(u => u.producerID);
            builder.Entity<listOfWork>().HasOne(u => u.license).WithMany(u => u.listOfWorks).HasForeignKey(u => u.licenseID);
            builder.Entity<ContractorStock>().HasOne(u => u.conctractorMaterial).WithMany(u => u.contractorStocks).HasForeignKey(u => u.contractorMaterialID);
            builder.Entity<AboutContractor>().HasOne(u => u.contractor).WithMany(u => u.aboutContractors).HasForeignKey(u => u.contractorID);
            builder.Entity<AboutContractor>().HasOne(u => u.contractorStock).WithMany(u => u.aboutContractors).HasForeignKey(u => u.contractorStockID);
            builder.Entity<AboutContractor>().HasOne(u => u.contractorTechnique).WithMany(u => u.aboutContractors).HasForeignKey(u => u.contractorTechniquesID);
            base.OnModelCreating(builder);
        }
    }
}
