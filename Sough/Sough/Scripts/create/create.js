function estNeufClick(id, x) {
    var EstNeuf = "";
    if (document.getElementById('estneuf0').checked == true) {
        if (x === "Neuf")
            EstNeuf = "Neuf";
    } else if (document.getElementById('estneuf1').checked == true) {
        if (x === "Occasion")
            EstNeuf = "Occasion";
    }
    document.getElementById('estneuf').value = EstNeuf;

}

function loadBoxImage(id) {
    var output = document.getElementById(id);
    output.setAttribute('src', output1.getAttribute('src'));
}

function imgClickUpload(id) {
    var _id = '_f' + id;
    (document.getElementById(_id)).click();
}

$(function () {
    if (window.FileReader != null) {
        $('#single').hide();
        $('.single').prop('disabled', true);
    } else {
        $('#multiple').hide();
        $('.multiple').prop('disabled', true);
    }
});

function loadImage(id, event) {

    var _id = 'output' + id;
    var load = document.getElementById('load' + id);
    var output = document.getElementById(_id);
    var icon = document.getElementById('i' + id);
    var form = document.getElementById('form');

    load.style.display = "block";
    output.style.display = "none";
    icon.setAttribute("class", "");
    icon.setAttribute("hidden", "hidden");
    output.setAttribute('class', 'upimg');
    //output.setAttribute('alt', 'loading...');

    if (id == 1) {
        var upt = document.getElementsByClassName('span-up')[0];
        upt.style.display = "none";
        icon.style.marginTop = "0px"; // pour ne pas pouser le span
    }

    if (isCanvasSupported()) // check if browser support canvas
    {
        console.log('browser support canvas');

        if (form.hasAttribute('enctype')) {
            form.removeAttribute('enctype');
        }

        var current_file = event.target.files[0];
        event.target.files[0] = null;
        var reader = new FileReader();

        if (current_file.type.indexOf('image') == 0) {
            reader.onload = function (event) {
                var image = new Image();
                image.src = event.target.result;

                image.onload = function () {
                    var maxWidth = 736,
                        maxHeight = 552,
                        imageWidth = image.width,
                        imageHeight = image.height;


                    if (imageWidth > imageHeight) {
                        if (imageWidth > maxWidth) {
                            imageHeight *= maxWidth / imageWidth;
                            imageWidth = maxWidth;
                        }
                    }
                    else {
                        if (imageHeight > maxHeight) {
                            imageWidth *= maxHeight / imageHeight;
                            imageHeight = maxHeight;
                        }
                    }

                    var canvas = document.createElement('canvas');
                    canvas.width = imageWidth;
                    canvas.height = imageHeight;
                    image.width = imageWidth;
                    image.height = imageHeight;
                    var ctx = canvas.getContext("2d");
                    ctx.drawImage(this, 0, 0, imageWidth, imageHeight);

                    var dataURL = canvas.toDataURL('image/jpeg');

                    output.style.display = "block";
                    load.style.display = "none";

                    output.setAttribute('src', dataURL);

                    dataURL = dataURL.replace('data:image/jpeg;base64,', '')

                    var imgToUpload = document.getElementById('image' + id);
                    imgToUpload.value = dataURL;
                    //console.log("file_up"+id +" : "+file_up.value);

                }
            }


            reader.readAsDataURL(current_file);
        }
    } else {

        if (id == 1) {
            alert('Votre navigateur n\'est pas à jour. l\'upload des photos sera lent.')

            form.setAttribute('enctype', 'multipart/form-data');
        }
        load.style.display = "none";
        output.style.display = "block";

        output.src = URL.createObjectURL(event.target.files[0]);
        var imgToUpload = document.getElementById('image' + id);
        imgToUpload.value = "";
    }
}

function isCanvasSupported() {
    var elem = document.createElement('canvas');
    return !!(elem.getContext && elem.getContext('2d'));
}


/////////////////////////////////
// Modal script
var modal = document.getElementById('Modal-AD');

var btn = document.getElementById("show_box");
var submit = document.getElementById("submit");
var span = document.getElementsByClassName("close")[0];

btn.onclick = function () {

    var output = document.getElementById('b_img1');
    var output1 = document.getElementById('output1'); //main image
    output.setAttribute('src', output1.getAttribute('src'));
    if (formValidate()) {
    modal.style.display = "block";
    setModalData();
    }

}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}



function inputFace() {
    var row_ns = document.getElementById("row-sn");
    var tfb = document.getElementById("col-fb");
    var tinsta = document.getElementById("col-insta");

    if (document.Form.agree_face.checked == true) {
        row_ns.style.display = 'block';
        tfb.style.display = 'block';

    }
    else {
        document.getElementById('face_input').value = "";
        tfb.style.display = 'none';

    }
    if (document.Form.agree_insta.checked == false && document.Form.agree_face.checked == false) {
        row_ns.style.display = 'none';
    }

}
function inputInsta() {
    var row_ns = document.getElementById("row-sn");
    var tfb = document.getElementById("col-fb");
    var tinsta = document.getElementById("col-insta");

    if (document.Form.agree_insta.checked == true) {

        row_ns.style.display = 'block';
        tinsta.style.display = 'block';
    }
    else {
        document.getElementById('insta_input').value = "";
        tinsta.style.display = 'none';
    }
    if (document.Form.agree_insta.checked == false && document.Form.agree_face.checked == false) {
        row_ns.style.display = 'none';
    }
}