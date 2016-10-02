(function () {
    'use strict';

    angular.module('hlydaBosApp')
        .constant('Enums', (function () {
            //Initialization stage.

            return {
                AccidentStatus: {
                    getById: function (id) {
                        for (var type in this) {
                            if (this.hasOwnProperty(type) && this[type].id == id)
                                return this[type];
                        }
                    },
                    inProcces: {
                        id: 2,
                        description: 'Σε Επεξεργασία'
                    },
                    assignToExpert: {
                        id: 3,
                        description: 'Ανάληψη από Εμπειρογνώμονα'
                    }
                }
            };
        })());

})();
