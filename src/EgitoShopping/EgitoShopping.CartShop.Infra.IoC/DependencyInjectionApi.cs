using EgitoShopping.CartShop.Application.Mappings;
using EgitoShopping.CartShop.Application.Services;
using EgitoShopping.CartShop.Application.Services.Interfaces;
using EgitoShopping.CartShop.Domain.Interfaces;
using EgitoShopping.CartShop.Infra.Data.Context;
using EgitoShopping.CartShop.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EgitoShopping.CartShop.Infra.IoC
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

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}
