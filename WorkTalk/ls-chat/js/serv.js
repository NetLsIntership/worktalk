var serv = angular.module('appServ', []);

serv.factory('ioServ', ['$rootScope', function ($rootScope) {
  

  return ;
}])

serv.factory('wsServ', ['$rootScope', function ($rootScope) {
  var socket = new WebSocket("ws://");

  socket.onOpen = function () {
    if(socket !== undefined) {
      $rootScope.isConnected = true;
    };
  };

  socket.on

  return socket;
}])