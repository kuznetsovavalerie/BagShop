(function () {
    'use strict';

    angular
        .module('app')
        .controller('shoppingController', shoppingController);

    shoppingController.$inject = [
                            '$scope',
                            '$attrs',
                            '$q',
                            '$controller',
                            '$state'];

    function shoppingController($scope,
                            $attrs,
                            $q,
                            $controller,
                            $state) {
        $scope.state = $state;

        $scope.init = function () {

        }
    }
})();
