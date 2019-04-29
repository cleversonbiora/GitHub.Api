using GitHub.Domain.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.CrossCutting.Apis
{
    public interface IGitHubApi
    {
        [Get("/search/repositories")]
        Task<SearchResult> GetRepositories(string q, string sort, string order, int per_page);
        [Get("/repos/{owner}/{repository}/readme")]
        Task<ReadMe> GetReadMe(string owner, string repository);
    }
} 
