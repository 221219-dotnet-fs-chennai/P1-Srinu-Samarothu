// window.setInterval(function() {
//     var elem = document.getElementById('scrollDiv');
//     elem.scrollTop = elem.scrollHeight;
//   }, 0);



async function SearchBySkill() {
    
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
        }).then(res => res.json())
         .then(data => {
            
            const h2 = document.getElementById("h2id");
            h2.innerHTML = `<b>Search results : <u><span style="color:red">by Skill '${skillval}' </span></u></b>`;
            const h4 = document.getElementById("h4id");
            h4.innerHTML = `<b>Total search count : <span style="color:red">${data.length}</span></b>`;

            let theader = document.createElement('div');
            theader.innerHTML = `<table class="table" id="tableId">
            <tr>
              <th scope="col">S.No</th>
              <th scope="col">First name</th>
              <th scope="col">Last name</th>
              <th scope="col">Gender</th>
              <th scope="col">City</th>
              <th scope="col">Skill</th>
              <th scope="col">Proficiency</th>
            </tr>
            </table>`

            const div = document.getElementById("divid");
            div.appendChild(theader);
            

            let i=1;
            data.forEach(element => {
                
                let table = document.getElementById('tableId');

                var row = table.insertRow(i);
                var cell0 = row.insertCell(0);
                var cell1 = row.insertCell(1);
                var cell2 = row.insertCell(2);
                var cell3 = row.insertCell(3);
                var cell4 = row.insertCell(4);
                var cell5 = row.insertCell(5);
                var cell6 = row.insertCell(6);
                
                cell0.innerHTML = `${i}`;
                cell1.innerHTML = `<b>${element.firstName}</b>`;
                cell2.innerHTML = `<b>${element.lastName}</b>`;
                cell3.innerHTML = `${element.gender}`;
                cell4.innerHTML = `${element.city}`;
                cell5.innerHTML = `${element.skill}`;
                cell6.innerHTML = `${element.proficiency}`;

                i++;
               
            });

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
         .then(data => {
            
            const h2 = document.getElementById("h2id");
            h2.innerHTML = `<b>Search results : <u><span style="color:red">by City '${city}' </span></u></b>`;
            const h4 = document.getElementById("h4id");
            h4.innerHTML = `<b>Total search count : <span style="color:red">${data.length}</span></b>`;

            let theader = document.createElement('div');
            theader.innerHTML = `<table class="table" id="tableId">
            <tr>
              <th scope="col">S.No</th>
              <th scope="col">First name</th>
              <th scope="col">Last name</th>
              <th scope="col">Gender</th>
              <th scope="col">City</th>
              <th scope="col">State</th>
              <th scope="col">Zip code</th>
            </tr>
            </table>`

            const div = document.getElementById("divid");
            div.appendChild(theader);
            

            let i=1;
            data.forEach(element => {
                
                let table = document.getElementById('tableId');

                var row = table.insertRow(i);
                var cell0 = row.insertCell(0);
                var cell1 = row.insertCell(1);
                var cell2 = row.insertCell(2);
                var cell3 = row.insertCell(3);
                var cell4 = row.insertCell(4);
                var cell5 = row.insertCell(5);
                var cell6 = row.insertCell(6);
                
                cell0.innerHTML = `${i}`;
                cell1.innerHTML = `<b>${element.firstName}</b>`;
                cell2.innerHTML = `<b>${element.lastName}</b>`;
                cell3.innerHTML = `${element.gender}`;
                cell4.innerHTML = `${element.city}`;
                cell5.innerHTML = `${element.state}`;
                cell6.innerHTML = `${element.zipcode}`;

                i++;
               
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
         .then(data => {
            
            const h2 = document.getElementById("h2id");
            h2.innerHTML = `<b>Search results : <u><span style="color:red">by Gender '${gender}' </span></u></b>`;
            const h4 = document.getElementById("h4id");
            h4.innerHTML = `<b>Total search count : <span style="color:red">${data.length}</span></b>`;

            let theader = document.createElement('div');
            theader.innerHTML = `<table class="table" id="tableId">
            <tr>
              <th scope="col">S.No</th>
              <th scope="col">First name</th>
              <th scope="col">Last name</th>
              <th scope="col">Gender</th>
              <th scope="col">City</th>
              <th scope="col">State</th>
              <th scope="col">Zip code</th>
            </tr>
            </table>`

            const div = document.getElementById("divid");
            div.appendChild(theader);
            

            let i=1;
            data.forEach(element => {
                
                let table = document.getElementById('tableId');

                var row = table.insertRow(i);
                var cell0 = row.insertCell(0);
                var cell1 = row.insertCell(1);
                var cell2 = row.insertCell(2);
                var cell3 = row.insertCell(3);
                var cell4 = row.insertCell(4);
                var cell5 = row.insertCell(5);
                var cell6 = row.insertCell(6);
                
                cell0.innerHTML = `${i}`;
                cell1.innerHTML = `<b>${element.firstName}</b>`;
                cell2.innerHTML = `<b>${element.lastName}</b>`;
                cell3.innerHTML = `${element.gender}`;
                cell4.innerHTML = `${element.city}`;
                cell5.innerHTML = `${element.state}`;
                cell6.innerHTML = `${element.zipcode}`;

                i++;
               
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
         .then(data => {
            
            const h2 = document.getElementById("h2id");
            h2.innerHTML = `<b>Search results : <u><span style="color:red">by Skill '${skill} & Gender '${gender}' </span></u></b>`;
            const h4 = document.getElementById("h4id");
            h4.innerHTML = `<b>Total search count : <span style="color:red">${data.length}</span></b>`;

            let theader = document.createElement('div');
            theader.innerHTML = `<table class="table" id="tableId">
            <tr>
              <th scope="col">S.No</th>
              <th scope="col">First name</th>
              <th scope="col">Last name</th>
              <th scope="col">Gender</th>
              <th scope="col">City</th>
              <th scope="col">Skill</th>
              <th scope="col">Proficiency</th>
            </tr>
            </table>`

            const div = document.getElementById("divid");
            div.appendChild(theader);
            

            let i=1;
            data.forEach(element => {
                
                let table = document.getElementById('tableId');

                var row = table.insertRow(i);
                var cell0 = row.insertCell(0);
                var cell1 = row.insertCell(1);
                var cell2 = row.insertCell(2);
                var cell3 = row.insertCell(3);
                var cell4 = row.insertCell(4);
                var cell5 = row.insertCell(5);
                var cell6 = row.insertCell(6);
                
                cell0.innerHTML = `${i}`;
                cell1.innerHTML = `<b>${element.firstName}</b>`;
                cell2.innerHTML = `<b>${element.lastName}</b>`;
                cell3.innerHTML = `${element.gender}`;
                cell4.innerHTML = `${element.city}`;
                cell5.innerHTML = `${element.skill}`;
                cell6.innerHTML = `${element.proficiency}`;

                i++;
               
            });

         })
         .catch(error => console.log(error));
}



