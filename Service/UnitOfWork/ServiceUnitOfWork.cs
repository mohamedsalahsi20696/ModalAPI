using AutoMapper;
using Modal.Common.UnitOfWork;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Repository.Data;
using Modal.Repository.Interfaces;
using Modal.Repository.UnitOfWork;
using Modal.Service.Interfaces;
using Modal.Service.Service;

namespace Modal.Service.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly ModalContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonUnitOfWork _commonUnitOfWork;
        private readonly IConfiguration _configuration;

        public Lazy<IProductService> ProductService { get; set; }
        public Lazy<IBrandService> ProductBrandService { get; set; }
        public Lazy<ICategoryService> ProductCategoryService { get; set; }
        //public Lazy<IAuthService> AuthService { get; set; }
        //public Lazy<IRoleManagementService> RoleManagementService { get; set; }
        //public Lazy<IRolesPermissionsService> RolesPermissionsService { get; set; }

        public ServiceUnitOfWork(
            //SignInManager<AppUser> signInManager,
            ModalContext context,
            IMapper mapper,
            ICommonUnitOfWork commonUnitOfWork,
             IConfiguration configuration

            )
        {

            _repositoryUnitOfWork = new RepositoryUnitOfWork(context);
            _mapper = mapper;
            _commonUnitOfWork = commonUnitOfWork;
            _configuration = configuration;

            ProductService = new Lazy<IProductService>(() => new ProductService(_repositoryUnitOfWork, mapper, _commonUnitOfWork));
            ProductBrandService = new Lazy<IBrandService>(() => new BrandService(_repositoryUnitOfWork, mapper, _commonUnitOfWork));
            ProductCategoryService = new Lazy<ICategoryService>(() => new CategoryService(_repositoryUnitOfWork, mapper, _commonUnitOfWork));
            //AuthService = new Lazy<IAuthService>(() => new AuthService(userManager, _repositoryUnitOfWork, mapper, _commonUnitOfWork, _configuration));
            //RoleManagementService = new Lazy<IRoleManagementService>(() => new RoleManagementService(_repositoryUnitOfWork, mapper, _commonUnitOfWork));
            //RolesPermissionsService = new Lazy<IRolesPermissionsService>(() => new RolesPermissionsService(_repositoryUnitOfWork, mapper, _commonUnitOfWork));

        }
    }
}
