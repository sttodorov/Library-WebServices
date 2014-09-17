define(['jquery', 'q'], function ($, Q) {
    'use strict';
    var requester;
    requester = (function () {
        var getJSON = function getJSON(resourceURL) {

            var deferred = Q.defer();

            deferred.resolve(
                $.ajax({
                    url: resourceURL,
                    type: 'GET',
                    contentType: 'application/json',
                    //                    timeout: 5000,
                    success: function (data) {
                        deferred.resolve(data);
                    },
                    error: function (err) {
                        deferred.reject(err);
                    }
                })
            );

            return deferred.promise;
        };

        var postJSON = function postJSON(resourceURL, data) {
            var deferred = Q.defer();

            deferred.resolve(
                $.ajax({
                    url: resourceURL,
                    type: 'POST',
                    data: JSON.stringify(data),
                    contentType: 'application/json',
                    //                    timeout: 5000,
                    success: function (data) {
                        deferred.resolve(data);
                    },
                    error: function (err) {
                        deferred.reject(err);
                    }
                })
            );

            return deferred.promise;
        };


        //TODO : Make DELETE query

        //TODO : Check if works 
        var putJSON = function putJSON(resourceURL, data, sessionKey) {
            var deferred = Q.defer();

            deferred.resolve(
                $.ajax({
                    url: resourceURL,
                    type: 'PUT',
                    sessionKey: sessionKey,
                    data: JSON.stringify(data),
                    contentType: 'application/json',
                    //                    timeout: 5000,
                    success: function (data) {
                        deferred.resolve(data);
                    },
                    error: function (err) {
                        deferred.reject(err);
                    }
                })
            );

            return deferred.promise;
        };
        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON
            //delete
        };
    }());
    return requester;
});