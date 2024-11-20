using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Abstraction.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return services; 
        }

    }
}
