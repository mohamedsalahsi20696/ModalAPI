using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modal.Domain.Models;
using Modal.Domain.ReturnJsonModel;

namespace Modal.APIs.Controllers
{
    [Route("api/[controller]/[action]/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {

        public ActionResult Error(int code)
        {
            return new OkObjectResult(new ErrorJsonModel(404, null) { });
        }
    }
}
