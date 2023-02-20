fetch('https://localhost:44387/api/Login/GetAll')
    .then(res => res.json())
    .then(data => console.log(data))