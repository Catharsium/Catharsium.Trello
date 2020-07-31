using System.Text.Json.Serialization;

namespace Catharsium.Trello.Api.Client.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MemberType
    {
        Normal,
        Admin
    }
}