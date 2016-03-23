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
        private ContextDB contextDB;

        public bool CheckIfExists(string categoria)
        {
            contextDB = new ContextDB();
            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);

                    IEnumerable<Categoria> cat = crawlerDB.Categorias.AsNoTracking().Where(p => p.Nome == categoria);
                    if (cat.Count() <= 0)
                        return false;

                    return true;
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

        public int GetId(string categoria)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    var cat = crawlerDB.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Nome == categoria);
                    return cat.Result.CategoriaId;
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

        public IEnumerable<Categoria> GetAllCategories()
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    IEnumerable<Categoria> categories = crawlerDB.Categorias.AsNoTracking().ToList();

                    return categories;
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

        public void SaveCategory(Categoria category)
        {

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    if (category != null)
                    {
                        crawlerDB.Categorias.Add(category);
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

        public IEnumerable<int> GetTotalByCategory(string categoria)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    return
                        crawlerDB.PostTwitters.Include(a => a.Categoria)
                        .AsNoTracking()
                            .Where(e => e.Categoria.Nome.ToString() == categoria.ToString())
                            .GroupBy(e => e.EstadoId)
                            .Select(e => e.Count())
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

        public int GetTotal(string categoria)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    return
                        crawlerDB.PostTwitters.Include(a => a.Categoria)
                            .AsNoTracking()
                            .Count(c => c.Categoria.Nome == categoria);
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
