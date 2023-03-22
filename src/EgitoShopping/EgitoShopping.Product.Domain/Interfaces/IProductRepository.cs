using EgitoShopping.Product.Domain.Entities;

namespace EgitoShopping.Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Produto>> FindAll();
        Task<Produto> FindById(long id);
        Task<Produto> Create(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<bool> DeleteById(long id);

    }
}
