function verifyLogin(){
    const token = localStorage.getItem('Token');

    if(token){
        window.location.href = 'dashboard.html';
    }
}

function verifyLogout(){
    const token = localStorage.getItem('Token');

    if(token == null){
        window.location.href = 'index.html'
    }
}