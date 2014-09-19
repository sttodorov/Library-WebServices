/// <reference path="../libs/jquery-2.1.1.js" />


define(['ui', 'jquery', 'requester'], function (UI, $, requester) {
    'use strict';

    var LibraryController;
    LibraryController = (function () {
        function LibraryController(selector, resourceURL) {
            this.selector = selector;
            this.resourceURL = resourceURL;
            this.ui = new UI(selector);
        }

        // Functionality of the app:

        function GetAllAuthors() {
            return requester.getJSON('http://localhost:51236/api/Authors/All');
        }

          var allAuthors = GetAllAuthors();


        // try if server seponds
       // console.log(1);
        //var asd = $.ajax({
        //    url: 'http://localhost:51236/api/Authors/All',
        //    type: 'GET',
        //    contentType: 'application/json',
        //    success: function (data) {
        //        var dataParsed = JSON.parse(data);

        //        for (var i = 0; i < length; i++) {
        //            if (dataParsed[i].name === "Gosho") {
        //                console.log(dataParsed[i]);
        //            }
        //        }
        //    },
        //    error: function (jqXHR, textStatus, errorThrown) {
        //        console.log(jqXHR);
        //        console.log(textStatus);
        //        console.log(errorThrown);
        //    }
        //});
       // console.log(2);


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


        return LibraryController;

    }());

    return LibraryController;
});