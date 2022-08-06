using iKOKO.Persistence;
using iKOKO.Persistence.Repository;
using iKOKO.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iKOKO.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<iKOKODbContext>(opt => opt
                .UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(iKOKODbContext)
                                          .GetTypeInfo().Assembly.GetName().Name)));
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<IIceCreamRepository, IceCreamRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
