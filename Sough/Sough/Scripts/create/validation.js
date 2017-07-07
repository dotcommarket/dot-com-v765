

function selectRequird(id, help, msg,pos) {
    var select = document.getElementById(id);
    var opt = select.options[select.selectedIndex].value;
    var help = document.getElementById(help);

    if (opt == "") {
        voiture_marque = "";
        select.style.border = "1px solid #cc0000";
        help.style.color = "#cc0000";
        help.innerText = '' + msg;
        if(pos != 0)
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

            node.onfocus = function () {
                node.style.borderColor = "#cc0000";
            }

            if(pos != 0)
                window.scrollTo(0, pos);

            return false;
        }
        else {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";
            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
            }

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
            node.onfocus = function () {
                node.style.borderColor = "#cc0000";
            }

            if (pos != 0)
                window.scrollTo(0, pos);
            return false;
        } else if (node.value.match(regex)) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = msg+'';
            node.onfocus = function () {
                node.style.borderColor = "#cc0000";
            }

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
        
        node.onfocus = function () { node.style.borderColor = "#cc0000"; }

        help.style.color = "#cc0000";
        help.innerText = err_data;

        window.scrollTo(0, 1);

        node.onblur = function () {  checkNom(); }

        return false;
    }
    else if (!isAlphabetic(value)) {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = err_data;

        window.scrollTo(0, 1);

        node.onfocus = function () { node.style.borderColor = "#cc0000"; }
        node.onblur = function () { checkNom(); }

        return false;
    }
    else {
        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            node.style.borderColor = "#0a67c7";
            node.style.boxShadow = "";
        }
        node.onblur = function () {  checkNom(); }
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
        help.innerText = err_data;

        window.scrollTo(0, 100);

        node.onfocus = function () { node.style.borderColor = "#cc0000"; }
        node.onblur = function () { checkPhone(); }

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
        }
        node.onblur = function () {  checkPhone(); }
        help.innerText = "";
        return true;
    }
    else {
        node.style.backgroundColor = "#ffe6e6";
        node.style.borderColor = "#cc0000";

        help.style.color = "#cc0000";
        help.innerText = err_data;

        window.scrollTo(0, 100);

        node.onfocus = function () { node.style.borderColor = "#cc0000"; }
        node.onblur = function () { checkPhone(); }

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
            }
            node.onblur = function () {  checkEmail(); }
            help.innerText = "";
            return true;
        }
        else {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = err_data;

            window.scrollTo(0, 100);

            node.onfocus = function () { node.style.borderColor = "#cc0000"; }
            node.onblur = function () { checkEmail(); }

            return false;
        }

    } else {

        node.style.backgroundColor = "#ffffff";
        node.style.borderColor = "#999999";

        node.onfocus = function () {
            this.style.borderColor = "#0a67c7";
        }

        node.onblur = function () {
            this.style.borderColor = "#999999";
            checkEmail();
        }

        help.innerText = "";

        return true;
    }

}

function checkImages(pos) {

    var img1 = document.getElementById("_f1");
    var img2 = document.getElementById("_f2");
    var img3 = document.getElementById("_f3");
    var img4 = document.getElementById("_f4");

    var help = document.getElementById("help-image");
    if ((img1.files.length != 1) || (img2.files.length != 1) || (img3.files.length != 1) || (img4.files.length != 1)) {
        help.style.color = "#cc0000";
        help.innerText = err_data;

        window.scrollTo(0, pos);
        return false;
    } else {
        help.innerText = '';
        return true;
    }
}
function checkPass(view,pos) {

    var node = document.getElementById("password");
    var help = document.getElementById("help-pass");
    if (view != "ed") {
        
        if (node.value.length <= 0) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = err_data;
            node.onfocus = function () { node.style.borderColor = "#cc0000"; }

            window.scrollTo(0, pos);

            node.onblur = function () { checkPass(view, pos); }
            return false;
        } else if (node.value.length <= 3) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";
            node.onfocus = function () { node.style.borderColor = "#cc0000"; }

            help.style.color = "#cc0000";
            help.innerText = err_data;
            window.scrollTo(0, pos);

            node.onblur = function () { checkPass(view, pos); }
            return false;
        }
        else {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";

            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
            }
            node.onblur = function () { checkPass(view, pos); }
            help.innerText = "";
            return true;
        }
    } else {
        
        if (node.value.length <= 0) {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";

            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
            }
            node.onblur = function () { checkPass(view, pos); }
            help.innerText = "";
            return true;
        } else if (node.value.length <= 3) {
            node.style.backgroundColor = "#ffe6e6";
            node.style.borderColor = "#cc0000";
            node.onfocus = function () { node.style.borderColor = "#cc0000"; }

            help.style.color = "#cc0000";
            help.innerText = err_data;
            window.scrollTo(0, pos);

            node.onblur = function () { checkPass(view, pos); }

            return false;
        }
        else {
            node.style.backgroundColor = "#ffffff";
            node.style.borderColor = "#999999";

            node.onfocus = function () {
                node.style.borderColor = "#0a67c7";
            }
            node.onblur = function () { checkPass(view, pos); }
            help.innerText = "";
            return true;
        }
    }
}
function checkConfPass(view,pos) {

    var help = document.getElementById("help-conf-pass");
    var password = document.getElementById("password");
    var conf_pass = document.getElementById("conf_pass");


    if (view != "ed") {
        
        if (password.value != conf_pass.value) {
            conf_pass.style.backgroundColor = "#ffe6e6";
            conf_pass.style.borderColor = "#cc0000";

            help.style.color = "#cc0000";
            help.innerText = err_data;
            window.scrollTo(0, pos);

            conf_pass.onfocus = function () { conf_pass.style.borderColor = "#cc0000"; }
            conf_pass.onblur = function () { checkConfPass(view, pos); }
            return false;
        } else {
            conf_pass.style.backgroundColor = "#ffffff";
            conf_pass.style.borderColor = "#999999";

            conf_pass.onfocus = function () {
                conf_pass.style.borderColor = "#0a67c7";
            }
            conf_pass.onblur = function () { checkConfPass(view, pos); }
            help.innerText = "";
            return true;
        }
    } else {
        if (password.value.length < 1) {
            conf_pass.style.backgroundColor = "#ffffff";
            conf_pass.style.borderColor = "#999999";

            conf_pass.onfocus = function () {
                conf_pass.style.borderColor = "#0a67c7";
            }
            conf_pass.onblur = function () { checkConfPass(view, pos); }
            help.innerText = "";
            return true;
        }
        else {
            if (password.value != conf_pass.value) {
                conf_pass.style.backgroundColor = "#ffe6e6";
                conf_pass.style.borderColor = "#cc0000";

                help.style.color = "#cc0000";
                help.innerText = err_data;
                window.scrollTo(0, pos);

                conf_pass.onfocus = function () { conf_pass.style.borderColor = "#cc0000"; }
                conf_pass.onblur = function () { checkConfPass(view, pos); }

                return false;
            } else {
                conf_pass.style.backgroundColor = "#ffffff";
                conf_pass.style.borderColor = "#999999";

                conf_pass.onfocus = function () {
                    conf_pass.style.borderColor = "#0a67c7";
                }
                conf_pass.onblur = function () { checkConfPass(view, pos); }
                help.innerText = "";
                return true;
            }
        }
        
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