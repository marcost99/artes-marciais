using ArtesMarciais.Domain.Mapper;
using ArtesMarciais.Domain.Services;
using ArtesMarciais.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArtesMarciais.Domain
{
    public static class DependencyInjectionExtension
    {
        public static void AddDomain(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddServices(services);
        }

        public static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ILutadorService, LutadorService>();
        }
    }
}
