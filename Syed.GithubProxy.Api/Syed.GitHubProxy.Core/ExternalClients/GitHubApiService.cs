using Syed.GitHubProxy.Core.Queries;
using System.Text.Json;
using Syed.GitHubProxy.Core.Dto;

namespace Syed.GitHubProxy.Core.ExternalClients
{
    public class GitHubApiService : IGitHubApiService
    {
        private readonly HttpClient _httpClient;

        public GitHubApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GitHubCommitDetail>> GetCommitsAsync(GetContributersQuery query, int pageSize)
        {
            var response = await _httpClient.GetAsync($"{query.Owner}/{query.RepoName}/commits?per_page={pageSize}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<GitHubCommitDetail>();

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var commits = JsonSerializer.Deserialize<IEnumerable<GitHubCommitDetail>>(responseString);

            return commits;
        }
    }
}
