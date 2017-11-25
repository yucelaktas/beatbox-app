/// <reference path="../jquery-1.9.1.js" /

$(document).ready(function () {
    $('#switch-btn').prop('checked', false);
    $('#side-menu li').filter('.scr').click(ClickList);
    $('#SideBarMenuContent').css('display', 'none');
    $('#side-menu li').filter('.scr').hover(HoverOn, HoverOff);

    $('#switch-btn').click(function () {
        if (!$('#switch-btn').prop('checked')) {
            $('#t-body tr').remove();
            $('#SideBarMenuContent').css('display', 'none');
        }
    });
})

function HoverOn() {
    $('#SideBarMenuContent').css('display', 'block');
    if (!$('#switch-btn').prop('checked')) {
        var elementId = this.id;
        $.ajax({
            url: '/Home/GetList/' + elementId,
            method: 'get',
            error: function (err) {
                console.log(err);
            },
            success: function (response) {
                $.each(response, AppenList);
            },
        });
    };
}

function HoverOff() {
    if (!$('#switch-btn').prop('checked')) {
        $('#t-body tr').remove();
        $('#SideBarMenuContent').css('display', 'none');
    }
}

var rowClassName = "success";

function AppenList(key, val) {
    var tbody = $('#t-body');
    var check = val.IsActive ? 'aktif' : 'pasif';
    var date = eval(val.InsertDate.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
    var shortDate = date.toLocaleDateString('tr-TR');
    var icon = val.IsActive == true ? "<button title=\"Sil\" id=\"remove-icon\" onclick=DeleteIcon(" + val.Id + ") class=\"	glyphicon glyphicon-remove \"> </button>" : "<button id=\"back-icon\" title=\"Geri Yükle\" onclick=UndeleteIcon(" + val.Id + ") class=\"glyphicon glyphicon-ok \"> </button> <button id=\"trush-icon\" title=\"Kalıcı Sil\" onclick=TrushIcon(" + val.Id + ") class=\"glyphicon glyphicon-trash \"> </button>";
    tbody.append('<tr class="' + rowClassName + '">' +
        '<td>' + val.Id + '</td>' +
        '<td>' + val.Name + '</td>' +
        '<td>' + shortDate + '</td>' +
        '<td>' + check + '</td>' +
        '<td> ' + icon +
        '</tr>');

    rowClassName = rowClassName == "success" ? "warning" : "success";
}

function DeleteIcon(id) {
    $.ajax({
        url: 'http://localhost:16042/category/Delete/' + id,
        method: 'get',
        success: function (response) {
            alert(response);
            $('#switch-btn').prop('checked', false);
            $('#t-body tr').remove();
            $('#SideBarMenuContent').css('display', 'none');
        },
        error: function (err) {
            alert(err);
        }
    });
}


function TrushIcon(id) {
    if(confirm("Veriyi kalıcı olarak silmek istediğinize emin misiniz?")){
        $.ajax({
            url: 'http://localhost:16042/category/SuperDelete/' + id,
            methop: 'get',
            success: function (response) {
                alert(response);
                $('#switch-btn').prop('checked', false);
                $('#t-body tr').remove();
                $('#SideBarMenuContent').css('display', 'none');
            },
            Error: function (err) {
                alert(err);
            },
        })
    }
}

function UndeleteIcon(id) {
    $.ajax({
        url: 'http://localhost:16042/category/UnDelete/' + id,
        method: 'get',
        success: function (response) {
            alert(response);
            $('#switch-btn').prop('checked', false);
            $('#t-body tr').remove();
            $('#SideBarMenuContent').css('display', 'none');
        },
        error: function (err) {
            alert(alert);
        }
    })
}




function ClickList() {
    $('#switch-btn').prop('checked', true);
    $('#t-body tr').remove();
    $('#SideBarMenuContent').css('display', 'block');
    var elementId = this.id;
    $.ajax({
        url: '/Home/GetList/' + elementId,
        method: 'get',
        error: function (err) {
            console.log(err);
        },
        success: function (response) {
            $.each(response, AppenList);
        },
    });

}



