using Tweetinvi.Models;

namespace CodeCrunch.Services
{
    public interface ITwitterService
    {

        Task<ITweet[]> GetTweetsByUsernameAsync(string username);
        Task<ITweet[]> GetTweetsByUserAsync(IUser user);
        Task<IUser> GetUserInfoAsync(string username);


        Task<ITweet[]> GetTweetsByHashtagAsync(string hashtag);

    }
}
