using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Domain.Models
{
    public class Repository
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }
        
        public int OwnerId { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fork")]
        public bool Fork { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("collaborators_url")]
        public string CollaboratorsUrl { get; set; }

        [JsonProperty("branches_url")]
        public string BranchesUrl { get; set; }

        [JsonProperty("tags_url")]
        public string TagsUrl { get; set; }

        [JsonProperty("languages_url")]
        public string LanguagesUrl { get; set; }

        [JsonProperty("downloads_url")]
        public string DownloadsUrl { get; set; }

        public string ReadMe  { get; set; }
    }
}
