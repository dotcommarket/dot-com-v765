
var type_modele = '';
var id_modele = '';

function checkModele(type,id) {
    var isok;
    if (type === "select") {
        isok = selectRequird(id, 'help-modele', err_data, 400);
        if (isok) return true;
        else {
            return false;
        }
    } else {
        isok = inputRequird(id, 'help-modele', err_data, 'all', 400);
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
        help.innerText = err_data;
        window.scrollTo(0, 700);
        return false;
    } else if (input2.length > 0) {
        help.style.color = "#cc0000"
        help.innerText = err_data;
        window.scrollTo(0, 700);
        return false;
    } else {

        help.style.color = "#cc0000"
        help.innerText = err_data;
        window.scrollTo(0, 700);
        return false;
    }
}

function checkEstNeuf() {

    var help = document.getElementById("help-EstNeuf");

    if (document.getElementById('estneuf').value.length < 1) {
        help.style.color = "#cc0000";
        help.innerText = err_data;
        window.scrollTo(0, 600);
        return false;
    } else {
        help.innerText = "";
        return true;
    }
    
}

function formValidate(view) {
    if (view != "ed") {

        var cn = checkNom();
        var cp = checkPhone();
        var ce = checkEmail();

        var cmarque = selectRequird('marque', 'help-marque', err_data, 190);
        var cmodele = checkModele(type_modele, id_modele);

        var ccarburant = selectRequird('carburant', 'help-carburant', err_data, 510);
        var cboite = selectRequird('boite', 'help-boite', err_data, 600);
        var cville = selectRequird('ville', 'help-ville', err_data, 680);
        var cEstNeuf = checkEstNeuf();

        var cklm = inputRequird('kilometrage', 'help-kilometrage', err_data, 'num', 570);
        var ccs = checkColorShape();
        var cprix = inputRequird('prix', 'help-prix', err_data, 'num', 900); 


        var cimages = checkImages(1250);
        var cpass = checkPass(view,1380);
        var cconfpass = checkConfPass(view,1400);


        if (cn && cp && ce && cmarque && cmodele && cEstNeuf && cklm && ccarburant && ccs
            && cboite && cville && cprix && cimages && cpass && cconfpass) {
            return true;
        } else {
            return false;
        }
    } else {
       
        var cn = checkNom();
        var ce = checkEmail();
        var cp = checkPhone();
        var cmarque = selectRequird('marque', 'help-marque', err_data, 190);
        var cklm = inputRequird('kilometrage', 'help-kilometrage', err_data, 'num', 570);
        var cprix = inputRequird('prix', 'help-prix', err_data, 'num', 900);
        var cpass = checkPass(view,1380);
        var cconfpass = checkConfPass(view,1400);

        if (cn && ce && cp && cmarque && cklm && cprix && cpass && cconfpass) {
            return true;
        } else {
            return false;
        }
    }
}
