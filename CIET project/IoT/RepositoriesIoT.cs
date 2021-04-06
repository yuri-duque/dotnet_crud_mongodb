using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;

namespace IoT
{
    public static class RepositoriesIoT
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
