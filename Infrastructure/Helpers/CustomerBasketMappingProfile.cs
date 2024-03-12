using AutoMapper;
using Core.Entities;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class CustomerBasketMappingProfile:Profile
    {
        public CustomerBasketMappingProfile()
        {
            CreateMap<CustomerBasketDto, CustomerBasket>();
            
        }
    }
}
