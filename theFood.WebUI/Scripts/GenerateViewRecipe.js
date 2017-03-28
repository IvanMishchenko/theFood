
$(document).ready(function () {
    $('form#generateRecipe').submit(function (event) {
        event.preventDefault();
        var url = $(this).attr('action');
        $('#listRecipes').html('');
        $.post(url, function (response) {
            $('#listRecipes').append(response);

            var id = '#ext', top = $(id).offset().top; //for slow scroll 
              $('body,html').animate({ scrollTop: top }, 1500); //it's too
        });
    });
});


