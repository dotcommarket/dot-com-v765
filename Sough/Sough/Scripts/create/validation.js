

function selectRequird(id, help, msg,pos) {
    var select = document.getElementById(id);
    var opt = select.options[select.selectedIndex].value;
    var help = document.getElementById(help);

    if (opt == "") {
        voiture_marque = "";
        select.style.border = "1px solid #cc0000";
        help.style.color = "#cc0000";
        help.innerText = '' + msg;
        window.scrollTo(0, pos);
        return false;
    }
    else {
        select.style.border = "1px solid #CCC";
        voiture_marque = opt + "";
        help.innerText = '';
        return true;
    }
}

function inputRequird(id, help, msg,type,pos) {
    var node = document.getElementById(id);
    var help = document.getElementById(help);

    if (type === "all") {
        if (node.value.length <= 0) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = '' + msg;

            node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
            node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type); }
            window.scrollTo(0, pos);
            return false;
        }
        else {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";

            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
                node.style.boxShadow = "0 0 5px #0a67c7";
            }
            node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type); }
            help.innerText = "";
            return true;
        }
    } else if (type === 'num') {
        var regex = new RegExp("/^[a-z0-9]+$/i");

        if (node.value.length <= 0) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = msg+'';

            node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
            node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type, pos); }
            window.scrollTo(0, pos);
            return false;
        } else if (node.value.match(regex)) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = msg+'';

            node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
            node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type, pos); }
            window.scrollTo(0, pos);
            return false;
        }
        else {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";

            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
                node.style.boxShadow = "0 0 5px #0a67c7";
            }
            node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type, pos); }
            help.innerText = "";
            return true;
        }
    }
}

function checkNom() {
    var node = document.getElementById("name");
    var help = document.getElementById("help-name");
    var value = String(node.value);

    if (value.length > 25) {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'Erreur , Le nom est long!';

        node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { node.style.boxShadow = ""; checkNom(); }
        window.scrollTo(0, 100); 
        return false;
    }
    else if (!isAlphabetic(value)) {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'Erreur , Le nom est incorrect!';

        node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { node.style.boxShadow = ""; checkNom(); }
        window.scrollTo(0, 100);
        return false;
    }
    else {
        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            node.style.borderColor = "#0a67c7";
            node.style.boxShadow = "0 0 5px #0a67c7";
        }
        node.onblur = function () { node.style.boxShadow = ""; checkNom(); }
        help.innerText = "";
        return true;
    }
}
function checkPhone() {

    var node = document.getElementById("phone");

    var phone_input = String(document.getElementById("phone").value);
    var help = document.getElementById("help-phone");

    if (phone_input.length <= 0) {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = "Le num\351ro du t\351l\351phone est obligatoire";

        node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { node.style.boxShadow = ""; checkPhone(); }
        window.scrollTo(0, 100);
        return false;
    }

    if (phone_input.charAt(0) == '+') {
        phone_input = phone_input.substring(1);
    }


    var regexPhone = new RegExp("^([0-9]{8,13})$");

    if ((phone_input.match(regexPhone)) && (phone_input.length == 8) ||
       (phone_input.match(regexPhone) && (phone_input.length == 11 && phone_input.charAt(0) == '2' && phone_input.charAt(1) == '2' && phone_input.charAt(2) == '2')) ||
       (phone_input.match(regexPhone) && (phone_input.length == 13 && phone_input.charAt(0) == '0' && phone_input.charAt(1) == '0' && phone_input.charAt(2) != '0'))) {

        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            this.style.borderColor = "#0a67c7";
            this.style.boxShadow = "0 0 5px #0a67c7";
        }
        node.onblur = function () { node.style.boxShadow = ""; checkPhone(); }
        help.innerText = "";
        return true;
    }
    else {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'le format du num\351ro du t\351l\351phone est incorrect';

        node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { node.style.boxShadow = ""; checkPhone(); }
        window.scrollTo(0, 100);
        return false;
    }
}
function checkEmail() {

    var help = document.getElementById("help-email");
    var node = document.getElementById("email");
    var email_input = String(node.value);

    if (email_input.length > 0) {
        var regexEmail = new RegExp("^[a-zA-Z0-9._-]+@[a-z0-9._-]{2,}\.[a-z]{2,4}$");

        if (email_input.match(regexEmail)) {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";

            node.onfocus = function () {
                this.style.borderColor = "#0a67c7";
                this.style.boxShadow = "0 0 5px #0a67c7";
            }
            node.onblur = function () { node.style.boxShadow = ""; checkEmail(); }
            help.innerText = "";
            return true;
        }
        else {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = 'Email incorrect!';

            node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
            node.onblur = function () { node.style.boxShadow = ""; checkEmail(); }
            window.scrollTo(0, 100);
            return false;
        }

    } else {

        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            this.style.borderColor = "#0a67c7";
            this.style.boxShadow = "0 0 5px #0a67c7";
        }

        node.onblur = function () {
            this.style.borderColor = "#999999";
            this.style.boxShadow = "";
            checkEmail();
        }

        help.innerText = "";

        return true;
    }

}

function checkPrix() {
    var node = document.getElementById("prix");
    var help = document.getElementById("help-prix");
    
}
function checkImages() {

    var img1 = document.getElementById("_f1");
    var img2 = document.getElementById("_f2");
    var img3 = document.getElementById("_f3");
    var img4 = document.getElementById("_f4");

    var help = document.getElementById("help-image");
    if ((img1.files.length != 1) || (img2.files.length != 1) || (img3.files.length != 1) || (img4.files.length != 1)) {
        help.style.color = "#cc0000";
        help.innerText = 'Selectionnez quatre images';
        window.scrollTo(0, 1250);
        return false;
    } else {
        help.innerText = '';
        return true;
    }
}
function checkPass() {

    var node = document.getElementById("password");
    var help = document.getElementById("help-pass");

    if (node.value.length <= 0) {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'Erreur , Creer un password pour votre produit!';

        node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { node.style.boxShadow = ""; checkPass(); }
        window.scrollTo(0, 1380);
        return false;
    }
    else {
        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            node.style.borderColor = "#0a67c7";
            node.style.boxShadow = "0 0 5px #0a67c7";
        }
        node.onblur = function () { node.style.boxShadow = ""; checkPass(); }
        help.innerText = "";
        return true;
    }
}
function checkConfPass() {
    var help = document.getElementById("help-conf-pass");
    var password = document.getElementById("password");
    var conf_pass = document.getElementById("conf_pass");

    if (password.value != conf_pass.value) {
        conf_pass.style.backgroundColor = "#ffe6e6";
        conf_pass.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'Erreur , le mot de pass n\'est pas identique!';

        conf_pass.onfocus = function () { conf_pass.style.boxShadow = "0 0 5px #cc0000"; }
        conf_pass.onblur = function () { conf_pass.style.boxShadow = ""; checkConfPass(); }
        window.scrollTo(0, 1400);
        return false;
    } else {
        conf_pass.style.backgroundColor = "#ffffff";
        conf_pass.style.borderColor = "#999999";

        conf_pass.onfocus = function () {
            conf_pass.style.borderColor = "#0a67c7";
            conf_pass.style.boxShadow = "0 0 5px #0a67c7";
        }
        conf_pass.onblur = function () { conf_pass.style.boxShadow = ""; checkConfPass(); }
        help.innerText = "";
        return true;
    }
}

function formValidate() {
    var cn = checkNom();
    var cp = checkPhone();
    var ce = checkEmail();

    var cmarque = selectRequird('marque', 'help-marque', 'Choisissez la marque du voiture',190);
    var ccarburant = selectRequird('carburant', 'help-carburant', 'Selectionnez le type du carburant', 510);
    var cboite = selectRequird('boite', 'help-boite', 'Selectionnez le type du boite', 600);
    var cville = selectRequird('ville', 'help-ville', 'Selectionnez une ville',680);

    var cmodele = checkModele(type_modele, id_modele);
    var cklm = inputRequird('kilometrage', 'help-kilometrage', 'Erreur! Verifier ici.', 'num', 570);
    var ccs = checkColorShape();
    var cprix = inputRequird('prix', 'help-prix', 'Erreur! Verifier ici.', 'num', 900);
    var cimages = checkImages();
    var cEstNeuf = checkEstNeuf();

    if (cn && cp && ce && cmarque && cmodele && cEstNeuf && cklm & ccarburant && ccs
        && cboite && cville && cprix && cimages) {
        return true;
    } else {
        return false;        
    }

}

function isAlphabetic(str) {
    var code, i, len;

    for (i = 0, len = str.length; i < len; i++) {
        code = str.charCodeAt(i);
        if ((code > 32 && code < 65)
            || (code > 32 && code < 58)
            || (code > 90 && code < 97)
            || (code > 122 && code < 192)
            || (code > 235)
           ) { // ASCII code
            return false;
        }
    }
    return true;
};