async function login() {

  const form1 = document.querySelector('.form');
  form1.addEventListener('submit', event => {
    event.preventDefault();

    const formData = new FormData(form1);
    let mail = formData.get('email');
    let pwd = formData.get('password');

    const data = Object.fromEntries(formData);

    console.log(data);

    // - Get - data

    fetch('https://localhost:44387/api/Login/GetUser?' + new URLSearchParams({
      Email: mail,
      Password: pwd
    }), {
      method: "GET",
      headers: {
        'Content-type': "application/json; charset=UTF-8",
      }
    })
      .then((res) => {
        if (res.status == 200) {
          localStorage.setItem("password", pwd);
          localStorage.setItem("email",mail);
          window.location.href = "Profile.html"
        }
        else if (res.status == 400 || res.status == 401) {
          alert("Invalid credentials :\nLogin with proper credentials\nGo to Sign up");
        }
      })
      //.then(data => console.log(data))
      .catch(error => console.log(error));

  });

}