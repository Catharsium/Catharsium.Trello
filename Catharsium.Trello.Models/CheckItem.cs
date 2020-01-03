using System.Text.Json.Serialization;

namespace Catharsium.Trello.Models
{
    public class CheckItem
    {
        public string IdChecklist { get; set; }
        public string State { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public NameData NameData { get; set; }
        [JsonPropertyName("Pos")]
        public decimal Position { get; set; }
    }
}