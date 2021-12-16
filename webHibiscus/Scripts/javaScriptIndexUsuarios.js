function myFunction() {

    var input, filter, table, tr, primerNombre, primerApellido, correo, i, txtValue;
    input = document.getElementById("busquedaNombre");
    filter = input.value.toUpperCase();
    table = document.getElementById("tablaUsuarios");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {

        primerNombre = tr[i].getElementsByTagName("td")[0];
        primerApellido = tr[i].getElementsByTagName("td")[1];
        correo = tr[i].getElementsByTagName("td")[4];

        if (correo) {

            txtValue = (primerNombre.textContent || primerNombre.innerText)
                + (primerApellido.innerText || primerApellido.textContent)
                + (correo.innerText || correo.textContent);

            console.log(primerNombre.textContent || primerNombre.innerText);

            if (txtValue.toUpperCase().indexOf(filter) > -1) {

                tr[i].style.display = "";

            } else {

                tr[i].style.display = "none";

            } //Fin del else.

        } //Fin del if.

    } //Fin del for. 

} //Fin de busqueda de usuarios.

