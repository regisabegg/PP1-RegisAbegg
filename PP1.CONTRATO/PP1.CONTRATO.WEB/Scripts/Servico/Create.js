//$(function () {
//    var config = window.getDatatableConfig();

//    Item.dataTable = new tDataTable({
//        table: {
//            jsItem: "Itens_js",
//            name: "tblItens",
//            remove: true,
//            paginate: false,
//            order: config.order,
//            iDisplayStart: config.displayStart,
//            iDisplayLength: config.displayLength,
//            columns: [
                
//                { data: "Id", sortable: false },
//                { data: "Nome", sortable: false },

//            ]
//        }
//    });

//    $('#addItem').click(function () {
//        Item.adicionar();
//        return false;
//    });
//});

//var Item = {
//    dataTable: null,
//    validarCampos: function () {
//        var data = shared_function["FormaPagto"].data;
//        if (data == null) {
//            alert('Por favor, informe uma forma de pagamento!');
//            shared_function["FormaPagto"].focus();
//            return false;
//        }
//        else if (Item.dataTable.exists("Id", data.id)) {
//            alert('Esta forma de pagamento já foi informada, verifique!');
//            shared_function["FormaPagto"].focus();
//            return false;
//        }
//        return true;
//    },

//    limparCampos: function () {
//        shared_function["FormaPagto"].data = null;
//        shared_function["FormaPagto"].focus();
//    },

//    adicionar: function () {

//        if (Item.validarCampos()) {
//            var data = shared_function["FormaPagto"].data;
//            var item = {
//                Id: data.id,
//                Nome: data.text
//            }
//            Item.dataTable.addItem(item);
//            Item.limparCampos();
//        }
//    },
//};

