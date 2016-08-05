
    'use strict';

    angular
        .module('app')
        .controller('productController', productController);

    productController.$inject = [
                            '$scope',
                            '$http',
                            '$controller',
                            '$state'];

    function productController(
                            $scope,
                            $http,
                            $controller,
                            $state) {

        $scope.init = function () {
            $http({
                method: 'get',
                url: '../api/Shopping/GetProducts'
            }).then(function (data) { console.log(data); });

            $scope.products;
        }

        $scope.init();
    }
