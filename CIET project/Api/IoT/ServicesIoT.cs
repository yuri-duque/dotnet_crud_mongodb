using Aplication.Services;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api.IoT
{
    public static class ServicesIoT
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();

            return services;
        }
    }
}
