

// Button and SHIFT variables
var useHelpKeys = false; // HELP
var useHelpMenu = true;

var rotateangle = 0;
var clustern = 8;
var solutionDims = 2; // SOLUTION 1,2 or 3 D
var ShowParticipants = true;
var ShowParticipantsGroups = true;
var showTreeInMap = false;
var showItemsInMap = true;
var showClustersInMap = true;
var showClusterRatingInMap = true;
var showItemNumber = false;
var sheetNumber = 1;
var showMapTitle = false;
var clusterType = 1;
var showRawDistancesInMap = false;
var rawDataN = 0;

var doTwice = false;

var buttonFalseColor = 'LightGrey';
var buttonTrueColor = 'Grey';

;

//var renderer;

function createbuttons() {

    buttonHelp = document.createElement("button");

    buttonSaveImagePNG = document.createElement("button");
    buttonSaveImageBMP = document.createElement("button");

    buttonChangeRateType1 = document.createElement("button");
    buttonChangeRateType2 = document.createElement("button");
    buttonChangeRateType3 = document.createElement("button");
    buttonChangeRateType4 = document.createElement("button");
    buttonChangeRateType5 = document.createElement("button");
    buttonTitle = document.createElement("button");

    buttonRate = document.createElement("button");
    buttonMatrix = document.createElement("button");
    buttonTree = document.createElement("button");
    buttonMap = document.createElement("button");
    buttonCloud = document.createElement("button");
    button1d = document.createElement("button");
    button2d = document.createElement("button");
    button3d = document.createElement("button");

    buttonShowItemNumbers = document.createElement("button");

    buttonShowPartDir = document.createElement("button");
    buttonShowGroupDir = document.createElement("button");
    buttonShowItems = document.createElement("button");
    buttonShowClusters = document.createElement("button");
    buttonShowClusterRating = document.createElement("button");
    buttonFormatClusters = document.createElement("button");
    buttonClustersUp = document.createElement("button");
    buttonClustersDown = document.createElement("button");
    buttonShowTree = document.createElement("button");
    buttonShowItems = document.createElement("button");

    buttonShowRawSort = document.createElement("button");
    buttonRawSortUp = document.createElement("button");
    buttonRawSortDown = document.createElement("button");

    buttonRotateRight = document.createElement("button");
    buttonRotateLeft = document.createElement("button");

    
    buttonMapFillstyle = document.createElement("input");
    buttonMapFontcolor = document.createElement("input");
    buttonImportanceColorLight = document.createElement("input");
    buttonImportanceColor = document.createElement("input");
    buttonItemDotColor = document.createElement("input");
    buttonTreeLineColor = document.createElement("input");
    buttonItemsAndNamesColor = document.createElement("input");
    buttonclustersAndDimensionsFontcolor = document.createElement("input");

    rbuttonMapFillstyle = document.createElement("button");
    rbuttonMapFontcolor = document.createElement("button");
    rbuttonImportanceColorLight = document.createElement("button");
    rbuttonImportanceColor = document.createElement("button");
    rbuttonItemDotColor = document.createElement("button");
    rbuttonTreeLineColor = document.createElement("button");
    rbuttonItemsAndNamesColor = document.createElement("button");
    rbuttonclustersAndDimensionsFontcolor = document.createElement("button");

    //  buttonRate = dv.appendChild(button1d);
    //  buttonTree = dv.appendChild(button2d);
    //  buttonMap = dv.appendChild(button3d);
    //  buttonCloud = dv.appendChild(button3d);
    //  button1d = dv.appendChild(button1d);
    //  button2d = dv.appendChild(button2d);
    //  button3d = dv.appendChild(button3d);


    stylebuttons(buttonHelp, '?', showHelpMenu);


    stylebuttons(buttonChangeRateType1, 'rate  type 1', changeRateType1);
    stylebuttons(buttonChangeRateType2, 'rate  type 2', changeRateType2);
    stylebuttons(buttonChangeRateType3, 'rate  type 3', changeRateType3);
    stylebuttons(buttonChangeRateType4, 'rate  type 4', changeRateType4);
    stylebuttons(buttonChangeRateType5, 'rate  type 5', changeRateType5);

    stylebuttons(buttonTitle, 'show title', showTitleInMap);


    stylebuttons(buttonRate, 'rate', showRateSheet);
    stylebuttons(buttonMatrix, 'rate matrix', showMatrixSheet);
    stylebuttons(buttonTree, 'tree', showTreeSheet);
    stylebuttons(buttonMap, 'map', showMapSheet);
    stylebuttons(buttonCloud, 'cloud', showCloudSheet);


    stylebuttons(button1d, "2D'", go1D);
    stylebuttons(button2d, '2D', go2D);
    stylebuttons(button3d, '3D', go3D);


    stylebuttons(buttonShowItems, 'show items', showItems);
    stylebuttons(buttonShowClusters, 'show clusters', showClusters);
    stylebuttons(buttonShowClusterRating, 'show rating', showClusterRating);

    stylebuttons(buttonFormatClusters, 'cluster format', clusterFormat);

    stylebuttons(buttonShowItemNumbers, 'item numbers', showItemNumbers);

    stylebuttons(buttonShowPartDir, 'participant directions', showPartDir);
    stylebuttons(buttonShowGroupDir, 'group directions', showGroupDir);

    stylebuttons(buttonClustersUp, 'more clusters', clustersUp);
    stylebuttons(buttonClustersDown, 'less clusters', clustersDown);
    stylebuttons(buttonShowTree, 'cluster tree', showTree);
    stylebuttons(buttonRotateRight, 'rotate right', rotateRight);
    stylebuttons(buttonRotateLeft, 'rotate left', rotateLeft);

    stylebuttons(buttonShowRawSort, 'raw sort data', showRawSort);
    stylebuttons(buttonRawSortUp, 'increase n (sort)', RawSortUp);
    stylebuttons(buttonRawSortDown, 'decrease n (sort)', RawSortDown);

    stylebuttons(buttonSaveImagePNG, 'save map as PNG', saveImagePNG);
    stylebuttons(buttonSaveImageBMP, 'save map as BMP', saveImageBMP);


    //styleCbuttons(buttonMapFillstyle, 'Importance Color', 5, 0, changeColor, "FFFEDB");
    //styleCbuttons(buttonMapFontcolor, 'Importance Color', 5, 0, changeColor, "6F4E37");
    //styleCbuttons(buttonImportanceColorLight, 'Importance Color', 5, 0, changeColor, "FF0000");
    //styleCbuttons(buttonImportanceColor, 'Importance Color', 5, 0, changeColor, "9F000F");
    //styleCbuttons(buttonItemDotColor, 'Importance Color', 5, 0, changeColor, "C85A17");
    //styleCbuttons(buttonTreeLineColor, 'Importance Color', 5, 0, changeColor, "347C2C");
    //styleCbuttons(buttonItemsAndNamesColor, 'Importance Color', 5, 0, changeColor, "4863A0");
    //styleCbuttons(buttonclustersAndDimensionsFontcolor, 'Importance Color', 5, 0, changeColor, "808000");

    styleCbuttons(buttonMapFillstyle, rbuttonMapFillstyle, 'back color', changeColor, "FFFEDB");
    styleCbuttons(buttonMapFontcolor, rbuttonMapFontcolor, 'font color', changeColor, "6F4E37");
    styleCbuttons(buttonImportanceColorLight, rbuttonImportanceColorLight, 'item importance color', changeColor, "FF0000");
    styleCbuttons(buttonImportanceColor, rbuttonImportanceColor, 'Importance color', changeColor, "9F000F");
    styleCbuttons(buttonItemDotColor, rbuttonItemDotColor, 'item dot color', changeColor, "C85A17");
    styleCbuttons(buttonTreeLineColor, rbuttonTreeLineColor, 'tree color', changeColor, "347C2C");
    styleCbuttons(buttonItemsAndNamesColor, rbuttonItemsAndNamesColor, 'overlay color', changeColor, "4863A0");
    styleCbuttons(buttonclustersAndDimensionsFontcolor, rbuttonclustersAndDimensionsFontcolor, 'cluster name color', changeColor, "808000");
}

//if (colorspectrum == 3) {
//    var mapFillstyle = '#FFFEDB';  
//    var mapFontcolor = '#6F4E37';  
//    var importanceColorLight = "#FF0000";
//    var importanceColor = "#9F000F";  
//    var itemDotColor = '#C85A17';
//    var treeLineColor = "#347C2C"; 
//    var itemsAndNamesColor = "#4863A0";
//    var clustersAndDimensionsFontcolor = '#808000'; 
//}



function hideBasicButtons() {

    buttonSaveImageBMP.style.visibility = 'hidden';
    buttonSaveImagePNG.style.visibility = 'hidden';

    buttonChangeRateType1.style.visibility = 'hidden';
    buttonChangeRateType2.style.visibility = 'hidden';
    buttonChangeRateType3.style.visibility = 'hidden';
    buttonChangeRateType4.style.visibility = 'hidden';
    buttonChangeRateType5.style.visibility = 'hidden';

    buttonTitle.style.visibility = 'hidden';

    buttonRate.style.visibility = 'hidden';
    buttonMatrix.style.visibility = 'hidden';
    buttonTree.style.visibility = 'hidden';
    buttonMap.style.visibility = 'hidden';
    buttonCloud.style.visibility = 'hidden';
}

function showBasicButtons() {

    buttonSaveImageBMP.style.visibility = 'hidden';
    buttonSaveImagePNG.style.visibility = 'hidden';

    //var browser = navigator.appCodeName;
    //if (browser == 'Mozilla') {
    //    buttonSaveImagePNG.style.visibility = 'visible';
    //}
   

    buttonChangeRateType1.style.visibility = 'visible';
    buttonChangeRateType2.style.visibility = 'visible';
    buttonChangeRateType3.style.visibility = 'visible';
    buttonChangeRateType4.style.visibility = 'visible';
    buttonChangeRateType5.style.visibility = 'visible';

    buttonTitle.style.visibility = 'visible';

    buttonRate.style.visibility = 'visible';
    buttonMatrix.style.visibility = 'visible';
    buttonTree.style.visibility = 'visible';
    buttonMap.style.visibility = 'visible';
    buttonCloud.style.visibility = 'visible';
}



function hideDimensionButtons() {
    button1d.style.visibility = 'hidden';
    button2d.style.visibility = 'hidden';
    button3d.style.visibility = 'hidden';
    hideMapButtons();
}

    function showDimensionButtons() {
        button1d.style.visibility = 'visible';
        button2d.style.visibility = 'visible';
        button3d.style.visibility = 'visible';


    }

    function showColorButtons() {
        buttonMapFillstyle.style.visibility = 'visible';
        buttonMapFontcolor.style.visibility = 'visible';
        buttonImportanceColorLight.style.visibility = 'visible';
        buttonImportanceColor.style.visibility = 'visible';
        buttonItemDotColor.style.visibility = 'visible';
        buttonTreeLineColor.style.visibility = 'visible';
        buttonItemsAndNamesColor.style.visibility = 'visible';
        buttonclustersAndDimensionsFontcolor.style.visibility = 'visible';
        rbuttonMapFillstyle.style.visibility = 'visible';
        rbuttonMapFontcolor.style.visibility = 'visible';
        rbuttonImportanceColorLight.style.visibility = 'visible';
        rbuttonImportanceColor.style.visibility = 'visible';
        rbuttonItemDotColor.style.visibility = 'visible';
        rbuttonTreeLineColor.style.visibility = 'visible';
        rbuttonItemsAndNamesColor.style.visibility = 'visible';
        rbuttonclustersAndDimensionsFontcolor.style.visibility = 'visible';
    }

    function hideColorButtons() {
        buttonMapFillstyle.style.visibility = 'hidden';
        buttonMapFontcolor.style.visibility = 'hidden';
        buttonImportanceColorLight.style.visibility = 'hidden';
        buttonImportanceColor.style.visibility = 'hidden';
        buttonItemDotColor.style.visibility = 'hidden';
        buttonTreeLineColor.style.visibility = 'hidden';
        buttonItemsAndNamesColor.style.visibility = 'hidden';
        buttonclustersAndDimensionsFontcolor.style.visibility = 'hidden';
        rbuttonMapFillstyle.style.visibility = 'hidden';
        rbuttonMapFontcolor.style.visibility = 'hidden';
        rbuttonImportanceColorLight.style.visibility = 'hidden';
        rbuttonImportanceColor.style.visibility = 'hidden';
        rbuttonItemDotColor.style.visibility = 'hidden';
        rbuttonTreeLineColor.style.visibility = 'hidden';
        rbuttonItemsAndNamesColor.style.visibility = 'hidden';
        rbuttonclustersAndDimensionsFontcolor.style.visibility = 'hidden';
    }

    function hideMapButtons() {
        buttonShowItems.style.visibility = 'hidden';
        buttonShowItemNumbers.style.visibility = 'hidden';
        buttonShowPartDir.style.visibility = 'hidden';
        buttonShowGroupDir.style.visibility = 'hidden';
        buttonShowClusters.style.visibility = 'hidden';
        buttonShowClusterRating.style.visibility = 'hidden';
        buttonFormatClusters.style.visibility = 'hidden';
        buttonClustersUp.style.visibility = 'hidden';
        buttonClustersDown.style.visibility = 'hidden';
        buttonShowTree.style.visibility = 'hidden';
        buttonRotateRight.style.visibility = 'hidden';
        buttonRotateLeft.style.visibility = 'hidden';
        hideMapExtraButtons();
    }
    function hideMapExtraButtons() {
        buttonShowRawSort.style.visibility = 'hidden';
        buttonRawSortUp.style.visibility = 'hidden';
        buttonRawSortDown.style.visibility = 'hidden';

    }

    function showMapButtons() {
        buttonShowItems.style.visibility = 'visible';
        buttonShowItemNumbers.style.visibility = 'visible';
        buttonShowPartDir.style.visibility = 'visible';
        buttonShowGroupDir.style.visibility = 'visible';
        buttonShowClusters.style.visibility = 'visible';
        buttonShowClusterRating.style.visibility = 'visible';
        buttonFormatClusters.style.visibility = 'visible';
        buttonClustersUp.style.visibility = 'visible';
        buttonClustersDown.style.visibility = 'visible';
        buttonShowTree.style.visibility = 'visible';
        buttonRotateRight.style.visibility = 'visible';
        buttonRotateLeft.style.visibility = 'visible';
    }
    function showMapExtraButtons() {
        buttonShowRawSort.style.visibility = 'visible';
        buttonRawSortUp.style.visibility = 'visible';
        buttonRawSortDown.style.visibility = 'visible';

    }
 
  

    function stylebuttons(bb, nn,  proc) {

         

        // bb = document.createElement("button");
        
            bb = dv.appendChild(bb);
            bb.innerText = nn;
            bb.style.fontSize = '9px';
            bb.className = 'conceptbuttons';

            bb.style.position = "absolute";
            bb.style.width = '0px';  //wwhh + 'px';
            bb.style.height = '0px'; // wwhh + 'px';
            bb.style.top = '0px';  // mmm + hh * (mm + wwhh) + 'px';
            bb.style.left = '0px'; // mmm + ll * (mm + wwhh) + 'px';
            //bb.style.borderStyle = "none";
            bb.style.backgroundColor = buttonTrueColor;
            bb.style.visibility = 'visible';
            bb.onclick = proc;
         
    }

    function styleCbuttons(bb,rbb, nn,  proc,color) {

         

        // bb = document.createElement("button");
        
        bb = dv.appendChild(bb);
        //bb.innerText = nn;
        bb.style.fontSize = '9px';
        bb.className = "color {pickerFaceColor:'transparent',pickerFace:3,pickerBorder:0,pickerInsetColor:'black'}"    ;
        bb.value=color ; //"66ff00"
        bb.style.position = "absolute";
        bb.style.width = '0px';  //wwhh + 'px';
        bb.style.height = '0px'; // wwhh + 'px';
        bb.style.top = '0px';  // mmm + hh * (mm + wwhh) + 'px';
        bb.style.left = '0px'; // mmm + ll * (mm + wwhh) + 'px';
        bb.style.textAlign="center"; 
        bb.style.borderStyle = "none";
        bb.style.backgroundColor = buttonTrueColor;
        bb.style.visibility = 'visible';
        bb.onchange = proc;

        rbb = dv.appendChild(rbb);
        rbb.innerText = nn;
        rbb.style.fontSize = '9px';
        rbb.className = "conceptbuttons";
        //bb.value = color; //"66ff00"
        rbb.style.position = "absolute";
        rbb.style.width = '0px';  //wwhh + 'px';
        rbb.style.height = '0px'; // wwhh + 'px';
        rbb.style.top = '0px';  // mmm + hh * (mm + wwhh) + 'px';
        rbb.style.left = '0px'; // mmm + ll * (mm + wwhh) + 'px';
        rbb.style.textAlign = "center";
        rbb.style.borderStyle = "none";
        rbb.style.backgroundColor = buttonTrueColor;
        rbb.style.visibility = 'visible';
         
    }

 
    function redrawbuttons(w4, h4, mapM4) {
              

        restylebuttons(buttonChangeRateType1, 0, 0);
        restylebuttons(buttonChangeRateType2, 0, 1);
        restylebuttons(buttonChangeRateType3, 0, 2);
        restylebuttons(buttonChangeRateType4, 0, 3);
        restylebuttons(buttonChangeRateType5, 0, 4);

        restylebuttons(buttonTitle, 0, 5);

        restylebuttons(buttonRate, 1, 0);
        restylebuttons(buttonMatrix, 1, 1);
        restylebuttons(buttonTree, 1, 2);
        restylebuttons(buttonMap, 1, 3);
        restylebuttons(buttonCloud, 1, 4);

        restylebuttons(button1d, 2, 0);
        restylebuttons(button2d, 2, 1);
        restylebuttons(button3d, 2, 2);


        restylebuttons(buttonShowItems, 3, 0);
        restylebuttons(buttonShowClusters, 3, 1);
        restylebuttons(buttonShowClusterRating, 3, 2);

        restylebuttons(buttonShowItemNumbers, 3, 3);
        restylebuttons(buttonFormatClusters, 3, 4);

        restylebuttons(buttonShowPartDir, 3, 5);
        restylebuttons(buttonShowGroupDir, 3,6 );

        restylebuttons(buttonClustersUp, 3, 7);
        restylebuttons(buttonClustersDown, 3, 8 );
        restylebuttons(buttonShowTree, 3, 9 );
        restylebuttons(buttonRotateRight, 3, 10 );
        restylebuttons(buttonRotateLeft, 3, 11 );



        restylebuttons(buttonShowRawSort, 4, 0 );
        restylebuttons(buttonRawSortUp, 4, 1 );
        restylebuttons(buttonRawSortDown, 4, 2 );

        restylebuttons(buttonSaveImagePNG, 5, 0 );
        restylebuttons(buttonSaveImageBMP, 5, 1);

       
        //restyleCbuttons(buttonMapFillstyle, 5, 0);
        //restyleCbuttons(buttonMapFontcolor, 5, 1);
       // restyleCbuttons(buttonImportanceColorLight, 5, 2);
        //restyleCbuttons(buttonImportanceColor, 5, 3);
        //restyleCbuttons(buttonItemDotColor, 5, 4);
        //restyleCbuttons(buttonTreeLineColor, 5, 5);
       // restyleCbuttons(buttonItemsAndNamesColor, 5, 6);
       // restyleCbuttons(buttonclustersAndDimensionsFontcolor, 5, 7);

        restyleCbuttons(buttonMapFillstyle, rbuttonMapFillstyle, 5, 0);
        restyleCbuttons(buttonMapFontcolor, rbuttonMapFontcolor, 5, 1);
        restyleCbuttons(buttonImportanceColorLight, rbuttonImportanceColorLight, 5, 2);
        restyleCbuttons(buttonImportanceColor, rbuttonImportanceColor, 5, 3);
        restyleCbuttons(buttonItemDotColor, rbuttonItemDotColor, 5, 4);
        restyleCbuttons(buttonTreeLineColor, rbuttonTreeLineColor, 5, 5);
        restyleCbuttons(buttonItemsAndNamesColor, rbuttonItemsAndNamesColor, 5, 6);
        restyleCbuttons(buttonclustersAndDimensionsFontcolor, rbuttonclustersAndDimensionsFontcolor, 5, 7);

        function restylebuttons(bb, hh, ll) {

            var wwhh = w4; if (h3 > w4) { wwhh = h3; }
            wwhh = wwhh / 13; 
            var mm = .1 * wwhh;
            wwhh = wwhh - mm;
        
            bb.style.width = wwhh + 'px';
            bb.style.height = wwhh + 'px';
            bb.style.top = mapM4 + hh * (mm + wwhh) + 'px';
            bb.style.left = mapM4 + ll * (mm + wwhh) + 'px';
 
        }

        function restyleCbuttons(bb, rbb, hh, ll) {

            var wwhh = w4; if (h3 > w4) { wwhh = h3; }
            wwhh = wwhh / 13;
            var mm = .1 * wwhh;
            wwhh = wwhh - mm;
 
            rbb.style.width = wwhh  + 'px';
            rbb.style.height = wwhh / 4 + 'px';
            rbb.style.top = mapM4 + hh * (mm + wwhh) + 'px';
            rbb.style.left = mapM4 + ll * (mm + wwhh ) + 'px';

            bb.style.width = wwhh-2  + 'px';
            bb.style.height = wwhh/6 + 'px';
            bb.style.top = mapM4 + hh * (mm + wwhh) + wwhh / 4 + 'px';
            bb.style.left = mapM4 + ll * (mm + wwhh ) + 'px';

            

        }

        var wwhh = w4; if (h3 > w4) { wwhh = h3; }
        wwhh = wwhh / 13;
        var mm = .1 * wwhh;
        buttonHelp.style.width = mapM4 - mm + 'px';
        buttonHelp.style.height = mapM4 - mm + 'px';
        buttonHelp.style.top = 0 + 'px';
        buttonHelp.style.left = 0 + 'px';

    }

   


    function convertCanvas(pCanvas, strType) {


    
        if (strType == "PNG")
            var oImg = Canvas2Image.saveAsPNG(pCanvas, true);
        if (strType == "BMP")
            var oImg = Canvas2Image.saveAsBMP(pCanvas, true);
        if (strType == "JPEG")
            var oImg = Canvas2Image.saveAsJPEG(pCanvas, true);

        if (!oImg) {
            alert("Sorry, this browser is not capable of saving " + strType + " files!");
            return false;
        }

        oImg.id = "canvasimage";

        oImg.style.border = oCanvas.style.border;
        document.body.replaceChild(oImg, oCanvas);

        showDownloadText();
    }

    function saveCanvas(pCanvas, strType) {


     
        //var data = cc.toDataURL("image/png").replace("image/png", "image/octet-stream");
        //window.location.href = data;

        var bRes = false;
        if (strType == "PNG")
            bRes = Canvas2Image.saveAsPNG(pCanvas);
        if (strType == "BMP")
            bRes = Canvas2Image.saveAsBMP(pCanvas);
        if (strType == "JPEG")
            bRes = Canvas2Image.saveAsJPEG(pCanvas);

        if (!bRes) {
            alert("Sorry, this browser is not capable of saving " + strType + " files!");
            return false;
        }
    }
 

    function showHelpMenu() {
        if (useHelpMenu == false) { useHelpMenu = true; } else { useHelpMenu = false; }
        showMenuManual();
    }

    function changeColor() {
        mapFillstyle = "#" + buttonMapFillstyle.value;
        mapFontcolor = "#" + buttonMapFontcolor.value;
        importanceColorLight = "#" + buttonImportanceColorLight.value;
        importanceColor = "#" + buttonImportanceColor.value
        itemDotColor = "#" + buttonItemDotColor.value;
        treeLineColor = "#" + buttonTreeLineColor.value;
        itemsAndNamesColor = "#" + buttonItemsAndNamesColor.value;
        clustersAndDimensionsFontcolor = "#" + buttonclustersAndDimensionsFontcolor.value;

        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }

    function saveImagePNG() {

        saveCanvas(cc, "PNG");
        //    saveCanvas(cc, "BMP");
        //   saveCanvas(cc, "JPEG");


        //   convertCanvas("PNG");
        //   convertCanvas("BMP");
        //   convertCanvas("JPEG");

    }

    function saveImageBMP() {

        //saveCanvas(cc, "PNG");
        saveCanvas(cc, "BMP");
        //   saveCanvas(cc, "JPEG");


        //   convertCanvas("PNG");
        //   convertCanvas("BMP");
        //   convertCanvas("JPEG");

    }

    function changeRateType1() {
        rateToUse = 1;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }

    

    function changeRateType2() {
        rateToUse = 2;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function changeRateType3() {
        rateToUse = 3;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function changeRateType4() {
        rateToUse = 4;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function changeRateType5() {
        rateToUse = 5;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }

    function showTitleInMap() {
        if (showMapTitle == false) { showMapTitle = true; } else { showMapTitle = false; }
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }

    function showRateSheet() {
        //hideDimensionButtons();
        //hideMapButtons();
        sheetNumber = 0;
        hideYellows();
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();

    }

    function showMatrixSheet() {
        //hideDimensionButtons();
        //hideMapButtons();
        sheetNumber = 1;
        hideYellows();
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();

    }
    function showTreeSheet() {
        //showDimensionButtons();
        //hideMapButtons();
        sheetNumber = 2;
        hideYellows();
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();
    }
    function showMapSheet() {
        //showDimensionButtons();
        //showMapButtons();
        sheetNumber = 3;
        hideYellows();
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();

    }
    function showCloudSheet() {
        //showDimensionButtons();
        //hideMapButtons();
        sheetNumber = 4;
        hideYellows();
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();
    }

    function go1D() {

 
        solutionDims = 1;

        if (solutionDims == 1) { groups = groups1; groupsn = groupsn1; groupsd = groupsd1; }
        if (solutionDims == 2) { groups = groups2; groupsn = groupsn2; groupsd = groupsd2; }
        if (solutionDims == 3) { groups = groups3; groupsn = groupsn3; groupsd = groupsd3; }

        hideYellows();
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();



    }

    function go2D() {

 
        solutionDims = 2;

        if (solutionDims == 1) { groups = groups1; groupsn = groupsn1; groupsd = groupsd1; }
        if (solutionDims == 2) { groups = groups2; groupsn = groupsn2; groupsd = groupsd2; }
        if (solutionDims == 3) { groups = groups3; groupsn = groupsn3; groupsd = groupsd3; }

        hideYellows();
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();



    }

    function go3D() {

   
        solutionDims = 3

        hideYellows();
        drawNow(true, sheetNumber, solutionDims);


    }

    function showItems() {
        if (showItemsInMap == false) { showItemsInMap = true; } else { showItemsInMap = false; }
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    } 


    function showClusters() {
        if (showClustersInMap == false) { showClustersInMap = true; } else { showClustersInMap = false; }
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }

    function showClusterRating() {
        if (showClusterRatingInMap == false) { showClusterRatingInMap = true; } else { showClusterRatingInMap = false; }
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }


    function clusterFormat() {
        if (clusterType < 3) { clusterType += 1; } else { clusterType = 1; }
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function clustersUp() {

        if (clustern < clustermaxn) clustern += 1;
   
        if (solutionDims == 3) {
            var obj;
            for (i = scene.children.length; i >= 4 ; i--) {
                obj = scene.children[i];
                scene.remove(obj);
            }
            drawitems();
            drawclusterlines();
            drawparticipants();
        }
        else {
            drawNow(false, sheetNumber, solutionDims);
            UploadPic();
        }

    }
    function clustersDown() {
        if (clustern > 2) clustern -= 1;

        if (solutionDims == 3) {
            var obj;
            for (i = scene.children.length; i >= 4 ; i--) {
                obj = scene.children[i];
                scene.remove(obj);
            }
            drawitems();
            drawclusterlines();
            drawparticipants();
        }
        else {
            hideYellows();
            drawNow(false, sheetNumber, solutionDims);
            UploadPic();
        }

    }
    function showTree() {
        if (showTreeInMap == false) { showTreeInMap = true; } else { showTreeInMap = false; }
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function showRawSort() {
        if (showRawDistancesInMap == false) showRawDistancesInMap = true; else showRawDistancesInMap = false;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function RawSortUp() {
        if (rawDataN < cardn) rawDataN += 1;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function RawSortDown() {
        if (rawDataN > 2) rawDataN -= 1;
        hideYellows();
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function showItemNumbers() {
        if (showItemNumber == true) { showItemNumber = false; } else { showItemNumber = true; };
        hideYellows();
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function showPartDir() {
        if (ShowParticipants == true) ShowParticipants = false; else ShowParticipants = true;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function showGroupDir() {
        if (ShowParticipantsGroups == true) ShowParticipantsGroups = false; else ShowParticipantsGroups = true;
        drawNow(false, sheetNumber, solutionDims);
        UploadPic();
    }
    function rotateRight() {
        rotateangle += .01;
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();
    }
    function rotateLeft() {
        rotateangle += -.01;
        drawNow(true, sheetNumber, solutionDims);
        UploadPic();

    }


    function showMenuManual() {

        if (useHelpMenu == true) {

            showBasicButtons();
            showColorButtons();

            if (showMapTitle == true) { buttonTitle.style.backgroundColor = buttonTrueColor; } else { buttonTitle.style.backgroundColor = buttonFalseColor; }

            buttonChangeRateType1.style.backgroundColor = buttonFalseColor;
            buttonChangeRateType2.style.backgroundColor = buttonFalseColor;
            buttonChangeRateType3.style.backgroundColor = buttonFalseColor;
            buttonChangeRateType4.style.backgroundColor = buttonFalseColor;
            buttonChangeRateType5.style.backgroundColor = buttonFalseColor;
            if (rateToUse == 1) { buttonChangeRateType1.style.backgroundColor = buttonTrueColor; }
            if (rateToUse == 2) { buttonChangeRateType2.style.backgroundColor = buttonTrueColor; }
            if (rateToUse == 3) { buttonChangeRateType3.style.backgroundColor = buttonTrueColor; }
            if (rateToUse == 4) { buttonChangeRateType4.style.backgroundColor = buttonTrueColor; }
            if (rateToUse == 5) { buttonChangeRateType5.style.backgroundColor = buttonTrueColor; }

            button1d.style.backgroundColor = buttonFalseColor;
            button2d.style.backgroundColor = buttonFalseColor;
            button3d.style.backgroundColor = buttonFalseColor;
            if (solutionDims == 1) { button1d.style.backgroundColor = buttonTrueColor; buttonCloud.style.visibility = 'hidden'; hideMapExtraButtons(); }
            if (solutionDims == 2) { button2d.style.backgroundColor = buttonTrueColor; buttonCloud.style.visibility = 'visble'; showMapExtraButtons(); }
            if (solutionDims == 3) { button3d.style.backgroundColor = buttonTrueColor; buttonCloud.style.visibility = 'hidden'; hideMapExtraButtons() }


            buttonRate.style.backgroundColor = buttonFalseColor;
            buttonMatrix.style.backgroundColor = buttonFalseColor;
            buttonTree.style.backgroundColor = buttonFalseColor;
            buttonMap.style.backgroundColor = buttonFalseColor;
            buttonCloud.style.backgroundColor = buttonFalseColor;

            if (sheetNumber == 0) { buttonRate.style.backgroundColor = buttonTrueColor; }
            if (sheetNumber == 1) buttonMatrix.style.backgroundColor = buttonTrueColor;
            if (sheetNumber == 2) buttonTree.style.backgroundColor = buttonTrueColor;
            if (sheetNumber == 3) buttonMap.style.backgroundColor = buttonTrueColor;
            if (sheetNumber == 4) buttonCloud.style.backgroundColor = buttonTrueColor;

            if (sheetNumber == 0) {

                hideDimensionButtons();
                hideMapButtons();
            }
            if (sheetNumber == 1) {
                hideDimensionButtons();
                hideMapButtons();
            }
            if (sheetNumber == 2) {
                showDimensionButtons();
                hideMapButtons();
            }

            if (sheetNumber == 3) {
                if (solutionDims == 3) {
                    showDimensionButtons();
                    hideMapButtons();
                    buttonClustersUp.style.visibility = 'visible';
                    buttonClustersDown.style.visibility = 'visible';
                }
                else {
                    showDimensionButtons();
                    showMapButtons();
                }
            }

            if (sheetNumber == 4) {
            
                hideDimensionButtons();
                hideMapButtons();
                hideMapExtraButtons();
        
            }

            if (showItemNumber == true) { buttonShowItemNumbers.style.backgroundColor = buttonTrueColor; } else { buttonShowItemNumbers.style.backgroundColor = buttonFalseColor; }
            if (ShowParticipants == true) { buttonShowPartDir.style.backgroundColor = buttonTrueColor; } else { buttonShowPartDir.style.backgroundColor = buttonFalseColor; }
            if (ShowParticipantsGroups == true) { buttonShowGroupDir.style.backgroundColor = buttonTrueColor; } else { buttonShowGroupDir.style.backgroundColor = buttonFalseColor; }
            if (showItemsInMap == true) { buttonShowItems.style.backgroundColor = buttonTrueColor; } else { buttonShowItems.style.backgroundColor = buttonFalseColor; }
            if (showClusterRatingInMap == true) { buttonShowClusterRating.style.backgroundColor = buttonTrueColor; } else { buttonShowClusterRating.style.backgroundColor = buttonFalseColor; }
            if (showClustersInMap == true) {
                buttonShowClusters.style.backgroundColor = buttonTrueColor;
                buttonClustersUp.style.backgroundColor = buttonTrueColor;
                buttonClustersDown.style.backgroundColor = buttonTrueColor;
            } else {
                buttonShowClusters.style.backgroundColor = buttonFalseColor;
                buttonClustersUp.style.backgroundColor = buttonFalseColor;
                buttonClustersDown.style.backgroundColor = buttonFalseColor;
            }

            if (showTreeInMap == true) { buttonShowTree.style.backgroundColor = buttonTrueColor; } else { buttonShowTree.style.backgroundColor = buttonFalseColor; }
            if (showRawDistancesInMap == true) {
                buttonShowRawSort.style.backgroundColor = buttonTrueColor;
                buttonRawSortUp.style.backgroundColor = buttonTrueColor;
                buttonRawSortDown.style.backgroundColor = buttonTrueColor;
            } else {
                buttonShowRawSort.style.backgroundColor = buttonFalseColor;
                buttonRawSortUp.style.backgroundColor = buttonFalseColor;
                buttonRawSortDown.style.backgroundColor = buttonFalseColor;
            }

        }
        else {
            hideBasicButtons();
            hideDimensionButtons();
            hideMapButtons();
            hideMapExtraButtons();
            hideColorButtons();
        }
    }



    function showKeyManual(context) {


        if (usehelpKeys == true) {

            cctx.textAlign = "left";
            cctx.textBaseline = "top"
            cctx.font = '20pt Calibri';

            var www = 400;
            var hhh = 575;
            var mmm = 25;
            var xxx = (GetWidth() - www) / 2;
            var xxx2 = 110 + (GetWidth() - www) / 2;
            var yyy = (GetHeight() - hhh) / 2;


            //cctx.strokeStyle = buttonFalseColor;
            //cctx.lineWidth = 3;
            cctx.fillStyle = "darkblue";
            cctx.globalAlpha = .8;

            cctx.beginPath();
            cctx.rect(xxx, yyy, www, hhh);
            cctx.fill();
            //cctx.stroke();

            cctx.globalAlpha = 1;



            cctx.fillStyle = "white";

            context.fillText("HELP MENU", xxx + mmm, yyy + mmm * 1);

            context.fillText("Shift-H:", xxx + mmm, yyy + mmm * 3);
            context.fillText("toggle help", xxx2 + mmm, yyy + mmm * 3);

            context.fillText("Shift-N:", xxx + mmm, yyy + mmm * 5);
            context.fillText("show item numbers", xxx2 + mmm, yyy + mmm * 5);

            context.fillText("Shift-E:", xxx + mmm, yyy + mmm * 6);
            context.fillText("1 or 2 dimensions", xxx2 + mmm, yyy + mmm * 6);

            context.fillText("Shift-B:", xxx + mmm, yyy + mmm * 7);
            context.fillText("screen >", xxx2 + mmm, yyy + mmm * 7);

            context.fillText("Shift-F:", xxx + mmm, yyy + mmm * 8);
            context.fillText("screen <", xxx2 + mmm, yyy + mmm * 8);

            context.fillText("Shift-P:", xxx + mmm, yyy + mmm * 9);
            context.fillText("participants directions", xxx2 + mmm, yyy + mmm * 9);

            context.fillText("Shift-G:", xxx + mmm, yyy + mmm * 10);
            context.fillText("group directions", xxx2 + mmm, yyy + mmm * 10);

            context.fillText("Shift-I:", xxx + mmm, yyy + mmm * 11);
            context.fillText("change rate type", xxx2 + mmm, yyy + mmm * 11);


            context.fillText("Shift-U:", xxx + mmm, yyy + mmm * 12);
            context.fillText("more clusters", xxx2 + mmm, yyy + mmm * 12);

            context.fillText("Shift-D:", xxx + mmm, yyy + mmm * 13);
            context.fillText("less clusters", xxx2 + mmm, yyy + mmm * 13);

            context.fillText("Shift-R:", xxx + mmm, yyy + mmm * 14);
            context.fillText("rotate right", xxx2 + mmm, yyy + mmm * 14);

            context.fillText("Shift-L:", xxx + mmm, yyy + mmm * 15);
            context.fillText("rotate left", xxx2 + mmm, yyy + mmm * 15);

            context.fillText("Shift-C:", xxx + mmm, yyy + mmm * 16);
            context.fillText("show clusters in map", xxx2 + mmm, yyy + mmm * 16);

            context.fillText("Shift-T:", xxx + mmm, yyy + mmm * 17);
            context.fillText("show tree in map", xxx2 + mmm, yyy + mmm * 17);

            context.fillText("Shift-A:", xxx + mmm, yyy + mmm * 18);
            context.fillText("show raw sort data", xxx2 + mmm, yyy + mmm * 18)

            context.fillText("Shift-X:", xxx + mmm, yyy + mmm * 19);
            context.fillText("bigger N (raw sort)", xxx2 + mmm, yyy + mmm * 19)

            context.fillText("Shift-Z:", xxx + mmm, yyy + mmm * 20);
            context.fillText("smaller N (raw sort)", xxx2 + mmm, yyy + mmm * 20)



        }
    }


    function keyup(event) {
    }

    function keydown(event) {

        if (event != "undifined") {

            if (doTwice == false) { doTwice = true; } else { doTwice = false; }

            if (doTwice == false) {
                if (event.shiftKey && event.keyCode === 72) {  // H: SHOW MANUAL
                    if (useHelpMenu == false) { useHelpMenu = true; } else { useHelpMenu = false; }
                    showMenuManual();
                    //drawNow(false, sheetNumber, solutionDims);
                }
                if (solutionDims < 3) {

                    if (event.shiftKey && event.keyCode === 69) {   /// E: 1,2 or 3 DIMS IN MAP
                        if (solutionDims < 2) { solutionDims += 1; } else { solutionDims = 1; };

                        if (solutionDims == 1) { groups = groups1; groupsn = groupsn1; groupsd = groupsd1; }
                        if (solutionDims == 2) { groups = groups2; groupsn = groupsn2; groupsd = groupsd2; }
                        if (solutionDims == 3) { groups = groups3; groupsn = groupsn3; groupsd = groupsd3; }

                        hideYellows();
                        drawNow(true, 1, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 78) {   /// N: SHOW NUMBERS
                        if (showItemNumber == true) { showItemNumber = false; } else { showItemNumber = true; };
                        hideYellows();
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 70) {   /// F: forward MAP TYPE
                        if (solutionDims == 1) {
                            if (sheetNumber < 2) { sheetNumber += 1 } else { sheetNumber = 0 };
                        }
                        if (solutionDims == 2) {
                            if (sheetNumber < 3) { sheetNumber += 1 } else { sheetNumber = 0 };
                        }
                        hideYellows();
                        drawNow(true, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 66) {   /// B: back MAP TYPE
                        if (solutionDims == 2) {
                            if (sheetNumber > 0) { sheetNumber -= 1 } //else { sheetNumber = 2 };
                        }
                        if (solutionDims == 2) {
                            if (sheetNumber > 0) { sheetNumber -= 1 } //else { sheetNumber = 2 };
                        }
                        hideYellows();
                        drawNow(true, sheetNumber, solutionDims);
                    }

                    if (event.shiftKey && event.keyCode === 82) {  // R: ROTATE RIGHT
                        rotateangle += .01;
                        drawNow(true, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 76) {  // L: ROTATE LEFT
                        rotateangle += -.01;
                        drawNow(true, sheetNumber, solutionDims);
                    }

                    if (event.shiftKey && event.keyCode === 73) {  // I: SHOW OTHER RATING
                        if (rateToUse > 4) { rateToUse = 1; } else { rateToUse += 1; }
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 73) {  // I: SHOW HELP
                        if (helpToUse == false) { helpToUse = true; } else { helpToUse = false; }
                        drawNow(false, sheetNumber, solutionDims);
                    }

                    if (event.shiftKey && event.keyCode === 68) {  // D: CLUSTER DOWN
                        if (clustern > 2) clustern -= 1;
                        hideYellows();
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 85) {  // U: CLUSTER UP

                        if (clustern < clustermaxn) clustern += 1;
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 67) {  // C: SHOW TREE IN MAP
                        if (showClustersInMap == false) { showClustersInMap = true; } else { showClustersInMap = false; }
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 84) {  // T: SHOW TREE IN MAP
                        if (showTreeInMap == false) { showTreeInMap = true; } else { showTreeInMap = false; }
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 80) {  // P: SHOW PARTICIPANTS  
                        if (ShowParticipants == true) ShowParticipants = false; else ShowParticipants = true;
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 71) {  // G: SHOW PARTICIPANTS GROUPS
                        if (ShowParticipantsGroups == true) ShowParticipantsGroups = false; else ShowParticipantsGroups = true;
                        drawNow(false, sheetNumber, solutionDims);
                    }

                    if (event.shiftKey && event.keyCode === 83) {  // S: show SQUARE or ROUND cluster
                        if (worldType == 1) worldType = 2; else worldType = 1;
                        drawNow(false, sheetNumber, solutionDims);
                    }

                    if (event.shiftKey && event.keyCode === 65) {  // D: Show Raw Distances
                        if (showRawDistancesInMap == false) showRawDistancesInMap = true; else showRawDistancesInMap = false;
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 90) {  // Z: RAW DATA DOWN
                        if (rawDataN > 2) rawDataN -= 1;
                        hideYellows();
                        drawNow(false, sheetNumber, solutionDims);
                    }
                    if (event.shiftKey && event.keyCode === 88) {  // X: RAW DATA  UP

                        if (rawDataN < cardn) rawDataN += 1;
                        drawNow(false, sheetNumber, solutionDims);
                    }
                }
                if (solutionDims == 3) {
                    //3D map only

                    if (event.shiftKey && event.keyCode === 85) {    // D : CLLUSTER DOWN
                    
                        var obj;
                        for (i = scene.children.length; i >= 4 ; i--) {
                            obj = scene.children[i];
                            scene.remove(obj);
                        }

                        clustern += 1;
                        drawitems();
                        drawclusterlines();
                        drawparticipants();

                    }
                    if (event.shiftKey && event.keyCode === 68) { //  U : CLLUSTER UP
                     
                        var obj; 
                        for (i = scene.children.length; i >= 4 ; i--) {
                            obj = scene.children[i];
                            scene.remove(obj);
                        }
                        clustern -= 1;
                        drawitems();
                        drawclusterlines();
                        drawparticipants();
                    }


                    if (event.shiftKey && event.keyCode === 77) {  // M : MAP TYPE

                        var obj;
                        for (i = scene.children.length; i >= 3 ; i--) {
                            obj = scene.children[i];
                            scene.remove(obj);
                        }
                        if (worldtype == 1) worldtype = 2; else worldtype = 1;
                        translatecoordinates3dWorld(worldtype);
                        drawworld3d(worldtype);
                        drawitems();
                        drawclusterlines();
                        drawparticipants();


                    }
                }
            }
        }
    }