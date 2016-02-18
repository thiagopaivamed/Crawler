$(function () {

    $("#btnGerarGrafico").on('click', function (e) {

        $.jqplot.config.enablePlugins = true;

        var dataInicio = $("#DataInicio").val();
        var dataFim = $("#DataFim").val();
        var categoria = $("#categoriasDDL option:selected").text();
        var estado = $("#estados option:selected").text();

        if (dataInicio.length <= 0 && dataFim.length <= 0) {
            alert("Informe as datas de inicio e fim");
        }

        else if (dataInicio.length <= 0) {
            alert("Informe a data de inicio");
        }

        else if (dataFim.length <= 0) {
            alert("Informe a data de fim");
        }

        else {

            var url = '/PostTwitters/GetTemporalData';
            $.ajax({
                url: url,
                type: 'GET',
                data: {
                    categoria: categoria,
                    dataInicio: dataInicio,
                    dataFim: dataFim,
                    estado: estado
                },
                success: function (dados) {
                    GerarGrafico(dados, categoria, dataInicio, dataFim, estado);
                },
                error: function () {
                }
            });

        }
    });

    function GerarGrafico(dados, categoria, dataInicio, dataFim, estado) {

        $.jqplot('GraficoTemporal', [dados.Quantidade],
            {
                seriesColors: ["#95a5a6"],
                animate: true,
                title: '<h4><strong>' + categoria + ' no estado de(o) ' + estado + ' no periodo de  ' + dataInicio + ' à ' + dataFim + '</strong> </h4>',

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
                        labels: [dados.Datas],
                        escapeHTML: true
                    }
                }
                ],

                seriesDefaults:
                {
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
                        autoscale: true,
                        drawMajorGridlines: false,
                        ticks: dados.Datas,
                        tickRenderer: $.jqplot.CanvasAxisTickRenderer,
                        tickOptions: {
                            angle: 30
                        }
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