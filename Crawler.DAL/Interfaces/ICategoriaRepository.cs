using System;
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

        IEnumerable<int> GetTotalByCategoryWithStartDate(string categoria, DateTime dataInicio);

        IEnumerable<int> GetTotalByCategoryWithEndDate(string categoria, DateTime dataFim);

        IEnumerable<int> GetTotalByCategoryBetweenDates(string categoria, DateTime dataInicio, DateTime dataFim);

        int GetTotal(string categoria);

        int GetTotalWithStartDate(string categoria, DateTime dataInicio);

        int GetTotalWithEndDate(string categoria, DateTime dataFim);

        int GetTotalBetweenDates(string categoria, DateTime dataInicio, DateTime dataFim);
    }
}
