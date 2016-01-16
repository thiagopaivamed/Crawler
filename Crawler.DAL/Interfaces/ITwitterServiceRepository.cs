using System.Collections.Generic;
using TweetSharp;

namespace Crawler.DAL.Interfaces
{
    interface ITwitterServiceRepository
    {
        TwitterService ConfigureService();

        List<TwitterStatus> Search(TwitterService service, string categoria);
    }
}
