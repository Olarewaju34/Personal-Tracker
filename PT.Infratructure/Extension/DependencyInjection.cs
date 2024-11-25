using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PT.Infratructure.Jwt;

namespace PT.Infratructure.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
        private static void AddJWTAuth(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions<JwtSettings>();
                 services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBeareroptions>();
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = config.GetSection("GoogleAuthConfig").GetValue<string>("ClientId");
                googleOptions.ClientSecret = config.GetSection("GoogleAuthConfig").GetValue<string>("ClientId");
            })
        }
    }
}
