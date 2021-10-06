using CodeCrunch.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrunch.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly ITwitterService _twitterService;
        public TwitterController(ITwitterService twitterService)
        {
            _twitterService = twitterService;
        }


        [HttpGet("[action]/{username}")]
        public async Task<IActionResult> UserAsync(string username)
        {
            var user = await _twitterService.GetUserInfoAsync(username);
            var tweets = await _twitterService.GetTweetsByUsernameAsync(username);
            var userTweets = new
            {
                user_name = user.Name,
                user_screen_name = user.ScreenName,
                followers_count = user.FollowersCount,
                friends_count = user.FriendsCount,
                tweets = tweets.Take(10).Select(t => new
                {
                    created_at = t.CreatedAt.ToString("ddd MMM dd HH:mm:ss +ffff yyyy"),
                    text = t.FullText,

                }).ToArray()
            };
            return Ok(userTweets);
        }

        [HttpGet("[action]/{hashtag}")]
        public async Task<IActionResult> HashtagAsync(string hashtag)
        {
            var tweets = await _twitterService.GetTweetsByHashtagAsync(hashtag);
            var newTweets = tweets.Take(10).Select(t => new
            {
                text = t.FullText,
                user_screen_name = t.CreatedBy.ScreenName,
                retweet_count = t.RetweetCount
            });
            return Ok(newTweets);
        }
    }
}
