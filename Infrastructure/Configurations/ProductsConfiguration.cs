using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Hp Envy Laptop",
                    Description = "This is the description for a nice Hp Envy Laptop. Check it out of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
                    Price = 109,
                    PictureUrl = "Images/Products/lap8.jpg",
                    ProductTypeId = 4,
                    ProductBrandId = 3
                },
              new Product
              {
                  Id = 2,
                  Name = "Modern Dining Table",
                  Description = "Add a touch of elegance to your dining room with this modern dining table. It features a sleek design and high-quality materials.",
                  Price = 299,
                  PictureUrl = "Images/Products/table1.jpg",
                  ProductTypeId = 2,
                  ProductBrandId = 6
              },

               new Product
               {
                   Id = 3,
                   Name = "Dell XPS 15",
                   Description = "The Dell XPS 15 is a powerful laptop that combines performance and portability. It features a stunning display and top-notch hardware.",
                   Price = 1499,
                   PictureUrl = "Images/Products/lap19.jpg",
                   ProductTypeId = 4,
                   ProductBrandId = 3
               },

                 new Product
                 {
                     Id = 4,
                     Name = "Samsung Galaxy S21",
                     Description = "The Samsung Galaxy S21 is a flagship smartphone with an impressive camera, powerful performance, and a stunning display.",
                     Price = 899,
                     PictureUrl = "Images/Products/phone1.jpg",
                     ProductTypeId = 3,
                     ProductBrandId = 3
                 },

                 new Product
                 {
                     Id = 5,
                     Name = "ErgoFlex Chair",
                     Description = "Achieve optimal comfort and productivity with the ErgoFlex Chair. Its ergonomic design promotes good posture and reduces back strain.",
                     Price = 129,
                     PictureUrl = "Images/Products/chair2.jpg",
                     ProductTypeId = 1,
                     ProductBrandId = 1
                 },

                  new Product
                  {
                      Id = 6,
                      Name = "Convertible Coffee Table",
                      Description = "This versatile coffee table can easily transform into a dining table. It's perfect for small spaces and multi-functional use.",
                      Price = 199,
                      PictureUrl = "Images/Products/table2.jpg",
                      ProductTypeId = 2,
                      ProductBrandId = 4
                  },
                  new Product
                  {
                      Id = 7,
                      Name = "Lenovo ThinkPad X1 Carbon",
                      Description = "The Lenovo ThinkPad X1 Carbon is a lightweight and durable laptop that offers exceptional performance and long battery life.",
                      Price = 1799,
                      PictureUrl = "Images/Products/lap10.jpg",
                      ProductTypeId = 4,
                      ProductBrandId = 2
                  },
                  new Product
                  {
                      Id = 8,
                      Name = "iPhone 13 Pro",
                      Description = "The iPhone 13 Pro is Apple's latest flagship smartphone. It boasts a powerful A15 Bionic chip, advanced camera system, and a stunning Super Retina XDR display.",
                      Price = 1299,
                      PictureUrl = "Images/Products/phone6.jpg",
                      ProductTypeId = 3,
                      ProductBrandId = 5
                  },
                  new Product
                  {
                      Id = 9,
                      Name = "Mesh Office Chair",
                      Description = "Stay cool and comfortable while working with this breathable mesh office chair. It features adjustable armrests and a supportive backrest.",
                      Price = 79,
                      PictureUrl = "Images/Products/chair3.jpg",
                      ProductTypeId = 1,
                      ProductBrandId = 6
                  },
                  new Product
                  {
                      Id = 10,
                      Name = "Rustic Farmhouse Table",
                      Description = "Create a charming dining space with this rustic farmhouse table. Its distressed finish and sturdy construction add character to any room.",
                      Price = 349,
                      PictureUrl = "Images/Products/table12.jpg",
                      ProductTypeId = 2,
                      ProductBrandId = 1
                  },
                  new Product
                  {
                      Id = 11,
                      Name = "HP Spectre x360",
                      Description = "The HP Spectre x360 is a versatile 2-in-1 laptop that combines elegance and performance. It features a stunning OLED display and long battery life.",
                      Price = 1299,
                      PictureUrl = "Images/Products/lap3.jpg",
                      ProductTypeId = 4,
                      ProductBrandId = 1
                  },
                  new Product
                  {
                      Id = 12,
                      Name = "Google Pixel 6",
                      Description = "The Google Pixel 6 is a flagship smartphone powered by Google's advanced AI technology. It offers a fantastic camera system and a clean Android experience.",
                      Price = 799,
                      PictureUrl = "Images/Products/phone3.jpg",
                      ProductTypeId = 3,
                      ProductBrandId = 3
                  },
                  new Product
                  {
                      Id = 13,
                      Name = "Executive Leather Chair",
                      Description = "Make a statement with this executive leather chair. Its luxurious design and ergonomic features provide both style and comfort.",
                      Price = 249,
                      PictureUrl = "Images/Products/chair4.jpg",
                      ProductTypeId = 1,
                      ProductBrandId = 2
                  },
                  new Product
                  {
                      Id = 14,
                      Name = "Glass Console Table",
                      Description = "Enhance your entryway or living room with this elegant glass console table. Its sleek design and tempered glass top create a contemporary look.",
                      Price = 179,
                      PictureUrl = "Images/Products/table4.jpg",
                      ProductTypeId = 2,
                      ProductBrandId = 4
                  },
                  new Product
                  {
                      Id = 15,
                      Name = "ASUS ROG Zephyrus G14",
                      Description = "The ASUS ROG Zephyrus G14 is a gaming laptop that offers a perfect balance of power and portability. It features a high-refresh-rate display and a powerful GPU.",
                      Price = 1599,
                      PictureUrl = "Images/Products/lap4.jpg",
                      ProductTypeId = 4,
                      ProductBrandId = 2
                  },
                  new Product
                  {
                      Id = 16,
                      Name = "Sony Xperia 1 III",
                      Description = "The Sony Xperia 1 III is a flagship smartphone designed for photography enthusiasts. It features a professional-grade camera system and a stunning 4K OLED display.",
                      Price = 1199,
                      PictureUrl = "Images/Products/phone4.jpg",
                      ProductTypeId = 3,
                      ProductBrandId = 4
                  },
                  new Product
                  {
                      Id = 17,
                      Name = "Gaming Rocker Chair",
                      Description = "Immerse yourself in gaming with this comfortable rocker chair. It features built-in speakers and a sleek design that enhances your gaming experience.",
                      Price = 149,
                      PictureUrl = "Images/Products/chair5.jpg",
                      ProductTypeId = 1,
                      ProductBrandId = 5
                  },
                  new Product
                  {
                      Id = 18,
                      Name = "Adjustable Standing Desk",
                      Description = "Stay active and productive with this adjustable standing desk. It allows you to switch between sitting and standing positions for improved comfort.",
                      Price = 299,
                      PictureUrl = "Images/Products/table5.jpg",
                      ProductTypeId = 2,
                      ProductBrandId = 6
                  },
                  new Product
                  {
                      Id = 19,
                      Name = "Microsoft Surface Laptop 4",
                      Description = "The Microsoft Surface Laptop 4 combines elegance and performance in a lightweight design. It features a vibrant touchscreen display and long battery life.",
                      Price = 1299,
                      PictureUrl = "Images/Products/lap5.jpg",
                      ProductTypeId = 4,
                      ProductBrandId = 5
                  },
                  new Product
                  {
                      Id = 20,
                      Name = "OnePlus 9 Pro",
                      Description = "The OnePlus 9 Pro is a high-performance smartphone that delivers a smooth and fast user experience. It features a Hasselblad camera system for stunning photos.",
                      Price = 899,
                      PictureUrl = "Images/Products/phone5.jpg",
                      ProductTypeId = 3,
                      ProductBrandId = 2
                  }















            );
        }
    }
}
