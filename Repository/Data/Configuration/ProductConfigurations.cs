using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Repository.Data.Configuration
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired(true);

            builder.Property(p => p.PictureURL)
                .IsRequired(true);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(b => b.Brand)
                .WithMany()
                .HasForeignKey(p=>p.BrandID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Category)
               .WithMany()
               .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
