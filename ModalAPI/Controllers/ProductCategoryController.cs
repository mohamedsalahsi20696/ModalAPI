using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modal.APIs.Extentions;
using Modal.Domain.DTO;
using Modal.Domain.Models;
using Modal.Service.UnitOfWork;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ProductCategoryController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetCategoryByID(Guid id)
        {
            return await _serviceUnitOfWork.ProductCategoryService.Value.Get(id);
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAllCategories()
        {
            return await _serviceUnitOfWork.ProductCategoryService.Value.GetAll();
        }

        [HttpGet]
        //[CustomAuthorize("ProductCategory_GetCategoryByID")]
        public async Task<IActionResult> Search(ProductSpecificationsParamtersDTO productSpecificationsParamtersDTO)
        {
            return await _serviceUnitOfWork.ProductCategoryService.Value.Search(productSpecificationsParamtersDTO);
        }
    }
}
