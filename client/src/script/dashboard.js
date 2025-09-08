document.addEventListener("DOMContentLoaded", function() {
    verifyLogout();
});

document.querySelector('.exit').addEventListener('click', () => {
    window.location.href = "index.html";
});

document.querySelector('.create-user').addEventListener('click', () => {
    toggleCreateModal();
});

document.querySelector('.fade').addEventListener('click', () => {
    toggleCreateModal();
});

document.querySelector('.close-modal').addEventListener('click', () => {
    toggleCreateModal();
})