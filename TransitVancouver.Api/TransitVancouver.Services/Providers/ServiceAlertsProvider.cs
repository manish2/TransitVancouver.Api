using Newtonsoft.Json;
using System.Threading.Tasks;
using TransitVancouver.Services.Interfaces;

namespace TransitVancouver.Services.Providers
{
    public class ServiceAlertsProvider : IServiceAlertsProvider
    {
        private readonly ITranslinkApiClient _apiClient; 
        public ServiceAlertsProvider(ITranslinkApiClient apiClient)
        {
            _apiClient = apiClient; 
        }
        public async Task<string> GetAllServiceAlerts()
        {
            var data = await _apiClient.GetServiceAlerts().ConfigureAwait(false);
            return JsonConvert.SerializeObject(data); 
        }
    }
}
