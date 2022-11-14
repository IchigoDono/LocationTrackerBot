using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LocationTrackerBot.API.Controller
{
    [Route("api/viberbot")]
    [ApiController]
    public class ViberController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SaveEvents()
        {
            HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);

            using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
            {
                string body = stream.ReadToEnd();
            }

            return new OkResult();
        }

        [HttpGet("testapi")]
        public async Task<IActionResult> TestApi() 
        {
            return new OkObjectResult("Test Controller");
        }
    }
}
