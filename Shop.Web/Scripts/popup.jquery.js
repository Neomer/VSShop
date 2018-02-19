﻿(function ($) {
    $.fn.Popup = function (options) {
        var settings = $.extend({
            'caption': '',
            'content': ''
        }, options);

        var instance = this;
        var rootElement = $(this);
        var titleElement = rootElement.find('.popUp-header > span');
        var contentElement = rootElement.find('.popUp-body');

        this.open = function (title, content) {
            titleElement.html(title);
            contentElement.html(content);
            var w = $(document).width() * 0.5 - rootElement.width() * 0.5;
            var h = $(document).height() * 0.5 - rootElement.height() * 0.5;
            rootElement.css({
                left: w + 'px',
                top: h + 'px'
            });
            $(".popUp-blockscreen").css({
                width: $(document).width(),
                height: $(document).height()
            }).show();
            rootElement.show();
        };

        this.close = function () {
            $(".popUp-blockscreen").hide();
            rootElement.hide();
        }

        return this.each(function () {
            rootElement.hide();
            $(".popUp-blockscreen").click(function () {
                instance.close();
            });
            rootElement
                .find(".popUp-header > .popUp-close > img").click(function () {
                console.log('click');
                instance.close();
            });
        });
    };

})(jQuery);