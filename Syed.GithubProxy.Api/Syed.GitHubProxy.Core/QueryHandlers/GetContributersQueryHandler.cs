using MediatR;
using Syed.GitHubProxy.Core.Domain;
using Syed.GitHubProxy.Core.ExternalClients;
using Syed.GitHubProxy.Core.Queries;

namespace Syed.GitHubProxy.Core.QueryHandlers
{
    public class GetContributersQueryHandler : IRequestHandler<GetContributersQuery, IList<GitHubCommit>>
    {
        public const int DEFAULT_PAGE_SIZE = 30;

        private readonly IGitHubApiService _gitHubApiService;
        
        public GetContributersQueryHandler(IGitHubApiService gitHubApiService)
        {
            _gitHubApiService = gitHubApiService;
        }

        public async Task<IList<GitHubCommit>> Handle(GetContributersQuery request, CancellationToken cancellationToken)
        {
            var commits = await _gitHubApiService.GetCommitsAsync(request, DEFAULT_PAGE_SIZE);

            if(commits != null)
            {
                return commits.OrderBy(c => c.commit.author.date)
                    .Select(
                    c => new GitHubCommit { 
                        AuthorName = c.commit?.author?.name, 
                        CommitHash = c.sha, 
                        Message = c?.commit.message, 
                        CommitDate = c.commit?.author?.date }
                    )
                    .ToList();
            }

            return new List<GitHubCommit>();
        }
    }
}
