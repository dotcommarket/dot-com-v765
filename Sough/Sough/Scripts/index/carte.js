//document.getElementById('map-div').style.display = "none";
function MM_findObj(n, d) { //v4.01
    var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
        d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
    }
    if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
    for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
    if (!x && d.getElementById) x = d.getElementById(n); return x;
}

function MM_swapImage1() { //v3.0
    var i, j = 0, x, a = MM_swapImage1.arguments; document.MM_sr = new Array;
    for (i = 0; i < (a.length - 2) ; i += 3) {
        if (i == 0) document.getElementById(a[i]).style.color = "#f50";
        if ((x = MM_findObj(a[i])) != null) {
            document.MM_sr[j++] = x;
            if (!x.oSrc) {
                x.oSrc = x.src;
            }
            x.src = a[i + 2];
        }
    }
}
function MM_swapImage2() { //v3.0
    var i, j = 0, x, a = MM_swapImage2.arguments; document.MM_sr = new Array;
    for (i = 0; i < (a.length - 2) ; i += 3) {
        if (i == 0) document.getElementById(a[i]).style.color = "#308fe4";
        if ((x = MM_findObj(a[i])) != null) {
            document.MM_sr[j++] = x;
            if (!x.oSrc) {
                x.oSrc = x.src;
            }
            x.src = a[i + 2];
        }
    }
}


function MM_preloadImages() { //v3.0
    var d = document; if (d.images) {
        if (!d.MM_p) d.MM_p = new Array();
        var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
            if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
    }
}


window.onload = function () {
    //document.getElementById('map-div').style.display = "none";

    MM_preloadImages('~/Content/icons/map/rim_r2_c13_s4.jpg', '~/Content/icons/map/rim_r3_c13_s4.jpg', '~/Content/icons/map/rim_r3_c25_s4.jpg', '~/Content/icons/map/rim_r4_c13_s4.jpg', '~/Content/icons/map/rim_r4_c22_s4.jpg', '~/Content/icons/map/rim_r4_c25_s4.jpg', '~/Content/icons/map/rim_r4_c26_s4.jpg', '~/Content/icons/map/rim_r2_c13.jpg', '~/Content/icons/map/rim_r3_c13.jpg', '~/Content/icons/map/rim_r3_c25.jpg', '~/Content/icons/map/rim_r4_c13.jpg', '~/Content/icons/map/rim_r4_c22.jpg', '~/Content/icons/map/rim_r4_c25.jpg', '~/Content/icons/map/rim_r4_c26.jpg', '~/Content/icons/map/rim_r3_c9_s4.jpg', '~/Content/icons/map/rim_r3_c13_s6.jpg', '~/Content/icons/map/rim_r4_c13_s6.jpg', '~/Content/icons/map/rim_r4_c22_s8.jpg', '~/Content/icons/map/rim_r5_c9_s6.jpg', '~/Content/icons/map/rim_r5_c10_s4.jpg', '~/Content/icons/map/rim_r6_c13_s4.jpg', '~/Content/icons/map/rim_r6_c22_s6.jpg', '~/Content/icons/map/rim_r7_c9_s8.jpg', '~/Content/icons/map/rim_r7_c10_s6.jpg', '~/Content/icons/map/rim_r7_c11_s4.jpg', '~/Content/icons/map/rim_r9_c13_s4.jpg', '~/Content/icons/map/rim_r9_c16_s6.jpg', '~/Content/icons/map/rim_r9_c22_s8.jpg', '~/Content/icons/map/rim_r9_c24_s6.jpg', '~/Content/icons/map/rim_r10_c9_s6.jpg', '~/Content/icons/map/rim_r12_c9_s4.jpg', '~/Content/icons/map/rim_r13_c9_s6.jpg', '~/Content/icons/map/rim_r13_c14_s4.jpg', '~/Content/icons/map/rim_r3_c9.jpg', '~/Content/icons/map/rim_r5_c9.jpg', '~/Content/icons/map/rim_r5_c10.jpg', '~/Content/icons/map/rim_r6_c13.jpg', '~/Content/icons/map/rim_r6_c22.jpg', '~/Content/icons/map/rim_r7_c9.jpg', '~/Content/icons/map/rim_r7_c10.jpg', '~/Content/icons/map/rim_r7_c11.jpg', '~/Content/icons/map/rim_r9_c13.jpg', '~/Content/icons/map/rim_r9_c16.jpg', '~/Content/icons/map/rim_r9_c22.jpg', '~/Content/icons/map/rim_r9_c24.jpg', '~/Content/icons/map/rim_r10_c9.jpg', '~/Content/icons/map/rim_r12_c9.jpg', '~/Content/icons/map/rim_r13_c9.jpg', '~/Content/icons/map/rim_r13_c14.jpg', '~/Content/icons/map/rim_r4_c22_s6.jpg', '~/Content/icons/map/rim_r4_c25_s6.jpg', '~/Content/icons/map/rim_r6_c22_s4.jpg', '~/Content/icons/map/rim_r6_c25_s4.jpg', '~/Content/icons/map/rim_r9_c22_s6.jpg', '~/Content/icons/map/rim_r9_c24_s4.jpg', '~/Content/icons/map/rim_r15_c22_s6.jpg', '~/Content/icons/map/rim_r15_c24_s4.jpg', '~/Content/icons/map/rim_r19_c22_s8.jpg', '~/Content/icons/map/rim_r19_c23_s6.jpg', '~/Content/icons/map/rim_r20_c22_s6.jpg', '~/Content/icons/map/rim_r20_c23_s4.jpg', '~/Content/icons/map/rim_r6_c25.jpg', '~/Content/icons/map/rim_r15_c22.jpg', '~/Content/icons/map/rim_r15_c24.jpg', '~/Content/icons/map/rim_r19_c22.jpg', '~/Content/icons/map/rim_r19_c23.jpg', '~/Content/icons/map/rim_r20_c22.jpg', '~/Content/icons/map/rim_r20_c23.jpg', '~/Content/icons/map/rim_r5_c3_s4.jpg', '~/Content/icons/map/rim_r5_c9_s4.jpg', '~/Content/icons/map/rim_r7_c3_s4.jpg', '~/Content/icons/map/rim_r7_c5_s6.jpg', '~/Content/icons/map/rim_r7_c9_s6.jpg', '~/Content/icons/map/rim_r5_c3.jpg', '~/Content/icons/map/rim_r7_c3.jpg', '~/Content/icons/map/rim_r7_c5.jpg', '~/Content/icons/map/rim_r7_c5_s4.jpg', '~/Content/icons/map/rim_r7_c9_s4.jpg', '~/Content/icons/map/rim_r7_c10_s4.jpg', '~/Content/icons/map/rim_r10_c5_s4.jpg', '~/Content/icons/map/rim_r10_c9_s4.jpg', '~/Content/icons/map/rim_r10_c5.jpg', '~/Content/icons/map/rim_r9_c16_s4.jpg', '~/Content/icons/map/rim_r9_c22_s4.jpg', '~/Content/icons/map/rim_r15_c16_s4.jpg', '~/Content/icons/map/rim_r15_c22_s4.jpg', '~/Content/icons/map/rim_r16_c16_s4.jpg', '~/Content/icons/map/rim_r16_c17_s4.jpg', '~/Content/icons/map/rim_r17_c16_s4.jpg', '~/Content/icons/map/rim_r17_c17_s4.jpg', '~/Content/icons/map/rim_r17_c21_s4.jpg', '~/Content/icons/map/rim_r19_c17_s4.jpg', '~/Content/icons/map/rim_r19_c20_s4.jpg', '~/Content/icons/map/rim_r19_c21_s4.jpg', '~/Content/icons/map/rim_r19_c22_s4.jpg', '~/Content/icons/map/rim_r19_c23_s4.jpg', '~/Content/icons/map/rim_r15_c16.jpg', '~/Content/icons/map/rim_r16_c16.jpg', '~/Content/icons/map/rim_r16_c17.jpg', '~/Content/icons/map/rim_r17_c16.jpg', '~/Content/icons/map/rim_r17_c17.jpg', '~/Content/icons/map/rim_r17_c21.jpg', '~/Content/icons/map/rim_r19_c17.jpg', '~/Content/icons/map/rim_r19_c20.jpg', '~/Content/icons/map/rim_r19_c21.jpg', '~/Content/icons/map/rim_r13_c4_s4.jpg', '~/Content/icons/map/rim_r13_c9_s4.jpg', '~/Content/icons/map/rim_r14_c4_s4.jpg', '~/Content/icons/map/rim_r14_c7_s4.jpg', '~/Content/icons/map/rim_r15_c9_s4.jpg', '~/Content/icons/map/rim_r16_c7_s4.jpg', '~/Content/icons/map/rim_r16_c8_s4.jpg', '~/Content/icons/map/rim_r18_c4_s4.jpg', '~/Content/icons/map/rim_r21_c8_s4.jpg', '~/Content/icons/map/rim_r21_c12_s4.jpg', '~/Content/icons/map/rim_r13_c4.jpg', '~/Content/icons/map/rim_r14_c4.jpg', '~/Content/icons/map/rim_r14_c7.jpg', '~/Content/icons/map/rim_r15_c9.jpg', '~/Content/icons/map/rim_r16_c7.jpg', '~/Content/icons/map/rim_r16_c8.jpg', '~/Content/icons/map/rim_r18_c4.jpg', '~/Content/icons/map/rim_r21_c8.jpg', '~/Content/icons/map/rim_r21_c12.jpg', '~/Content/icons/map/rim_r14_c2_s4.jpg', '~/Content/icons/map/rim_r14_c4_s6.jpg', '~/Content/icons/map/rim_r14_c2.jpg', '~/Content/icons/map/rim_r16_c8_s6.jpg', '~/Content/icons/map/rim_r16_c14_s4.jpg', '~/Content/icons/map/rim_r16_c16_s6.jpg', '~/Content/icons/map/rim_r17_c14_s4.jpg', '~/Content/icons/map/rim_r17_c16_s6.jpg', '~/Content/icons/map/rim_r20_c16_s4.jpg', '~/Content/icons/map/rim_r21_c8_s6.jpg', '~/Content/icons/map/rim_r21_c12_s8.jpg', '~/Content/icons/map/rim_r21_c14_s6.jpg', '~/Content/icons/map/rim_r22_c8_s4.jpg', '~/Content/icons/map/rim_r22_c12_s6.jpg', '~/Content/icons/map/rim_r16_c14.jpg', '~/Content/icons/map/rim_r17_c14.jpg', '~/Content/icons/map/rim_r20_c16.jpg', '~/Content/icons/map/rim_r21_c14.jpg', '~/Content/icons/map/rim_r22_c8.jpg', '~/Content/icons/map/rim_r22_c12.jpg', '~/Content/icons/map/rim_r17_c14_s6.jpg', '~/Content/icons/map/rim_r17_c16_s8.jpg', '~/Content/icons/map/rim_r17_c17_s6.jpg', '~/Content/icons/map/rim_r19_c17_s6.jpg', '~/Content/icons/map/rim_r19_c20_s8.jpg', '~/Content/icons/map/rim_r20_c16_s6.jpg', '~/Content/icons/map/rim_r20_c17_s4.jpg', '~/Content/icons/map/rim_r20_c20_s6.jpg', '~/Content/icons/map/rim_r21_c14_s8.jpg', '~/Content/icons/map/rim_r21_c17_s6.jpg', '~/Content/icons/map/rim_r21_c18_s4.jpg', '~/Content/icons/map/rim_r23_c14_s6.jpg', '~/Content/icons/map/rim_r24_c14_s6.jpg', '~/Content/icons/map/rim_r24_c15_s8.jpg', '~/Content/icons/map/rim_r24_c18_s6.jpg', '~/Content/icons/map/rim_r24_c19_s4.jpg', '~/Content/icons/map/rim_r26_c20_s4.jpg', '~/Content/icons/map/rim_r27_c14_s4.jpg', '~/Content/icons/map/rim_r27_c15_s6.jpg', '~/Content/icons/map/rim_r20_c17.jpg', '~/Content/icons/map/rim_r20_c20.jpg', '~/Content/icons/map/rim_r21_c17.jpg', '~/Content/icons/map/rim_r21_c18.jpg', '~/Content/icons/map/rim_r23_c14.jpg', '~/Content/icons/map/rim_r24_c14.jpg', '~/Content/icons/map/rim_r24_c15.jpg', '~/Content/icons/map/rim_r24_c18.jpg', '~/Content/icons/map/rim_r24_c19.jpg', '~/Content/icons/map/rim_r26_c20.jpg', '~/Content/icons/map/rim_r27_c14.jpg', '~/Content/icons/map/rim_r27_c15.jpg', '~/Content/icons/map/rim_r19_c20_s6.jpg', '~/Content/icons/map/rim_r19_c21_s6.jpg', '~/Content/icons/map/rim_r19_c22_s6.jpg', '~/Content/icons/map/rim_r20_c20_s4.jpg', '~/Content/icons/map/rim_r20_c21_s4.jpg', '~/Content/icons/map/rim_r20_c22_s4.jpg', '~/Content/icons/map/rim_r25_c22_s4.jpg', '~/Content/icons/map/rim_r20_c21.jpg', '~/Content/icons/map/rim_r25_c22.jpg', '~/Content/icons/map/rim_r21_c12_s6.jpg', '~/Content/icons/map/rim_r21_c14_s4.jpg', '~/Content/icons/map/rim_r21_c17_s4.jpg', '~/Content/icons/map/rim_r22_c12_s4.jpg', '~/Content/icons/map/rim_r23_c12_s4.jpg', '~/Content/icons/map/rim_r23_c14_s4.jpg', '~/Content/icons/map/rim_r24_c14_s4.jpg', '~/Content/icons/map/rim_r24_c15_s6.jpg', '~/Content/icons/map/rim_r23_c12.jpg', '~/Content/icons/map/rim_r24_c15_s4.jpg', '~/Content/icons/map/rim_r24_c18_s4.jpg', '~/Content/icons/map/rim_r27_c15_s4.jpg', '~/Content/icons/map/rim_r28_c15_s4.jpg', '~/Content/icons/map/rim_r28_c15.jpg');
}
