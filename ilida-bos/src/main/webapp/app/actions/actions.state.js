(function () {
    'use strict';

    angular
        .module('hlydaBosApp')
        .config(stateConfig);

    stateConfig.$inject = ['$stateProvider'];

    function stateConfig ($stateProvider) {
        $stateProvider.state('actions', {
            abstract: true,
            parent: 'app'
        });
    }
})();
