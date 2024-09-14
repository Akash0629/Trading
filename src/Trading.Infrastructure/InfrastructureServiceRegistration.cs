using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trading.Application.Contracts.Persistence;
using Trading.Infrastructure.Persistence;
using Trading.Infrastructure.Repositories;

namespace Trading.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataBaseContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
         
            services.AddScoped<IPositionRepository, PositionRepository>();

            return services;
        }
    }
}
