(function () {

    'use strict';

    var whenConfig = ['$urlRouterProvider', function ($urlRouterProvider) {
        $urlRouterProvider
        .otherwise('/');
    }];

    angular.module('app')
            //.config(function ($breadcrumbProvider) {
            //    $breadcrumbProvider.setOptions({
            //        prefixStateName: 'index'
            //    });
            //})
            .config(whenConfig)
            .config(function ($stateProvider) {
                $stateProvider
                    .state('index', {
                        url: "/"
                        //templateUrl: "selection.html",
                        //ncyBreadcrumb: {
                        //    label: 'Select'
                        //}
                    })
                .state('productViewer', {
                    url: "/products",
                    views: {
                        "viewProductList": {
                            controller: productController,
                            templateUrl: "../app/dashboard/templates/products.html"
                        }
                    }
                    //reloadOnSearch: false,
                    //ncyBreadcrumb: {
                    //    label: "{{ makeModelYear }}",
                    //    parent: 'index'
                    //}
                })
                //.state('master.trim', {
                //    url: "/:trim",
                //    views: {
                //        //"viewSelection": {
                //        //    templateUrl: "selection.html"
                //        //},
                //        //"viewMaster": {
                //        //    templateUrl: "master.html"
                //        //},
                //        "viewRadioSummaryDetail": {
                //            controller: function ($scope, $rootScope, $state, $stateParams) {
                //                $rootScope.trim = $stateParams.trim;
                //                $rootScope.$state = $state;
                //                $rootScope.goto = function (e) {
                //                    var stateName = 'master.trim.' + e.currentTarget.innerText.trim().toLowerCase();
                //                    $state.go(stateName);
                //                }

                //                $(document).on('checked', '[name=RadioSummaryDetail]', $rootScope.goto);
                //            },
                //            templateUrl: "radiosummarydetail.html"
                //        },
                //        "viewSummary": {
                //            templateUrl: "summary.html"
                //        },
                //        "viewDetail": {
                //            templateUrl: "detail.html"
                //        }
                //    },
                //    reloadOnSearch: false,
                //    ncyBreadcrumb: {
                //        label: "{{ trim }}"
                //    }
                //})
            });
})();
