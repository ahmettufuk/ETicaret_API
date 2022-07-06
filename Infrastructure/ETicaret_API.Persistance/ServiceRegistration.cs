using ETicaret_API.Application.Absraction;
using ETicaret_API.Persistance.Concretes;
using ETicaret_API.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ETicaret_API.Application.Repositories;
using ETicaret_API.Persistance.Repositories;

namespace ETicaret_API.Persistance
{
    public static class ServiceRegistration
    {
        
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           

            services.AddDbContext<ETicaret_API_DbContext> (options => options.UseNpgsql(Configuration.ConnectionString) , ServiceLifetime.Singleton);

            

            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();

            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
