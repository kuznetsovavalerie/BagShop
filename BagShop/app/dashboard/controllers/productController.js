
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

        $scope.getDetails = function (product) {
            $http({
                method: 'get',
                url: '../api/Shopping/GetProductDetails',
                data: { id: product.ID }
            }).then(function (data) {
                console.log(data);

                $scope.model = data;
            });
        }

        $scope.saveDetails = function () {
            $http({
                method: 'get',
                url: '../api/Shopping/SaveProductDetails',
                data: { model: $scope.model }
            }).then(function (data) {
                console.log(data);
            });
        }

        $scope.removeImg = function (img, parent) {
            console.log(img, parent);
        }

        $scope.init();
    }
