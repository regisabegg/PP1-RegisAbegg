$(document).ready(function () {
    $(document).on('change', '.btn-file :file', function () {
        var input = $(this),
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [label]);
    });

    $('.btn-file :file').on('fileselect', function (event, label) {

        var input = $(this).parents('.input-group').find(':text'),
            log = label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#img-upload').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $("#ImageUpload").change(function () {
        readURL(this);
    });
});


var PhoneMask = function (input) {
    input.unmask();
    var fone = input.val().replace(/\D/g, '');
    if (fone.length <= 10) {
        input.mask("(99) 9999-9999?9");
    } else {
        input.mask("(99) 99999-999?9");
    }
};

// adiciona a funcionalidade de mascara a todos inputs com atributo [mask]
var mask = function () {
    $('input[mask]').each(function () {
        $(this).mask($(this).attr('mask'));
    });
};
$('input[mask]').each(function () {
    $(this).mask($(this).attr('mask'));
});

$('input.mask.fone').each(function () {
    PhoneMask($(this));
})
    .focusout(function () {
        PhoneMask($(this));
    });

