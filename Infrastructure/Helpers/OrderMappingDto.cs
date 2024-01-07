using AutoMapper;
using Core.Entities.OrderAggregate;
using Infrastructure.Dtos;

namespace Infrastructure.Helpers
{
    public class OrderMappingDto : Profile
    {

        public OrderMappingDto()
        {
            CreateMap<AddressDto, Address>();
        }
    }
}
