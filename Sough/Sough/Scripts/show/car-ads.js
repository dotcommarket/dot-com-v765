
window.onload = function () {
    $.noConflict();

    //trieSelect();

    var pmn = document.getElementsByName('pmn');
    var pmx = document.getElementsByName('pmx');
    pmn[0].value = "";
    pmx[0].value = "";
    document.getElementById("md_neuf").checked = false;
    document.getElementById('md_occ').checked = false;
    
    document.getElementById('marque').selectedIndex = "0";
    document.getElementsByName('km_min')[0].selectedIndex = "0";
    document.getElementsByName('km_max')[0].selectedIndex = "0";
    document.getElementsByName('boite')[0].selectedIndex = "0";
    document.getElementsByName('carburant')[0].selectedIndex = "0";
    


    /* clear models selects*/
    var selects = document.getElementsByClassName('modele-select');
    for (i = 0; i<selects.length;i++) {
        selects[i].selectedIndex = "0";
    }

    for (i = 1; i <= 8; i++) {
        var cs;
        var clr;

        clr = document.getElementById('color' + i);
        clr.value = "";

        if (i <= 4) {
            cs = document.getElementById("car_shape" + i);
            cs.value = "";
        }
    }
    

}

function toggleCarShape(x, type) {
    var sh_type = document.getElementById('car_shape' + x);
        var elt = $("#md_cs_" + x);

        if (elt.hasClass("car_shape_box_orange")) {
            elt.addClass("car_shape_box_black").removeClass("car_shape_box_orange");
         } else {
            elt.addClass("car_shape_box_orange").removeClass("car_shape_box_black");
         }

        var car_md = document.getElementById("md_vic" + x);
        
        if (car_md.getAttribute("class") === 'ic-' + x + '-b') {
            car_md.setAttribute('class', 'ic-' + x + '-o');
            sh_type.value = type + "";
        }
        else if (car_md.getAttribute("class") === 'ic-' + x + '-o') {
            car_md.setAttribute('class', 'ic-' + x + '-b');
            sh_type.value = "";
        }
       

}

function toggleCarColor(color, id) {

    var color_value = document.getElementById('color' + id).value;

    $('#md_' + color).toggleClass('color_selected');

    if (color_value.length < 1)
        document.getElementById('color' + id).value = color;
    else
        document.getElementById('color' + id).value = "";
}

// Your own scripts

