using Microsoft.AspNetCore.Mvc;

namespace WebPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        public ApplicationController()
        {
            
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}