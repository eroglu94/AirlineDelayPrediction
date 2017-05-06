//$(".div1").click(function () {
//    $(".div1").toggleClass("hidden");
//    $(".div2").toggleClass("hidden");
//});

//$(".div2").click(function () {
//    $(".div1").toggleClass("hidden");
//    $(".div2").toggleClass("hidden");
//});


$(".account").click(function () {
    $(".loginFloatDiv").toggleClass("hidden");
    $(".bgmask").toggleClass("hidden");
});

$(".bgmask").click(function () {
    $(".bgmask").toggleClass("hidden");
    $(".loginFloatDiv").toggleClass("hidden");
});

$(document).ready(function () {

    //if ($(".loginFloatDiv").hasClass("hidden")) {
    //    $(".bgmask").fadeIn("slow");
    //}

    //else if ($(".bgmask").hasClass("hidden")) {
    //    $(".loginFloatDiv").fadeIn("slow");
    //}

    //if ($(".loginFloatDiv").hasClass("hidden")) {
    //    $(".bgmask").fadeOut("slow");
    //    $(".loginFloatDiv").fadeOut("slow");

    //}
    //else if (($(".bgmask").hasClass("hidden"))) {
    //    $(".bgmask").fadeIn("slow");
    //    $(".loginFloatDiv").fadeIn("slow");
    //}

});