using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Domain.ViewModel
{
    public class OwnerViewModel
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string NodeId { get; set; }
        public string AvatarUrl { get; set; }
        public string Url { get; set; }
        public string HtmlUrl { get; set; }
        public string FollowersUrl { get; set; }
        public string FollowingUrl { get; set; }
        public string ReposUrl { get; set; }
    }
}
