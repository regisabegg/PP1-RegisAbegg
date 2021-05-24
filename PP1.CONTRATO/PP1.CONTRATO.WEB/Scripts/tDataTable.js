
function tDataTable(options) {
    var self = this;
    this.settings = options;
    this.currentTable = $("#" + self.settings.table.name);
    this.jsItem = $("#" + self.settings.table.jsItem);
    this.currentDataTable = null;
    this.dataSelected = null;
    this.isEdit = false;

    var init = function () {
        var columns = new Array();
        var btns = "";
        var $table = self.currentTable;
        var $item = self.jsItem;

        if ($item.length == 0) {
            throw "Nao foi possivel encontrar o jsItem, favor nao cabacear!";
        }
        if ($table.length == 0) {
            throw "Nao foi possivel encontrar a table, favor nao cabacear!";
        }

        $table.addClass(defaults.rootClass);

        count = 0;
        if (self.settings.table.select) {
            var title = self.settings.table.titleSelect == undefined ? "Selecionar registro" : self.settings.table.titleSelect;
            var btnCheck = defaults.btnCheck.replace("{0}", title);

            count += 33.33;
            btns += btnCheck;
        }
        if (self.settings.table.remove) {
            count += 33.33;
            btns += defaults.btnRemove;
        }
        if (self.settings.table.edit) {
            count += 33.33;
            btns += defaults.btnEdit;
        }
        var rowReorder = (self.settings.table.rowReorder == undefined) ? null : self.settings.table.rowReorder;
        if (btns != "" && rowReorder == null) {

            var actions = "<div style='width:" + count + "px'>" + btns + "</div>"
            columns.push({
                sortable: false,
                data: null,
                sClass: 'center',
                sWidth: "10px",
                mRender: function (data) {
                    return actions;
                }
            });
        }
        var selectGrid = (self.settings.table.selectGrid == undefined || self.settings.table.selectGrid == true) ? true : false;

        for (var i = 0; i < self.settings.table.columns.length; i++) {

            item = self.settings.table.columns[i];

            var visible = (item.visible == "undefined" || item.visible == false) ? false : true;
            var sortable = (item.sortable == "undefined" || item.sortable == false) ? false : true;

            columns.push({
                data: item.data,
                sClass: item.sClass,
                mRender: item.mRender,
                sortable: sortable,
                visible: visible,
                sType: item.sType,
                defaultContent: item.defaultContent
            });
        }
        if (btns != "" && rowReorder != null) {

            var actions = "<div style='width:" + count + "px'>" + btns + "</div>"
            columns.push({
                sortable: false,
                data: null,
                sClass: 'center',
                sWidth: "10px",
                mRender: function (data) {
                    return actions;
                }
            });
        }
        var dataSet = $item.val() ? jQuery.parseJSON($item.val()) : null;
        var paginate = (self.settings.table.paginate == "undefined" || self.settings.table.paginate == false) ? false : true;
        var order = (self.settings.table.order == "undefined") ? [[1, "desc"]] : self.settings.table.order;
        var dom = (self.settings.table.dom) ? self.settings.table.dom : "<'row'<'visible-lg visible-md hidden-sm hidden-xs  col-md-6'l><'col-md-6'f><'col-md-12'r>>t<'row'<'visible-lg visible-md hidden-sm hidden-xs col-md-6'i><'col-md-6'p>>";

        self.currentDataTable = $table.dataTable({
            sDom: paginate ? dom : "t<'row'<'visible-lg visible-md hidden-sm hidden-xs col-md-12'i>>",
            bServerSide: false,
            columns: columns,
            bPaginate: paginate,
            data: dataSet,
            order: order,
            rowReorder: rowReorder,
            pageLength: self.settings.table.pageLength == null ? 25 : self.settings.table.pageLength,
            fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                var result = { nRow: nRow, aData: aData, iDisplayIndex: iDisplayIndex, iDisplayIndexFull: iDisplayIndexFull };
                $(document).trigger(self.settings.table.name + 'RowCallback', result);
                if (aData.flCheck == null) {
                    $('td a[data-event=select]', nRow).find("i").removeClass().addClass("fa fa-check");
                } else if (aData.flCheck == true) {
                    $('td a[data-event=select]', nRow).find("i").removeClass().addClass("fa fa-check-square-o");
                    $(nRow).addClass("row-selected");
                } else {
                    $('td a[data-event=select]', nRow).find("i").removeClass().addClass("fa fa-square-o");
                }
                var data = { row: nRow, item: aData };
                $('td a[data-event=remove]', nRow).off('click').on('click', function (e) {

                    self.deleteItem(data);

                    e.preventDefault()
                });

                $('td a[data-event=edit]', nRow).off('click').on('click', function (e) {
                    openEdit(data);

                    e.preventDefault()
                });

                $('td a[data-event=select]', nRow).off('click').on('click', function (e) {
                    if (data.item.flCheck != null) {
                        if (data.item.flCheck == false) {
                            data.item.flCheck = true;
                            $('td a[data-event=select]', nRow).find("i").removeClass().addClass("fa fa-check-square-o");
                            $(nRow).addClass("row-selected");
                        } else {
                            data.item.flCheck = false;
                            $('td a[data-event=select]', nRow).find("i").removeClass().addClass("fa fa-square-o");
                            $(nRow).removeClass("row-selected");
                        }
                    }
                    selectItem(data);
                    e.preventDefault()
                    return false;
                });
                if (self.settings.table.select && selectGrid) {
                    $('td', nRow).off('click').on('click', function (e) {
                        if (data.item.flCheck != null) {
                            if (data.item.flCheck == false) {
                                data.item.flCheck = true;
                                $('td a[data-event=select]', nRow).find("i").removeClass().addClass("fa fa-check-square-o");
                                $(nRow).addClass("row-selected");
                            } else {
                                data.item.flCheck = false;
                                $('td a[data-event=select]', nRow).find("i").removeClass().addClass("fa fa-square-o");
                                $(nRow).removeClass("row-selected");
                            }
                        }
                        selectItem(data);
                        e.preventDefault()
                    });
                }
            },
            fnInfoCallback: null,
            fnDrawCallback: function (setings) {
                if (self.settings.table.handlers) {
                    Functions.handlers.mask();
                    Functions.handlers.runMaskMoney();
                }
                if (self.settings.table.select && selectGrid) {
                    $table.find('tbody tr td').css('cursor', 'pointer');
                }
                $(document).trigger(self.settings.table.name + 'DrawCallback', setings);
            },
        }).on('row-reorder', function (e, diff, edit) {
            var itens = self.currentDataTable.fnGetData();
            console.log(itens)
        });
    };

    self.currentTable.on({
        change: function () {
            var value = null;
            var row = $(this).parents('tr');
            var id = $(this).attr("data-id");
            var item = self.currentDataTable.fnGetData(row);
            if ($(this).attr("data-type") == "currency") {
                value = Functions.parseFloatInput($(this));
            } else {
                value = this.value;
            }
            item[id] = value;
            self.atualizarItens();
        }
    }, 'input[data-event=true]');

    var selectItem = function (data) {

        self.dataSelected = data;

        var itens = self.currentDataTable.fnGetData();
        if (self.settings.table.selectUnique == true) {

            for (var i = 0; i < itens.length; i++) {
                itens[i].flCheck = JSON.stringify(data.item) == JSON.stringify(itens[i]);
            }
            self.clear();
            self.addItens(itens);
        }
        else {
            self.jsItem.val(JSON.stringify(itens));
        }

        $(document).trigger(self.settings.table.name + 'SelectItem', data);

    }


    var openEdit = function (data) {
        /// <signature>
        ///   <summary>Habilita a edição do item selecionado na grid</summary>
        ///   <param name="data" type="Objeto">O objeto data contem a row na qual foi selecionado o item na grid e o próprio item selecionado</param>
        /// </signature>

        var hasEdit = $(data.row).find("[data-event='edit']").hasClass("btn-success");

        $(self.currentTable).find("tr [data-event='edit']").removeClass("btn-success").addClass("btn-info").attr("title", "Editar registro");

        if ((self.isEdit == false && hasEdit == false) || (self.isEdit && hasEdit == false)) {

            $(data.row).find("[data-event='edit']")
                .removeClass("btn-info")
                .addClass("btn-success")
                .attr("editando", "true")
                .attr("title", "Este registro esta aberto para edição");

            self.dataSelected = data;
            self.isEdit = true;

            $(document).trigger(self.settings.table.name + 'OpenEdit', data);
        } else {
            self.dataSelected = null;
            self.isEdit = false;
            $(document).trigger(self.settings.table.name + 'CancelEdit', data);
        }
    }

    this.cancelEdit = function () {
        /// <signature>
        ///   <summary>Cancela a edição do item selecionado na grid</summary
        /// </signature>
        $(self.currentTable).find("tr [data-event='edit']").removeClass("btn-success").addClass("btn-info").attr("title", "Editar registro");

        self.dataSelected = null;
        self.isEdit = false;
        $(document).trigger(self.settings.table.name + 'CancelEdit', true);
    }

    this.atualizarItens = function () {
        /// <signature>
        ///   <summary>Atualiza  JSON (jsItem) com valores da grid.</summary>
        /// </signature>
        var itens = self.currentDataTable.fnGetData();

        self.jsItem.val(JSON.stringify(itens));

        $(document).trigger(self.settings.table.name + 'AfterAtualize', true);

    }
    this.atualizarGrid = function () {
        /// <signature>
        ///   <summary>Atualiza  a grid com valores do JSON (jsItem).</summary>
        /// </signature>
        if (self.jsItem.val() != "") {

            self.currentDataTable.fnClearTable();

            var list = JSON.parse(self.jsItem.val())

            self.addItens(list);
        }
    }

    this.getData = function (row) {
        /// <signature>
        ///     <summary>Retorna um item selecionado na Grid</summary>
        ///     <param name="row" type="Row">Row selecionada na grid</param>
        ///     <returns type="Item" />
        /// </signature>

        var data = self.currentDataTable.fnGetData(row);

        return data;

    }

    this.deleteItem = function (data) {

        var validate = $(document).triggerHandler(self.settings.table.name + 'ValidateDelete', data);
        if (validate != undefined) {
            if (validate == false) {
                return false;
            }
        }

        $(document).trigger(self.settings.table.name + 'BeforDelete', data);


        self.currentDataTable.fnDeleteRow(data.row);


        var itens = self.currentDataTable.fnGetData();

        self.jsItem.val(JSON.stringify(itens));


        $(document).trigger(self.settings.table.name + 'AfterDelete', true);

    }

    this.addItem = function (data) {

        var validate = $(document).triggerHandler(self.settings.table.name + 'ValidateInsert', data);

        if (!validate && validate != undefined) {
            return false;
        }

        var item = $(document).triggerHandler(self.settings.table.name + 'BeforInsert', data);

        item = item == undefined ? data : item;
        self.currentDataTable.fnAddData(item);

        var itens = self.currentDataTable.fnGetData();

        self.jsItem.val(JSON.stringify(itens));

        $(document).triggerHandler(self.settings.table.name + 'AfterInsert', data);
    };

    this.addItens = function (data) {

        self.currentDataTable.fnAddData(data);

        var itens = self.currentDataTable.fnGetData();

        self.jsItem.val(JSON.stringify(itens));
    };

    this.clear = function () {

        $(document).trigger(self.settings.table.name + 'BeforClear', true);

        self.currentDataTable.fnClearTable();

        self.jsItem.val("");

        $(document).trigger(self.settings.table.name + 'AfterClear', true);
    };

    this.editItem = function (data) {

        var validate = $(document).triggerHandler(self.settings.table.name + 'ValidateEdit', data);
        if (!validate) {
            return false;
        }
        $(document).trigger(self.settings.table.name + 'BeforEdit', data);

        self.currentDataTable.fnUpdate(data, self.dataSelected.row);

        var itens = self.currentDataTable.fnGetData();

        self.jsItem.val(JSON.stringify(itens));

        $(document).trigger(self.settings.table.name + 'AfterEdit', true);

        self.isEdit = false;
    };

    this.itens = function () {

        return self.currentDataTable.fnGetData();
    };


    this.count = function (key, value) {
        var count = 0;
        var itens = self.currentDataTable.fnGetData();
        var ikey = key.split('.');
        for (var i = 0; i < itens.length; i++) {
            var obj = itens[i];
            if (obj[ikey[0]] == value || (obj[ikey[0]] != null && ikey.length > 1)) {
                if (ikey.length > 1) {
                    obj = obj[ikey[0]];
                    for (var k = 1; k < ikey.length; k++) {
                        if (obj[ikey[k]] == value && k == ikey.length - 1) {
                            count++;
                        } else if (k < ikey.length - 1 && obj[ikey[k]] != null) {
                            obj = obj[ikey[k]];
                        }
                    }
                } else {
                    count++;
                }
            }
        }
        return count;
    };

    this.exists = function (key, value) {
        var itens = self.currentDataTable.fnGetData();
        var ikey = key.split('.');
        for (var i = 0; i < itens.length; i++) {
            var obj = itens[i];
            if (obj[ikey[0]] == value || (obj[ikey[0]] != null && ikey.length > 1)) {
                if (ikey.length > 1) {
                    obj = obj[ikey[0]];
                    for (var k = 1; k < ikey.length; k++) {
                        if (obj[ikey[k]] == value && k == ikey.length - 1) {
                            return true;
                        } else if (k < ikey.length - 1 && obj[ikey[k]] != null) {
                            obj = obj[ikey[k]];
                        }
                    }
                } else {
                    return true;
                }
            }
        }
        return false;
    };


    this.getTotal = function (key) {
        var total = 0;
        var itens = self.currentDataTable.fnGetData();

        for (var i = 0; i < itens.length; i++) {
            var obj = itens[i];
            total += obj[key];
        }

        return total;
    };


    var defaults = {
        rootClass: 'table table-condensed table-bordered table-striped table-hover',
        btnRemove: '<a style="width: 29px;margin-right: 2px;" class="btn btn-danger btn-sm" href="#" data-event="remove" title="Remover registro"><i class="fa fa-trash"></i></a>',
        btnEdit: '<a style="margin-right: 1px;" class="btn btn-info btn-edit btn-sm" href="#" data-event="edit" title="Selecionar registro"><i class="fa fa-edit"></i> </a>',
        btnCheckEmpty: '<a style="width: 30px;margin-right: 2px;" class="btn btn-default btn-sm" href="#" data-event="select" title="Selecionar registro"><i class="fa fa-square-o"></i> </a>',
        btnCheck: '<a style="width: 32px;margin-right: 2px;" class="btn btn-default btn-sm" href="#" data-event="select" title="{0}"><i class="fa fa-check-square-o"></i> </a>',
    };

    init();
}