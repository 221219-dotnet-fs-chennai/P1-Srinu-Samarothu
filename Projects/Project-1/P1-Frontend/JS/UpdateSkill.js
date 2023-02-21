
let mailID = localStorage.getItem("Email");
let flag = localStorage.getItem("flag");



    while(flag != null && flag) {
        let y = prompt("Enter the skill you want to update : ");
        if(y == null || y == '') {
            y = prompt("Enter the skill you want to update : ");
        }
        else {
            //x = y;
            localStorage.setItem("skill", y);
            localStorage.removeItem("flag");
            break;
        }
    }

ski = localStorage.getItem("skill");

    fetch("https://localhost:44387/api/Skills/GetSkill?" + new URLSearchParams({
        Email : mailID,
        skill : ski
    }), {
        method : "GET",
        headers : {
            "Content-type" : "application/json"
        }
    }).then(response => response.json())
      .then(data => {

        let skill = document.getElementById('skill');
        skill.value = data.skill1;

        let pro = document.getElementById('pro');
        pro.value = data.proficiency;

    })
      .catch(error => console.log(error));


    let skillbtn = document.getElementById('skillbtn');
    skillbtn.addEventListener('click', event => {
        if(event)
            event.preventDefault();
    })

    let probtn = document.getElementById('probtn');
    probtn.addEventListener('click', event => {
        if(event)
            event.preventDefault();
    })



    function Updateskill() {
        let skill = document.getElementById('skill');
        skill.removeAttribute("readonly");
        skill.style.borderBottomColor = 'black';
        skill.style.color = 'red';
    }

    function Updatepro() {
        let pro = document.getElementById('pro');
        pro.removeAttribute("readonly");
        pro.style.borderBottomColor = 'black';
        pro.style.color = 'red';
    }


    
    
function Update() {
    let changesbtn = document.getElementById("changes");
        changesbtn.addEventListener('submit', event => {
            if (event)
              event.preventDefault();
    })

    let Skill = document.getElementById('skill').value;

    let Pro = document.getElementById('pro').value;
    
    localStorage.setItem("skill", Skill);

    fetch("https://localhost:44387/api/Skills/Modify?" + new URLSearchParams({
        Email : mailID,
        skill : ski
    }), {
    method : "PUT",
    body : JSON.stringify({
        skill1 : Skill,
        proficiency : +Pro,
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