using ArtesMarciais.Infra.Extensions;
using ArtesMarciais.Infra.Repositories;
using ArtesMarciais.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtesMarciais.Infra
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepository(services);
            if (configuration.IsTestEnvironment() == false)
            {
                AddDbContext(services, configuration);
            }
        }

        public static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<ILutadorRepository, LutadorRepository>();
        }

        public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var version = new Version(8, 0, 35);
            var serverVersion = new MySqlServerVersion(version);

            services.AddDbContext<ArtesMarciaisDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }
    }
}
