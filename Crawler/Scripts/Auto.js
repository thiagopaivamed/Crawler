
var options = {

    url: '/PostTwitters/GetCategories',

    getValue: "Nome",

    list: {
        match: {
            enabled: true,
        },
        
        sort: {
            enabled: true
        },
        
        showAnimation: {
            type: "fade", 
            time: 400
        },

        hideAnimation: {
            type: "slide", 
            time: 400
        },

        maxNumberOfElements: 8
    },
    
    theme: "bootstrap"


};

$("#termo").easyAutocomplete(options);


