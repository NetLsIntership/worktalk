'use strict'
var app = angular.module('appCtrl', []);

app.controller('userListCtrl', ['$scope', function ($scope) {
  $scope.users = [
    {
      name: 'testUser1',
      status: 'online'
    },
    {
      name: 'testUser2',
      status: 'away'
    },
    {
      name: 'testUser3',
      status: 'offline'
    },
    {
      name: 'testUser1',
      status: 'online'
    },
    {
      name: 'testUser2',
      status: 'away'
    },
    {
      name: 'testUser1',
      status: 'online'
    },
    {
      name: 'testUser2',
      status: 'away'
    }
  ];
  $scope.test = "test";
}]);

app.controller('chatCtrl', ['$scope', '$rootScope', 'wsServ',
 function ($scope, $rootScope) {

  $scope.isMyPost = function(user) {
    var style = "";
    if ("testUser2" === user) {
      style = "message-item-my pull-right";
    } else {
      style = "message-item pull-left";
    };
    return style;
  };

  $scope.message = "";
  $scope.sendMessage = function() {
    var inMessage = this.message;
    console.log(inMessage);
    if (inMessage !== "") {
      wsServ.getSocket().send(inMessage);
    };
    this.message = "";
  };
  $scope.chatStack = $rootScope.localStorage.chatStack;
  $scope.status = $rootScope.localStorage.isConnested;

}]);