(function() {
    'use strict';

    angular
        .module('hlydaBosApp')
        .controller('AccidentσController', AccidentσController);

    AccidentσController.$inject = ['$scope', '$window', 'AlertService', 'AccidentsService', 'AccidentsListener', /*'Enums',*/ 'accidents'];

    function AccidentσController ($scope, $window, AlertService, AccidentsService, AccidentsListener, /*Enums,*/ accidents) {
        var vm = this;

        vm.accidents = accidents;

        AccidentsListener.receive().then(null, null, function (data) {
            vm.accidents.splice(0, 0, data);
        });

        /**
         * Approves the accident as valid.
         */
        var approveAccident = function (accident) {
            accident.status = 2/*Enums.AccidentStatus.assignToExpert.id*/;
            AccidentsService.update(accident, updateSuccess, updateFailure);
        };

        var updateSuccess = function (data, headers) {
            AlertService.success('Accident approved');
            vm.removeAccident(data.id); //TODO CHeck correct property
        };

        var updateFailure = function (error) {
            AlertService.error(error.data.message);
        };

        /**
         * Views the matching accident photos
         */
        var viewPhoto = function (accident) {
            $window.open(accident.photo[0], '_blank');
        };

        /**
         * Removes the accident from the list.
         */
        var removeAccident = function (accidentId) {
            vm.accidents.forEach(function (obj, index, array) {
                if (accidentId == obj.id)
                    array.splice(index, 1);
            });
        };
    }
})();
