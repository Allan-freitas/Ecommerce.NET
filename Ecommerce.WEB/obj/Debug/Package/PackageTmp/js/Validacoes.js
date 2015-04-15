function ValidaEmail(obj) {
    email = obj.value;
    delim = ''
    p = ''
    if (obj.value != '') {
        for (i = 0; i <= email.length; i++) {

            if (email.charAt(0) == '.' || email.charAt(0) == '@') { alerta("Digite o email corretamente.", obj); return false; }
            if (email.charAt(i) == '@') {
                delim = '@'
                if (email.charAt(i) == '@' && email.charAt(i + 1) == '.') { alerta("Digite o email corretamente.", obj); return false; }
            }

            if (delim == '@') {
                if (email.charAt(i) == '.') {
                    p = p + 1
                    if (email.charAt(i + 1) == '') { alerta("Digite o email corretamente.", obj); return false; }
                    if (email.charAt(i) == '.' && email.charAt(i + 1) == '.') { alerta("Digite o email corretamente.", obj); return false; }
                }
            }


            if (email.charAt(i) == ';' ||
            email.charAt(i) == ',' ||
            email.charAt(i) == '*' ||
            email.charAt(i) == ']' ||
            email.charAt(i) == '[' ||
            email.charAt(i) == '(' ||
            email.charAt(i) == ')' ||
            email.charAt(i) == '/' ||
            email.charAt(i) == '|' ||
            email.charAt(i) == '´' ||
            email.charAt(i) == '^' ||
            email.charAt(i) == '+' ||
            email.charAt(i) == '?' ||
            email.charAt(i) == '~' ||
            email.charAt(i) == '-' ||
            email.charAt(i) == '¨' ||
            email.charAt(i) == '*' ||
            email.charAt(i) == '!'
           ) { alerta("Digite o email corretamente.", obj); return false; }
        }

        if (delim == '') { alerta("Digite o email corretamente.", obj); return false; }
        if (p == '') { alerta("Digite o email corretamente.", obj); return false; }
    }
}

function alerta(obj, campo) {
    alert(obj);
    campo.value = '';
    campo.focus;
    return false;
}

function ValidaCnpj(campo) {
    if (campo.value != '') {
        pri = campo.value.substring(0, 2);
        seg = campo.value.substring(3, 6);
        ter = campo.value.substring(7, 10);
        qua = campo.value.substring(11, 15);
        qui = campo.value.substring(16, 18);

        var i;
        var campo;
        var situacao = '';

        campo = (pri + seg + ter + qua + qui);

        s = campo;

        c = s.substr(0, 12);
        var dv = s.substr(12, 2);
        var d1 = 0;

        for (i = 0; i < 12; i++) {
            d1 += c.charAt(11 - i) * (2 + (i % 8));
        }

        if (d1 == 0) {
            var result = "falso";
        }
        d1 = 11 - (d1 % 11);

        if (d1 > 9) d1 = 0;

        if (dv.charAt(0) != d1) {
            var result = "falso";
        }

        d1 *= 2;
        for (i = 0; i < 12; i++) {
            d1 += c.charAt(11 - i) * (2 + ((i + 1) % 8));
        }

        d1 = 11 - (d1 % 11);
        if (d1 > 9) d1 = 0;

        if (dv.charAt(1) != d1) {
            var result = "falso";
        }

        if (result == "falso") {
            alerta("CNPJ invalido", campo);
        }
    }
}

function ValidaCpf(campo) {
    if (campo.value != '') {
        var cpf = campo.value
        var filtro = /^\d{3}.\d{3}.\d{3}-\d{2}$/i;
        if (!filtro.test(cpf)) {
            alerta("CPF invalido.", campo);
        }

        cpf = remove(cpf, ".");
        cpf = remove(cpf, "-");

        if (cpf.length != 11 || cpf == "00000000000" || cpf == "11111111111" ||
	  cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" ||
	  cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" ||
	  cpf == "88888888888" || cpf == "99999999999") {
            alerta("CPF inválido. Tente novamente.", campo);

        }

        soma = 0;
        for (i = 0; i < 9; i++)
            soma += parseInt(cpf.charAt(i)) * (10 - i);
        resto = 11 - (soma % 11);
        if (resto == 10 || resto == 11)
            resto = 0;
        if (resto != parseInt(cpf.charAt(9))) {
            alerta("CPF invalido.", campo);
        }
        soma = 0;
        for (i = 0; i < 10; i++)
            soma += parseInt(cpf.charAt(i)) * (11 - i);
        resto = 11 - (soma % 11);
        if (resto == 10 || resto == 11)
            resto = 0;
        if (resto != parseInt(cpf.charAt(10))) {
            alerta("CPF invalido.", campo);
        }
        return true;
    }
}

function remove(str, sub) {
    i = str.indexOf(sub);
    r = "";
    if (i == -1) return str;
    r += str.substring(0, i) + remove(str.substring(i + sub.length), sub);
    return r;
}


function ValidaRg(campo) {
    if (campo.value != '') {
        campo = remove(campo.value, ".");
        campo = remove(campo, "-");
        tamanho = campo.length;
        vetor = new Array(tamanho);

        if (tamanho >= 1) {
            vetor[0] = parseInt(campo[0]) * 2;
        }
        if (tamanho >= 2) {
            vetor[1] = parseInt(campo[1]) * 3;
        }
        if (tamanho >= 3) {
            vetor[2] = parseInt(campo[2]) * 4;
        }
        if (tamanho >= 4) {
            vetor[3] = parseInt(campo[3]) * 5;
        }
        if (tamanho >= 5) {
            vetor[4] = parseInt(campo[4]) * 6;
        }
        if (tamanho >= 6) {
            vetor[5] = parseInt(campo[5]) * 7;
        }
        if (tamanho >= 7) {
            vetor[6] = parseInt(campo[6]) * 8;
        }
        if (tamanho >= 8) {
            vetor[7] = parseInt(campo[7]) * 9;
        }
        if (tamanho >= 9) {
            vetor[8] = parseInt(campo[8]) * 100;
        }

        total = 0;

        if (tamanho >= 1) {
            total += vetor[0];
        }
        if (tamanho >= 2) {
            total += vetor[1];
        }
        if (tamanho >= 3) {
            total += vetor[2];
        }
        if (tamanho >= 4) {
            total += vetor[3];
        }
        if (tamanho >= 5) {
            total += vetor[4];
        }
        if (tamanho >= 6) {
            total += vetor[5];
        }
        if (tamanho >= 7) {
            total += vetor[6];
        }
        if (tamanho >= 8) {
            total += vetor[7];
        }
        if (tamanho >= 9) {
            total += vetor[8];
        }

        resto = total % 11;

        if (resto != 0)
            alerta("RG invalido.", campo);

    }
}