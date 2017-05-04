$(document).ready(function () {
    $(".click-details").click(function(){
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: 'Cupcake/Details/' + this.id,
            success: function (result) {
                $('.return-details').html(result);
            }
        });
    });


    $("#click-create").click(function () {
        $.ajax({
            type: 'GET',
            datatype: 'html',
            url: '/Cupcake/Create',
            success: function (result) {
                $('.return-create').html(result);
            }
        });
    });

    $('.new-cupcake').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: 'Cupcake/Create',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var resultReturn = result.name;
                $('#cupcake-list').append('<p>' + resultReturn + '</p>');
            }
        });
    });

    $('.edit-form').click(function (event) {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Cupcake/Edit/' + this.value,
            success: function (result) {
                $('.return-edit').html(result);
            }
        });
    });

    $('.edit-cupcake').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: 'Cupcake/Edit',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var editedCupcake = result.name;
                var cupcakeId = result.id.toString();
                $('#' + cupcakeId).text(editedCupcake);
            }
        });
    });

    $(".delete-cupcake").click(function () {
        $.ajax({
            type: "POST",
            url: 'Cupcake/Delete/' + this.value,
            success: function (result) {
                var cupcakeId = result.id.toString();
                $('.each-' + cupcakeId).remove();
            }
        });
    })
});