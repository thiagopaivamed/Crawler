using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosGraficoLinha
    {
        private IEnumerable<int> _quantidade;
        private IEnumerable<string> _datas;
        private IEnumerable<string> _estados;

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

        public IEnumerable<string> Estados
        {
            get { return _estados; }
            set { _estados = value; }
        }
    }
}