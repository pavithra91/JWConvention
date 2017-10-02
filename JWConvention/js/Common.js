    var w = parseInt($(".container").css("width").replace(/[^-\d\.]/g, ''));
$(".list-jwcarousel").css("width", (($(".list-jwcarousel ul li").length) * w) + "px");

function StartSlideshow() {
    clearInterval(timer_slider);
    timer_slider = setInterval(function () {
        w = parseInt($(".container").css("width").replace(/[^-\d\.]/g, ''));
        $(".list-jwcarousel").css("width", (($(".list-jwcarousel ul li").length) * w) + "px");
        if ($(".linkbar-collapse-row").is(":visible")) {
            $(".list-jwcarousel ul").animate({ left: '-' + (w) + 'px', easing: "linear" }, 1000, function () {
                $(this).find("li:last").after($(this).find("li:first"));
                $(this).css({ left: "0" });
            });
        }
        else {
            $(".list-jwcarousel ul").animate({ left: '-' + (2 * w) + 'px', easing: "linear" }, 1000, function () {
                $(this).find("li:last").after($(this).find("li:first"));
                $(this).css({ left: "-" + w + "px" });
            });
        }
    }, 5000);
}

function NextSlide() {
    clearInterval(timer_slider);
    w = parseInt($(".container").css("width").replace(/[^-\d\.]/g, ''));
    $(".list-jwcarousel").css("width", (($(".list-jwcarousel ul li").length) * w) + "px");
    if ($(".linkbar-collapse-row").is(":visible")) {
        $(".list-jwcarousel ul").animate({ left: '-' + (w) + 'px', easing: "linear" }, 1000, function () {
            $(this).find("li:last").after($(this).find("li:first"));
            $(this).css({ left: "0" });
            StartSlideshow();
        });
    }
    else {
        $(".list-jwcarousel ul").animate({ left: '-' + (2 * w) + 'px', easing: "linear" }, 1000, function () {
            $(this).find("li:last").after($(this).find("li:first"));
            $(this).css({ left: "-" + w + "px" });
            StartSlideshow();
        });
    }
}

function PrevSlide() {
    clearInterval(timer_slider);
    w = parseInt($(".container").css("width").replace(/[^-\d\.]/g, ''));
    $(".list-jwcarousel").css("width", (($(".list-jwcarousel ul li").length) * w) + "px");
    $(".list-jwcarousel ul").find("li:last").prependTo($(".list-jwcarousel ul"));
    if ($(".linkbar-collapse-row").is(":visible")) {
        $(".list-jwcarousel ul").css({ left: '-' + (w) + 'px' });
        $(".list-jwcarousel ul").animate({ left: "0", easing: "linear" }, 1000, function () {
            StartSlideshow();
        });
    }
    else {
        $(".list-jwcarousel ul").css({ left: '-' + (2 * w) + 'px' });
        $(".list-jwcarousel ul").animate({ left: "-" + w + "px", easing: "linear" }, 1000, function () {
            StartSlideshow();
        });
    }
}

function Fix() {
    w = parseInt($(".container").css("width").replace(/[^-\d\.]/g, ''));
    $(".list-jwcarousel").css("width", (($(".list-jwcarousel ul li").length) * w) + "px");
    if ($(".linkbar-collapse-row").is(":visible")) {
        StartSlideshow();
    }
    else {
        $(".list-jwcarousel ul").css("left", '-' + w + 'px');
        $(".list-jwcarousel ul").find("li:last").after($(this).find("li:first"));
        StartSlideshow();
    }
}

var timer_slider;

$(window).resize(function () {
    clearInterval(timer_slider);
    setTimeout(Fix, 50);
});

$(".jwcarousel").hover(function () { clearInterval(timer_slider) }, function () { StartSlideshow() });
$(".information-box").addClass("carousel-fix");
StartSlideshow();

    /*
    window.onerror = function(errorMsg) {
        $('#console').html($('#console').html()+'<br>'+errorMsg)
    }*/

    $.datetimepicker.setLocale('en');

$('#datetimepicker_format').datetimepicker({ value: '2015/04/15', format: $("#datetimepicker_format_value").val() });
console.log($('#datetimepicker_format').datetimepicker('getValue'));

$("#datetimepicker_format_change").on("click", function (e) {
    $("#datetimepicker_format").data('xdsoft_datetimepicker').setOptions({ format: $("#datetimepicker_format_value").val() });
});
$("#datetimepicker_format_locale").on("change", function (e) {
    $.datetimepicker.setLocale($(e.currentTarget).val());
});

$('#datetimepicker').datetimepicker({
    dayOfWeekStart: 1,
    lang: 'en',
    disabledDates: ['1986/01/08', '1986/01/09', '1986/01/10'],
    startDate: '1986/01/05'
});
$('#datetimepicker').datetimepicker({ value: '2015/04/15 05:03', step: 10 });

$('.some_class').datetimepicker();

$('#default_datetimepicker').datetimepicker({
    formatTime: 'H:i',
    formatDate: 'd.m.Y',
    //defaultDate:'8.12.1986', // it's my birthday
    defaultDate: '+03.01.1970', // it's my birthday
    defaultTime: '10:00',
    timepickerScrollbar: false
});

$('#datetimepicker10').datetimepicker({
    step: 5,
    inline: true
});
$('#datetimepicker_mask').datetimepicker({
    mask: '9999/19/39 29:59'
});

$('#datetimepicker1').datetimepicker({
    datepicker: false,
    format: 'H:i',
    step: 5
});
$('#datetimepicker2').datetimepicker({


    timepicker: false,
    format: 'd/m/Y',
    formatDate: 'Y/m/d',


});
$('#datetimepicker3').datetimepicker({
    inline: true
});
$('#datetimepicker4').datetimepicker();
$('#open').click(function () {
    $('#datetimepicker4').datetimepicker('hide');
});
$('#close').click(function () {
    $('#datetimepicker4').datetimepicker('hide');
});
$('#reset').click(function () {
    $('#datetimepicker4').datetimepicker('reset');
});
$('#datetimepicker5').datetimepicker({
    datepicker: false,
    allowDates: ['1986/01/08', '1986/01/09', '1986/01/10'],

});
$('#datetimepicker6').datetimepicker();
$('#destroy').click(function () {
    if ($('#datetimepicker6').data('xdsoft_datetimepicker')) {
        $('#datetimepicker6').datetimepicker('destroy');
        this.value = 'create';
    } else {
        $('#datetimepicker6').datetimepicker();
        this.value = 'destroy';
    }
});
var logic = function (currentDateTime) {
    if (currentDateTime && currentDateTime.getDay() == 6) {
        this.setOptions({
            minTime: '11:00'
        });
    } else
        this.setOptions({
            minTime: '8:00'
        });
};
$('#datetimepicker7').datetimepicker({
    onChangeDateTime: logic,
    onShow: logic
});
$('#datetimepicker8').datetimepicker({
    onGenerate: function () {
        $(this).find('.xdsoft_date')
            .toggleClass('xdsoft_disabled');
    },
    minDate: '-1970/01/2',
    maxDate: '+1970/01/2',
    timepicker: false
});
$('#datetimepicker9').datetimepicker({
    onGenerate: function (ct) {
        $(this).find('.xdsoft_date.xdsoft_weekend')
            .addClass('xdsoft_disabled');
    },
    weekends: ['01.01.2014', '02.01.2014', '03.01.2014', '04.01.2014', '05.01.2014', '06.01.2014'],
    timepicker: false
});
var dateToDisable = new Date();
dateToDisable.setDate(dateToDisable.getDate() + 2);
$('#datetimepicker11').datetimepicker({
    beforeShowDay: function (date) {
        if (date.getMonth() == dateToDisable.getMonth() && date.getDate() == dateToDisable.getDate()) {
            return [false, ""]
        }

        return [true, ""];
    }
});
$('#datetimepicker12').datetimepicker({
    beforeShowDay: function (date) {
        if (date.getMonth() == dateToDisable.getMonth() && date.getDate() == dateToDisable.getDate()) {
            return [true, "custom-date-style"];
        }

        return [true, ""];
    }
});
$('#datetimepicker_dark').datetimepicker({ theme: 'dark' })

