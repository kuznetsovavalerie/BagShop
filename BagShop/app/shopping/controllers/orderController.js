(function () {
    'use strict';

    angular
        .module('app')
        .controller('orderController', orderController);

    orderController.$inject = [
                            '$scope',
                            '$attrs',
                            '$q',
                            '$controller',
                            '$state'];

    function orderController($scope,
                            $attrs,
                            $q,
                            $controller,
                            $state) {
        $controller('baseController', { $scope: $scope });
        $scope.url = "../Confirm"

        $scope.init = function (data) {
            $scope.bindData(data);
        }
    }
})();
