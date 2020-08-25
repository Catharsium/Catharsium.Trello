using Catharsium.Trello.Api.Client._Configuration;
using Catharsium.Trello.Api.Client.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Clients
{
    public class TrelloRestClient : ITrelloRestClient
    {
        private readonly HttpClient httpClient;
        private readonly TrelloApiClientConfiguration configuration;
        private readonly string apiToken;


        public TrelloRestClient(HttpClient httpClient, TrelloApiClientConfiguration configuration, string apiToken)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.apiToken = apiToken;
        }


        public async Task<T> Get<T>(string path)
        {
            var url = $"{this.configuration.BaseUrl}/{path}?key={this.configuration.ApiKey}&token={this.apiToken}";
            var result = await this.httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });
        }


        public async Task<T> Post<T>(string path, Dictionary<string, object> data)
        {
            var parameters = string.Join("&", data.Select(d => $"{d.Key}={d.Value}"));
            var url = $"{this.configuration.BaseUrl}/{path}?key={this.configuration.ApiKey}&token={this.apiToken}&{parameters}";
            var result = await this.httpClient.PostAsync(url, null);
            var x = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(x, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true, IgnoreReadOnlyProperties = true
            });
        }


        public async Task<T> Put<T>(string path, Dictionary<string, object> data)
        {
            var parameters = string.Join("&", data.Select(d => $"{d.Key}={d.Value}"));
            var url = $"{this.configuration.BaseUrl}/{path}?key={this.configuration.ApiKey}&token={this.apiToken}&{parameters}";
            var result = await this.httpClient.PutAsync(url, null);
            var x = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(x, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            });
        }
    }
}