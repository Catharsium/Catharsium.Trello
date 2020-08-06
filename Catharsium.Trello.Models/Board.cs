using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Models
{
    public class Board
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string DescData { get; set; }
        public bool Closed { get; set; }

        public string IdOrganisation { get; set; }

        public List<object> Limits { get; set; }
        public object Pinned { get; set; }
        public bool Starred { get; set; }

        public string Url { get; set; }

        public Preferences Prefs { get; set; }
        public string IdOrganization { get; set; }
        public string IdEnterprise { get; set; }
        public string IdBoardSource { get; set; }
        public string ShortLink { get; set; }

        public bool Subscribed { get; set; }

        public DateTime? DateLastActivity { get; set; }
        public DateTime? DateLastView { get; set; }

        public Dictionary<string, string> LabelNames { get; set; }
        public string ShortUrl { get; set; }
        
        public List<object> PowerUps { get; set; }
        public List<object> IdTags { get; set; }
        public DateTime? DatePluginDisable { get; set; }
        public object CreationMethod { get; set; }
        public decimal? IxUpdate { get; set; }
        public object TemplateGallery { get; set; }
        public List<object> PremiumFeatures { get; set; }
        public bool EnterpriseOwned { get; set; }

        private List<Action> actions;
        public List<Action> Actions {
            get => this.actions ?? (this.actions = new List<Action>());
            set => this.actions = value;
        }

        private List<Card> cards;
        public List<Card> Cards {
            get => this.cards ?? (this.cards = new List<Card>());
            set => this.cards = value;
        }

        private List<List> lists;
        public List<List> Lists {
            get => this.lists ?? (this.lists = new List<List>());
            set => this.lists = value;
        }

        private List<Checklist> checklists;
        public List<Checklist> Checklists {
            get => this.checklists ?? (this.checklists = new List<Checklist>());
            set => this.checklists = value;
        }

        private List<Label> labels;
        public List<Label> Labels
        {
            get => this.labels ?? (this.labels = new List<Label>());
            set => this.labels = value;
        }

        private List<Membership> memberships;
        public List<Membership> Memberships {
            get => this.memberships ?? (this.memberships = new List<Membership>());
            set => this.memberships = value;
        }
        

        public override string ToString()
        {
            return $"'{this.Name}' ({this.Lists.Count} lists, {this.Cards.Count} cards)";
        }
    }
}