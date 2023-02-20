let mailID = localStorage.getItem("Email");


fetch("https://localhost:44387/api/Trainer/Get?" + new URLSearchParams({ Email: mailID }), {
    method: "GET",
    headers: {
        "Content-type": "application/json"
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


let fnamebtn = document.getElementById("fnamebtn");
fnamebtn.addEventListener('click', event => {
    if(event)
        event.preventDefault();
});

let lnamebtn = document.getElementById("lnamebtn");
lnamebtn.addEventListener('click', event => {
    if(event)
        event.preventDefault();
});

let genderbtn = document.getElementById("genderbtn");
genderbtn.addEventListener('click', event => {
    if(event)
        event.preventDefault();
});

let dobbtn = document.getElementById("dobbtn");
dobbtn.addEventListener('click', event => {
    if(event)
        event.preventDefault();
});




function Updatefname() {
    let fname = document.getElementById('fname');
    fname.removeAttribute("readonly");
    fname.style.borderBottomColor = 'black';
    fname.style.color = 'red';
}

function Updatelname() {
    let lname = document.getElementById('lname');
    lname.removeAttribute("readonly");
    lname.style.borderBottomColor = 'black';
    lname.style.color = 'red';
}

function Updategender() {
    let gender = document.getElementById('gender');
    gender.removeAttribute("readonly");
    gender.style.borderBottomColor = 'black';
    gender.style.color = 'red';
}
function Updatedob() {
    let dob = document.getElementById('dob');
    dob.removeAttribute("readonly");
    dob.style.borderBottomColor = 'black';
    dob.style.color = 'red';
}

function Updateemail() {
    let email = document.getElementById('email');
    email.removeAttribute("readonly");
    email.style.borderBottomColor = 'black';
    email.style.color = 'red';
}
 




function UpdateTrainer() {
    
    let changesbtn = document.getElementById("changes");
    changesbtn.addEventListener('submit', event => {
        if (event)
        event.preventDefault();
    })

        let Fname = document.getElementById('fname').value;
        
        let Lname = document.getElementById('lname').value;

        let Gen = document.getElementById('gender').value;

        let Dob = document.getElementById('dob').value;

        console.log(Fname);
        console.log(Lname);

        fetch("https://localhost:44387/api/Trainer/Modify?" + new URLSearchParams({ Email: mailID }), {
            method: "PUT",
            body: JSON.stringify({
            tid : 0,
            firstName: Fname,
            lastName: Lname,
            gender: Gen,
            dob: Dob.toString(),
            mail : mailID
        }),
            headers: {
                "Content-type": "application/json"
            }
        }).then(response => {
            if(response.status === 200 || response.status===204) {
                alert("hii");
              window.location.href = "P1Index.html"
            }
            else{
              alert("Something went wrong..\n check your password");
            }
          })
        // .then(response => {
        //     if (response.status == 200 && response.status == 204) {
        //         if (alert("Updated successfully :) \n Want to go back ?"))
        //             window.location.href = "Profile.html"
        //     }
        //     else if (res.status == 400 || res.status == 401) {
        //         alert("Something went wrong...\n**Redirecting to PROFILE**");
        //     }
        // })
        .catch(error => console.log(error))
}