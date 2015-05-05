var ViewModel = function () {
    var self = this;
    self.properties = ko.observableArray();
    self.error = ko.observable();

    var propertiesUri = '/api/properties/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllProperties() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.properties(data);
        });
    }

    // Fetch the initial data.
    getAllProperties();
};

ko.applyBindings(new ViewModel());