using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PT.Infratructure.Data;
using PT.Infratructure.Jwt;
using System.Configuration;

namespace PT.Infratructure.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration config)
        {
            AddJWTAuth(services, config);
            return services;
        }
        private static IServiceCollection AddJWTAuth(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions<JwtSettings>().BindConfiguration(nameof(JwtSettings)).ValidateDataAnnotations().ValidateOnStart();
            services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBeareroptions>();
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = config.GetSection("GoogleAuthConfig").GetValue<string>("ClientId");
                googleOptions.ClientSecret = config.GetSection("GoogleAuthConfig").GetValue<string>("ClientSecret");
            });
            return services.AddAuthentication(authentication =>
             {
                 authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             })
             .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, null!).Services;
        }
        private static void AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            string connectionString =
         config.GetConnectionString("DefaultConnection")
         ?? throw new ArgumentNullException(nameof(config));
            services.AddDbContext<PTContext>(Opt => Opt.UseMySQL(config.GetConnectionString(connectionString)));
        }
    }
}
