using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Domain.ViewModel
{
    public class RepositoryResumeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Private { get; set; }
        public string Login { get; set; }
        public string HtmlUrl { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        //Owner
        public int OwnerId { get; set; }
        public string AvatarUrl { get; set; }
        public string OwnerHtmlUrl { get; set; }
        public string ReposUrl { get; set; }
    }
}
