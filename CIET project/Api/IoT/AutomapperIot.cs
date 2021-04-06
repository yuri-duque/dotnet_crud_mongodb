using Microsoft.Extensions.DependencyInjection;

namespace Api.IoT
{
    public static class AutoMapperIoT
    {
        public static IServiceCollection AddAutoMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));

            return services;
        }
    }
}
