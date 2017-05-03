$(document).ready(function () {
    $(".click-details").click(function(){
        console.log(this.id);
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: 'Cupcake/Details/' + this.id,
            success: function (result) {
                $('.return-details').html(result);
                console.log(result);
            }
        });
    });

});