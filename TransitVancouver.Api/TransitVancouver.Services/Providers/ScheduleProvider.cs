using Newtonsoft.Json;
using System.Threading.Tasks;
using TransitVancouver.Services.Interfaces;

namespace TransitVancouver.Services.Providers
{
    public class ScheduleProvider : IScheduleProvider
    {
        private readonly ITranslinkApiClient _apiClient;
        public ScheduleProvider(ITranslinkApiClient apiClient)
        {
            _apiClient = apiClient; 
        }
        public async Task<string> GetVehicleSchedule()
        {
            var data = await _apiClient.GetTripUpdate().ConfigureAwait(false);
            return JsonConvert.SerializeObject(data);
        }
    }
}
