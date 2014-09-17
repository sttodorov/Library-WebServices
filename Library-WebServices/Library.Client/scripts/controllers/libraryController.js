define(['ui', 'jquery', 'requester'], function (UI, $, requester) {
    'use strict';

    var libraryController = (function () {
        function libraryController(selector, resourceURL) {
            this.selector = selector;
            this.resourceURL = resourceURL;
            this.ui = new UI(selector);
        }

        // Functionality of the app:

        // getAllAuthors

        //getAllBooks

        //FindBooksByAuthorName

        //FindBookByTitleName

        //FindBooksInGenre

        //TakeBook (change status taken/untaken)

        //AddAuthor

        //AddBook

        //DeleteAuthorByName

        //DeleteBookByTitle

        return libraryController;

    }());

    return libraryController;
});