(function () {
    'use strict';
    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1',
            mustache: 'libs/mustache',
            q: 'libs/q',
            sammy: 'libs/sammy',
            requester: 'modules/requester',
            libraryController: 'controllers/libraryController',
            rsvp: 'libs/RSVP',
            ui: 'ui/ui'
        },
    });

    require(['sammy', 'jquery', 'libraryController'], function (Sammy, $, libraryController) {

        var resourceURL = 'http://melonlibrary.apphb.com/';
        var libraryApp = new libraryController('#main-content', resourceURL);

        libraryApp.addEvents();

        var app = Sammy('#main-content', function () {

            this.get('#/authors', function () {
                // libraryApp.loadAuthors();
            });

            this.get('#/books', function () {
                //  libraryApp.loadBooks();
            });
            this.get('#/searchAuthor', function () {
                //  libraryApp.loadFoundedAuthors();
            });
            this.get('#/searchBook', function () {
                // libraryApp.loadFoundedBooks();
            });

        });

        $(function () {
            app.run('#/');
        });

    });
}());
