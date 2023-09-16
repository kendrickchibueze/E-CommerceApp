using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using E_CommerceApp.Errors;
using E_CommerceApp.Infrastructure.Dtos;
using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers
{

    public class ProductsController : BaseApiController
    {
        public readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var products = await _productService.GetProductsAsync(productParams);
            return Ok(products);

        }
     

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product); 
          
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrand =  await _productService.GetProductBrandsAsync();
            return Ok(productBrand);
          
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productType =  await _productService.GetProductTypesAsync();
            return Ok(productType);
           
        }
    }
}
