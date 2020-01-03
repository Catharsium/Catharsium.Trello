namespace Catharsium.Trello.Models
{
    public class Badges
    {
        //"attachmentsByType": {
        //    "trello": {
        //        "board": 0,
        //        "card": 0
        //    }
        //},
        public bool Location { get; set; }
        public int Votes { get; set; }
        public bool ViewingMemberVoted { get; set; }
        public bool Subscribed { get; set; }
        public string Fogbugz { get; set; }
        public int CheckItems { get; set; }
        public int CheckItemsChecked { get; set; }
        public int Comments { get; set; }
        public int Attachments { get; set; }
        public bool Description { get; set; }
        //"due": null,
        public bool DueComplete { get; set; }
    }
}