using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Repository.Interfaces;
using Modal.Service.Interfaces;

namespace Modal.Service.UnitOfWork
{
    public interface IServiceUnitOfWork
    {
        Lazy<IProductService> ProductService { get; set; }
        Lazy<IBrandService> ProductBrandService { get; set; }
        Lazy<ICategoryService> ProductCategoryService { get; set; }
        //Lazy<IAuthService> AuthService { get; set; }
        //Lazy<IRoleManagementService> RoleManagementService { get; set; }
        //Lazy<IRolesPermissionsService> RolesPermissionsService { get; set; }
    }
}
