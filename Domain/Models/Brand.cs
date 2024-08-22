using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.Models
{
    public class Brand : BaseModel
    {
        public string Name { get; set; }
    }

    public sealed class ProductBrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> modelBuilder)
        {
            modelBuilder.HasData(
                   new Brand { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b901"), Name = "Starbucks", IsActive = true, IsDeleted = false },
                   new Brand { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b902"), Name = "Costa", IsActive = true, IsDeleted = false },
                   new Brand { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b903"), Name = "Cilantro", IsActive = true, IsDeleted = false },
                   new Brand { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b904"), Name = "TBS", IsActive = true, IsDeleted = false },
                   new Brand { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b905"), Name = "On The Run", IsActive = true, IsDeleted = false },
                   new Brand { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b906"), Name = "Caribou", IsActive = true, IsDeleted = false },
                   new Brand { ID = new Guid("f06c3c8d-b2c2-4cc6-9a1a-8b3b3c82b907"), Name = "Krispy Kreme", IsActive = true, IsDeleted = false }
                         );
        }
    }
}
