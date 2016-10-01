(function() {
    'use strict';

    angular
        .module('hlydaBosApp')
        .config(stateConfig);

    stateConfig.$inject = ['$stateProvider'/*, 'Enums'*/];

    function stateConfig($stateProvider/*, Enums*/) {
        $stateProvider.state('accidents', {
            parent: 'admin',
            url: '/accidents',
            data: {
                authorities: ['ROLE_ADMIN', 'ROLE_USER'],
                pageTitle: 'Accidents Tracking'
            },
            views: {
                'content@': {
                    templateUrl: 'app/components/accident/listing/accidents.html',
                    controller: 'AccidentListController',
                    controllerAs: 'vm'
                }
            },
            resolve: {
                accidents: ['AccidentsService',
                    function(AccidentsService) {
                        return AccidentsService.finalAllByStatus({statusId: 2/*Enums.AccidentStatus.inProcces.id*/});
                    }
                ]
            }
        });
    }
})();
