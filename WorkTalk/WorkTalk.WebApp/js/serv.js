var serv = angular.module('appServ', []);

serv.factory('wsServ', ['$rootScope', function wsServ ($rootScope) {
  var uri = 'ws://' + window.location.hostname + '/api/Chat' + '?username=testUser';
  var socket = new WebSocket(uri);
  socket.self = socket;
  $rootScope.localStorage = {};
  $rootScope.localStorage.chatStack = [];

  socket.onopen = function () {
    if(socket !== undefined) {
      $rootScope.localStorage.isConnected = true;
    } else {
      $rootScope.localStorage.isConnected = false;
    };
    console.log($rootScope.localStorage.isConnected);
  };

  socket.onmessage = function (event, $rootScope) {
    var inMessage = event.data;
    $rootScope.localStorage.chatStack.push(inMessage);
    return inMessage;
  };

  return socket;
}]);