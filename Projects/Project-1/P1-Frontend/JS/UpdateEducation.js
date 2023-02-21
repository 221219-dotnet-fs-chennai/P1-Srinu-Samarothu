let mailID = localStorage.getItem("Email");

    fetch("https://localhost:44387/api/Education/Get?" + new URLSearchParams({Email : mailID}), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then((data) => {

          let email = document.getElementById("email");
          email.value = mailID;

          let UGclg = document.getElementById("UGclg");
          UGclg.value = data.ugCollege;

          let UGper = document.getElementById("UGper");
          UGper.value = data.ugPercentage;

          let UGpy = document.getElementById("UGpy");
          UGpy.value = data.ugPassoutYear;

          let PGclg = document.getElementById("PGclg");
          PGclg.value = data.pgCollege;

          let PGper = document.getElementById("PGper");
          PGper.value = data.pgPercentage;

          let PGpy = document.getElementById("PGpy");
          PGpy.value = data.pgPassoutYear;
      })
      .catch(error => console.log(error));




      let ugclgbtn = document.getElementById("ugclgbtn");
      ugclgbtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      let ugperbtn = document.getElementById("ugperbtn");
      ugperbtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      let ugpybtn = document.getElementById("ugpybtn");
      ugpybtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      let pgclgbtn = document.getElementById("pgclgbtn");
      pgclgbtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });

      let pgperbtn = document.getElementById("pgperbtn");
      pgperbtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });

      let pgpybtn = document.getElementById("pgpybtn");
      pgpybtn.addEventListener('click', event => {
          if(event)
              event.preventDefault();
      });
      
      
      
      
      function UpdateUgclg() {
          let UGclg = document.getElementById('UGclg');
          UGclg.removeAttribute("readonly");
          UGclg.style.borderBottomColor = 'black';
          UGclg.style.color = 'red';
      }
      
      function UpdateUgper() {
          let UGper = document.getElementById('UGper');
          UGper.removeAttribute("readonly");
          UGper.style.borderBottomColor = 'black';
          UGper.style.color = 'red';
      }
      
      function UpdateUgpy() {
          let UGpy = document.getElementById('UGpy');
          UGpy.removeAttribute("readonly");
          UGpy.style.borderBottomColor = 'black';
          UGpy.style.color = 'red';
      }
      function UpdatePgclg() {
          let PGclg = document.getElementById('PGclg');
          PGclg.removeAttribute("readonly");
          PGclg.style.borderBottomColor = 'black';
          PGclg.style.color = 'red';
      }

      function UpdatePgper() {
          let PGper = document.getElementById('PGper');
          PGper.removeAttribute("readonly");
          PGper.style.borderBottomColor = 'black';
          PGper.style.color = 'red';
      }
      
      function UpdatePgpy() {
          let PGpy = document.getElementById('PGpy');
          PGpy.removeAttribute("readonly");
          PGpy.style.borderBottomColor = 'black';
          PGpy.style.color = 'red';
      }
       
      
      
      
      
      function UpdateEducation() {
          
          let changesbtn = document.getElementById("changes");
          changesbtn.addEventListener('submit', event => {
              if (event)
              event.preventDefault();
          })
      
          let UGclg = document.getElementById('UGclg').value;
              
          let UGper = document.getElementById('UGper').value;
      
          let UGpy = document.getElementById('UGpy').value;
      
          let PGclg = document.getElementById('PGclg').value;

          let PGper = document.getElementById('PGper').value;

          let PGpy = document.getElementById('PGpy').value;

      
              fetch("https://localhost:44387/api/Education/Modify?" + new URLSearchParams({ Email: mailID }), {
                  method: "PUT",
                  body: JSON.stringify({
                    ugCollege : UGclg,
                    ugPercentage : +UGper,
                    ugPassoutYear : +UGpy,
                    pgCollege : PGclg,
                    pgPercentage : +PGper,
                    pgPassoutYear : +PGpy,
                    tid : 0
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
                    alert("Something went wrong..\n");
                  }
                })
              .catch(error => console.log(error))
      }