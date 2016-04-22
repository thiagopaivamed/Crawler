$("#btnGerarGraficoGB").on('click', function () {

    $.jqplot.config.enablePlugins = true;
    var url = '/PostTwitters/GetGraphicData';
    var categorias = $("#categorias option:selected").text();
    var dataInicioGB = $("#DataInicioGB").val();
    var dataFimGB = $("#DataFimGB").val();

    //Sem datas definidas
    if (dataInicioGB.length <= 0 && dataFimGB.length <= 0) {

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
                if (result == null) {
                    sweetAlert({
                        title: '',
                        html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                        type: 'error',
                        showConfirmButton: true
                    });
                }

                else {

                    GerarGrafico(result.Quantidade, result.Siglas);
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
    
    //Com data de início definida
    else if (dataInicioGB.length > 0 && dataFimGB.length <= 0) {

        url = '/PostTwitters/GetTotalByCategoryWithStartDate';

        $.ajax({
            url: url,
            type: 'GET',
            data: {
                categoria: categorias,
                dataInicio: dataInicioGB
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

            success: function (result) {

                if (result.Quantidade.length == 0 || result.Quantidade == null) {
                    sweetAlert({
                        title: '',
                        html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                        type: 'error',
                        confirmButtonText: 'Entendi !',
                        confirmButtonColor: "#008cba"
                    });
                }

                else {

                    GerarGrafico(result.Quantidade, result.Siglas);

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

        //Com data de fim definida
    else if (dataInicioGB.length <= 0 && dataFimGB.length > 0) {

        url = '/PostTwitters/GetTotalByCategoryWithEndtDate';

        $.ajax({
            url: url,
            type: 'GET',
            data: {
                categoria: categorias,
                dataFim: dataFimGB
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

            success: function (result) {

                if (result.Quantidade.length == 0 || result.Quantidade == null) {
                    sweetAlert({
                        title: '',
                        html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                        type: 'error',
                        confirmButtonText: 'Entendi !',
                        confirmButtonColor: "#008cba"
                    });
                }

                else {

                    GerarGrafico(result.Quantidade, result.Siglas);

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

        //Com data de início e fim definida
    else {
        
        url = '/PostTwitters/GetTotalByCategoryBetweenDates';

        $.ajax({
            url: url,
            type: 'GET',
            data: {
                categoria: categorias,
                dataInicio: dataInicioGB,
                dataFim: dataFimGB
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

            success: function (result) {
               
                if (result.Quantidade.length == 0 || result.Quantidade == null) {
                    sweetAlert({
                        title: '',
                        html: '</br><strong>Sua pesquisa não retornou resultados.</strong></br></br></br>',
                        type: 'error',
                        confirmButtonText: 'Entendi !',
                        confirmButtonColor: "#008cba"
                    });
                }

                else {
                    
                    GerarGrafico(result.Quantidade, result.Siglas);
                    
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

    function GerarGrafico(quantidade, siglas) {
        $.jqplot('grafico', [quantidade], {
            seriesColors: ["#95a5a6"],
            animate: true,
            title: '<h4><strong>' + categorias + ' por região</strong> </h4>',

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

        }).replot();
    }
});