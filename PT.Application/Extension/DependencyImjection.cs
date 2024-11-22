using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Abstraction.Behaviours;
using PT.Application.Abstraction.ExternalApi.OptionsSettings;

namespace PT.Application.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(ValidationBehaviour<,>));  
            });


            services.Configure<GoogleAuthConfig>(configuration.GetSection("GoogleAuthConfig"));

            //AddHttpClientFactory(services,configuration);
            
            return services; 
        }

    }
    private static void AddHttpClientFactory(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection("ApiSettings").Get<GoogleAuthConfig>();

        if (settings == null || string.IsNullOrWhiteSpace(settings.ClientName) || string.IsNullOrWhiteSpace(settings.Api?.BaseUrl))
        {
            throw new ArgumentException("Invalid API settings in configuration.");
        }

        services.AddHttpClient(settings.ClientName, client =>
        {
            client.Timeout = TimeSpan.FromMinutes(1);
            client.BaseAddress = new Uri(settings.Api.BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        });
    }
}
