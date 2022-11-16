using LoacationTrackerBot.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationTrackerBot.API.Controller
{
    [Route("api/viberbot")]
    [ApiController]
    public class ViberController : ControllerBase
    {
        private readonly ILogger<ViberController> _logger;
        private readonly IMessageService _messageService;
        public ViberController(ILogger<ViberController> logger, IMessageService messageService) 
        {
            _logger = logger;
            _messageService = messageService;
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> WebhookEvents([FromBody]JsonElement json)
        {
            try
            {
                var temp = Environment.GetEnvironmentVariable("ConnectionString");
                _logger.LogInformation($"Viber request: {json}");
                await _messageService.DistributionService(json);
                return new OkObjectResult(Path.Combine(Directory.GetCurrentDirectory()));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex);
            }

        }

    }
}
