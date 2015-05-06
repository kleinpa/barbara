/*global angular, d3, window*/
(function () {
  'use strict';
  angular.module('main', ['ngRoute'])
    .controller('CtrlMain', function ($scope, $http, $interval) {
    })
    .config(['$routeProvider', '$locationProvider',
      function($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider.
          when('/', {
            templateUrl: '/partials/home.html',
            controller: 'CtrlOverview'
          }).
          when('/configuration/', {
            templateUrl: '/partials/configuration.html',
          }).
          when('/menu/', {
            templateUrl: '/partials/menu.html',
          }).
          when('/users/', {
            templateUrl: '/partials/users.html',
          }).
          otherwise({
            redirectTo: '/'
          });
      }]);
}());
