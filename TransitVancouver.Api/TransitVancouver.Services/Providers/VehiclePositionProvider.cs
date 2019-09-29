using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitVancouver.Services.Interfaces;

namespace TransitVancouver.Services.Providers
{
    public class VehiclePositionProvider : IVehiclePositionProvider
    {
        private readonly ITranslinkApiClient _apiClient;
        private readonly IFeedEntityToDomainObjectMapper _mapper;
        public VehiclePositionProvider(ITranslinkApiClient apiClient, IFeedEntityToDomainObjectMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper; 
        }
        public async Task<string> GetCurrentVehiclePosition(string routeName)
        {
            var data = await _apiClient.GetPositionUpdate();
            var searchResult = data.Entities.Where(e => e.Vehicle.Trip.RouteId == routeName).Select(_mapper.MapEntityToVehiclePosition);
            return JsonConvert.SerializeObject(searchResult);
        }
    }
}
