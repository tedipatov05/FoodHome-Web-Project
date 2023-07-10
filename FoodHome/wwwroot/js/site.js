$(document).ready(function () {

    $('.counter').each(function () {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 4000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });

});


let map = document.getElementById('location');

map.addEventListener("click", function () {
    let address = map.textContent;

    var mapouter = document.getElementsByClassName("mapouter")[0];
    mapouter.innerHTML = `<iframe width = "100%" height = "100%" id = "gmap_canvas" src = "https://maps.google.com/maps?q=` + address + `&t=&z=9&ie=UTF8&iwloc=&output=embed" frameborder = "0" scrolling = "no" marginheight = "0" marginwidth = "0" ></iframe>`;
    mapouter.setAttribute("style", "height: 250px");
});



