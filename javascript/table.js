
//COPYRIGHT TALCOTT bv THE NETHERLANDS

//colors and map propeties
var mapFillstyle = 'Cornsilk'; //background]
//var mapFontcolor = 'Chocolate';
var mapFontcolor = 'Brown';
var mapClusterImportancecolor = "Tomato";
var importanceColor = "red";
var treeLineColor = "LightSalmon";

var mapM = 20;

//data
var projectName = "";
var dataFile = "";
var data = "";
var catN = 99;
var dimN = 2;
var burtData;
var selectData
var mapData;


// coordinates and eigenvalues


var la = new Array(dimN.value);
var se = new Array(dimN.value);

var ev = new Array(dimN.value);
var es = new Array(dimN.value);
var co = new Array(dimN.value);
for (var n = 0; n < catN; n++) {
    es[n] = new Array(catN.value);
    co[n] = new Array(catN.value);
}
var catS = new Array(catN.value);

dl = document.getElementById('MainContent_tableLabels');
db = document.getElementById('MainContent_tableBurtMatrix');
ds = document.getElementById('MainContent_tableSelectField');
df = document.getElementById('MainContent_tableDataField');

dfp = document.getElementById('MainContent_tableProjectNameField');
dff = document.getElementById('MainContent_tableFileNameField');

cc = document.getElementById('MainContent_TableCanvas');
cctx = cc.getContext("2d");

//function startTimer() {
//    doNow();
//    setTimeout(function () { startTimer() }, 1500);
//}
//function doNow() {    
//}
//startTimer();

//var myVar;
//function myFunction() {
//    myVar = setTimeout(function () { alert("Hello") }, 3000);
//}
//function myStopFunction() {
//    clearTimeout(myVar);
//}

setInterval(start(), 3000);

function start() {

    data = df.value.trim();

    if (data != "") {
        readdataall();
        definecoordinaties()
        draw()
    }
}

//var myTimer = setInterval(doStuff, 5000);
//var myTimer = setTimeout(doStuff, 5000);

function readdataall() {

    

    projectName = dfp.value.trim();

    dataFile = dfp.value.trim();

    //read data
    if (db) {
        burtData = db.value;
        //nog lezen..        
    }
   
    readcoordines();
   
    if (dl) {
        for (var c = 0; c < catN; c++) {
            la[c] = dl.value.substr( c * 100, 100).trim();
        }
    }
    if (ds) {
        selectData = ds.value;
        for (var c = 0; c < catN; c++) {
            catS[c] = ds.value.substr(c, 1);
        }
    }
   
}

function readcoordines() {

    if (df) {

        mapData = df.value;
        dimN = parseInt(df.value.substr(0, 6));
        catN = parseInt(df.value.substr(6, 6));


        for (var d = 0; d < dimN; d++) {
            ev[d] = parseFloat(df.value.substr(12  + d * 10, 10));
        }
        for (var d = 0; d < dimN; d++) {
            for (var c = 0; c < catN; c++) {

                es[d][c] = parseFloat(df.value.substr(12 + dimN * 10 + d * (catN * 10) + c * 10, 10));
            }
        }
    }
}

function saveSelection() {
    ds.value = "";
    for (var c = 0; c < catN; c++) {      
        ds.value += catS[c];
    }
    selectData = ds.value;
   // yellowth[g + 1][1] = MapCN.value.substr(g * 180, 90).trim();
}


function definecoordinaties() {

    //es[0][0] = -1;
    //es[1][0] = -1;

    //es[0][1] = 1;
    //es[1][1] = -1;

    //es[0][2] = -1;
    //es[1][2] = 1;

    //es[0][3] = 1;
    //es[1][3] = 1;

    var w = cc.clientWidth - 2 * mapM;
    var h = cc.clientHeight - 2 * mapM;;

    var notSelectedN = 0;
    for (var c = 0; c < catN; c++) {
        if (catS[c] == 1) {
            co[0][c] = mapM + ((es[0][c] + 1) / 2) * w;
            co[1][c] = mapM + ((es[1][c] + 1) / 2) * h;
        }
        else {
            notSelectedN += 1;
            co[0][c] = mapM + w;
            co[1][c] = mapM + 60  * (notSelectedN -1);
            
        }
    }

     
}
 
function draw() {

    cc.onmousedown = catSelect;

    var m = 5;

    cctx.textBaseline = "top";
    cctx.textAlign = "start";

    cctx.clearRect(0, 0, cc.width, cc.height);

    cctx.lineWidth = 2;
    cctx.fillStyle = 'White';
    cctx.fillRect(0, 0, cc.width, cc.height);
    cctx.fillStyle = mapFillstyle;
    cctx.fillRect(mapM - m, mapM - m, 2 * m + cc.width - 2 * mapM, 2 * m + cc.height - 2 * mapM);

    cctx.font = '20pt Calibri';

    projectName ="test project"

    var metrics = cctx.measureText(projectName);
    var testWidth = metrics.width;
    cctx.fillStyle = mapFontcolor;

    cctx.fillText(projectName, (cc.width - testWidth) / 2, 2);
    cctx.font = '9pt Calibri';

    var lw = 3;
    var cardStyle = 1;
    var w = 20;
    var h = 20;

    for (var c = 0; c < catN; c++) {
        //drawCat(co[0][c] - (w / 2 + lw / 2), co[1][c] - (h / 2 + lw / 2), w, h, cardStyle, lw);
        drawCat(co[0][c] - (w / 2 + lw / 2), co[1][c] - (h / 2 + lw / 2), w, h, cardStyle, lw);

        cctx.font = '16pt Calibri';
        cctx.fillStyle = mapFontcolor;
        wraptext(cctx, la[c].trim(), co[0][c] + w, co[1][c] - h / 2, 150, 22);
        cctx.font = "9pt Calibri"

    }

}

function drawCat(x, y, xw, yw,   cardStyle, rr) {

     

    cctx.globalAlpha = .6;

    cctx.shadowOffsetX = 6;
    cctx.shadowOffsetY = 6;
    cctx.shadowBlur = 15;
    cctx.shadowColor = "grey";

    cctx.fillStyle = importanceColor;

    var cornerRadius = 5;

    if (xw <= 2 * rr) xw = 2 * rr;
    if (yw <= 2 * rr) yw = 2 * rr;


    cctx.beginPath();
    //cctx.rect(xl, yl, xh - xl, yh - yl);
    switch (cardStyle) {
        case 1:
            cctx.straightRect(x + rr, y + rr, xw - 2 * rr, yw - 2 * rr);
            break;
        case 2:
            cctx.singleRoundRect(x + rr, y + rr, xw - 2 * rr, yw - 2 * rr, cornerRadius);
            break;
        case 3:
            cctx.roundRect(x + rr, y + rr, xw - 2 * rr, yw - 2 * rr, cornerRadius);
            break;
        default:

    }




    cctx.lineWidth = rr;
    //cctx.lineWidth = 1;
    cctx.strokeStyle = mapClusterImportancecolor;
    cctx.stroke();

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
    cctx.fillStyle = 'White';
    cctx.fill();

    cctx.shadowOffsetX = 0;
    cctx.shadowOffsetY = 0;
    cctx.shadowBlur = 0;
    cctx.shadowColor = "transparent";




}


function catSelect(e) {

    var dist = 0; var low = 9999999; var yellow = 0; var item = 0;

    startmove = 1;
    var cardxnow = e.pageX - cc.offsetLeft;
    var cardynow = e.pageY - cc.offsetTop;


    for (var c = 0; c < catN  ; c++) {

        dist = Math.pow(co[0][c] - cardxnow, 2) + Math.pow(co[1][c] - cardynow, 2);
        if (dist < low) { low = dist; item = c }
    }
    //if (!catS[item]) { catS[item] = 0; }
    if (catS[item] == 0) { catS[item] = 1; } else { catS[item] = 0; }

    saveSelection()
    makeCall()
    
    
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


            indexNow1 = saveResult.indexOf("<computeMapResult>");
            indexNow2 = saveResult.indexOf("</computeMapResult>");
            saveResult = saveResult.substr(indexNow1+18, indexNow2 - (indexNow1+18));
            df.value = saveResult;
            readcoordines();
            definecoordinaties();
            draw();

            //wraptextSingleLine(cctx, " OK: " + saveSucceededN + ", NOT OK: " + saveNotSucceededN + ", last error message = " + saveResult, 10, cc.height - 20, 1800, 20);
        }
    }

    // Build the operation URL
    var url = "http://localhost:51636/Service3.svc";
    
    var body = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Body><computeMap xmlns="http://tempuri.org/">';

    body = body + '<selectData>' + selectData + '</selectData>';
    body = body + '<burtData>' + burtData + '</burtData>';
    body = body + '</computeMap></s:Body></s:Envelope>';

    // Send the HTTP request
    xmlHttp.open("POST", url, true);

    xmlHttp.setRequestHeader("Content-type", "text/xml; charset=utf-8");
    xmlHttp.setRequestHeader("SOAPAction", "http://tempuri.org/IService3/computeMap");

     


    xmlHttp.send(body);

}
