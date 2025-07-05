function inicializarEventosEdicion() {
    document.querySelectorAll('.btn-editar').forEach(function (boton) {
        boton.addEventListener('click', function () {
            const fila = this.closest('tr');
            const celdas = fila.querySelectorAll('td');

            const id = this.dataset.id;

            const nombre = celdas[1].innerText.trim();
            const fecha = celdas[2].innerText.trim();
            const email = celdas[3].innerText.trim();
            const telefono = celdas[4].innerText.trim();

            document.getElementById('idUsuarioEditar').value = id;
            document.getElementById('Nombre').value = nombre;
            document.getElementById('fechaingreso').value = fecha;
            document.getElementById('email').value = email;
            document.getElementById('telefono').value = telefono;

            console.log("🛠️ Datos cargados en el modal:", { id, nombre, fecha, email, telefono });
        });
    });
}
