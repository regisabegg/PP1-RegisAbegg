$(function () {
    var config = window.getDatatableConfig();

    var table = $('#lista').DataTable({
        ajax: { url: $('#lista').attr('data-url') },
        fnServerParams: function (aoData) {
            aoData.search.value = $('#filter').val();
            
        },
        order: config.order,
        iDisplayStart: config.displayStart,
        iDisplayLength: config.displayLength,
        search: { search: config.search },
        pageLength: config.displayLength,
        //lengthMenu: config.lengthMenu,
        //dom: config.dom,
        buttons: config.buttons,
        columnDefs: config.columnDefs,
        language: config.language,
        columns: [


            { data: "idFormaPagto", className:'dt-right' },
            { data: "nmFormaPagto" },
       
            //{
            //    data: "dtCadastro",
            //    sType: "date",
            //    mRender: function (data) {
            //        return data == null ? "" : data.toDateFromJson('dd/MM/yyyy');
            //    }
            //},
            //{
            //    data: "dtAtualizacao",
            //    sType: "date",
            //    mRender: function (data) {
            //        return data == null ? "" : data.toDateFromJson('dd/MM/yyyy');
            //    }
            //},

         
            {
                sortable: false,
                data: null,
                sClass: 'center',
                mRender: function (data) {
                    return tmpl("lista-actions", data);
                }
            },

        ],

    });

    $('.dataTables_length select').select2({ minimumResultsForSearch: Infinity });

    $('#filter').keypress(function (event) {

        console.log(event);
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            event.preventDefault()
            table.draw()
        }
    });

    $('#lista_filter').hide();
    $('#btnFilter').click(function (e) {
        e.preventDefault()
        table.draw()
    });
});

