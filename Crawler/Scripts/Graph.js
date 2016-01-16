$("#categorias").on('change', function () {
    
    $.jqplot.config.enablePlugins = true;
    var url = '/PostTwitters/DadosGraficos';
    var categorias = $("#categorias option:selected").text();
    
    $.ajax({
        url: url,
        type: 'GET',
        data: { categoria: categorias },
        success: function (result) {
            GerarGrafico(result.Quantidade, result.Siglas);
        },
        error: function () {
            alert("Erro");
        }
    });
    
    function GerarGrafico(quantidade, siglas) {
        $.jqplot('grafico', [quantidade], {
            seriesColors: ["#3498db"],
            animate: true,
            title: '<h5>' + categorias + ' no Brasil </h5>',

            grid:
            {
                drawGridLines: true,
                gridLineColor: 'white',
                background: 'white',
                borderColor: 'white',
                shadow: false
            },

            series: [
            {
                pointLabels:
                {
                    show: true,
                    labels: [quantidade],
                    escapeHTML: true
                }
            }
            ],

            seriesDefaults:
            {
                renderer: $.jqplot.BarRenderer,
                pointLabels: { show: true, formatString: '%d' },
                rendererOptions:
                {
                    fillToZero: true

                }
            },

            legend: {
                show: true,
                location: 'e',
                placement: 'outside',
                showLabels: true,
                labels: ["Quantidade"]

            },

            highlighter: {
                showTooltip: true,
                tooltipFade: true
            },

            axes:
            {
                tickOptions: { showGridline: false },
                xaxis:
                {
                    renderer: $.jqplot.CategoryAxisRenderer,
                    ticks: siglas
                }
            },

        }).replot();
    }

    
});