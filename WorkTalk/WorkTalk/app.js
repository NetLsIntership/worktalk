var lsChat = angular.module('lsChat', 
  ['auth', 
   'appCtrl', 
   'appService']);

lsChat.run(['$rootScope', function($rootScope) {
  $rootScope.user = prompt('Please enter user name');
}]);
