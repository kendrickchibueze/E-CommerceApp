using AutoMapper;
using Core.Entities;
using E_CommerceApp.Infrastructure.Dtos;

namespace Infrastructure.Helpers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
               .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
               .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
               .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());
                
            CreateMap<ProductToReturnDto, Product>();
        }
    }
}
