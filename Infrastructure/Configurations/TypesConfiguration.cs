using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TypesConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                new ProductType
                {
                    Id = 1,
                    Name = "Chairs"
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Tables"
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Phones"
                },
                new ProductType
                {
                    Id = 4,
                    Name = "Laptops"
                }

            );
        }
    }
}
