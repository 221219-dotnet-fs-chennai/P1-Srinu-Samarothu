let mailID = localStorage.getItem("Email");

const form1 = document.querySelector('.form');

form1.addEventListener('submit', event => {
    if(event)
        event.preventDefault();

    signUp();
    
});



function signUp() {
  const formData = new FormData(form1);
    const data = Object.fromEntries(formData);

    //console.log(data);

    const loginData = {
      email : formData.get('email'),
      password : formData.get('confirmPassword')
    }
    
      localStorage.setItem("Email", loginData.email);

    fetch('https://localhost:44387/api/Login/Add', {
        method : 'POST',
        body : JSON.stringify(loginData),
        headers : {
            'Content-type' : 'application/json'
        },
    }).then(res => res.json())
    .then((res) => {
      if(res.status == 200) {
        alert("done")
        // window.location.href="Profile.html"
      }
      else if(res.status == 400 || res.status == 401) {
        alert("Email exists already !!, try with new one...");
      }
    })
      .catch(error => console.log(error));

      AddTrainer();
}

function AddTrainer() {
  const formData = new FormData(form1);
    const data = Object.fromEntries(formData);

    const trainerData = {
      tid: 0,
      firstName: formData.get('fname'),
      lastName: formData.get('lname'),
      gender: formData.get('gender'),
      dob: formData.get('dob').toString(),
      mail : formData.get('email')
    }

    fetch('https://localhost:44387/api/Trainer/Add', {
        method : 'POST',
        body : JSON.stringify(trainerData),
        headers : {
            'Content-type' : 'application/json'
          },
    }).then(res => res.json())
    .then((res) => {
        if(res.status == 201 || res.status == 200) {
          alert("Sign up successful :)");
          window.location.href="Profile.html"
        }
        else if(res.status == 400 || res.status == 401) {
          alert("Something went wrong!!");
        }
      })
      .catch(error => console.log(error));
}


//----------------------------------


async function login() {

  const form1 = document.querySelector('.form');
  form1.addEventListener('submit', event => {
    event.preventDefault();

    const formData = new FormData(form1);
    let mail = formData.get('email');
    let pwd = formData.get('password');

    const data = Object.fromEntries(formData);

    console.log(mail);

    // mailID = formData.get('email');

   

    // - Get - data

    fetch('https://localhost:44387/api/Login/GetUser?' + new URLSearchParams({
        Email: mail,
        Password: pwd
      }), {
        method: "GET",
        headers: {
          'Content-type': "application/json; charset=UTF-8",
        }
      })
      .then((res) => {
        if(res.status == 200) {
          localStorage.setItem("Email", mail);
          localStorage.setItem("password", pwd);
          localStorage.setItem("email",mail);
          window.location.href="Profile.html"
        }
        else if(res.status == 400 || res.status == 401) {
          alert("Invalid credentials :\nLogin with proper credentials\nGo to Sign up");
        }
      })
        //.then(data => console.log(data))
        .catch(error => console.log(error));

  });
}

//----------------------------------------------------------------


//----------------------------------------------------------------




function AddContact() {

  const contactform = document.querySelector('.contactForm');

  contactform.addEventListener('submit', event => {
    if (event)
      event.preventDefault();
  });
  const formData = new FormData(contactform);
    const data = Object.fromEntries(formData);

    console.log(data);
    const contactData = {
      mobileNumber : +formData.get('mobile'),
      addressLane: formData.get('address'),
      city : formData.get('city'),
      state: formData.get('state'),
      zipcode: formData.get('zip'),
      tid : 0,
      mailId : formData.get('mail')
    }

    fetch('https://localhost:44387/api/TrainerContact/Add?' + new URLSearchParams({Email : mailID}), {
        method : 'POST',
        body : JSON.stringify(contactData),
        headers : {
            'Content-type' : 'application/json'
          },
    })
    .then(res => {
        if(res.status == 200 || res.status == 201) {
          alert("Trainer contact details were added successfully :)");
          window.location.href="Profile.html";
        }
        else if(res.status == 400 || res.status == 401) {
          alert("Something went wrong!!");
        }
      })
      .catch(error => console.log(error));
}


//-----------------------------------------------------------------

function AddEducation() {

  const educationform = document.querySelector('.educationForm');

  educationform.addEventListener('submit', event => {
    if (event)
      event.preventDefault();
  });
  const formData = new FormData(educationform);
    const data = Object.fromEntries(formData);

    console.log(data);
    const educationData = {
      ugCollege : formData.get('UGclg') ?? "NA",
      ugPercentage : +formData.get('UGper') ?? 0,
      ugPassoutYear : +formData.get('UGpy') ?? 0,
      pgCollege : formData.get('PGclg') ?? "NA",
      pgPercentage : +formData.get('PGper') ?? 0,
      pgPassoutYear : +formData.get('PGpy') ?? 0,
      tid : 0
    }

    fetch('https://localhost:44387/api/Education/Add?' + new URLSearchParams({Email : mailID}), {
        method : 'POST',
        body : JSON.stringify(educationData),
        headers : {
            'Content-type' : 'application/json'
          },
    })
    .then(res => {
        if(res.status == 200 || res.status == 201) {
          alert("Trainer education details were added successfully :)");
          window.location.href="Profile.html";
        }
        else if(res.status == 400 || res.status == 401) {
          alert("Something went wrong!!");
        }
      })
      .catch(error => console.log(error));
}

//---------------------------------------------------------------------



function AddExperience() {

  const experienceForm = document.querySelector('.experienceForm');

  experienceForm.addEventListener('submit', event => {
    if (event)
      event.preventDefault();
  });
  const formData = new FormData(experienceForm);
    const data = Object.fromEntries(formData);

    
    const experience1Data = {
      company : formData.get('company1'),
      designation : formData.get('role1'),
      overallExperience : +formData.get('exp1'),
      tid : 0
    }

    fetch('https://localhost:44387/api/Experience/Add?' + new URLSearchParams({Email : mailID}), {
        method : 'POST',
        body : JSON.stringify(experience1Data),
        headers : {
            'Content-type' : 'application/json'
          },
    }).then(res => {
        if(res.status == 200 || res.status == 201) {
          localStorage.setItem("flag", true);
          if(window.confirm("Experience added successfully :)\n Do you want to add another ?") == true) 
            window.location.reload();
          else
            window.location.href="Profile.html";
        }
        else if(res.status == 400 || res.status == 401) {
          alert("Something went wrong!!");
        }
      })
      .catch(error => console.log(error));
}

//-------------------------------------------------------------------------

function AddSkill() {

  const skillForm = document.querySelector('.skillForm');

  skillForm.addEventListener('submit', event => {
    if (event)
      event.preventDefault();
  });
  const formData = new FormData(skillForm);
    const data = Object.fromEntries(formData);

    
    const skillData = {
      skill1 : formData.get('skill'),
      proficiency : +formData.get('pro'),
      tid : 0
    }

    fetch('https://localhost:44387/api/Skills/Add?' + new URLSearchParams({Email : mailID}), {
        method : 'POST',
        body : JSON.stringify(skillData),
        headers : {
            'Content-type' : 'application/json'
          },
    }).then(res => {
        if(res.status == 200 || res.status == 201) {
          if(window.confirm("Skill added successfully :)\n Do you want to add another ?") == true) 
            window.location.reload();
          else
            window.location.href="Profile.html";
        }
        else if(res.status == 400 || res.status == 401) {
          alert("Something went wrong!!");
        }
      })
      .catch(error => console.log(error));
}