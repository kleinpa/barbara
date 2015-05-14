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
    .factory('model', function(socket) {
      function buildModel(name){
        return {
          index: function(fn){
            socket.emit('index-'+name.plural.toLowerCase(), null, function(data){
              fn(data);
            });
          },
          create: function(data, fn){
            socket.emit('create-'+name.singular.toLowerCase(), data, function(data){
              fn(data);
            });
          },
          show: function(data, fn){
            socket.emit('show-'+name.singular.toLowerCase(), data, function(data){
              fn(data);
            });
          },
          update: function(data, fn){
            socket.emit('update-'+name.singular.toLowerCase(), data, function(data){
              fn(data);
            });
          },
          destroy: function(data, fn){
            socket.emit('destroy-'+name.singular.toLowerCase(), data, function(data){
              fn(data);
            });
          }
        }
      }
      return {
        users: buildModel({singular: 'user', plural: 'users'}),
        recipes: buildModel({singular: 'recipe', plural: 'recipes'}),
        channels: buildModel({singular: 'channel', plural: 'channels'})
      }

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
    .controller('CtrlMenu', function($scope, model) {
      $scope.volume = 100;
      model.recipes.index(function(data){
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
    .controller('CtrlTest', function($scope, $http, $window, socket, model) {
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
      model.channels.index(function(data) {
	$scope.channels = data;
      });
    })
    .controller('CtrlUsers', function($scope, $http, $window, socket, model) {
      // socket.emit('get-users', null, function(data){
      //   $scope.users = data;
      // });
      model.users.index(function(data) {
	$scope.users = data;
      });
      $scope.createUser = function() {
      };
    });
}());
