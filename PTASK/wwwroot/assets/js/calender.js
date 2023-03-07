function startTime() {
    var weekday = new Array();
    weekday[0] = "Chủ nhật";
    weekday[1] = "Thứ hai";
    weekday[2] = "Thứ ba";
    weekday[3] = "Thứ tư";
    weekday[4] = "Thứ năm";
    weekday[5] = "Thứ sáu";
    weekday[6] = "Thứ bảy";
    var month = new Array();
    month[0] = "Tháng 1";
    month[1] = "Tháng 2";
    month[2] = "Tháng 3";
    month[3] = "Tháng 4";
    month[4] = "Tháng 5";
    month[5] = "Tháng 6";
    month[6] = "Tháng 7";
    month[7] = "Tháng 8";
    month[8] = "Tháng 9";
    month[9] = "Tháng 10";
    month[10] = "Tháng 11";
    month[11] = "Tháng 12";
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var d = today.getDate();
    var y = today.getFullYear();
    var wd = weekday[today.getDay()];
    var mt = month[today.getMonth()];

    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('date').innerHTML = d;
    document.getElementById('day').innerHTML = wd;
    document.getElementById('month').innerHTML = mt + "/" + y;

    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) { i = "0" + i };
    return i;
}