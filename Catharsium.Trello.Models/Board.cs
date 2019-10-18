using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Models
{
    public class Board
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public string Desc { get; set; }
        //public string DescData { get; set; }
        public bool Closed { get; set; }
        public string IdOrganisation { get; set; }
        //public List<object> Limits { get; set; }
        public bool Pinned { get; set; }
        public bool Starred { get; set; }
        public string Url { get; set; }
        //public List<object> Prefs {get;set;}
        public string ShortLink { get; set; }
        public bool Subscribed { get; set; }
        //public object Powerups { get; set; }
        public DateTime DateLastActivity { get; set; }
        public DateTime DateLastView { get; set; }
        public string ShortUrl { get; set; }
        //public object IdTags { get; set; }
        public DateTime DatePluginDisabled { get; set; }
        //public object CreationMethod { get; set; }
        public int IxUpdate { get; set; }
        public object TemplateGallery { get; set; }
        public bool EnterpriseOwned { get; set; }
        public List<Action> Actions { get; set; }
        public List<Card> Cards { get; set; }
        public List<Label> Labels { get; set; }
        public List<List> Lists { get; set; }
        //public List<object> Members { get; set; }
        public List<Checklist> Checklists { get; set; }
        //public object CustomFields { get; set; }
        //public List<object> Memberships { get; set; }
        //public object PluginData { get; set; }
    }
}