using AutoMapper;
using EgitoShopping.Product.Application.DTOs;
using EgitoShopping.Product.Application.Services.Interfaces;
using EgitoShopping.Product.Domain.Entities;
using EgitoShopping.Product.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitoShopping.Product.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> CreateAsync(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            produto = await _repository.Create(produto);

            return produtoDTO;
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return false;

            try
            {
                return await _repository.DeleteById(id);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProdutoDTO>> FindAllAsync()
        {
            var produtos = await _repository.FindAll();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO> FindByIdAsync(long id)
        {
            var product = await _repository.FindById(id);
            return _mapper.Map<ProdutoDTO>(product);
        }

        public async Task<ProdutoDTO> UpdateAsync(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            produto = await _repository.Update(produto);

            return produtoDTO;
        }
    }
}
