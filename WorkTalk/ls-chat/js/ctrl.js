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

app.controller('chatCtrl', ['$scope', '$rootScope',
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

  

  $scope.chatStack = [
    {
      user: "testUser1",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
    {
      user: "testUser2",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1 = 2",
    },
    {
      user: "testUser1",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
    {
      user: "testUser1",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
    {
      user: "testUser2",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
    {
      user: "testUser1",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
    {
      user: "testUser2",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1 = 2",
    },
    {
      user: "testUser1",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
    {
      user: "testUser1",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
    {
      user: "testUser2",
      message: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum maxime soluta a, accusamus incidunt quas cupiditate provident magnam asperiores, iste assumenda dolores id numquam porro dolorem. Sed nobis sequi distinctio. 1",
    },
  ];

}])