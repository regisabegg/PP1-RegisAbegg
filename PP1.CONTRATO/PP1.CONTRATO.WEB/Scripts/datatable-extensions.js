//jQuery.fn.dataTableExt.oApi.fnFilterClear = function (oSettings) {
//    var i, iLen;

//    oSettings.oInit.hasColumnFilters = false;
//    oSettings.oPreviousSearch.sSearch = "";

//    for (i = 0, iLen = oSettings.aoPreSearchCols.length ; i < iLen ; i++) {
//        oSettings.aoPreSearchCols[i].sSearch = "";
//    }

//    oSettings.oApi._fnReDraw(oSettings);
//};

//jQuery.fn.dataTableExt.oApi.fnSingleFilter = function (oSettings, sSearch) {
//    oSettings.oInit.hasColumnFilters = false;
//    oSettings.oInstance.fnFilter(sSearch);
//};

//jQuery.fn.dataTableExt.oApi.fnMultiFilter = function (oSettings, oData) {
//    oSettings.oInit.hasColumnFilters = true;
//    for (var key in oData) {
//        if (oData.hasOwnProperty(key)) {
//            var itemFound = false;
//            for (var i = 0, iLen = oSettings.aoColumns.length ; i < iLen ; i++) {

//                if (oSettings.aoColumns[i].data == key) {
//                    oSettings.aoPreSearchCols[i].sSearch = oData[key];
//                    itemFound = true;
//                    break;
//                }
//            }

//            if (itemFound == false) {
//                var obj = {
//                    bCaseInsensitive: true,
//                    bRegex: true,
//                    bSmart: true,
//                    mData: key,
//                    sSearch: oData[key]
//                };
//                oSettings.aoPreSearchCols.pushUnique(obj);
//            }

//        }
//    }
//    this.oApi._fnReDraw(oSettings);
//};


jQuery.extend(jQuery.fn.dataTable.defaults, {
    processing: true,
    serverSide: true,
    // sort: true,
    autoWidth: false,
    //fnServerParams: function (aoData) {
    //    var name = "";
    //    var index = 0;
    //    $("form input, select").each(function () {
    //        if (this.type == "checkbox") {
    //            if (name != this.name) {
    //                name = this.name;
    //                index = 0;
    //            }
    //            if (this.checked) {
    //                aoData[this.name + "[" + index + "]"] = this.value;
    //                index++;
    //            }
    //        }
    //        else if (this.type == "radio") {
    //            aoData[this.name] = $("input[name=" + this.name + "]:checked").val();
    //        } else {
    //            if (this.id == "filter") {
    //                aoData.search.value = this.value;
    //            }
    //            aoData[this.id] = this.value;
    //        }
    //    });
    //},
    //"fnInfoCallback": function (oSettings, iStart, iEnd, iMax, iTotal, sPre) {

    //    $("tr").click(function () {
    //        if ($(this).hasClass("row-selected")) {
    //            $(this).removeClass("row-selected");
    //        } else {
    //            $(this).addClass("row-selected");
    //        }
    //    });

    //    window.setDatatableConfig(oSettings);
    //    if (iEnd == 0)
    //        return "Mostrando 0 até 0 de 0 registros";
    //    return "Mostrando de " + iStart + " até " + iEnd + " de " + iTotal + " registros"
    //},
    language: {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sInfoFiltered": "",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ resultados por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar: ",
        "oPaginate": {
            "sNext": "Próximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Último"
        },
        "oAria": {            
            "sSortDescending": ": Ordenar colunas de forma descendente",
            "sSortAscending": ": Ordenar colunas de forma ascendente"
        }
    }
});

var getDatatablePathName = function (path) {
    path = path ? path : window.location.pathname.toLowerCase();

    if (path.endsWith('/')) {
        return getDatatablePathName(path.replaceLast('/', ''));
    }

    if (path.endsWith('index')) {
        return getDatatablePathName(path.replaceLast('index', ''));
    }

    return path;
};

var getDatatableConfig = function () {
    var name = "datatables_" + getDatatablePathName().toLowerCase();
    var displayLength = Configuration.defaultPageSize == undefined ? 25 : parseInt(Configuration.defaultPageSize)
    var table = { displayStart: 0, displayLength: displayLength, order: [[0, 'desc']] };

    if (location.search.toLocaleLowerCase().indexOf('clear=true') < 0) {

        var ls = LocalStorage.get(name);
        if (ls != null && ls.table != null) {
            table = ls.table;
        }

        if (ls != null && ls.parameters != null) {
            $("form input, select").each(function () {

                if (this.type == "checkbox" || this.type == "radio") {
                    this.checked = ls.parameters[this.id];
                } else if (this.type != "file") {
                    this.value = ls.parameters[this.id];
                }
            });
        }
    }


    table.buttons = [
            'pageLength',
            {
                extend: 'copyHtml5',
                titleAttr: 'Copiar registros',
                className: 'btn btn-primary',
                key: {
                    key: 'c',
                    altKey: true
                },
                exportOptions: {
                    columns: '[export="true"]'
                }
            },
            {
                extend: 'pdfHtml5',
                titleAttr: 'Gerar relatório em PDF',
                text: '<i class="fa fa-file-pdf-o"></i>',
                className: 'btn btn-primary',
                exportOptions: {
                    columns: '[export="true"]'
                }
            },
            {
                extend: 'excel',
                titleAttr: 'Gerar planilha de excel',
                text: '<i class="fa fa-file-excel-o"></i>',
                className: 'btn btn-primary',
                exportOptions: {
                    columns: '[export="true"]'
                }
            }
    ];
    table.columnDefs = [
    {
        columns: '.data',
        visible: true,
    }
    ],
    table.language = {
        buttons: {
            copy: '<i class="fa fa-files-o"></i>',
            copySuccess: {
                1: "Um registro copiado",
                _: "Copiado %d registros"
            },
            copyTitle: 'Copiar registros',
            copyKeys: 'Appuyez sur <i>ctrl</i> ou <i>\u2318</i> + <i>C</i> pour copier les données du tableau à votre presse-papiers. <br><br>Pour annuler, cliquez sur ce message ou appuyez sur Echap.',

            pageLength: {
                _: "%d registros",
            }
        }
    };
    table.lengthMenu = [
          [10, 25, 50, 100, 1000],
          ['10 registros', '25 registros', '50 registros', '100 registros', '1000 registros']
    ];
    table.dom = "<'row'<'visible-lg visible-md hidden-sm hidden-xs  col-md-6'B><'col-md-6'p><'col-md-12 wrapper_processing'r>>t<'row'<'visible-lg visible-md hidden-sm hidden-xs col-md-6'i><'col-md-6'p>>";

    return table;
};

if (typeof String.prototype.replaceLast !== 'function') {
    String.prototype.replaceLast = function (find, replace) {
        var index = this.lastIndexOf(find);

        if (index >= 0) {
            return this.substring(0, index) + replace + this.substring(index + find.length);
        }

        return this.toString();
    };
}

var setDatatableConfig = function (settings) {
    var name = "datatables_" + getDatatablePathName().toLowerCase();
    var parameters = {};
    $("form input, select").each(function () {
        if (this.type == "checkbox" || this.type == "radio") {
            parameters[this.id] = this.checked;
        } else {
            parameters[this.id] = this.value;
        }
    });
    var table = {
        url: getDatatablePathName().toLowerCase(),
        tableId: settings.nTable.id,
        search: settings.oPreviousSearch.sSearch,
        displayStart: settings._iDisplayStart,
        displayLength: settings._iDisplayLength,
        order: settings.aaSorting,
        hasColumnFilters: settings.oInit.hasColumnFilters || false,
        searchColumns: (settings.oInit.hasColumnFilters || false) ? getDataFromColumns(settings) : []
    }

    var title = document.getElementsByTagName('title')[0].innerHTML;

    var url = window.location.href.toLocaleLowerCase().replace('clear=true&', '').replace('&clear=true', '').replace('clear=true', '');

    window.history.pushState("", title, url);

    var result = { "parameters": parameters, "table": table };
    LocalStorage.set(name, result);
};