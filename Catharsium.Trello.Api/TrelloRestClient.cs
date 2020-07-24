using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client
{
    public class TrelloRestClient : ITrelloRestClient
    {
        public async Task Get(string token)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("https://api.trello.com/1/members/me/boards?key=b3495a336263680911126a92272fc259&token=" + token);
            var x = JsonSerializer.Deserialize<Board[]>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }

    public class Board
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}