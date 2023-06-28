using Moq;
using Syed.GitHubProxy.Core.Dto;
using Syed.GitHubProxy.Core.ExternalClients;
using Syed.GitHubProxy.Core.Queries;
using Syed.GitHubProxy.Core.QueryHandlers;

namespace Syed.GithubProxy.Core.Tests.QueryHandlers
{
    public class GetContributersQueryHandlerTests
    {
        [Fact]
        public void Handle_Should_Return_Empty_List_When_Api_Returns_Empty_List()
        {
            // Arrange
            var mockApi = new Mock<IGitHubApiService>();
            mockApi.Setup(m => m.GetCommitsAsync(It.IsAny<GetContributersQuery>(), It.IsAny<int>())).ReturnsAsync(new List<GitHubCommitDetail>());

            var sut = new GetContributersQueryHandler(mockApi.Object);
            var request = new GetContributersQuery();

            // Act
            var response = sut.Handle(request, CancellationToken.None).Result;

            // Assert
            Assert.Equal(0, response.Count);
        }
    }
}
