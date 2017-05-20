var type_modele = '';
var id_modele = '';

function checkModele(type, id) {
    var isok;
    if (type === "select") {
        isok = selectRequird(id, 'help-modele', 'Selectionner un mod\350le', 400);
        if (isok) return true;
        else {
            return false;
        }
    } else {
        isok = inputRequird(id, 'help-modele', 'Saisir un mod\350le', 'all', 400);
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

function formValidate(t) {
    var cn = checkNom();
    var cp = checkPhone();
    var ce = checkEmail();

    var cmarque = selectRequird('marque', 'help-marque', 'Choisissez la marque du voiture', 190);
    var cmodele = checkModele(type_modele, id_modele);

    var ccarburant = selectRequird('carburant', 'help-carburant', 'Selectionnez le type du carburant', 510);
    var cboite = selectRequird('boite', 'help-boite', 'Selectionnez le type du boite', 600);
    var cville = selectRequird('ville', 'help-ville', 'Selectionnez une ville', 680);
    var cEstNeuf = checkEstNeuf();

    var cklm = inputRequird('kilometrage', 'help-kilometrage', 'Erreur! Verifier ici.', 'num', 570);
    var ccs = checkColorShape();
    var cprix = inputRequird('prix', 'help-prix', 'Erreur! Verifier ici.', 'num', 900);
    var cimages = checkImages(1250);
    var cpass = checkPass();
    var cconfpass = checkConfPass();


    if (cn && cp && ce && cmarque && cmodele && cEstNeuf && cklm & ccarburant && ccs
        && cboite && cville && cprix && cimages && cpass && cconfpass) {
        return true;
    } else {
        return false;
    }

}
