﻿$(function () {

    $("#btnGerarGrafico").on('click', function (e) {

        $.jqplot.config.enablePlugins = true;

        var dataInicio = $("#DataInicio").val();
        var dataFim = $("#DataFim").val();
        var categoria = $("#categoriasDDL option:selected").text();
        var estado = $("#estados option:selected").text();

        if (dataInicio.length <= 0 && dataFim.length <= 0) {
            sweetAlert({
                title: 'Erro',
                html: '<strong>Informe a data inicial e final</strong>',
                type: 'error',
                confirmButtonText: 'Entendi !',
                confirmButtonColor: "#008cba"
            });
        }

        else if (dataInicio.length <= 0) {
            sweetAlert({
                title: 'Erro',
                html: '<strong>Informe a data inicial</strong>',
                type: 'error',
                confirmButtonText: 'Entendi !',
                confirmButtonColor: "#008cba"
            });
        }

        else if (dataFim.length <= 0) {
            sweetAlert({
                title: 'Erro',
                html: '<strong>Informe a data final</strong>',
                type: 'error',
                confirmButtonText: 'Entendi !',
                confirmButtonColor: "#008cba"
            });
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
                
                beforeSend: function() {
                    sweetAlert({
                        title: 'Processando dados',
                        html: '</br><strong>Processando os dados pedidos</strong></br></br></br>',
                        type: 'warning',
                        showConfirmButton: false,
                        allowOutsideClick: false
                    });
                },

                success: function (dados) {
                    
                    if (dados.Quantidade.length <= 0) {
                        sweetAlert({
                            title: '',
                            html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                            type: 'error',
                            showConfirmButton: true
                        });
                    }

                    else {
                        GerarGrafico(dados, categoria, dataInicio, dataFim, estado);
                        sweetAlert({
                            title: 'Processando dados',
                            html: '</br><strong>Processo concluido</strong></br></br></br>',
                            type: 'success',
                            showConfirmButton: false,
                            allowOutsideClick: false,
                            timer: 1500
                        });
                    }
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

        }
    });

    function GerarGrafico(dados, categoria, dataInicio, dataFim, estado) {
        
        var datas = [];
        var d;
        var i = 0;
        
        while (i < dados.Datas.length) {
            d = moment.utc(dados.Datas[i]).format('D/M/YYYY');
            datas.push(d);
            i++;
        }

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
                        labels: [datas],
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

                highlighter: {
                    showTooltip: true,
                    tooltipFade: true,
                    tooltipContentEditor: function (str, seriesIndex, pointIndex) {
                        return "Data : " + datas[pointIndex] + "</br>" + "Ocorrências : " + dados.Quantidade[pointIndex];

                        }
                },

                axes:
                {
                    tickOptions: { showGridline: false },
                    xaxis:
                    {
                        renderer: $.jqplot.CategoryAxisRenderer,
                        autoscale: true,
                        drawMajorGridlines: false,
                        ticks: datas,
                        tickRenderer: $.jqplot.CanvasAxisTickRenderer,
                        tickOptions: {
                            angle: 45,
                            fontSize: '1.0em',
                            position: 'relative',
                            textAlign: 'center'
                            
                        }
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

            }).replot();
    }
});