// COPYRIGHT TALCOTT bv THE NETHERLANDS


//SHOW SAVE RESULT

var saveResult = "";
var saveSucceededN = 0;
var saveNotSucceededN = 0;

// DATA CONDITIONS

var maxtextlength = 100;


// RATE CONDITIONS

var groupmaxn = 10;
var itemmaxn = 100;


// ITEM CARDS
 
var cardbackcolor = "#FFFF99";
var cardbordercolor = "grey";
var cardbordersize = 1;
var cardstyle = 2;
var moved = 4;

// YELOOWS

var yellowNumberRadius = 60;

 
var yellowbackcolor = "#FACC2E";
var yellowbordercolor = "#FACC2E";
var yellowbordersize = 0;
var yellowstyle = 1;

var cornerRadius = 0;
var cornerRadiusFromSw = 30;

var w3 = 0;
var h3 = 0;
var sw = 100;
var sh = 60;

var m = 10;

var mcx = 0; //space between non rated items
var mcy = 0; //space between non rated items

// CARD TEXT

var mtx = 8;
var mty = 8;
var lineHeightNow = 0;

//RANDOM SHUFLING
var cardr = new Array(itemmaxn);
var cardo = new Array(itemmaxn);
var showNumber = false;


//PAGE LAYOUT

var lineSub = 0;

//VARS

var varsall = new Array(14999);

var cardn = 0;

 
 
var rates = new Array(groupmaxn);

 

var groups = new Array(itemmaxn);

var groupsn = new Array(cardn.value);
//var groups2 = new Array(groupmaxn + 2);

var groups2 = new Array(groupmaxn + 2);
var groupsnr = new Array(cardn.value);
var groupsr = new Array(cardn.value);
var groups2r = new Array(groupmaxn + 2);
for (var n = 1; n < groupmaxn + 2; n++) {
    groupsn[n] = 0;
    groups2[n] = new Array(cardn.value);
    groups2r[n] = new Array(cardn.value);
}
 
 
 
var cardg = new Array(cardn.value);
var cardt = new Array(cardn.value);
var carddroworder = new Array(cardn.value);
 
var cardx = new Array(cardn.value);
var cardy = new Array(cardn.value);
var cardsel = 0;
var cardup = 0;
var arrayn = groupmaxn.value * cardn.value;
//var groups = new Array(arrayn.value);

var groupsel = 0;
var yellowx = new Array(cardn.value);
var yellowy = new Array(cardn.value);
var yellowt = new Array(cardn.value);

var yellow = new Array(groupmaxn);

//var tooManyGroupsMessage = false;
var cardselold = 0;
 
for (var i = 1; i < groupmaxn + 1; i++) {

    yellowt[i] = 'group ' + i;
    yellowx[i] = 0;
    yellowy[i] = 0;

}

var cardxn;
var cardyn;
var cardxd = 0;
var cardyd = 0;
 
//Number of groups found
var groupNNow = 0;
var groupNNowr = 0;

var ccc = document.createElement('canvas')
document.body.appendChild(ccc);
var ccctx = ccc.getContext('2d');

createCanvas();

function loaded() {

    

    cc = document.getElementById('SortCanvas');
    //cc.style.visibility = 'hidden';
    cctx = cc.getContext("2d");

     
    cctx.textAlign = 'left';
    cctx.textBaseline = "top";

    dv = document.getElementById('form1');

    db = document.getElementById('datablock');
    db.style.visibility = 'hidden';

    yt = document.getElementById('YellowText');
    yt.style.visibility = 'hidden';

    dft = document.getElementById('itemData');
    dfs = document.getElementById('sortData');
    dfr = document.getElementById('rateData');
    dfcx= document.getElementById('xData');
    dfcy = document.getElementById('yData');
   
    dfc = document.getElementById('clusterNames');
   
    if (document.getElementById("saveThis").value != "yes") { document.getElementById("savesortresulttoserverandback").style.visibility = "hidden";  }

    if (dft.value != '') {
        readdataall();
        createyellows();
    }

    ///TOUCH////

    window.addEventListener('load', function () {
        var startx = 0
        var dist = 0

        //document.body.addEventListener('orientationchange', function (e) {
        //    e.preventDefault();
        //    reload();

        //    e.preventDefault();
        //}, false)
        document.body.addEventListener('touchstart', function (e) {

            var touchobj = e.changedTouches[0] // reference first touch point (ie: first finger)
            //startx = parseInt(touchobj.clientX) // get x position of touch point relative to left edge of browser
            //statusdiv.innerHTML = 'Status: touchstart<br /> ClientX: ' + startx + 'px'

            cardselect(touchobj);
           
            //e.preventDefault()
        }, false)

        document.body.addEventListener('touchmove', function (e) {

            var touchobj = e.changedTouches[0] // reference first touch point for this event
            //var dist = parseInt(touchobj.clientX) - startx
            //statusdiv.innerHTML = 'Status: touchmove<br /> Horizontal distance traveled: ' + dist + 'px'

            cardmove(touchobj);

            e.preventDefault();
        }, false)

        document.body.addEventListener('touchend', function (e) {

            var touchobj = e.changedTouches[0] // reference first touch point for this event
            //statusdiv.innerHTML = 'Status: touchend<br /> Resting x coordinate: ' + touchobj.clientX + 'px';

            carddeselect(touchobj);
            
            //e.preventDefault();
        }, false)

    }, false)

    ///TOUCH////
   
    onkeydown = keydown;
    window.onresize = reload;
    
    reload();
   

}


function reload() {

    w3 = $(window).width();
    h3 = $(window).height();

    document.body.width = w3;
    document.body.height = h3;
    document.body.style.top = '0px';
    document.body.style.left = '0px';

    document.forms[0].width = w3;
    document.forms[0].height = h3;
    document.forms[0].style.top = '0px';
    document.forms[0].style.left = '0px';

    cc.width = w3;
    cc.height = h3;
    cc.style.top = '0px';
    cc.style.left = '0px';

    

    sh = parseInt((cc.height - (3 * m)) / 10);
    //sw = parseInt((cc.width - (m * (groupmaxn + 1))) / groupmaxn);

    sw = parseInt(cc.width  / (groupmaxn+4));

    //if (sh > 91) { sh = 91;}
    //if (sw > 140) { sw = 140; }

    cornerRadius = parseInt(sw / cornerRadiusFromSw)
    lineSub = parseInt(cc.height - (sh + 2 * m));
    

    mcx = parseInt((cc.width - (2*m + sw)) / cardn);
    if (mcx > 20) mcx = 20;
    mcy = parseInt((cc.height - (2*m + sh + (cc.height-lineSub))) / (cardn/2));
    if (mcy > 20) mcy = 20;

    resetfont()
    ccc.width = sw + 10;
    ccc.height = sh + 10;

    if (cctx) {

        if (dft.value != '') {
            //readdataall();
            if (dfcx.value != "") {

                readcoordinates();

                var testZeroAll = 0;
                for (var i = 1; i < cardn + 1; i++) {

                    if (cardx[i] == 0 && cardy[i] == 0) { testZeroAll = 1 };

                }
                if (testZeroAll == 0) { //ALS NIET ALLE COORDINATEN 0 ZIJN

                   
                    redrawstock();  //LOST HET PROBLEEM OP VAN DE VERDWENEN KAARTJES
                    drawcardsandgroups();
                   
                }
                else {  //ALS ALLE COORDINATEN 0 ZIJN
                    redrawcards();
                    drawcardsandgroups();
                }

            }
            else { //ALS ER GEEN CLUSTERRECORD IN DE DATABASE IS
                redrawcards();
                drawcardsandgroups();
            }
            document.onmousedown = cardselect;
            document.onmouseup = carddeselect;
            document.onmousemove = cardmove;

        }
       

       
    }

}


function resetfont() {

    cctx.font = '8px Helvetica'
    lineHeightNow = 10;
    yellowNumberRadius = 25;
    if (sh > 60 && sw > 90) { cctx.font = '9px Helvetica'; lineHeightNow = 11; yellowNumberRadius=30; }
    if (sh > 70 && sw > 105) { cctx.font = '10px Helvetica'; lineHeightNow = 12; yellowNumberRadius = 40; }
    if (sh > 80 && sw > 120) { cctx.font = '11px Helvetica'; lineHeightNow = 13; yellowNumberRadius = 50; }
    if (sh > 90 && sw > 135) { cctx.font = '12px Helvetica'; lineHeightNow = 14; yellowNumberRadius = 60; }
    if (sh > 100 && sw > 150) { cctx.font = '13px Helvetica'; lineHeightNow = 15; yellowNumberRadius = 70; }


    ccctx.font = '8px Helvetica';
    if (sh > 60 && sw > 90) { ccctx.font = '9px Helvetica'; }
    if (sh > 70 && sw > 105) { ccctx.font = '10px Helvetica'; }
    if (sh > 80 && sw > 120) { ccctx.font = '11px Helvetica'; }
    if (sh > 90 && sw > 135) { ccctx.font = '12px Helvetica'; }
    if (sh > 100 && sw > 150) { ccctx.font = '13px Helvetica'; }

    var shw = .75 * ((cc.height - lineSub) - 15);
    var sbut = document.getElementById("savesortresulttoserverandback");
    sbut.style.width = shw + 'px';
    sbut.style.height = shw + 'px';
    

}

function createyellows() {

    for (var i = 1; i < groupmaxn + 1; i++) {
        
        yellow[i] = document.createElement("textarea");
        yellow[i] = dv.appendChild(yellow[i]);
        if (i < 10) bbt = "yellow0" + i;
        if (i > 9) bbt = "yellow" + i;
        yellow[i].id = bbt;
        //yellow[i].style.visibility = 'hidden';
        yellow[i].onchange = savecoordinates;
        //if (i < 10) {
        //    yy = document.getElementById("yellow0" + i).onchange = savecoordinates;
            //yy = document.getElementById("yellow0" + i).onmouseleave = savecoordinates;
        //}
        //else {
        //    document.getElementById("yellow" + i).onchange = savecoordinates;
            //document.getElementById("yellow" + i).onmouseleave = savecoordinates;
        //}
        
        //if (i < 10) {
       //     yellow[i] = document.getElementById("yellow0" + i);
        //}
        //else {
        //    yellow[i] = document.getElementById("yellow" + i);
        //}

        //yellow[i].setAttribute("onchange", function () { savecoordinates(); });
        //yellow[i].onchange = savecoordinates();
        //yellow[i].setAttribute("onchange", savecoordinates());

        //yellow[i].style.visibility = 'visible';
        
        //yellow[i].value = "added on the fly";
        //yellow[i].style.backgroundColor = "black";
        //yellow[i].style.backgroundColor = "yellow";
        //yellow[i].style.backgroundColor = "grey";


        yellow[i].value = yellowt[i];

        
        //yellow[i].style.align ="top";
        yellow[i].style.position = "absolute";
        yellow[i].style.width =  '0px';
        yellow[i].style.height = '0px';
        yellow[i].style.left = "0px";
        yellow[i].style.top = "0px";

        yellow[i].style.backgroundColor = "white";
        yellow[i].style.overflow = "hidden";
        yellow[i].style.borderStyle = "solid";
        yellow[i].style.borderWidth= "1px";
        yellow[i].style.borderColor = yellowbordercolor;
        yellow[i].style.padding = "3px";
        yellow[i].style.margin = "0px";
        yellow[i].style.fontFamily = "Helvetica";
        yellow[i].style.fontSize = "10px";


  
        yellow[i].style.visibility = 'hidden';

    }

}

function savecoordinates() {


    dfcx.value = ""; 
    if (cardn < 1000) { dfcx.value = "" + cardn; }
    if (cardn < 100) { dfcx.value = " " + cardn; }
    if (cardn < 10) { dfcx.value = "  " + cardn; }
    dfcy.value = dfcx.value;
    var xc = 0;
    var yc = 0;
    for (var i = 1; i < cardn + 1; i++) {

        xc = cardx[i] / cc.width;
        //yc = cardy[i] / cc.height; // XXX
        yc = cardy[i] / lineSub;

        if (xc >= 0 && xc <= 1) {
            dfcx.value += cardg[i];
            dfcx.value += xc.toFixed(4);
        }
        else {
            xc = 0;
            dfcx.value += cardg[i];
            dfcx.value += xc.toFixed(4);

        }
        if (yc >= 0 && yc <= 1) {
            dfcy.value += cardg[i];
            dfcy.value += yc.toFixed(4);
        }
        else {
            yc = 0;
            dfcy.value += cardg[i];
            dfcy.value += yc.toFixed(4);
        }

       
    }

    dfc.value = "";
    for (var c = 1; c < groupmaxn + 1; c++) {

        yellowt[c] = yellow[c].value;
        dfc.value += fixedLength(yellowt[c],90);   

    }
    
}
function readcoordinates() {

    var xc = 0;
    var yc = 0;
    var posg = ""; 
    var cardnSaved = dfcx.value.substr(0, 3).valueOf();

    for (var i = 0; i < cardn ; i++) {
        cardx[i + 1] = .1;
        cardy[i + 1] = .9;
      
    }
    for (var is = 0; is < cardnSaved ; is++) {

        posg = dfcx.value.substr(3 + is * 42, 36);
        xc = parseFloat(dfcx.value.substr(3 + is * 42 + 36, 6));
        for (var i = 0; i < cardn ; i++) {
            if (posg == cardg[i + 1]) {
                if (xc >= 0 && xc <= 1) {
                    cardx[i + 1] = xc * cc.width;
                }
            }
        }

        posg = dfcy.value.substr(3 + is * 42, 36);
        yc = parseFloat(dfcy.value.substr(3 + is * 42 + 36, 6));
        for (var i = 0; i < cardn  ; i++) {
            if (posg == cardg[i + 1]) {
                if (yc >= 0 && yc <= 1) {
                    //cardy[i + 1] = yc * cc.height; // XXX
                    cardy[i + 1] = yc * lineSub;
                }
            }
        }
       
   
    }

    for (var c = 1; c < groupmaxn + 1; c++) {

        
        yellowt[c] = dfc.value.substr((c - 1) * 90, 90);
        yellow[c].value = yellowt[c].trim();
    }
}

function savesortresult() {
    
    dfs.value = "";
    if (cardn < 1000) { dfs.value = "" + cardn; }
    if (cardn < 100) { dfs.value = " " + cardn; }
    if (cardn < 10) { dfs.value = "  " + cardn; }
    for (var g = 1; g < groupmaxn + 1; g++) {
        if (groupsn[g] < 10) {
            dfs.value += " " + groupsn[g];
        }
        else {
              dfs.value += groupsn[g];
        }
    }

    for (var g = 1; g < groupmaxn + 1; g++) {
        for (var i = 1; i < groupsn[g] + 1; i++) {

            dfs.value += cardg[groups2[g][i]];
        }
    }
}

function readdataall() {
 
    //CARDS 

    cardn = parseInt(dft.value.substr(0, 3));

    var done = 0;
    for (var i = 0; i < cardn; i++) { cardr[i] = 0; }
    for (var i = 0; i < cardn; i++) {

        var rand = Math.round(-.5 + Math.random() * cardn); done = 1;
        for (var ii = 0; ii < i; ii++) {
            if (cardr[ii] == rand) { i -= 1; done = 0; break; }
        }
        if (done == 1) cardr[i] = rand;
    }

    //groupsn[1] = cardn;
    //groups[1] = 1;
    for (var i = 0; i < cardn; i++) {

        //cardg[i + 1] = dft.value.substr(3 + i * (36 + maxtextlength), 36);
        //cardt[i + 1] = dft.value.substr(3 + i * (36 + maxtextlength) + 36, maxtextlength);
        //rates[i + 1] = 0;
        //groups[i + 1] = 0;
        ////groups2[1][i] = i;
        //carddroworder[i + 1] = cardn - i;

        cardg[cardr[i] + 1] = dft.value.substr(3 + i * (36 + maxtextlength), 36);
        cardt[cardr[i] + 1] = dft.value.substr(3 + i * (36 + maxtextlength) + 36, maxtextlength);     

        carddroworder[cardr[i] + 1] = cardn - i;

        cardo[cardr[i] + 1] = i + 1;

        rates[i + 1] = 0;
        groups[i + 1] = 0;
        


    }
   
    //SORT
    if (dfs.value != '') {

        var cardnSaved = dfs.value.substr(0, 3).valueOf();
        for (var g = 1; g < groupmaxn + 1; g++) {


            groupsn[g] = parseInt(dfs.value.substr(3 + (g - 1) * 2, 2));


        }
        var pos = 0; var ni = 0; var sortg = "";
        for (var g = 1; g < groupmaxn + 1; g++) {
            ni = 0;
            for (var is = 1; is < groupsn[g] + 1; is++) {


                sortg = dfs.value.substr(3 + 2 * groupmaxn + pos * 36, 36);

                //groups[groups2[g][i]] = g
                pos += 1;

                for (var i = 0; i < cardn; i++) {
                    if (sortg == cardg[i + 1]) { ni += 1; groups2[g][ni] = i + 1; }
                }

            }


        }

        for (var g = 1; g < groupmaxn + 1; g++) {
            if (groupsn[g] > 0) {

                for (var ci = 1; ci < groupsn[g] + 1; ci++) {

                    groups[groups2[g][ci]] = g;
                }
            }
        }

        if (dfr.value != '') {

            var cardnSaved = dfr.value.substr(0, 3).valueOf();
            var ratesg = ""; var ratesr = "";

            if (cardnSaved > 0) {
                for (var is = 0; is < cardnSaved ; is++) {

                    ratesg = dfr.value.substr(3 + is * 38, 36);
                    ratesr = parseInt(dfr.value.substr(3 + is * 38 + 36, 2));

                    //pos += 1;
                    for (var i = 0; i < cardn; i++) {

                        if (ratesg == cardg[i + 1]) { rates[i + 1] = ratesr; }

                    }
                }
            }
        }
    }
}



function cardselect(e) {

    if (groupsel == 0) {
        for (var g = 1; g < groupmaxn + 1; g++) {
            yellow[g].style.visibility = 'hidden';
        }

        cardxn = e.pageX - cc.offsetLeft;
        cardyn = e.pageY - cc.offsetTop;


        var dist = 9999; var low = 999999; var item = 0;

        for (var g = 1; g < groupNNow + 1; g++) {

            dist = Math.pow(Math.pow(yellowx[g] - cardxn, 2) + Math.pow(yellowy[g] - cardyn, 2), .5);
            if (dist < low) { low = dist; item = g }
        }

        if (low < 1 * (5 + yellowNumberRadius / 2)) { //4 for padding = 3 and border = 1  + 1.4 maal (half wortel twee) om hoeken te bereiken
            groupsel = item;

            yellow[groupsel].style.width = yellowNumberRadius * 2 + 'px';
            yellow[groupsel].style.height = yellowNumberRadius * 2 + 'px';

            yellow[groupsel].style.left = cc.offsetLeft + yellowx[groupsel] - (yellowNumberRadius + 5) + 'px';
            yellow[groupsel].style.top = cc.offsetTop + yellowy[groupsel] - (yellowNumberRadius + 5) + "px";


            yellow[groupsel].style.visibility = 'visible';


            yellow[groupsel].focus();
            return;
            //setCaretPosition(yellow[groupsel], 0)

        }
    }
    //if (low < 2 * (5 + yellowNumberRadius / 2)) {
       // groupsel = 0;
    //}

    if (groupsel == 0) {
        //Find item
        dist = 9999; low = 999999; item = 0;

        for (var i = 1; i < cardn + 1; i++) {

            dist = Math.pow((cardx[i] + sw / 2) - cardxn, 2) + Math.pow((cardy[i] + sh / 2) - cardyn, 2);
            if (dist < low) { low = dist; item = i }
        }
        if (low < 12000) {
            cardsel = item;
            cardxd = cardx[cardsel] - cardxn;
            cardyd = cardy[cardsel] - cardyn;
            groupsel = 0;

            drawcardsandgroups();
            ccc.style.top = cardy[cardsel] + "px";
            ccc.style.left = cardx[cardsel] + "px";
            //ccc.style.width = sw + 'px';
            //ccc.style.height = sh + 'px';
            ccc.style.visibility = "visible";
            ccctx.clearRect(0, 0, ccc.width, ccc.height);
            drawselectedcard(cardsel, groups[carddroworder[cardsel]]);

        }
    }



    // if (groupsel > 0) {

    //var ddd = yellow[groupsel].selectionStart;
    //yellow[groupsel].setSelectionRange(0, 0);
    //yellow[groupsel].focus();
    // yellow[groupsel].select();
    //yellow[groupsel].SelectionStart = 0;
    //yellow[groupsel].SelectionEnd = 0;
    //}
}


function doGetCaretPosition(ctrl) {
    var CaretPos = 0;
    // IE Support     
    if (document.selection) {
        ctrl.focus();
        var Sel = document.selection.createRange();
        Sel.moveStart('character', -ctrl.value.length);
        CaretPos = Sel.text.length;
    }
        // Firefox support     
    else if (ctrl.selectionStart || ctrl.selectionStart == '0')
        CaretPos = ctrl.selectionStart;
    return (CaretPos);
}

function setCaretPosition(ctrl, pos) {
    if (ctrl.setSelectionRange) {
        ctrl.focus();
        ctrl.setSelectionRange(pos, pos);
    }
    else if (ctrl.createTextRange) {
        var range = ctrl.createTextRange();
        range.collapse(true);
        range.moveEnd('character', pos);
        range.moveStart('character', pos);
        range.select();
    }
}

function carddeselect(e) {

    if (cardsel != 0) {

        for (var i = 1; i < cardn + 1; i++) {

            if (cardsel == carddroworder[i]) {
                for (var ii = i; ii < cardn; ii++) {
                    carddroworder[ii] = carddroworder[ii + 1];
                }
            }

        }
        carddroworder[cardn] = cardsel;
        cardselold = cardsel;
        cardsel = 0;



        findgroups();
        ccc.style.visibility = "hidden";
        drawcardsandgroups();
       
        savecoordinates();
        if (document.getElementById("saveThis").value == "yes") {
            savesortresult();
            //savecoordinates();
            makeCall2();
            
        }
 
    }


}


function cardmove(e) {

    //show selected card and get it face up..

    cardxn = e.pageX - cc.offsetLeft;
    cardyn = e.pageY - cc.offsetTop;

    if (cardsel == 0) {
        var check = 0;
        var dist = 9999
        for (var g = 1; g < 11; g++) {
            dist = Math.pow(Math.pow((yellowx[g]) - cardxn, 2) + Math.pow((yellowy[g]) - cardyn, 2), .5);
            //if (cardxn > yellowx[g] - 20 && cardxn < yellowx[g] + 20 && cardyn > yellowy[g] - 20 && cardyn < yellowy[g] + 20) {
            if (dist < 2.2 * (5 + yellowNumberRadius / 2)) {
                check = 1;
            }
            
        }

        if (check == 0) {

            var dist = 9999; var low = 999999; var item = 0;

            for (var i = 1; i < cardn + 1; i++) {

                dist = Math.pow((cardx[i] + sw / 2) - cardxn, 2) + Math.pow((cardy[i] + sh / 2) - cardyn, 2);
                if (dist < low) { low = dist; item = i }
            }
            if (low < 12000) {
                for (var i = 1; i < cardn + 1; i++) {

                    if (item == carddroworder[i]) {
                        for (var ii = i; ii < cardn; ii++) {
                            carddroworder[ii] = carddroworder[ii + 1];
                        }
                    }

                }
                groupsel = 0;
                carddroworder[cardn] = item
                ccc.style.visibility = "hidden";
                drawcardsandgroups();
            }
        }
    }
    //show card on the move
    if (cardsel != 0) {
        
        if (cardxn < w3 && cardyn < h3) {
            cardx[cardsel] = cardxd + cardxn;
            cardy[cardsel] = cardyd + cardyn;
        }
        if (cardxn > w3 && cardyn < h3) {
            cardx[cardsel] = w3 + cardxd;
            cardy[cardsel] = cardyd + cardyn;
        }
        if (cardxn < w3 && cardyn > h3) {
            cardx[cardsel] = cardxd + cardxn;
            cardy[cardsel] = h3 + cardyd;
        }
        if (cardxn > w3 && cardyn > h3) {
            cardx[cardsel] = w3 + cardxd;
            cardy[cardsel] = h3 + cardyd;;
        }
        ccc.style.top = cardy[cardsel] + "px";
        ccc.style.left = cardx[cardsel] + "px";
        ccc.style.visibility = "visible";

    }

    if (groupsel > 0) {
        yellow[groupsel].focus();
        //yellow[groupsel].select();
        //yellow[groupsel].setSelectionRange(0, 0);
    }
}
 

function createCanvas() {


    ccc.style.position = "absolute";
    ccc.width = 0; //GetWidth();
    ccc.height = 0; //GetHeight();

    ccc.style.visibility = "hidden";
    ccctx.fillStyle = "transparent";
    // ccctx.fillRect(0, 0, 200, 200);
}


function findgroups() {


 
   
    var groupsnrr = new Array(cardn.value);
    var groupsrr = new Array(groupmaxn + 1);
    var groups2rr = new Array(groupmaxn + 2);
    for (var n = 1; n < groupmaxn + 2; n++) {
        groups2rr[n] = new Array(cardn.value);
    }

  


    //MAKE COPY FIRST
    for (var i = 1; i <= cardn ; i++) {
        groupsr[i] = groups[i];
    }
    for (var n = 1; n < groupmaxn + 1; n++) {
        groupsnr[n] = groupsn[n];
        
        for (var i = 1; i < cardn + 1; i++) {

            //groups[(n - 1) * itemmaxn + i] = 0;
            groups2r[n][i] = groups2[n][i];
        }
    }
    groupNNowr = 0;
    for (var n = 1; n <= groupmaxn + 1; n++) {

        if (groupsn[n] > 0) { groupNNowr += 1; }
    }
    
    //END COPY

    var cardfirsthit = 0;
    var groupn = 0;
    var groupcontentn = 0;
        
    var cardinfirstloop = new Array(cardn.value);
    var cardin = new Array(cardn.value);

    for (var i = 1; i <= cardn ; i++) {
        cardinfirstloop[i] = 1;
        groups[i] = 0;
    }
    for (var n = 1; n < groupmaxn + 2; n++) {
        groupsn[n] = 0;
        groupsnrr[n] = 0;
        for (var i = 1; i < cardn + 1; i++) {

            //groups[(n - 1) * itemmaxn + i] = 0;
            groups2[n][i] = 0;
            groups2rr[n][i] = 0;
        }
    }
    for (var n = 1; n < groupmaxn + 2; n++) {         
        cardfirsthit = 0;


        for (var i = 1; i < cardn + 1; i++) {
            cardin[i] = 0;
        }
        for (var iter = 1; iter <= 10; iter++) {
            for (var i = 1; i < cardn + 1; i++) {


                if (cardy[i] < lineSub - sh) {

                    if (cardinfirstloop[i] == 1) {

                        //for (var iter = 1; iter <= 3; iter++) {
                        if (cardin[i] == 1 || cardfirsthit == 0) {
                            for (var ii = 1; ii <= cardn ; ii++) {



                                //if(px.x >= x && px.x <= x + width && px.y >= y && px.y <= y + height)

                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }

                            }
                        }

                        cardfirsthit = 1;
                        if (cardin[i] == 1) {
                            for (var ii = cardn; ii >= 1; ii--) {



                                //if(px.x >= x && px.x <= x + width && px.y >= y && px.y <= y + height)

                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }

                            }
                        }
                        //}

                    }
                }
            }
            for (var i = cardn; i >= 1  ; i--) {


                if (cardy[i] < lineSub - sh) {

                    if (cardinfirstloop[i] == 1) {


                        if (cardin[i] == 1) {
                            for (var ii = 1; ii <= cardn ; ii++) {



                                //if(px.x >= x && px.x <= x + width && px.y >= y && px.y <= y + height)

                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }

                            }
                        }

                        if (cardin[i] == 1) {
                            for (var ii = cardn; ii >= 1; ii--) {



                                //if(px.x >= x && px.x <= x + width && px.y >= y && px.y <= y + height)

                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[i] >= cardx[ii] && cardx[i] <= cardx[ii] + sw && cardy[ii] >= cardy[i] && cardy[ii] <= cardy[i] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }
                                if (cardx[ii] >= cardx[i] && cardx[ii] <= cardx[i] + sw && cardy[i] >= cardy[ii] && cardy[i] <= cardy[ii] + sh) {
                                    cardin[ii] = 1; groupcontentn += 1;
                                }

                            }
                        }
                        //}

                    }
                }
            }
        }
        groupn += 1;
        var itemnnow=0;
        for (var ii = 1; ii <= cardn ; ii++) {
            if (cardin[ii] == 1) {
                cardinfirstloop[ii] = 0;
                groupsn[groupn] += 1;
                groupsnrr[groupn] += 1;
                //groups[(groupn - 1) * itemmaxn + ii] = cardin[ii];
                itemnnow +=1;
                groups2[groupn][itemnnow] = ii;
                groups2rr[groupn][itemnnow] = ii;
            }          
        }
        
    }

    

 
    // IF NOT TOO MANY GROUPS
    if (groupsn[11] > 0) {
        undogrouping();
        //zie website: http://tristanedwards.me/sweetalert 
        sweetAlert("Oops...", "You can only make 10 groups!\nAdd items to the existing groups", "error");
        //swal({ title: "Auto close alert!", text: "I will close in 2 seconds.", timer: 2000 });
        
        //alert('Too many groups.\nOnly 10 groups are allowed.');
        redrawstock();
        //tooManyGroupsMessage = true;
    }
    else {

        

        for (var g = 1; g < groupmaxn + 2; g++) {
            if (groupsn[g] > 0) {
                for (var ci = 1; ci < groupsn[g] + 1; ci++) {
                    groups[groups2[g][ci]] = g;
                }
            }
        }
         groupNNow = 0;
        for (var g = 1; g <= groupmaxn + 1; g++) {
            if (groupsn[g] > 0) { groupNNow += 1; }            
        }

        //ALWAYS THE SAME NUMBER

        var doThis = true;

        if (doThis == true) {


            //Backup of current solution
           
            for (var i = 1; i <= cardn; i++) {
                groupsrr[i] = groups[i];    ///WORDT EERDER OP 0 GEZET
            }

            //for (var g = 1; g < groupmaxn + 2; g++) {
            //    if (groupsn[g] > 0) {
            //        for (var ci = 1; ci < groupsn[g] + 1; ci++) {
            //            groupsrr[groups2[g][ci]] = g;
            //        }
            //    }
            //}

            //define and make 0 clusorder and n of each cluster
            var ClusReorder = new Array(groupmaxn + 1);
            var ClusReorderH = new Array(groupmaxn + 1);
            var ClusUsed = new Array(groupmaxn + 1);
            var ClusNrToUse = new Array(groupmaxn + 1);
            for (var g = 1; g <= groupmaxn + 1; g++) {                       
                ClusReorder[g] = 0;
                ClusReorderH[g] = 0;
                ClusUsed[g] = 0;
                ClusNrToUse[g] =0
            }

            // one counter for clusn
            var gr = 0
            if (groupNNowr > groupNNow) { gr = groupNNowr } else { gr = groupNNow }

            //make correlation matrix beween this and previous solution
            var corr = new Array(groupmaxn + 2);
            for (var g = 0; g <= groupmaxn +1 ; g++) {
                corr[g] = new Array(groupmaxn + 2);
            }
            for (var g = 0; g <= groupmaxn + 1; g++) {
                for (var gg = 0; gg <= groupmaxn +1; gg++) {
                    corr[g][gg] = 0;
                }
            }
            for (var i = 1; i <= cardn; i++) {
                //if (groupsr[i]) {
                    corr[groupsr[i]][groups[i]] += 1;
                //}
            }
            for (var g = 1; g <= groupNNowr ; g++) {
                for (var gg = 1; gg <= groupNNow ; gg++) {
                    corr[g][gg] = corr[g][gg] / Math.pow(groupsnr[g] * groupsn[gg], .5)  ;
                }
            }
            //find corresponding cluster in ols and in new solution
            var clush = 0; var clushv = 0;
            for (var gg = 1; gg <= groupNNow ; gg++) {
                var ch = -999; clush = 0;
                for (var g = 1; g <= groupNNowr ; g++) {
                    if (corr[g][gg] > ch) { ch = corr[g][gg]; clush = g; clushv = ch; }
                }
                ClusReorder[gg] = clush;  //gg gives the old cluster number, ClusReorder[gg] gives the number of the cooresponding current calculated clusters
                ClusReorderH[gg] = clushv;   
            }
           
           
            for (var g = 1; g <= groupNNow ; g++) {
                if (ClusReorderH[g] < .8) { ClusReorder[g] = 0; } else { ClusUsed[ClusReorder[g]] = 1; }
            }
            var count = 0; 
            for (var g = 1; g <= groupNNow ; g++) {
                if (ClusUsed[g] == 0) { count += 1;   ClusNrToUse[count] = g; }
            }
            var count = 0;
            for (var g = 1; g <= groupNNow ; g++) {
                if (ClusReorder[g] == 0) {
                    count += 1;
                    ClusReorder[g] = ClusNrToUse[count]
                }
            }

            //FIRST EMPTY THE GROUPS
            for (var i = 1; i <= cardn; i++) {
                groups[i] = 0;
            //     groups[i] = ClusReorder[groupsrr[i]]; 
            }
            for (var g = 1; g <= groupmaxn ; g++) {
                for (var i = 1; i <= cardn ; i++) {   //i <= groupsnrr[g]
                    groups2[g][i] = 0;
                }
                groupsn[g] = 0;
            }

            //AND FILL AGAIN
            for (var g = 1; g <= groupNNow ; g++) {
                for (var i = 1; i <= cardn ; i++) {   //i <= groupsnrr[g]
                    groups2[ClusReorder[g]][i] = groups2rr[g][i]
                }
                groupsn[ClusReorder[g]] = groupsnrr[g];
            }
            for (var g = 1; g < groupmaxn + 2; g++) {
                if (groupsn[g] > 0) {
                    for (var ci = 1; ci < groupsn[g] + 1; ci++) {
                        groups[groups2[g][ci]] = g;
                    }
                }
            }
             
        }
        
        //END ALWAYS THE SAME NUMBER

        redrawstock();
    }

    function undogrouping() {

        for (var n = 1; n < groupmaxn + 1; n++) {
            groupsn[n] = groupsnr[n];
            for (var i = 1; i < cardn + 1; i++) {

                //groups[(n - 1) * itemmaxn + i] = 0;
                groups2[n][i] = groups2r[n][i];
            }
        }
        groups2[11][1] = 0; groups2[11][2] = 0;
        for (var g = 1; g < groupmaxn + 2; g++) {
            if (groupsn[g] > 0) {
                for (var ci = 1; ci < groupsn[g] + 1; ci++) {
                    groups[groups2[g][ci]] = g;
                }
            }
        }


    }
}



function drawcardsandgroups() {


    cctx.clearRect(0, 0, cc.width, cc.height);




    //cctx.fillStyle = '#F5F5F5';
    cctx.fillStyle = '#4682B4';
    cctx.lineWidth = 2;

    //cctx.singleRoundRect(0, 0, cc.width, lineSub, cornerRadius);
    cctx.straightRect(0, 0, cc.width, lineSub);
    cctx.fillStyle = "#F2F2F2";
    cctx.straightRect(0, lineSub  , cc.width,   cc.height - lineSub);
    cctx.fill();
    
    

    //cctx.beginPath();
    //cctx.moveTo(0, lineSub);
    //cctx.lineTo(cc.width, lineSub);
    //cctx.stroke(); 

    var xtot = 0;
    var ytot = 0;

  
    cctx.textBaseline = "bottom";
    cctx.textAlign = "left";
    for (var i = 1; i < cardn + 1; i++) {
        
            drawcard(carddroworder[i], groups[carddroworder[i]]);       
    }

    for (var n = 1; n < groupmaxn + 1; n++) {

        yellow[n].style.visibility = 'hidden';

        if (groupsn[n] > 0) {

            xtot = 0;
            ytot = 0;
            for (var nn = 1; nn < groupsn[n] + 1; nn++) {

                xtot += cardx[groups2[n][nn]];
                ytot += cardy[groups2[n][nn]] + sh / 4;
            }

            //YELLOWS
            if (cardsel ==0) {
                yellowx[n] = sw/2+ xtot / groupsn[n];
                yellowy[n] = sh/2 + ytot / groupsn[n];
            }
             
           
            drawyellow(n, yellowNumberRadius);
             
        }
        if (groupsel > 0) {
            yellow[groupsel].style.visibility = 'visible';
            //yellow[groupsel].style.left = cc.offsetLeft + yellowx[n] + "px";
            //yellow[groupsel].style.top = cc.offsetTop + yellowy[n] + "px";
        }
    }

    //if (tooManyGroupsMessage == true) {
        //cctx.fillStyle = "black";
        //cctx.font = '24px Calibri'
        //cctx.fillText("Too many groups, add the item below to an existing group", cardx[cardselold]-150, cardy[cardselold] - 28);
        //resetfont();
        //cctx.fillStyle = "white";
    //    groups2[11][1] = 0;
    //    groups[groups2[11][1]] = 0;
    //    alert('Too many groups. Only 10 groups are allowed.');
    //    tooManyGroupsMessage = false;

        
    //}

    
    if (groupsn[2] == 0)   {

        var Fold = ""
        var sizetext = 20;
        var sorttext = "Get cards from below and place them in meaningfull groups on this canvas.";
        var metrics = "";
        var mtext = 20;

        Fold = cctx.font;
        
        cctx.font = sizetext + 'px Helvetica';
        metrics = cctx.measureText(sorttext)
        cctx.fillStyle = "grey";

        var xx = .5* cc.width - .5 * metrics.width;
        var yy = .5* cc.height - .5 * sizetext;

        cctx.fillText(sorttext, xx,yy);

        cctx.font = Fold;
 
    }
    //wraptextSingleLine(cctx, " OK: " + saveSucceededN + ", NOT OK: " + saveNotSucceededN + ", last error message = " + saveResult, 10, 10, 1800, 20);
}

//function redrawcardsbutton() {
//    redrawcards();
//    drawcardsandgroups();
//}

function redrawcards() {

   

    

         
            for (var i = 1; i < cardn + 1; i++) {

                carddroworder[i] = 1 + cardn - i;
            }

            for (var g = 1; g < groupmaxn + 1; g++) {

                var ni = 0;
                for (var i = 1; i < groupsn[g] + 1; i++) {

                    cardx[groups2[g][i]] = m + (g - 1) * (m + sw);
                    cardy[groups2[g][i]] = m + ni * mcy;
                    ni += 1;
                }

            }
            redrawstock();
       
    

}

function redrawstock() {
    var ni = 0;
    for (var ii = 1; ii < cardn + 1; ii++) {
        i = carddroworder[ii];
        if (parseInt(groups[i]) == 0) {
            cardx[i] = m + ni * mcx;
            cardy[i] = m + lineSub;
            ni += 1;
        }

    }
}

 


function del(i, color) {
    switch (color) {
        case 0:
            cctx.strokeStyle = "#004400";
            break;
        case 1:
            cctx.strokeStyle = "#003344";
            break;
        case 2:
            cctx.strokeStyle = "#004455";
            break;
        case 3:
            cctx.strokeStyle = "#005566";
            break;
        case 4:
            cctx.strokeStyle = "#006677";
            break;
        case 5:
            cctx.strokeStyle = "#007788";
            break;

        case 6:
            cctx.strokeStyle = "#227766";
            break;
        case 7:
            cctx.strokeStyle = "#447744";
            break;

        case 8:
            cctx.strokeStyle = "#667722";
            break;
        case 9:
            cctx.strokeStyle = "#887700";
            break;
        case 10:
            cctx.strokeStyle = "#BB7700";
            break;


    }
}

function drawselectedcard(i, color) {

    if (i) {

 
        //ccctx.fillStyle = "#F2F2F2";
      
     
        switch (cardstyle) {
            case 1:
                ccctx.straightRect(0, 0, sw, sh);
                break;
            case 2:
                ccctx.singleRoundRect(0, 0, sw, sh, cornerRadius);
                break;
            case 3:
                ccctx.roundRect(0, 0, sw, sh, cornerRadius);
                break;
            default:

        }
      
        //ccctx.fillStyle = "#080808";
        ccctx.fillStyle = "black";
        ccctx.fill();
        switch (cardstyle) {
            case 1:
                ccctx.straightRect(moved, moved, sw, sh);
                break;
            case 2:
                ccctx.singleRoundRect(moved, moved, sw, sh, cornerRadius);
                break;
            case 3:
                ccctx.roundRect(moved, moved, sw, sh, cornerRadius);
                break;
            default:

        }
        ccctx.fillStyle = cardbackcolor;
        ccctx.fill();
        ccctx.lineWidth = cardbordersize;
        ccctx.strokeStyle = cardbordercolor;
        ccctx.stroke();

        ccctx.fillStyle = "black";
        wraptext(ccctx,   cardt[i], mtx +  moved, m + mty +  moved, sw - 2 * mtx,  lineHeightNow  )
    }
}

function drawcard(i, color) {

    if (i) {

        ///cctx.globalAlpha = .7;

        ///cctx.shadowOffsetX = 6;
        ///cctx.shadowOffsetY = 6;
        ///cctx.shadowBlur = 15;
        ///cctx.shadowColor = "grey";






        //cctx.beginPath();
        //cctx.moveTo(cardx[i], cardy[i]);
        //cctx.lineTo(cardx[i] + sw - cornerRadius, cardy[i]);
        //cctx.arcTo(cardx[i] + sw, cardy[i], cardx[i] + sw, cardy[i] + cornerRadius, cornerRadius);
        //cctx.lineTo(cardx[i] + sw, cardy[i] + sh);
        //cctx.lineTo(cardx[i], cardy[i] + sh);
        //cctx.lineTo(cardx[i], cardy[i]);
        //cctx.closePath();

        //moved = 0;

        if (i !== cardsel) {



            //          switch (cardstyle) {
            //              case 1:
            //                  cctx.straightRect(cardx[i] + moved, cardy[i] + moved, sw, sh);
            //                  break;
            //              case 2:
            //                  cctx.singleRoundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);
            //                  break;
            //              case 3:
            //                  cctx.roundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);
            //                  break;
            //              default:

            //          }
            //          //cctx.singleRoundRect(cardx[i], cardy[i], sw, sh, cornerRadius);
            //          cctx.fillStyle = "#080808";
            //          cctx.fill();
            //          moved = 4;


            //      }

            switch (cardstyle) {
                case 1:
                    cctx.straightRect(cardx[i], cardy[i], sw, sh);
                    break;
                case 2:
                    cctx.singleRoundRect(cardx[i], cardy[i], sw, sh, cornerRadius);
                    break;
                case 3:
                    cctx.roundRect(cardx[i], cardy[i], sw, sh, cornerRadius);
                    break;
                default:

            }



            cctx.fillStyle = cardbackcolor;
            cctx.fill();
            cctx.lineWidth = cardbordersize;
            cctx.strokeStyle = cardbordercolor;
            cctx.stroke();

            ///cctx.shadowOffsetX = 0;
            ///cctx.shadowOffsetY = 0;
            ///cctx.shadowBlur = 0;
            ///cctx.shadowColor = "transparant";


            switch (rates[i]) {
                case 0:
                    cctx.fillStyle = "#00802B";
                    break;
                case 1:
                    cctx.fillStyle = "#0000FF";
                    break;
                case 2:
                    cctx.fillStyle = "#0080FF";
                    break;
                case 3:
                    cctx.fillStyle = "#FFD400";
                    break;
                case 4:
                    cctx.fillStyle = "#FF8000";
                    break;
                case 5:
                    cctx.fillStyle = "#FF0000";
                    break;
            }

            //cctx.fillRect(cardx[i] + sw - cornerRadius, cardy[i], cornerRadius, cornerRadius);

            cctx.fillRect(cardx[i] + sw - cornerRadius + moved, -cornerRadius + cardy[i] + sh + moved, cornerRadius, cornerRadius);

            cctx.fillStyle = "black";
            //cctx.fillText(cardt[i], tm + cardx[i], tm + cardy[i]);
            ///cctx.globalAlpha = 1;
            //wraptext(cctx, cardt[i], m + cardx[i], m / 2 + cardy[i], sw - 2 * m, 16);


            //wraptext(cctx, i + "- " + cardt[i], mtx + cardx[i] , m + mty + cardy[i]  , sw - 2 * mtx, 16);
            if (showNumber == false) {
                wraptext(cctx, cardt[i], mtx + cardx[i], m + mty + cardy[i], sw - 2 * mtx, lineHeightNow);
            }
            else {
                wraptext(cctx, cardo[i] + "-" + cardt[i], mtx + cardx[i], m + mty + cardy[i], sw - 2 * mtx, lineHeightNow);
            }

        }
    }
}

function drawyellow(i, radius) {

    if (i) {
        if (yellowx[i] != 0) {

            
         
            cctx.circle(yellowx[i], yellowy[i], radius/2);
            
            cctx.fillStyle = "white";
            cctx.fill();
            cctx.lineWidth = yellowbordersize;
            cctx.strokeStyle = yellowbordercolor;
            cctx.stroke();
         
            var radius = parseInt(radius * .7);
            cctx.fillStyle = yellowbackcolor;
            cctx.strokeStyle = yellowbordercolor;
            var font_old = cctx.font;
            cctx.font = radius + 'px Calibri';
            cctx.textBaseline = "middle";
            cctx.textAlign = "center";
            //if (i == 10) {
            //    cctx.fillText("0", yellowx[i] - .7 * radius / 2, yellowy[i] + .9 * radius / 2);
            //}
            //else {
            //    cctx.fillText(i, yellowx[i] - .7 * radius / 2, yellowy[i] + .9 * radius / 2);
            //}
             
            cctx.fillText(i, yellowx[i], yellowy[i]);
             
            cctx.textBaseline = "bottom";
            cctx.textAlign = "left";
            cctx.font = font_old;

        }
    }

}

 
 

 

function padString(String, leng) {
    for (i = str.length() ; i <= leng; i++) {
        str += " ";
    }
    return str;
}

function fixedLength(s, n) {
    n = (n < 0) ? 0 : n
    s = s.substr(0, n);
    var a = [];
    a.length = n - s.length + 1;
    return s + a.join(' ');
};




function makeCall2() {

    //      body = body + '<sortData>' + document.getElementById("rateType").value + document.getElementById("TextBoxProject").value + document.getElementById("TextBoxParticipant").value + document.getElementById("sortData").value + '</sortData>';

    //body = body + '<xData>' + document.getElementById("xData").value + '</xData>';
    //body = body + '<yData>' + document.getElementById("yData").value + '</yData>';

    //body = body + '<clusterNames>' + document.getElementById("clusterNames").value + '</clusterNames>';

    var obj = {};

    obj.sortData = document.getElementById("rateType").value + document.getElementById("TextBoxProject").value + document.getElementById("TextBoxParticipant").value + document.getElementById("sortData").value;
    obj.xData = document.getElementById("xData").value;
    obj.yData = document.getElementById("yData").value;
    obj.clusterNames = document.getElementById("clusterNames").value;

    $.ajax({

        type: "POST",

        url: "AriadneSort.aspx/saveSortDataToServer",

        data: JSON.stringify(obj),

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (r) {

            // alert(r.d); //give back result

        },
        error: function (msg) {
            alert('failure to save clusternames: ' + msg);
        }

    });


}

function makeCall() {

    // Create HTTP request
    var xmlHttp;
    try {
        xmlHttp = new XMLHttpRequest();
    } catch (e) {
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                alert("This sample only works in browsers with AJAX support");
                return false;
            }
        }
    }

    // Create result handler 
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4) {
            saveResult = xmlHttp.responseText;
            var indexNow1 = saveResult.indexOf("save OK"); var indexNow2 = 0;
            if (indexNow1 > 0) {
                saveResult = "save OK"
                saveSucceededN += 1;
            }
            else {

                indexNow1 = saveResult.indexOf("<SaveSortDataResult>");
                indexNow2 = saveResult.indexOf("</SaveSortDataResult>");
                saveResult = saveResult.substr(indexNow1, indexNow2 - indexNow1);
                saveNotSucceededN += 1;
            }
            wraptextSingleLine(cctx, " OK: " + saveSucceededN + ", NOT OK: " + saveNotSucceededN + ", last error message = " + saveResult, 10, 10, 1800, 20);
        }
    }

    // Build the operation URL
    //var url = "http://localhost:51636/Service2.svc";
    var url = "https://www.minds21.org/Service2.svc";
    //var url = "http://localhost:64681/ariadne%2014-04-2014/Service2.svc";

    // Build the body of the JSON message
    //var body = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Body><Echo xmlns="http://tempuri.org/"><input>';
    //body = body + document.getElementById("rateData").value;
    //body = body + '</input></Echo></s:Body></s:Envelope>';


    //var body = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Header><Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService2/SaveData</Action></s:Header><s:Body><SaveData xmlns="http://tempuri.org/"><value>';
    var body = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Body><SaveSortData xmlns="http://tempuri.org/">';

        //sortData.Text      
       //xData.Text  
        //yData.Text 
        //cardOrder.Text  
        //clusterNames.Text  
     
    body = body + '<sortData>' + document.getElementById("rateType").value + document.getElementById("TextBoxProject").value + document.getElementById("TextBoxParticipant").value + document.getElementById("sortData").value + '</sortData>';

    body = body + '<xData>' + document.getElementById("xData").value + '</xData>';
    body = body + '<yData>' + document.getElementById("yData").value + '</yData>';

    body = body + '<clusterNames>' + document.getElementById("clusterNames").value + '</clusterNames>';

    body = body + '</SaveSortData></s:Body></s:Envelope>';

    // Send the HTTP request
    xmlHttp.open("POST", url, true);

    xmlHttp.setRequestHeader("Content-type", "text/xml; charset=utf-8");
    xmlHttp.setRequestHeader("SOAPAction", "http://tempuri.org/IService2/SaveSortData");

    // xmlHttp.setRequestHeader('<Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService2/SaveSortData</Action>');


    xmlHttp.send(body);

}
function keydown(event) {

    if (event != "undifined") {

        if (event.shiftKey && event.keyCode === 78) {   /// N: SHOW NUMBERS
            if (showNumber == false) { showNumber = true; } else { showNumber = false; };
            drawcardsandgroups();
        }
    }

}


loaded()
 


 
 