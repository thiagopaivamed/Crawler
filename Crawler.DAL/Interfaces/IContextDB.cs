using Crawler.BLL.Models;

namespace Crawler.DAL.Interfaces
{
    interface IContextDB
    {
        void ConfigureContext(CrawlerDB crawlerDB);
    }
}
