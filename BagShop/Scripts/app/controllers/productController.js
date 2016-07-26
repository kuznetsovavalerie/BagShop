(function () {
    'use strict';

    angular
        .module('app')
        .controller('shopController', shopController);

    shopController.$inject = [
                            '$scope',
                            '$attrs',
                            '$q',
                            '$controller',
                            '$state'];

    var shopController = function ($scope) {
        //$scope.
        $scope.init = function (data) {
            console.log(data);
        }


    }
});