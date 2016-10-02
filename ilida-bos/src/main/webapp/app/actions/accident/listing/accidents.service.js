(function () {
    'use strict';

    angular
        .module('hlydaBosApp')
        .factory('AccidentsService', AccidentsService);

    AccidentsService.$inject = ['$resource'];

    function AccidentsService($resource) {
        return $resource('api/accident/:id', {}, {
            'findOne': {
                method: 'GET', isArray: false,
                transformResponse: function (data) {
                    return angular.fromJson(data);
                }
            },
            'findAll': {method: 'GET', isArray: true},
            'update': {
                method: 'PUT',
                url: 'api/accident',
                transformResponse: function (data) {
                    return angular.fromJson(data);
                }
            },
            'approveIncident': {
                method: 'POST',
                params: {accidentId: '@accidentId'},
                url: 'api/accident/approve/:accidentId'
            },
            'finalAllByStatus': {
                method: 'GET', isArray: true,
                url: 'api/accident/status/:statusId'
            }
        });
    }
})();
