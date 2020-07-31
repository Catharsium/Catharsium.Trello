namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiBadges
    {
        public ApiAttachmentsByType ApiAttachmentsByType { get; set; }
        public bool Location { get; set; }
        public int Votes { get; set; }
        public bool ViewingMemberVoted { get; set; }
        public bool Subscribed { get; set; }
        public string Fogbugz { get; set; }
        public int CheckItems { get; set; }
        public int CheckItemsChecked { get; set; }
        public object CheckItemsEarliestDue { get; set; }
        public int Comments { get; set; }
        public int Attachments { get; set; }
        public bool Description { get; set; }
        public object Due { get; set; }
        public bool DueComplete { get; set; }
    }
}