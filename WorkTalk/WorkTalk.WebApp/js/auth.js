var auth = angular.module('auth', []);

auth.factory('auth', ['$http', '$window', function ($http, $window) {
  var auth = {}

  auth.saveToken = function (token) {
    $window.localStorage['ls-chat'] = token;
  };

  auth.getToken = function () {
    return $window.localStorage['ls-chat'];
  };

  auth.isLoggedIn = function () {
    var token = auth.getToken();

    if(token){
      var payload = JSON.parse($window.atob(token.split('.')[1]));

      return payload.exp > Date.now() / 1000;
    } else {
      return false;
    }
  };

  auth.currentUser = function () {
    if(auth.isLoggedIn()) {
      var token = auth.getToken();
      var payload = JSON.parse($window.atob(token.split('.'[1])));

      return payload.username;
    };
  };

  auth.register = function(user){
    return $http.post('/register', user).success(function(data) {
      auth.saveToken(data.token);
    });
  };

  auth.logIn = function (user) {
    return $http.post('/login', user).success(function(data) {
      auth.saveToken(data.token);
    });
  };

  auth.logOut = function () {
    $window.localStorage.removeItem('ls-chat');
  }

  return auth;
}]);

auth.controller('AuthCtrl', ['$scope', '$state', 'auth', 
  function($scope, $state, auth) {

    $scope.user = {};

    $scope.register = function () {
      auth.register($scope.user).error(function(error){
        $scope.error = error;
      }).then(function () {
        $state.go('/');
      });
    };

    $scope.logIn = function () {
      auth.logIn($scope.user).error(function (error) {
        $scope.error = error;
      }).then(function () {
        $state.go('home');
      });
    };

  }]);