document.addEventListener("DOMContentLoaded", function () {
    const submenus = document.querySelectorAll(".submenu > a");

    submenus.forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault();
            const parentLi = this.parentElement;
            parentLi.classList.toggle("open");
        });
    });
});