$(document).ready(function () {
    $(".click").click(function () {
        var proizvod = $("#Proizvod").val().valueOf().toString(); 
        var cijena = $("#Cijena").val();
        var kolicina = $("#Kolicina").val();
        var popust = $("#Popust").val();

        var code = "<tr><td>" + proizvod + "</td><td>" + cijena + "</td><td>" + kolicina + "</td></tr>"+popust+"</td></tr>"

        $("table .tbody").append(code);
    })
});