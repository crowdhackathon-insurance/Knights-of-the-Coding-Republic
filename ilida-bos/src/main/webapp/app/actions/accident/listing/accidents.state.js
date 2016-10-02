(function() {
    'use strict';

    angular
        .module('hlydaBosApp')
        .config(stateConfig);

    stateConfig.$inject = ['$stateProvider', 'Enums'];

    function stateConfig($stateProvider, Enums) {
        $stateProvider.state('accidents', {
            parent: 'actions',
            url: '/accidents',
            data: {
                authorities: ['ROLE_ADMIN', 'ROLE_USER'],
                pageTitle: 'Accidents Tracking'
            },
            views: {
                'content@': {
                    templateUrl: 'app/actions/accident/listing/accidents.html',
                    controller: 'AccidentListController',
                    controllerAs: 'vm'
                }
            },
            resolve: {
                accidents: ['AccidentsService',
                    function(AccidentsService) {
                        return [];
                        // return AccidentsService.finalAllByStatus({statusId: Enums.AccidentStatus.inProcces.id});
                    }
                ]
            }
        });
    }
})();
