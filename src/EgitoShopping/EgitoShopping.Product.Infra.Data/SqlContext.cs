using EgitoShopping.Product.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EgitoShopping.Product.Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);
        }
    }
}
