using Crawler.BLL.Models;
using System.Collections.Generic;

namespace Crawler.DAL.Interfaces
{
    interface IEstadoRepository
    {
        IEnumerable<Estado> GetAllStates();

        string GetStatebyId(int id);
       
        IEnumerable<string> GetStatesAcronymsByCategory(string categoria);

        IEnumerable<int> GetStatesCodesByCategory(string categoria);

        IEnumerable<int> GetTotalByCode(int codigo);

        IEnumerable<string> GetCategoryByCode(int codigo);

    }
}
