+ function ($) {
    $('.palceholder').click(function () {
        $(this).siblings('input').focus();
    });

    $('.form-control').focus(function () {
        $(this).parent().addClass("focused");
    });

    $('.form-control').blur(function () {
        var $this = $(this);
        if ($this.val().length == 0)
            $(this).parent().removeClass("focused");
    });
    $('.form-control').blur();

    // validetion
    //$.validator.setDefaults({
    //    errorElement: 'span',
    //    errorClass: 'validate-tooltip'
    //});

    //$("#formvalidate").validate({
    //    rules: {
    //        UserName: {
    //            required: true,
    //            minlength: 6
    //        },
    //        Password: {
    //            required: true,
    //            minlength: 6
    //        }
    //    },
    //    messages: {
    //        UserName: {
    //            required: "Please enter your username.",
    //            minlength: "Please provide valid username."
    //        },
    //        Password: {
    //            required: "Enter your password to Login.",
    //            minlength: "Incorrect login or password."
    //        }
    //    }
    //});

}(jQuery);