
$(document).ready(function () {


    var taxRate = 0.05;
    var shippingRate = 5.00;
    var fadeTime = 300;
    var quantity = 1;

    $('.shopping-cart').ready(function () {
        updateQuantity($('.product-quantity input'));
        recalculateCart();
    });

    $('.product-quantity input').change(function () {
        updateQuantity(this);
    });

    //$('.button-plus button').click(function () {
    //    var dishId = Number($('#dishId').val());
    //    updateObjectQuantityToSession(dishId);
    //    quantity += 1;
    //    $('.product-quantity input').val(quantity);
    //});

    //$('.button-minus button').click(function () {
    //    var dishId = Number($('#dishId').val());
    //    decreaseQuantity(dishId);
    //    quantity -= 1;
    //    $('.product-quantity input').val(quantity);
    //});
   
    $('.product-removal button').click(function () {
        removeItem(this);
    });


    function recalculateCart() {
        var subtotal = 0;

        $('.product').each(function () {
            subtotal += parseFloat($(this).children('.product-line-price').text());
        });


        var tax = subtotal * taxRate;
        var shipping = (subtotal > 0 ? shippingRate : 0);
        var total = subtotal + tax + shipping;


        $('.totals-value').fadeOut(fadeTime, function () {
            $('#cart-subtotal').html(subtotal.toFixed(2));
            $('#cart-tax').html(tax.toFixed(2));
            $('#cart-shipping').html(shipping.toFixed(2));
            $('#cart-total').html(total.toFixed(2));
            if (total == 0) {
                $('.checkout').fadeOut(fadeTime);
            } else {
                $('.checkout').fadeIn(fadeTime);
            }
            $('.totals-value').fadeIn(fadeTime);
        });
    }


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

    //function updateObjectQuantityToSession(dishId) {
    //    $.ajax({
    //        url: '/Dish/AddToCart',
    //        type: 'GET',
    //        data: {
    //            dishId: dishId,
    //            quantity: 1
    //        },
    //        success: function () {
    //            console.log('Object updated successfully');
    //        },
    //        error: function () {
    //            console.error('Error occurred while removing object');
    //        }
    //    });
    //}

    //function decreaseQuantity(dishId) {
    //    $.ajax({
    //        url: '/Dish/DecreaseDishQuantity',
    //        type: 'GET',
    //        data: {
    //            dishId: dishId
    //        },

    //        success: function () {
    //            console.log('Object quantity decreased successfully');
    //        },

    //        error: function () {
    //            console.error('Érror occurred while removing object')
    //        }
    //    });
    //}
    function updateQuantity(quantityInput) {

        var productRow = $(quantityInput).parent().parent();
        var price = parseFloat(productRow.children('.product-price').text());
        var quantity = $(quantityInput).val();
        var linePrice = price * quantity;

        productRow.children('.product-line-price').each(function () {
            $(this).fadeOut(fadeTime, function () {
                $(this).text(linePrice.toFixed(2));
                recalculateCart();
                $(this).fadeIn(fadeTime);
            });
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
