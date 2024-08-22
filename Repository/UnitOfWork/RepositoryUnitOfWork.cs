using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Repository.Data;
using Modal.Repository.Interfaces;
using Modal.Repository.Repositories;

namespace Modal.Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private readonly ModalContext _context;

        public Lazy<IProductRepository> Product { get; set; }
        public Lazy<ICategoryRepository> productCategory { get; set; }
        public Lazy<IBrandRepository> ProductBrand { get; set; }
        //public Lazy<IRoleManagementRepository> RoleManagement { get; set; }
        //public Lazy<IUserRoleRepository> UserRole { get; set; }
        //public Lazy<IRolesPermissionsRepository> RolesPermissions { get; set; }


        public RepositoryUnitOfWork(ModalContext context)
        {
            _context = context;

            Product = new Lazy<IProductRepository>(() => new ProductRepository(_context));
            productCategory = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            ProductBrand = new Lazy<IBrandRepository>(() => new BrandRepository(_context));
            //RoleManagement = new Lazy<IRoleManagementRepository>(() => new RoleManagementRepository(_context));
            //UserRole = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(_context));
            //RolesPermissions = new Lazy<IRolesPermissionsRepository>(() => new RolesPermissionsRepository(_context));
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
