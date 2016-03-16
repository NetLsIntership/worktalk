var lsChat = angular.module('lsChat', 
  ['auth', 
   'appCtrl', 
   'appService',
   'luegg.directives',
   'ui.router']);

lsChat.run(['$rootScope', function($rootScope) {
  $rootScope.user = prompt('Please enter user name');
}]);
