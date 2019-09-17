var modal = document.getElementById('id01');
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

$("#loadLoginPartialView").click(function () {
    $.get('Login/LoadLoginPartialView', {}, function (response) {
        $("#display_modal").html(response);
        var modal = document.getElementById('id01');
        modal.style.display = "Block";
    });
});

$("#loadRegisterPartialView").click(function () {
    $.get('Register/LoadRegisterPartialView', {}, function (response) {
        $("#display_modal").html(response);
        var modal = document.getElementById('id01');
        modal.style.display = "Block";
    });
});