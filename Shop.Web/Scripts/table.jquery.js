(function ($) {
    $.fn.Table = function (options) {
        var settings = $.extend({
            model: [
                {
                    name: "#",
                    type: "number"
                },
                {
                    name: "Name",
                    type: "str",
                    align: "right"
                }
            ],
            rowsPerPage: 15,
            data: [[1, "dfdf"], [2, "dfdfdfdf"]],
            identity: [0, 1],
            onRowSelect: null
        }, options);

        var instance = this;
        var rootElement = $(this);
        var divNavigation = null;

        function _rowClicked(id) {
            if (typeof settings.onRowSelect == 'function') { 
                settings.onRowSelect.call(this, this, id);
            }
        }

        this.displayPage = function (page) {
            if (page >= settings.data.length / settings.rowsPerPage) return;
            rootElement.find(".shop-table > tbody").remove();

            var dlTable = rootElement.find('table');
            var tBody = document.createElement('tbody');
            for (var r = settings.rowsPerPage * page; r < Math.min(settings.data.length, settings.rowsPerPage * (page + 1)) ; r++) {
                var tr = document.createElement('tr');
                $(tr).attr("row_id", settings.identity[r]);
                for (var c = 0; c < settings.model.length; c++) {
                    var td = document.createElement('td');
                    if ((settings.model[c].align != null) && (settings.model[c].align !== 'undefined')) {
                        $(td).addClass(settings.model[c].align);
                    }
                    td.innerHTML = settings.data[r][c];

                    $(td).click(function () {
                        _rowClicked($(this).parent().attr("row_id"));
                    });
                    tr.appendChild(td);
                }
                tBody.appendChild(tr);
            }
            dlTable.append(tBody);

            divNavigation.innerHTML = '';
            if (settings.data.length > settings.rowsPerPage) {
                for (var p = 0; p < settings.data.length / settings.rowsPerPage; p++) {
                    var divPage = document.createElement('span');
                    $(divPage).attr('page', p);
                    if (p == page)
                    {
                        $(divPage).addClass('selected');
                    }
                    $(divPage).click(function () {
                        instance.displayPage($(this).attr('page'));
                    });
                    divPage.innerHTML = p + 1;
                    divNavigation.appendChild(divPage);
                }
            }


        }

        return this.each(function () {
            var dlTable = document.createElement('table');
            $(dlTable).addClass("shop-table").addClass("hoverable");
            rootElement.html('');
            var tHead = document.createElement('thead');
            for (var i = 0; i < settings.model.length; i++) {
                var th = document.createElement('th');
                th.innerHTML = settings.model[i].name;
                tHead.appendChild(th);
            }
            dlTable.appendChild(tHead);
            $(rootElement).append(dlTable);

            divNavigation = document.createElement('div');
            $(divNavigation).addClass('shop-table-nav');
            $(rootElement).append(divNavigation);

            instance.displayPage(0);
        });
    };

})(jQuery);