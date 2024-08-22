using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.DTO;
using Modal.Domain.Models;

namespace Modal.Service.Interfaces
{
    public interface IProductService
    {
        Task<OkObjectResult> Get(Guid id);
        Task<OkObjectResult> GetAll();
        Task<OkObjectResult> Search(ProductSpecificationsParamtersDTO productSpecificationsParamtersDTO);
        Task<OkObjectResult> Insert(ProductInsertDTO productDTO);
    }
}
