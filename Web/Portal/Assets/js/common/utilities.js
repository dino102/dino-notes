// # Rational Framework v1.0 #
// This file contains custom js helpers.
page.factory('utilities', function () {
    return {
        stringFormat: function (source) {
            var output = source;
            for (var ctr = 1; ctr < arguments.length; ctr++) {
                var regexp = new RegExp('\\{' + (ctr - 1) + '\\}', 'gi');
                output = output.replace(regexp, arguments[ctr]);
            }
            return output;
        },

        isValidNumber: function (input) {
            var numStr = input;
            var numNum = +numStr;
            if (isNaN(numNum)) {
                return false;
            } else {
                return true;
            }
        },

        formatDate: function (date, mask) {
            var result = "";
            var defaultMask = "DD/MM/YYYY";

            if (date instanceof Date) {
                // js date type
                if (typeof mask != 'undefined' && mask.length > 0)
                    result = moment(date).format(mask);
                else
                    result = moment(date).format(defaultMask);
            } else {
                // json date
                var d = new Date(date.substr(0, 10));
                if (typeof mask != 'undefined' && mask.length > 0)
                    result = moment(d).format(mask);
                else
                    result = moment(d).format(defaultMask);
            }
            return result;
        },

        getDate: function (dateString, mask) {
            var result = new Date();
            if (typeof mask != 'undefined' && mask.length > 0) {
                var momentDate = moment(dateString, mask);
                result = momentDate.toDate();
            }
            return result;
        },

        // uses bootbox.js
        alert: {
            info: function (message, callback) {
                bootbox.alert({
                    size: 'small',
                    title: '<strong class="text-success">Info</strong>',
                    closeButton: false,
                    message: message,
                    callback: callback
                });
            },
            error: function (message, callback) {
                bootbox.alert({
                    size: 'small',
                    title: '<strong class="text-danger">Error</strong>',
                    closeButton: false,
                    message: message,
                    callback: callback
                });
            },
            confirm: function (message, callback) {
                bootbox.confirm({
                    size: 'small',
                    title: '<strong class="text-warning">Confirm</strong>',
                    closeButton: false,
                    message: message,
                    callback: callback
                });
            }
        }

    }
});