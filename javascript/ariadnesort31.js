

// COPYRIGHT TALCOTT bv THE NETHERLANDS
 
// DATA CONDITIONS

var maxtextlength = 100;

// RATE CONDITIONS

var groupmaxn = 8;
var itemmaxn = 100;

// ITEM CARDS

var cardbackcolor = "#FFFF99";
var cardbordercolor = "grey";
var cardbordersize = 1;
var cardstyle = 2;
 
var cornerRadius = 0;
var cornerRadiusFromSw = 30;

var sw = 0;  //card width
var sh = 0;  //card height
 //card width
var mx = 8;
var my = 8;

var mcx = 0; //space between non rated items

// CARD TEXT

var tmx = 6;
var tmy = 10;


//PAGE LAYOUT

var sizeHelpText =  30;
var lineSub = 0;  //devision between rated and non rated items
var sw2 = 0;      //rate cell width
var sh2 = 0;      //rate cell height

//VARS

var varsall = new Array(14999);

var cardn = 0;

var rates = new Array(groupmaxn);
var ratesN = new Array(groupmaxn);
var ratesCol = new Array(groupmaxn);

var cardt = new Array(cardn.value);
var carddroworder = new Array(cardn.value);
 
var cardx = new Array(cardn.value);
var cardy = new Array(cardn.value);

var cardsel = 0;

var groupsn = new Array(cardn.value);
 

 

var cardxn;
var cardyn;
var cardxd = 0;
var cardyd = 0;
var startdown = 0;
var startmove = 0;

 
function loaded() {

   
    cc = document.getElementById('SortCanvas');
    //cc.style.visibility = 'hidden';
    cctx = cc.getContext("2d");

    
    cctx.textAlign = 'left';
    cctx.textBaseline = "top";

    dv = document.getElementById('div');

    db = document.getElementById('datablock');
    db.style.visibility = 'hidden';

    yt = document.getElementById('YellowText');
    yt.style.visibility = 'hidden';


    dft = document.getElementById('itemData');
    dfs = document.getElementById('sortData');
    dfr = document.getElementById('rateData');
    if (dft.value != '') {
        readdataall();
        
    }
    
     
    
   
    //arrb = document.getElementById('arrangebutton');

    if (cctx) {

        //drawcardsandgroups() 


         

        cc.onmousedown = cardselect;
        cc.onmousemove = cardmove;

        //cc.onmousedown = startDraw;
        //cc.onmouseup = stopDraw;
        //cc.ontouchstart = handleStart;
        //cc.ontouchstop = handleEnd;
        //cc.ontouchmove = handleMove;


    }
    window.onresize = reload; 
    reload();

}
 



function reload() {

    cc.width = GetWidth();
    cc.height = GetHeight();

    var nPerRow = parseInt(cardn / (groupmaxn * 2)) + 1;

    //sw = parseInt((cc.width - (mx+ mx * (2 * groupmaxn))) / (2 * groupmaxn));

    sw2 = (cc.width - (mx + mx * groupmaxn)) / (groupmaxn);
    
    sw = (sw2 - 3 * mx) / 2;

    //sh = ((cc.height - sizeHelpText )- (nPerRow + 4) * my) / (nPerRow + 1);
     

    sh = 100;

    sh2 = cc.height - (sh + 3 * my+ sizeHelpText);
    
    cornerRadius = parseInt(sw / cornerRadiusFromSw)
    
    lineSub = cc.height - (sh + 2 * my);

     

    mcx = parseInt((cc.width - (2 * mx + sw)) / cardn);
    if (mcx > 20) mcx = 20;

    if (sh > 150) sh = 150;
 
    cctx.font = '8pt Helvetica';

    //if (sh > 50) cctx.font = '8pt Helvetica';
    //if (sh > 90) cctx.font = '9pt Helvetica';
    //if (sw < 90) cctx.font = '7pt Helvetica';



    if (dft.value != '') {
        redrawcards();
    }
}
 

 
 

function saverateresult() {
    
    dfs.value = "";

    for (var g = 1; g < groupmaxn + 1; g++) {
        groupsn[g] = 0;
    }
    for (var i = 1; i < cardn + 1; i++) {
        
       groupsn[rates[i]] += 1;
         
    }

    for (var g = 1; g < groupmaxn + 1; g++) {
        if (groupsn[g] <  10) {
            dfs.value += " " + groupsn[g];
        }
        else {
            dfs.value += groupsn[g];
        }

    }

    for (var g = 1; g < groupmaxn + 1; g++) {


        for (var i = 1; i < cardn + 1; i++) {

            if (rates[i] == g) {

                if (i < 10) {
                    dfs.value += " " + i;
                }
                else {
                    dfs.value += i;
                }
            }
          
        }
    }
}

function readdataall() {
 
    //CARDS 

    cardn = parseInt(dft.value.substr(0, 3));
 
    groupsn[1] = cardn;
    //groups[1] = 1;
    for (var i = 0; i < cardn; i++) {

        cardt[i + 1] = dft.value.substr(3 + i * maxtextlength, maxtextlength)
 
    }
    for (var i = 1; i < cardn + 1; i++) {
        carddroworder[i] = 1 + cardn - i;
    }
  
    //SORT
    if (dfs.value != '') {
        for (var g = 1; g < groupmaxn + 1; g++) {


            groupsn[g] = parseInt(dfs.value.substr((g - 1) * 2, 2));


        }
        var pos = 0;
        var ii = 0;
        for (var g = 1; g < groupmaxn + 1; g++) {


            for (var i = 1; i < groupsn[g] + 1; i++) {


                ii = parseInt(dfs.value.substr(2 * groupmaxn + pos * 2, 2));
                rates[ii] = g;

                //groups[groups2[g][i]] = g
                pos += 1;
            }


        }
 
    }

    
}


function redrawcards() {


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

        

        cctx.fillStyle = "#C3C3C3";
        ratetext = "group";

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
        cctx.font = sizetext + 'pt Helvetica';
        metrics = cctx.measureText(ratetext)
        cctx.fillStyle = "white";
        cctx.fillText(ratetext, x + .5 * (sw2 - metrics.width), y + sh2 - mtext);
        
        var sizenumber = sw2;
        cctx.font = sizenumber + 'pt Helvetica';
        ratetext = i;
        metrics = cctx.measureText(ratetext)
        cctx.fillStyle = "white";
        cctx.fillText(ratetext, x + .5 * (sw2 - metrics.width), y + sh2 - (2*20+sizetext));

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

       i= carddroworder[ii]
        if (ratesCol[rates[i]] == 0) ratesCol[rates[i]] = 1; else ratesCol[rates[i]] = 0;
        if (i !== cardsel) {


            //cardx[i] = 2 * mx + ratesCol[rates[i]] * (mx + sw) + 2 * (rates[i] - 1) * (mx + sw);
             
            cardx[i] = mx + (rates[i] - 1) * (sw2 + mx) +   mx + ratesCol[rates[i]] * (mx + sw)  ;

            coln = (ratesN[rates[i]] - ratesCol[rates[i]])/2;
            cardy[i] = 2* my + coln * (sh + my);
            if (parseInt(rates[i]) == 0) {
                cardx[i] = mx +  ratesN[rates[i]] *   mcx;
                cardy[i] = my + sh2 +my+ sizeHelpText;
            }
        }
        ratesN[rates[i]] += 1;
        if (i !== cardsel) {
            drawcard(i, rates[i]);
        }
        //if (i == cardsel) {
        //    drawcard(i, rates[i]);
        //}
    }
    if (cardsel > 0) drawcard(cardsel, rates[i]);

    helptext(sizeHelpText);
}

function helptext(sizetext) {

    var Fold = ""
    var sorttext = "Get cards from below and place them in meaningfull groups on the canvasses above.";
    var metrics = "";

    //sizetext = sizetext / 2;
    //var mtext = sizetext / 2;

    Fold = cctx.font;

    cctx.font = sizetext-my + 'pt Helvetica';
    metrics = cctx.measureText(sorttext)
    cctx.fillStyle =   "#B3B3B3";

    var xx = .5 * cc.width - .5 * metrics.width;
    var yy = sh2 + sizetext + 1* my; // .5 * cc.height - .5 * sizetext;

    cctx.fillText(sorttext, xx, yy);
    cctx.font = Fold;
}

function cardselect(e) {



    if (startdown == 0) {
        startdown = 1;

        startmove = 1;
        cardxn = e.pageX - cc.offsetLeft;
        cardyn = e.pageY - cc.offsetTop;
        var dist = 9999; var low = 999999; var item = 0;

        for (var i = 1; i < cardn + 1; i++) {

            dist = Math.pow((cardx[i] + sw / 2) - cardxn, 2) + Math.pow((cardy[i] + sh / 2) - cardyn, 2);
            if (dist < low) { low = dist; item = i }
        }

        cardsel = item;

       

        redrawcards();

    }
    else {
        startdown = 0;


        for (var i = 1; i < cardn + 1; i++) {
            if (cardsel == carddroworder[i]) {
                for (var ii = i; ii < cardn; ii++) {
                    carddroworder[ii] = carddroworder[ii + 1];
                }
            }
        }

        carddroworder[cardn] = cardsel;

        if (e.pageY - cc.offsetTop < sh2 + sh/2) {
            var rr = 1 + parseInt((e.pageX - cc.offsetLeft) / ((cc.width - cc.offsetLeft) / groupmaxn));
            rates[cardsel] = rr;
        }
        else {
            rates[cardsel] = 0;
        }
        cardsel = 0;
        redrawcards();
        saverateresult();
    }

}

function cardmove(e) {

    if (startdown == 1) {
        if (startmove == 1) {

            //var base64 = cc.toDataURL();
            //cctx.clearRect(0, 0, cc.width, cc.height);
            //cc.style.backgroundImage = "url(" + base64 + ")";

            //var imageData = context.getImageData(0, 0, cc.width, cc.height);
            //var data = imageData.data;
            //cctx.putImageData(imageData, 0, 0);

            //also possible : animation frames: http://www.html5canvastutorials.com/advanced/html5-canvas-animation-stage/

            cardxd = cardx[cardsel] - cardxn;
            cardyd = cardy[cardsel] - cardyn;

            startmove = 0;
        }
        cctx.clearRect(0, 0, cc.width, cc.height);
        cardx[cardsel] = cardxd + e.pageX - cc.offsetLeft;
        cardy[cardsel] = cardyd + e.pageY - cc.offsetTop;

        redrawcards();
        //drawcard(cardsel, 1);
        //drawcards();
       // drawcardsandgroups() 


    }

}


    
  
 

function redrawcardsbutton() {
    redrawcards();
 
}


CanvasRenderingContext2D.prototype.straightRect = function (x, y, w, h) {

    this.beginPath();
    cctx.rect(x,y,w,h);
    this.closePath();
    return this;
}

CanvasRenderingContext2D.prototype.singleRoundRect = function (x, y, w, h, r) {
    if (w < 2 * r) r = w / 2;
    if (h < 2 * r) r = h / 2;
    this.beginPath();
     
    this.moveTo(x + r, y);
    this.arcTo(x + w, y, x + w, y + h, r);
    this.lineTo(x+w, y + h);
    this.lineTo(x, y + h);
    this.lineTo(x, y);

    this.closePath();
}


CanvasRenderingContext2D.prototype.roundRect = function (x, y, w, h, r) {
    if (w < 2 * r) r = w / 2;
    if (h < 2 * r) r = h / 2;
    this.beginPath();
    this.moveTo(x + r, y);
    this.arcTo(x + w, y, x + w, y + h, r);
    this.arcTo(x + w, y + h, x, y + h, r);
    this.arcTo(x, y + h, x, y, r);
    this.arcTo(x, y, x + w, y, r);
    this.closePath();
    return this;
}

CanvasRenderingContext2D.prototype.roundRect2 = function (sx, sy, ex, ey, r) {
    var r2d = Math.PI / 180;
    if ((ex - sx) - (2 * r) < 0) {
        r = ((ex - sx) / 2);
    } //ensure that the radius isn't too large for x
    if ((ey - sy) - (2 * r) < 0) {
        r = ((ey - sy) / 2);
    } //ensure that the radius isn't too large for y
    this.beginPath();
    this.moveTo(sx + r, sy);
    this.lineTo(ex - r, sy);
    this.arc(ex - r, sy + r, r, r2d * 270, r2d * 360, false);
    this.lineTo(ex, ey - r);
    this.arc(ex - r, ey - r, r, r2d * 0, r2d * 90, false);
    this.lineTo(sx + r, ey);
    this.arc(sx + r, ey - r, r, r2d * 90, r2d * 180, false);
    this.lineTo(sx, sy + r);
    this.arc(sx + r, sy + r, r, r2d * 180, r2d * 270, false);
    this.closePath();
    return this;
}

function drawcard(i, color) {

    if (i) {

        ///cctx.globalAlpha = .7;

        ///cctx.shadowOffsetX = 6;
        ///cctx.shadowOffsetY = 6;
        ///cctx.shadowBlur = 15;
        ///cctx.shadowColor = "grey";
        var moved=0.
        if (i == cardsel) {

            switch (cardstyle) {
                case 1:
                    cctx.straightRect(cardx[i] + moved, cardy[i] + moved, sw, sh);
                    break;
                case 2:
                    cctx.singleRoundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);
                    break;
                case 3:
                    cctx.roundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);
                    break;
                default:

            }
            //cctx.singleRoundRect(cardx[i], cardy[i], sw, sh, cornerRadius);
            cctx.fillStyle = "#080808";
            cctx.fill();
            moved=4;
        }


        switch (cardstyle) {
            case 1:
                cctx.straightRect(cardx[i] + moved, cardy[i] + moved, sw, sh);
                break;
            case 2:
                cctx.singleRoundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);
                break;
            case 3:
                cctx.roundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);
                break;
            default:

        }

        //cctx.singleRoundRect(cardx[i] + moved, cardy[i] + moved, sw, sh, cornerRadius);

        //cctx.roundRect2(cardx[i], cardy[i], cardx[i] + sw, cardy[i] + sh, cornerRadius);

        //cctx.roundRect(cardx[i], cardy[i],   sw,  sh, cornerRadius);

        
        //cctx.straightRect(cardx[i], cardy[i], sw, sh);

        //cctx.fillStyle = "#F8F8F8";
        //cctx.fillStyle = "#EEEEEE";

        cctx.fillStyle=cardbackcolor
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


        wraptext(cctx, cardt[i], tmx + cardx[i] + moved, tmy * 1.5 + cardy[i] + moved, sw - 2 * tmx, 16);
     
    }

}

 

function wraptext(context, text, x, y, maxWidth, lineHeight) {
    var words = text.split(' ');
    var line = '';

    for (var n = 0; n < words.length; n++) {
        var testLine = line + words[n] + ' ';
        var metrics = context.measureText(testLine);
        var testWidth = metrics.width;
        if (testWidth > maxWidth) {
            context.fillText(line, x, y);
            line = words[n] + ' ';
            y += lineHeight;
        }
        else {
            line = testLine;
        }
    }
 
    context.fillText(line, x, y);
  
}



function sortNumber(a, b) {
    return a - b;
}

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}
function ltrim(stringToTrim) {
    return stringToTrim.replace(/^\s+/, "");
}
function rtrim(stringToTrim) {
    return stringToTrim.replace(/\s+$/, "");
}

 

function GetWidth() {
    var x = 0;
    if (self.innerHeight) {
        x = self.innerWidth;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        x = document.documentElement.clientWidth;
    }
    else if (document.body) {
        x = document.body.clientWidth;
    }
    return x;
}

function GetHeight() {
    var y = 0;
    if (self.innerHeight) {
        y = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        y = document.documentElement.clientHeight;
    }
    else if (document.body) {
        y = document.body.clientHeight;
    }
    return y;
}

loaded()
 


 
 