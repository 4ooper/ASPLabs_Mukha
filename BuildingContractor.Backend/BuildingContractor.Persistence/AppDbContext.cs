using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Domain;
using BuildingContractor.Persistence.EntityTypeConfigurations;

namespace BuildingContractor.Persistence
{
    public class AppDbContext : DbContext, INotesDbContext
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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProducerConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new ContractorConfiguration());
            builder.ApplyConfiguration(new BuildingConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            builder.ApplyConfiguration(new ProvidedWorkConfiguration());
            builder.ApplyConfiguration(new MaterialConfiguration());
            builder.ApplyConfiguration(new TechnicConfiguration());
            builder.ApplyConfiguration(new StockConfiguration());
            builder.Entity<Building>().HasOne(u => u.Customer).WithMany(u => u.Buildings).HasForeignKey(u => u.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Building>().HasOne(u => u.Contractor).WithMany(u => u.Buildings).HasForeignKey(u => u.ContractorId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Photo>().HasOne(u => u.Building).WithMany(u => u.Photos).HasForeignKey(u => u.BuildingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProvidedWork>().HasOne(u => u.Building).WithMany(u => u.ProvidedWorks).HasForeignKey(u => u.BuildingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Material>().HasOne(u => u.Producer).WithMany(u => u.Materials).HasForeignKey(u => u.ProducerId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Technic>().HasOne(u => u.Contractor).WithMany(u => u.Technics).HasForeignKey(u => u.ContractorId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Stock>().HasOne(u => u.Material).WithMany(u => u.Stocks).HasForeignKey(u => u.MaterialId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Stock>().HasOne(u => u.Contractor).WithMany(u => u.Stock).HasForeignKey(u => u.ContractorId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>().HasOne(u => u.Role).WithMany(u => u.users).HasForeignKey(u => u.RoleId);
            base.OnModelCreating(builder);
        }
    }
}
