

function loaded() {


    cc = document.getElementById('MapCanvas');
    cctx = cc.getContext("2d");

    //TEST CANVAS
    ccTest = document.createElement('canvas')
    document.body.appendChild(ccTest);
    ccTest.style.visibility = "hidden"
    ccTest.width = 0; //GetWidth();
    ccTest.height = 0; //GetHeight();
    cctxTest = ccTest.getContext("2d");


    //cctx.font = '9pt Calibri';
    //cctx.textAlign = 'left';
    //cctx.textBaseline = "top";


    dv = document.getElementById('body1');


    db = document.getElementById('datablock');
    db.style.visibility = 'hidden';
    //db.clientHeight = '0px';
    db.style.position = "absolute";
    db.width = '0px';
    db.height = '0px';

    


    readdataall();

    //saveUserClusterNamesFromVar();

    createyellows();
    createyellows2();

   
    getUserClusterNames();
    getUserDimensionNames()
    getClusterNamesFromTree(clustern);

    createbuttons();


    onkeydown = keydown;
    onkeyup = keyup;
    window.onresize = reload;
    reload();

}


function reload() {


    drawNow(true, sheetNumber, solutionDims);

}

loaded();