
//COPYRIGHT TALCOTT bv THE NETHERLANDS

// TEST CANVAS

//var ccc = document.createElement('canvas')
//document.body.appendChild(ccc);
//var ccctx = ccc.getContext('2d');

// MARGINS

var mapM = 50; //map margin
var backM = 20;
var textM = 10; //text margin

var sw = 160; //YELLOW width
var sh = 120; //YELLOW height

var w3 = 0;
var h3 = 0;

//COLORS

var colorspectrum = 3; //(has to be 3)

if (colorspectrum == 1) {
    var mapFillstyle = 'Cornsilk'; //background]
    //var mapFontcolor = 'Chocolate';
    var mapFontcolor = 'FireBrick'; //'Brown';
    var importanceColorLight = "Tomato";
    var importanceColor = "red"; //'Scarlet'; //"red";
    var itemDotColor = 'DarkRed';
    var treeLineColor = "Coral";// "LightSalmon";
    var itemsAndNamesColor = "Blue";
    var clustersAndDimensionsFontcolor = "Coral"
}
if (colorspectrum == 2) {
    var mapFillstyle = 'LightYellow'; //background]
    //var mapFontcolor = 'Chocolate';
    var mapFontcolor = 'FireBrick'; //'Brown';
    var importanceColorLight = "Tomato";
    var importanceColor = "red"; //'Scarlet'; //"red";
    var itemDotColor = 'DarkRed';
    var treeLineColor = "DarkOrange";// "LightSalmon";
    var itemsAndNamesColor = "Blue";
    var clustersAndDimensionsFontcolor = 'Orange'; //"DarkOliveGreen"
}

if (colorspectrum == 3) {
    //var mapFillstyle = 'LightYellow'; //background]
    //var mapFontcolor = 'Chocolate'; //'Brown';
    //var importanceColorLight = "Red";
    //var importanceColor = "DarkRed"; //'Scarlet'; //"red";
    //var itemDotColor = 'Chocolate';
    //var treeLineColor = "DarkGreen";// "LightSalmon";
    //var itemsAndNamesColor = "SteelBlue";
    //var clustersAndDimensionsFontcolor = 'DarkOliveGreen'; //"DarkOliveGreen"

    var mapFillstyle = '#FFFEDB';
    var mapFontcolor = '#6F4E37';
    var importanceColorLight = "#FF0000";
    var importanceColor = "#9F000F";
    var itemDotColor = '#C85A17';
    var treeLineColor = "#347C2C";
    var itemsAndNamesColor = "#4863A0";
    var clustersAndDimensionsFontcolor = '#808000';

}

//var buttonFalseColor = 'YellowGreen';
//var buttonTrueColor = 'DarkGreen';

//var buttonFalseColor = 'SteelBlue';
//var buttonTrueColor = 'LightSteelBlue'

// make generic GROUPS from 1,2 or 3 d solution)

var groups = new Array(clustermaxn);
var groupsn = new Array(clustermaxn);
var groupsd = new Array(clustermaxn);
for (var n = 1; n < clustermaxn + 1; n++) {
    groups[n] = new Array(itemmaxn.value);
    groupsn[n] = new Array(itemmaxn.value);
    groupsd[n] = new Array(5);
    for (var nn = 1; nn < clustermaxn + 1; nn++) {
        groups[n][nn] = new Array(clustermaxn.value);
    }
}

groups = groups2;
groupsn = groupsn2;
groupsd = groupsd2;

var groupsOld = new Array(clustermaxn);
for (var n = 1; n < clustermaxn + 1; n++) {
    groupsOld[n] = new Array(itemmaxn.value);
}

// MAP



// MAP TYPE


var sheetNumber = 0;
var rateToUse = 1;

var participantmaxn = 200;

var partx_orig = new Array(participantmaxn.value);
var party_orig = new Array(participantmaxn.value);

var partgx_orig = new Array(participantmaxn.value);
var partgy_orig = new Array(participantmaxn.value);


// TREE 

// GET CLUSTERNAMES FROM TREE

var clusterNameNow = new Array(clustermaxn);

// CLUSTERTREE

var clusternShown = 12;

var groupsX = new Array(clustermaxn);
var groupsY = new Array(clustermaxn);
var clusterHeigth1 = new Array(clustermaxn);
var clusterHeigth2 = new Array(clustermaxn);
for (var n = 1; n < clustermaxn + 1; n++) {
    groupsX[n] = new Array(itemmaxn.value);
    groupsY[n] = new Array(itemmaxn.value);
    clusterHeigth1[n] = new Array(itemmaxn.value);
    clusterHeigth2[n] = new Array(itemmaxn.value);
}


//VARS

var i, d, c, g, r;

//SELCTED CLUSTER MOUSEMOVE..

var clusterSelected = 0;

//CLASSIC MAP

var zeroX = 0;
var zeroY = 0;
//var radius = 4;




var itemcluster = new Array(cardn.value);


var itemwx = new Array(cardn.value);
var itemwy = new Array(cardn.value);
var itemwz = new Array(cardn.value);

var itemxx = new Array(cardn.value);
var itemyy = new Array(cardn.value);

var cardx = new Array(cardn.value);
var cardy = new Array(cardn.value);
var cardwx = new Array(cardn.value);
var cardwy = new Array(cardn.value);
var cardwz = new Array(cardn.value);


var clusterx = new Array(clustermaxn.value);
var clustery = new Array(clustermaxn.value);
var clusterxl = new Array(clustermaxn.value);
var clusteryl = new Array(clustermaxn.value);
var clusterxw = new Array(clustermaxn.value);
var clusteryw = new Array(clustermaxn.value);
for (var n = 1; n < clustermaxn + 1; n++) {
    clusterx[n] = new Array(clustermaxn.value);
    clustery[n] = new Array(clustermaxn.value);
    clusterxl[n] = new Array(clustermaxn.value);
    clusteryl[n] = new Array(clustermaxn.value);
    clusterxw[n] = new Array(clustermaxn.value);
    clusteryw[n] = new Array(clustermaxn.value);
}


var clusterxx = new Array(clustermaxn.value);
var clusteryy = new Array(clustermaxn.value);
var clusterxxl = new Array(clustermaxn.value);
var clusteryyl = new Array(clustermaxn.value);
var clusterxxw = new Array(clustermaxn.value);
var clusteryyw = new Array(clustermaxn.value);
var clusterdist = new Array(clustermaxn);
for (var n = 1; n < clustermaxn + 1; n++) {
    clusterxx[n] = new Array(clustermaxn.value);
    clusteryy[n] = new Array(clustermaxn.value);
    clusterxxl[n] = new Array(clustermaxn.value);
    clusteryyl[n] = new Array(clustermaxn.value);
    clusterxxw[n] = new Array(clustermaxn.value);
    clusteryyw[n] = new Array(clustermaxn.value);
    clusterdist[n] = new Array(clustermaxn);
    for (var nn = 1; nn < clustermaxn + 1; nn++) {
        clusterdist[n][nn] = new Array(clustermaxn);
    }
}



var pXsize = 0;
var pYsize = 0;
var itemselect = new Array(cardn.value);

var yellow = new Array(clustermaxn);

var yellowh = new Array(clustermaxn);
//var yellowth = new Array(clustermaxn);
for (var r = 1; r < clustermaxn + 1; r++) {
    yellowh[r] = new Array(3);
    //yellowth[r] = new Array(3);
}
var mapClusersFromG = new Array(clustermaxn);
var mapClusersFromR = new Array(clustermaxn);





var cardxn;
var cardyn;
var cardxd = 0;
var cardyd = 0;

var startmove = 0;

var clusterxn;
var clusteryn;



//WORLD MAP

var worldsize;
var worldcenterx;
var worldcentery;

var boxMwithin = 60;
var boxMcorner = 40;

var wmy = 9;
var wmx = 9;
var wamy = 11;

var graphPositionH = new Array(cardn.value);

var pilWC = new Array(clustern.value);
var pihWC = new Array(clustern.value);
var pilName = new Array(clustern.value);
var pihName = new Array(clustern.value);
var clusterwx = new Array(clustern.value);
var mxWC3 = new Array(clustern.value);
var myWC3 = new Array(clustern.value);
var mxAbsWC = new Array(clustern.value);
var myAbsWC = new Array(clustern.value);
var lenAbsWC = new Array(clustern.value);

for (var n = 1; n < clustermaxn + 1; n++) {
    pilWC[n] = new Array(clustermaxn.value);
    pihWC[n] = new Array(clustermaxn.value);
    pilName[n] = new Array(clustermaxn.value);
    pihName[n] = new Array(clustermaxn.value);
    clusterwx[n] = new Array(clustermaxn.value);

    mxWC3[n] = new Array(clustermaxn.value);
    myWC3[n] = new Array(clustermaxn.value);
    mxAbsWC[n] = new Array(clustermaxn.value);
    myAbsWC[n] = new Array(clustermaxn.value);
    lenAbsWC[n] = new Array(clustermaxn.value);
    graphPositionH[n] = new Array(clustermaxn.value);
    for (var nn = 1; nn < clustermaxn + 1; nn++) {
        graphPositionH[n][nn] = new Array(itemmaxn.value);
    }
}

//WORDCLOUD
var wordsused = new Array(999);
var wordsusedn = new Array(999);
var wordsusedx = new Array(999);
var wordsusedy = new Array(999);
var wordsusednow = 0;






//WORDCLOUD V+CANVASSES

var ccw = new Array(11);
for (c = 1; c < 10 + 1; c++) {
    ccw[c] = document.createElement('canvas');
    document.body.appendChild(ccw[c]);
    //var ccwtx = ccw[c].getContext('2d');
    ccw[c].style.position = "absolute";
    ccw[c].style.visibility = "hidden";
    ccw[c].width = 1;
    ccw[c].height = 1;
    ccw[c].style.top = 1 + "px";
    ccw[c].style.left = 1 + "px";
}

function removeWordCloud() {
    for (c = 1; c < 10 + 1; c++) {


        ccw[c].style.visibility;
        ccw[c].style.position = "absolute";
        ccw[c].style.visibility = "hidden";
        ccw[c].width = 1;
        ccw[c].height = 1;
        ccw[c].style.top = 1 + "px";
        ccw[c].style.left = 1 + "px";
    }
}



//ITEM RATES

function drawItemRates() {

    //getUserClusterNames();

    cc.onmousedown = "";
    cc.onmousemove = "";



    //document.body.style.overflow = "hidden";
    document.body.style.overflow = "scroll";
    var Rnow = 0;
    for (var r = 0; r < 5; r++) { if (parseInt(ratedefinition[0][r + 1]) > 0) { Rnow += 1; } }


    maxItemWidth = 600;


    lineHeight = 14;
    var m1 = 8; //between rectangles
    var m2 = 2; //between rectangle and text

    var labelH = 22;
    var margeStart = mapM + 10;
    var margeBetween = 40;
    var maxY = 0;

    maxWidth = (cc.width - (maxItemWidth + margeStart * 3 + (Rnow - 1) * margeBetween)) / Rnow;


    maxY = margeStart + labelH + cardn * (lineHeight + m1 + m2 * 2) + margeStart;
    cc.height = maxY;

    cctx.textBaseline = "top";
    cctx.textAlign = "start";

    cctx.globalAlpha = 1;
    cctx.clearRect(0, 0, cc.width, cc.height);
    cctx.lineWidth = 2;
    //cctx.fillStyle = mapFillstyle;
    cctx.fillStyle = 'White';
    cctx.fillRect(0, 0, cc.width, cc.height);
    cctx.fillStyle = mapFillstyle;
    cctx.fillRect(backM, backM, cc.width - 2 * backM, cc.height - 2 * backM);


    drawProjectName();


    cctx.font = '9pt Calibri';
    cctx.fillStyle = itemDotColor;

    x = margeStart;
    y = margeStart;
    wraptextSingleLine(cctx, "items", x, y, maxItemWidth);

    for (var r = 0; r < Rnow; r++) {
        x = margeStart + maxItemWidth + margeBetween + r * (maxWidth + margeBetween);
        //if (parseInt(ratedefinition[0][r+1]) > 0) {
        wraptextSingleLine(cctx, ratedefinition[1][r + 1].trim(), x, y, maxItemWidth);
        //}
    }

    cctx.font = '9pt Calibri';
    var number = "";
    for (var i = 0; i < cardn ; i++) {


        x = margeStart;
        y = margeStart + labelH + i * (lineHeight + m1 + m2 * 2);

        xw = margeStart + maxItemWidth + margeBetween + Rnow * (maxWidth + margeBetween) + margeStart;

        var cornerRadius = lineHeight / 4;

        cctx.lineWidth = 0;
        cctx.roundRect(x, y, xw, lineHeight + 2 * m2, cornerRadius);
        cctx.fillStyle = "white";
        cctx.fill();

        cctx.fillStyle = itemDotColor;;
        if (showItemNumber == true) { number = "(" + (i + 1).toString() + ") "; }
        wraptextSingleLine(cctx, number + cardt[i + 1].trim(), x, y + m2, maxItemWidth);

        for (var r = 0; r < Rnow; r++) {

            if (parseInt(ratedefinition[0][r + 1]) > 0) {

                x = margeStart + maxItemWidth + margeBetween + r * (maxWidth + margeBetween);
                var xw = maxWidth * itemrating[i + 1][r + 1] / ratedefinition[0][r + 1];

                cctx.roundRect(x, y, maxWidth, lineHeight + 2 * m2, cornerRadius);
                cctx.fillStyle = "lightgray";
                cctx.fill();

                //cctx.strokeStyle = mapFontcolor;
                //cctx.stroke();

                cctx.roundRect(x, y + m2, xw, lineHeight, cornerRadius);
                cctx.fillStyle = importanceColorLight;
                cctx.fill();

                //cctx.strokeStyle = mapFontcolor;
                //cctx.stroke();

                cctx.fillStyle = mapFontcolor;
                wraptextSingleLine(cctx, "(" + itemratingn[i + 1][r + 1] + ")", x + maxWidth, y + m2, maxWidth);

            }
        }
    }


    //var dataURL = cc.toDataURL();
    //document.getElementById('canvasImg').src = dataURL;

}

//Calculate IMPORTANCE versus PRIORITY matrix..
function calculateRateMatrix(ratingOnX, ratingOnY) {

    var xh = -9999; var xl = 9999; var yh = -9999; var yl = 9999; var meanX = 0; var meanY = 0;



    for (var i = 1; i < cardn + 1; i++) {
        if (parseFloat(itemrating[i + 1][ratingOnX] / ratedefinition[0][ratingOnX]) > xh) { xh = itemrating[i + 1][ratingOnX] / ratedefinition[0][ratingOnX]; }
        if (parseFloat(itemrating[i + 1][ratingOnX] / ratedefinition[0][ratingOnX]) < xl) { xl = itemrating[i + 1][ratingOnX] / ratedefinition[0][ratingOnX]; }
        if (parseFloat(itemrating[i + 1][ratingOnY] / ratedefinition[0][ratingOnY]) > yh) { yh = itemrating[i + 1][ratingOnY] / ratedefinition[0][ratingOnY]; }
        if (parseFloat(itemrating[i + 1][ratingOnY] / ratedefinition[0][ratingOnY]) < yl) { yl = itemrating[i + 1][ratingOnY] / ratedefinition[0][ratingOnY]; }
    }




    //items
    for (var i = 1; i < cardn + 1; i++) {

        var xx = (parseFloat(itemrating[i][ratingOnX] / ratedefinition[0][ratingOnX]) - xl) / (xh - xl);
        var yy = (parseFloat(itemrating[i][ratingOnY] / ratedefinition[0][ratingOnY]) - yl) / (yh - yl);

        cardx[i] = parseInt(mapM + (cc.width - (2 * mapM)) * xx);
        cardy[i] = parseInt(mapM + (cc.height - (2 * mapM)) * yy);
        meanX += xx;
        meanY += yy;
    }
    meanX = meanX / cardn;
    meanY = meanY / cardn;

    //ASPECT RATIO
    //what is 1 in pixels X?
    pXsize = (cc.width - (2 * mapM)) / Math.abs(xh - xl);
    //what is 1 in pixels Y?
    pYsize = (cc.height - (2 * mapM)) / Math.abs(yh - yl);

    //center
    var xx = (meanX - xl) / (xh - xl);
    var yy = (meanY - yl) / (yh - yl);
    zeroX = parseInt(mapM + (cc.width - (2 * mapM)) * xx);
    zeroY = parseInt(mapM + (cc.height - (2 * mapM)) * yy);

}

//DRAW IMPORTANCE versus PRIORITY matrix..
function drawItemRateMatrix(ratingOnX, ratingOnY) {


    cc.onmousedown = "";
    cc.onmousemove = "";

    document.body.style.overflow = "hidden";
    //document.body.style.overflow = "scroll";
    var Rnow = 0;
    for (var r = 0; r < 5; r++) { if (parseInt(ratedefinition[0][r + 1]) > 0) { Rnow += 1; } }

    var wp = cc.width;
    var hp = cc.height;

    var xy = new Array(wp);
    for (var x = 1; x <= wp  ; x++) {
        xy[x] = new Array(hp);
    }
    for (var x = 1; x <= wp  ; x++) {
        for (var y = 1; y <=hp; y++) {
            xy[x][y] =0;
        }
    }
    var changeX = 0; var changeY = 0;
    maxItemWidth = 100;


    

    cctx.textBaseline = "top";
    cctx.textAlign = "start";

    cctx.globalAlpha = 1;
    cctx.clearRect(0, 0, cc.width, cc.height);
    cctx.lineWidth = 2;
    //cctx.fillStyle = mapFillstyle;
    cctx.fillStyle = 'White';
    cctx.fillRect(0, 0, cc.width, cc.height);
    cctx.fillStyle = mapFillstyle;
    cctx.fillRect(backM, backM, cc.width - 2 * backM, cc.height - 2 * backM);


    drawProjectName();


    cctx.font = '20pt Calibri';
    cctx.fillStyle = itemDotColor;

    if (Rnow == 1) { wraptextSingleLine(cctx, "Cannot draw graphic, there is only one rating in this project: " + ratedefinition[1][1].trim(), mapM, mapM, cc.width - (2 * mapM)); return; }

    cctx.font = '11pt Calibri';
    var titleNow = ratedefinition[1][ratingOnX].trim() + " (left to right) versus " + ratedefinition[1][ratingOnY].trim() + " (top to bottom)";
    wraptextSingleLine(cctx, titleNow, mapM, backM, cc.width - (2 * mapM) );

    cctx.font = '20pt Calibri';
    lineHeight = 22;

    var mm = 15;
    var llx1 = zeroX - mapM;
    var lly1 = zeroY - mapM;;
    var llx2 = (cc.width - 2 * mapM) - (zeroX - mapM);
    var lly2 = (cc.height - 2 * mapM) - (zeroY - mapM);

    cctx.strokeStyle = itemDotColor;
    cctx.strokeRect(mapM, mapM, llx1, lly1);
    cctx.strokeRect(zeroX, mapM, llx2, lly1);
    cctx.strokeRect(mapM, zeroY, llx1, lly2);
    cctx.strokeRect(zeroX, zeroY, llx2, lly2);

    cctx.textBaseline = "top";

    titleNow = ratedefinition[1][ratingOnX].trim() + " (LOW) " + ratedefinition[1][ratingOnY].trim() + " (LOW) ";
    wraptextsign(cctx, titleNow, mapM + mm, mapM, llx1, lineHeight, 1);
    titleNow = ratedefinition[1][ratingOnX].trim() + " (HIGH) " + ratedefinition[1][ratingOnY].trim() + " (LOW) ";
    wraptextsign(cctx, titleNow, mapM + cc.width - (2 * mapM) - mm, mapM, llx2, lineHeight, -1);

    cctx.textBaseline = "bottom";
    titleNow = ratedefinition[1][ratingOnX].trim() + " (LOW) " + ratedefinition[1][ratingOnY].trim() + " (HIGH) ";
    wraptextsign(cctx, titleNow, mapM + mm, mapM + cc.height - (2 * mapM), llx1, lineHeight, 1);
    titleNow = ratedefinition[1][ratingOnX].trim() + " (HIGH " + ratedefinition[1][ratingOnY].trim() + " (HIGH) ";
    wraptextsign(cctx, titleNow, mapM + cc.width - (2 * mapM) - mm, mapM + cc.height - (2 * mapM), llx2, lineHeight, -1);

    cctx.textBaseline = "middle";
    cctx.font = '9pt Calibri';
    //var fontS = 11; //var addY = 0;
    var xw = 2;
    var xww = 4;
    //var xupdown = 6;
    var number = "";
    var precision = 2; var Marg = 2; var lineH =11
    
    for (var i = 0; i < cardn ; i++) {

        cctx.beginPath();
        cctx.arc(cardx[i], cardy[i], xw, 0, 2 * Math.PI, false);
        cctx.fillStyle = mapFillstyle;
        cctx.fill();
        cctx.lineWidth = 1;
        cctx.strokeStyle = itemDotColor;
        cctx.stroke();
        

        //cctx.fillStyle = "White";
        //if (showItemNumber == true) { number = "(" + (i + 1).toString() + ") "; }
        //if (cardy[i] < (cc.height - 2 * mapM) / 2) { cctx.textBaseline = "bottom"; } else { cctx.textBaseline = "top"; }
        //cctx.textAlign = "center"
        //if (cardx[i] < (cc.width - 2 * mapM) / 3) { cctx.textAlign = "right" };
        //if (cardx[i] > 2 * (cc.width - 2 * mapM) / 3) { cctx.textAlign = "left" }
        //var wNow= wraptextSingleLine(cctx, number + cardt[i + 1].trim(), cardx[i] + xw, cardy[i], maxItemWidth, lineHeight);

        if (showItemNumber == true) { number = "(" + i.toString() + ") "; }
         
        var Nwords = 4; var Line = "";
        var words = cardt[i + 1].trim().split(' ');
        if (words.length < Nwords) { Nwords = words.length; }
        for (var n = 0; n < Nwords; n++) {
            Line = Line + words[n] + ' ';
        }
        Line = number + Line.trim();
        cctx.textBaseline = "top";
        cctx.textAlign = "start";
        var metrics = cctx.measureText(Line)
        
        var change = moveToExt(cardx[i], cardy[i], Marg, metrics.width, 1 * lineH, 1, 1, precision, xy, wp, hp);
        changeX = change[0];
        changeY = change[1];
 
        

        cctx.fillStyle = itemDotColor;
        wraptextSingleLine(cctx, Line, cardx[i] + xww + changeX, cardy[i] + changeY, maxItemWidth );
        if (changeX != 0  || changeY != 0) {
            //if (changeY > 0) { addY = fontS / 2 } else { addY = -fontS / 2 }
            cctx.beginPath();
            cctx.moveTo(cardx[i], cardy[i]);
            cctx.lineTo(cardx[i] + xww + changeX, cardy[i] + changeY);
            cctx.stroke();
        }


        //}
        
    }
    cctx.textAlign = "left";
    cctx.textBaseline = "top";

     
}

// CLUSTER TREE

function calculateClusterTREE() {


    cc.onmousedown = "";
    cc.onmousemove = "";

    clusternShown = clustermaxn;


    //document.body.style.overflow = "hidden";
    document.body.style.overflow = "scroll";
    cctx.textBaseline = "top";
    cctx.textAlign = "start";




    lineHeight = 12;
    var margeH = lineHeight + 10;
    var labelH = 22;
    var margeStart = mapM + 10;

    maxWidth = 150;
    var margeM = 30;
    //var mb = 5;

    var number = "";

    //var maxY = 0;
    //var maxW = 0;

    //maxY = margeStart + labelH + clusternShown * margeH + cardn * lineHeight + margeStart;
    //maxW = margeStart + maxWidth * (clusternShown - 1) + margeM * (clusternShown - 2) + margeStart;

    //cc.height = maxY;
    //cc.width = maxW;

    var clusterHold = 0; var clusterH = 0; var clusterH1 = 0; var clusterH2 = 0; var xc1 = 0; var xc2 = 0; var ycOld = 0; yc1 = 0; var yc2 = 0;
    for (g = 2; g < clusternShown + 1 ; g++) {

        var Xnow = margeStart + (g - 2) * (maxWidth + margeM);
        //var Ynow = margeStart;
        var Xnow2 = 0;
        var Ynow2 = 0;
        var Ynow02 = 0;
        if (isNaN(groupsd[g][3]) == false) {
            if (g > 2) {
                clusterHold = lineHeight * groupsn[groupsd[g][3]][groupsd[g][4]];
                Xnow2 = margeStart + (groupsd[g][3] - 1) * (maxWidth + margeM);
                Ynow02 = groupsY[groupsd[g][3]][groupsd[g][4]];
                Ynow2 = Ynow02 + clusterHold / 2;
            }
            clusterH1 = labelH + lineHeight * groupsn[g][groupsd[g][1]];
            clusterH2 = labelH + lineHeight * groupsn[g][groupsd[g][2]];
        }

        for (c = 1; c < g + 1; c++) {
            //Ynow += margeH;
            //cctx.fillStyle ="rgba(255, 255, 255, 0.4)";
            //cctx.fillStyle = 'White';
            cctx.fillStyle = mapFillstyle;


            groupsX[g][c] = Xnow;


            if (groupsd[g][1] == c || groupsd[g][2] == c) {

                groupsOld[g][c] = 1;

                if (groupsd[g][1] == c) {
                    clusterH = clusterH1;

                    clusterHeigth1[g][c] = clusterH1;

                    groupsY[g][c] = Ynow02;// yc1 = groupsY[g][c] + clusterH1 / 2;
                    groupsOld[g][c] = 1;
                }
                if (groupsd[g][2] == c) {

                    clusterH = clusterH2;

                    clusterHeigth2[g][c] = clusterH2;

                    groupsY[g][c] = Ynow02 + margeH + clusterH1;// yc2 = groupsY[g][c] + clusterH2 / 2;
                    groupsOld[g][c] = 2;
                }
            }
        }
        ccTest

        //xcOld = xcToOld + maxWidth; ycOld = ycToOld;
    }



    dv.onscroll = drawTree;

    drawTree();

}

function drawTree() {

    getUserClusterNames();

    //for (g = 2; g < clusternShown + 1; g++) {

    //    yellowh[g][1].style.visibility = 'hidden';
    //    yellowh[g][2].style.visibility = 'hidden';

    //}

    cctx.textBaseline = "top";
    cctx.textAlign = "start";


    lineHeight = 12;

    var margeH = lineHeight + 10;
    var labelH = 22;
    var margeStart = mapM + 10;

    maxWidth = 150;
    var margeM = 30;
    var mb = 5;

    var number = "";


    var maxY = 0;
    var maxW = 0;

    maxY = margeStart + labelH + clusternShown * margeH + cardn * lineHeight + margeStart;
    maxW = margeStart + maxWidth * (clusternShown - 1) + margeM * (clusternShown - 2) + margeStart;

    cc.height = maxY;
    cc.width = maxW;


    cctx.globalAlpha = 1;
    cctx.clearRect(0, 0, cc.width, cc.height);
    cctx.lineWidth = 2;
    //cctx.fillStyle = mapFillstyle;
    cctx.fillStyle = 'White';
    cctx.fillRect(0, 0, cc.width, cc.height);
    cctx.fillStyle = mapFillstyle;
    cctx.fillRect(backM, backM, cc.width - 2 * backM, cc.height - 2 * backM);


    var Xnow; var Xold; var yc1; var yc2; var Yold;

    cctx.fillStyle = mapFontcolor;
    drawProjectName();

    cctx.font = '11pt Calibri';
    for (g = 2; g < clusternShown + 1; g++) {

        Xnow = margeStart + (g - 2) * (maxWidth + margeM);
        var Ynow = backM + backM;
        wraptextSingleLine(cctx, "cluster node " + g, Xnow, Ynow, maxWidth );
    }


    for (g = 3; g < clusternShown + 1; g++) {

        Xnow = margeStart + (g - 2) * (maxWidth + margeM);
        Xold = margeStart + (groupsd[g][3] - 1) * (maxWidth + margeM);
        yc1 = groupsY[g][groupsd[g][1]] + clusterHeigth1[g][groupsd[g][1]] / 2;
        yc2 = groupsY[g][groupsd[g][2]] + clusterHeigth2[g][groupsd[g][2]] / 2;;
        Yold = groupsY[groupsd[g][3]][groupsd[g][4]] + (labelH + lineHeight * groupsn[groupsd[g][3]][groupsd[g][4]]) / 2;

        //+  clusterHeigth1[groupsd[g][3]][groupsd[g][4]] / 2



        var labelW = 200;
        var labelH2 = 30;

        //var ng = 2 + clusternShown - g;
        var cornerRadius = 4;

        var ng = 3;
        cctx.lineWidth = ng;

        cctx.strokeStyle = treeLineColor;
        cctx.fillStyle = treeLineColor;
        cctx.textBaseline = "middle";
        cctx.textAlign = "center";
        cctx.font = '14pt Calibri';

        cctx.beginPath();
        cctx.moveTo(Xnow - mb, margeStart + yc1);
        cctx.lineTo(Xold + mb - margeM, margeStart + Yold);
        cctx.stroke();

        cctx.beginPath();
        cctx.moveTo(Xnow - mb, margeStart + yc2);
        cctx.lineTo(Xold + mb - margeM, margeStart + Yold);
        cctx.stroke();

        if (showTreeInMap == true || showClustersInMap == false) {

            // C1
            var clustertext = yellowth[g][1].trim();
            var metrics = cctx.measureText(clustertext);
            labelW = metrics.width + 2 * mb + ng;
            if (labelW < maxWidth + 2 * mb + ng) { labelW = maxWidth + 2 * mb + ng };

            cctx.fillStyle = treeLineColor;
            cctx.beginPath();
            cctx.roundRect(Xnow - labelW / 2 + maxWidth / 2, margeStart - labelH2 / 2 + yc1, labelW, labelH2, cornerRadius);
            cctx.fill();

            cctx.fillStyle = "White";
            //cctx.fillStyle = "Black";
            cctx.fillText(clustertext, Xnow + maxWidth / 2, margeStart + yc1);

            // C2
            clustertext = yellowth[g][2].trim();
            metrics = cctx.measureText(clustertext);
            labelW = metrics.width + 2 * mb + ng;
            if (labelW < maxWidth + 2 * mb + ng) { labelW = maxWidth + 2 * mb + ng; }

            cctx.fillStyle = treeLineColor;
            cctx.beginPath();
            cctx.roundRect(Xnow - labelW / 2 + maxWidth / 2, margeStart - labelH2 / 2 + yc2, labelW, labelH2, cornerRadius);
            cctx.fill();

            cctx.fillStyle = "White";
            //cctx.fillStyle = "Black";
            cctx.fillText(clustertext, Xnow + maxWidth / 2, margeStart + yc2);

            // C old
            if (groupsd[g][3] == 2) {
                clustertext = yellowth[groupsd[g][3]][groupsOld[groupsd[g][3]][groupsd[g][4]]].trim();
                clustertext = yellowth[groupsd[g][3]][groupsOld[groupsd[g][3]][groupsd[g][4]]].trim();
                var metrics = cctx.measureText(clustertext);
                labelW = metrics.width + 2 * mb + ng;
                if (labelW < maxWidth + 2 * mb + ng) { labelW = maxWidth + 2 * mb + ng; }

                cctx.fillStyle = treeLineColor;
                cctx.beginPath();
                cctx.roundRect(Xold - labelW / 2 - maxWidth / 2 - margeM, margeStart - labelH2 / 2 + Yold, labelW, labelH2, cornerRadius);
                cctx.fill();

                cctx.fillStyle = "White";
                //cctx.fillStyle = "Black";
                cctx.fillText(clustertext, Xold - maxWidth / 2 - margeM, margeStart + Yold);
            }
        }
    }

    if (showClustersInMap == true) {


        for (g = 2; g < clusternShown + 1; g++) {
            for (c = 1; c < g + 1; c++) {
                if (groupsd[g][1] == c || groupsd[g][2] == c) {

                    cctx.fillStyle = importanceColor;
                    var clusterRadius = 1;
                    if (solutionDims == 1) clusterRadius = (clusterr1[g][c][rateToUse] - 1) / ratedefinition[0][rateToUse];
                    if (solutionDims == 2) clusterRadius = (clusterr2[g][c][rateToUse] - 1) / ratedefinition[0][rateToUse];


                    if (groupsd[g][1] == c) { drawcluster2(c, groupsX[g][c] - mb, margeStart + groupsY[g][c] - mb, maxWidth + 2 * mb, clusterHeigth1[g][c] + 2 * mb, true, 1, 3, -1, false); }
                    if (groupsd[g][2] == c) { drawcluster2(c, groupsX[g][c] - mb, margeStart + groupsY[g][c] - mb, maxWidth + 2 * mb, clusterHeigth2[g][c] + 2 * mb, true, 1, 3, -1, false); }

                    cctx.textBaseline = "top";
                    cctx.textAlign = "start";
                    cctx.fillStyle = clustersAndDimensionsFontcolor;
                    cctx.font = 'bold 11pt Calibri';

                    if (groupsd[g][1] == c) {


                        yellowh[g][1].style.visibility = 'visible';
                        yellowh[g][1].style.left = -dv.scrollLeft + groupsX[g][c] + "px";
                        yellowh[g][1].style.top = -dv.scrollTop + margeStart + groupsY[g][c] + 0 * mb + "px";
                        yellowh[g][1].style.width = maxWidth + 'px';
                        yellowh[g][1].style.height = labelH + 'px';
                        yellowh[g][1].innerText = yellowth[g][1].trim();
                        //yellowh[g][1].visibility = 'visible';
                        wraptextSingleLine(cctx, yellowth[g][1].trim(), groupsX[g][c], margeStart + groupsY[g][c] + 0 * mb, maxWidth);
                    }
                    if (groupsd[g][2] == c) {
                        yellowh[g][2].style.visibility = 'visible';
                        yellowh[g][2].style.left = -dv.scrollLeft + groupsX[g][c] + "px";
                        yellowh[g][2].style.top = -dv.scrollTop + margeStart + groupsY[g][c] + 0 * mb + "px";
                        yellowh[g][2].style.width = maxWidth + 'px';
                        yellowh[g][2].style.height = labelH + 'px';
                        yellowh[g][2].innerText = yellowth[g][2].trim();
                        //yellowh[g][2].visibility = 'visible';
                        wraptextSingleLine(cctx, yellowth[g][2].trim(), groupsX[g][c], margeStart + groupsY[g][c] + 0 * mb, maxWidth);
                    }
                    cctx.font = '9pt Calibri';
                    cctx.fillStyle = itemDotColor;;
                    for (i = 1; i < groupsn[g][c] + 1; i++) {

                        ii = groups[g][c][i];
                        if (showItemNumber == true) { number = "(" + ii.toString() + ") "; }
                        wraptextSingleLine(cctx, number + cardt[ii].trim(), groupsX[g][c], margeStart + labelH + groupsY[g][c] + 1 * mb + (i - 2) * lineHeight, maxWidth);

                    }

                }
            }

        }
    }
    //var dataURL = cc.toDataURL();

    // set canvasImg image src to dataURL
    // so it can be saved as an image
    //document.getElementById('canvasImg').src = dataURL;


}


function cardselect(e) {

    var dist = 0; var low = 9999999; var yellow = 0; var item = 0;

    startmove = 1;
    var cardxnow = e.pageX - cc.offsetLeft;
    var cardynow = e.pageY - cc.offsetTop;


    for (var i = 1; i < cardn + 1; i++) {

        dist = Math.pow(cardx[i] - cardxnow, 2) + Math.pow(cardy[i] - cardynow, 2);
        if (dist < low) { low = dist; item = i }
    }
    if (!itemselect[item]) { itemselect[item] = 0; }
    if (itemselect[item] == 0) { itemselect[item] = 1; drawNow(false, sheetNumber, solutionDims) } else { itemselect[item] = 0; drawNow(false, sheetNumber, solutionDims) }
}

function clusterselect(e) {



    var dist = 0; var low = 9999999; var yellow = 0; var item = 0;

    //if (Math.abs(clusterxn - (e.pageX - cc.offsetLeft)) > 10) {
        clusterxn = e.pageX - cc.offsetLeft;
        clusteryn = e.pageY - cc.offsetTop;
    //}

    for (var c = 1; c < clustern + 1; c++) {

        dist = Math.pow(clusterx[clustern][c] - clusterxn, 2) + Math.pow(clustery[clustern][c] - clusteryn, 2);
        if (dist < low) { low = dist; item = c }
    }
    clusterSelected = item;
    //saveUserClusterNamesFromMap();
    if (clusterxn > backM && clusteryn > backM && clusterxn < cc.width - backM && clusteryn < cc.height - backM) {
        clusterSelected = item;
    }
    else { clusterSelected = 0; }
    drawNow(false, sheetNumber, solutionDims);


    drawclusteritems(item, (clusterxn - cc.width / 2) / cc.width, (clusteryn - cc.height / 2) / cc.height, clusterxn);



}


function drawclusteritems(c, rx, ry, clusterxn) {


    if (clusterxn > backM && clusteryn > backM && clusterxn < cc.width - backM && clusteryn < cc.height - backM) {


        

        cctx.fillStyle = itemsAndNamesColor;
        cctx.strokeStyle = itemsAndNamesColor;
        cctx.font = '11pt Calibri';
        cctx.textAlign = "left";
        var XPnow = mapM;
        if (clusterxn < cc.width / 2) { XPnow = cc.width - mapM; cctx.textAlign = "right"; }

        var YPnow = mapM;
        cctx.fillText("cluster (mean rating)", XPnow, YPnow);

        YPnow += 15;
        cctx.fillText(clusterNameNow[c] + " (" + clusterr2[clustern][c][rateToUse] + ")", XPnow, YPnow);

        cctx.font = '9pt Calibri';

        YPnow += 10;
        var number = "";
        for (var i = 1; i < groupsn[clustern][c] + 1; i++) {
            //cctx.fillText(cardt[groups[clustern][c][i]], mapM, mapM + (i - 1) * 12);

            if (showItemNumber == true) { number = "(" + groups[clustern][c][i].toString() + ") "; }
            YPnow += 12;
            cctx.fillText(number + cardt[groups[clustern][c][i]], XPnow, YPnow);
        }

        cctx.font = '11pt Calibri';
        YPnow += 12 + 14;
        cctx.fillText("CLUSTERNAMES GIVEN BY PARTICIPANTS", XPnow, YPnow);

        cctx.font = '9pt Calibri';
        YPnow = YPnow + 10;
        var nn = 0;
        for (var r = 1; r < clusternamesn + 1; r++) {

            var sumsq = Math.pow(Math.pow(clusternamesdr[r][1], 2) + Math.pow(clusternamesdr[r][2], 2), 0.5);

            var corr = rx * clusternamesdr[r][1] / sumsq + ry * clusternamesdr[r][2] / sumsq
            if (corr > .5) {
                YPnow += 12;
                cctx.fillText(clusternames[r].trim(), XPnow, YPnow);
                nn += 1;
            }
        }
        if (nn == 0) { YPnow += 12; cctx.fillText("none with positive correlations", XPnow, YPnow); }
    }
}


function drawparticipantsclusterNames(e) {

    drawconceptmapWORLD();
    clusterxn = e.pageX - cc.offsetLeft;
    clusteryn = e.pageY - cc.offsetTop;
    if (clusterxn > backM && clusteryn > backM && clusterxn < cc.width - backM && clusteryn < cc.height - backM) {



        worldcenterx = cc.width / 2;
        worldcentery = cc.height / 2;





        //if (clusterxn > mapM) {

        rx = .7 * (clusterxn / worldcenterx) - 1;   //should be corrected for the eigenvalue when checkbox eigenvalue checked in selection screen?..
        ry = -.7 * ((clusteryn / worldcentery) - 1);

        cctx.textAlign = "left";

        cctx.fillStyle = itemsAndNamesColor;
        cctx.strokeStyle = itemsAndNamesColor;
        cctx.font = '11pt Calibri';

        var YPnow = mapM;
        cctx.fillText("CLUSTERNAMES GIVEN BY PARTICIPANTS", mapM, YPnow);

        cctx.font = '9pt Calibri';
        YPnow = YPnow + 10;
        var nn = 0;
        for (var r = 1; r < clusternamesn + 1; r++) {

            var sumsq = Math.pow(Math.pow(clusternamesdr[r][1], 2) + Math.pow(clusternamesdr[r][2], 2), 0.5);

            var corr = rx * clusternamesdr[r][1] / sumsq + ry * clusternamesdr[r][2] / sumsq
            if (corr > .5) {
                YPnow += 12;
                cctx.fillText(clusternames[r], mapM, YPnow);
                nn += 1;

            }
        }

        if (nn == 0) { YPnow += 12; cctx.fillText("none with positive correlations", mapM, YPnow); }
        //}
    }
}


function clustermeansMAP() {

    rawDataN = participantn - 1;

    for (g = 2; g < clusternShown + 1; g++) {

        for (c = 1; c < g + 1; c++) {

            var xl = 9999; var xh = -9999; var yl = 9999; var yh = -9999;
            clusterx[g][c] = 0; clustery[g][c] = 0;
            for (var i = 1; i < groupsn[g][c] + 1; i++) {

                var radius = parseInt(itemrating[i] * 2);
                if (!radius) { radius = 5; }
                if (cardx[groups[g][c][i]] < xl - radius) xl = cardx[groups[g][c][i]] - radius;
                if (cardx[groups[g][c][i]] > xh + radius) xh = cardx[groups[g][c][i]] + radius;
                if (cardy[groups[g][c][i]] < yl - radius) yl = cardy[groups[g][c][i]] - radius;
                if (cardy[groups[g][c][i]] > yh + radius) yh = cardy[groups[g][c][i]] + radius;

                clusterx[g][c] += cardx[groups[g][c][i]];
                clustery[g][c] += cardy[groups[g][c][i]];

            }
            clusterx[g][c] = clusterx[g][c] / groupsn[g][c];
            clustery[g][c] = clustery[g][c] / groupsn[g][c];

            //if (g == clustern) { clusterxl[c] = xl; }
            //if (g == clustern) { clusteryl[c] = yl; }

            //if (g == clustern) { clusterxw[c] = xh - xl; }
            //if (g == clustern) { clusteryw[c] = yh - yl; }

            clusterxl[g][c] = xl;
            clusteryl[g][c] = yl;

            clusterxw[g][c] = xh - xl;
            clusteryw[g][c] = yh - yl;

        }
    }

}

function clusterdistancesMap() {

    for (g = 2; g < clusternShown + 1; g++) {
        for (c = 1; c < g + 1; c++) {

            var xl = 9999; var xh = -9999; var yl = 9999; var yh = -9999;
            clusterxx[g][c] = 0; clusteryy[g][c] = 0;
            for (var i = 1; i < groupsn[g][c] + 1; i++) {

                var radius = parseInt(itemrating[i][rateToUse] * 2);
                if (!radius) { radius = 5; }
                if (itemxx[groups[g][c][i]] < xl - radius) { xl = itemxx[groups[g][c][i]] - radius; }
                if (itemxx[groups[g][c][i]] > xh + radius) { xh = itemxx[groups[g][c][i]] + radius; }
                if (itemyy[groups[g][c][i]] < yl - radius) { yl = itemyy[groups[g][c][i]] - radius; }
                if (itemyy[groups[g][c][i]] > yh + radius) { yh = itemyy[groups[g][c][i]] + radius; }

                clusterxx[g][c] += itemxx[groups[g][c][i]];
                clusteryy[g][c] += itemyy[groups[g][c][i]];

            }
            clusterxx[g][c] = clusterxx[g][c] / groupsn[g][c];
            clusteryy[g][c] = clusteryy[g][c] / groupsn[g][c];

            clusterxxl[g][c] = xl;
            clusteryyl[g][c] = yl;

            clusterxxw[g][c] = xh - xl;
            clusteryyw[g][c] = yh - yl;


        }
        for (c = 1; c < g + 1; c++) {
            for (c2 = 1; c2 < g + 1; c2++) {
                //clusterdist[c][c2] = Math.pow(Math.pow(clusterx[c] - clusterx[c2], 2) + Math.pow(clustery[c] - clustery[c2], 2), .5);
                clusterdist[g][c][c2] = Math.pow(Math.pow(clusterxx[g][c] - clusterxx[g][c2], 2) + Math.pow(clusteryy[g][c] - clusteryy[g][c2], 2), .5);

                //itemxx[i]: maar eerst clustergemiddelden hiervan maken..
            }
        }
        var distl = 99999;
        for (c = 1; c < g + 1; c++) {
            distl = 99999;
            for (c2 = 1; c2 < g + 1; c2++) {
                if (c !== c2) {
                    if (clusterdist[g][c][c2] < distl) { distl = clusterdist[g][c][c2]; }
                }
            }
            clusterdist[g][c][0] = distl;
        }

    }
}

function calculateConceptMAP(angle) {

    var xh = -9999; var xl = 9999; var yh = -9999; var yl = 9999;


    //var itemxx = new Array(cardn.value);
    //var itemyy = new Array(cardn.value);


    //ROTATE ITEMS

    for (var i = 1; i < cardn + 1; i++) {

        itemxx[i] = itemx[i] * Math.cos(angle * Math.PI) - itemy[i] * Math.sin(angle * Math.PI);   //cos.x - sin.y
        itemyy[i] = itemx[i] * Math.sin(angle * Math.PI) + itemy[i] * Math.cos(angle * Math.PI);  // sin.x + cos.y
    }
    for (var i = 1; i < cardn + 1; i++) {
        if (parseFloat(itemxx[i]) > xh) { xh = itemxx[i]; }
        if (parseFloat(itemxx[i]) < xl) { xl = itemxx[i]; }
        if (parseFloat(itemyy[i]) > yh) { yh = itemyy[i]; }
        if (parseFloat(itemyy[i]) < yl) { yl = itemyy[i]; }
    }


    //ROTATE PARTICIPANTS

    for (var p = 1; p < participantn + 1; p++) {
        partx_orig[p] = participantdr[p][1][rateToUse] * Math.cos(angle * Math.PI) - participantdr[p][2][rateToUse] * Math.sin(angle * Math.PI);
        party_orig[p] = participantdr[p][1][rateToUse] * Math.sin(angle * Math.PI) + participantdr[p][2][rateToUse] * Math.cos(angle * Math.PI);
    }

    for (var p = 1; p < participantgroupn + 1; p++) {
        partgx_orig[p] = participantdrg[p][1][rateToUse] * Math.cos(angle * Math.PI) - participantdrg[p][2][rateToUse] * Math.sin(angle * Math.PI);
        partgy_orig[p] = participantdrg[p][1][rateToUse] * Math.sin(angle * Math.PI) + participantdrg[p][2][rateToUse] * Math.cos(angle * Math.PI);
    }
    for (var p = 1; p < participantn + 1; p++) {
        if (parseFloat(partx_orig[p]) > xh) { xh = partx_orig[p]; }
        if (parseFloat(partx_orig[p]) < xl) { xl = partx_orig[p]; }
        if (parseFloat(party_orig[p]) > yh) { yh = party_orig[p]; }
        if (parseFloat(party_orig[p]) < yl) { yl = party_orig[p]; }


    }


    //items
    for (var i = 1; i < cardn + 1; i++) {

        var xx = (parseFloat(itemxx[i]) - xl) / (xh - xl);
        var yy = (parseFloat(itemyy[i]) - yl) / (yh - yl);

        cardx[i] = parseInt(mapM + (cc.width - (2 * mapM)) * xx);
        cardy[i] = parseInt(mapM + (cc.height - (2 * mapM)) * yy);
    }
    //participants
    for (var p = 1; p < participantn + 1; p++) {

        var xx = (parseFloat(partx_orig[p]) - xl) / (xh - xl);
        var yy = (parseFloat(party_orig[p]) - yl) / (yh - yl);

        partx[p] = parseInt(mapM + (cc.width - (2 * mapM)) * xx);
        party[p] = parseInt(mapM + (cc.height - (2 * mapM)) * yy);

    }
    //participantsgroups
    for (var p = 1; p < participantgroupn + 1; p++) {

        xx = (parseFloat(partgx_orig[p]) - xl) / (xh - xl);
        yy = (parseFloat(partgy_orig[p]) - yl) / (yh - yl);

        partgx[p] = parseInt(mapM + (cc.width - (2 * mapM)) * xx);
        partgy[p] = parseInt(mapM + (cc.height - (2 * mapM)) * yy);
    }
    //clusternames
    for (var r = 1; r < clusternamesn + 1; r++) {

        var xx = (parseFloat(clusternamesdr[r][1]) - xl) / (xh - xl);
        var yy = (parseFloat(clusternamesdr[r][2]) - yl) / (yh - yl);

        cnamex[r] = parseInt(mapM + (cc.width - (2 * mapM)) * xx);
        cnamey[r] = parseInt(mapM + (cc.height - (2 * mapM)) * yy);
    }

    //ASPECT RATIO
    //what is 1 in pixels X?
    pXsize = (cc.width - (2 * mapM)) / Math.abs(xh - xl);
    //what is 1 in pixels Y?
    pYsize = (cc.height - (2 * mapM)) / Math.abs(yh - yl);

    var xx = (0 - xl) / (xh - xl);
    var yy = (0 - yl) / (yh - yl);

    //center
    zeroX = parseInt(mapM + (cc.width - (2 * mapM)) * xx);
    zeroY = parseInt(mapM + (cc.height - (2 * mapM)) * yy);


    clustermeansMAP();
}



function drawconceptmap(type) {


    var mb = 5;
    cc.onmousedown = "" //;cardselect;    
    cc.onmousemove = clusterselect;

    var wp = cc.width;
    var hp = cc.height;

    var xy = new Array(wp);
    for (var x = 1; x <= wp  ; x++) {
        xy[x] = new Array(hp);
    }
    for (var x = 1; x <= wp  ; x++) {
        for (var y = 1; y <= hp; y++) {
            xy[x][y] = 0;
        }
    }
    var changeX = 0; var changeY = 0;

    getUserClusterNames();
    getUserDimensionNames()
    getClusterNamesFromTree(clustern);

    document.body.style.overflow = "hidden";
    //document.body.style.overflow = "scroll";


    cctx.textBaseline = "top";
    cctx.textAlign = "start";

    cctx.globalAlpha = 1;
    cctx.clearRect(0, 0, cc.width, cc.height);

    cctx.lineWidth = 2;
    cctx.fillStyle = 'White';
    cctx.fillRect(0, 0, cc.width, cc.height);
    cctx.fillStyle = mapFillstyle;
    cctx.fillRect(backM, backM, cc.width - 2 * backM, cc.height - 2 * backM);


    drawProjectName();
    cctx.font = '9pt Calibri';

    cctx.beginPath();
    cctx.moveTo(zeroX, mapM);
    cctx.lineTo(zeroX, cc.height - mapM);
    cctx.strokeStyle = mapFontcolor;
    cctx.stroke();

    cctx.beginPath();
    cctx.moveTo(mapM, zeroY);
    cctx.lineTo(mapM + cc.width - mapM, zeroY);
    cctx.strokeStyle = mapFontcolor;
    cctx.stroke();



    cctx.lineWidth = 2;

    //raw links between items
    if (showRawDistancesInMap == true) {

        var lineW = 0;
        for (var i = 1; i < cardn + 1; i++) {
            for (var ii = i; ii < cardn + 1; ii++) {

                lineW = sortdataraw[i][ii];

                if (lineW >= rawDataN) {
                    cctx.beginPath();
                    cctx.moveTo(cardx[i], cardy[i]);
                    cctx.lineTo(cardx[ii], cardy[ii]);
                    cctx.lineWidth = lineW;
                    cctx.strokeStyle = mapFontcolor;
                    cctx.stroke();
                }
            }
        }
    }

    //participants scores

    var pSig = .14;
    if (ShowParticipants == true) {

        cctx.font = '9pt Calibri';
        cctx.fillStyle = mapFontcolor;
        for (var p = 1; p < participantn + 1; p++) {

            if (Math.pow(Math.pow(participantdr[p][1][rateToUse], 2) + Math.pow(participantdr[p][2][rateToUse], 2), .5) > pSig) {
                cctx.beginPath();
                cctx.moveTo(zeroX, zeroY);
                cctx.lineTo(partx[p], party[p]);
                cctx.lineWidth = 2;
                cctx.stroke();

                wraptextsign(cctx, partnames[p].trim(), sign(partx_orig[p]) * textM + partx[p], sign(party_orig[p]) * textM / 2 + party[p], sw - 2 * textM, 16, sign(partx_orig[p]) * 1);
            }
        }
    }
    if (ShowParticipantsGroups == true) {

        cctx.font = '9pt Calibri';
        cctx.fillStyle = mapFontcolor;
        for (var p = 1; p < participantgroupn + 1; p++) {

            if (Math.pow(Math.pow(participantdrg[p][1][rateToUse], 2) + Math.pow(participantdrg[p][2][rateToUse], 2), .5) > pSig) {

                cctx.beginPath();
                cctx.moveTo(zeroX, zeroY);
                cctx.lineTo(partgx[p], partgy[p]);
                cctx.lineWidth = 2;
                cctx.stroke();

                wraptextsign(cctx, participantdrgn[p].trim(), sign(partgx_orig[p]) * textM + partgx[p], sign(partgy_orig[p]) * textM / 2 + partgy[p], sw - 2 * textM, 16, sign(partgx_orig[p]) * 1);
            }
        }
    }

    if (ShowParticipantsGroups == true || ShowParticipants == true) {

        cctx.save();
        cctx.translate(zeroX, zeroY);
        //cctx.scale(pXsize / pYsize, 1);
        cctx.scale(1, pYsize / pXsize);
        cctx.beginPath();
        cctx.arc(0, 0, pSig * pXsize, 0, 2 * Math.PI, false);
        cctx.restore();
        cctx.fillStyle = mapFillstyle;
        cctx.fill();
        cctx.lineWidth = 6;
        cctx.strokeStyle = mapFontcolor;;
        cctx.stroke();
    }

    cctx.fillStyle = 'Black';




    //SHOW TREE IN MAP

    if (showTreeInMap == true) {


        // cctx.textBaseline = "middle";
        // cctx.textAlign = "center";

        var x0 = zeroX; var y0 = zeroY;
        for (g = 2; g < clustern + 1; g++) {

            if (g > 2) { x0 = clusterx[groupsd[g][3]][groupsd[g][4]]; y0 = clustery[groupsd[g][3]][groupsd[g][4]]; }

            var ng = 2 + clustern - g;
            for (l = 1; l < 2 + 1; l++) {

                var x = clusterx[g][groupsd[g][l]];
                var y = clustery[g][groupsd[g][l]];

                cctx.lineWidth = ng;

                cctx.strokeStyle = treeLineColor;
                cctx.fillStyle = treeLineColor;

                cctx.beginPath();
                cctx.moveTo(x0, y0);
                cctx.lineTo(x, y);
                //cctx.strokeStyle = "white";
                cctx.stroke();

            }



        }

        for (g = 2; g < clustern + 1; g++) {

            if (g > 2) { x0 = clusterx[groupsd[g][3]][groupsd[g][4]]; y0 = clustery[groupsd[g][3]][groupsd[g][4]]; }

            var ng = 2 + clustern - g;
            for (l = 1; l < 2 + 1; l++) {

                var x = clusterx[g][groupsd[g][l]];
                var y = clustery[g][groupsd[g][l]];

                var labelW = 200;
                var labelH = 30;
                var cornerRadius = 4;

                //var ng = 3;
                //cctx.lineWidth = ng;

                cctx.strokeStyle = treeLineColor;
                cctx.fillStyle = treeLineColor;
                cctx.textBaseline = "middle";
                cctx.textAlign = "center";
                cctx.font = '14pt Calibri';

                var clustertext = yellowth[g][l].trim();
                var metrics = cctx.measureText(clustertext);
                labelW = metrics.width + ng + 2 * mb;
                //if (labelW < maxWidth + +ng) { labelW = maxWidth + ng };

                cctx.beginPath();
                cctx.roundRect(x - labelW / 2, y - labelH / 2, labelW, labelH, cornerRadius);
                cctx.fill();

                cctx.fillStyle = "White";
                cctx.fillText(clustertext, x, y);

            }
        }

        cctx.textBaseline = "top";
        cctx.textAlign = "start";
    }


    //CLUSTERS, ITEMS, CLUSTERNAMES

    if (showClustersInMap == true) {

        var showClusterRatingInMap = true;
        for (c = 1; c < clustern + 1; c++) {


            //var cornerRadius = 4;

            if (clusterType == 1) {
                if (showClusterRatingInMap == true) {
                    drawcluster2(c, parseInt(clusterxl[clustern][c]), parseInt(clusteryl[clustern][c]), parseInt(clusterxw[clustern][c]), parseInt(clusteryw[clustern][c]), false, 1, 3, (clusterr2[clustern][c][rateToUse] - 1) / ratedefinition[0][rateToUse], false);
                }
                else {
                    drawcluster2(c, parseInt(clusterxl[clustern][c]), parseInt(clusteryl[clustern][c]), parseInt(clusterxw[clustern][c]), parseInt(clusteryw[clustern][c]), false, 1, 3, -1, false);
                }
                //var rr = (clusterr2[g][c][rateToUse] - 1) / ratedefinition[0][rateToUse];

            }
            if (clusterType == 2) {
                if (showClusterRatingInMap == true) {
                    drawcluster2(c, parseInt(clusterxl[clustern][c]), parseInt(clusteryl[clustern][c]), parseInt(clusterxw[clustern][c]), parseInt(clusteryw[clustern][c]), false, 1, 3, (clusterr2[clustern][c][rateToUse] - 1) / ratedefinition[0][rateToUse], true);
                }
                else {
                    drawcluster2(c, parseInt(clusterxl[clustern][c]), parseInt(clusteryl[clustern][c]), parseInt(clusterxw[clustern][c]), parseInt(clusteryw[clustern][c]), false, 1, 3, -1, false);
                }
                //var rr = (clusterr2[g][c][rateToUse] - 1) / ratedefinition[0][rateToUse];

            }
            if (clusterType == 3) {
                if (showClusterRatingInMap == true) {
                    defineanddrawclusterround(c, (clusterr2[clustern][c][rateToUse] - 1) / ratedefinition[0][rateToUse]);
                }
                else {
                    defineanddrawclusterround(c, -1);
                }
            }

            //in textbox
            var Xnow = textM + cc.offsetLeft + parseInt(clusterxl[clustern][c]);
            var Ynow = textM + cc.offsetTop + parseInt(clusteryl[clustern][c]);
            yellow[c].style.visibility = 'visible';
            yellow[c].innerText = clusterNameNow[c].trim();
            yellow[c].style.fontFamily = "Calibri";
            yellow[c].style.fontSize = "22px";
            yellow[c].style.left = Xnow + "px";
            yellow[c].style.top = Ynow + "px";
            var yellowWnow = parseInt(clusteryw[clustern][c]);
            if (yellowWnow < 100) { yellowWnow = 100; }
            yellow[c].style.width = yellowWnow + 'px';//parseInt(clusteryw[clustern][c]) + 'px';
            yellow[c].style.height = 22 + 'px';


            //in canvas
            cctx.strokeStyle = clustersAndDimensionsFontcolor;
            cctx.fillStyle = clustersAndDimensionsFontcolor;
            //cctx.textBaseline = "top";
            //cctx.textAlign = "start";

            cctx.font = 'bold 16pt Calibri';

            wraptext(cctx, clusterNameNow[c].trim(), Xnow, Ynow, 150, 22);

            //if (showItemsInMap == true) {
            //    cctx.font = "9pt Calibri"
            //
            // 
            //    ///ITEMS 
            //
            //    for (var i = 1; i < groupsn[clustern][c] + 1; i++) {
            //        var radius = parseInt(itemrating[i][rateToUse] * 2);
            //        if (!radius) { radius = 5; }
            //        drawcardclassiccmsimple(groups[clustern][c][i], cardx[groups[clustern][c][i]], cardy[groups[clustern][c][i]], c, radius);
            //
            //    }
            //}
        }
    }
    if (showItemsInMap == true) {


        var startAngle = 0.5 * Math.PI;
        var endAngle = 2 * Math.PI;
        var counterClockwise = false;

        for (c = 1; c < clustern + 1; c++) {
            cctx.font = "9pt Calibri"
            var lineH = 11;
            var precision = 2;  var Marg = 2;
            ///ITEMS 
            for (var i = 1; i < groupsn[clustern][c] + 1; i++) {

                var radius = parseInt(itemrating[i][rateToUse] * 2);
                if (!radius) { radius = 5; }

                cctx.beginPath();
                cctx.arc(cardx[groups[clustern][c][i]], cardy[groups[clustern][c][i]], radius, startAngle, endAngle, counterClockwise);
                cctx.lineTo(cardx[groups[clustern][c][i]], cardy[groups[clustern][c][i]]);
                cctx.closePath();
                cctx.fillStyle = "grey";
                cctx.fillStyle = itemDotColor;
                cctx.fill();
                cctx.lineWidth = 1;

                cctx.textBaseline = "top";
                cctx.textAlign = "start";

                if (showItemNumber == false) {
                    if (clusterSelected == c) {
                        var dims = wraptexttest(cctx, cardt[groups[clustern][c][i]], cardx[groups[clustern][c][i]] + 4, cardy[groups[clustern][c][i]], sw, lineH);
                        var change = moveToExt(cardx[groups[clustern][c][i]] + 4, cardy[groups[clustern][c][i]], Marg, dims[0], dims[1] * lineH, 1, 1, precision, xy, wp, hp);
                        changeX = change[0];
                        changeY = change[1];
                        wraptext(cctx, cardt[groups[clustern][c][i]], cardx[groups[clustern][c][i]] + 4 + changeX, cardy[groups[clustern][c][i]] + changeY, sw, lineH);
                        if (changeX != 0 || changeY != 0) {
                            cctx.beginPath();
                            cctx.moveTo(cardx[groups[clustern][c][i]] + 4, cardy[groups[clustern][c][i]]);
                            cctx.lineTo(cardx[groups[clustern][c][i]] + 4 + changeX, cardy[groups[clustern][c][i]] + changeY + 11 / 2);
                            cctx.stroke();
                        }
                        //cctx.beginPath();
                        //cctx.moveTo(cardx[groups[clustern][c][i]] + 4 + changeX, cardy[groups[clustern][c][i]] + changeY);
                        //cctx.lineTo(cardx[groups[clustern][c][i]] + 4 + changeX, cardy[groups[clustern][c][i]] + changeY + dims[1] * 11);
                        //cctx.stroke();
                        //cctx.beginPath();
                        //cctx.moveTo(cardx[groups[clustern][c][i]] + 4 + changeX + dims[0], cardy[groups[clustern][c][i]] + changeY);
                        //cctx.lineTo(cardx[groups[clustern][c][i]] + 4 + changeX + dims[0], cardy[groups[clustern][c][i]] + changeY + dims[1] * 11);
                        //cctx.stroke();
                    }
                    else {
                        wraptext(cctx, groups[clustern][c][i].toString(), cardx[groups[clustern][c][i]] + 4, cardy[groups[clustern][c][i]], sw, 11);
                    }
                }
                if (showItemNumber == true) { wraptext(cctx, groups[clustern][c][i].toString(), cardx[groups[clustern][c][i]] + 4, cardy[groups[clustern][c][i]], sw, 11);}
            }
        }
    }


    showdimensions();


     

}

function moveToExt(Ix, Iy, Marg, Wnow, Hnow, moveXnow, moveYnow, precision, xy, wp, hp) {

    var change = new Array(2);
    var sIx = sign((Ix / wp) - .5);
    var sIy = sign((Iy / hp) - .5);
    var Ln = 0;
    changeX = 0; changeY = 0; var changeXold = 0; var changeYold = 0;
    do {
        overlap = 0; changeXold += changeX; changeYold += changeY; 
        for (var x = Ix ; x < Ix + Wnow  ; x += precision) {
            for (var y = Iy; y < Iy + Hnow; y += precision) {
                if (x + changeX < wp && y + changeY < hp && x + changeX > 0 && y + changeY > 0) { if (xy[x + changeX][y + changeY] == 1) { overlap = 1; break; }; }
            }
            if (overlap == 1) { break; }
        }

        if (overlap == 1) {
            for (var a = 1; a <= 8  ; a++) {

                switch (a) {
                    case 1:
                        changeX = changeXold + 0;
                        changeY = changeYold - sIy * moveYnow;
                        break;
                    case 2:
                        changeX = changeXold + 0;
                        changeY = changeYold + sIy * moveYnow;
                        break;
                    case 3:
                        changeX = changeXold + sIx * moveXnow;
                        changeY = changeYold + 0;
                        break;
                    case 4:
                        changeX = changeXold - sIx * moveXnow;
                        changeY = changeYold + 0;
                        break;
                    case 5:
                        changeX = changeXold - sIx * moveXnow;
                        changeY = changeYold - sIy * moveYnow;
                        break;
                    case 6:
                        changeX = changeXold - sIx * moveXnow;
                        changeY = changeYold + sIy * moveYnow;
                        break;
                    case 7:
                        changeX = changeXold + sIx * moveXnow;
                        changeY = changeYold - sIy * moveYnow;
                        break;
                    case 8:
                        changeX = changeXold + sIx * moveXnow;
                        changeY = changeYold + sIy * moveYnow;
                        break;
                }

                overlap = 0;
                for (var x = Ix - Marg ; x < Ix + Wnow + Marg  ; x += precision) {
                    for (var y = Iy - Marg; y < Iy + Hnow + Marg; y += precision) {
                        if (x + changeX < wp && y + changeY < hp && x + changeX > 0 && y + changeY > 0) { if (xy[x + changeX][y + changeY] == 1) { overlap = 1; break; }; }
                    }
                    if (overlap == 1) { break; }
                }
                if (overlap == 0) { break; }
            }   
        }
        Ln += 1; if (Ln > 1000) { break; }
        if (overlap == 1) {
            changeX = -sIx * moveXnow; // (-1 + Math.round(Math.random()) * 2) * moveXnow;
            changeY = -sIy * moveYnow; //(-1 + Math.round(Math.random()) * 2) * moveYnow;
            //if (Math.abs(changeX) > 16 * moveXnow) { changeX = 0; changeXold = 0; }
            //if (Math.abs(changeY) > 10 * moveYnow) { changeY = 0; changeYold = 0; }
        }
    } while (overlap == 1);
    for (var x = Ix ; x < Ix + Wnow  ; x++) {
        for (var y = Iy ; y < Iy + Hnow  ; y++) {
            if (x + changeX < wp && y + changeY < hp && x + changeX > 0 && y + changeY > 0) { xy[x + changeX][y + changeY] = 1; }
        }
    }

    change[0] = changeX;
    change[1] = changeY;
    return change;

   
}


function calculateConceptWORLD(angle) {


    var xh = -9999; var xl = 9999; var yh = -9999; var yl = 9999;


    //ROTATE
    for (var i = 1; i < cardn + 1; i++) {

        itemxx[i] = itemx[i] * Math.cos(angle * Math.PI) - itemy[i] * Math.sin(angle * Math.PI);   //cos.x - sin.y
        itemyy[i] = itemx[i] * Math.sin(angle * Math.PI) + itemy[i] * Math.cos(angle * Math.PI);  // sin.x + cos.y    

    }
    //TRANSLATE
    for (var i = 1; i < cardn + 1; i++) {

        cardwx[i] = itemxx[i] / Math.pow(Math.pow(itemxx[i], 2) + Math.pow(itemyy[i], 2), .5);
        cardwy[i] = itemyy[i] / Math.pow(Math.pow(itemxx[i], 2) + Math.pow(itemyy[i], 2), .5);

    }

    //participants
    for (var p = 1; p < participantn + 1; p++) {
        partx[p] = participantdr[p][1][rateToUse] * Math.cos(angle * Math.PI) - participantdr[p][2][rateToUse] * Math.sin(angle * Math.PI); //itemx[i] * Math.cos(angle * Math.PI) - itemy[i] * Math.sin(angle * Math.PI);
        party[p] = participantdr[p][1][rateToUse] * Math.sin(angle * Math.PI) + participantdr[p][2][rateToUse] * Math.cos(angle * Math.PI); //itemx[i] * Math.sin(angle * Math.PI) + itemy[i] * Math.cos(angle * Math.PI);
    }
    //participantsgroups
    for (var p = 1; p < participantgroupn + 1; p++) {
        partgx[p] = participantdrg[p][1][rateToUse] * Math.cos(angle * Math.PI) - participantdrg[p][2][rateToUse] * Math.sin(angle * Math.PI);
        partgy[p] = participantdrg[p][1][rateToUse] * Math.sin(angle * Math.PI) + participantdrg[p][2][rateToUse] * Math.cos(angle * Math.PI);

    }

    //center
    worldcenterx = cc.width / 2;
    worldcentery = cc.height / 2;

    worldsize = cc.width / 5;
    if (2 * worldsize > cc.height) worldsize = cc.height / 6;



    //DEFINE POSITIONS TO DRAW CLUSTERS
    for (var g = 2; g < clusternShown + 1 ; g++) {
        for (var c = 1; c < g + 1; c++) {

            clusterwx[g][c] = 0; var nn = 0;
            for (var ii = 1; ii < groupsn1[g][c] + 1; ii++) {

                var i = groups1[g][c][ii];

                clusterwx[g][c] += cardwx[i];
                nn += 1;
            }
            clusterwx[g][c] = clusterwx[g][c] / nn;

            // meanz = meanz / nn;
            var hnr = 0; var lnr = 0; var pipi = 0
            var pil = 9999; var pih = -9999;




            if (clusterwx[g][c] != 0) {

                for (var ii = 1; ii < groupsn1[g][c] + 1; ii++) {

                    var i = groups1[g][c][ii];

                    if (cardwx[i] > 0 && cardwy[i] > 0) pipi = 0 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);
                    if (cardwx[i] > 0 && cardwy[i] < 0) pipi = 1 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);
                    if (cardwx[i] < 0 && cardwy[i] < 0) pipi = 1 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);
                    if (cardwx[i] < 0 && cardwy[i] > 0) pipi = 2 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);


                    graphPositionH[g][c][i] = pipi;


                    if (pipi < pil) { pil = pipi; lnr = i }
                    if (pipi > pih) { pih = pipi; hnr = i }


                }


                pilWC[g][c] = pil; pihWC[g][c] = pih;

                pilName[g][c] = -.5 * Math.PI + pilWC[g][c];
                pihName[g][c] = -.5 * Math.PI + pihWC[g][c];

                mxWC3[g][c] = parseFloat(Math.sin(pilWC[g][c] + (pihWC[g][c] - pilWC[g][c]) / 2))
                myWC3[g][c] = parseFloat(-Math.cos(pilWC[g][c] + (pihWC[g][c] - pilWC[g][c]) / 2));
                mxAbsWC[g][c] = worldcenterx + sign(mxWC3[g][c]) * (worldsize + boxMwithin);
                myAbsWC[g][c] = worldcentery + myWC3[g][c] * (worldsize + boxMwithin);

                //mxWC3[g][c] = mxWC[c];
                //myWC3[g][c] = myWC[c];

                //this correction is needed for upper cluster going trough x zero..
                if (pihWC[g][c] - pilWC[g][c] > Math.PI) {



                    //var ll = pilWC[c]; pilWC[c] = pihWC[c]; pihWC[c] = ll + 2 * Math.PI;

                    var pil = 9999; var pih = -9999;
                    for (var ii = 1; ii < groupsn1[g][c] + 1; ii++) {

                        var i = groups1[g][c][ii];

                        if (cardwx[i] > 0 && cardwy[i] > 0) pipi = 0 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);
                        if (cardwx[i] > 0 && cardwy[i] < 0) pipi = 1 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);
                        if (cardwx[i] < 0 && cardwy[i] < 0) pipi = 1 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);
                        if (cardwx[i] < 0 && cardwy[i] > 0) pipi = 2 * Math.PI + Math.atan(cardwx[i] / cardwy[i]);


                        graphPositionH[g][c][i] = pipi;


                        if (pipi > Math.PI) { if (pipi < pil) { pil = pipi; lnr = i; } }
                        if (pipi < Math.PI) { if (pipi > pih) { pih = pipi; hnr = i; } }


                    }


                    pilWC[g][c] = pil; pihWC[g][c] = pih;

                    pilName[g][c] = .5 * Math.PI + pilWC[g][c];
                    pihName[g][c] = .5 * Math.PI + pihWC[g][c];


                    mxWC3[g][c] = -parseFloat(Math.sin(pilWC[g][c] + (pihWC[g][c] - pilWC[g][c]) / 2))
                    myWC3[g][c] = -parseFloat(-Math.cos(pilWC[g][c] + (pihWC[g][c] - pilWC[g][c]) / 2));
                    //myWC[c] = parseFloat(-1);
                    mxAbsWC[g][c] = worldcenterx + sign(mxWC3[g][c]) * (worldsize + boxMwithin);
                    myAbsWC[g][c] = worldcentery + myWC3[g][c] * (worldsize + boxMwithin);

                    // mxWC3[g][c] = mxWC[g][c];
                    // myWC3[g][c] = myWC[g][c];



                }


            }
        }
    }
    var boxWidth = (cc.width - (2 * worldsize + 2 * boxMwithin + 2 * boxMcorner)) / 2;
    var lineHeight = 10;




    //TEST TOTAL LENGTH OF CLUSTER ITEMS
    for (var g = 2; g < clusternShown + 1 ; g++) {
        var number = "";
        for (var c = 1; c < g + 1; c++) {
            lenAbsWC[g][c] = 0;
            for (var ii = 1; ii < groupsn1[g][c] + 1; ii++) {

                var i = groups1[g][c][ii];
                //testcanvas//
                cctxTest.font = '9pt Calibri';
                if (showItemNumber == true) { number = "(" + i.toString() + ") "; }
                var linN = wraptextsign(cctxTest, number + cardt[i].trim(), 0, 0, boxWidth, lineHeight, sign(cardwx[i]));
                lenAbsWC[g][c] += wamy + linN * wmy;
            }
            lenAbsWC[g][c] += wamy;
            //lenWC[c] = lenWC[c] / (.5 * cc.height);
        }

        for (var s = 0; s < 2; s++) {

            var mxWC2 = new Array(g.value);

            for (var c = 1; c < g + 1; c++) {
                if (s == 0) { mxWC2[c] = mxWC3[g][c] } else { mxWC2[c] = -mxWC3[g][c] };
            }

            var cNow = new Array(g.value);
            var lyNow = new Array(g.value);
            var cDoneNow = new Array(g.value);
            var CinNow = 0;
            for (var c = 1; c < g + 1; c++) {
                cNow[c] = 0; lyNow[c] = 99999; cDoneNow[c] = 0;
            }
            for (var c = 1; c < g + 1; c++) {
                if (sign(mxWC2[c]) > 0) {
                    for (var c2 = 1; c2 < g + 1; c2++) {

                        if (sign(mxWC2[c2]) > 0 && cDoneNow[c2] !== 1) { if (myAbsWC[g][c2] < lyNow[c]) { lyNow[c] = myAbsWC[g][c2]; cNow[c] = c2; } }
                    }
                }
                cDoneNow[cNow[c]] = 1;
            }
            var totSpace = 0; var Space = 0;
            for (var c = 1; c < g + 1; c++) {
                if (sign(mxWC2[c]) > 0) {
                    totSpace += lenAbsWC[g][cNow[c]];
                    CinNow += 1;
                }
            }
            totSpace = cc.height - totSpace;
            var nNow = 0; var yNowStart = -1; var yNowEnd = -1;
            for (var c = 1; c < g + 1; c++) {
                if (sign(mxWC2[c]) > 0) {
                    nNow += 1;
                    if (nNow == 1) { yNowStart = totSpace / (CinNow + 1); yNowEnd = yNowStart + lenAbsWC[g][cNow[c]]; }
                    if (nNow > 1) { yNowStart = yNowEnd + totSpace / (CinNow + 1); yNowEnd = yNowStart + lenAbsWC[g][cNow[c]]; }
                    myAbsWC[g][cNow[c]] = yNowStart;

                }
            }
        }
    }
}


function drawconceptmapWORLD() {


    cc.onmousedown = "";
    cc.onmousemove = drawparticipantsclusterNames;  //DEZE PROCEDURE NOG IN TWEE DELEN OPSPLITSEN OM SNELLER TE MAKEN

    document.body.style.overflow = "hidden";   // "scroll";

    getUserClusterNames();
    getUserDimensionNames()
    getClusterNamesFromTree(clustern);

    //START DRAWING

    var boxWidth = (cc.width - (2 * worldsize + 2 * boxMwithin + 2 * boxMcorner)) / 2;
    var lineHeight = 10;

    var number = "";

    var xxr = 10;
    var yyr = 20;

    var clusterRateSpace = .8;
    var clusterNamePosition = 1.1;
    var clusterListingPosition = (clusterNamePosition - 1) * worldsize;


    //CLEAR SCREEN
    cctx.globalAlpha = 1;
    cctx.clearRect(0, 0, cc.width, cc.height);

    cctx.fillStyle = mapFillstyle;
    cctx.fillRect(backM, backM, cc.width - 2 * backM, cc.height - 2 * backM);

    drawProjectName();

    //DRAW WORLD
    cctx.strokeStyle = mapFontcolor;
    cctx.fillStyle = mapFillstyle;
    cctx.lineWidth = 1;

    cctx.beginPath();
    cctx.arc(worldcenterx, worldcentery, worldsize, 0, 2 * Math.PI, false);
    //cctx.closePath();

    cctx.fill();


    cctx.stroke();

    cctx.font = '9pt Calibri';
    cctx.textAlign = 'start';
    cctx.textBaseline = "top";

    //DRAW PARTICIPANT eigenvalues
    var pSig = .14;
    if (ShowParticipants == true) {
        for (var p = 1; p < participantn + 1; p++) {

            if (Math.pow(Math.pow(participantdr[p][1][rateToUse], 2) + Math.pow(participantdr[p][2][rateToUse], 2), .5) > pSig) {


                var xx = parseFloat(worldcenterx + partx[p] * worldsize * .9);
                var yy = parseFloat(worldcentery + -1 * party[p] * worldsize * .9);

                cctx.beginPath();
                cctx.lineWidth = 1;
                cctx.moveTo(worldcenterx, worldcentery);
                cctx.lineTo(xx, yy);
                cctx.strokeStyle = mapFontcolor;
                cctx.stroke();

                cctx.fillStyle = mapFontcolor;
                wraptextsign(cctx, partnames[p].trim(), sign(partx[p]) * textM + xx, sign(party[p]) * textM / 2 + yy, sw - 2 * textM, 16, sign(partx[p]) * 1);


            }
        }
    }

    //DRAW PARTICIPANT GROUPS eigenvalues
    if (ShowParticipantsGroups == true) {


        for (var p = 1; p < participantgroupn + 1; p++) {

            if (Math.pow(Math.pow(participantdrg[p][1][rateToUse], 2) + Math.pow(participantdrg[p][2][rateToUse], 2), .5) > pSig) {


                var xx = parseFloat(worldcenterx + partgx[p] * worldsize * .9);
                var yy = parseFloat(worldcentery + -1 * partgy[p] * worldsize * .9);

                cctx.beginPath();
                cctx.lineWidth = 1;
                cctx.moveTo(worldcenterx, worldcentery);
                cctx.lineTo(xx, yy);
                cctx.strokeStyle = mapFontcolor;
                cctx.stroke();

                cctx.fillStyle = mapFontcolor;
                wraptextsign(cctx, participantdrgn[p].trim(), sign(partgx[p]) * textM + xx, sign(party[p]) * textM / 2 + yy, sw - 2 * textM, 16, sign(partgx[p]) * 1);


            }
        }

    }


    if (showClustersInMap == true) { smaller = .8 } else { smaller = 1 }

    if (showTreeInMap == true) {
        var x0 = worldcenterx; var y0 = worldcentery;
        for (var g = 2; g < clustern + 1 ; g++) {

            var relative = smaller * g / clustern;
            var relativeOld = smaller * groupsd[g][3] / clustern;

            if (g > 2) { x0 = mxWC3[groupsd[g][3]][groupsd[g][4]]; y0 = myWC3[groupsd[g][3]][groupsd[g][4]]; }

            for (l = 1; l < 2 + 1; l++) {

                var x = mxWC3[g][groupsd[g][l]];
                var y = myWC3[g][groupsd[g][l]];



                cctx.strokeStyle = treeLineColor;
                cctx.fillStyle = treeLineColor;

                //DRAW LINES BETWEEN CLUSTERS
                var ng = 2 + clustern - g;
                cctx.lineWidth = ng;

                cctx.beginPath();
                //cctx.moveTo(worldcenterx + x0 * relativeOld * worldsize, worldcentery + y0 * relativeOld * worldsize);
                cctx.moveTo(worldcenterx + x * relativeOld * worldsize, worldcentery + y * relativeOld * worldsize);
                cctx.lineTo(worldcenterx + x * relative * worldsize, worldcentery + y * relative * worldsize);
                //cctx.strokeStyle = "grey";
                cctx.stroke();

                cctx.textBaseline = "middle";
                cctx.textAlign = "center";

                //DRAW CLUSTER ARCS OF ALL CLUSTERS
                if (groupsn1[g][groupsd[g][l]] > 1) {

                    var clusterRadius = 16;
                    cctx.lineWidth = clusterRadius;
                    cctx.beginPath();
                    if (g == 2) {
                        cctx.arc(worldcenterx, worldcentery, relative * worldsize, -.5 * Math.PI + pilWC[2][l], -.5 * Math.PI + pihWC[2][l], false);
                    }
                    if (g > 2) {
                        cctx.arc(worldcenterx, worldcentery, relative * worldsize, -.5 * Math.PI + pilWC[g][groupsd[g][l]], -.5 * Math.PI + pihWC[g][groupsd[g][l]], false);
                    }


                    cctx.stroke();
                };
            }
        }

        for (var g = 2; g < clustern + 1 ; g++) {


            var relative = smaller * g / clustern;

            if (g > 2) { x0 = mxWC3[groupsd[g][3]][groupsd[g][4]]; y0 = myWC3[groupsd[g][3]][groupsd[g][4]]; }

            for (l = 1; l < 2 + 1; l++) {

                //DRAW CLUSTER TEXT IN ARCS OF ALL CLUSTERS
                cctx.font = '12pt Calibri';
                if (groupsn1[g][groupsd[g][l]] > 1) { cctx.fillStyle = cctx.fillStyle = "White"; } else { cctx.fillStyle = treeLineColor; }

                //cctx.fillStyle = "White";
                if (g == 2) {
                    drawTextAlongArc(cctx, yellowth[g][l].trim(), worldcenterx, worldcentery, relative * worldsize, pilName[2][l], pihName[2][l])
                }
                if (g > 2) {
                    drawTextAlongArc(cctx, yellowth[g][l].trim(), worldcenterx, worldcentery, relative * worldsize, pilName[g][groupsd[g][l]], pihName[g][groupsd[g][l]])
                }

            }
        }
    }


    for (var c = 1; c < clustern + 1; c++) {


        cctx.textBaseline = "top";
        cctx.textAlign = "left";


        if (showClustersInMap == true) {

            //DRAW CLUSTER NAME

            cctx.font = '14pt Calibri';
            cctx.fillStyle = clustersAndDimensionsFontcolor;
            cctx.strokeStyle = clustersAndDimensionsFontcolor;

            drawTextAlongArc(cctx, clusterNameNow[c], worldcenterx, worldcentery, worldsize * clusterNamePosition, pilName[clustern][c], pihName[clustern][c])

            //DRAW CLUSTER ARC
            var clusterRadius = parseInt((worldsize * .2 * (1 - clusterRateSpace)) * (clusterr1[clustern][c][rateToUse] - 1));
            cctx.beginPath();
            cctx.arc(worldcenterx, worldcentery, worldsize - clusterRadius * .5, -.5 * Math.PI + pilWC[clustern][c], -.5 * Math.PI + pihWC[clustern][c], false);
            cctx.lineWidth = clusterRadius;
            cctx.strokeStyle = importanceColor;
            cctx.stroke();

            for (var ii = 1; ii < groupsn1[clustern][c] + 1; ii++) {

                var i = groups1[clustern][c][ii];

                //DRAW ITEM ARC
                radius = parseInt((worldsize * .2 * (1 - clusterRateSpace)) * itemrating[i][rateToUse]);
                cctx.strokeStyle = importanceColorLight;
                cctx.lineWidth = radius;

                cctx.beginPath();
                //cctx.arc(worldcenterx, worldcentery, worldsize - radius * .5, -.502 * Math.PI + graphPositionH[i], -.498 * Math.PI + graphPositionH[i], false);
                cctx.arc(worldcenterx, worldcentery, worldsize - radius * .5, -.5 * Math.PI + graphPositionH[clustern][c][i] - .01, -.5 * Math.PI + graphPositionH[clustern][c][i] + .01, false);

                cctx.stroke();
            }

        }





        //DRAW ITEMS IN SEPARATE BOXES LEFT AND RIGHT OF THE WORLD

        var graphPositionY = new Array(cardn.value);

        var xt = mxAbsWC[clustern][c]; // worldcenterx + mxWC3[c] * (worldsize + 100); // worldcenterx + parseFloat(Math.sin(pilWC[c] + (pihWC[c] - pilWC[c]) / 2) * (worldsize + 100))
        var yt = myAbsWC[clustern][c]; // worldcentery + myWC3[c] * (worldsize + 100); //worldcentery + parseFloat(-Math.cos(pilWC[c] + (pihWC[c] - pilWC[c]) / 2) * (worldsize + 100));

        var xt2 = worldcenterx + mxWC3[clustern][c] * (worldsize + clusterListingPosition); // worldcenterx + parseFloat(Math.sin(pilWC[c] + (pihWC[c] - pilWC[c]) / 2) * (worldsize + 20))
        var yt2 = worldcentery + myWC3[clustern][c] * (worldsize + clusterListingPosition); //worldcentery + parseFloat(-Math.cos(pilWC[c] + (pihWC[c] - pilWC[c]) / 2) * (worldsize + 20));




        cctx.fillStyle = mapFillstyle;
        cctx.strokeStyle = mapFontcolor;

        cctx.lineWidth = 1;

        //DRAW STANDARD CLUSTER BACKGROUND
        if (mxAbsWC[clustern][c] > worldcenterx) {

            drawcluster2(c, xt - wmx, yt - wmy, boxWidth + 2 * wmx, lenAbsWC[clustern][c] + 2 * wmy, 1, false, 3, -1, false);
        }
        else {
            drawcluster2(c, xt - (boxWidth + wmx), yt - wmy, boxWidth + 2 * wmx, lenAbsWC[clustern][c] + 2 * wmy, false, 1, 3, -1, false);
        }



        // CLUSTERNAME IN TEXTBOX
        var mLabel = 10;
        if (mxAbsWC[clustern][c] > worldcenterx) {
            //if (clusterwx[c] > 0) {
            xx = mLabel + xt - wmx;

        }
        else {
            xx = mLabel + xt - (boxWidth + wmx);
        }
        yy = yt - (wmy);

        yellow[c].innerText = clusterNameNow[c].trim();
        yellow[c].style.fontFamily = "Calibri";
        yellow[c].style.fontSize = "22px";
        yellow[c].style.color = "transparant";
        yellow[c].style.visibility = 'visible';
        yellow[c].style.left = cc.offsetLeft + parseInt(xx) + "px";
        yellow[c].style.top = cc.offsetTop + parseInt(yy) + "px";
        yellow[c].style.width = boxWidth + 'px';
        yellow[c].style.height = sh + 'px';

        var plusMy = 0;
        for (var ii = 1; ii < groupsn1[clustern][c] + 1; ii++) {

            var i = groups1[clustern][c][ii];


            //DRAW ITEM TEXT
            cctx.font = '9pt Calibri';
            cctx.fillStyle = itemDotColor;
            if (showItemNumber == true) { number = "(" + i.toString() + ") "; }
            var linN = wraptextsign(cctx, number + cardt[i].trim(), xt, yt + plusMy, boxWidth, lineHeight, sign(mxAbsWC[clustern][c] - worldcenterx));

            plusMy += wamy + linN * wmy;

            var xxr = worldcenterx + cardwx[i] * (worldsize + 30);
            var yyr = worldcentery + cardwy[i] * (worldsize + 30) * -1;



        }
        //clusterHeight = plusMy;
        cctx.fillStyle = "black";
        cctx.strokeStyle = mapFontcolor;
        cctx.beginPath();

        if (cardwx[groups1[clustern][c][1]] > 0) {
            cctx.moveTo(xt - wmx, yt + lenAbsWC[clustern][c] * .5);
        }
        else {
            cctx.moveTo(xt + wmx, yt + lenAbsWC[clustern][c] * .5);
        }
        cctx.lineTo(xt2, yt2);
        //cctx.moveTo(xxr2, yyr2);
        //cctx.lineTo(xxr, yyr);
        cctx.closePath();

        cctx.lineWidth = 1;
        cctx.stroke();


    }


    showdimensions();

    cctx.font = "9pt Calibri"
    cctx.textAlign = "left";

    ///CLUSTER NAMES USED BY PARTICIPANTS

    //for (var r = 1; r < clusternamesn + 1; r++) {
    //    cctx.fillText(clusternames[r], cnamex[r], cnamey[r]);;

    //}


    //var dataURL = cc.toDataURL();

    // set canvasImg image src to dataURL
    // so it can be saved as an image
    //document.getElementById('canvasImg').src = dataURL;
    //buttonTest.src = dataURL;

}


function drawwordcloud() {


    cc.onmousedown = "";
    cc.onmousemove = "";

    document.body.style.overflow = "hidden";
    //document.body.style.overflow = "scroll";

    var cloudType = 1;

    getUserClusterNames();
    getUserDimensionNames()
    getClusterNamesFromTree(clustern);

    clusterdistancesMap();

    cctx.globalAlpha = 1;
    cctx.clearRect(0, 0, cc.width, cc.height);

    cctx.lineWidth = 2;
    //cctx.fillStyle = mapFillstyle;
    cctx.fillStyle = 'White';
    cctx.fillRect(0, 0, cc.width, cc.height);
    cctx.fillStyle = mapFillstyle;
    cctx.fillRect(backM, backM, cc.width - 2 * backM, cc.height - 2 * backM);

    drawProjectName()

    var currentoption = loadExampleData();


    removeWordCloud()



    for (c = 1; c < clustern + 1; c++) {



        var xl = clusterxl[clustern][c] + clusterxw[clustern][c] / 2 - .5 * clusterdist[clustern][c][0] * pXsize;
        var xh = clusterxl[clustern][c] + clusterxw[clustern][c] / 2 + .5 * clusterdist[clustern][c][0] * pXsize;
        var xw = clusterdist[clustern][c][0] * pXsize;   //clusterxw[c];  //.77 weg als ronde vorm 
        var yl = clusteryl[clustern][c] + clusteryw[clustern][c] / 2 - .5 * clusterdist[clustern][c][0] * pYsize;
        var yh = clusteryl[clustern][c] + clusteryw[clustern][c] / 2 + .5 * clusterdist[clustern][c][0] * pYsize;
        var yw = clusterdist[clustern][c][0] * pYsize;  //clusteryw[c];   //.77 weg als ronde vorm 


        //DRAW CIRCLE

        cctx.save();
        cctx.translate(xl + (xh - xl) / 2, yl + (yh - yl) / 2);
        //cctx.scale(pXsize / pYsize, 1);
        cctx.scale(1, pYsize / pXsize);
        cctx.beginPath();
        cctx.arc(0, 0, .5 * clusterdist[clustern][c][0] * pXsize, 0, 2 * Math.PI, false);
        cctx.restore();
        cctx.fillStyle = mapFillstyle;
        cctx.fill();
        cctx.strokeStyle = importanceColor;
        //cctx.lineWidth = 14;
        cctx.lineWidth = parseInt((clusterr2[clustern][c][rateToUse] - 1) * 5);
        cctx.stroke();

        //SELECT WORDS
        for (var w = 0; w < 1000; w++) {
            wordsusedn[w] = 0;
            wordsused[w] = "";
        }
        wordsusednow = 0;

        var wordNow = "";
        for (var i = 1; i < groupsn[clustern][c] + 1; i++) {
            wordNow = cardt[groups[clustern][c][i]];
            //wordNow = wordNow.replace(/[^a-zA-Z0-9]/g, ' ');
            wordNow = wordNow.replace('(', ' ');
            wordNow = wordNow.replace(')', ' ');
            wordNow = wordNow.replace('.', ' ');
            wordNow = wordNow.replace(',', ' ');
            wordNow = wordNow.replace(':', ' ');
            wordNow = wordNow.replace(';', ' ');
            wordNow = wordNow.replace('/', ' ');
            addword(wordNow, itemx[i], itemy[i]);
        }

        //TOEVOEGEN WOORDEN AAN CLOUD;
        var plus = 0;
        for (var u = 0; u < wordsusednow; u++) {
            if (wordsusedn[u] < 2 && wordsused[u].length < 9) {
                plus += 1
            } else {
                wordsused[u - plus] = wordsused[u]; wordsusedn[u - plus] = wordsusedn[u];
            }
        }
        wordsusednow -= plus;

        //ccw[c] = document.createElement('canvas')
        //document.body.appendChild(ccw[c]);
        //var ccwtx = ccw[c].getContext('2d');


        //DEFINE WORDCLOUD




        var ccwtx = ccw[c].getContext('2d');

        ccw[c].style.position = "absolute";
        ccw[c].width = xw;
        ccw[c].height = yw;
        ccw[c].style.top = yl + "px";
        ccw[c].style.left = xl + "px";

        ccw[c].style.visibility = "visible";
        ccwtx.clearRect(0, 0, ccw[c].width, ccw[c].height);


        ccwtx.font = '30pt Calibri';

        var textNow = clusterNameNow[c].trim();
        var metrics = ccwtx.measureText(textNow);
        var testWidth = metrics.width;
        //hiero

        ccwtx.beginPath();
        ccwtx.rect(ccw[c].width / 2 - testWidth / 2, ccw[c].height / 2 - 45, testWidth, 35);


        ccwtx.fillStyle = mapFontcolor;
        ccwtx.fill();


        ccwtx.fillStyle = mapFillstyle;

        ccwtx.fillText(textNow, ccw[c].width / 2 - testWidth / 2, ccw[c].height / 2 - 15);
        //ccw[c].style.backgroundColor = 'grey';

        var options = {};
        if (currentoption) {
            options = (function evalOptions() {
                try {
                    return eval('(' + currentoption + ')');
                } catch (error) {
                    alert('The following Javascript error occurred in the option definition; all option will be ignored: \n\n' +
                      error.toString());
                    return {};
                }
            })();
        }

        options.gridSize = 8;
        options.weightFactor = 1
        options.origin[0] = xw / 2;
        options.origin[1] = yw / 2;
        options.fontFamily = 'Calibri';
        options.color = mapFontcolor;
        options.backgroundColor = 'transparent';
        options.clearCanvas = false;
        options.click = function (item) { alert(item[0] + ' N: ' + parseInt(Math.pow(item[1] / 12, 2))); }


        // Put the word list into options

        var list = [];

        for (var u = 0; u < wordsusednow ; u++) {
            //list.push(["groener", 5]);
            list.push([wordsused[u], 12 * Math.pow(wordsusedn[u], .5)]);
        }

        options.list = list;


        // All set, call the WordCloud();
        WordCloud(ccw[c], options);

    }



    var mapcloud = 0;
    if (mapcloud == 1) {


        cctx.lineWidth = 2;
        cctx.fillStyle = mapFillstyle;
        //cctx.fillStyle = 'White';
        cctx.fillRect(backM, backM, cc.width - 2 * backM, cc.height - 2 * backM);

        drawProjectName()
        cctx.font = '9pt Calibri';


        for (var w = 0; w < 1000; w++) {
            wordsusedn[w] = 0;
        }
        wordsusednow = 0;


        for (var i = 1; i < cardn + 1; i++) {
            addword(cardt[i], itemx[i], itemy[i]);  //NOT ROTATED!! original values
        }
        for (var r = 1; r < clusternamesn + 1; r++) {
            addword(clusternames[r], clusternamesdr[r][1], clusternamesdr[r][2]);
        }

        var rndm = Math.random();

        for (var u = 0; u < wordsusednow ; u++) {

            // }
            //var sumsq = Math.pow(Math.pow(clusternamesdr[r][1], 2) + Math.pow(clusternamesdr[r][2], 2), 0.5);

            //var corr = rx * clusternamesdr[r][1] / sumsq + ry * clusternamesdr[r][2] / sumsq
            //if (corr > .5) {
            //    nn += 1;



            //var xx = Math.round(( wordsusedx[u] / wordsusedn[u]) * 100) / 100;
            //var yy = Math.round(( wordsusedy[u] / wordsusedn[u]) * 100) / 100;
            //cctx.font = '9pt Calibri';
            //cctx.fillText(wordsused[u] + " (n= " + wordsusedn[u] + ")" + " (x= " + xx + ") (y= " + yy + ")", mapM, mapM + u * 12);



            var sumsq = Math.pow(Math.pow(wordsusedx[u], 2) + Math.pow(wordsusedy[u], 2), 0.5);

            if (sumsq > .2) {
                rndm = (Math.random() - .5) / 7;
                xx = cc.width / 2 + ((rndm + wordsusedx[u]) / wordsusedn[u]) * cc.width / 2;
                yy = cc.height / 2 + ((rndm + wordsusedy[u]) / wordsusedn[u]) * cc.height / 2;

                switch (wordsusedn[u]) {
                    case 1:
                        cctx.font = '9pt Calibri';
                        break;
                    case 2:
                        cctx.font = '11pt Calibri';
                        break;
                    case 2:
                        cctx.font = '13pt Calibri';
                        break;
                    case 3:
                        cctx.font = '15pt Calibri';
                        break;
                    case 4:
                        cctx.font = '17pt Calibri';
                        break;
                }

                cctx.fillText(wordsused[u], xx, yy);
                cctx.font = '19pt Calibri';
            }
            //cc.width - 2 * mapM

        }
    }
    cctx.font = '9pt Calibri';
}

function addword(sentence, x, y) {
    var found = 0;
    var words = sentence.split(' ');
    for (var w = 0; w < words.length; w++) {
        found = 0;
        words[w] = words[w].trim().toLowerCase();
        //if (words[w] == "voldoende") {
        //    var xx = 0;
        //}
        if (checkword(words[w]) != 1) {

            for (var u = 0; u <= wordsusednow ; u++) {
                if (wordsused[u] == words[w]) {
                    wordsusedn[u] += 1;
                    wordsusedx[u] += x;
                    wordsusedy[u] += y;

                    found = 1;
                }
            }

            if (found == 0) { wordsusednow += 1; wordsusedn[wordsusednow] = 1; wordsused[wordsusednow] = words[w]; wordsusedx[wordsusednow] = x; wordsusedy[wordsusednow] = y; }
        }
    }
}

function checkword(word, x, y) {

    var result = 0;
    var lang = "en";
    lang = "en";
    if (word.length < 4) {
        result = 1
    }
    else {
        if (lang == "nl") {
            switch (word) {
                case "zijn":
                    result = 1;
                    break;
                case "wordt":
                    result = 1;
                    break;
                case "het":
                    result = 1;
                    break;
                case "word":
                    result = 1;
                    break;
                case "een":
                    result = 1;
                    break;
                case "niet":
                    result = 1;
                case "mate":
                    result = 1;
                case "voor":
                    result = 1;
                case "achter":
                    result = 1;
                case "nee":
                    result = 1;
                    break;
                case "met":
                    result = 1;
                    break;
                case "ten":
                    result = 1;
                    break;
                case "dan":
                    result = 1;
                    break;
                case "heeft":
                    result = 1;
                    break;
                case "aan":
                    result = 1;
                    break;
                case "van":
                    result = 1;
                    break;
                case "was":
                    result = 1;
                    break;
                case "over":
                    result = 1;
                    break;
                case "langs":
                    result = 1;
                    break;
                case "door":
                    result = 1;
                    break;
                case "tussen":
                    result = 1;
                    break;
                case "alles":
                    result = 1;
                    break;
                case "erop":
                    result = 1;
                    break;
                case "eraan":
                    result = 1;
                    break;
                case "kan":
                    result = 1;
                    break;
            }
        }
        if (lang == "en") {
            switch (word) {
                case "":
                    result = 1;
                    break;
                case "the":
                    result = 1;
                    break;
                case "them":
                    result = 1;
                    break;
                case "with":
                    result = 1;
                    break;
                case "there":
                    result = 1;
                    break;
                case "what":
                    result = 1;
                    break;
                case "made":
                    result = 1;
                    break;
                case "not":
                    result = 1;
                    break;
                case "were":
                    result = 1;
                    break;
                case "make":
                    result = 1;
                    break;
                case "takr":
                    result = 1;
                    break;
                case "you":
                    result = 1;
                    break;
                case "and":
                    result = 1;
                    break;
                case "from":
                    result = 1;
                    break;
                case "for":
                    result = 1;
                    break;
                case "was":
                    result = 1;
                    break;
                case "their":
                    result = 1;
                    break;
            }
        }
    }
    return result
}





function showdimensions() {
    //DIMENSION NAMES

    //in textbox
    var ww = 300;
    var hh = 16;
    var mm = 2;
    for (d = 1; d < 4 + 1; d++) {
        yellow[clustermaxn + d].style.visibility = 'visible';
        yellow[clustermaxn + d].style.width = ww + 'px';
        yellow[clustermaxn + d].style.height = hh + 'px';
    }

    yellow[clustermaxn + 1].className = "dimtext";
    yellow[clustermaxn + 1].innerText = yellowt[clustermaxn + 1];
    yellow[clustermaxn + 1].style.top = (cc.height - 0) / 2 + 'px';
    yellow[clustermaxn + 1].style.left = 4 * mm - ww / 2 + 'px';
    yellow[clustermaxn + 1].style.textAlign = "center";
    //yellow[clustermaxn + 1].style.backgroundColor = "White";

    yellow[clustermaxn + 2].className = "dimtext";
    yellow[clustermaxn + 2].innerText = yellowt[clustermaxn + 2];
    yellow[clustermaxn + 2].style.top = (cc.height - 0) / 2 + 'px';
    yellow[clustermaxn + 2].style.left = cc.width - (4 * mm + ww / 2) + 'px';
    yellow[clustermaxn + 2].style.textAlign = "center";
    //yellow[clustermaxn + 2].style.backgroundColor = "White";

    yellow[clustermaxn + 3].innerText = yellowt[clustermaxn + 3];
    yellow[clustermaxn + 3].style.top = mm + 'px';
    yellow[clustermaxn + 3].style.left = (cc.width - ww) / 2 + 'px';
    yellow[clustermaxn + 3].style.textAlign = "center";
    //yellow[clustermaxn + 3].style.backgroundColor = "White";

    yellow[clustermaxn + 4].innerText = yellowt[clustermaxn + 4];
    yellow[clustermaxn + 4].style.top = cc.height - (mm + hh) + 'px';
    yellow[clustermaxn + 4].style.left = (cc.width - ww) / 2 + 'px';
    yellow[clustermaxn + 4].style.textAlign = "center";
    //yellow[clustermaxn + 4].style.backgroundColor = "White";

    //in canvas
    cctx.strokeStyle = 'black';
    cctx.fillStyle = "black";
    cctx.textBaseline = "top";
    cctx.textAlign = "start";

    cctx.font = "bold  11pt Calibri"

    cctx.fillStyle = clustersAndDimensionsFontcolor;

    cctx.save();
    cctx.translate(hh, (cc.height - 0) / 2);
    cctx.rotate(Math.PI / 2);
    cctx.textAlign = "center";
    cctx.fillText(yellowt[clustermaxn + 1].trim(), 0, 0);
    cctx.restore();

    cctx.save();
    cctx.translate(cc.width - 0, (cc.height - 0) / 2);
    cctx.rotate(Math.PI / 2);
    cctx.textAlign = "center";
    cctx.fillText(yellowt[clustermaxn + 2].trim(), 0, 0);
    cctx.restore();

    cctx.textAlign = "center";
    var metrics = cctx.measureText(yellowt[clustermaxn + 3]);
    var testWidth = metrics.width;
    wraptext(cctx, yellowt[clustermaxn + 3], (cc.width - 0) / 2, mm, ww, hh);

    var metrics = cctx.measureText(yellowt[clustermaxn + 4]);
    var testWidth = metrics.width;
    wraptext(cctx, yellowt[clustermaxn + 4], (cc.width - 0) / 2, cc.height - (mm + hh), ww, hh);

}

function defineanddrawclusterround(c, clusterrating) {



    var xl = 9999; var xh = -9999; var yl = 9999; var yh = -9999;
    var xll = new Array(101); var xli = new Array(101); var xhh = new Array(101); var yll = new Array(101); var yll2 = new Array(101); var yhh = new Array(101);
    var xc = new Array(101); var yc = new Array(101);
    for (var r = 1; r <= 100; r++) {
        xll[r] = 9999; xhh[r] = -9999; yll[r] = 9999; yll2[r] = 9999; yhh[r] = -9999;
    }
    var meanx = 0; var meany = 0; var meanz = 0; var nn = 0;
    for (var i = 1; i < groupsn[clustern][c] + 1; i++) {

        meanx += cardx[groups[clustern][c][i]];
        meany += cardy[groups[clustern][c][i]];
        //meanz += cardwz[groups3[clustern][c][i]];
        nn += 1;

    }
    meanx = meanx / nn;
    meany = meany / nn;
    //meanz = meanz / nn;

    if (meanx != 0) {

        for (var i = 1; i < groupsn[clustern][c] + 1; i++) {


            if (cardx[groups[clustern][c][i]] < xl) xl = cardx[groups[clustern][c][i]];
            if (cardx[groups[clustern][c][i]] > xh) xh = cardx[groups[clustern][c][i]];
            if (cardy[groups[clustern][c][i]] < yl) yl = cardy[groups[clustern][c][i]];
            if (cardy[groups[clustern][c][i]] > yh) yh = cardy[groups[clustern][c][i]];

            //VANUIT MEAN DRAAIEN! (EN TWEEMAAL LOOP VAN C! om eerst mean x en y te bepalen)
            for (var r = 1; r <= 100; r++) {



                var x = (cardx[groups[clustern][c][i]] - meanx) * Math.cos(2 * r / 100 * Math.PI) - (cardy[groups[clustern][c][i]] - meany) * Math.sin(2 * r / 100 * Math.PI);   //cos.x - sin.y
                var y = (cardx[groups[clustern][c][i]] - meanx) * Math.sin(2 * r / 100 * Math.PI) + (cardy[groups[clustern][c][i]] - meany) * Math.cos(2 * r / 100 * Math.PI);  // sin.x + cos.y
                var plusx = sign(x) * 10;  //.08
                //var plusx = sign(x) * .00
                var plusy = sign(y) * 10;   //.08
                x = x + plusx;
                //y = y + plusy;
                if (x < xll[r]) { xll[r] = x; xli[r] = groups[clustern][c][i]; yll[r] = y; }; //yll[r] = y;

                //if (y < yll[r]) yll[r] = y;
                if (y < yll2[r]) yll2[r] = y;


            }


        }
        for (var r = 1; r <= 100; r++) {
            //straight lines
            xc[r] = xll[r] * Math.cos(-2 * r / 100 * Math.PI) - yll[r] * Math.sin(-2 * r / 100 * Math.PI);
            yc[r] = xll[r] * Math.sin(-2 * r / 100 * Math.PI) + yll[r] * Math.cos(-2 * r / 100 * Math.PI);

            //roundings
            //xc[r] = xll[r] * Math.cos(-2 * r / 100 * Math.PI) - yll2[r] * Math.sin(-2 * r / 100 * Math.PI);
            //yc[r] = xll[r] * Math.sin(-2 * r / 100 * Math.PI) + yll2[r] * Math.cos(-2 * r / 100 * Math.PI);

            //beter roundings
            //xc[r] = xll[r] * Math.cos(-2 * r / 100 * Math.PI) - (yll[r] + yll2[r]) / 2 * Math.sin(-2 * r / 100 * Math.PI);
            //yc[r] = xll[r] * Math.sin(-2 * r / 100 * Math.PI) + (yll[r] + yll2[r]) / 2 * Math.cos(-2 * r / 100 * Math.PI);


            xc[r] = xc[r] + meanx;
            yc[r] = yc[r] + meany;


            //easy straight lines
            //xc[r] = cardwx[xli[r]];
            //yc[r] = cardwy[xli[r]];

        }
        // even smoother roundings
        for (var r = 5; r <= 96; r++) {
            xc[r] = (xc[r - 2] + xc[r - 1] + xc[r] + xc[r + 1] + xc[r + 2]) / 5;
            yc[r] = (yc[r - 2] + yc[r - 1] + yc[r] + yc[r + 1] + yc[r + 2]) / 5;
        }

        // blow up on page prevent painting outside world
        for (var r = 1; r <= 100; r++) {


        }

        if (xl != 9999) drawclusterround2(c, xc, yc, meanx, meany, clusterrating);
    }


}








function drawcluster(x, y, xw, yw, color, cardStyle, r) {

    var maxR = 20;
    var rr = parseInt(r * maxR);



    cctx.fillStyle = importanceColor;

    var cornerRadius = 5;



    cctx.beginPath();
    //cctx.rect(xl, yl, xh - xl, yh - yl);

    switch (cardStyle) {
        case 1:
            cctx.straightRect(x, y, xw, yw);
            break;
        case 2:
            cctx.singleRoundRect(x, y, xw, yw, cornerRadius);
            break;
        case 3:
            cctx.roundRect(x, y, xw, yw, cornerRadius);
            break;
        default:

    }



    cctx.lineWidth = rr;
    //cctx.lineWidth = 1;
    cctx.strokeStyle = Importancecolor;
    cctx.stroke();

    cctx.beginPath();

    //cctx.rect(xl - rr, yl - rr, 2 * rr + xh - xl, 2 * rr + yh - yl);
    switch (cardStyle) {
        case 1:
            cctx.straightRect(x - rr, y - rr, 2 * rr + xw, 2 * rr + yw);
            break;
        case 2:
            cctx.singleRoundRect(x - rr, y - rr, 2 * rr + xw, 2 * rr + yw, cornerRadius);
            break;
        case 3:
            cctx.roundRect(x - rr, y - rr, 2 * rr + xw, 2 * rr + yw, cornerRadius);
            break;
        default:

    }
    cctx.fillStyle = 'White';
    cctx.fill();

    //cctx.shadowOffsetX = 0;
    //cctx.shadowOffsetY = 0;
    //cctx.shadowBlur = 0;
    //cctx.shadowColor = "transparent";




}

function drawcluster2(cc, x, y, xw, yw, drawBack, color, cardStyle, r, lines) {

    var maxR = 20;
    var rr = parseInt(r * maxR);



    //cctx.fillStyle = importanceColor;

    var cornerRadius = 5;

    if (xw <= 2 * rr) xw = 2 * rr;
    if (yw <= 2 * rr) yw = 2 * rr;




    if (clusterSelected == cc && showItemNumber==false) {
        cctx.globalAlpha = 0.5
        //cctx.fillStyle =  "White";
    }
    else {
        cctx.globalAlpha = 1
        //cctx.fillStyle = mapFillstyle;
    }
    if (lines == false) {
        //cctx.beginPath();
        //cctx.rect(xl, yl, xh - xl, yh - yl);
        cctx.lineWidth = rr;
        if (r == -1) { cctx.lineWidth = 1; rr = 0; }
        switch (cardStyle) {
            case 1:
                cctx.straightRect(x + rr, y + rr, xw - 2 * rr, yw - 2 * rr);
                break;
            case 2:
                cctx.singleRoundRect(x + rr, y + rr, xw - 2 * rr, yw - 2 * rr, cornerRadius);
                break;
            case 3:
                cctx.roundRect(x - rr, y - rr, xw + 2 * rr, yw + 2 * rr, cornerRadius);
                break;
            default:

        }

        cctx.strokeStyle = importanceColor;
        cctx.stroke();
        //cctx.fill();
    }

    if (lines == true) {
        //cctx.beginPath();
        //cctx.rect(xl, yl, xh - xl, yh - yl);
        cctx.lineWidth = 1;
        for (var r = 1; r <= rr; r += 3) {
            switch (cardStyle) {
                case 1:
                    cctx.straightRect(x + r, y + r, xw - 2 * r, yw - 2 * r);
                    break;
                case 2:
                    cctx.singleRoundRect(x + r, y + r, xw - 2 * r, yw - 2 * r, cornerRadius);
                    break;
                case 3:
                    cctx.roundRect(x - r, y - r, xw + 2 * r, yw + 2 * r, cornerRadius);
                    break;
                default:

            }
            cctx.strokeStyle = importanceColor;
            cctx.stroke();
            //cctx.fill();
        }
    }




    //cctx.lineWidth = 1;



    if (drawBack == true) {
        cctx.beginPath();

        //cctx.rect(xl - rr, yl - rr, 2 * rr + xh - xl, 2 * rr + yh - yl);
        switch (cardStyle) {
            case 1:
                cctx.straightRect(x, y, xw, yw);
                break;
            case 2:
                cctx.singleRoundRect(x, y, xw, yw, cornerRadius);
                break;
            case 3:
                cctx.roundRect(x, y, xw, yw, cornerRadius);
                break;
            default:

        }
        cctx.fillStyle = mapFillstyle;
        cctx.fill();


    }


}

function drawclusterround(c, xc, yc) {



    if (c) {




        cctx.fillStyle = importanceColor;

        cctx.beginPath();
        cctx.moveTo(xc[r], yc[r]);
        for (var r = 1; r <= 100; r++) {


            cctx.lineTo(xc[r], yc[r]);


        }
        cctx.closePath();


        cctx.fill();


        cctx.lineWidth = 2;
        cctx.strokeStyle = 'black';
        cctx.stroke();

        cctx.shadowOffsetX = 0;
        cctx.shadowOffsetY = 0;
        cctx.shadowBlur = 0;
        cctx.shadowColor = "transparent";


    }


}


function drawclusterround2(c, xc, yc, meanx, meany, clusterrating) {



    if (c) {


        //cctx.restore();


        //cctx.shadowOffsetX = 6;
        //cctx.shadowOffsetY = 6;
        //cctx.shadowBlur = 15;
        //cctx.shadowColor = "grey";

        cctx.beginPath();
        cctx.moveTo(xc[r], yc[r]);

        for (var r = 1; r <= 100; r++) {


            cctx.lineTo(xc[r], yc[r]);


        }
        cctx.closePath();

        //cctx.fillStyle = mapFillstyle;
        //cctx.fill();

        cctx.lineWidth = parseInt(clusterrating * 20);
        if (clusterrating == -1) { cctx.lineWidth = 1; }

        cctx.strokeStyle = importanceColor;
        cctx.stroke();


        var w = sw - 2 * textM;
        var h = sh - 2 * textM;
        yellow[c].style.visibility = 'visible';
        yellow[c].style.left = textM + cc.offsetLeft + parseInt(meanx) - (w / 2) + "px";
        yellow[c].style.top = textM + cc.offsetTop + parseInt(meany) - (h / 2) + "px";
        yellow[c].style.width = w + 'px';
        yellow[c].style.height = h + 'px';



    }


}




function drawcardclassiccm(i, x, y, color, radius) {

    if (i) {



        var startAngle = 0.5 * Math.PI;
        var endAngle = 2 * Math.PI;
        var counterClockwise = false;



        cctx.beginPath();

        cctx.arc(x, y, radius, startAngle, endAngle, counterClockwise);
        cctx.lineTo(x, y);


        cctx.closePath();

        cctx.fillStyle = "grey";

        //cctx.fillStyle = '#555';
        if (color == 0) {
            cctx.fillStyle = "yellow";
        }
        if (color == 1) {
            cctx.fillStyle = "grey";
        }
        if (color == 2) {
            cctx.fillStyle = "blue";
        }
        if (color == 3) {
            cctx.fillStyle = "green";
        }
        if (color == 4) {
            cctx.fillStyle = "DarkKhaki";
        }
        if (color == 5) {
            cctx.fillStyle = "FireBrick";
        }
        if (color == 6) {
            cctx.fillStyle = "YellowGreen ";
        }
        if (color == 7) {
            cctx.fillStyle = "orange";
        }
        if (color == 8) {
            cctx.fillStyle = "DarkSalmon";
        }
        if (color == 9) {
            cctx.fillStyle = "CornflowerBlue";
        }
        if (color == 10) {
            cctx.fillStyle = "red";
        }
        if (color == 11) {
            cctx.fillStyle = "DarkSlateGray ";
        }
        if (color == 12) {
            cctx.fillStyle = "CadetBlue";
        }
        if (color == 13) {
            cctx.fillStyle = "DarkRed";
        }
        if (color == 14) {
            cctx.fillStyle = "MediumAquaMarine";
        }
        if (color == 15) {
            cctx.fillStyle = "pink";
        }


        cctx.fill();
        cctx.lineWidth = 1;



        cctx.strokeStyle = 'black';
        cctx.stroke();




        cctx.fillStyle = "black";
        //cctx.fillText(cardt[i], tm + cardx[i], tm + cardy[i]);


        //if (itemselect[i] == 1) { wraptext(cctx, cardt[i], textM + x, textM / 2 + y, sw - 2 * textM, 16) };

        cctx.textBaseline = "top";
        cctx.textAlign = "start";

        if (showItemNumber == false) { if (itemselect[i] == 1) { wraptext(cctx, cardt[i], x + radius, y + radius, sw - 2 * textM, 16) } }
        if (showItemNumber == true) { wraptext(cctx, i.toString(), x + radius, y + radius, sw - 2 * textM, 16) }

    }

}

function drawcardclassiccmsimple(i, x, y, color, radius) {

    if (i) {





        var startAngle = 0.5 * Math.PI;
        var endAngle = 2 * Math.PI;
        var counterClockwise = false;



        cctx.beginPath();

        cctx.arc(x, y, radius, startAngle, endAngle, counterClockwise);
        cctx.lineTo(x, y);


        cctx.closePath();

        cctx.fillStyle = "grey";


        cctx.fillStyle = itemDotColor;



        cctx.fill();
        cctx.lineWidth = 1;

        cctx.shadowOffsetX = 0;
        cctx.shadowOffsetY = 0;
        cctx.shadowBlur = 0;
        cctx.shadowColor = "transparent";


        //cctx.strokeStyle = 'black';
        //cctx.stroke();


        cctx.textBaseline = "top";
        cctx.textAlign = "start";

        if (showItemNumber == false) { if (itemselect[i] == 1) { wraptext(cctx, cardt[i], x + 4, y, sw - 2 * textM, 16) } }
        if (showItemNumber == true) { wraptext(cctx, i.toString(), x + 4, y, sw - 2 * textM, 16) }

    }
}


function createyellows() {

    var doc = document;

    for (var i = 1; i < clustermaxn + 5; i++) {



        // create/insert new
        yellow[i] = document.createElement("textarea");

        yellow[i] = dv.appendChild(yellow[i]);
        if (i < 10) bbt = "yellow0" + i;
        if (i > 9) bbt = "yellow" + i;
        yellow[i].id = bbt;
        //yellow[i].style.visibility = 'hidden';

        if (i < 10) {
            yellow[i] = document.getElementById("yellow0" + i);
        }
        else {
            yellow[i] = document.getElementById("yellow" + i);
        }
        //yellow[i].style.visibility = 'visible';
        yellow[i].style.position = "absolute";

        //yellow[i].style.backgroundColor = "black";
        yellow[i].style.backgroundColor = "transparent";
        //yellow[i].value = yellowt[i];
        yellow[i].style.width = '1px';
        yellow[i].style.height = '1px';
        yellow[i].style.overflow = "hidden";
        yellow[i].style.borderStyle = "none";
        yellow[i].style.padding = "0px";
        yellow[i].style.fontFamily = "Calibri";
        yellow[i].style.fontSize = "14px";
        yellow[i].cols = 1;
        yellow[i].rows = 1;

        yellow[i].onclick = makeClusterNameVisible;
        yellow[i].onmouseleave = saveUserClusterNamesFromMap;

        yellow[i].style.color = 'transparent';
    }

}

function createyellows2() {

    var doc = document;

    for (var i = 1; i < clustermaxn + 1; i++) {
        for (var r = 1; r < 2 + 1; r++) {


            // create/insert new
            yellowh[i][r] = document.createElement("textarea");
            yellowh[i][r] = dv.appendChild(yellowh[i][r]);
            if (i < 10) bbt = "yellowt0" + i + r;
            if (i > 9) bbt = "yellowt" + i + r;
            yellowh[i][r].id = bbt;
            yellow[i].style.visibility = 'hidden';

            if (i < 10) {
                yellowh[i][r] = document.getElementById("yellowt0" + i + r);
            }
            else {
                yellowh[i][r] = document.getElementById("yellowt" + i + r);
            }
            //yellowh[i][r].style.visibility = 'visible';
            yellowh[i][r].style.position = "absolute";
            //yellowh[i][r].value = "added on the fly";
            //yellow[i].style.backgroundColor = "black";
            yellowh[i][r].style.backgroundColor = "transparent";
            //yellowh[i][r].value = yellowt[i];
            yellowh[i][r].style.width = '1px';
            yellowh[i][r].style.height = '1px';
            yellowh[i][r].style.overflow = "hidden";

            yellowh[i][r].style.borderStyle = "none";
            yellowh[i][r].style.padding = "0px";
            yellowh[i][r].style.fontFamily = "Calibri";
            yellowh[i][r].style.fontSize = "14px";
            yellowh[i][r].cols = 1;
            yellowh[i][r].rows = 1;

            yellowh[i][r].onclick = makeClusterNameVisibleH;
            yellowh[i][r].onmouseleave = saveUserClusterNamesFromTree;

            yellowh[i][r].style.color = 'transparent';


        }
    }
}

function hideYellows() {
    for (var c = 1; c < clustermaxn + 5; c++) {
        yellow[c].style.visibility = 'hidden';
    }
    for (var c = 1; c < clustermaxn + 1; c++) {
        for (var r = 1; r < 2 + 1; r++) {
            yellowh[c][r].style.visibility = 'hidden';
        }
    }
}


function saveUserClusterNamesFromVar() {

    var names = ""
    for (var g = 0; g < clustermaxn ; g++) {

        names += fixedLength(yellowth[g + 1][1], 90) + fixedLength(yellowth[g + 1][2], 90);
    }
    MapCN.value = names;
    var names = "";
    names += fixedLength(yellowt[clustermaxn + 1], 90);
    names += fixedLength(yellowt[clustermaxn + 2], 90);
    names += fixedLength(yellowt[clustermaxn + 3], 90);
    names += fixedLength(yellowt[clustermaxn + 4], 90);
    MapDN.value = names;
    saveMapNamesToServer();

}


function makeClusterNameVisible() {
    var idNow = this.id;
    var g = parseInt(idNow.substr(6, 2));
    yellow[g].style.color = 'red';
    if (g > clustermaxn) { yellow[g].style.backgroundColor = 'white' };
}


function makeClusterNameVisibleH() {
    var idNow = this.id;
    var g = parseInt(idNow.substr(7, 2));
    var ii = idNow.substr(9, 1);
    yellowh[g][ii].style.color = 'red';
}



function saveUserClusterNamesFromTree() {

    //var oo = this.id;
    var names = ""
    for (var g = 0; g < clustermaxn ; g++) {

        yellowth[g + 1][1] = yellowh[g + 1][1].innerText;
        yellowth[g + 1][2] = yellowh[g + 1][2].innerText;

        //names  += fixedLength(yellowth[g+1][1], 90) +fixedLength(yellowth[g+1][2], 90);

        yellowh[g + 1][1].style.color = 'transparent';
        yellowh[g + 1][2].style.color = 'transparent';

    }
    saveUserClusterNamesFromVar();
    //MapCN.value = names;
    drawTree();
}

function saveUserClusterNamesFromMap() {

    var names = ""
    for (var c = 0; c < clustern ; c++) {

        yellowth[mapClusersFromG[c + 1]][mapClusersFromR[c + 1]] = yellow[c + 1].innerText;
        yellowt[c + 1] = yellow[c + 1].innerText;

        yellow[c + 1].style.color = 'transparent';
        yellow[c + 1].style.backgroundColor = 'transparent';
    }
    saveUserDimensionNames()
    saveUserClusterNamesFromVar();



}

function getUserClusterNames() {


    var names = ""
    for (var g = 0; g < clustermaxn  ; g++) {

        yellowth[g + 1][1] = MapCN.value.substr(g * 180, 90).trim();
        yellowth[g + 1][2] = MapCN.value.substr(g * 180 + 90, 90).trim();

        yellowh[g + 1][1].innerText = yellowth[g + 1][1];
        yellowh[g + 1][2].innerText = yellowth[g + 1][2];

    }

}

function saveUserDimensionNames() {
    yellowt[clustermaxn + 1] = yellow[clustermaxn + 1].innerText;
    yellow[clustermaxn + 1].style.color = 'transparent';
    yellow[clustermaxn + 1].style.backgroundColor = 'transparent';
    yellowt[clustermaxn + 2] = yellow[clustermaxn + 2].innerText;
    yellow[clustermaxn + 2].style.color = 'transparent';
    yellow[clustermaxn + 2].style.backgroundColor = 'transparent';
    yellowt[clustermaxn + 3] = yellow[clustermaxn + 3].innerText;
    yellow[clustermaxn + 3].style.color = 'transparent';
    yellow[clustermaxn + 3].style.backgroundColor = 'transparent';
    yellowt[clustermaxn + 4] = yellow[clustermaxn + 4].innerText;
    yellow[clustermaxn + 4].style.color = 'transparent';
    yellow[clustermaxn + 4].style.backgroundColor = 'transparent';
}

function getUserDimensionNames() {


    yellowt[clustermaxn + 1] = MapDN.value.substr(0 * 90, 90).trim();
    yellowt[clustermaxn + 2] = MapDN.value.substr(1 * 90, 90).trim();
    yellowt[clustermaxn + 3] = MapDN.value.substr(2 * 90, 90).trim();
    yellowt[clustermaxn + 4] = MapDN.value.substr(3 * 90, 90).trim();

    yellow[clustermaxn + 1].innerText = yellowt[clustermaxn + 1];
    yellow[clustermaxn + 2].innerText = yellowt[clustermaxn + 2];
    yellow[clustermaxn + 3].innerText = yellowt[clustermaxn + 3];
    yellow[clustermaxn + 4].innerText = yellowt[clustermaxn + 4];
}

function getClusterNamesFromTree(clustern) {



    var clusterFingerPrint = new Array(clustermaxn);
    var clusterFingerPrintNow = new Array(clustermaxn);
    for (var n = 1; n < clustermaxn + 1; n++) {
        clusterNameNow[n] = "";
    }

    for (var n = 1; n < clustermaxn + 1; n++) {
        clusterFingerPrint[n] = new Array(3);
    }
    for (var g = 2; g < clustern  ; g++) {
        clusterFingerPrint[g][1] = ""; clusterFingerPrint[g][2] = "";
        for (var i = 1; i < groupsn[g][groupsd[g][1]] + 1; i++) {
            clusterFingerPrint[g][1] += groups[g][groupsd[g][1]][i] + ".";
        }
        for (var i = 1; i < groupsn[g][groupsd[g][2]] + 1; i++) {
            clusterFingerPrint[g][2] += groups[g][groupsd[g][2]][i] + ".";
        }
    }

    for (c = 1; c < clustern + 1; c++) {
        clusterFingerPrintNow[c] = "";
        for (var i = 1; i < groupsn[clustern][c] + 1; i++) {
            clusterFingerPrintNow[c] += groups[clustern][c][i] + ".";
        }
    }

    for (c = 1; c < clustern + 1; c++) {


        if (groupsd[clustern][1] == c) { clusterNameNow[c] = yellowth[clustern][1]; mapClusersFromG[c] = clustern; mapClusersFromR[c] = 1; }
        if (groupsd[clustern][2] == c) { clusterNameNow[c] = yellowth[clustern][2]; mapClusersFromG[c] = clustern; mapClusersFromR[c] = 2; }
        if (groupsd[clustern][1] != c && groupsd[clustern][2] != c) {
            for (var g = clustern - 1; g > 1  ; g--) {
                //for (var c = 1; c < groupsn[g][c] + 1; c++) {
                if (clusterFingerPrintNow[c] == clusterFingerPrint[g][1]) { clusterNameNow[c] = yellowth[g][1]; mapClusersFromG[c] = g; mapClusersFromR[c] = 1; }
                if (clusterFingerPrintNow[c] == clusterFingerPrint[g][2]) { clusterNameNow[c] = yellowth[g][2]; mapClusersFromG[c] = g; mapClusersFromR[c] = 2; }
                //}
            }
        }
    }
}

function drawNow(rotateNow, world, solutionDims) {

    w3 = $(window).width();
    h3 = $(window).height();

    redrawbuttons(w3, h3, mapM);
    showMenuManual();
    controls.enabled = false;

    if (rotateNow == true) { readdataall(); }

    if (sheetNumber == 0) {

        removeWordCloud(); setScreenW(); drawItemRates();
        UploadPic();
    }

    if (sheetNumber == 1) {
        setScreenHW(); removeWordCloud(); setScreenW(); calculateRateMatrix(1, 2); drawItemRateMatrix(1, 2);
        UploadPic();
    }

    if (sheetNumber == 2) {
        removeWordCloud(); calculateClusterTREE(); drawTree();
        UploadPic();
    }



    if (sheetNumber == 3) {


        if (solutionDims == 1) {

            radius = 4; setScreenHW(); removeWordCloud(); if (rotateNow == true) { calculateConceptWORLD(rotateangle); } drawconceptmapWORLD();
            if (rotateNow == true) { UploadPic(); }
            //UploadPic();
        }

        if (solutionDims == 2) {


            radius = 8; setScreenHW(); if (rotateNow == true) { calculateConceptMAP(rotateangle); } drawconceptmap(1);
            //if (rotateNow == true) { UploadPic(); }
            //UploadPic();

        }
        if (solutionDims == 3) {

            
            controls.enabled = true;


            drawconceptmap3dWorld();
        }
    }



    if (sheetNumber == 4) {



        if (solutionDims == 2) {
            radius = 4; setScreenHW(); if (rotateNow == true) { calculateConceptMAP(rotateangle); } drawwordcloud();
            //if (rotateNow == true) { UploadPic(); }
            UploadPic();
        }
    }

    function setScreenHW() {
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
    }
    function setScreenW() {
        document.body.width = w3;
        //document.body.height = h3;
        document.body.style.top = '0px';
        document.body.style.left = '0px';

        document.forms[0].width = w3;
        //document.forms[0].height = h3;
        document.forms[0].style.top = '0px';
        document.forms[0].style.left = '0px';

        cc.width = w3;
        //cc.height = h3;
        cc.style.top = '0px';
        cc.style.left = '0px';
    }

}



var loadExampleData = function loadExampleData() {

    var currentoption;
    var example = {

        option: '{\n' +
                '  gridSize: 12,\n' +
                '  weightFactor: 3,\n' +
                '  origin: [400, 200],\n' +   //center of canvas!!
                '  clearCanvas: true,\n' +
                '  fontFamily: \'Calibri\',\n' +
                '  color: \'#f0f0c0\',\n' +
                '  click: function(item) {\n' +
                '    alert(item[0] + \': \' + item[1]);\n' +
                '  },\n' +
                '  backgroundColor: \'#001f00\'\n' +
                '}'
    };



    currentoption = example.option

    return currentoption;

};




function fixedLength(s, n) {
    n = (n < 0) ? 0 : n
    s = s.substr(0, n);
    var a = [];
    a.length = n - s.length + 1;
    return s + a.join(' ');
};


function UploadPic() {

    // Generate the image data
    var Pic = document.getElementById("MapCanvas").toDataURL("image/png");
    Pic = Pic.replace(/^data:image\/(png|jpg);base64,/, "")

    // Sending the image data to Server
    $.ajax({
        type: 'POST',
        //url: 'Save_Picture.aspx/UploadPic',
        url: 'AriadneConceptSelectedMap.aspx/UploadPic',
        data: '{ "imageData" : "' + Pic + '" }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            //alert("Done, Picture Uploaded.");
        },

        error: function (msg) {
            alert('failure to save image to server: ' + msg);
        }

    });

    //saveMapNamesToServer();
}


function saveMapNamesToServer() {



    var obj = {};

    obj.activeSelectionS = activesel.value;
    obj.subTitle = dpns.value;
    obj.clusterNames = MapCN.value;
    obj.dimensionNames = MapDN.value;
    //obj.test = 52;

    $.ajax({

        type: "POST",

        url: "AriadneConceptSelectedMap.aspx/saveMapNamesToServer",

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

function drawProjectName() {

    if (showMapTitle == true) {

        cctx.font = '11pt Calibri';
        var projectName2 = projectName + ': ' + projectSubTitle + ' ';

        //" (" + solutionDims + " dimensional solution)"

        if (rateToUse == 1) { projectName2 = projectName2 + " (rating: " + ratedefinition[1][1] + ")"; }
        if (rateToUse == 2) { projectName2 = projectName2 + " (rating: " + ratedefinition[1][2] + ")"; }
        if (rateToUse == 3) { projectName2 = projectName2 + " (rating: " + ratedefinition[1][3] + ")"; }
        if (rateToUse == 4) { projectName2 = projectName2 + " (rating: " + ratedefinition[1][4] + ")"; }
        if (rateToUse == 5) { projectName2 = projectName2 + " (rating: " + ratedefinition[1][5] + ")"; }

        //' (' + participantn + ' participants)'
        //' (' + cardn + ' items)'
        //' (' + solutionDims + ' dimensional solution)'

        var metrics = cctx.measureText(projectName2);
        var testWidth = metrics.width;
        cctx.fillStyle = mapFontcolor;

        cctx.fillText(projectName2, (cc.width - testWidth) - mapM, 2);
    }
}