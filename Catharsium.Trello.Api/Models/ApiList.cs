namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Closed { get; set; }
        public decimal Pos { get; set; }
        //public ? SoftLimit { get; set; }
        public string IdBoard { get; set; }
        public bool Subscribed { get; set; }
        //public string Limits { get; set; }
    }
}