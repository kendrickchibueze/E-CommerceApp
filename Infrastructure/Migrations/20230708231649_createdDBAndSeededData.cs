using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class createdDBAndSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alibaba" },
                    { 2, "Shopify" },
                    { 3, "Amazon" },
                    { 4, "Nike" },
                    { 5, "Apple" },
                    { 6, "Zara" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chairs" },
                    { 2, "Tables" },
                    { 3, "Phones" },
                    { 4, "Laptops" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "ProductBrandId", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, "This is the description for a nice Hp Envy Laptop. Check it out of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.", "Hp Envy Laptop", "Images/Products/lap8.jpg", 109m, 3, 4 },
                    { 2, "Add a touch of elegance to your dining room with this modern dining table. It features a sleek design and high-quality materials.", "Modern Dining Table", "Images/Products/table1.jpg", 299m, 6, 2 },
                    { 3, "The Dell XPS 15 is a powerful laptop that combines performance and portability. It features a stunning display and top-notch hardware.", "Dell XPS 15", "Images/Products/lap19.jpg", 1499m, 3, 4 },
                    { 4, "The Samsung Galaxy S21 is a flagship smartphone with an impressive camera, powerful performance, and a stunning display.", "Samsung Galaxy S21", "Images/Products/phone1.jpg", 899m, 3, 3 },
                    { 5, "Achieve optimal comfort and productivity with the ErgoFlex Chair. Its ergonomic design promotes good posture and reduces back strain.", "ErgoFlex Chair", "Images/Products/chair2.jpg", 129m, 1, 1 },
                    { 6, "This versatile coffee table can easily transform into a dining table. It's perfect for small spaces and multi-functional use.", "Convertible Coffee Table", "Images/Products/table2.jpg", 199m, 4, 2 },
                    { 7, "The Lenovo ThinkPad X1 Carbon is a lightweight and durable laptop that offers exceptional performance and long battery life.", "Lenovo ThinkPad X1 Carbon", "Images/Products/lap10.jpg", 1799m, 2, 4 },
                    { 8, "The iPhone 13 Pro is Apple's latest flagship smartphone. It boasts a powerful A15 Bionic chip, advanced camera system, and a stunning Super Retina XDR display.", "iPhone 13 Pro", "Images/Products/phone6.jpg", 1299m, 5, 3 },
                    { 9, "Stay cool and comfortable while working with this breathable mesh office chair. It features adjustable armrests and a supportive backrest.", "Mesh Office Chair", "Images/Products/chair3.jpg", 79m, 6, 1 },
                    { 10, "Create a charming dining space with this rustic farmhouse table. Its distressed finish and sturdy construction add character to any room.", "Rustic Farmhouse Table", "Images/Products/table12.jpg", 349m, 1, 2 },
                    { 11, "The HP Spectre x360 is a versatile 2-in-1 laptop that combines elegance and performance. It features a stunning OLED display and long battery life.", "HP Spectre x360", "Images/Products/lap3.jpg", 1299m, 1, 4 },
                    { 12, "The Google Pixel 6 is a flagship smartphone powered by Google's advanced AI technology. It offers a fantastic camera system and a clean Android experience.", "Google Pixel 6", "Images/Products/phone3.jpg", 799m, 3, 3 },
                    { 13, "Make a statement with this executive leather chair. Its luxurious design and ergonomic features provide both style and comfort.", "Executive Leather Chair", "Images/Products/chair4.jpg", 249m, 2, 1 },
                    { 14, "Enhance your entryway or living room with this elegant glass console table. Its sleek design and tempered glass top create a contemporary look.", "Glass Console Table", "Images/Products/table4.jpg", 179m, 4, 2 },
                    { 15, "The ASUS ROG Zephyrus G14 is a gaming laptop that offers a perfect balance of power and portability. It features a high-refresh-rate display and a powerful GPU.", "ASUS ROG Zephyrus G14", "Images/Products/lap4.jpg", 1599m, 2, 4 },
                    { 16, "The Sony Xperia 1 III is a flagship smartphone designed for photography enthusiasts. It features a professional-grade camera system and a stunning 4K OLED display.", "Sony Xperia 1 III", "Images/Products/phone4.jpg", 1199m, 4, 3 },
                    { 17, "Immerse yourself in gaming with this comfortable rocker chair. It features built-in speakers and a sleek design that enhances your gaming experience.", "Gaming Rocker Chair", "Images/Products/chair5.jpg", 149m, 5, 1 },
                    { 18, "Stay active and productive with this adjustable standing desk. It allows you to switch between sitting and standing positions for improved comfort.", "Adjustable Standing Desk", "Images/Products/table5.jpg", 299m, 6, 2 },
                    { 19, "The Microsoft Surface Laptop 4 combines elegance and performance in a lightweight design. It features a vibrant touchscreen display and long battery life.", "Microsoft Surface Laptop 4", "Images/Products/lap5.jpg", 1299m, 5, 4 },
                    { 20, "The OnePlus 9 Pro is a high-performance smartphone that delivers a smooth and fast user experience. It features a Hasselblad camera system for stunning photos.", "OnePlus 9 Pro", "Images/Products/phone5.jpg", 899m, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
