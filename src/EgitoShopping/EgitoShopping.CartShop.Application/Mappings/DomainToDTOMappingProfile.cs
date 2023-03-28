using AutoMapper;
using EgitoShopping.CartShop.Application.DTOs;
using EgitoShopping.CartShop.Domain.Entities;

namespace EgitoShopping.CartShop.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CartHeader, CartHeaderDTO>().ReverseMap();
            CreateMap<CartDetail, CartDetailDTO>().ReverseMap();
        }
    }
}
