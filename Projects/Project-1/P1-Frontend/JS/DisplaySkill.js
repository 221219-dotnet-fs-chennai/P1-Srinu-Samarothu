let mailID = localStorage.getItem("Email");


    fetch("https://localhost:44387/api/Skills/GetAll?" + new URLSearchParams({Email : mailID}), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then(data => {
        localStorage.setItem("flag", true);
        let i=1;
        data.forEach(element => {
            
            let parentDiv = document.getElementById('tdiv');
            let childDiv = document.createElement('div');

            childDiv.innerHTML = `<br>
            <h5 style="color: rgba(0,0,0,0.5);">&emsp;<b>Skill-${i}</b></h5>
            <br>
            <!-- <form class="tForm"> -->
              <div class="mb-3 row">
                <label for="staticEmail" class="col-sm-4 col-form-label">&emsp;&emsp;Company</label>
                <div class="col-sm-5 ipicon">
                  <input type="text" readonly class="form-control-plaintext forminput" value="${element.skill1}" id="company">
                </div>
                
              </div>
              <div class="mb-3 row">
                <label for="staticEmail" class="col-sm-4 col-form-label">&emsp;&emsp;Proficiency</label>
                <div class="col-sm-5">
                  <input type="text" readonly class="form-control-plaintext forminput" value="${element.proficiency}" id="role">
                </div>
              </div>`

              parentDiv.appendChild(childDiv);
              i++;
        });
      })
      .catch(error => console.log(error));