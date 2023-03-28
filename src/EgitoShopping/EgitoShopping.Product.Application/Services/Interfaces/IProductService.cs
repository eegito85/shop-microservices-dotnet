using EgitoShopping.Product.Application.DTOs;
using EgitoShopping.Product.Domain.Entities;

namespace EgitoShopping.Product.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProdutoDTO>> FindAllAsync();
        Task<ProdutoDTO> FindByIdAsync(long id);
        Task<ProdutoDTO> CreateAsync(ProdutoDTO produto);
        Task<ProdutoDTO> UpdateAsync(ProdutoDTO produto);
        Task<bool> DeleteByIdAsync(long id);
    }
}
