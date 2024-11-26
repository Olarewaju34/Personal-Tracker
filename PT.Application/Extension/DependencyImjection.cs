using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Abstraction.Behaviours;
using PT.Application.Abstraction.ExternalApi.OptionsSettings;

namespace PT.Application.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                configuration.AddOpenBehavior(typeof(ValidationBehaviour<,>));

                configuration.AddOpenBehavior(typeof(QueryCachingBehavior<,>));


            });

            return services;
        }

    }

}
