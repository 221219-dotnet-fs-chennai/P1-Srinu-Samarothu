let mailID = localStorage.getItem("Email");

    fetch("https://localhost:44387/api/TrainerContact/Get?" + new URLSearchParams({Email : mailID}), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then((data) => {

          let email = document.getElementById("email");
          email.value = mailID;

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

          let semail = document.getElementById("semail");
          semail.value = data.mailId;
      })
      .catch(error => console.log(error));




      let mobilebtn = document.getElementById("mobilebtn");
      mobilebtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      let addressbtn = document.getElementById("addressbtn");
      addressbtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      let citybtn = document.getElementById("citybtn");
      citybtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      let statebtn = document.getElementById("statebtn");
      statebtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });

      let zipbtn = document.getElementById("zipbtn");
      zipbtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });

      let emailbtn = document.getElementById("emailbtn");
      emailbtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      
      
      
      function Updatemobile() {
          let mobile = document.getElementById('mobile');
          mobile.removeAttribute("readonly");
          mobile.style.borderBottomColor = 'black';
          mobile.style.color = 'red';
      }
      
      function Updateaddress() {
          let address = document.getElementById('address');
          address.removeAttribute("readonly");
          address.style.borderBottomColor = 'black';
          address.style.color = 'red';
      }
      
      function Updatecity() {
          let city = document.getElementById('city');
          city.removeAttribute("readonly");
          city.style.borderBottomColor = 'black';
          city.style.color = 'red';
      }
      function Updatestate() {
          let state = document.getElementById('state');
          state.removeAttribute("readonly");
          state.style.borderBottomColor = 'black';
          state.style.color = 'red';
      }

      function Updatezip() {
          let zipcode = document.getElementById('zipcode');
          zipcode.removeAttribute("readonly");
          zipcode.style.borderBottomColor = 'black';
          zipcode.style.color = 'red';
      }
      
      function Updateemail() {
          let semail = document.getElementById('semail');
          semail.removeAttribute("readonly");
          semail.style.borderBottomColor = 'black';
          semail.style.color = 'red';
      }
       
      
      
      
      
      function UpdateContact() {
          
          let changesbtn = document.getElementById("changes");
          changesbtn.addEventListener('submit', event => {
              if (event)
              event.preventDefault();
          })
      
          let Mobile = document.getElementById('mobile').value;
              
          let Address = document.getElementById('address').value;
      
          let City = document.getElementById('city').value;
      
          let State = document.getElementById('state').value;

          let Zipcode = document.getElementById('zipcode').value;

          let Semail = document.getElementById('semail').value;

      
              fetch("https://localhost:44387/api/TrainerContact/Modify?" + new URLSearchParams({ Email: mailID }), {
                  method: "PUT",
                  body: JSON.stringify({
                    mobileNumber : +Mobile,
                    addressLane : Address,
                    city : City,
                    state : State,
                    zipcode : Zipcode,
                    tid : 0,
                    mailId: Semail
                  }),
                  headers: {
                      "Content-type": "application/json"
                  }
              }).then(response => {
                  if(response.status == 200 || response.status == 204) {
                    alert("Updated successfully");
                    window.location.href = "Profile.html"
                  }
                  else{
                    alert("Something went wrong..\n check your password");
                  }
                })
              .catch(error => console.log(error))
      }