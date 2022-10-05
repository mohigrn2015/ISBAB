var baseUrl = 'https://localhost:44337/Attendence'
$(document).ready(function () {
    var data = {};  
    data.sessionToken = sessionStorage.getItem("token");
    try {
        $.ajax({
            url: baseUrl + "/GetAttendence",
            type: 'POST',
            async: true,
            data: data,
            success: function (data) {
                $("#attendenceData tbody").empty();
                var tr = "";

                $.each(data, function (colindex, r) {
                    tr += "<tr>"+
                        "<td>" + r.checkinDate + "</td>" +
                        "<td>" + r.checkinTime + "</td>" +
                        "<td>" + r.checkoutTime + "</td>" +
                        "<td>" + r.overTime + "</td>" +
                        "<td>" + r.leaveDaysCount + "</td>" +
                        "<td>" + r.holidaysCount + "</td>" +
                        "<td>" + r.weekendDaysCount + "</td>" +
                        "<td>" + r.lateDaysCount + "</td>" +
                        "<td>" + r.attendenceStatus + "</td>" + "</tr>"
                })
                $("#attendenceData").append(tr);
                tr = "";
            },
            error: function (result) {
                alert(result);
            }
        });
    }
    catch (err) {
        alert(err)
    }

    $('#checkInSubmit').click(function () {
        window.location.reload();
        var data = {};        
        data.sessionToken = sessionStorage.getItem("token");
        try {
            $.ajax({
                url: baseUrl + "/CheckIn",
                type: 'POST',
                async: true,
                data: data,
                success: function (data) {
                    $("#attendenceData tbody").empty();
                    var tr = "";
                    $.each(data, function (colindex, r) {
                        tr += "<tr>" +
                            "<td>" + r.checkinDate + "</td>" +
                            "<td>" + r.checkinTime + "</td>" +
                            "<td>" + r.checkoutTime + "</td>" +
                            "<td>" + r.overTime + "</td>" +
                            "<td>" + r.leaveDaysCount + "</td>" +
                            "<td>" + r.holidaysCount + "</td>" +
                            "<td>" + r.weekendDaysCount + "</td>" +
                            "<td>" + r.lateDaysCount + "</td>" +
                            "<td>" + r.attendenceStatus + "</td>" + "</tr>"
                    })
                    $("#attendenceData").append(tr);
                    tr = "";
                },
                error: function (result) {

                }
            });
        }
        catch (err) {
            alert(err)
        }
    })

    $('#checkOutSubmit').click(function () {
        window.location.reload();
        var data = {};
        data.sessionToken = sessionStorage.getItem("token");
        try {
            $.ajax({
                url: baseUrl + "/CheckOut",
                type: 'POST',
                async: true,
                data: data,
                success: function (data) {
                    var tr = "";
                    $.each(data, function (colindex, r) {
                        tr += "<tr>" +
                            "<td>" + r.checkinDate + "</td>" +
                            "<td>" + r.checkinTime + "</td>" +
                            "<td>" + r.checkoutTime + "</td>" +
                            "<td>" + r.overTime + "</td>" +
                            "<td>" + r.leaveDaysCount + "</td>" +
                            "<td>" + r.holidaysCount + "</td>" +
                            "<td>" + r.weekendDaysCount + "</td>" +
                            "<td>" + r.lateDaysCount + "</td>" +
                            "<td>" + r.attendenceStatus + "</td>" + "</tr>"
                    })
                    $("#attendenceData").append(tr);
                    tr = "";
                },
                error: function (result) {

                }
            });
        }
        catch (err) {
            alert(err)
        }
    })
})