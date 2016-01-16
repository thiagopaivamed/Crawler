using System.Linq;
using Crawler.Models;
using System.Collections.Generic;
using TweetSharp;

namespace Crawler.DAL
{
    interface IPostTwitterRepository
    {

        TwitterService ConfigureService();

        List<TwitterStatus> Search(TwitterService service, string categoria);

        IEnumerable<PostTwitter> GetAll();

        bool CheckIfExists(string categoria);

        int GetId(string categoria);

        IEnumerable<Categoria> GetAllCategories();

        void SaveCategory(Categoria category);

        void SaveTweets(PostTwitter postTwitter);

        IEnumerable<Estado> GetAllStates();

        string GetStatebyId(int id);

        IEnumerable<string> GetStatesAcronyms();

        IEnumerable<int> GetStatesIds();

        IEnumerable<string> GetStatesNames();
        
        IEnumerable<int> GetTotal();

        IEnumerable<int> GetTotalByCategory(string categoria);

        IEnumerable<string> GetStatesAcronymsByCategory(string categoria);
    }
}
