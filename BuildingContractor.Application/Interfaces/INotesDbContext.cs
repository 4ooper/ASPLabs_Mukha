using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Interfaces
{
    public interface INotesDbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<Contractor> contractors { get; set; }
        public DbSet<Producer> producers { get; set; }
        public DbSet<ContractorTechniques> contractorTechniques { get; set; }
        public DbSet<ConctractorMaterial> conctractorMaterials { get; set; }
        public DbSet<ContractorStock> contractorStock { get; set; }
        public DbSet<Domain.AboutContractor> aboutContractor { get; set; }
        public DbSet<listOfWork> listOfWorks { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();

    }
}
