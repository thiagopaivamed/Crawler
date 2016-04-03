$('#DataInicio, #DataFim, #DataInicioGB, #DataFimGB, #DataInicioMapa, #DataFimMapa').datepicker({
    format: "dd/mm/yyyy",
    startDate: "25/01/2016",
    endDate: "today",
    language: "pt-BR",
    autoclose: true,
    todayHighlight: true
});


$('#DataInicio, #DataFim ,#DataInicioGB, #DataFimGB, #DataInicioMapa, #DataFimMapa').tooltip();