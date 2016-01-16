using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.BLL.Models;

namespace Crawler.DAL.Interfaces
{
    interface IEstadoRepository
    {
        IEnumerable<Estado> GetAllStates();

        string GetStatebyId(int id);

        IEnumerable<string> GetStatesAcronyms();

        IEnumerable<int> GetStatesIds();

        IEnumerable<string> GetStatesNames();

        IEnumerable<int> GetTotal();

        IEnumerable<string> GetStatesAcronymsByCategory(string categoria);
    }
}
