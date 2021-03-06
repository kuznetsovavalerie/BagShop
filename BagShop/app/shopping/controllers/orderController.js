﻿(function () {
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
        $scope.loading = false;

        $controller('baseController', { $scope: $scope });
        $scope.url = "/Home/Confirm";

        $scope.init = function (data) {
            $scope.bindData(data);

            $scope.selectedColour = $.grep($scope.Product.Colours, function (e) {
                return e.ID == $scope.SelectedColourId;
            })[0];

            $scope.Quantity = 1;
        }

        $scope.selectColour = function (colour) {
            $scope.selectedColour = colour;
            $scope.SelectedColourId = colour.ID;
        }

        $scope.submit = function () {
            if ($scope.loading) {
                return;
            }

            $scope.loading = true;

            var model = $scope.resolveData(['FirstName',
                'LastName',
                'PhoneNumber',
                'Address',
                'SelectedColourId',
                'Product',
                'Quantity']);

            $.ajax({
                method: 'POST',
                url: $scope.url,
                data: JSON.stringify({ model: model }),
                dataType: "json",
                contentType: 'application/json'
            }).done(function (data) {
                if (data.Success) {
                    $('#confirmation-modal').modal();
                }

                $scope.loading = false;
            });
        }
    }
})();
