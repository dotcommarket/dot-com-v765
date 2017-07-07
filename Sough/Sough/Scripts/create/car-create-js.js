
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

    if (marque.value === "Audi" || marque.value === "Bmw" || marque.value === "Mercedes" || marque.value === "Land-Rover"
        || marque.value === "Nissan" || marque.value === "Renault" || marque.value === "Toyota") {
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

    smarque.innerHTML = '<abbr title="">' + r_marque + '</abbr>:  ' + String(marque.value);
    if (modele != null) {
        smodele.innerHTML = '<abbr title="">' + r_modele + '</abbr>:  ' + String(modele.value);
    }
    skilometrage.innerHTML = '<abbr title="">' + r_kilometrage + '</abbr>:   ' + String(kilometrage.value);
    scarburant.innerHTML = '<abbr title="">' + r_carburant + '</abbr>:  ' + String(carburant.options[carburant.selectedIndex].text);
    sboite.innerHTML = '<abbr title="">' + r_boite + '</abbr>:   ' + String(boite.options[boite.selectedIndex].text);
    sEstNeuf.innerHTML = EstNeuf + "";
    sville.innerHTML = '<abbr title="">' + r_ville + '</abbr>:   ' + String(ville.options[ville.selectedIndex].text);


    sphone.innerHTML = '<span class="fa fa-whatsapp"></span><abbr title="">' + r_tel + ': </abbr>' + String(phone.value);

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
        sname.innerHTML = '<abbr title="">' + r_nom + '</abbr>:   ' + String(name.value);
    sprix.innerHTML = String(prix.value) + ' Mro';

}

function toggleCarShape(type, x) {

    var car1 = document.getElementById("vic1");
    var car2 = document.getElementById("vic2");
    var car3 = document.getElementById("vic3");
    var car4 = document.getElementById("vic4");
    var carShape = document.getElementById("car_shape");
    
    if (carShape.value === x) {
        carShape.value = "";
    }
    else {
        carShape.value = x;
    }

    if (x === '2') {
        if (car1.getAttribute("class") === 'ic-1-b') {
            car1.setAttribute('class', 'ic-1-o');
            car2.setAttribute('class', 'ic-2-b');
            car3.setAttribute('class', 'ic-3-b');
            car4.setAttribute('class', 'ic-4-b');
        }
        else if (car1.getAttribute("class") === 'ic-1-o') {
            car1.setAttribute('class', 'ic-1-b');
        }
    } else if (x === '3') {


        if (car2.getAttribute("class") === 'ic-2-b') {
            car1.setAttribute('class', 'ic-1-b');
            car2.setAttribute('class', 'ic-2-o');
            car3.setAttribute('class', 'ic-3-b');
            car4.setAttribute('class', 'ic-4-b');

        }
        else if (car2.getAttribute("class") === 'ic-2-o') {
            car2.setAttribute('class', 'ic-2-b');
        }
    } else if (x === '4') {

        if (car3.getAttribute("class") === 'ic-3-b') {
            car1.setAttribute('class', 'ic-1-b');
            car2.setAttribute('class', 'ic-2-b');
            car3.setAttribute('class', 'ic-3-o');
            car4.setAttribute('class', 'ic-4-b');

        }
        else if (car3.getAttribute("class") === 'ic-3-o') {
            car3.setAttribute('class', 'ic-3-b');
        }
    } else if (x === '5') {

        if (car4.getAttribute("class") === 'ic-4-b') {
            car1.setAttribute('class', 'ic-1-b');
            car2.setAttribute('class', 'ic-2-b');
            car3.setAttribute('class', 'ic-3-b');
            car4.setAttribute('class', 'ic-4-o');
        }
        else if (car4.getAttribute("class") === 'ic-4-o') {
            car4.setAttribute('class', 'ic-4-b');
        }
    }
}

function toggleCarColor(color, id) {
    var white = document.getElementById('white');
    var grey = document.getElementById('grey');
    var brown = document.getElementById('brown');
    var black = document.getElementById('black');
    var red = document.getElementById('red');
    var yellow = document.getElementById('yellow');
    var green = document.getElementById('green');
    var blue = document.getElementById('blue');

    var _color = document.getElementById("color");

    /* Remove or add color border */
    $('#' + color).toggleClass('color_selected');

    if (id == 1) {
        grey.setAttribute('class', '');
        brown.setAttribute('class', '');
        black.setAttribute('class', '');
        red.setAttribute('class', '');
        yellow.setAttribute('class', '');
        green.setAttribute('class', '');
        blue.setAttribute('class', '');
    }
    if (id == 2) {
        white.setAttribute('class', '');
        brown.setAttribute('class', '');
        black.setAttribute('class', '');
        red.setAttribute('class', '');
        yellow.setAttribute('class', '');
        green.setAttribute('class', '');
        blue.setAttribute('class', '');

    } if (id == 3) {
        grey.setAttribute('class', '');
        white.setAttribute('class', '');
        black.setAttribute('class', '');
        red.setAttribute('class', '');
        yellow.setAttribute('class', '');
        green.setAttribute('class', '');
        blue.setAttribute('class', '');

    } if (id == 4) {
        grey.setAttribute('class', '');
        brown.setAttribute('class', '');
        white.setAttribute('class', '');
        red.setAttribute('class', '');
        yellow.setAttribute('class', '');
        green.setAttribute('class', '');
        blue.setAttribute('class', '');

    } if (id == 5) {
        grey.setAttribute('class', '');
        brown.setAttribute('class', '');
        black.setAttribute('class', '');
        white.setAttribute('class', '');
        yellow.setAttribute('class', '');
        green.setAttribute('class', '');
        blue.setAttribute('class', '');

    } if (id == 6) {
        grey.setAttribute('class', '');
        brown.setAttribute('class', '');
        black.setAttribute('class', '');
        red.setAttribute('class', '');
        white.setAttribute('class', '');
        green.setAttribute('class', '');
        blue.setAttribute('class', '');

    } if (id == 7) {
        grey.setAttribute('class', '');
        brown.setAttribute('class', '');
        black.setAttribute('class', '');
        red.setAttribute('class', '');
        yellow.setAttribute('class', '');
        white.setAttribute('class', '');
        blue.setAttribute('class', '');

    } if (id == 8) {
        grey.setAttribute('class', '');
        brown.setAttribute('class', '');
        black.setAttribute('class', '');
        red.setAttribute('class', '');
        yellow.setAttribute('class', '');
        green.setAttribute('class', '');
        white.setAttribute('class', '');
    }

    if (_color.value === color) {
        _color.value = "";
    }
    else {
        _color.value = color;
    }
}
