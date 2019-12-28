
$(function () {
    var urlParams = new URLSearchParams(window.location.search);
    let min = urlParams.get('min');
    let max = urlParams.get('max');
    if (min == null || max == null){
    min = 0
    max=1000
}  
    $("#slider-range").slider({
        range: true,
        min: 0,
        max: 1000,
        values: [parseInt(min), parseInt(max)],
        slide: function (event, ui) {
            $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $("#amount").val("$" + $("#slider-range").slider("values", 0) +
        " - $" + $("#slider-range").slider("values", 1));
});


