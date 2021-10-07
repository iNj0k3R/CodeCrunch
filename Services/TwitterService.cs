using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace CodeCrunch.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly TwitterClient _userClient;
        public TwitterService(IConfiguration configuration)
        {
            _userClient = new TwitterClient(configuration["Twitter:APIKey"], configuration["Twitter:APIKeySecret"],
                configuration["Twitter:AccessToken"], configuration["Twitter:AccessTokenSecret"]);
        }

        public Task<ITweet[]> GetTweetsByUserAsync(IUser user)
        {
            return user.GetUserTimelineAsync();
        }

        public Task<ITweet[]> GetTweetsByUsernameAsync(string username)
        {
            return _userClient.Timelines.GetUserTimelineAsync(new GetUserTimelineParameters(username)
            {
                IncludeRetweets = false,
                ExcludeReplies = true,
                PageSize = 50

            });
        }

        public Task<IUser> GetUserInfoAsync(string username)
        {
            return _userClient.Users.GetUserAsync(username);

        }
        public Task<ITweet[]> GetTweetsByHashtagAsync(string hashtag)
        {
            return _userClient.Search.SearchTweetsAsync(new SearchTweetsParameters($"#{hashtag}") { PageSize = 50 });
        }

        public Task<ITweet[]> GetTweetsByLocationAsync(string hashtag)
        {
            throw new NotImplementedException();
        }
    }
}
