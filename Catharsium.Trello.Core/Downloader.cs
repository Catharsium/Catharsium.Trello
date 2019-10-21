using Catharsium.Trello.Models;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catharsium.Trello.Core
{
    public class Downloader
    {
        public async Task<Board> Json()
        {
            using (var httpClient = new HttpClient()) {
                var response = await httpClient.GetStreamAsync("https://trello.com/b/YEhI6IaM.json");
                using (var reader = new StreamReader(response)) {
                    return JsonSerializer.Deserialize<Board>(reader.ReadToEnd());
                }
            }
        }
    }
}