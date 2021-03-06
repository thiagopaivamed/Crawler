﻿$(function () {
    
    var url = '/PostTwitters/GetMapData';
    var dados;
    var categoria = $("#CategoriasViolencia option:selected").text();

    $.ajax({
        url: url,
        type: 'GET',
        data: { categoria: categoria },

        beforeSend: function () {
            sweetAlert({
                title: 'Processando dados',
                html: '</br><strong>Carregando dados do mapa</strong></br></br></br>',
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
                timer: 1000
            });
        },

        success: function (data) {
            dados = data;
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

    $("#btnGerarMapa").on('click', function () {
        categoria = $("#CategoriasViolencia option:selected").text();
        var dataInicioMapa = $("#DataInicioMapa").val();
        var dataFimMapa = $("#DataFimMapa").val();

        // Sem datas especificadas
        if (dataInicioMapa.length <= 0 && dataFimMapa.length <= 0) {

            $.ajax({
                url: url,
                type: 'GET',
                data: { categoria: categoria },

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
                        timer: 1000
                    });
                },

                success: function (data) {

                    dados = data;
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

        }// fim if sem datas especificadas
        
            // Com data de início especificadas
        else if (dataInicioMapa.length >= 0 && dataFimMapa.length <= 0) {
            url = '/PostTwitters/GetMapDataWithStartDate';

            $.ajax({
                url: url,
                type: 'GET',
                data: {
                    categoria: categoria,
                    dataInicio: dataInicioMapa
                },

                beforeSend: function () {
                    sweetAlert({
                        title: 'Processando dados',
                        html: '</br><strong>Processando os dados pedidos</strong></br></br></br>',
                        type: 'warning',
                        showConfirmButton: false,
                        allowOutsideClick: false
                    });
                },

                success: function (data) {

                    if (data.Quantidade.length == 0 || data.Quantidade == null) {
                        sweetAlert({
                            title: '',
                            html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                            type: 'error',
                            confirmButtonText: 'Entendi !',
                            confirmButtonColor: "#008cba"
                        });
                    }

                    else {
                        dados = data;
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

        }// fim else if Com data de início especificadas
        
            // Com data de fim especificada
        else if (dataInicioMapa.length <= 0 && dataFimMapa.length >= 0) {
            url = '/PostTwitters/GetMapDataWithEndDate';

            $.ajax({
                url: url,
                type: 'GET',
                data: {
                    categoria: categoria,
                    dataFim: dataFimMapa
                },

                beforeSend: function () {
                    sweetAlert({
                        title: 'Processando dados',
                        html: '</br><strong>Processando os dados pedidos</strong></br></br></br>',
                        type: 'warning',
                        showConfirmButton: false,
                        allowOutsideClick: false
                    });
                },

                success: function (data) {

                    if (data.Quantidade.length == 0 || data.Quantidade == null) {
                        sweetAlert({
                            title: '',
                            html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                            type: 'error',
                            confirmButtonText: 'Entendi !',
                            confirmButtonColor: "#008cba"
                        });
                    }

                    else {
                        dados = data;
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
        }// fim else if Com data de fim especificada

            // Com data de início e fim especificadas
        else {
            url = '/PostTwitters/GetMapDataWithBetweenDates';

            $.ajax({
                url: url,
                type: 'GET',
                data: {
                    categoria: categoria,
                    dataInicio: dataInicioMapa,
                    dataFim: dataFimMapa
                },

                beforeSend: function () {
                    sweetAlert({
                        title: 'Processando dados',
                        html: '</br><strong>Processando os dados pedidos</strong></br></br></br>',
                        type: 'warning',
                        showConfirmButton: false,
                        allowOutsideClick: false
                    });
                },

                success: function (data) {

                    if (data.Quantidade.length == 0 || data.Quantidade == null) {
                        sweetAlert({
                            title: '',
                            html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                            type: 'error',
                            confirmButtonText: 'Entendi !',
                            confirmButtonColor: "#008cba"
                        });
                    }

                    else {
                        dados = data;
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

        }// fim else Com data de início e fim especificadas
    });


    $('#MapaViolencia').vectorMap({
        map: 'brazil_br',
        backgroundColor: null,
        borderColor: '#fff',
        borderOpacity: 0.25,
        borderWidth: 1,
        color: "#2980b9",
        enableZoom: false,
        hoverColor: '#2c3e50',
        selectedColor: '#27ae60',
        showTooltip: true,
        onLabelShow: function (event, label, code) {

            for (var i = 0; i <= dados.Codigos.length; i++) {
                if (dados.Codigos[i] == code) {
                    if (dados.Quantidade[code - 1] != "") {
                        label[0].innerHTML = "<div style='margin: auto;padding: 5px;'>" + "<center><strong>Aproximadamente " + ((dados.Quantidade[code - 1] / dados.QuantidadeTotal) * 100).toFixed(2) + "% das ocorrências de " + (categoria.toLowerCase()) + "</br> acontecem em " + label[0].innerHTML + "</br> " + "</strong></center>" + "</div>";
                    }//fim else

                    else {
                        label[0].innerHTML = "<div style='margin: auto;padding: 5px;'>" + "<center><strong>Sem dados dispóniveis a respeito de " + (categoria.toLowerCase()) + "</br> em " + label[0].innerHTML + "</br> " + "</strong></center>" + "</div>";
                    }// fim else

                }// fim if
            }// fim for

        },

        onRegionClick: function (element, code) {
            ConstruirGrafico(code);
        }
    });
  

    function ConstruirGrafico(code) {

            $.jqplot.config.enablePlugins = true;

            var url = '/PostTwitters/GetViolenceData';

            $.ajax({
                url: url,
                type: 'GET',
                data: { codigo: code },
                success: function (data) {
                    if (data == null) {
                        sweetAlert({
                            title: '',
                            html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                            type: 'success',
                            showConfirmButton: true
                        });
                    }

                    else {
                        GerarGrafico(data.Quantidade, data.Categoria, data.Estado);
                    }
                },
                error: function () { }
            });
        }

        function GerarGrafico(quantidade, categoria, estado) {
            $.jqplot('GraficoViolencia', [quantidade], {
                seriesColors: ["#95a5a6"],
                animate: true,
                title: '<h4><strong>Violência em ' + estado + ' </strong></h4>',

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
                        ticks: categoria
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