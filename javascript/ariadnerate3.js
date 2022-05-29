// COPYRIGHT TALCOTT bv THE NETHERLANDS

/// in html
///<meta name="viewport" content="width=device-width, maximum-scale=1.0" /> : width of the device
///<meta name="viewport" content="width=width, maximum-scale=1.0" /> : width of the availeble screen

//SHOW SAVE RESULT

var saveResult = "";
var saveSucceededN = 0;
var saveNotSucceededN = 0;


// DATA CONDITIONS

var maxtextlength = 100;


// RATE CONDITIONS

var groupmaxn = 5;
var itemmaxn = 100;

// ITEM CARDS

var cardbackcolor = "#FFFF99";
var cardbordercolor = "grey";
var cardbordersize = 1;
var cardstyle = 2;

var moved = 4;

var cornerRadius = 0;
var cornerRadiusFromSw = 30;

var w3=0;
var h3=0;
var sw = 0;  //card width
var sh = 0;  //card height
//card width
var mx = 8;
var my = 8;

var mcx = 0; //space between non rated items

var lineHeightNow = 0;
// CARD TEXT

var tmx = 6;
var tmy = 10;

//RANDOM SHUFLING
var cardr = new Array(itemmaxn);
var cardo = new Array(itemmaxn);
var showNumber = false;

//PAGE LAYOUT

var sizeHelpText = 30;
var lineSub = 0;  //devision between rated and non rated items
var sw2 = 0;      //rate cell width
var sh2 = 0;      //rate cell height

//VARS

var varsall = new Array(14999);

var cardn = 0;


var rates = new Array(groupmaxn);
var ratesN = new Array(groupmaxn);
var ratesCol = new Array(groupmaxn);

//read in these and then translate to available items;


var cardg = new Array(cardn.value);
var cardt = new Array(cardn.value);
var carddroworder = new Array(cardn.value);

var cardx = new Array(cardn.value);
var cardy = new Array(cardn.value);

var cardsel = 0;

var ratesV = "Not Defined";
var ratesC = new Array(groupmaxn);


//TO MOVE
var cardxn;
var cardyn;
var cardxd = 0;
var cardyd = 0;


var ccc = document.createElement('canvas')
document.body.appendChild(ccc);
var ccctx = ccc.getContext('2d');

createCanvas();


jQuery(document).ready(function ($) {
    var deviceAgent = navigator.userAgent.toLowerCase();
    var agentID = deviceAgent.match(/(iphone|ipod|ipad)/);
    if (agentID) {

        // mobile code here
        mobile = true;
    }
    else
    {
        mobile = false;
    }
});

function loaded() {

    cc = document.getElementById('SortCanvas');
    //cc.style.visibility = 'hidden';
    cctx = cc.getContext("2d");


    cctx.textAlign = 'left';
    cctx.textBaseline = "top";

    

    db = document.getElementById('datablock');
    db.style.visibility = 'hidden';


    dft = document.getElementById('itemData');
    //dfs = document.getElementById('sortData');
    dfr = document.getElementById('rateData');
    if (dft.value != '') {
        readdataall();

    }
    dvn = document.getElementById('RateTextBox1N');
    if (dvn.value.trim() != "") {
        if (parseInt(dvn.value) != 0) {
            groupmaxn = dvn.value - 1;

            dvv = document.getElementById('RateTextBox1');
            dvc1 = document.getElementById('RateTextBox11');
            dvc2 = document.getElementById('RateTextBox12');
            dvc3 = document.getElementById('RateTextBox13');
            dvc4 = document.getElementById('RateTextBox14');
            dvc5 = document.getElementById('RateTextBox15');

            ratesV = dvv.value;
            ratesC[1] = dvc1.value;
            ratesC[2] = dvc2.value;
            ratesC[3] = dvc3.value;
            ratesC[4] = dvc4.value;
            ratesC[5] = dvc5.value;
        }
        else {

            groupmaxn = 5;
            ratesV = "importance";
            ratesC[1] = "not important";
            ratesC[2] = "less important";
            ratesC[3] = "in between";
            ratesC[4] = "important";
            ratesC[5] = "very important";
        }
    }
    //arrb = document.getElementById('arrangebutton');

    if (document.getElementById("saveThis").value != "yes") { document.getElementById("saverateresulttoserverandback").style.visibility = "hidden"; }


    ///TOUCH////

   // ontouchmove
   // ontouchend 
   // ontouchcancel 
   // orientationchange 
  //  gesturestart 
  //  gesturechange
    //  gestureend

    //if (window.Touch) {
        window.addEventListener('load', function () {
            var startx = 0
            var dist = 0

            //document.body.addEventListener('orientationchange', function (e) {
            //    e.preventDefault();
            //    reload();

            //    e.preventDefault();
            //}, false)
            document.body.addEventListener('touchstart', function (e) {
                
                var touchobj = e.changedTouches[0]; // reference first touch point (ie: first finger)
                //startx = parseInt(touchobj.clientX) // get x position of touch point relative to left edge of browser
                //statusdiv.innerHTML = 'Status: touchstart<br /> ClientX: ' + startx + 'px'

                cardselect(touchobj);

                //e.preventDefault();
            }, false)

            document.body.addEventListener('touchmove', function (e) {
                
                var touchobj = e.changedTouches[0];// reference first touch point for this event
                //var dist = parseInt(touchobj.clientX) - startx
                //statusdiv.innerHTML = 'Status: touchmove<br /> Horizontal distance traveled: ' + dist + 'px'

                cardmove(touchobj);

                e.preventDefault();
            }, false)

            document.body.addEventListener('touchend', function (e) {
                
                var touchobj = e.changedTouches[0]; // reference first touch point for this event
                //statusdiv.innerHTML = 'Status: touchend<br /> Resting x coordinate: ' + touchobj.clientX + 'px'

                carddeselect(touchobj);

                //e.preventDefault();
            }, false)

        }, false)
    //}

    ///TOUCH////

    if (cctx) {

        //drawcardsandgroups() 

        document.onmousedown = cardselect;
        document.onmousemove = cardmove;
        document.onmouseup = carddeselect;

        ///cc.onmousedown = startDraw;
        ///cc.onmouseup = stopDraw;
        ///cc.ontouchstart = handleStart;
        ///cc.ontouchstop = handleEnd;
        ///cc.ontouchmove = handleMove;


    }
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

    document.forms[0].width =w3;
    document.forms[0].height = h3;
    document.forms[0].style.top = '0px';
    document.forms[0].style.left = '0px';

    cc.width = w3;
    cc.height = h3;
    cc.style.top = '0px';
    cc.style.left = '0px';

 


    var nPerRow = parseInt(cardn / (groupmaxn * 2)) + 1;

    //sw = parseInt((cc.width - (mx+ mx * (2 * groupmaxn))) / (2 * groupmaxn));

    sw2 = (cc.width - (mx + mx * groupmaxn)) / (groupmaxn);

    sw = (sw2 - 3 * mx) / 2;

    sh = ((cc.height - sizeHelpText) - (nPerRow + 4) * my) / (nPerRow + 1);

    if (sh > 120) sh = 120;

    sh2 = cc.height - (sh + 3 * my + sizeHelpText);


    cornerRadius = parseInt(sw / cornerRadiusFromSw)

    lineSub = cc.height - (sh + 2 * my);



    mcx = parseInt((cc.width - (2 * mx + sw)) / cardn);
    if (mcx > 20) mcx = 20;



    resetfont();
    ccc.width = sw+10;
    ccc.height = sh+10;

    if (dft.value != '') {
        redrawcards(true);
    }
}
function resetfont() {

    
    cctx.font = '8px Helvetica'
    lineHeightNow = 10;
    if (sh > 60 && sw > 90) { cctx.font = '9px Helvetica'; lineHeightNow = 11; }
    if (sh > 70 && sw > 105) { cctx.font = '10px Helvetica'; lineHeightNow = 12; }
    if (sh > 80 && sw > 120) { cctx.font = '11px Helvetica'; lineHeightNow = 13; }
    if (sh > 90 && sw > 135) { cctx.font = '12px Helvetica'; lineHeightNow = 14; }
    if (sh > 100 && sw > 150) { cctx.font = '13px Helvetica'; lineHeightNow = 15; }


    ccctx.font = '8px Helvetica';
    if (sh > 60 && sw > 90) { ccctx.font = '9px Helvetica'; }
    if (sh > 70 && sw > 105) { ccctx.font = '10px Helvetica'; }
    if (sh > 80 && sw > 120) { ccctx.font = '11px Helvetica'; }
    if (sh > 90 && sw > 135) { ccctx.font = '12px Helvetica'; }
    if (sh > 100 && sw > 150) { ccctx.font = '13px Helvetica'; }
   
    var shw = ((cc.height - lineSub) - 15);
    var sbut = document.getElementById("saverateresulttoserverandback");
    sbut.style.width = shw + 'px';
    sbut.style.height = shw + 'px';
    
}


function saverateresult() {

    dfr.value = "";
    if (cardn < 1000) { dfr.value = "" + cardn; }
    if (cardn < 100) { dfr.value = " " + cardn; }
    if (cardn < 10) { dfr.value = "  " + cardn; }
    for (var i = 1; i < cardn + 1; i++) {
        dfr.value += cardg[i];
        if (rates[i] < 10) {
            dfr.value += " " + rates[i];
        }
        else {
            dfr.value += rates[i];
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

    for (var i = 0; i < cardn; i++) {

        //cardg[i + 1] = dft.value.substr(3 + i * (36 + maxtextlength), 36);
        //cardt[i + 1] = dft.value.substr(3 + i * (36 + maxtextlength) + 36, maxtextlength);
        //rates[i + 1] = 0;
        //carddroworder[i + 1] = cardn - i;


        cardg[cardr[i] + 1] = dft.value.substr(3 + i * (36 + maxtextlength), 36);
        cardt[cardr[i] + 1] = dft.value.substr(3 + i * (36 + maxtextlength) + 36, maxtextlength);
        cardo[cardr[i] + 1] = i + 1;
        rates[cardr[i] + 1] = 0;
        carddroworder[cardr[i] + 1] = cardn - i;
    }

    //RATE 
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


function redrawcards(doorder) {


    var Fold = ""
    var ratetexte = "";
    var metrics = "";
    var mtext = 20;

    cctx.clearRect(0, 0, cc.width, cc.height);

    cctx.fillStyle = "#F2F2F2";
    cctx.straightRect(0, 0, cc.width, cc.height);
    cctx.fill();

    cctx.fillStyle = 'Black';
    cctx.lineWidth = 3;

    var xx = 0; var x = 0;
    for (var i = 1; i < groupmaxn + 1; i++) {
        var ratetext = "";
        switch (i) {
            case 0:
                cctx.fillStyle = "#00802B";
                ratetext = "";
                break;
            case 1:
                cctx.fillStyle = "#0040FF";
                ratetext = ratesC[1];
                //if (ratetext.trim() == "") ratetext = "not important";
                break;
            case 2:
                cctx.fillStyle = "#6495ED";
                ratetext = ratesC[2];
                //if (ratetext.trim() == "") ratetext = "less important";
                break;
            case 3:
                cctx.fillStyle = "#C3C3C3";
                ratetext = ratesC[3];
                //if (ratetext.trim() == "") ratetext = "in between";
                break;
            case 4:
                cctx.fillStyle = "#FF6347";
                ratetext = ratesC[4];
                //if (ratetext.trim() == "") ratetext = "important";
                break;
            case 5:
                cctx.fillStyle = "#FF0040";
                ratetext = ratesC[5];
                //if (ratetext.trim() == "") ratetext = "very important";
                break;

        }

        cctx.fillStyle = "#C3C3C3";
        cctx.strokeStyle = "#FFFFFF";


        x = mx + (i - 1) * (sw2 + mx);
        y = my;

        cctx.beginPath();
        cctx.moveTo(xx, 0);
        //cctx.lineTo(xx, lineSub);
        //cctx.fillRect(x, y, sw2, sh2);
        cctx.straightRect(x, y, sw2, sh2);
        //cctx.stroke();
        cctx.fill();

        Fold = cctx.font;


        var sizetext = 20;
        cctx.font = sizetext + 'px Helvetica';
        metrics = cctx.measureText(ratetext)
        cctx.fillStyle = "white";
        cctx.fillText(ratetext, x + .5 * (sw2 - metrics.width), y + sh2 - mtext);

        var sizenumber = sw2;
        cctx.font = sizenumber + 'px Helvetica';
        ratetext = i;
        metrics = cctx.measureText(ratetext)
        cctx.fillStyle = "white";
        cctx.fillText(ratetext, x + .5 * (sw2 - metrics.width), y + sh2 - (2 * 20 + sizetext));

        cctx.font = Fold;
    }

    for (var i = 0; i < groupmaxn + 1; i++) {
        ratesN[i] = 0;
        ratesCol[i] = 1;
    }
    var ni = 0;
    var ii = 0;
    var coln = 0;
    for (var ii = 1; ii < cardn + 1; ii++) {

        i = carddroworder[ii]
        if (parseInt(rates[i]) > 0) {
            if (ratesCol[rates[i]] == 0) ratesCol[rates[i]] = 1; else ratesCol[rates[i]] = 0;
            if (i !== cardsel) {


                //cardx[i] = 2 * mx + ratesCol[rates[i]] * (mx + sw) + 2 * (rates[i] - 1) * (mx + sw);

                cardx[i] = mx + (rates[i] - 1) * (sw2 + mx) + mx + ratesCol[rates[i]] * (mx + sw);

                coln = (ratesN[rates[i]] - ratesCol[rates[i]]) / 2;
                cardy[i] = 2 * my + coln * (sh + my);
                //if (parseInt(rates[i]) == 0) {
                //    cardx[i] = mx +  ratesN[rates[i]] *   mcx;
                //    cardy[i] = my + sh2 +my+ sizeHelpText;
                //}
            }
            ratesN[rates[i]] += 1;
            if (i !== cardsel) {
                drawcard(i, rates[i]);
            }
            //if (i == cardsel) {
            //    drawcard(i, rates[i]);
            //}
        }
    }
    for (var ii = 1; ii < cardn + 1; ii++) {

        i = ii; //carddroworder[ii]
        if (parseInt(rates[i]) == 0) {
            if (ratesCol[rates[i]] == 0) ratesCol[rates[i]] = 1; else ratesCol[rates[i]] = 0;
            if (i !== cardsel) {

                cardx[i] = mx + ratesN[rates[i]] * mcx;
                cardy[i] = my + sh2 + my + sizeHelpText;
                drawcard(i, rates[i]);

            }
            ratesN[rates[i]] += 1;

        }
    }

    if (parseInt(rates[carddroworder[cardn]]) == 0) {
        if (doorder == true) drawcard(carddroworder[cardn], rates[carddroworder[cardn]]);
    }

    if (cardsel > 0) drawcard(cardsel, rates[i]);

    helptext(sizeHelpText);


}

function helptext(sizetext) {

    var Fold = ""
    var sorttext = ratesV + ": Get cards from below and place them on the canvasses above.";
    var metrics = "";

    //sizetext = sizetext / 2;
    //var mtext = sizetext / 2;

    Fold = cctx.font;

    cctx.font = sizetext - my + 'pt Helvetica';
    metrics = cctx.measureText(sorttext)
    cctx.fillStyle = "#B3B3B3";

    var xx = .5 * cc.width - .5 * metrics.width;
    var yy = sh2 + sizetext + 1 * my; // .5 * cc.height - .5 * sizetext;

    cctx.fillText(sorttext, xx, yy);
    cctx.font = Fold;
}

function cardselect(e) {

    cardsel = 0;
    cardxn = e.pageX - cc.offsetLeft;
    cardyn = e.pageY - cc.offsetTop;
    var dist = 9999; var low = 999999; var item = 0;
    for (var i = 1; i < cardn + 1; i++) {
        dist = Math.pow((cardx[i] + sw / 2) - cardxn, 2) + Math.pow((cardy[i] + sh / 2) - cardyn, 2);
        if (dist < low) { low = dist; item = i }
    }
    if (low < 12000) {
        cardsel = item;
        cardxd = cardx[cardsel] - cardxn;
        cardyd = cardy[cardsel] - cardyn;
        redrawcards(false);
        ccc.style.top = cardy[cardsel] + "px";
        ccc.style.left = cardx[cardsel] + "px";
        ccc.style.visibility = "visible";
        ccctx.clearRect(0, 0, ccc.width, ccc.height);
        drawselectedcard(cardsel, rates[cardsel]);
    }
}


function carddeselect(e) {

    if (cardsel != 0) {




        if (e.pageY - cc.offsetTop < sh2 + sh / 2) {
            var rr = 1 + parseInt((e.pageX - cc.offsetLeft) / ((cc.width - cc.offsetLeft) / groupmaxn));
            if (rr > groupmaxn) rr = groupmaxn;
            if (rr == 0) rr = 1;
            if (rates[cardsel] != rr) {
                for (var i = 1; i < cardn + 1; i++) {
                    if (cardsel == carddroworder[i]) {
                        for (var ii = i; ii < cardn; ii++) {
                            carddroworder[ii] = carddroworder[ii + 1];
                        }
                    }
                }
                carddroworder[cardn] = cardsel;
            }
            rates[cardsel] = rr;
        }
        else {
            rates[cardsel] = 0;
        }
        cardsel = 0;

        ccc.style.visibility = "hidden";
        redrawcards(false);
        if (document.getElementById("saveThis").value == "yes") {
            saverateresult();
            makeCall2();
            //wraptextSingleLine(cctx, " OK: " + saveSucceededN + ", NOT OK: " + saveNotSucceededN + ", last error message = " + saveResult, 10, cc.height - 20, 1800, 20);
        }
    }
}



function cardmove(e) {

    cardxn = e.pageX - cc.offsetLeft;
    cardyn = e.pageY - cc.offsetTop;

   
        if (cardsel == 0) {
            var dist = 9999; var low = 999999; var item = 0;

            for (var i = 1; i < cardn + 1; i++) {

                dist = Math.pow((cardx[i] + sw / 2) - cardxn, 2) + Math.pow((cardy[i] + sh / 2) - cardyn, 2);
                if (dist < low) { low = dist; item = i }
            }
            if (rates[item] == 0) {
                if (low < 12000) {
                    for (var i = 1; i < cardn + 1; i++) {

                        if (item == carddroworder[i]) {
                            for (var ii = i; ii < cardn; ii++) {
                                carddroworder[ii] = carddroworder[ii + 1];
                            }
                        }

                    }
                    carddroworder[cardn] = item
                    redrawcards(true);
                }
            }
        }
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
}

//}



function createCanvas() {


    ccc.style.position = "absolute";
    ccc.width = 300; //GetWidth();
    ccc.height = 300; //GetHeight();

    ccc.style.visibility = "hidden";
    ccctx.fillStyle = "transparent";
    // ccctx.fillRect(0, 0, 200, 200);
}



function redrawcardsbutton() {
    redrawcards(true);

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
        wraptext(ccctx, cardt[i], tmx + moved, tmy * 1.5 + moved, sw - 2 * tmx, lineHeightNow);

    }
}


function drawcard(i, color) {

    if (i) {

        ///cctx.globalAlpha = .7;

        ///cctx.shadowOffsetX = 6;
        ///cctx.shadowOffsetY = 6;
        ///cctx.shadowBlur = 15;
        ///cctx.shadowColor = "grey";

        if (i !== cardsel) {




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

            //cctx.singleRoundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);

            //cctx.roundRect2(cardx[i], cardy[i], cardx[i] + sw, cardy[i] + sh, cornerRadius);

            //cctx.roundRect(cardx[i], cardy[i],   sw,  sh, cornerRadius);


            //cctx.straightRect(cardx[i], cardy[i], sw, sh);

            //cctx.fillStyle = "#F8F8F8";
            //cctx.fillStyle = "#EEEEEE";

            cctx.fillStyle = cardbackcolor
            cctx.fill();



            //if (color == 0 || i == cardsel) {

            //cctx.strokeStyle = "#080808";
            //cctx.strokeStyle = "white";

            cctx.lineWidth = cardbordersize;
            cctx.strokeStyle = cardbordercolor;
            cctx.stroke();
            //}
            //else {
            //    cctx.strokeStyle = 'none';
            //}


            ///cctx.shadowOffsetX = 0;
            ///cctx.shadowOffsetY = 0;
            ///cctx.shadowBlur = 0;
            ///cctx.shadowColor = "transparant";


            //if (cardsel == i) {
            //    cctx.lineWidth = 4;
            //    //drawcard(cardsel, 1);
            //}



            cctx.fillStyle = "black";
            //cctx.fillText(cardt[i], tm + cardx[i], tm + cardy[i]);
            //cctx.globalAlpha = 1;

            if (showNumber == false) {
                wraptext(cctx, cardt[i], tmx + cardx[i], tmy * 1.5 + cardy[i], sw - 2 * tmx, lineHeightNow);
            }
            else {
                wraptext(cctx, cardo[i] + "-" + cardt[i], tmx + cardx[i], tmy * 1.5 + cardy[i], sw - 2 * tmx, lineHeightNow);
            }

        }
    }
}





function makeCall2() {

  //  

    var obj = {};

    obj.rateData = document.getElementById("rateType").value + document.getElementById("TextBoxProject").value + document.getElementById("TextBoxParticipant").value + document.getElementById("rateData").value;
   
    $.ajax({

        type: "POST",

        url: "AriadneRate.aspx/saveRateDataToServer",

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
            var saveResult = xmlHttp.responseText;
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
            wraptextSingleLine(cctx, " OK: " + saveSucceededN + ", NOT OK: " + saveNotSucceededN + ", last error message = " + saveResult, 10, cc.height - 20, 1800, 20);
        }
    }

    // Build the operation URL
    //var url = "http://localhost:51636/Service.svc";
    var url = "https://www.minds21.org/Service.svc";
    //var url = "http://localhost:64681/ariadne%2014-04-2014/Service.svc";

    // Build the body of the JSON message
    //var body = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Body><Echo xmlns="http://tempuri.org/"><input>';
    //body = body + document.getElementById("rateData").value;
    //body = body + '</input></Echo></s:Body></s:Envelope>';


    //var body = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Header><Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService/SaveData</Action></s:Header><s:Body><SaveData xmlns="http://tempuri.org/"><value>';
    var body = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Body><SaveRateData xmlns="http://tempuri.org/"><rateData>';

    body = body + document.getElementById("rateType").value + document.getElementById("TextBoxProject").value + document.getElementById("TextBoxParticipant").value + document.getElementById("rateData").value;
    body = body + '</rateData></SaveRateData></s:Body></s:Envelope>';

    // Send the HTTP request
    xmlHttp.open("POST", url, true);

    xmlHttp.setRequestHeader("Content-type", "text/xml; charset=utf-8");
    xmlHttp.setRequestHeader("SOAPAction", "http://tempuri.org/IService/SaveRateData");

    // xmlHttp.setRequestHeader('<Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService/SaveRateData</Action>');


    xmlHttp.send(body);

}

function keydown(event) {

    if (event != "undifined") {

        if (event.shiftKey && event.keyCode === 78) {   /// N: SHOW NUMBERS
            if (showNumber == false) { showNumber = true; } else { showNumber = false; };
            redrawcards(true);
        }
    }

}

loaded()




