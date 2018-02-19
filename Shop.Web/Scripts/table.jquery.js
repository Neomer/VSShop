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
                    type: "str"
                }
            ],
            data: [[1, "dfdf"], [2, "dfdfdfdf"]],
            identity: [0, 1],
            onRowSelect: null
        }, options);

        var instance = this;
        var rootElement = $(this);

        function _rowClicked(id) {
            if (typeof settings.onRowSelect == 'function') { 
                settings.onRowSelect.call(this, this, id);
            }
        }

        return this.each(function () {
            rootElement.addClass("shop-table").addClass("hoverable");
            rootElement.html('');
            var tHead = document.createElement('thead');
            for (var i = 0; i < settings.model.length; i++) {
                var th = document.createElement('th');
                th.innerHTML = settings.model[i].name;
                tHead.appendChild(th);
            }
            rootElement.append(tHead);
            var tBody = document.createElement('tbody');
            for (var r = 0; r < settings.data.length; r++) {
                var tr = document.createElement('tr');
                $(tr).attr("row_id", settings.identity[r]);
                for (var c = 0; c < settings.model.length; c++) {
                    var td = document.createElement('td');
                    td.innerHTML = settings.data[r][c];

                    $(td).click(function () {
                        _rowClicked($(this).parent().attr("row_id"));
                    });
                    tr.appendChild(td);
                }
                tBody.appendChild(tr);
            }
            rootElement.append(tBody);
        });
    };

})(jQuery);