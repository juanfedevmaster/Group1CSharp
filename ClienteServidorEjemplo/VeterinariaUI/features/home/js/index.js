const url = "http://localhost:5097/Mascota/api/GetMascotas";
fetch(url)
    .then(response => {
        if(!response.ok) {
            alert("Llamado Fallido");
        }

        return response.json();
    })
    .then(data =>{
        let table = document.getElementById("table");
        let tbody = table.querySelector("tbody");

        data.forEach(mascota => {
            let tr = document.createElement("tr");
            tr.innerHTML = `
                <td>${mascota.id}</td>
                <td>${mascota.nombre}</td>
                <td>${mascota.especie}</td>
                <td>${mascota.raza}</td>
                <td>${mascota.fechaNacimiento}</td>
            `;
            tbody.appendChild(tr);
        });
        
    });