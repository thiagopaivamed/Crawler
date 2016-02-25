using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosMapas
    {
        private IEnumerable<int> _codigos;
        private IEnumerable<int> _quantidade;
        private int _quantidadeTotal;

        public IEnumerable<int> Codigos
        {
            get { return _codigos; }
            set { _codigos = value; }
        }

        public IEnumerable<int> Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public int QuantidadeTotal
        {
            get { return _quantidadeTotal; }
            set { _quantidadeTotal = value; }
        }
    }
}