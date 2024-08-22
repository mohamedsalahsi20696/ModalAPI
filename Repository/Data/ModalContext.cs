using Microsoft.EntityFrameworkCore;
using Modal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Repository.Data
{
    // Add-Migration "InitialDB" -o Data/Migrations 
    public class ModalContext : DbContext
    {
        public ModalContext()
        {
        }

        public ModalContext(DbContextOptions<ModalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> ProductBrands { get; set; }
        public virtual DbSet<Category> ProductCategories { get; set; }
        public virtual DbSet<Product> Product { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Brand>().ToTable("Brands", "Common");
            modelBuilder.Entity<Category>().ToTable("Categories", "Common");
            modelBuilder.Entity<Product>().ToTable("Products", "Product");

            //modelBuilder.Entity<AppUser>().ToTable("AppUser", "Core");
            //modelBuilder.Entity<Roles>().ToTable("Roles", "Core");
            //modelBuilder.Entity<UserClaim>().ToTable("UserClaims", "Core");
            //modelBuilder.Entity<UserRole>().ToTable("UserRoles", "Core");
            //modelBuilder.Entity<UserLogin>().ToTable("UserLogins", "Core");
            //modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", "Core");
            //modelBuilder.Entity<UserToken>().ToTable("UserTokens", "Core");
            //modelBuilder.Entity<RoleManagement>().ToTable("RolesManagement", "Core");
            //modelBuilder.Entity<Permission>().ToTable("Permissions", "Core");
            //modelBuilder.Entity<RolesPermissions>().ToTable("RolesPermissions", "Core");


            modelBuilder.ApplyConfiguration<Brand>(new ProductBrandMap());
            modelBuilder.ApplyConfiguration<Category>(new ProductCategoryMap());
            modelBuilder.ApplyConfiguration<Product>(new ProductMap());


            //modelBuilder.ApplyConfiguration<Roles>(new RolesMap());
            //modelBuilder.ApplyConfiguration<Permission>(new PermissionMap());
            //modelBuilder.ApplyConfiguration<RoleManagement>(new RoleManagementsMap());
            //modelBuilder.ApplyConfiguration<AppUser>(new AppUserMap());
            //modelBuilder.ApplyConfiguration<UserRole>(new UserRoleMap());
            //modelBuilder.ApplyConfiguration<RolesPermissions>(new RolesPermissionsMap());
        }
    }
}
