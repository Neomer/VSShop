(function ($) {
    $.fn.Tree = function (options) {
        var settings = $.extend({
            'ajaxUrl': null
        }, options);

        var rootElement = null;

        return this.each(function () {
            rootElement = document.createElement('ul');
        });
    };

})(jQuery);