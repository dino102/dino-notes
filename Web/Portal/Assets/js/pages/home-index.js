page.constant('constants', {
    apiUrl: js.config.ApiUrl,
    notes: {
        apiMethods: {
            getList: '/notes/getlist',
            getNote: '/notes/getnote?id='
        }
    },
    otherController: {
    }
});


page.controller('SideBarController', ['$http', '$window', 'constants', 'utilities', function ($http, $window, constants, utilities) {
    var controller = this;

    // initialization event
    controller.init = function () {
        controller.notes.load();
    };

    controller.notes = {
        list: [],
        load: function () {
            $http.get(constants.apiUrl + constants.notes.apiMethods.getList)
                .then(function (response) {

                    controller.notes.list = response.data;
                });
        }
    };
}]);


page.controller('HomeController', ['$http', '$window', 'constants', 'utilities', function ($http, $window, constants, utilities) {
    var controller = this;

    // initialization event
    controller.init = function () {
        controller.note.load(1);
    };

    controller.note = {
        info: {
            id: 0,
            title: "",
            dateUpdated: "",
            content: ""
        },
        load: function (id) {
            $http.get(constants.apiUrl + constants.notes.apiMethods.getNote + id)
                .then(function (response) {
                    controller.note.info.id = response.data.Id;
                    controller.note.info.title = response.data.Title;
                    controller.note.info.dateUpdated = response.data.DateUpdated;
                    controller.note.info.content = response.data.Content;
                });
        },
        add: function () {
            //window.location.href = '/poc/moviedetails';
        },
        save: function (uid) {

        },
        pin: function (uid) {
            
        },
        delete: function (uid) {
            utilities.alert.confirm('Are you sure you want to delete this record?', function (result) {
                if (result) {
                    // delete proper
                    $http.post(constants.apiUrl + constants.movies.apiMethods.deleteMovie, { value: uid })
                        .then(function (response) {
                            if (response.data !== '') {
                                utilities.alert.info('The record was successfully deleted.');

                                // reload the list
                                controller.movies.load();
                            } else {
                                utilities.alert.error('Process failed. Please contact our support team.');
                            }
                        });
                }
            });

        }
    };

}]);

