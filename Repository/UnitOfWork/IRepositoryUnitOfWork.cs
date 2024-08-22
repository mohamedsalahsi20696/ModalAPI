using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Repository.Interfaces;

namespace Modal.Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork:IAsyncDisposable
    {
        Lazy<IProductRepository> Product { get; set; }
        Lazy<ICategoryRepository> productCategory{ get; set; }
        Lazy<IBrandRepository> ProductBrand { get; set; }
        //Lazy<IRoleManagementRepository> RoleManagement { get; set; }
        //Lazy<IUserRoleRepository> UserRole { get; set; }
        //Lazy<IRolesPermissionsRepository> RolesPermissions { get; set; }

        Task<int> CompleteAsync();
    }
}
