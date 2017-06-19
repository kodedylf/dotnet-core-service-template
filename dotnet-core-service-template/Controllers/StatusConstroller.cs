using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

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
