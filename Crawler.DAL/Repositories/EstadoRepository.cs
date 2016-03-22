using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Crawler.BLL.Models;
using Crawler.DAL.Interfaces;

namespace Crawler.DAL.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private ContextDB contextDB;

        public IEnumerable<Estado> GetAllStates()
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    IEnumerable<Estado> states = crawlerDB.Estados.AsNoTracking().OrderBy(x => x.Nome).ToList();
                    return states;
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

        public string GetStatebyId(int id)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    Task<Estado> state = crawlerDB.Estados.AsNoTracking().FirstOrDefaultAsync(e => e.EstadoId == id);

                    return state.Result.Nome;
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

        public IEnumerable<string> GetStatesAcronymsByCategory(string categoria)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    contextDB.ConfigureContext(crawlerDB);
                    return
                        crawlerDB.PostTwitters.Include(a => a.Categoria)
                            .Where(c => c.Categoria.Nome == categoria)
                            .Select(p => p.Estado.Sigla)
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

        public IEnumerable<int> GetStatesCodesByCategory(string categoria)
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
                        .Where(c => c.Categoria.Nome == categoria)
                        .Select(p => p.Estado.EstadoId)
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

        public IEnumerable<int> GetTotalByCode(int codigo)
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
                            .Where(e => e.EstadoId == codigo)
                            .GroupBy(c => c.Categoria.Nome)
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

        public IEnumerable<string> GetCategoryByCode(int codigo)
        {
            contextDB = new ContextDB();

            try
            {
                using (CrawlerDB crawlerDB = new CrawlerDB())
                {
                    return
                        crawlerDB.PostTwitters.Include(a => a.Categoria)
                            .AsNoTracking()
                            .Where(e => e.EstadoId == codigo)
                            .Select(p => p.Categoria.Nome)
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
