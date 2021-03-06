$(function () {
   
    Item.datatable = new tDataTable({
        
        table: {
           
            jsItem: "Itens_js",
            name: "tblItens",
            remove: true,
            edit: false,
            paginate: false,
            order: [[1, "asc"]],
            sortable: false,
            data: null,
            columns: [
                {
                    data: 'nrParcela',
                    sortable: false,
                    mRender: function (data) {
                        return '<div style="text-align: right">' + data + '</div>';
                    }
                },
                {
                    data: 'qtDias',
                    sortable: false,
                    mRender: function (data) {
                        return '<div style="text-align: right">' + data + '</div>';
                    }
                },
                {
                    data: 'txPercentual',
                    sortable: false,
                    mRender: function (data) {
                        return '<div style="text-align: right">' + parseFloat(data) + '</div>';
                    }
                },
                { data: "nmFormaPagto" },

               
            ]
        }
    });

    //AtualizaTaxa(dtCondicao);

    //$(document).on('tblCondicaoAfterDelete', function (e, data) {
    //    self.AtualizaTaxa(dtCondicao);
    //})

    $('#removeAll').click(function () {
        Item.removerTudo();
        return false;
        //e.preventDefault();
    });

    
    $('#addItem').click(function () {

        Item.adicionar(Item.datatable);
        return false;
    });
});

let nr = 1;

var Item = {
    datatable: null,

    validarForm: function (datatable) {

        if (($("#qtDias").val() == "")) {
            alert('Por favor, informe quantos dias para pagamento');
            $("#qtDias").focus();
            return false;
        }

        if (($("#txPercent").val() == "")) {
            alert('Por favor, informe o percetual de cobrança');
            $("#txPercent").focus();
            return false;
        }

        if (($("#FormaPagto_id").val() == "")) {
            alert('Por favor, informe a forma de pagamento');
            $("#FormaPagto_id").focus();
            return false;
        }


        //let txTotal = $("#txTotPercent").val();
        //let txPercentual = $("#txPercent").val();

        //if (!IsNullOrEmpty(txPercentual)) {
        //    if (!IsNullOrEmpty(txTotal)) {
        //        txTotal = parseFloat(txTotal);
        //    }
        //    txPercentual = txPercentual.replace(",", ".");
        //    txPercentual = parseFloat(txPercentual);
        //    txTotal = parseFloat(txTotal);

        //    let total = txTotal + txPercentual;
        //    if (total > 100) {
        //        $("#txTotPercent").blink({ msg: "O valor total deve ser equivalente a 100%, verifique!" });
        //        valid = false;
        //    }
        //}

        ////item
        //console.log(dtCondicao.length)
        //nrParcelaAux = dtCondicao.length;
        //console.log(nrParcelaAux)
        
        return true;
    },

    limparForm: function () {
        $("#FormaPagto_id").val('');
        $("#FormaPagto_text").val('');        
        $("#qtDias").val('');
        $("#txPercent").val('');
    },

    getForm: function () {

        return {           
            idFormaPagto: $('#FormaPagto_id').val(),
            nmFormaPagto: $('#FormaPagto_text').val(),
            qtDias: $('#qtDias').val(),
            txPercentual: $('#txPercent').val(),
        };
    },

    adicionar: function (datatable) {

        
        var form = Item.getForm();
     
        if (Item.validarForm(datatable)) {
         
            var item = {

                nrParcela: nr,
                idFormaPagto: form.idFormaPagto,
                nmFormaPagto: form.nmFormaPagto,
                qtDias: form.qtDias,
                txPercentual: form.txPercentual,               
            }
            nr++;
            console.log(item);
            datatable.addItem(item);
            Item.limparForm();

            $("#FormaPagto_id").focus();
        }
    },

    //removerTudo: function (datatable) {
    //    alert();
    //   // var dtCondicao = null,
           
    //    if (dtCondicao.data == null || !dtCondicao.data.length) {
           
    //        alert('Não existem parcelas para serem removidas');
    //    } else {
    //        dtCondicao.data = null;
    //        //$("#txPercent").val(0);
    //        //$("#txPercent").val(0);
    //    }
    //}

    removerTudo: function () {
        Item.limparForm();
        Item.datatable.data = null;
        //Item.txPercentual();
    },

    //AtualizaTaxa = function (data) {

    //    let taxaTotal = 0;
    //    let dt = data.data;
    //    let aux = "";
    //    for (var i = 0; i < dt.length; i++) {
    //        if (typeof (dt[i].txPercentual) == "string") {
    //            aux = dt[i].txPercentual.replace(",", ".");
    //            aux = parseFloat(aux);
    //        } else {
    //            aux = dt[i].txPercentual;
    //        }
    //        taxaTotal += aux;
    //    }
    //    $("#txTotPercent").val(taxaTotal);
    //}

   
}
