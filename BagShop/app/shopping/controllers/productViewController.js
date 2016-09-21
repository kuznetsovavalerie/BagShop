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
        $scope.url = "/Home/Buy"

        $scope.init = function (data) {
            $scope.bindData(data);

            $scope.selectColour($scope.Colours[0]);
        }

        $scope.selectColour = function (colour) {
            $scope.selectedColour = colour;

            if ($scope.selectedColour.Images.length < 1) {
                $scope.selectedColour.Images[0] = $scope.TitleImage;
            }
        }

        $scope.buyLink = function () {
            return $scope.url + "?productId=" + $scope.ID + "&colourId=" + $scope.selectedColour.ID;            
        }
    }
})();
