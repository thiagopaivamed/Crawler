﻿using Crawler.BLL.Models;
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

        public List<int> GetTotalByDate(string categoria, string dataInicio, string dataFim, string estado)
        {
            crawlerDB = new CrawlerDB();
            try
            {
                return
                    crawlerDB.PostTwitters.Include(c => c.Categoria).Include(e => e.Estado).AsEnumerable()
                        .Where( p => p.Categoria.Nome == categoria && p.Estado.Nome == estado && Convert.ToDateTime(p.Data) >= Convert.ToDateTime(dataInicio) && Convert.ToDateTime(p.Data) <= Convert.ToDateTime(dataFim))
                        .GroupBy(p => new { p.Data, p.Estado.Sigla, p.Categoria.Nome })
                        .OrderByDescending(p => p.Key.Data)
                        .Distinct()
                        .Select(p => p.Count())
                        .ToList();
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

        public List<string> GetDatesByRange(string categoria, string dataInicio, string dataFim, string estado)
        {
            crawlerDB = new CrawlerDB();
            try
            {
                return
                    crawlerDB.PostTwitters.Include(c => c.Categoria).Include(e => e.Estado).AsEnumerable()
                        .Where(p => p.Categoria.Nome == categoria && p.Estado.Nome == estado && Convert.ToDateTime(p.Data) >= Convert.ToDateTime(dataInicio) && Convert.ToDateTime(p.Data) <= Convert.ToDateTime(dataFim))
                        .GroupBy(p => new { p.Data, p.Estado.Sigla, p.Categoria.Nome })
                        .OrderByDescending(p => p.Key.Data)
                        .Select(p => p.Key.Data)
                        .Distinct()
                        .ToList();
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

    }
}
