namespace Catharsium.Trello.Models
{
    public class MemberCreator
    {
        public string Id { get; set; }
        public bool ActivityBlocked { get; set; }
        public string AvatarHash { get; set; }
        public string AvatarUrl { get; set; }
        public string FullName { get; set; }
        public string IdMemberReferrer { get; set; }
        public string Initials { get; set; }
        //"nonPublic": {},
        public bool NonPublicAvailable { get; set; }
        public string Username { get; set; }
    }
}