
var baseUrl = 'https://localhost:44337'
$(document).ready(function () {
    $('#loginSubmit').click(function () {
        var data = {};
        data.user_name = $('#userName').val();
        data.password = $('#password-field').val();
       
        try {
            $.ajax({
                url: baseUrl + "/Security/Login",
                type: 'POST',
                async: true,
                data: data,
                success: function (result) {
                    if (result.is_Authenticated == true) {
                        sessionStorage.setItem("token", result.session_token);
                        location.href = baseUrl + "/Home/Index";                        
                        //sessionStorage.setItem("user", result.userId);
                        //sessionStorage.setItem("right", result.right_id);
                    }
                    else {
                        alert("Invalid login!");
                    }                
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

$('#registerSubmit').click(function () {
    alert('Hello');
    $.ajax({
        url: baseUrl + "/Security/Register",
        type: 'GET',
        success: function (result) {

        },
        error: function (result) {

        }
    });
})


//if (result.is_Authenticated == true) {
//    var getAttendence = {};
//    getAttendence.userId = result.userId;
//    getAttendence.sessionToken = result.session_token;
//    $.ajax({
//        url: baseUrl + "/Attendance/GetAttendenceList",
//        type: 'POST',
//        async: true,
//        data: getAttendence,
//        success: function (result) {
//            console.log(result);
//        },
//        error: function (result) {

//        }
//    });
//}                    