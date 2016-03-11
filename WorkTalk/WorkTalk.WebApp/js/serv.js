var serv = angular.module('appServ', []);

serv.factory('wsServ', [function wsServ () {
  var uri = 'ws://' + window.location.hostname + '/api/Chat' + '?username=testUser';
  var socket = new WebSocket(uri);
  socket.self = socket;
  socket.localStorage = {};
  socket.localStorage.chatStack = [];

  socket.onopen = function () {
    if(socket !== undefined) {
      socket.localStorage.isConnected = true;
    } else {
      socket.localStorage.isConnected = false;
    };
  };

  socket.onmessage = function (event) {
    var inMessage = event.data;
    socket.localStorage.chatStack.push(inMessage);
    return inMessage;
  };

  return socket;
}]);