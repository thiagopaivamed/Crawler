using Crawler.BLL.Models;
using Crawler.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Crawler.DAL.Repositories
{
    public class PostTwitterRepository : IPostTwitterRepository
    {
        private CrawlerDB crawlerDB;

        public IEnumerable<PostTwitter> GetAll()
        {
            crawlerDB = new CrawlerDB();

            try
            {
                var tweets =
                    crawlerDB.PostTwitters.Include(p => p.Categoria).Include(p => p.Estado).OrderBy(e => e.Estado.Nome);
                return tweets;
            }

            catch (Exception exception)
            {
                throw exception;
            }

            finally
            {
                crawlerDB = null;
            }
            
        }

        public void SaveTweets(PostTwitter postTwitter)
        {
            crawlerDB = new CrawlerDB();
            if (postTwitter != null)
            {
                crawlerDB.PostTwitters.Add(postTwitter);
                crawlerDB.SaveChanges();
            }
        }
    }
}
