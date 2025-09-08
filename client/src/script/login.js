document.addEventListener("DOMContentLoaded", function() {
    verifyLogin();
});

document.querySelector('#login-submit').addEventListener('click', async () => {
    const email = document.querySelector('#email-input').value
    const password = document.querySelector('#password-input').value 

    console.log(password)

    const login = {
        Email: email,
        Password: password
    }

    try{
        const response = await fetch('https://localhost:7020/api/Auth/Login',{
            method: 'Post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(login)
        });

        if (!response.ok) {
            const errorText = await response.text();
            console.error('Erro do servidor:', errorText);
            throw new Error(`Erro ${response.status}: ${errorText}`);
        }

        const responseData = await response.json();
        localStorage.setItem("Token", responseData.token);

        window.location.href = "dashboard.html";
    }
    catch(error){
        console.error('Login error', error);
    }

})