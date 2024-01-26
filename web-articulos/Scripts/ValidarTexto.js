const txtEmail = document.getElementById('txtEmail');
const mensajeEmail = document.getElementById('mensajeEmail');
const txtCodigo = document.getElementById('txtCodigo');
const mensajeCodigo = document.getElementById('mensajeCodigo');
const txtPrecio = document.getElementById('txtPrecio');
const mensajePrecio = document.getElementById('mensajePrecio');
const textBoxArray = document.querySelectorAll('.cajasTexto');
const mensajesTxt = document.querySelectorAll(".mensajesTextBox");
const expressionMail = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
const expressionPrecio = /^\d+(\,\d{1,2})?$/;
const expressionCodigo = /^[A-Z]\d+$/;

function validar() {
    let hayTextoVacio = false;
    for (var i = 0; i < textBoxArray.length; i++) {
        if (textBoxArray[i].value === "") {
            textBoxArray[i].classList.add("is-invalid");
            mensajesTxt[i].classList.add("invalid-feedback");
            mensajesTxt[i].innerHTML = "El texto está vacío";
            hayTextoVacio = true;
        } else {
            textBoxArray[i].classList.remove("is-invalid");
            mensajesTxt[i].classList.remove("invalid-feedback");
            mensajesTxt[i].innerHTML = "";
        }
    }

    if (hayTextoVacio) {
        return false;
    }

    if (txtEmail != null) {
        if (!expressionMail.test(txtEmail.value)) {
            txtEmail.classList.add("is-invalid");
            mensajeEmail.classList.add("invalid-feedback");
            mensajeEmail.innerHTML = "El correo electrónico no es válido";
            return false;
        }
        mensajeEmail.classList.remove("invalid-feedback");
        mensajeEmail.innerHTML = "";
        txtEmail.classList.remove("is-invalid");
    }

    if (txtCodigo != null) {
        if (!expressionCodigo.test(txtCodigo.value)) {
            txtCodigo.classList.add("is-invalid");
            mensajeCodigo.classList.add("invalid-feedback");
            mensajeCodigo.innerHTML = "El formato del código no es válido";
            return false;
        }
        mensajeCodigo.classList.remove("invalid-feedback");
        mensajeCodigo.innerHTML = "";
        txtCodigo.classList.remove("is-invalid");
    }

    if (txtPrecio != null) {
        if (!expressionPrecio.test(txtPrecio.value)) {
            txtPrecio.classList.add("is-invalid");
            mensajePrecio.classList.add("invalid-feedback");
            mensajePrecio.innerHTML = "Solo números y separar con comas decimales";
            return false;
        }
        mensajePrecio.classList.remove("invalid-feedback");
        mensajePrecio.innerHTML = "";
        txtPrecio.classList.remove("is-invalid");
    }


    return true;
}