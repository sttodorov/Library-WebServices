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

    require(['sammy', 'jquery', 'libraryController'], function (Sammy, $, LibraryController) {

        //var resourceURL = 'http://melonlibrary.apphb.com/';
        var resourceURL = 'http://localhost:51236/';
        var libraryApp = new LibraryController('#main-container', resourceURL);
        'http://localhost:51236/'


        //  libraryApp.addEvents();

        var app = Sammy('#main-container', function () {

            this.get('#/', function () {
                $('#main-container').load('templates/Home.html');
            });

            this.get('#/authors', function () {
                $('#main-container').load('templates/Authors.html');
                // this.partial('..//templates//Authors.html');
                // libraryApp.loadAuthors();
            });

            this.get('#/books', function () {
                $('#main-container').load('templates/Books.html');
                //  libraryApp.loadBooks();
            });
            this.get('#/searchAuthor', function () {
                $('#main-container').load('templates/SearchAuthor.html');
                //  libraryApp.loadFoundedAuthors();
            });
            this.get('#/searchBook', function () {
                $('#main-container').load('templates/SearchBook.html');
                // libraryApp.loadFoundedBooks();
            });

        });

        app.run('#/');

    });
}());
