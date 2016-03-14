var appCtrl = angular.module('appCtrl', []);

appCtrl.controller('userListCtrl', ['$scope', function ($scope) {
  $scope.users = [
    {
      name: 'testUser1',
      status: 'online'
    }
  ];
  $scope.test = "test";
}]);

appCtrl.controller('chatCtrl', ['$scope', '$rootScope', 'socketService',
 function ($scope, $rootScope, socketService) {
  
  $scope.chatStack = [];
  var s = socketService;
  s.open();

  s.listener(function(e) {
    console.log(e.data, ' message event');
    $scope.$apply($scope.chatStack.push(JSON.parse(e.data)));
    console.log($scope.chatStack);
  });

  $scope.isMyPost = function(user) {
    var style = "";
    if ($rootScope.user === user) {
      style = "message-item-my pull-right";
    } else {
      style = "message-item pull-left"; 
    };
    return style;
  };

  $scope.sendText = function () {
    if ($scope.message === "") return;
    var msg = {
      type: 'message',
      id:   1,
      date: Date.now()
    };
    msg.text = $scope.message;
    msg.user = $rootScope.user;
    socketService.send(JSON.stringify(msg));
    $scope.message = "";
  };
}]);