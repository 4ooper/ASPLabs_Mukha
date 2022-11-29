using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = @"Server=MUKHA;Database=lab1;Trusted_Connection=True;";
            //var connectionString = @"Server=LBOR\SQLEXPRESS;Database=rpbd_mukha;Trusted_Connection=True;";
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddScoped<INotesDbContext>(provider =>
                provider.GetService<AppDbContext>());

            return services;
        }
    }
}
