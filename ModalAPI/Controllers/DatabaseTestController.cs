using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modal.Repository.Data;

namespace Modal.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DatabaseTestController : ControllerBase
    {
        private readonly ModalContext _context;
        public DatabaseTestController(ModalContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult TestConnection()
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();
                return Ok("Connection successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection failed: {ex.Message}. Inner Exception: {ex.InnerException?.Message}. StackTrace: {ex.StackTrace}");
            }
        }
    }
}
