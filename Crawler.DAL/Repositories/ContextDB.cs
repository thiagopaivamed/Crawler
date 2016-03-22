using Crawler.DAL.Interfaces;

namespace Crawler.DAL.Repositories
{
    public class ContextDB : IContextDB
    {
        public void ConfigureContext(BLL.Models.CrawlerDB crawlerDB)
        {
            crawlerDB.Configuration.ProxyCreationEnabled = false;
            crawlerDB.Configuration.AutoDetectChangesEnabled = false;
            crawlerDB.Configuration.ValidateOnSaveEnabled = false;
            crawlerDB.Configuration.ProxyCreationEnabled = false;
        }
    }
}
