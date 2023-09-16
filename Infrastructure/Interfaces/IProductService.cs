using Core.Entities;
using Core.Specifications;
using E_CommerceApp.Infrastructure.Dtos;
using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProductService
    {

       Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductSpecParams productParams);

        Task<ProductToReturnDto> GetProductByIdAsync(int id);

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();


    }
}
