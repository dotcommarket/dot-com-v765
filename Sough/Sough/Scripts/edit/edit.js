
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