document.addEventListener("DOMContentLoaded", function() {
    verifyLogout();
    userList();
});

document.querySelector('.exit').addEventListener('click', () => {
    localStorage.removeItem('Token');
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

async function userList(){
    const table = document.querySelector('.user-list-table');

    const rows = table.querySelectorAll(".table-row-itens");
    rows.forEach(row => row.remove());
    
    try{
        const token = localStorage.getItem('Token');
        const response = await fetch('https://localhost:7020/api/User', {
            method: 'GET',
            headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json',
            }
        })

        if(!response.ok){
            throw{
                status: response.status,
                message: responseData?.message || 'Error loading user list'
            }
        }

        const profiles = await response.json();
        profiles.forEach(profile => {
            const tableRow = document.createElement("tr");
            tableRow.className = "table-row-itens";
            table.appendChild(tableRow);

            const tableName = document.createElement("td");
            tableName.textContent = profile.name;
            tableRow.appendChild(tableName);

            const tableEmail = document.createElement("td");
            tableEmail.textContent = profile.email;
            tableRow.appendChild(tableEmail);

            const tableCity = document.createElement("td");
            tableCity.textContent = profile.city;
            tableRow.appendChild(tableCity);

            const tableAge = document.createElement("td");
            tableAge.textContent = profile.age;
            tableRow.appendChild(tableAge);

            const tableEdit = document.createElement("td");
            const tableEditImg = document.createElement("img");
            tableEditImg.className = "tableEditLink";
            tableEditImg.src = "src/assets/edit.png";
            tableRow.appendChild(tableEdit);
            tableEdit.appendChild(tableEditImg);
        })
    }   
    catch(error){
        console.error("Error loading users", error);
    }
}