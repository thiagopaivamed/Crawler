$("#categorias").on('change', function () {
    
    $.jqplot.config.enablePlugins = true;
    var url = '/PostTwitters/GetGraphicData';
    var categorias = $("#categorias option:selected").text();
    
    $.ajax({
        url: url,
        type: 'GET',
        data: { categoria: categorias },
        
        beforeSend: function () {
            sweetAlert({
                title: 'Processando dados',
                html: '</br><strong>Processando os dados pedidos</strong></br></br></br>',
                type: 'warning',
                showConfirmButton: false,
                allowOutsideClick: false
            });
        },

        complete: function () {
            sweetAlert({
                title: 'Processando dados',
                html: '</br><strong>Processo concluido</strong></br></br></br>',
                type: 'success',
                showConfirmButton: false,
                allowOutsideClick: false,
                timer: 1500
            });
        },

        success: function (result) {
            GerarGrafico(result.Quantidade, result.Siglas);
        },
        error: function () {
            sweetAlert({
                title: 'Erro',
                html: '<strong>Não foi possível processar os dados</strong>',
                type: 'error',
                confirmButtonText: 'Entendi !',
                confirmButtonColor: "#008cba"
            });
        }
    });
    
    function GerarGrafico(quantidade, siglas) {
        $.jqplot('grafico', [quantidade], {
            seriesColors: ["#95a5a6"],
            animate: true,
            title: '<h4><strong>' + categorias + ' no Brasil</strong> </h4>',

            grid:
            {
                drawBorder: false,
                borderWidth: 0,
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
                    drawMajorGridlines: false,
                    ticks: siglas
                }
            },
            
            axesDefaults: {
                rendererOptions: {
                    baselineWidth: 1.5,
                    drawBaseline: false
                }
            },

        }).replot();
    }

    
});