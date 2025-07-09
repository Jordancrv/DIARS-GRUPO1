document.addEventListener("DOMContentLoaded", function () {
    // Sidebar toggle
    const toggleBtn = document.getElementById("sidebarToggle");
    const sidebar = document.getElementById("sidebar");

    if (toggleBtn && sidebar) {
        toggleBtn.addEventListener("click", function () {
            sidebar.classList.toggle("collapsed");
        });
    }

    // Carga dinámica de vistas parciales
    const links = document.querySelectorAll(".cargar-vista");

    links.forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault();
            const url = this.getAttribute("data-url");

            fetch(url)
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Error en la respuesta del servidor.");
                    }
                    return response.text();
                })
                .then(html => {
                    const contenedor = document.getElementById("contenido-dinamico");
                    if (contenedor) {
                        contenedor.innerHTML = html;
                    } else {
                        console.warn("No se encontró el contenedor 'contenido-dinamico'.");
                    }
                })
                .catch(err => {
                    console.error("Error al cargar vista:", err);
                });
        });
    });
});
