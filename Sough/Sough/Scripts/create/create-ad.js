window.onload = function () {
    document.getElementById('cat').selectedIndex = "0";
}


function setSubject() {
    var cat = document.getElementById('cat');
    if (cat.selectedIndex == 0) {
        alert('Selectionner un categorie');
    }
    else {
        var controller = cat.value;
        console.log('controller : ' + controller);
        window.location.href = '../' + controller + '/Create';

    }

}