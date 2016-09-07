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
        $scope.state = $state;

        function bindData(scope, data) {
            for (var property in data) {
                if (data.hasOwnProperty(property)) {
                    scope[property] = data[property];
                }
            }
        }

        $scope.init = function (data) {
            bindData($scope, data);

            $scope.selectedColour = $scope.colours[0];
        }

        $scope.selectColour = function (colour) {
            $scope.selectedColour = colour;
        }

        $scope.buyLink = function () {
            return $scope.url + "?productId=${$scope.ID}&colourId=${$scope.selectedColour.ID}";            
        }
    }
})();
