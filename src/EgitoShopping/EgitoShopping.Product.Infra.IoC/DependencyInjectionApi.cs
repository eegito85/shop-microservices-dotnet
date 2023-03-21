using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EgitoShopping.Product.Infra.Data;
using Microsoft.EntityFrameworkCore;

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

            return services;
        }
    }
}
