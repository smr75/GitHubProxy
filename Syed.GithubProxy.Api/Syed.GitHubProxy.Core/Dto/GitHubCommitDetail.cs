using System.Net;

namespace Syed.GitHubProxy.Core.Dto
{
    public class GitHubCommitDetail
    {
        public string sha { get; set; }
        public Commit commit { get; set; }
    }

    public class Commit
    {
        public Author author { get; set; }
        public string message { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public DateTime? date { get; set; }
    }
}
