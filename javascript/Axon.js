// COPYRIGHT TALCOTT bv THE NETHERLANDS

/// in html
///<meta name="viewport" content="width=device-width, maximum-scale=1.0" /> : width of the device
///<meta name="viewport" content="width=width, maximum-scale=1.0" /> : width of the availeble screen


//RESULT

var rfile = "";
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
var myVar = setInterval(function () { myTimer() }, 2000);
//var timer2 = $.timer(myTimer(), 10000);
//timer2.set({ time: 2000, autostart: true });

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

    cc = document.getElementById('ResultCanvas');
    //cc.style.visibility = 'hidden';
    cctx = cc.getContext("2d");


    cctx.textAlign = 'left';
    cctx.textBaseline = "top";




    rslt = document.getElementById('fileResultText');
    rfile = rslt.innerText;

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

 
        document.onmousedown = cardselect;
        document.onmousemove = cardmove;
        document.onmouseup = carddeselect;
 
    }

    

   

   

    //var timer = $.timer(function () {
    //    //alert('This message was sent by a timer.');
    //    myTimer()
    //});

   
   
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
    cc.height = h3/5;
    cc.style.top = '0px';
    cc.style.left = '0px';

 
 
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

    
}



function cardmove(e) {

   
}

 

function createCanvas() {


    ccc.style.position = "absolute";
    ccc.width = 300; //GetWidth();
    ccc.height = 300; //GetHeight();

    ccc.style.visibility = "hidden";
    ccctx.fillStyle = "transparent";
    // ccctx.fillRect(0, 0, 200, 200);
}



function myTimer() {
    var d = new Date();
    // makeCall2(rslt.innerText);
    makeCall2(rfile);
    // document.getElementById("demo").innerHTML = d.toLocaleTimeString();
}


function makeCall2(rfile) {

  //  
    if (rfile !="") {
        var obj = {};
        obj.file = rslt.innerText;
        //obj.rateData = document.getElementById("rateType").value + document.getElementById("TextBoxProject").value + document.getElementById("TextBoxParticipant").value + document.getElementById("rateData").value;

        $.ajax({

            type: "POST",

            url: "Axon.aspx/showResult",

            data: JSON.stringify(obj),

            contentType: "application/json; charset=utf-8",

            dataType: "json",

            success: function (r) {
                cctx.clearRect(0, 0, cc.width, cc.height);
                cctx.fillStyle = "black";
                wraptext(cctx, r.d, 20, 20, 300, 16);
                // alert(r.d); //give back result
            },
            error: function (msg) {
                alert('failure to update status: ' + msg);
            }

        });
    }

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




