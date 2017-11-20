$("#drpOccupancy").change(function () {
    var OccupancyID = $('#drpOccupancy').val();

    if (OccupancyID == "Double") {
        var dvPassport = document.getElementById("bedPreference");
        dvPassport.style.display = "block";
    }
    else {
        var dvPassport = document.getElementById("bedPreference");
        dvPassport.style.display = "none";
    }
});


$("#datetimepicker2").change(function () {
    var roomID = $('#drpRoomType').val();
    var startDate = $('#datetimepicker2').val();
    $('#datetimepicker7').val(startDate);

    var endDate = $('#datetimepicker3').val();
    var drpOccupancy = $('#drpOccupancy').val();

    if (drpOccupancy == "Double")
    {        
        var drpPerferences = $('#drpPerferences').val();
        var _hotelCode = $('#_hotelCode').val();

        if (drpPerferences == null)
        {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "Please Select Bed Preference.";
            return;
        }

        if (_hotelCode == "TKH" && drpPerferences == "Twin")
        {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "No Allotment Available for Twin Room. Please select different Room type or Hotel.";
            return;
        }
    }

    $('#datetimepicker8').val(endDate);

    $.ajax({
        type: 'GET',
        url: "http://events.walkerstours.net/Service/DateCheck?fromDate=" + startDate + "&endDate=" + endDate + "&roomID=" + roomID + "&Occupancy=" + drpOccupancy,
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var r = result;

            if (r.Message == "Failed") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "You have to Select Minimum 7 Nights to Continue the Reservation!";
                return;
            }

            if (r.Allotment == 0) {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "No Allotment Available for above Reservation. Please select different Room type or Hotel.";
            }
            else {
                document.getElementById("save").disabled = false;
                document.getElementById('lblTotalCost').innerHTML = "USD : " + r.TotalCost;
                document.getElementById('lblBefore').style.color = "black";
                document.getElementById('lblBefore').innerHTML = r.PackageDays + " Night Package";
                //document.getElementById('lblBefore').innerHTML = r.BeforeDays + " Additional Nights + " + r.PackageDays + " Night Package + " + r.AfterDays + " Additional Nights";
            }
        },
        error: function (req, status, err) {
            debugger;
            //alert("Error");
        }
    });
});

$("#datetimepicker3").change(function () {
    var roomID = $('#drpRoomType').val();
    var startDate = $('#datetimepicker2').val();
    var endDate = $('#datetimepicker3').val();
    var drpOccupancy = $('#drpOccupancy').val();

    $('#datetimepicker8').val(endDate);

    if (drpOccupancy == "Double") {
        var drpPerferences = $('#drpPerferences').val();
        var _hotelCode = $('#_hotelCode').val();

        if (drpPerferences == null) {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "Please Select Bed Preference.";
            return;
        }

        if (_hotelCode == "TKH" && drpPerferences == "Twin") {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "No Allotment Available for Twin Room. Please select different Room type or Hotel.";
            return;
        }
    }

    $.ajax({
        type: 'GET',
        url: "http://events.walkerstours.net/Service/DateCheck?fromDate=" + startDate + "&endDate=" + endDate + "&roomID=" + roomID + "&Occupancy=" + drpOccupancy,
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var r = result;

            if (r.Message == "Failed") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "You have to Select Minimum 7 Nights to Continue the Reservation!";
                return;
            }

            if (r.Allotment == 0) {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "No Allotment Available for above Reservation. Please select different Room type or Hotel.";
            }
            else {
                document.getElementById("save").disabled = false;
                document.getElementById('lblTotalCost').innerHTML = "USD : " + r.TotalCost;
                document.getElementById('lblBefore').style.color = "black";
                document.getElementById('lblBefore').innerHTML = r.PackageDays + " Night Package";
                //document.getElementById('lblBefore').innerHTML = r.BeforeDays + " Additional Nights + " + r.PackageDays + " Night Package + " + r.AfterDays + " Additional Nights";
            }
        },
        error: function (req, status, err) {
            debugger;
            //alert("Error");
        }
    });
});

$("#drpOccupancy").change(function () {
    var roomID = $('#drpRoomType').val();
    var startDate = $('#datetimepicker2').val();
    var endDate = $('#datetimepicker3').val();
    var drpOccupancy = $('#drpOccupancy').val();

    $('#datetimepicker8').val(endDate);

    if (drpOccupancy == "Double") {
        var drpPerferences = $('#drpPerferences').val();
        var _hotelCode = $('#_hotelCode').val();

        if (drpPerferences == null) {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "Please Select Bed Preference.";
            return;
        }

        if (_hotelCode == "TKH" && drpPerferences == "Twin") {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "No Allotment Available for Twin Room. Please select different Room type or Hotel.";
            return;
        }
    }

    $.ajax({
        type: 'GET',
        url: "http://events.walkerstours.net/Service/DateCheck?fromDate=" + startDate + "&endDate=" + endDate + "&roomID=" + roomID + "&Occupancy=" + drpOccupancy,
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var r = result;

            if (r.Message == "Failed") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "You have to Select Minimum 7 Nights to Continue the Reservation!";
                return;
            }

            if (r.Allotment == 0) {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "No Allotment Available for above Reservation. Please select different Room type or Hotel.";
            }
            else {
                document.getElementById("save").disabled = false;
                document.getElementById('lblTotalCost').innerHTML = "USD : " + r.TotalCost;
                document.getElementById('lblBefore').style.color = "black";
                document.getElementById('lblBefore').innerHTML = r.PackageDays + " Night Package";
                //document.getElementById('lblBefore').innerHTML = r.BeforeDays + " Additional Nights + " + r.PackageDays + " Night Package + " + r.AfterDays + " Additional Nights";
            }
        },
        error: function (req, status, err) {
            debugger;
            //alert("Error");
        }
    });
});


$("#drpPerferences").change(function () {
    var roomID = $('#drpRoomType').val();
    var startDate = $('#datetimepicker2').val();
    var endDate = $('#datetimepicker3').val();
    var drpOccupancy = $('#drpOccupancy').val();
    
    $('#datetimepicker8').val(endDate);

    debugger;

    if (drpOccupancy == "Double") {
        var drpPerferences = $('#drpPerferences').val();
        var _hotelCode = $('#_hotelCode').val();

        if (drpPerferences == null) {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "Please Select Bed Preference.";
            return;
        }

        if (_hotelCode == "TKH" && drpPerferences == "Twin") {
            document.getElementById("save").disabled = true;
            document.getElementById('lblTotalCost').innerHTML = "USD : 0";
            document.getElementById('lblBefore').style.color = "red";
            document.getElementById('lblBefore').innerHTML = "No Allotment Available for Twin Room. Please select different Room type or Hotel.";
            return;
        }
    }

    $.ajax({
        type: 'GET',
        url: "http://events.walkerstours.net/Service/DateCheck?fromDate=" + startDate + "&endDate=" + endDate + "&roomID=" + roomID + "&Occupancy=" + drpOccupancy,
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var r = result;

            if (r.Message == "Failed") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "You have to Select Minimum 7 Nights to Continue the Reservation!";
                return;
            }

            if (r.Allotment == 0) {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "No Allotment Available for above Reservation. Please select different Room type or Hotel.";
            }
            else {
                document.getElementById("save").disabled = false;
                document.getElementById('lblTotalCost').innerHTML = "USD : " + r.TotalCost;
                document.getElementById('lblBefore').style.color = "black";
                document.getElementById('lblBefore').innerHTML = r.PackageDays + " Night Package";
                //document.getElementById('lblBefore').innerHTML = r.BeforeDays + " Additional Nights + " + r.PackageDays + " Night Package + " + r.AfterDays + " Additional Nights";
            }
        },
        error: function (req, status, err) {
            debugger;
            //alert("Error");
        }
    });
});