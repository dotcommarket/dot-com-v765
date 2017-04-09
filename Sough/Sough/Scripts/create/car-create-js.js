
$(document).ready(function () {
    //init
    $('#marque option[value=""]').attr("selected", true);
    document.getElementById("face_input").value = "";
    document.getElementById("insta_input").value = "";
    document.Form.agree_face.checked = false;
    document.Form.agree_insta.checked = false;
    document.getElementById("not_modele").value = "";
    $("input:radio").attr("checked", false);
    $("input:hidden").val("");

});



function setModalData() {
    var color = document.getElementById('color');
    var car_value = document.getElementById('car_shape');
    var car_shape = document.getElementById('vic');
    var li_color = document.getElementsByClassName('show-li-color');

    var x = parseInt(car_value.value) - 1;
    var icon = 'ic-' + x + '-o';

    li_color[0].setAttribute('id', color.value);
    car_shape.setAttribute('class', icon);

    var marque = document.getElementById('marque');
    var modele = null;
    var kilometrage = document.getElementById('kilometrage');
    var carburant = document.getElementById('carburant');
    var boite = document.getElementById('boite');
    var ville = document.getElementById('ville');
    var phone = document.getElementById('phone');
    var email = document.getElementById('email');
    var name = document.getElementById('name');
    var prix = document.getElementById('prix');
    var face = document.getElementById('face_input');
    var insta = document.getElementById('insta_input');

    if (marque.value === "audi" || marque.value === "bmw" || marque.value === "mercedes"
        || marque.value === "nissan" || marque.value === "renault" || marque.value === "toyota") {
        modele = document.getElementById("model_" + marque.value);
        var smodele = document.getElementById('s_modele');
    }
    var smarque = document.getElementById('s_marque');

    var skilometrage = document.getElementById('s_kilometrage');
    var scarburant = document.getElementById('s_carburant');
    var sboite = document.getElementById('s_boite');
    var sville = document.getElementById('s_ville');
    var sphone = document.getElementById('s_phone');
    var semail = document.getElementById('s_email');
    var sname = document.getElementById('s_name');
    var sEstNeuf = document.getElementById('s_EstNeuf');
    var sprix = document.getElementById('txt-h3');
    var sface = document.getElementById('s_face');
    var sinsta = document.getElementById('s_insta');

    var radios = document.getElementsByName('EstNeuf');
    var EstNeuf = "";
    for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
            EstNeuf = radios[i].value;
            break;
        }
    }

    smarque.innerHTML = '<abbr title="">Marque</abbr>: ' + String(marque.value);
    if (modele != null) {
        smodele.innerHTML = '<abbr title="">Modèle</abbr>: ' + String(modele.value);
    }
    skilometrage.innerHTML = '<abbr title="">Kilometrage</abbr>: ' + String(kilometrage.value);
    scarburant.innerHTML = '<abbr title="">Carburant</abbr>: ' + String(carburant.value);
    sboite.innerHTML = '<abbr title="">Boite</abbr>: ' + String(boite.value);
    sEstNeuf.innerHTML = EstNeuf + "";
    sville.innerHTML = '<abbr title="">Ville</abbr>: ' + String(ville.value);


    sphone.innerHTML = '<span class="fa fa-whatsapp"></span><abbr title="">Tel: </abbr>' + String(phone.value);

    if (face.value.length > 1) {
        sface.innerHTML = '<span class="fa fa-facebook"></span><abbr>' + face.value + '</abbr>';
    } else {
        sface.innerHTML = '';
    }

    if (insta.value.length > 1) {
        sinsta.innerHTML = '<span class="fa fa-instagram"></span><abbr>' + insta.value + '</abbr>';
    } else {
        sinsta.innerHTML = '';
    }

    if (email.value.length > 0)
        semail.innerHTML = '<span class="fa fa-envelope"></span>' + String(email.value);
    if (name.value.length > 0)
        sname.innerHTML = '<abbr title="">Nom</abbr>: ' + String(name.value);
    sprix.innerHTML = String(prix.value) + ' Mro';

}
