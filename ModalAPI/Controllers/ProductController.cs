using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modal.Domain.DTO;
using Modal.Domain.Models;
using Modal.Repository.Data;
using Modal.Repository.Interfaces;
using Modal.Service.UnitOfWork;

namespace Modal.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ProductController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetProductByID(Guid id)
        {
            return await _serviceUnitOfWork.ProductService.Value.Get(id);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            return await _serviceUnitOfWork.ProductService.Value.GetAll();
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Search(ProductSpecificationsParamtersDTO productSpecificationsParamtersDTO)
        {
            return await _serviceUnitOfWork.ProductService.Value.Search(productSpecificationsParamtersDTO);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Insert(ProductInsertDTO productDTO)
        {
            return await _serviceUnitOfWork.ProductService.Value.Insert(productDTO);
        }


    }
}
