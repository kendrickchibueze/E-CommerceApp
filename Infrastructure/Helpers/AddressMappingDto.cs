using AutoMapper;
using Core.Entities.Identity;
using Infrastructure.Dtos;

namespace Infrastructure.Helpers
{
    public class AddressMappingDto : Profile
    {

        public AddressMappingDto()
        {
            CreateMap<Address, AddressDto>().ReverseMap();

           
        }

    }
}
