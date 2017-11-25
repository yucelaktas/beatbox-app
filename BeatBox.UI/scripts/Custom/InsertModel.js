$(document).ready(function () {

    $('#InsertCategoryModel').submit(function (e) {

        debugger;
        e.preventDefault();
        $.ajax({
            url: 'http://localhost:16042/category/Insert',
            method: 'post',
            data: $('#InsertCategoryModel').serialize(),
            success: function (response) {
                $('#CloseCategoryModel').click();
                alert(response);
            },
            error: function (err) {
                $('#CloseCategoryModel').click();
                alert(err);
            }

        })
    })


    $('#InsertSongModel').submit(function (e) {

        e.preventDefault();
        $.ajax({
            url: 'http://localhost:16042/Song/Insert',
            method: 'post',
            data: $('#InsertSongModel').serialize(),
            success: function (response) {
                $('#CloseSongModel').click();
                alert(response);
            },
            error: function (err) {
                $('#CloseSongModel').click();
                alert(err);
            }

        })
    })

});