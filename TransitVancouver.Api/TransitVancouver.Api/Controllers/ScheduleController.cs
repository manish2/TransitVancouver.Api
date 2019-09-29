using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TransitVancouver.Services.Interfaces;

namespace TransitVancouver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleProvider _scheduleProvider; 
        public ScheduleController(IScheduleProvider scheduleProvider)
        {
            _scheduleProvider = scheduleProvider; 
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _scheduleProvider.GetVehicleSchedule(); 
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Api encountered an exception");
            }
        }
    }
}