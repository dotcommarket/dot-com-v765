﻿

function selectRequird(id, help, msg, pos) {
    var select = document.getElementById(id);
    var opt = select.options[select.selectedIndex].value;
    var help = document.getElementById(help);

    if (opt == "") {
        voiture_marque = "";
        select.style.border = "1px solid #cc0000";
        help.style.color = "#cc0000";
        help.innerText = '' + msg;
        if (pos != 0)
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

function inputRequird(id, help, msg, type, pos) {
    var node = document.getElementById(id);
    var help = document.getElementById(help);

    if (type === "all") {
        if (node.value.length <= 0) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = '' + msg;

            node.onfocus = function () {
                node.style.borderColor = "#cc0000";
            }

            //node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type); }
            if (pos != 0)
                window.scrollTo(0, pos);
            return false;
        }
        else {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";
            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
            }
            //node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type); }
            help.innerText = "";
            return true;
        }
    } else if (type === 'num') {
        var regex = new RegExp("/^[a-z0-9]+$/i");

        if (node.value.length <= 0) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = msg + '';
            node.onfocus = function () {
                node.style.borderColor = "#cc0000";
            }
            //node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type, pos); }
            if (pos != 0)
                window.scrollTo(0, pos);
            return false;
        } else if (node.value.match(regex)) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = msg + '';
            node.onfocus = function () {
                node.style.borderColor = "#cc0000";
            }
            //node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type, pos); }
            if (pos != 0)
                window.scrollTo(0, pos);
            return false;
        }
        else {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";
            help.innerText = "";

            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
            }
            //node.onblur = function () { node.style.boxShadow = ""; inputRequird(id, help, msg, type, pos); }
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

        node.onblur = function () { checkNom(); }
        window.scrollTo(0, 1);
        return false;
    }
    else if (!isAlphabetic(value)) {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'Erreur , Le nom est incorrect!';

        node.onblur = function () { checkNom(); }
        window.scrollTo(0, 1);
        return false;
    }
    else {
        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            node.style.borderColor = "#0a67c7";
            node.style.boxShadow = "";
        }
        node.onblur = function () { checkNom(); }
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

        //node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { checkPhone(); }
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
            //this.style.boxShadow = "0 0 5px #0a67c7";
        }
        node.onblur = function () { checkPhone(); }
        help.innerText = "";
        return true;
    }
    else {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'le format du num\351ro du t\351l\351phone est incorrect';

        //node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { checkPhone(); }
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
                //this.style.boxShadow = "0 0 5px #0a67c7";
            }
            node.onblur = function () { checkEmail(); }
            help.innerText = "";
            return true;
        }
        else {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = 'Email incorrect!';

            //node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
            node.onblur = function () { checkEmail(); }
            window.scrollTo(0, 100);
            return false;
        }

    } else {

        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            this.style.borderColor = "#0a67c7";
            //this.style.boxShadow = "0 0 5px #0a67c7";
        }

        node.onblur = function () {
            this.style.borderColor = "#999999";
            // this.style.boxShadow = "";
            checkEmail();
        }

        help.innerText = "";

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

        //node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { checkPass(); }
        window.scrollTo(0, 1380);
        return false;
    } else if (node.value.length <= 3) {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = 'Password faible!';

        //node.onfocus = function () { node.style.boxShadow = "0 0 5px #cc0000"; }
        node.onblur = function () { checkPass(); }
        window.scrollTo(0, 1380);
        return false;
    }
    else {
        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            node.style.borderColor = "#0a67c7";
            // node.style.boxShadow = "0 0 5px #0a67c7";
        }
        node.onblur = function () { checkPass(); }
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

        //conf_pass.onfocus = function () { conf_pass.style.boxShadow = "0 0 5px #cc0000"; }
        conf_pass.onblur = function () { checkConfPass(); }
        window.scrollTo(0, 1400);
        return false;
    } else {
        conf_pass.style.backgroundColor = "#ffffff";
        conf_pass.style.borderColor = "#999999";

        conf_pass.onfocus = function () {
            conf_pass.style.borderColor = "#0a67c7";
            //conf_pass.style.boxShadow = "0 0 5px #0a67c7";
        }
        conf_pass.onblur = function () { checkConfPass(); }
        help.innerText = "";
        return true;
    }
}

function isAlphabetic(str) {
    var code, i, len;
    //  ar (1569 -1599) || (1601-1610)

    for (i = 0, len = str.length; i < len; i++) {
        code = str.charCodeAt(i);

        if ((code >= 1569 && code <= 1599) || (code >= 1601 && code <= 1610))
            return true;

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
}