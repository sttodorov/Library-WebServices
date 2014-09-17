//Here templates will be loaded

define(['jquery', 'mustache'], function ($, Mustache) {
    'use strict';
    var UI;
    UI = (function () {
        function UI(selector) {
            this.selector = selector;
        }

        //    Load templates when needed

        return UI;
    }());
    return UI;
});