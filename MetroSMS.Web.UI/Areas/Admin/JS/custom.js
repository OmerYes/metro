$(document).ready(function () {
    $(".btn_ProductList").click(function () {

        var id = $(this).data("product")

        window.location.href = "/Table/Detay/" + id

    })

})