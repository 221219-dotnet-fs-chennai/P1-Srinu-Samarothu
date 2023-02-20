let mailID = localStorage.getItem("Email");

    fetch("https://localhost:44387/api/TrainerContact/Get?" + new URLSearchParams({Email : mailID}), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then((data) => {
          let mobile = document.getElementById("mobile");
          mobile.value = data.mobileNumber;

          let address = document.getElementById("address");
          address.value = data.addressLane;

          let city = document.getElementById("city");
          city.value = data.city;

          let state = document.getElementById("state");
          state.value = data.state;

          let zipcode = document.getElementById("zipcode");
          zipcode.value = data.zipcode;

          let email = document.getElementById("email");
          email.value = data.mailId;
      })
      .catch(error => console.log(error));