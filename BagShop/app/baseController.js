(function () {
    'use strict';

    angular
        .module('app')
        .controller('baseController', baseController);

    baseController.$inject = [
                            '$scope'];

    function baseController($scope) {
        $scope.bindData = function(data) {
            for (var property in data) {
                if (data.hasOwnProperty(property)) {
                    $scope[property] = data[property];
                }
            }
        }

        $scope.resolveData = function (names) {
            var obj = {};

            names.forEach(function (property) {
                if ($scope.hasOwnProperty(property)) {
                    obj[property] = $scope[property];
                }
            });

            return obj;
        }
    }
})();
