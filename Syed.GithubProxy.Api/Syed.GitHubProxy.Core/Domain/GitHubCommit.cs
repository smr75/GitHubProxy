namespace Syed.GitHubProxy.Core.Domain
{
    public class GitHubCommit
    {
        public string CommitHash { get; set; }

        public string AuthorName { get; set; }

        public string Message { get; set; }

        public DateTime? CommitDate { get; set; }
    }
}
