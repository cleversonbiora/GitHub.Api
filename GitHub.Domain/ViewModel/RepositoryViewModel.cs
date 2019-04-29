using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Domain.ViewModel
{
    public class RepositoryViewModel
    {
        public int Id { get; set; }
        public string NodeId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Private { get; set; }
        public int OwnerId { get; set; }
        public OwnerViewModel Owner { get; set; }
        public string HtmlUrl { get; set; }
        public string Description { get; set; }
        public bool Fork { get; set; }
        public string Url { get; set; }
        public string CollaboratorsUrl { get; set; }
        public string BranchesUrl { get; set; }
        public string TagsUrl { get; set; }
        public string LanguagesUrl { get; set; }
        public string DownloadsUrl { get; set; }
        public string ReadMe { get; set; }
    }
}
