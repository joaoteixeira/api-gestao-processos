using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoProcessos.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new { status = "up", api = "ApiGestaoProcessos" });
        }

        [HttpGet("down")]
        public IActionResult Get2()
        {
            return Ok(new { status = "down", api = "ApiGestaoProcessos" });
        }
    }
}
