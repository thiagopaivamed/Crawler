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
        private IContextDB contextDB;

        public IEnumerable<PostTwitter> GetAll()
        {
            contextDB = new ContextDB();

            try
            {
                using (var crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    var tweets =
                        crawlerDB.PostTwitters.Include(p => p.Categoria)
                            .Include(p => p.Estado)
                            .AsNoTracking()
                            .OrderBy(e => e.Estado.Nome)
                            .ToList();

                    return tweets;
                }
            }

            catch (Exception exception)
            {
                throw exception;
            }

            finally
            {
                contextDB = null;
            }
            
        }

        public void SaveTweets(PostTwitter postTwitter)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);

                    if (postTwitter != null)
                    {
                        crawlerDB.PostTwitters.Add(postTwitter);
                        crawlerDB.SaveChangesAsync();
                    }
                }
            }

            catch (Exception exception)
            {
                throw exception;
            }

            finally
            {
                contextDB = null;
            }
        }

        public List<int> GetTotalByDate(string categoria, DateTime dataInicio, DateTime dataFim, string estado)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);

                    return
                        crawlerDB.PostTwitters.Include(c => c.Categoria)
                            .Include(e => e.Estado)
                            .AsNoTracking()
                            .AsEnumerable()
                            .Where(
                                p =>
                                    p.Categoria.Nome == categoria && p.Estado.Nome == estado && p.Data >= dataInicio &&
                                    p.Data <= dataFim)
                            .GroupBy(p => new {p.Data, p.Estado.Sigla, p.Categoria.Nome})
                            .OrderBy(p => p.Key.Data)
                            .Distinct()
                            .Select(p => p.Count())
                            .ToList();
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }

            finally
            {
                contextDB = null;
            }
        }

        public List<DateTime?> GetDatesByRange(string categoria, DateTime dataInicio, DateTime dataFim, string estado)
        {
            contextDB = new ContextDB();

            try
            {

                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    
                    return
                        crawlerDB.PostTwitters.Include(c => c.Categoria)
                            .Include(e => e.Estado)
                            .AsNoTracking()
                            .AsEnumerable()
                            .Where(
                                p =>
                                    p.Categoria.Nome == categoria && p.Estado.Nome == estado && p.Data >= dataInicio &&
                                    p.Data <= dataFim)
                            .GroupBy(p => new {p.Data, p.Estado.Sigla, p.Categoria.Nome})
                            .OrderBy(p => p.Key.Data)
                            .Select(p => p.Key.Data)
                            .Distinct()
                            .ToList();

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            finally
            {
                contextDB = null;
            }
        }

    }
}
