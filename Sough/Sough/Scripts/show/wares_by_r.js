﻿var loading = document.getElementById('loading');

window.onload = function () {

    $.noConflict();
}

function searchBnt(contorller) {
    var cat = document.getElementById('cat');
    if (cat.selectedIndex == 0) {
        alert('Selectionner un categorie');
    }
    else {
        var form = document.getElementById('form');

        loading.style.display = "block";

        $.ajax({

            url: "../" + contorller + "/Ads",
            type: "POST",
            data: $("Form").serialize(), //if you need to post Model data, use this
            cache: false,

            success: function (result) {
                $("#List").html(result);
                loading.style.display = "none";
            }
        });
    }
    return false;
}

function aPager(href, page) {
    window.scrollTo(0, 0);
    loading.style.display = "block";

    $.ajax({
        url: href + "",
        type: "get",
        data: { "page": page },
        cache: false,
        success: function (result) {
            $("#List").html(result);
            loading.style.display = "none";

        }
    });

}

function trierPar(controller,reg) {

    var e = document.getElementById("TrieID");
    var t = e.options[e.selectedIndex].value;

    switch (t) {
        case "1":
            window.location.href = '../' + controller + '/TrierParDate?r='+reg;

            break;
        case "2":
            
            window.location.href = '../' + controller + '/TrierParPrix?r='+reg;

            break;
        default:
            window.location.href = '../' + controller + '/TrierParDate?r='+reg;
            break;
    }
    
}

