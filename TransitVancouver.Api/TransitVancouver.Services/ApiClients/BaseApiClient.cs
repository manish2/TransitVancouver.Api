using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TransitVancouver.Services.ApiClients
{
    public class BaseApiClient
    {
        private readonly HttpClient _httpClient; 
        public BaseApiClient(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }
        public async Task<string> GetAsync(string requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null; 
        }
        public async Task<Stream> GetAsStreamAsync(string requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsStreamAsync() : null; 
        }
    }
}
