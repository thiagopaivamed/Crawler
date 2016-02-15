$(function ()
{

    var url = '/PostTwitters/GetMapData';
    var dados;
    var categoria = $("#CategoriasViolencia option:selected").text();

    $.ajax({
        url: url,
        type: 'GET',
        data: { categoria: categoria },
        success: function (data)
        {
            dados = data;
        },
        error: function (){ }
    });

    $("#CategoriasViolencia").on('change', function ()
    {
        categoria = $("#CategoriasViolencia option:selected").text();
        
        $.ajax({
            url: url,
            type: 'GET',
            data: { categoria: categoria },
            success: function (data) {
                dados = data;
            },
            error: function () {
            }
        });
    });


    $('#MapaViolencia').vectorMap({
        map: 'brazil_br',
        backgroundColor: null,
        borderColor: '#fff',
        borderOpacity: 0.25,
        borderWidth: 1,
        color: '#2980b9',
        enableZoom: false,
        hoverColor: '#2c3e50',
        selectedColor: '#27ae60',
        showTooltip: true,

        onLabelShow: function (event, label, code)
        {
            
            for (var i = 0; i <= dados.Codigos.length; i++)
            {
                if (dados.Codigos[i] == code)
                {
                    if (dados.Quantidade[i] != "")
                    {
                        label[0].innerHTML = "<div style='margin: auto;padding: 5px;'>" + "<center><strong>Aproximadamente " + ((dados.Quantidade[i] / dados.QuantidadeTotal) * 100).toFixed(2) + "% das ocorrências de " + (categoria.toLowerCase()) + "</br> acontecem em " + label[0].innerHTML + "</br> " + "</strong></center>" + "</div>";
                    }//fim else

                    else
                    {
                        label[0].innerHTML = "<div style='margin: auto;padding: 5px;'>" + "<center><strong>Sem dados dispóniveis a respeito de " + (categoria.toLowerCase()) + "</br> em " + label[0].innerHTML + "</br> " + "</strong></center>" + "</div>";
                    }// fim else
                    
                }// fim if
            }// fim for

        },

        onRegionClick: function (element, code) {
            ConstruirGrafico(code);
        }
    });

    function ConstruirGrafico(code)
    {

        $.jqplot.config.enablePlugins = true;

        var url = '/PostTwitters/GetViolenceData';

        $.ajax({
            url: url,
            type: 'GET',
            data: { codigo: code },
            success: function (data)
            {
                GerarGrafico(data.Quantidade, data.Categoria, data.Estado);
            },
            error: function () { }
        });
    }

    function GerarGrafico(quantidade, categoria, estado)
    {
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
                tooltipFade: true
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