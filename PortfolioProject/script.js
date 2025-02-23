document.addEventListener("DOMContentLoaded", function () {
    // Toggle mobile navigation menu
    function toggleMenu() {
        const navMenu = document.querySelector("nav ul");
        navMenu.classList.toggle("active");
    }

    const menuToggle = document.querySelector(".menu-toggle");
    if (menuToggle) {
        menuToggle.addEventListener("click", toggleMenu);
    }

    // Smooth scrolling for navigation links
    document.querySelectorAll("nav ul li a").forEach(anchor => {
        anchor.addEventListener("click", function (event) {
            event.preventDefault();
            const targetId = this.getAttribute("href").substring(1);
            const targetElement = document.getElementById(targetId);

            if (targetElement) {
                window.scrollTo({
                    top: targetElement.offsetTop - 20,
                    behavior: "smooth"
                });
            }
        });
    });

    // Filter projects by category
    function filterProjects(category) {
        const projects = document.querySelectorAll("#projects article");
        projects.forEach(project => {
            if (category === "all" || project.classList.contains(category)) {
                project.style.display = "block";
            } else {
                project.style.display = "none";
            }
        });
    }

    document.querySelectorAll(".filter-btn").forEach(button => {
        button.addEventListener("click", function () {
            const category = this.getAttribute("data-category");
            filterProjects(category);
        });
    });

    // Lightbox effect for project images
    const lightbox = document.createElement("div");
    lightbox.id = "lightbox";
    document.body.appendChild(lightbox);

    const images = document.querySelectorAll("#projects figure img");
    images.forEach(image => {
        image.addEventListener("click", function () {
            lightbox.classList.add("active");
            const img = document.createElement("img");
            img.src = this.src;
            while (lightbox.firstChild) {
                lightbox.removeChild(lightbox.firstChild);
            }
            lightbox.appendChild(img);
        });
    });

    lightbox.addEventListener("click", function () {
        lightbox.classList.remove("active");
    });

    // Contact form validation
    const form = document.querySelector("#contact-form");
    if (form) {
        form.addEventListener("submit", function (event) {
            event.preventDefault();
            let isValid = true;

            const name = document.querySelector("#name");
            const email = document.querySelector("#email");
            const message = document.querySelector("#message");

            function showError(input, message) {
                const errorSpan = input.nextElementSibling;
                errorSpan.textContent = message;
                errorSpan.style.color = "red";
            }

            function clearError(input) {
                const errorSpan = input.nextElementSibling;
                errorSpan.textContent = "";
            }

            if (name.value.trim() === "") {
                showError(name, "Name is required");
                isValid = false;
            } else {
                clearError(name);
            }

            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(email.value.trim())) {
                showError(email, "Valid email is required");
                isValid = false;
            } else {
                clearError(email);
            }

            if (message.value.trim() === "") {
                showError(message, "Message cannot be empty");
                isValid = false;
            } else {
                clearError(message);
            }

            if (isValid) {
                form.submit();
            }
        });
    }
});
