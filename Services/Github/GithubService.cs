using Octokit;
namespace CodeCrunch.Services.Github
{
    public class GithubService : IGithubService
    {
        private readonly IGitHubClient _githubClient;
        public GithubService(IGitHubClient gitHubClient, IConfiguration configuration)
        {
            _githubClient = new GitHubClient(new ProductHeaderValue("")); 
            
        }

    }
}
