using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PT.Application.Abstraction.ExternalApi;
using PT.Application.Abstraction;
using PT.Application.Abstraction.ExternalApi.OptionsSettings;
using PT.Application.Abstraction.Repositories;
using PT.Infratructure.Authentication;
using PT.Infratructure.Data;
using PT.Infratructure.Jwt;
using PT.Infratructure.Repositories;
using System.Configuration;
using PT.Infratructure.Caching;
using PT.Application.Caching;

namespace PT.Infratructure.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration config)
        {
            AddJWTAuth(services, config);
            AddPersistence(services, config);
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
            services.Configure< GoogleAuthConfig>(config.GetSection("GoogleAuthConfig"));
            services.AddSingleton<GoogleAuthConfig>(sp=>sp.GetRequiredService<IOptions<GoogleAuthConfig>>().Value);


            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<ITransactionRepository, TransactionsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGoogleAuthService, GoogleAuthentication>();
            services.AddSingleton<ICachedService, CacheService>();
        }
      
    }
}
