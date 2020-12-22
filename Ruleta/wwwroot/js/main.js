var urlAPI;
$(document).ready(function() {
    var host = new Host();
    urlAPI = host.getUrl();
})


$('#newRoulette').click(function() {
    $("#modalNewRoulette").modal("show");
})

$('#openRoulette').click(function() {
    $("#modalOpenRoulette").modal("show");
})

$('#Bet').click(function() {
    $("#modalBet").modal("show");
})


$("#btnLogin").click(function(e) {
    e.preventDefault();
    let Username = $("#username").val();
    let Email = $("#email").val();
    let Password = $("#password").val();
    const obj = {
        Username: Username,
        Email: Email,
        Password: Password,
    };

    fetch("https://localhost:44398/api/login/Login", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(obj),
        })
        .then((response) => response.json())
        .then((json) => {
            $("#alert").html("");
            if (json.messageId == 1) {
                localStorage.removeItem("token");
                localStorage.setItem("token", json.object.token)
                window.location = "home.html";
            } else if (json.messageId == 2) {
                $("#alert").append(`<div class="alert alert-danger" role="alert">
                ${json.message}
              </div>`);
            } else if (json.messageId == 3) {
                $("#alert").append(`<div class="alert alert-danger" role="alert">
                ${json.message}
              </div>`);
            }
        })
        .catch((response) => {
            alert("Problema al conectarse con la API: " + response);
        });
});


$('#btnNewRoulette').click(function() {
    Swal.fire({
        title: "",
        text: "¿Estás seguro que deseas crear una ruleta?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#2E8B57",
        cancelButtonColor: "#DC143C",
        confirmButtonText: "Si",
        cancelButtonText: "No",
    }).then((result) => {
        if (result.value) {
            fetch(urlAPI + "api/roulette/CreateRoulette", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                })
                .then((response) => response.json())
                .then((json) => {
                    if (json.status == true) {
                        $("#modalNewRoulette").modal("hide");
                        Swal.fire({
                            position: 'center',
                            icon: 'success',
                            text: json.message,
                            showConfirmButton: true
                        })
                    }
                });
        }
    });
})

$('#btnOpenRoulette').click(function(e) {
    e.preventDefault();
    let IdRoulette = $("#IdRoulette").val();
    const objRoulette = {
        IdRoulette: parseInt(IdRoulette)
    }
    fetch(urlAPI + "api/roulette/OpenRoulette", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(objRoulette),
        })
        .then((response) => response.json())
        .then((json) => {
            $("#modalOpenRoulette").modal("hide");
            if (json.status == true) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    text: json.message,
                    showConfirmButton: true
                })
            } else if (json.status == false) {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    text: json.message,
                    showConfirmButton: true
                })
            }
        });
})


$('#btnBet').click(function(e) {
    e.preventDefault();
    let numberBet = $("#numberBet").val();
    let quantityBet = $("#quantityBet").val();
    const objBet = {
        Number: parseInt(numberBet),
        Quantity: parseInt(quantityBet)
    }
    fetch(urlAPI + "api/roulette/Bet", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(objBet),
        })
        .then((response) => response.json())
        .then((json) => {
            $("#modalBet").modal("hide");
            if (json.status == true) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    text: json.message,
                    showConfirmButton: true
                })
            } else if (json.status == false) {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    text: json.message,
                    showConfirmButton: true
                })
            }
        }).catch((res) => { debugger;});
})

$("#modalOpenRoulette").on('hidden.bs.modal', function() {
    $("#IdRoulette").val("")
})