

$(document).ready(function () {

    var listMiniProduct = $('#cartPanel').find('form#miniProduct');
    if (listMiniProduct.length > 0) {
        document.getElementById("clearCartButton").hidden = false;
        document.getElementById("cartPanel").hidden = false;
    }

        $('form#clearCartButton').submit(function (event) {
            event.preventDefault();
            var data = $(this).serialize();
            var url = $(this).attr('action');
            $('#cartPanel').html('');
            document.getElementById("clearCartButton").hidden = true;
            document.getElementById("cartPanel").hidden = true;
            $.post(url, data, function (response) {
                $('#cartPanel').append(response);

            });
        });
 
        $('form#addProductForm').submit(function (event) {
            event.preventDefault();
            var data = $(this).serialize();
            var url = $(this).attr('action');

            document.getElementById("clearCartButton").hidden = false;
            document.getElementById("cartPanel").hidden = false;

            $.post(url, data, function (response) {

                var from = response.length;
                var to = response.lastIndexOf("<form");
                var result = response.substr(to, from);
                $('#cartPanel').append(result);


                $('form#miniProduct').submit(function (event) {
                    event.preventDefault();
                    var data = $(this).serialize();
                    var url = $(this).attr('action');
                    this.remove();

                    $.post(url, data, function (response) {
                        var isNull = response.indexOf("form");
                        if (isNull < 0) {
                            document.getElementById("clearCartButton").hidden = true;
                            document.getElementById("cartPanel").hidden = true;
                        }

                    });
                });
            });
        });

   

});





