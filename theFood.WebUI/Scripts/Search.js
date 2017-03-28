
$(document).ready(function () {
    $('#search').submit(function (event) {
        event.preventDefault();
        var url = $(this).attr('action');
        var data = $(this).serialize();

        if (data !== 'searchValue=Search') { /* should be add check on a space*/

            $('#listRecipes').html('');
            $.post(url, data, function (response) {
                $('#listRecipes').append(response);

                var id = '#ext', top = $(id).offset().top; //for slow scroll 
                $('body,html').animate({ scrollTop: top }, 1500); //it's too


            });
        }
      
    });
});
