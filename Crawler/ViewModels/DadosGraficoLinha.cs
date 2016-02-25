using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosGraficoLinha
    {
        private IEnumerable<int> _quantidade;
        private IEnumerable<string> _datas;

        public IEnumerable<int> Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public IEnumerable<string> Datas
        {
            get { return _datas; }
            set { _datas = value; }
        }
       
    }
}