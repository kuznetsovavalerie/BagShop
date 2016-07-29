(function () {
    'use strict';

    angular
        .module('app')
        .controller('dashboardController', dashboardController);

    dashboardController.$inject = [
                            '$scope',
                            '$attrs',
                            '$q',
                            '$controller',
                            '$state'];

    function dashboardController($scope,
                            $attrs,
                            $q,
                            $controller,
                            $state) {
        $scope.state = $state;

        $scope.init = function () {

        }
    }
})();
