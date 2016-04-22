$(function () {

    $.jqplot.config.enablePlugins = true;
    var url = '/PostTwitters/GetGraphicData';

    $.ajax({
        url: url,
        type: 'GET',

        beforeSend: function () {
            sweetAlert({
                title: 'Processando dados',
                html: '</br><strong>Carregando dados do gráfico</strong></br></br></br>',
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
                title: '',
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
            title: '<h4><strong>Assalto por região</strong></h4>',

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

            highlighter: {
                showTooltip: true,
                tooltipFade: true,
                tooltipContentEditor: function (str, seriesIndex, pointIndex) {
                    return quantidade[pointIndex] + " ocorrências";

                }
            },

            axes:
            {
                tickOptions: { showGridline: false },
                xaxis:
                {
                    renderer: $.jqplot.CategoryAxisRenderer,
                    drawMajorGridlines: false,
                    ticks: siglas
                },
                
                yaxis: {
                    label: 'Quantidade de tweets',
                    labelRenderer: $.jqplot.CanvasAxisLabelRenderer
                }
            },

            axesDefaults: {
                rendererOptions: {
                    baselineWidth: 1.5,
                    drawBaseline: false
                }
            },
            


        });
    }
});