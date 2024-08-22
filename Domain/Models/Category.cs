using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
    }

    public sealed class ProductCategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.HasData(
                   new Category { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), Name = "Frappuccino", IsActive = true, IsDeleted = false },
                   new Category { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), Name = "Latte", IsActive = true, IsDeleted = false },
                   new Category { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), Name = "Mocha", IsActive = true, IsDeleted = false },
                   new Category { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), Name = "Macchiato", IsActive = true, IsDeleted = false },
                   new Category { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"), Name = "Cake", IsActive = true, IsDeleted = false },
                   new Category { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), Name = "Donuts", IsActive = true, IsDeleted = false },
                   new Category { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"), Name = "Salad", IsActive = true, IsDeleted = false }
                         );
        }
    }
}
