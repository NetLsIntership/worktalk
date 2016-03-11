var serv = angular.module('wsServ', []);

serv.factory('wsServ', ['$rootScope', function ($rootScope) {
  var uri = 'ws://' + window.location.hostname + window.location.pathname.replace('default.html', 'api/Chat');
  var socket = new WebSocket("ws://localhost");

  socket.onopen = function () {
    if(socket !== undefined) {
      $rootScope.isConnected = true;
    };
  };

  socket.onmessage = function (event, $rootScope) {
    var inMessage = event.data;
    $rootScope.chatStack.apply(inMessage);
    return inMessage;
  };

  return socket;
}])