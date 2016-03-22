using Crawler.BLL.Models;
using System.Collections.Generic;

namespace Crawler.DAL.Interfaces
{
    interface ICategoriaRepository
    {
        bool CheckIfExists(string categoria);

        int GetId(string categoria);

        IEnumerable<Categoria> GetAllCategories();

        void SaveCategory(Categoria category);

        IEnumerable<int> GetTotalByCategory(string categoria);

        int GetTotal(string categoria);
    }
}
