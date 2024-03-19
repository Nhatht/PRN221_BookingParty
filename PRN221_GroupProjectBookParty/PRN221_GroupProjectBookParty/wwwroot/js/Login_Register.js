const container = document.getElementById('container');
const registerBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');

registerBtn.addEventListener('click', () => {
    container.classList.add("active");
});

loginBtn.addEventListener('click', () => {
    container.classList.remove("active");
});
document.getElementById('emailInput').addEventListener('input', function () {
    var emailAlert = document.getElementById('emailAlert');
    if (emailAlert) {
        emailAlert.style.display = 'none';
    }
});