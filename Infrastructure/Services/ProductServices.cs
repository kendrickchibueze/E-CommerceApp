using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using E_CommerceApp.Infrastructure.Dtos;
using Infrastructure.Helpers;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class ProductServices : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _productsRepo;
        private readonly IRepository<ProductBrand> _productBrandRepo;
        private readonly IRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _productsRepo = _unitOfWork.GetRepository<Product>();
            _productBrandRepo = _unitOfWork.GetRepository<ProductBrand>();
            _productTypeRepo = _unitOfWork.GetRepository<ProductType>();
        }

        public async Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductSpecParams productParams)
        {

            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);
            var totalItems = await _productsRepo.CountAsync(countSpec);
            var products = await _productsRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            return new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data);
        }
        public  async Task<ProductToReturnDto> GetProductByIdAsync(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if (product == null)
            {
                _logger.LogError("Product cannot be found");
            }
            var newProduct = _mapper.Map<ProductToReturnDto>(product);
             return newProduct;
        }

        public  async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var productBrands = await _productBrandRepo.ListAllAsync();
             return productBrands;
        }

        public  async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _productTypeRepo.ListAllAsync();
            return productTypes;         
        }
    }
}
