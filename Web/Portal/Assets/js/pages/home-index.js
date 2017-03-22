page.constant('constants', {
    apiUrl: js.config.ApiUrl,
    apiMethods: {
        getList: '/notes/getlist',
        getNote: '/notes/getnote?id=',
        saveNote: '/notes/savenote'
    },
    otherController: {
    }
});

page.value('globals', {
    activeId: ""
});

page.controller('HomeController', ['$http', '$window', 'constants', 'globals', 'utilities',
    function ($http, $window, constants, globals, utilities) {

    var controller = this;

    // initialization event
    controller.init = function () {
        // get all notes
        $http.get(constants.apiUrl + constants.apiMethods.getList)
            .then(function (response) {
                if (response.data.length > 0) {
                    controller.sidebar.notes = response.data;

                    // load the first item
                    globals.activeId = response.data[0].Id;
                    controller.note.load(globals.activeId);
                }
            });
    };

    controller.state = {
        status: '', // viewing, adding, saving, saved
        message: ''
    };

    controller.sidebar = {
        notes: [],
        select: function (id) {
            globals.activeId = id;
            controller.note.load(globals.activeId);
        }
    };

    controller.note = {
        info: {
            id: 0,
            title: "",
            dateUpdated: "",
            content: "",
            isPinned: false
        },
        load: function (id) {
            $http.get(constants.apiUrl + constants.apiMethods.getNote + id)
                .then(function (response) {
                    controller.note.info.id = response.data.Id;
                    controller.note.info.title = response.data.Title;
                    controller.note.info.dateUpdated = response.data.DateUpdated;
                    controller.note.info.content = response.data.Content;
                });
        },
        add: function () {
            globals.activeId = '';
            controller.note.info.id = 0;
            controller.note.info.title = '';
            controller.note.info.dateUpdated = '';
            controller.note.info.content = '';

            $('#note-textarea').focus();
        },
        save: function (uid) {
            $http.post(constants.apiUrl + constants.apiMethods.saveNote, controller.note.info)
                .then(function (response) {
                    if (response.data !== '') {
                        utilities.alert.info('The record was successfully save.', function (result) {
                            if (result) {
                                // reload page
                                $window.location.href = utilities.stringFormat('/poc/moviedetails/{0}', response.data);
                            }
                        });
                    } else {
                        utilities.alert.error('Process failed. Please contact our support team.');
                    }
                });
        },
        pin: function (uid) {
            
        },
        delete: function (uid) {
            utilities.alert.confirm('Are you sure you want to delete this record?', function (result) {
                if (result) {
                    // delete proper
                    $http.post(constants.apiUrl + constants.apiMethods.deleteMovie, { value: uid })
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

