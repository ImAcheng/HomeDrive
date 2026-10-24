document.querySelectorAll(".button").forEach(button => {
    button.addEventListener("click", () => {
        openPage(button.dataset.page);
    });
});

function openPage(target) {
    document.location.assign(target);
}