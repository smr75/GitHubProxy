using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Syed.GitHubProxy.Core.Domain;
using Syed.GitHubProxy.Core.Queries;

namespace Syed.GithubProxy.Api.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GitHubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{owner}/{repo}/contributors",Name ="GetContributors")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(IList<GitHubCommit>))]
        public async Task<IActionResult> GetContributors(string owner, string repo)
        {
            var response = await _mediator.Send(new GetContributersQuery { Owner = owner, RepoName = repo });

            return Ok(response);
        }
    }
}
