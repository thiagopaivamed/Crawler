using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Crawler.BLL.Models;
using Crawler.DAL.Interfaces;

namespace Crawler.DAL.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {

        private CrawlerDB crawlerDB;

        public IEnumerable<Estado> GetAllStates()
        {
            crawlerDB = new CrawlerDB();

            try
            {
                IEnumerable<Estado> states = crawlerDB.Estados.OrderBy(x => x.Nome);
                return states;
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

        public string GetStatebyId(int id)
        {
            crawlerDB = new CrawlerDB();

            try
            {
                Estado state = crawlerDB.Estados.FirstOrDefault(e => e.EstadoId == id);

                return state.Nome;
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

        public IEnumerable<string> GetStatesAcronyms()
        {
            crawlerDB = new CrawlerDB();

            try
            {
                return crawlerDB.PostTwitters.Include(a => a.Categoria).Select(p => p.Estado.Sigla).Distinct().ToList();
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

        public IEnumerable<string> GetStatesNames()
        {
            crawlerDB = new CrawlerDB();
            try
            {
                return crawlerDB.PostTwitters.Include(a => a.Categoria).Select(p => p.Estado.Nome).Distinct().ToList();
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

        public IEnumerable<int> GetStatesIds()
        {
            crawlerDB = new CrawlerDB();
            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria).Select(p => p.Estado.EstadoId).Distinct().ToList();
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

        public IEnumerable<int> GetTotal()
        {
            crawlerDB = new CrawlerDB();
            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria)
                        .GroupBy(d => d.EstadoId)
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

        public IEnumerable<string> GetStatesAcronymsByCategory(string categoria)
        {
            crawlerDB = new CrawlerDB();

            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria)
                        .Where(c => c.Categoria.Nome == categoria)
                        .Select(p => p.Estado.Sigla)
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

        public IEnumerable<int> GetStatesCodesByCategory(string categoria)
        {
            crawlerDB = new CrawlerDB();

            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria)
                        .Where(c => c.Categoria.Nome == categoria)
                        .Select(p => p.Estado.EstadoId)
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

        public IEnumerable<int> GetTotalByCode(int codigo)
        {
            crawlerDB = new CrawlerDB();
            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria)
                        .Where(e => e.EstadoId == codigo)
                        .GroupBy(c => c.Categoria.Nome)
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

        public IEnumerable<string> GetCategoryByCode(int codigo)
        {
            crawlerDB = new CrawlerDB();
            try
            {
                return
                    crawlerDB.PostTwitters.Include(a => a.Categoria)
                        .Where(e => e.EstadoId == codigo)
                        .Select(p => p.Categoria.Nome)
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
