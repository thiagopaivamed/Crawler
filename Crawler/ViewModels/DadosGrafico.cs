﻿using System.Collections.Generic;

namespace Crawler.ViewModels
{
    public class DadosGrafico
    {
        public IEnumerable<string> Siglas { get; set; }
        public IEnumerable<int> Quantidade { get; set; }

    }
}