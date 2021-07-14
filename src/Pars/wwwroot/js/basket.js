$(function () {
    getBasket();
});

function updateOrderCard(html) {
    $('#basket-container').html(html);
}

function decreaseBasketItem(productId) {
    $.get('/orderbasket/subtract', { productId })
        .done(function (data) {
            Swal.fire({
                toast: true,
                position: 'top',
                icon: 'success',
                title: 'کم شد',
                showConfirmButton: false,
                timer: 1000
            });
            updateOrderCard(data);
        }).fail(function () {
            Swal.fire({
                position: 'top',
                icon: 'error',
                title: 'خطایی در ارسال اطلاعات به سرور رخ داده است',
                showConfirmButton: false,
                timer: 1000
            });
        });
}

function increaseBasketItem(productId) {
    $.get('/orderbasket/add', { productId })
        .done(function (data) {
            Swal.fire({
                toast: true,
                position: 'top',
                icon: 'success',
                title: 'اضافه شد',
                showConfirmButton: false,
                timer: 1000
            });
            updateOrderCard(data);
        }).fail(function () {
            Swal.fire({
                toast: true,
                position: 'top',
                icon: 'error',
                title: 'خطایی در ارسال اطلاعات به سرور رخ داده است',
                showConfirmButton: false,
                timer: 1000
            });
        });
}

function submitBasket() {
    document.location = '/orderbasket/submit';
}

function clearBasket() {
    $.get('/orderbasket/clear')
        .done(function (data) {
            Swal.fire({
                toast: true,
                position: 'top',
                icon: 'success',
                title: 'حذف شد',
                showConfirmButton: false,
                timer: 1000
            });
            updateOrderCard(data);
        }).fail(function () {
            Swal.fire({
                position: 'top',
                icon: 'error',
                title: 'خطایی در ارسال اطلاعات به سرور رخ داده است',
                showConfirmButton: false,
                timer: 1000
            });
        });
}

function getBasket() {
    $.get('/orderbasket/card')
        .done(function(data) {
            updateOrderCard(data);
        });
}

