using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiBoard
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public object DescData { get; set; }
        public bool Closed { get; set; }
        public string IdOrganization { get; set; }
        public string IdEnterprise { get; set; }
        public object Limits { get; set; }
        public object Pinned { get; set; }
        public string ShortLink { get; set; }
        public List<object> PowerUps { get; set; }
        public DateTime? DateLastActivity { get; set; }
        public List<object> IdTags { get; set; }
        public DateTime? DatePluginDisable { get; set; }
        public object CreationMethod { get; set; }
        public decimal? IxUpdate { get; set; }
        public bool EnterpriseOwned { get; set; }
        public string IdBoardSource { get; set; }
        public string Id { get; set; }
        public bool Starred { get; set; }
        public string Url { get; set; }
        public ApiPreferences Prefs { get; set; }
        public bool Subscribed { get; set; }
        public Dictionary<string, string> LabelNames { get; set; }
        public DateTime? DateLastView { get; set; }
        public string ShortUrl { get; set; }
        public object TemplateGallery { get; set; }
        public List<object> PremiumFeatures { get; set; }
        public List<ApiMembership> Memberships { get; set; }
    }
}