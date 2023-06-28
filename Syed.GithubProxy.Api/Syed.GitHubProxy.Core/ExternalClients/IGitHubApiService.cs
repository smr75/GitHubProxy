using Syed.GitHubProxy.Core.Dto;
using Syed.GitHubProxy.Core.Queries;

namespace Syed.GitHubProxy.Core.ExternalClients
{
    public interface IGitHubApiService
    {
        Task<IEnumerable<GitHubCommitDetail>> GetCommitsAsync(GetContributersQuery query, int pageSize);
    }
}
