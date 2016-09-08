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
        $controller('baseController', { $scope: $scope });
        $scope.url = "../Buy"

        $scope.init = function (data) {
            $scope.bindData(data);

            $scope.selectedColour = $scope.Colours[0];
        }

        $scope.selectColour = function (colour) {
            $scope.selectedColour = colour;
        }

        $scope.buyLink = function () {
            return $scope.url + "?productId=" + $scope.ID + "&colourId=" + $scope.selectedColour.ID;            
        }
    }
})();
