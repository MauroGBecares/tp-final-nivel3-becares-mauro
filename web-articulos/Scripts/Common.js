
// CAMBIAR ESTILOS DE LOS CHECKBOX
const listaCheckBox = document.querySelectorAll('input[type="checkbox"]')


function cambiarCheckBox() {
    listaCheckBox.forEach(chk => { chk.classList.add("form-check-input") })
}