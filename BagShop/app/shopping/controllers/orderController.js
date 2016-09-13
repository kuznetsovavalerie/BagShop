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
        $scope.url = "/Home/Confirm";

        $scope.init = function (data) {
            $scope.bindData(data);

            $scope.selectedColour = $.grep($scope.Product.Colours, function (e) {
                return e.ID == $scope.SelectedColourId;
            })[0];
        }

        $scope.selectColour = function (colour) {
            $scope.selectedColour = colour;
            $scope.SelectedColourId = colour.ID;
        }

        $scope.submit = function () {
            var model = $scope.resolveData(['FirstName', 'LastName', 'PhoneNumber', 'Address', 'SelectedColourId']);
            console.log(model);

            $.ajax({
                method: 'POST',
                url: $scope.url,
                data: JSON.stringify({ model: model }),
                dataType: "json",
                contentType: 'application/json'
            }).done(function (data) {
                console.log(data);
            });
        }
    }
})();
