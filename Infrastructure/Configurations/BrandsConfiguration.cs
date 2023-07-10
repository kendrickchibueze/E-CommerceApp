using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BrandsConfiguration : IEntityTypeConfiguration<ProductBrand>
    {

        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasData(
                new ProductBrand
                {
                    Id = 1,
                    Name = "Alibaba"
                },
                new ProductBrand
                {
                    Id = 2,
                    Name = "Shopify"
                },
                new ProductBrand
                {
                    Id = 3,
                    Name = "Amazon"
                },
                new ProductBrand
                {
                    Id = 4,
                    Name = "Nike"
                },
                new ProductBrand
                {
                    Id = 5,
                    Name = "Apple"
                },
                new ProductBrand
                {
                    Id = 6,
                    Name = "Zara"
                }
            );
        }
    }
}
