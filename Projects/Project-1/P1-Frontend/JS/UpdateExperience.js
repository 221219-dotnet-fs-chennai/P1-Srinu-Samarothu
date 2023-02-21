
let mailID = localStorage.getItem("Email");
let flag = localStorage.getItem("flag");



    while(flag != null && flag) {
        let y = prompt("Enter the company name you want to update : ");
        if(y == null || y == '') {
            y = prompt("Enter the company name you want to update : ");
        }
        else {
            //x = y;
            localStorage.setItem("com", y);
            localStorage.removeItem("flag");
            break;
        }
    }

com = localStorage.getItem("com");

    fetch("https://localhost:44387/api/Experience/GetCompany?" + new URLSearchParams({
        Email : mailID,
        company : com
    }), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then(data => {

        let company = document.getElementById('company');
        company.value = data.company;

        let role = document.getElementById('role');
        role.value = data.designation;

        let exp = document.getElementById('exp');
        exp.value = data.overallExperience;

    })
      .catch(error => console.log(error));


    let companybtn = document.getElementById('companybtn');
    companybtn.addEventListener('click', event => {
        if(event)
            event.preventDefault();
    })

    let rolebtn = document.getElementById('rolebtn');
    rolebtn.addEventListener('click', event => {
        if(event)
            event.preventDefault();
    })

    let expbtn = document.getElementById('expbtn');
    expbtn.addEventListener('click', event => {
        if(event)
            event.preventDefault();
    })



    function Updatecompany() {
        let company = document.getElementById('company');
        company.removeAttribute("readonly");
        company.style.borderBottomColor = 'black';
        company.style.color = 'red';
    }

    function Updaterole() {
        let role = document.getElementById('role');
        role.removeAttribute("readonly");
        role.style.borderBottomColor = 'black';
        role.style.color = 'red';
    }

    function Updateexp() {
        let exp = document.getElementById('exp');
        exp.removeAttribute("readonly");
        exp.style.borderBottomColor = 'black';
        exp.style.color = 'red';
    }

    
    
function UpdateExperience() {
    let changesbtn = document.getElementById("changes");
        changesbtn.addEventListener('submit', event => {
            if (event)
              event.preventDefault();
    })

    let Company = document.getElementById('company').value;

    let Role = document.getElementById('role').value;

    let Exp = document.getElementById('exp').value;

    fetch("https://localhost:44387/api/Experience/Modify?" + new URLSearchParams({
        Email : mailID,
        Company : com
    }), {
    method : "PUT",
    body : JSON.stringify({
        company: Company,
        designation : Role,
        overallExperience : +Exp,
        tid : 0
    }),
    headers : {
        "Content-type" : "application/json"
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