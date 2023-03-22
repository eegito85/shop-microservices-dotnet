using AutoMapper;
using EgitoShopping.Product.Application.DTOs;
using EgitoShopping.Product.Domain.Entities;

namespace EgitoShopping.Product.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
