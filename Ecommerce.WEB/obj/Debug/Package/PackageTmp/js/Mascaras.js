function MascaraTelefone(tel) {
    if (mascaraInteiro(tel) == false) {
        event.returnValue = false;
    }
    return formataCampo(tel, '(00) 0000-0000', event);
}

function MascaraTelefoneComDdd(obj) {
    var mask;
    mask = obj.value;

    if (mask.length == 1) { mask = '(' + mask; }
    if (mask.length == 3) { mask = mask + ')'; }
    if (mask.length == 4) { mask = mask + " "; }
    if (mask.length == 9) { mask = mask + '-'; }

    obj.value = mask;
}

function MascaraTelefoneSemDdd(obj) {
    var mask;
    mask = obj.value;
    
    if (mask.length == 4) { mask = mask + '-'; }

    obj.value = mask;
}

function MascaraTelefone(obj) {
    var mask;
    mask = obj.value;

    if (mask.length == 0)
        mask = '(' + mask;

    if (mask.length == 3)
        mask = mask + ')';

    if (mask.length == 8)
        mask = mask + '-';

    obj.value = mask;
}

function MascaraCep(obj) {
    var mask;
    mask = obj.value;

    if (mask.length == 5) { mask = mask + '-'; }

    obj.value = mask;
}

function MascaraData(obj) {
    var mask;
    mask = obj.value;

    if (mask.length == 2) { mask = mask + '/'; }
    if (mask.length == 5) { mask = mask + '/'; }

    obj.value = mask;
}

function MascaraCnpj(obj) {
    var mask;
    mask = obj.value;

    if (mask.length == 2) { mask = mask + '.'; }
    if (mask.length == 6) { mask = mask + '.'; }
    if (mask.length == 10) { mask = mask + '/'; }
    if (mask.length == 15) { mask = mask + '-'; }

    obj.value = mask;
}

function MascaraCpf(obj) {
    var mask;
    mask = obj.value;

    if (mask.length == 3) { mask = mask + '.'; }
    if (mask.length == 7) { mask = mask + '.'; }
    if (mask.length == 11) { mask = mask + '-'; }
    
    obj.value = mask;
}

function MascaraRg(obj) {
    var mask;
    mask = obj.value;

    if (mask.length == 2) { mask = mask + '.'; }
    if (mask.length == 6) { mask = mask + '.'; }
    if (mask.length == 10) { mask = mask + '-'; }

    obj.value = mask;
}