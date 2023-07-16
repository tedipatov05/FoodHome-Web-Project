
$(document).ready(function () {
    
   
    var taxRate = 0.05;
    var shippingRate = 5.00;
    var fadeTime = 300;

    $('.shopping-cart').ready(function () {
        updateQuantity($('.product-quantity input'));
        recalculateCart();
    })

   
    $('.product-quantity input').change(function () {
        updateQuantity(this);
    });

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
        fetch(`/Dish/RemoveFromCart/${dishId}`, {
            method: 'GET',
             
        })
            .then(response => {
                if (response.ok) {
                    
                    console.log('Object removed from session.');
                } else {
                    
                    console.error('Error removing object from session.');
                }
            })
            .catch(error => {
                console.error('Error removing object from session:', error);
            });
    }
    
       


    
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
        var id = $("#dishId").val();


        removeObjectFromSession(id);



        productRow.slideUp(fadeTime, function () {
            productRow.remove();
            recalculateCart();
        });
    }

});
