(function () {
    'use strict';

    angular
        .module('app')
        .controller('dashboardController', dashboardController);

    $stateProvider.state('products', {
        templateUrl: 'products.html',
        url: ''
    })

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
