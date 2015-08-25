/*global angular, d3, window*/
(function() {
  'use strict';
  angular.module('main', ['ngRoute', 'ngTouchStartEnd'])
    .factory('socket', function($rootScope) {
      var socket = io.connect();
      return {
        on: function(eventName, callback) {
          socket.on(eventName, function() {
            var args = arguments;
            $rootScope.$apply(function() {
              callback.apply(socket, args);
            });
          });
        },
        emit: function(eventName, data, callback) {
          socket.emit(eventName, data, function() {
            var args = arguments;
            $rootScope.$apply(function() {
              if (callback) {
                callback.apply(socket, args);
              }
            });
          });
        }
      };
    })
    .controller('CtrlMain', function($scope, $http, $location, socket) {
      $scope.isActive = function(route) {
        return route === $location.path();
      };
      $scope.isDispensing = false;
      socket.on('dispensing', function() {
        $scope.isDispensing = true;
      });
      socket.on('done-dispensing', function() {
        $scope.isDispensing = false;
      });
    })
    .controller('CtrlMenu', function($scope, socket) {
      $scope.volume = 100;
      socket.emit('get-recipes', null, function(data){
        $scope.recipes = data;
      });
      $scope.order = function(recipe, volume){
        socket.emit('order', {recipe: recipe, volume: volume, user: null});
      }
    })
    .config(['$routeProvider', '$locationProvider',
      function($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider.
        //when('/', {
        //  templateUrl: '/partials/home.html'
        //}).
        //when('/configuration/', {
        //  templateUrl: '/partials/configuration.html'
        //}).
        when('/', {
          templateUrl: '/partials/menu.html',
          controller: 'CtrlMenu'
        }).
        when('/users/', {
          templateUrl: '/partials/users.html',
          controller: 'CtrlUsers'
        }).
        when('/test/', {
          templateUrl: '/partials/test.html',
          controller: 'CtrlTest'
        }).
        otherwise({
          redirectTo: '/'
        });
      }
    ])
    .controller('CtrlTest', function($scope, $http, $window, socket) {
      $scope.channels = [0, 1, 2, 3, 4];
      var channel_states = {};
      socket.on('init', function(data) {
        $scope.name = data.name;
        $scope.users = data.users;
      });
      $scope.set = function(channel, state, x) {
        if (channel_states[channel] != state) {
          socket.emit('test-set', {
            c: channel,
            s: state
          });
          channel_states[channel] = state;
        }
      };

      $scope.dispenseFor = function(channel, ms) {
        socket.emit('test-dispense', {
          c: channel,
          ms: ms
        });
	$scope.rand = 3000+Math.floor(Math.random() * 10000);
      };

      $scope.dispenseVol = function(channel, ml) {
        socket.emit('test-dispense-vol', {
          c: channel,
          ml: ml
        });
      };

      var keyDown = function(e) {
        var n = e.which - 49;
        if (n >= 0 && n < 5) {
          $scope.set(n, 1);
        }
      };
      var keyUp = function(e) {
        var n = e.which - 49;
        if (n >= 0 && n < 5) {
          $scope.set(n, 0);
        }
      };
      angular.element($window).on('keydown', keyDown);
      angular.element($window).on('keyup', keyUp);
      $scope.$on('$destroy', function() {
        angular.element($window).off('keyup', keyUp);
        angular.element($window).off('keydown', keyDown);
      });

      $scope.z = 4;
    })
    .controller('CtrlUsers', function($scope, $http, $window, socket) {
      socket.emit('get-users', null, function(data){
        $scope.users = data;
      });
    });
}());
