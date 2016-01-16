using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Crawler.Models;
using TweetSharp;

namespace Crawler.DAL
{
    public class PostTwitterRepository : IPostTwitterRepository
    {
        private CrawlerDB db = new CrawlerDB();

        public TwitterService ConfigureService()
        {
            var service = new TwitterService("9FgYiA3dIXRuqCqLfQHlPorLp", "Hvxy1M5xIDYFb5q5gG9FucricO7gtxG8oxQLlbQGtj1PaaEiAP");
            service.AuthenticateWith("4071103402-aia29ocbuFPlbNidECq3yYlVImJ02FbyLlkKGuE", "i0lC5xbFQNGe8O06GZu8XyCNnp5lFQLnUXobOEgM9cGD7");

            return service;
        }

        public List<TwitterStatus> Search(TwitterService service, string categoria)
        {
            var tweets = service.Search(new SearchOptions { Q = categoria, Count = 200 });
            List<TwitterStatus> tw = tweets.Statuses.Where(tweet => tweet.Id > 0).ToList();

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            tweets = service.Search(new SearchOptions { Q = categoria, Count = 200, MaxId = tweets.Statuses.Last().Id });
            tw.AddRange(tweets.Statuses.Where(tweet => tweet.Id > 0));

            return tw;
        }

        public IEnumerable<PostTwitter> GetAll()
        {
            var tweets = db.PostTwitters.Include(p => p.Categoria).Include(p => p.Estado).OrderBy(e => e.Estado.Nome);
            return tweets;
        }

        public bool CheckIfExists(string categoria)
        {
            IEnumerable<Categoria> cat = db.Categorias.Where(p => p.Nome == categoria);
            if (cat.Count() <= 0)
                return false;

            return true;
        }

        public int GetId(string categoria)
        {
            var cat = db.Categorias.FirstOrDefault(c => c.Nome == categoria);
            return cat.CategoriaId;
        }

        public IEnumerable<Categoria> GetAllCategories()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<Categoria> categories = db.Categorias.ToList();

            return categories;
        }


        public void SaveCategory(Categoria category)
        {
            if (category != null)
            {
                db.Categorias.Add(category);
                db.SaveChanges();
            }
        }

        public void SaveTweets(PostTwitter postTwitter)
        {
            if (postTwitter != null)
            {
                db.PostTwitters.Add(postTwitter);
                db.SaveChanges();
            }
        }

        public IEnumerable<Estado> GetAllStates()
        {
            IEnumerable<Estado> states = db.Estados.OrderBy(x => x.Nome);

            return states;
        }

        public string GetStatebyId(int id)
        {
            Estado state = db.Estados.FirstOrDefault(e => e.EstadoId == id);

            return state.Nome;
        }

        public IEnumerable<string> GetStatesAcronyms()
        {
            return db.PostTwitters.Include(a => a.Categoria).Select(p => p.Estado.Sigla).Distinct().ToList();
        }

        public IEnumerable<string> GetStatesNames()
        {
            return db.PostTwitters.Include(a => a.Categoria).Select(p => p.Estado.Nome).Distinct().ToList();
        }

        public IEnumerable<int> GetStatesIds()
        {
           
            return db.PostTwitters.Include(a => a.Categoria).Select(p => p.Estado.EstadoId).Distinct().ToList();
        }

        public IEnumerable<int> GetTotal()
        {
            return db.PostTwitters.Include(a => a.Categoria).GroupBy(d => d.EstadoId).Select(p => p.Count()).ToList();
        }

        public IEnumerable<int> GetTotalByCategory(string categoria)
        {
            return db.PostTwitters.Include(a => a.Categoria).Where(c => c.Categoria.Nome == categoria).GroupBy(d => d.EstadoId).Select(p => p.Count()).ToList();
        }

        public IEnumerable<string> GetStatesAcronymsByCategory(string categoria)
        {
            return db.PostTwitters.Include(a => a.Categoria).Where(c => c.Categoria.Nome == categoria).Select(p => p.Estado.Sigla).Distinct().ToList();
        }
    }
}