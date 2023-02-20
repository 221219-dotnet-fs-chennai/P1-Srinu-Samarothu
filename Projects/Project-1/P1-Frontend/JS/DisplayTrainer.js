let mailID = localStorage.getItem("Email");

    fetch("https://localhost:44387/api/Trainer/Get?" + new URLSearchParams({Email : mailID}), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then((data) => {
          let f_name = document.getElementById("fname");
          f_name.value = data.firstName;

          let l_name = document.getElementById("lname");
          l_name.value = data.lastName;

          let gen = document.getElementById("gender");
          gen.value = data.gender;

          let dob = document.getElementById("dob");
          dob.value = data.dob;

          let email = document.getElementById("email");
          email.value = data.mail;
      })
      .catch(error => console.log(error));