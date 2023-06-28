using Syed.GitHubProxy.Core.Domain;
using Syed.GitHubProxy.Core.ExternalClients;
using Syed.GitHubProxy.Core.Queries;

namespace Syed.GithubProxy.Api
{
    internal static class ServiceCollectionExtensions
    {
        internal static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetContributersQuery).Assembly));

            var gitHubApiBaseUri = configuration["GitHubApiBaseUrl"];

            services.AddHttpClient<IGitHubApiService, GitHubApiService>(
                client => {
                    client.BaseAddress = new Uri(gitHubApiBaseUri);
                    client.DefaultRequestHeaders.Add("User-Agent", "Test-App");
                    }
                );
        }
    }
}
