using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modal.Repository.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "Common",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Common",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalSchema: "Common",
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "Common",
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Brands",
                columns: new[] { "ID", "CreatedDate", "IsActive", "IsArchived", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), null, true, null, false, "Starbucks" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), null, true, null, false, "Costa" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), null, true, null, false, "Cilantro" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), null, true, null, false, "TBS" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"), null, true, null, false, "On The Run" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), null, true, null, false, "Caribou" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"), null, true, null, false, "Krispy Kreme" }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "IsActive", "IsArchived", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), null, true, null, false, "Frappuccino" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), null, true, null, false, "Latte" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), null, true, null, false, "Mocha" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), null, true, null, false, "Macchiato" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"), null, true, null, false, "Cake" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), null, true, null, false, "Donuts" },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"), null, true, null, false, "Salad" }
                });

            migrationBuilder.InsertData(
                schema: "Product",
                table: "Products",
                columns: new[] { "ID", "BrandID", "CategoryID", "CreatedDate", "Description", "IsActive", "IsArchived", "IsDeleted", "Name", "PictureURL", "Price" },
                values: new object[,]
                {
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6777), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", true, null, false, "Double Caramel Frappuccino", "images/products/sb-ang1.png", 200m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6813), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", true, null, false, "White Chocolate Mocha Frappuccino", "images/products/sb-ang2.png", 150m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6817), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", true, null, false, "Iced Cafe Latte", "images/products/sb-core1.png", 180m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6820), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc.", true, null, false, "White Chocolate Mocha", "images/products/sb-core2.png", 300m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6824), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.", true, null, false, "Iced Caramel Macchiato", "images/products/sb-react1.png", 300m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6827), "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", true, null, false, "Hot Caramel Macchiato", "images/products/sb-ts1.png", 120m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6830), "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", true, null, false, "Iced Matcha Latte", "images/products/hat-core1.png", 10m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b908"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6835), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", true, null, false, "Honey Cake", "images/products/hat-react1.png", 8m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b909"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6840), "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", true, null, false, "Blueberry Cheesecake", "images/products/hat-react2.png", 15m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b910"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6844), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", true, null, false, "Glazed Donuts", "images/products/glove-code1.png", 18m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b911"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6880), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", true, null, false, "Greek Salad", "images/products/glove-code2.png", 15m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b912"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6885), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", true, null, false, "Purple React Gloves", "images/products/glove-react1.png", 16m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b913"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6888), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", true, null, false, "Green React Gloves", "images/products/glove-react2.png", 14m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b914"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6892), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", true, null, false, "Redis Red Boots", "images/products/boot-redis1.png", 250m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b915"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6895), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", true, null, false, "Core Red Boots", "images/products/boot-core2.png", 189m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b916"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6899), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", true, null, false, "Core Purple Boots", "images/products/boot-core1.png", 199m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b917"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6903), "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", true, null, false, "Angular Purple Boots", "images/products/boot-ang2.png", 150m },
                    { new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b918"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), new DateTime(2024, 8, 22, 11, 28, 35, 157, DateTimeKind.Local).AddTicks(6906), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", true, null, false, "Angular Blue Boots", "images/products/boot-ang1.png", 180m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                schema: "Product",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                schema: "Product",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Common");
        }
    }
}
