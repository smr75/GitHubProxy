using MediatR;
using Syed.GitHubProxy.Core.Domain;

namespace Syed.GitHubProxy.Core.Queries
{
    public class GetContributersQuery : IRequest<IList<GitHubCommit>>
    {
        public string? Owner { get; set; }
        public string? RepoName { get; set; }
    }
}