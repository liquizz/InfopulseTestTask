using Microsoft.AspNetCore.Mvc;

namespace CustomersService.API.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}