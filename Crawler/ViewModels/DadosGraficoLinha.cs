using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosGraficoLinha
    {
        public IEnumerable<int> Quantidade { get; set; }
        public IEnumerable<string> Datas { get; set; }
        public IEnumerable<string> Estados { get; set; }

    }
}