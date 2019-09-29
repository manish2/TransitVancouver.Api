using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransitRealtime;

namespace TransitVancouver.Services.Interfaces
{
    public interface ITranslinkApiClient
    {
        Task<FeedMessage> GetTripUpdate();
        Task<FeedMessage> GetPositionUpdate();
        Task<FeedMessage> GetServiceAlerts(); 
    }
}
