(function () {
    'use strict';

    angular
        .module('app')
        .controller('productController', productController);

    productController.$inject = [
                            '$scope',
                            '$attrs',
                            '$q',
                            '$controller',
                            '$state'];

    function productController($scope,
                            $attrs,
                            $q,
                            $controller,
                            $state) {

        $scope.init = function () {

        }
    }
})();
