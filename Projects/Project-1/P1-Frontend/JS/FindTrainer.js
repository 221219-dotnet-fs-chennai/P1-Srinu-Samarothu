// window.setInterval(function() {
//     var elem = document.getElementById('scrollDiv');
//     elem.scrollTop = elem.scrollHeight;
//   }, 0);



async function SearchBySkill() {


    document.querySelector("#skillbtn").addEventListener("click", () => {
        window.scrollTo(0, 1500);
    })
    
    const skillval = document.getElementById("skill").value;
    console.log(skillval);

    const button = document.getElementById("skillbtn");
    button.addEventListener('submit', (event) => {
        if(event)
            event.preventDefault();

        });
        await fetch('https://localhost:44387/api/Filters/BySkill?' + new URLSearchParams ({
           Skill : skillval
       }), {
           method : 'GET',
           headers : {
               'Content-type' : 'application/json'
           }
        })//.then((res) => {
    //     if(res.status == 200) {
    //         window.location.href="Profile.html"
    //       }
    //       else if(res.status == 400 || res.status == 401) {
    //         alert("Invalid credentials :\nLogin with proper credentials\nGo to Sign up");
    //       }
    //    })
        //  .then(data => {
        //     data.forEach(element => {
        //         console.log(element.firstName)
        //     })
        //  })
         .then(res => {
            
             
             const div = document.getElementById("divid");

            const h2 = document.getElementById("h2id");
            h2.textContent = "Skill results";

            let table = document.createElement("table");
            
               let tr = document.createElement("tr");
               let th1 = document.createElement("th");
               th1.textContent = "First name";
               let th2 = document.createElement("th");
               th2.textContent = "Last name";
               let th3 = document.createElement("th");
               th3.textContent = "Gender";
               let th4 = document.createElement("th");
               th4.textContent = "City";
               let th5 = document.createElement("th");
               th5.textContent = "Skill";
               let th6 = document.createElement("th");
               th6.textContent = "Proficiency";

               res.forEach(element => {
               
               let tr1 = document.createElement("tr");
               let th11 = document.createElement("td");
               th11.textContent = element.firstName;
               let th21 = document.createElement("td");
               th21.textContent = element.lastName;
               let th31 = document.createElement("td");
               th31.textContent = element.gender;
               let th41 = document.createElement("td");
               th41.textContent = element.city;
               let th51 = document.createElement("td");
               th51.textContent = element.skill;
               let th61 = document.createElement("td");
               th61.textContent = element.proficiency;
               
               tr1.appendChild(th11);
               tr1.appendChild(th21);
               tr1.appendChild(th31);
               tr1.appendChild(th41);
               tr1.appendChild(th51);
               tr1.appendChild(th61);
            });

               tr.appendChild(th1);
               tr.appendChild(th2);
               tr.appendChild(th3);
               tr.appendChild(th4);
               tr.appendChild(th5);
               tr.appendChild(th6);
               table.appendChild(tr);
               div.appendChild(table);
         })
         .catch(error => console.log(error))
}


function SearchByLocation() {

    let city = document.getElementById("city").value;
    console.log(city);

    let button = document.getElementById("citybtn");
    button.addEventListener('submit', (event) => {
        if(event)
            event.preventDefault();

        });
        fetch('https://localhost:44387/api/Filters/ByCity?' + new URLSearchParams ({
           City : city
       }), {
           method : 'GET',
           headers : {
               'Content-type' : 'application/json'
           },
       }).then(res => res.json())
         //.then(data => console.log(data))
         .then((res) => {
            res.forEach(element => {
                console.log(element.firstName);
            });
          })
         .catch(error => console.log(error));
}



function SearchByGender() {

    let gender = document.getElementById("gender").value;
    console.log(gender);

    let button = document.getElementById("genderbtn");
    button.addEventListener('submit', (event) => {
        if(event)
            event.preventDefault();

        });
        fetch('https://localhost:44387/api/Filters/ByGender?' + new URLSearchParams ({
           Gender : gender
       }), {
           method : 'GET',
           headers : {
               'Content-type' : 'application/json'
           },
       }).then(res => res.json())
         //.then(data => console.log(data))
         .then((res) => {
            res.forEach(element => {
                console.log(element.firstName);
            });
          })
         .catch(error => console.log(error));
}



function SearchBySkillGender() {

    let skill = document.getElementById("skill1").value;
    let gender = document.getElementById("gender1").value;
    //console.log(gender);

    let button = document.getElementById("sgbtn");
    button.addEventListener('submit', (event) => {
        if(event)
            event.preventDefault();

        });
        fetch('https://localhost:44387/api/Filters/BySkillAndGender?' + new URLSearchParams ({
           Skill : skill,
           Gender : gender
       }), {
           method : 'GET',
           headers : {
               'Content-type' : 'application/json'
           },
       }).then(res => res.json())
         //.then(data => console.log(data))
         .then((res) => {
            res.forEach(element => {
                console.log(element.firstName);
            });
          })
         .catch(error => console.log(error));
}