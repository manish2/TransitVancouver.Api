using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransitVancouver.Services.Interfaces;

namespace TransitVancouver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAlertsController : ControllerBase
    {
        private readonly IServiceAlertsProvider _provider; 
        public ServiceAlertsController(IServiceAlertsProvider provider)
        {
            _provider = provider; 
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _provider.GetAllServiceAlerts();
                return Ok(data);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Api encountered an exception"); 
            }
        }
    }
}
