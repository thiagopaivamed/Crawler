using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.BLL.Models;

namespace Crawler.DAL.Interfaces
{
    interface IPostTwitterRepository
    {
        IEnumerable<PostTwitter> GetAll();

        void SaveTweets(PostTwitter postTwitter);
    }
}
