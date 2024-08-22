using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.Models
{
    public class Product: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Brand")]
        public Guid BrandID { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("ProductCategory")]
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }

    public sealed class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> modelBuilder)
        {

            modelBuilder.HasData(
                   new Product
                   {
                       ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                       Name = "Double Caramel Frappuccino",
                       Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                       Price = 200,
                       PictureURL = "images/products/sb-ang1.png",
                       CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                       BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                       IsActive = true,
                       IsDeleted = false,
                       CreatedDate = DateTime.Now

                   },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"),
                        Name = "White Chocolate Mocha Frappuccino",
                        Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        Price = 150,
                        PictureURL = "images/products/sb-ang2.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        Name = "Iced Cafe Latte",
                        Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 180,
                        PictureURL = "images/products/sb-core1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"),
                        Name = "White Chocolate Mocha",
                        Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc.",
                        Price = 300,
                        PictureURL = "images/products/sb-core2.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"),
                        Name = "Iced Caramel Macchiato",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                        Price = 300,
                        PictureURL = "images/products/sb-react1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"),
                        Name = "Hot Caramel Macchiato",
                        Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                        Price = 120,
                        PictureURL = "images/products/sb-ts1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"),
                        Name = "Iced Matcha Latte",
                        Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 10,
                        PictureURL = "images/products/hat-core1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b908"),
                        Name = "Honey Cake",
                        Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 8,
                        PictureURL = "images/products/hat-react1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b909"),
                        Name = "Blueberry Cheesecake",
                        Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 15,
                        PictureURL = "images/products/hat-react2.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b910"),
                        Name = "Glazed Donuts",
                        Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        Price = 18,
                        PictureURL = "images/products/glove-code1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b911"),
                        Name = "Greek Salad",
                        Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 15,
                        PictureURL = "images/products/glove-code2.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b912"),
                        Name = "Purple React Gloves",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                        Price = 16,
                        PictureURL = "images/products/glove-react1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b913"),
                        Name = "Green React Gloves",
                        Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 14,
                        PictureURL = "images/products/glove-react2.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b914"),
                        Name = "Redis Red Boots",
                        Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 250,
                        PictureURL = "images/products/boot-redis1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b915"),
                        Name = "Core Red Boots",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 189,
                        PictureURL = "images/products/boot-core2.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b916"),
                        Name = "Core Purple Boots",
                        Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 199,
                        PictureURL = "images/products/boot-core1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b917"),
                        Name = "Angular Purple Boots",
                        Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                        Price = 150,
                        PictureURL = "images/products/boot-ang2.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b918"),
                        Name = "Angular Blue Boots",
                        Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 180,
                        PictureURL = "images/products/boot-ang1.png",
                        CategoryID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"),
                        BrandID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    }
                         );
        }
    }

}
