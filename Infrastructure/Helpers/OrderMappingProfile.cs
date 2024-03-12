using AutoMapper;
using Core.Entities.OrderAggregate;
using Infrastructure.Dtos;

namespace Infrastructure.Helpers
{
    public class OrderMappingProfile : Profile
    {
       public OrderMappingProfile()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<Order, OrderToReturnDto>()
               .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
               .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
        }
    }
}
