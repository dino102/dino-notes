// This file contains AngularJS declarations and common functions.

// angularjs declaration
var page = angular.module('page', ['ngCookies']);

// http interceptor
page.factory('HttpInterceptor', ['$q', '$cookies', '$window', 'utilities', function ($q, $cookies, $window, utilities) {
    return {
        request: function (config) {
            jQuery("#loader").show(); // display loader

            config.headers = config.headers || {};
            config.headers.Authorization = utilities.stringFormat('Bearer {0}', $cookies.get('apitoken'));
            return config || $q.when(config);
        },
        requestError: function (config) {
            return config;
        },
        response: function (response) {
            // called upon successful response (status = 200)

            jQuery("#loader").hide(); // hide loader
            return response;
        },
        responseError: function (response) {
            if (response.status === 401) {
                // redirect to logout
                $window.location.href = utilities.stringFormat('{0}/login/logout?returnurl={1}', window.location.origin, window.location.pathname);
            } else {
                // TO DO: handle other HTTP error here
                //console.log(response.status);
            }
            return response;
        }
    }
}]);

// register interceptor
page.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('HttpInterceptor');
}]);