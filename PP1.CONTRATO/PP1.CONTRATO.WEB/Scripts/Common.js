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

/*******************************************************************************
* Escritas em CAIXA ALTA
*******************************************************************************/
$("input, textarea, file").css('text-transform', 'uppercase').blur(function () { this.value = this.value.toUpperCase(); });


var IsNullOrEmpty = function (value) {
    return (!value || (value) == '' || value == null);
};


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
// adiciona a funcionalidade de foco a todos inputs com atributo [autofocus]
this.autofocus = function () {
    $('input[autofocus]').focus();
};

// remove a funcionalidade mascara para o elemento informado
this.unmask = function ($input) {
    if ($input instanceof jQuery) {
        $input.val($input.val().replace(/[\s\-\.\/\(\)]/g, ''));
    }
    else {
        return $input.replace(/[\s\-\.\/\(\)]/g, '');
    }
};

$('.currency').each(function () {

    var aSep = $(this).attr('asep');
    var aDec = $(this).attr('adec');
    var vMin = $(this).attr('vmin');
    var vMax = $(this).attr('vmax');
    var mDec = $(this).attr('mdec');
    var metod = $(this).attr('metod');

    vMin = IsNullOrEmpty(vMin) ? '0' : vMin;
    vMax = IsNullOrEmpty(vMax) ? '9999999999.99999' : vMax;
    aSep = aSep == null ? '.' : aSep;
    aDec = IsNullOrEmpty(aDec) ? ',' : aDec;
    mDec = IsNullOrEmpty(mDec) ? '2' : mDec;
    metod = IsNullOrEmpty(metod) ? "init" : metod;

    $(this).autoNumeric(metod, {
        aSep: aSep,
        aDec: aDec,
        vMin: vMin,
        vMax: vMax,
        mDec: mDec,
    }).css('text-align', 'right');;
});

$(".taxa").autoNumeric('init', {
    aSep: '.',
    aDec: ',',
    nBracket: '(,)',
    vMin: -999.99,
    vMax: 999.99
});

$(".peso").autoNumeric('init', {
    aSep: '.',
    aDec: ',',
    nBracket: '(,)',
    vMin: 0,
    mDec: 3,
    vMax: 199.99
});

$(".integer").autoNumeric('init', {
    vMin: 0,
    vMax: 9999999,
    mDec: 0,
    aSep: ''
});



// exibe funcionalidade de contador de caracteres a todos elementos textarea com o atributo [maxlength]
$('textarea[maxlength]:not([data-counter=true])').each(function () {

    var defaults = {};
    defaults.goal = $(this).attr('maxlength');
    defaults.text = ($(this).attr('data-textarea-label') || true).toString().toLowerCase() === 'true';
    defaults.type = $(this).attr('data-textarea-type');
    defaults = $.extend({ type: 'char' }, defaults);
    $(this).attr('data-counter', true).counter(defaults);
});

var NumberFormat = function (value, mDec) {

    aSep = '.';
    aDec = ',';
    mDec = IsNullOrEmpty(mDec) ? 2 : mDec;

    var n = value;
    var prec = mDec;
    n = !isFinite(+n) ? 0 : +n;
    prec = !isFinite(+prec) ? 0 : Math.abs(prec);
    var sep = aSep;
    var dec = aDec;

    var s = (prec > 0) ? n.toFixed(prec) : Math.round(n).toFixed(prec);

    var abs = Math.abs(n).toFixed(prec);
    var _, i;

    if (abs >= 1000) {
        _ = abs.split(/\D/);
        i = _[0].length % 3 || 3;

        _[0] = s.slice(0, i + (n < 0)) +
            _[0].slice(i).replace(/(\d{3})/g, sep + '$1');

        s = _.join(dec);
    } else {
        s = s.replace('.', dec);
    }
    return s;
};

var ParseFloat = function (str) {

    if (window.IsNullOrEmpty(str)) {
        return 0;
    }
    if (!isNaN(str)) {
        var value = parseFloat(str);
        return value;
    }
    str = str.split(".").join("");
    str = str.split(",").join(".");

    var value = parseFloat(str);
    value = isNaN(value) ? 0 : value;
    return value;
};


/*******************************************************************************
*BUSCAR CEP
*******************************************************************************/


$(document).ready(function () {
   
    function limpa_formulário_cep() {
        // Limpa valores do formulário de cep.
        $("#nmLogradouro").val("");
        $("#nmBairro").val("");
        $("#nrCEP").val("");
    }

    //Quando o campo cep perde o foco.
    $("#nrCEP").on('change', function () {
        alert();
        //$(document).on('change', 

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#nmLogradouro").val("...");
                $("#nmBairro").val("...");
                //$("#cidade").val("...");
                //$("#uf").val("...");
                //$("#ibge").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#nmLogradouro").val(dados.logradouro);
                        $("#nmBairro").val(dados.bairro);
                        //$("#cidade").val(dados.localidade);
                        //$("#uf").val(dados.uf);
                        //$("#ibge").val(dados.ibge);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});

