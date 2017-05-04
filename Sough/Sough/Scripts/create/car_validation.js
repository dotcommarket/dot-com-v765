


var type_modele = '';
var id_modele = '';


/* Set the a new class to make the selected car shape in orange and set a value in the hidden field*/
function toggleCarShape(type,x) {
   
    var car1 = document.getElementById("vic1");
    var car2 = document.getElementById("vic2");
    var car3 = document.getElementById("vic3");
    var car4 = document.getElementById("vic4");
    var carShape = document.getElementById("car_shape");
    //if (carShape.value.length <= 0) {
    //carShape.value = x;
    //console.log('shape : ' + carShape.value);

    if (carShape.value === x) {
        carShape.value = "";
        console.log('carShape : ' + carShape.value);
        console.log('carShape length : ' + carShape.value.length);
    }
    else {
        carShape.value = x;
        console.log('carShape : ' + carShape.value);
        console.log('carShape length : ' + carShape.value.length);
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

    if(_color.value === color) {
        _color.value = "";
       }
    else {
        _color.value = color;
         }
}

function checkModele(type,id) {
    var isok;
    if (type === "select") {
        isok = selectRequird(id, 'help-modele', 'Selectionner un mod\350le',400);
        if (isok) return true;
        else {
            return false;
        }
    } else {
        isok = inputRequird(id, 'help-modele', 'Saisir un mod\350le','all',400);
        if (isok) return true;
        else {
            return false;
        }
    }
   
}

function checkColorShape() {
    var input1 = String(document.getElementById('color').value);
    var input2 = String(document.getElementById('car_shape').value);
    var help = document.getElementById("help-color-shape");

    if (input1.length > 0 && input2.length > 0) {
        input1.length > 0
        help.innerText = "";
        return true;
    } else if (input1.length > 0) {
        help.style.color = "#cc0000"
        help.innerText = 'Veuillez choisir le type de la voiture.';
        window.scrollTo(0, 700);
        return false;
    } else if (input2.length > 0) {
        help.style.color = "#cc0000"
        help.innerText = 'Veuillez choisir le couleur de la voiture.';
        window.scrollTo(0, 700);
        return false;
    } else {

        help.style.color = "#cc0000"
        help.innerText = 'Veuillez choisir le couleur et le type de la voiture.';
        window.scrollTo(0, 700);
        return false;
    }
}

function checkEstNeuf() {

    var help = document.getElementById("help-EstNeuf");

    if (document.getElementById('estneuf').value.length < 1) {
        help.style.color = "#cc0000";
        help.innerText = 'Choisir ici';
        window.scrollTo(0, 600);
        return false;
    } else {
        help.innerText = "";
        return true;
    }
    
}
