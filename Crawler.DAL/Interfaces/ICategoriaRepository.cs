using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.BLL.Models;

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
