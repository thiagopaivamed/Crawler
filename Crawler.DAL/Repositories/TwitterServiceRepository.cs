using System;
using System.Collections.Generic;
using System.Linq;
using Crawler.DAL.Interfaces;
using TweetSharp;

namespace Crawler.DAL.Repositories
{
    public class TwitterServiceRepository : ITwitterServiceRepository
    {
        
        public TwitterService ConfigureService()
        {

            try
            {
                var service = new TwitterService("9FgYiA3dIXRuqCqLfQHlPorLp",
                    "Hvxy1M5xIDYFb5q5gG9FucricO7gtxG8oxQLlbQGtj1PaaEiAP");
                service.AuthenticateWith("4071103402-aia29ocbuFPlbNidECq3yYlVImJ02FbyLlkKGuE",
                    "i0lC5xbFQNGe8O06GZu8XyCNnp5lFQLnUXobOEgM9cGD7");

                return service;
            }

            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        public List<TwitterStatus> Search(TwitterService service, string categoria)
        {
            
            try
            {
                var tweets = service.Search(new SearchOptions {Q = categoria, Count = 200});
                List<TwitterStatus> tw = tweets.Statuses.Where(tweet => tweet.Id > 0).ToList();

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                tweets =
                    service.Search(new SearchOptions {Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id});
                tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

                return tw;
            }

            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
