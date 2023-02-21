let mailID = localStorage.getItem("Email");

    fetch("https://localhost:44387/api/Education/Get?" + new URLSearchParams({Email : mailID}), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then((data) => {
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