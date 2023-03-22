using EgitoShopping.Product.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EgitoShopping.Product.Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
            
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 3,
                Name = "Capacete Darth Vader",
                Price = new decimal(255.50),
                Description = "Capacete tamanho real Darth Vader - Star Wars",
                CategoryName = "Presentes",
                UrlImage = "C:\\Users\\emmanuel.marinho\\Downloads\\ShoppingImages\\3_vader"
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);

            
        }
    }
}
