namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiMember
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public bool ActivityBlocked { get; set; }
        public string AvatarHash { get; set; }
        public string AvatarUrl { get; set; }
        public string FullName { get; set; }
        public object IdMemberReferrer { get; set; }
        public string Initials { get; set; }
        public object NonPublic { get; set; }
        public bool NonPublicAvailable { get; set; }
    }
}