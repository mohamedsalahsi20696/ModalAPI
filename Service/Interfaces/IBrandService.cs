using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.Models;
using Modal.Domain.DTO;

namespace Modal.Service.Interfaces
{
    public interface IBrandService
    {
        Task<OkObjectResult> Get(Guid id);
        Task<OkObjectResult> GetAll();
        Task<OkObjectResult> Search(ProductSpecificationsParamtersDTO productSpecificationsParamtersDTO);
    }
}
