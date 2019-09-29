using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransitRealtime;
using TransitVancouver.Services.Interfaces;

namespace TransitVancouver.Services.ApiClients
{
    public class TranslinkApiClient : BaseApiClient, ITranslinkApiClient
    {
        private readonly string _apiKey; 
        public TranslinkApiClient(string baseAddress, string apiKey) 
            : base(baseAddress)
        {
            _apiKey = apiKey; 
        }

        public async Task<FeedMessage> GetTripUpdate() => await ReadApiFeed("gtfsrealtime").ConfigureAwait(false);
        public async Task<FeedMessage> GetPositionUpdate() => await ReadApiFeed("gtfsposition").ConfigureAwait(false);
        public async Task<FeedMessage> GetServiceAlerts() => await ReadApiFeed("gtfsalerts").ConfigureAwait(false);

        private async Task<FeedMessage> ReadApiFeed(string endpoint)
        {
            var response = await GetAsStreamAsync($"{endpoint}?apikey={_apiKey}"); 
            if(response == null)
            {
                throw new Exception($"Response from url {endpoint} was empty"); 
            }
            return Serializer.Deserialize<FeedMessage>(response);
        }
    }
}
