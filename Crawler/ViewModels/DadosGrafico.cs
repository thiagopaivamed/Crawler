using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosGrafico
    {
        private IEnumerable<string> _siglas;
        private IEnumerable<int> _quantidade;

        public IEnumerable<string> Siglas
        {
            get { return _siglas; }
            set { _siglas = value; }
        }

        public IEnumerable<int> Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
       
    }
}