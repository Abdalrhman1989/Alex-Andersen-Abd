

function Validate(id) {



    Swal.fire({
        title: '<h2 style="font-size: 16px;line-height: 1.6rem;font-weight: bolder;">Er du sikker på at du vil slette din profil?</h2>',
        //icon: 'info',
        html:
            '<div class="radio-container">' +
            '<label for="check">' +
            '<input id="check" type="checkbox" class= "checkbox-round" checked="checked" >' +
            'Tryk for at slette profil' +
            '</label>' +
            '</div>',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Slet',
        confirmButtonColor: '#00904a',
        denyButtonText: `Annuler`,
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: "/Settings/DeleteDriver",
                data:           
                {
                    "id": id
                },
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {

                    Swal.fire({
                        title: '<p style="font-size: 16px;">Din profil er nu slettet </p>',
                        showDenyButton: true,
                        showCancelButton: false,
                        showConfirmButton: false,
                        //confirmButtonText: 'Annuler',
                        denyButtonText: `Ok`,
                    }).then((results) => {
                        if (results.isDenied) {
                            window.location.href = "/Login/Index";
                        }
                        
                    });
                },
                error: function () {
                    alert("Error while inserting data");
                }
            });
        }
    }
    );
}