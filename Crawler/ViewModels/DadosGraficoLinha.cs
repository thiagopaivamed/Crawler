using System;
using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosGraficoLinha
    {
        private IEnumerable<int> _quantidade;
        private List<DateTime?> _datas;
       
        public IEnumerable<int> Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public List<DateTime?> Datas
        {
            get { return _datas; }
            set { _datas = value; }
        }
    }
}