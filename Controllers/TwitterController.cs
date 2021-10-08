using CodeCrunch.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrunch.Controllers
{
    [Route("twitter")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly ITwitterService _twitterService;
        public TwitterController(ITwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        [HttpGet("user/{username}")]
        public async Task<IActionResult> UserTweetsAsync(string username)
        {
            try
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
            catch (Exception)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "tweets not found"
                });
            }

        }

        [HttpGet("hashtag/{hashtag}")]
        public async Task<IActionResult> SearchHashtagAsync(string hashtag)
        {
            try
            {
                var tweets = await _twitterService.GetTweetsByHashtagAsync($"#{hashtag}");
                var response = tweets.Take(10).Select(t => new
                {
                    text = t.FullText,
                    user_screen_name = t.CreatedBy.ScreenName,
                    retweet_count = t.RetweetCount
                });
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "tweets not found"
                });
            }
        }
        [HttpGet("location")]
        public async Task<IActionResult> SearchByLocationAsync(float latitude, float longitude, string radius)
        {
            try
            {
                var tweets = await _twitterService.GetTweetsByLocationAsync(latitude, longitude, radius);

                var response = tweets.Take(10).Select(t => new
                {
                    text = t.FullText,
                    user_screen_name = t.CreatedBy.ScreenName,
                });
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "tweets not found"
                });
            }

        }
    }
}
