
$(document).ready(function () {

    var fadeTime = 300;
    

    $('.product-removal button').click(function () {
        removeItem(this);
    });

    function removeObjectFromSession(dishId) {
        $.ajax({
            url: '/Dish/RemoveFromCart',
            type: 'GET',
            data: { dishId: dishId },
            success: function () {
                console.log('Object removed successfully');
            },
            error: function () {
                console.error('Error occurred while removing object');
            }
        });
    }

    function removeItem(removeButton) {

        var productRow = $(removeButton).parent().parent();
        var id = Number($("#dishId").val());

        removeObjectFromSession(id);

        productRow.slideUp(fadeTime, function () {
            productRow.remove();
            recalculateCart();
        });
    }

});
