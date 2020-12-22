var urlAPI;
$(document).ready(function () {
    var host = new Host();
    urlAPI = host.getUrl();
})

$("#btnLogin").click(function (e) {
    e.preventDefault();
    let Username = $("#Username").val();
    let Password = $("#Password").val();
    const objLogin = {
        Username: Username,
        Password: Password,
    };

    fetch(urlAPI +"api/login/Login", {
        method: "POST",
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(objLogin),
    })
        .then((response) => response.json())
        .then((json) => {
            if (json.status == true) {
                window.location = "/Home";
            } else if (json.status == false) {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    text: json.message,
                    showConfirmButton: true
                })
            }
        })
        .catch((response) => {
            Swal.fire({
                position: 'center',
                icon: 'error',
                text: "Problema al conectarse con la API: " + response,
                showConfirmButton: true
            })
        });
});