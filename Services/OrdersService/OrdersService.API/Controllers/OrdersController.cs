using Microsoft.AspNetCore.Mvc;

namespace OrdersService.API.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}