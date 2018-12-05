$(document).ready(function () {

    loadDVDs();

    $('#add-button').click(function (event) {

        //check for errors and display any that we have
        //pass the input associated with the add form to the validation function
        var haveValidationErrors = checkAndDisplayValidationErrors($('#add-form').find('input'));

        //if we have errors, bail out by returning false
        if (haveValidationErrors) {
            return false;
        }
        $.ajax({
            type: 'POST',
            url: 'http://localhost:50003/dvd',
            data: JSON.stringify({
                title: $('#add-dvd-title').val(),
                realeaseYear: parseInt($('#add-release-year').val(), 10),
                director: $('#add-director').val(),
                rating: ratingSelected($('#add-rating option:selected').text()),
                notes: $('#add-notes').val()
            }),
            headers: {
                'Accepts': 'application/ json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                loadDVDs();
            },
            error: function () {
                loadingError();
            }
        });
    });

    $('#search-button').click(function (event) {

        var searchCategory = $('#select-search-category option:selected').val();
        var searchTerm = $('#search-term').val();

        $('#errorMessages').empty();

        var haveValidationErrors = checkAndDisplayValidationErrors($('#input-search-term').find('input'));
        if (haveValidationErrors) {
            $('#search-term').val('');
            $('#select-search-category').val('');
            return false;
        }

        if (searchCategory == null || searchCategory == '') {
            var haveValidationErrors = $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text('Both Search Category and Search Term are required'));
        }

        if (haveValidationErrors) {

            $('#search-term').val('');
            $('#select-search-category').val('');
            return false;
        }

        $('#DVDRows').empty();
        var contentRows = $('#DVDRows');

        $.ajax({
            type: 'GET',
            url: 'http://localhost:50003/dvds/' + searchCategory + '/' + searchTerm,
            success: function (data, status) {
                $('#search-term').val('');
                $('#select-search-category').val('');
                if (!$.trim(data)) {
                    alert("There were no DVDs that matched those search criteria.");
                }
                $.each(data, function (index, dvd) {
                    var dvdId = dvd.dvdId;

                    var row = '<tr>';
                    row += '<td><a onclick="showTitleDetail(' + dvdId + ')">' + dvd.title + '</a></td>';
                    row += '<td>' + dvd.realeaseYear + '</td>';
                    row += '<td>' + dvd.director + '</td>';
                    row += '<td>' + dvd.rating + '</td>';
                    row += '<td class = "text-center"><a onclick ="editDVD(' + dvdId + ')">' + 'Edit</a>' + '  |  ' + '<a onclick = "deleteDVD(' + dvdId + ')">' + 'Delete' + '</a></td>';
                    row += '</tr>';
                    contentRows.append(row);
                });
            },
            error: function () {
                loadingError();
            }
        });
    });

    // Edit Button onclick handler
    $('#save-changes-button').click(function (event) {

        //check for errors and display any that we have
        //pass the input associated with the add form to the validation function
        var haveValidationErrors = checkAndDisplayValidationErrors($('#edit-form').find('input'));

        //if we have errors, bail out by returning false
        if (haveValidationErrors) {
            return false;
        }
        $.ajax({
            type: 'PUT',
            url: 'http://localhost:50003/dvd/' + $('#edit-dvd-id').val(),
            data: JSON.stringify({
                dvdId: $('#edit-dvd-id').val(),
                title: $('#edit-dvd-title').val(),
                realeaseYear: parseInt($('#edit-release-year').val(), 10),
                director: $('#edit-director').val(),
                rating: ratingSelected($('#edit-rating option:selected').text()),
                notes: $('#edit-notes').val()
            }),
            headers: {
                'Accept': 'application/ json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                loadDVDs();
            },
            error: function () {
                loadingError();
            }
        });
    });
});

function ratingSelected(rating) {
    if (rating == 'Choose Rating')
        return 'G'
    else
        return rating
}

function loadDVDs() {
    preparePage();
    $('#DVDTableHeader').show();
    $('#DVDTableDiv').show();

    var contentRows = $('#DVDRows');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:50003/dvds',
        success: function (data, status) {
            $.each(data, function (index, dvd) {

                var dvdId = dvd.dvdId;

                var row = '<tr>';
                row += '<td><a onclick="showTitleDetail(' + dvdId + ')">' + dvd.title + '</a></td>';
                row += '<td>' + dvd.realeaseYear + '</td>';
                row += '<td>' + dvd.director + '</td>';
                row += '<td>' + dvd.rating + '</td>';
                row += '<td class = "text-center"><a onclick ="editDVD(' + dvdId + ')">' + 'Edit</a>' + '  |  ' + '<a onclick = "deleteDVD(' + dvdId + ')">' + 'Delete' + '</a></td>';
                row += '</tr>';
                contentRows.append(row);
            });
        },
        error: function () {
            loadingError();
        }
    });
}

function showTitleDetail(dvdId) {
    preparePage();
    $('#DetailTableDiv').show();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:50003/dvd/' + dvdId,
        success: function (data, status) {

            $('#pageHeader').append('<h2>' + data.title + '</h2>');
            $('#display-release-year').append('<h4>' + data.realeaseYear + '</h4>');
            $('#display-director').append('<h4>' + data.director + '</h4>');
            $('#display-rating').append('<h4>' + data.rating + '</h4>');
            $('#display-notes').append('<h4>' + data.notes + '</h4>');
        },
        error: function () {
            loadingError();
        }
    });
}

function processBackButton() {
    $('#display-release-year').empty();
    $('#display-director').empty();
    $('#display-rating').empty();
    $('#display-notes').empty();
    loadDVDs();
}

function processCancelEditButton() {
    $('#edit-dvd-title').val('');
    $('#edit-release-year').val('');
    $('#edit-director').val('');
    $('#edit-rating').val('');
    $('#edit-notes').val('');
    loadDVDs();
}

function processCancelDVDLoad() {
    clearAddForm();
    loadDVDs();
}

function deleteDVD(dvdId) {
    $('#delete-dvd-id').val(dvdId);
    $('#DeleteModal').modal();
}

function processDeleteButton() {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:50003/dvd/' + $('#delete-dvd-id').val(),
            success: function (status) {
                loadDVDs();
            }
        });
}

function editDVD(dvdId) {
    preparePage();
    $('#EditDVDDiv').show();

    $('#edit-dvd-id').val(dvdId);

    $.ajax({
        type: 'GET',
        url: 'http://localhost:50003/dvd/' + dvdId,
        success: function (data, status) {

            $('#pageHeader').append('<h2>Edit Dvd:  ' + data.title + '</h2>');
            $('#edit-dvd-title').val(data.title);
            $('#edit-release-year').val(data.realeaseYear);
            $('#edit-director').val(data.director);
            $('#edit-rating').val(data.rating);
            $('#edit-notes').val(data.notes);
        },
        error: function () {
            loadingError();
        }
    });
}

function createDVD() {
    preparePage();
    $('#CreateDVDDiv').show();
    clearAddForm();

    $('#pageHeader').append('<h2>Create Dvd</h2>');
}

function clearAddForm() {
    $('#add-dvd-title').val('');
    $('#add-release-year').val('');
    $('#add-director').val('');
    $('#add-rating').val('');
    $('#add-notes').val('');
}

function preparePage() {
    $('#errorMessages').empty();
    $('#pageHeader').empty();
    $('#DVDRows').empty();
    $('#DVDTableHeader').hide();
    $('#DVDTableDiv').hide();
    $('#DetailTableDiv').hide();
    $('#EditDVDDiv').hide();
    $('#CreateDVDDiv').hide();

}

// processes validation errors for the given input.  returns true if there
// are validation errors, false otherwise
function checkAndDisplayValidationErrors(input) {
    // clear displayed error message if there are any
    $('#errorMessages').empty();
    // check for HTML5 validation errors and process/display appropriately
    // a place to hold error messages
    var errorMessages = [];

    // loop through each input and check for validation errors
    input.each(function () {
        // Use the HTML5 validation API to find the validation errors
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            if (this.id == "add-dvd-title" || this.id == "edit-dvd-title") {
                var message = "Please enter a title for the Dvd"
            }
            if (this.id == "add-release-year" || this.id == "edit-release-year") {
                var message = "Please enter a 4-digit year"
            }
            if (this.id == "search-term") {
                var message = "Both Search Category and Search Term are required"
            }

            errorMessages.push(message);
        }
    });

    // put any error messages in the errorMessages div
    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}

function loadingError() {
    $('#errorMessages')
        .append($('<li>')
            .attr({ class: 'list-group-item list-group-item-danger' })
            .text('Error calling web service.  Please try again later.'));
}
