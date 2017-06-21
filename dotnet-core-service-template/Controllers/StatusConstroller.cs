using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_service_template.Controllers
{
    [Route("api/status")]
    public class StatusController : Controller
    {
        // GET api/status
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
