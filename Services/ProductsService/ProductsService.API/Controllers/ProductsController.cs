using Microsoft.AspNetCore.Mvc;

namespace ProductsService.API.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
    
}