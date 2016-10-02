(function () {
    'use strict';

    angular.module('hlydaBosApp')
        .factory('AccidentsListener', AccidentsListener);

    AccidentsListener.$inject = ['$rootScope', '$cookies', '$http', '$q'];

    function AccidentsListener($rootScope, $cookies, $http, $q) {
        var stompClient = null;
        var subscriber = null;
        var listener = $q.defer();
        var connected = $q.defer();
        var alreadyConnectedOnce = false;

        return {
            connect: function (callback, endpoint) {
                //building absolute path so that websocket doesnt fail when deploying with a context path
                this.callback = callback;
                this.endpoint = endpoint;


                var loc = window.location;
                var url = '//' + loc.host + loc.pathname + 'websocket/accidents';
                var socket = new SockJS(url);
                stompClient = Stomp.over(socket);
                var headers = {};
                headers['X-CSRF-TOKEN'] = $cookies[$http.defaults.xsrfCookieName];
                stompClient.connect(headers, function (frame) {
                    connected.resolve("success");

                    if (!alreadyConnectedOnce) {
                        $rootScope.$on('$stateChangeStart', function (event) {

                        });
                        alreadyConnectedOnce = true;
                    }
                });
            },
            subscribe: function () {
                connected.promise.then(function () {
                    subscriber = stompClient.subscribe("/topic/accidents", function (data) {
                        listener.notify(JSON.parse(data.body));
                    });
                }, null, null);
            },
            unsubscribe: function () {
                if (subscriber != null) {
                    subscriber.unsubscribe();
                }
                listener = $q.defer();
            },
            receive: function () {
                return listener.promise;
            },
            disconnect: function () {
                if (stompClient != null) {
                    stompClient.disconnect();
                    stompClient = null;
                }
            }
        };
    }
})();
