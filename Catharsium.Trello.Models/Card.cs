using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Trello.Models
{
    public class Card
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int IdShort { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public string ShortLink { get; set; }

        public string IdBoard { get; set; }
        public string IdList { get; set; }

        public object CheckItemStates { get; set; }
        public bool Closed { get; set; }
        public DateTime DateLastActivity { get; set; }
        public string Desc { get; set; }
        public object DescData { get; set; }
        public int? DueReminder { get; set; }
        public List<object> IdMembersVoted { get; set; }
        public object IdAttachmentCover { get; set; }
        public List<string> IdLabels { get; set; }
        public bool ManualCoverAttachment { get; set; }
        public decimal Pos { get; set; }
        public bool IsTemplate { get; set; }
        public bool DueComplete { get; set; }
        public object Due { get; set; }
        public List<Label> Labels { get; set; }
        public bool Subscribed { get; set; }
        public Cover ApiCover { get; set; }
        public string LocationName { get; set; }
        public Badges Badges { get; set; }
        public string Email { get; set; }
        public List<string> IdChecklists { get; set; }
        public List<string> IdMembers { get; set; }



        public override string ToString()
        {
            var labels = this.Labels != null
                ? string.Join(", ", this.Labels.Select(l => l.Name))
                : "";
            return $"{this.Name} (Labels: {labels})";
        }
    }
}