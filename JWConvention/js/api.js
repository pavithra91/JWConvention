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

    debugger;

    var sDate = startDate.split('/'),
    sYear = parseInt(sDate[2], 10), // cast Strings as Numbers
    sDay = parseInt(sDate[0], 10),
    sMo = parseInt(sDate[1], 10);

    var eDate = endDate.split('/'),
    eYear = parseInt(eDate[2], 10), // cast Strings as Numbers
    eDay = parseInt(eDate[0], 10),
    eMo = parseInt(eDate[1], 10);

    if (sMo == 6 && sDay < 25) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }
    if (sMo == 7 && sDay > 4) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }

    if (eMo == 7 && eDay < 5) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }
    if (eMo == 7 && eDay > 17) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }

    if (6 > sMo || 7 < sMo) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }

    if (7 > eMo || 7 < eMo) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }
    else
    {
        document.getElementById("save").disabled = false;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "";
    }

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
            if (r.Message == "Convention Dates") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "Please include Convention dates within your booking Dates!";
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

    debugger;

    var sDate = startDate.split('/'),
    sYear = parseInt(sDate[2], 10), // cast Strings as Numbers
    sDay = parseInt(sDate[0], 10),
    sMo = parseInt(sDate[1], 10);

    var eDate = endDate.split('/'),
    eYear = parseInt(eDate[2], 10), // cast Strings as Numbers
    eDay = parseInt(eDate[0], 10),
    eMo = parseInt(eDate[1], 10);


    if (sMo==6 && sDay < 25) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }
    if (sMo == 7 && sDay > 4) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }

    if (eMo == 7 && eDay < 5) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }
    if (eMo == 7 && eDay > 17) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }


    if (6 > sMo || 7 < sMo) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }

    if (7 > eMo || 7 < eMo) {
        document.getElementById("save").disabled = true;
        document.getElementById('lblTotalCost').innerHTML = "USD : 0";
        document.getElementById('lblBefore').style.color = "red";
        document.getElementById('lblBefore').innerHTML = "Sorry You can't book for this Date.";
        return;
    }

    //if (startDate > endDate) {
    //    document.getElementById("save").disabled = true;
    //    document.getElementById('lblTotalCost').innerHTML = "USD : 0";
    //    document.getElementById('lblBefore').style.color = "red";
    //    document.getElementById('lblBefore').innerHTML = "Check In date cannot be Greater than Check Out Date";
    //    return;
    //}

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

            if (r.Message == "Convention Dates") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "Please include Convention dates within your booking Dates!";
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

            if (r.Message == "Convention Dates") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "Please include Convention dates within your booking Dates!";
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

            if (r.Message == "Convention Dates") {
                document.getElementById("save").disabled = true;
                document.getElementById('lblTotalCost').innerHTML = "USD : 0";
                document.getElementById('lblBefore').style.color = "red";
                document.getElementById('lblBefore').innerHTML = "Please include Convention dates within your booking Dates!";
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