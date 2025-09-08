async function createUser(){
    const name = document.querySelector('#name-input').value;
    const city = document.querySelector('#city-input').value;
    const email = document.querySelector('#email-input').value;
    const age = document.querySelector('#age-input').value;
    const password = document.querySelector('#password-input').value;
    const admin = document.querySelector('#admin-input').value;

    const newProfile = {
        Name: name,
        City: city,
        Email: email,
        Age: age,
        Password: password,
        Adim: admin
    }

    try {
        const response = await fetch('https://localhost:7020/api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newProfile)
        });

        if (!response.ok) {
            const errorText = await response.text();
            console.error('Erro do servidor:', errorText);
            throw new Error(`Erro ${response.status}: ${errorText}`);
        }

        toggleCreateModal();
    }
    catch (error){
        console.error('Create user error', error);
    }
}