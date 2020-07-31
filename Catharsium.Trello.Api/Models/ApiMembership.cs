namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiMembership
    {
        public string Id { get; set; }
        public string IdMember { get; set; }
        public MemberType MemberType { get; set; }
        public bool Unconfirmed { get; set; }
        public bool Deactivated { get; set; }
    }
}