var serv = angular.module('wsServ', []);

serv.factory('wsServ', ['$rootScope', function ($rootScope) {
  var uri = 'ws://' + window.location.hostname + '/api/Chat' + '?username=testUser';
  var socket = new WebSocket(uri);
  var obj = {};
  $rootScope.localStorage = {};
  $rootScope.localStorage.chatStack = [];

  obj.getSocket = function () {
    return socket;
  }

  obj.onopen = function () {
    if(socket !== undefined) {
      $rootScope.localStorage.isConnected = true;
    } else {
      $rootScope.localStorage.isConnected = false;
    };
    console.log($rootScope.localStorage.isConnected);
  };

  obj.onmessage = function (event, $rootScope) {
    var inMessage = event.data;
    $rootScope.localStorage.chatStack.push(inMessage);
    return inMessage;
  };

  return obj;
}])