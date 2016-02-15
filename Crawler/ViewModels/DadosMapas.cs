using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosMapas
    {
        public IEnumerable<int> Codigos { get; set; }
        public IEnumerable<int> Quantidade { get; set; }
        public int QuantidadeTotal { get; set; }
    }
}