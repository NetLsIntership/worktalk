var appService = angular.module('appService', []);

/*appService.factory('wsService', ['$rootScope', function ($rootScope) {
  var obj = {
    chatStack: [],
  };

  $rootScope.ws.onopen = function() {
    console.log("Соединение установлено.");
  };

  $rootScope.ws.onclose = function(event) {
    if (event.wasClean) {
      console.log('Соединение закрыто чисто');
    } else {
      console.log('Обрыв соединения'); // например, "убит" процесс сервера
    }
    console.log('Код: ' + event.code + ' причина: ' + event.reason);
  };

  $rootScope.ws.onmessage = function(event) {
    console.log("Получены данные " + event.data);

  //  obj.chatStack.push(JSON.parse(event.data));
  };

  $rootScope.ws.onerror = function(error) {
    console.log("Ошибка " + error.message);
  };

  //return obj;
return {
  chatStack: obj.chatStack,
  message: $rootScope.ws.onmessage
};

}]);*/

appService.service('socketService', function() {
    var socket;
    var connectionString = 'ws://localhost:5858/';
  return {
    open: function open (conn) {
      console.log('from service');
      socket = new WebSocket(conn || connectionString);
      console.log(event);
      return socket;
    },
    connected: function connected () {
      socket.onopen = function() {
        console.log("Соединение установлено.");
      };
    },
    listener: function listener (callback) {
      if(typeof(socket) != 'undefined') {
        socket.onmessage = function(e) {
            callback(e);
        };
      } else {
        this.open();
      }
      return callback;
    },
    send: function send (message) {
      socket.send(message);
    },
    closed: function closed (callback) {
      socket.onclose = function(e) {
        if (event.wasClean) {
          console.log('Соединение закрыто чисто');
        } else {
          console.log('Обрыв соединения'); // например, "убит" процесс сервера
        }
        console.log('Код: ' + event.code + ' причина: ' + event.reason);
        callback(e);
        };
    },
    error: function error () {
      socket.onerror = function () {

      };
    }
  }
});








