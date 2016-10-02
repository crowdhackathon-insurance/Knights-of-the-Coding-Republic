(function () {
    'use strict';

    angular
        .module('hlydaBosApp')
        .controller('AccidentListController', AccidentListController);

    AccidentListController.$inject = ['$scope', '$window', 'DateUtils', 'AlertService', 'AccidentsService', 'AccidentsListener', 'Enums', 'accidents'];

    function AccidentListController($scope, $window, DateUtils, AlertService, AccidentsService, AccidentsListener, Enums, accidents) {
        var vm = this;

        vm.approveAccident = approveAccident;
        vm.viewPhoto = viewPhoto;
        vm.removeAccident = removeAccident;
        vm.dateTimeView = dateTimeView;
        vm.vehiclesView = vehiclesView;
        vm.insuredClients = insuredClients;
        vm.injuriesView = injuriesView;
        vm.addressView = addressView;
        vm.statusView = statusView;
        vm.actionView = actionView;

        vm.accidents = accidents;

        AccidentsListener.receive().then(null, null, function (data) {
            vm.accidents = data;
        });

        //****Data view functions****//
        function dateTimeView(accident) {
            var date = DateUtils.convertDateTimeFromServer(accident.occuredOn);
            return date.toLocaleDateString() + ' ' + date.toLocaleTimeString();
        }

        function vehiclesView(accident) {
            var carIds = '';
            accident.accidentCars.forEach(function (car, index, array) {
                if (array.length == (index + 1))
                    carIds += car.carPlate;
                else
                    carIds += car.carPlate + ', ';
            });
            return carIds;
        }

        function insuredClients(accident) {
            var clients = 'Νικολάου Νικόλαος \n Αθανασίου Αθανάσιος';
            return clients;
        }

        function injuriesView(accident) {
            if (accident.hasInjuries)
                return 'NAI';
            else
                return 'OXI';
        }

        function addressView(accident) {
            return 'Διεύθυνση 2, Αθήνα 14356';
        }

        function statusView(accident) {
            return Enums.AccidentStatus.getById(accident.workflowStatusId).description;
        }

        function actionView() {
            return 'Αποδοχή';
        }

        /**
         * Approves the accident as valid.
         */
        function approveAccident(accident) {
            AccidentsService.approveIncident({accidentId: accident.id}, updateSuccess, updateFailure);
        }

        var updateSuccess = function (data, headers) {
            AlertService.success('Accident approved');
            vm.removeAccident(data.accidentId);
        };

        var updateFailure = function (error) {
            AlertService.error(error.data.message);
        };

        /**
         * Views the matching accident photos
         */
        function viewPhoto(accident) {
            $window.open('http://www.caraccidentlawyerdc.com/wp-content/uploads/2013/11/Car-Accident.jpg', '_blank');
        }

        /**
         * Removes the accident from the list.
         */
        function removeAccident(accidentId) {
            vm.accidents.forEach(function (obj, index, array) {
                if (accidentId == obj.id)
                    array.splice(index, 1);
            });
        }
    }
})();
