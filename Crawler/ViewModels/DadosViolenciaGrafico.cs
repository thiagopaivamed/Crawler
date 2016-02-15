using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosViolenciaGrafico
    {
        public IEnumerable<int> Quantidade { get; set; }

        public IEnumerable<string> Categoria { get; set; }

        public string Estado { get; set; }
    }
}