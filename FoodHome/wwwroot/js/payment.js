$(document).ready(function () {

    $('#name').change(function () {
        var name = $('#name').val();

        document.getElementById('nameCard').textContent = name;
    });

    $('#cardNum').change(function () {
        var num = $('#cardNum').val();

        document.getElementById('num').textContent = num;
    });

    $('#expDate').change(function () {
        var date = $('#expDate').val();

        document.getElementById('exp').textContent = 'EXP' + date;
    });
    
    $('#cvcInp').change(function () {
        var cvc = $('#cvcInp').val();

        document.getElementById('cvc').textContent = 'CVC' + cvc;
    });


})