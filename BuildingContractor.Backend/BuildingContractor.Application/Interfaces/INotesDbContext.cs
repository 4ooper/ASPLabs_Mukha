using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Interfaces
{
    public interface INotesDbContext
    {
        public DbSet<Producer> producers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Contractor> contractors { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<ProvidedWork> providedWorks { get; set; }
        public DbSet<Material> materials { get; set; }
        public DbSet<Technic> technics { get; set; }
        public DbSet<Stock> stock { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
