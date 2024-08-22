using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modal.Domain.DTO;
using Modal.Domain.Models;
using Modal.Service.UnitOfWork;

namespace Modal.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ProductBrandController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetBrandByID(Guid id)
        {
            return await _serviceUnitOfWork.ProductBrandService.Value.Get(id);
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAllBrands()
        {
            return await _serviceUnitOfWork.ProductBrandService.Value.GetAll();
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> Search(ProductSpecificationsParamtersDTO productSpecificationsParamtersDTO)
        {
            return await _serviceUnitOfWork.ProductBrandService.Value.Search(productSpecificationsParamtersDTO);
        }
    }
}
