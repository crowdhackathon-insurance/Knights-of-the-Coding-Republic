(function () {
    'use strict';

    angular.module('hlydaBosApp')
        .constant('Enums', (function () {
            //Initialization stage.

            return {
                AccidentStatus: {
                    getById: function (id) {
                        for (var type in this) {
                            if (this.hasOwnProperty(type) && type == id)
                                return this[type];
                        }
                    },
                    inProcces: {
                        id: 2,
                        description: 'inProcess'
                    },
                    assignToExpert: {
                        id: 3,
                        description: 'assignToExpert'
                    }
                }
            };
        })());

})();
