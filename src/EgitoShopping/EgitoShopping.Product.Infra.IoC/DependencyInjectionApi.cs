using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EgitoShopping.Product.Infra.Data;
using Microsoft.EntityFrameworkCore;
using EgitoShopping.Product.Application.Mappings;
using EgitoShopping.Product.Application.Services.Interfaces;
using EgitoShopping.Product.Application.Services;
using EgitoShopping.Product.Domain.Interfaces;
using EgitoShopping.Product.Infra.Data.Repositories;

namespace EgitoShopping.Product.Infra.IoC
{
    public static class DependencyInjectionApi
    {
        public static IServiceCollection AddInfrastructureApi(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
            b => b.MigrationsAssembly(typeof(SqlContext).Assembly.FullName)));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
