var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = '/tiep-tuc-mua';
        });
        $('#btnContinue_not_login').off('click').on('click', function () {
            window.location.href = '/Home/Index';
        });

        $('#btnDeleteAll').off('click').on('click', function () {


            $.ajax({
                url: '/ThucDon/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/ThucDon/Index';
                    }
                }
            })
        });
       

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/ThucDon/Index';
                    }
                }
            })
        });

        $('a[href="#sign_up"]').click(function (e) {
            alert('Sign new href executed.');
            event.stopPropagation();
            if (window.confirm('Really go to another page?')) {
                window.location.href = '/Login/Login/'
            }
            else {
                e.preventDefault();
            }
        });


    }
}
cart.init();