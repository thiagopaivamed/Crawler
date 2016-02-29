using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Crawler.BLL.Models;
using Crawler.DAL.Interfaces;

namespace Crawler.DAL.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private CrawlerDB crawlerDB;

        public bool CheckIfExists(string categoria)
        {
            crawlerDB = new CrawlerDB();
            try
            {
                IEnumerable<Categoria> cat = crawlerDB.Categorias.Where(p => p.Nome == categoria);
                if (cat.Count() <= 0)
                    return false;

                return true;
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

        public int GetId(string categoria)
        {
            crawlerDB = new CrawlerDB();

            try
            {
                var cat = crawlerDB.Categorias.FirstOrDefault(c => c.Nome == categoria);
                return cat.CategoriaId;
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

        public IEnumerable<Categoria> GetAllCategories()
        {
            crawlerDB = new CrawlerDB();

            try
            {
                crawlerDB.Configuration.ProxyCreationEnabled = false;
                IEnumerable<Categoria> categories = crawlerDB.Categorias.ToList();

                return categories;
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

        public void SaveCategory(Categoria category)
        {
            crawlerDB = new CrawlerDB();
            try
            {
                if (category != null)
                {
                    crawlerDB.Categorias.Add(category);
                    crawlerDB.SaveChanges();
                }
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

        public IEnumerable<int> GetTotalByCategory(string categoria)
        {
            crawlerDB = new CrawlerDB();

            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria)
                        .Where(e => e.Categoria.Nome == categoria.ToString())
                        .GroupBy(e => e.EstadoId)
                        .Select(e => e.Count())
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

        public int GetTotal(string categoria)
        {
            crawlerDB = new CrawlerDB();

            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria).Count(c => c.Categoria.Nome == categoria);

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
