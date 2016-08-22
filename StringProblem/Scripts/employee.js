$(document).ready(function () {
    $("#idEnter").click(function () {
        var pathname = window.location.pathname;
        var url = pathname + "/GetEmployee?empData=" + $('#EmployeeInput').val();
        $.ajax({
            url: url,
            type: "POST",
            dataType: "json",
            success: function (data) {
                $('#divDisplayHere').html("<br><span style='font-size:20px;margin-top:10%;font-weight:bold;color:red'>RESULTS:</span><br>")
                $.each(data.EmployeeData, function (idx, employeeInfo) {
                    $('#divDisplayHere').append("<span style='font-size:15px;margin-top:5%;font-weight:bold;color:green'>" + employeeInfo + "</span><br>")
                });

            }
        });
    });
   
});

