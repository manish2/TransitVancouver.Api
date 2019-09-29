using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransitVancouver.Services.Interfaces;

namespace TransitVancouver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IVehiclePositionProvider _vehiclePositionProvider;
        public PositionsController(IVehiclePositionProvider vehiclePositionProvider)
        {
            _vehiclePositionProvider = vehiclePositionProvider; 
        }
        [HttpGet]
        [Route("Get/{routeNo}")]
        public async Task<IActionResult> Get(string routeNo)
        {
            var data = await _vehiclePositionProvider.GetCurrentVehiclePosition(routeNo);
            return Ok(data);
        }
    }
}