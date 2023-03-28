using EgitoShopping.Product.Domain.Entities;
using EgitoShopping.Product.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EgitoShopping.Product.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlContext _context;

        public ProductRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> FindAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> FindById(long id)
        {
            Produto product = new Produto(); 
            var produto = await _context.Produtos.FindAsync(id);
            if(produto == null) { return product; }
            return produto;
        }

        public async Task<Produto> Create(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Update(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeleteById(long id)
        {
            var product = await _context.Produtos.FindAsync(id);
            if (product == null) return false;
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
