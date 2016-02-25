using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosViolenciaGrafico
    {
        private IEnumerable<int> _quantidade;

        private IEnumerable<string> _categoria;

        private string _estado;

        public IEnumerable<int> Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public IEnumerable<string> Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}