using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiBoard
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Desc { get; set; }

        //public ? DescData { get; set; }
        public bool Closed { get; set; }
        public string IdOrganization { get; set; }
        public string IdEnterprise { get; set; }

        public string Limits { get; set; }

        //public ? Pinned { get; set; }
        public string ShortLink { get; set; }
        public List<string> PowerUps { get; set; }
        public DateTime? DateLastActivity { get; set; }
        public List<string> IdTags { get; set; }
        public DateTime? DatePluginDisable { get; set; }

        public DateTime? CreationMethod { get; set; }

        //public ? IxUpdate { get; set; }
        public bool EnterpriseOwned { get; set; }
        public string IdBoardSource { get; set; }
        public bool Starred { get; set; }
        public string Url { get; set; }
        public ApiBoardPreferences Prefs { get; set; }
        public bool Subscribed { get; set; }
        public Dictionary<string, string> LabelNames { get; set; }
        public DateTime? DateLastView { get; set; }

        public string ShortUrl { get; set; }

        //public ? TemplateGallery { get; set; }
        //public List<?> PremiumFeatures { get; set; }
        public List<ApiMembership> Memberships { get; set; }
    }
}