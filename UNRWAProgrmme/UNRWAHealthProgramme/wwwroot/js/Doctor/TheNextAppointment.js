let btn = document.getElementById("next-appointment-btn");
let pationtSpan = document.getElementById("pationtName");
let timespan = document.getElementById("time");
btn.onclick = function (e) {
    $.ajax(
        {
            url: '/Doctor/GetNextAppointment',
            type: "POST",
            success: function (result) {
                let pationtSpanText = document.createTextNode(result.name);
                let timeSpanText = document.createTextNode(result.time);
                pationtSpan.innerHTML = "";
                timespan.innerHTML = "";
                pationtSpan.appendChild(pationtSpanText);
                timespan.appendChild(timeSpanText);
                console.log("done" + result.name + "rama");
            },
            error: function () {
                console.log("faild");
            }
        });
}