using System.Collections.Generic;

namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiBoardPreferences
    {
        public string PermissionLevel { get; set; }
        public bool HideVotes { get; set; }
        public PermittedRole Voting { get; set; }
        public PermittedRole Comments { get; set; }
        public PermittedRole Invitations { get; set; }
        public bool SelfJoin { get; set; }
        public bool CardCovers { get; set; }
        public bool IsTemplate { get; set; }
        public string CardAging { get; set; }
        public bool CalendarFeedEnabled { get; set; }
        public string Background { get; set; }
        public string BackgroundImage { get; set; }
        public List<ApiImage> BackgroundImageScaled { get; set; }
        public bool BackgroundTile { get; set; }
        public string BackgroundBrightness { get; set; }
        public string BackgroundBottomColor { get; set; }
        public string BackgroundTopColor { get; set; }
        public bool CanBePublic { get; set; }
        public bool CanBeEnterprise { get; set; }
        public bool CanBeOrg { get; set; }
        public bool CanBePrivate { get; set; }
        public bool CanInvite { get; set; }
    }
}