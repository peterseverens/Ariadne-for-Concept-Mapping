
//COPYRIGHT TALCOTT bv THE NETHERLANDS

// DATA BLOCKS



dpn = document.getElementById('projectName');
dpns = document.getElementById('subtitletext');

activesel = document.getElementById('activeselectiontext');
MapCN = document.getElementById('MapClusterNames');
MapDN = document.getElementById('MapDimensionNames');


dft = document.getElementById('itemData');
dfe = document.getElementById('coordinateData');
dfc3 = document.getElementById('clusterData3');
dfc2 = document.getElementById('clusterData2');
dfc1 = document.getElementById('clusterData1');

dfcd3 = document.getElementById('clusterDataD3');
dfcd2 = document.getElementById('clusterDataD2');
dfcd1 = document.getElementById('clusterDataD1');

dfr1 = document.getElementById('rates1');
dfr2 = document.getElementById('rates2');
dfr3 = document.getElementById('rates3');
dfr4 = document.getElementById('rates4');
dfr5 = document.getElementById('rates5');

dfrc11 = document.getElementById('clusterRates1');
dfrc12 = document.getElementById('clusterRates2');
dfrc13 = document.getElementById('clusterRates3');
dfrc21 = document.getElementById('clusterRates21');
dfrc22 = document.getElementById('clusterRates22');
dfrc23 = document.getElementById('clusterRates23');
dfrc31 = document.getElementById('clusterRates31');
dfrc32 = document.getElementById('clusterRates32');
dfrc33 = document.getElementById('clusterRates33');
dfrc41 = document.getElementById('clusterRates41');
dfrc42 = document.getElementById('clusterRates42');
dfrc43 = document.getElementById('clusterRates43');
dfrc51 = document.getElementById('clusterRates51');
dfrc52 = document.getElementById('clusterRates52');
dfrc53 = document.getElementById('clusterRates53');

dfpdr1 = document.getElementById('participantDimensions');
dfpdr2 = document.getElementById('participantDimensions2');
dfpdr3 = document.getElementById('participantDimensions3');
dfpdr4 = document.getElementById('participantDimensions4');
dfpdr5 = document.getElementById('participantDimensions5');

dfpdrg1 = document.getElementById('participantGroupsDimensions');
dfpdrg2 = document.getElementById('participantGroupsDimensions2');
dfpdrg3 = document.getElementById('participantGroupsDimensions3');
dfpdrg4 = document.getElementById('participantGroupsDimensions4');
dfpdrg5 = document.getElementById('participantGroupsDimensions5');

dfpdrgn = document.getElementById('participantGroupsNames');
dfpn = document.getElementById('participantNames');
dfcdr = document.getElementById('clusterNamesCoord');

dfrsd = document.getElementById('rawSortData');

rv1 = document.getElementById('ratedef1');
rv2 = document.getElementById('ratedef2');
rv3 = document.getElementById('ratedef3');
rv4 = document.getElementById('ratedef4');
rv5 = document.getElementById('ratedef5');




// GENERAL DATA

var projectName = dpn.value.trim();
var projectSubTitle = dpns.value.trim();

var itemmaxn = 200;
var clustermaxn = 18;
var participantmaxn = 999;
var participantGroupMaxN = 100;

var dimensionn = 3;
var cardn = 0;
var participantn = 0;
var participantgroupn = 0;

var maxtextlength = 100;
var groupsn3 = new Array(clustermaxn);
var groups3 = new Array(clustermaxn);
var groupsd3 = new Array(clustermaxn);
var groupsn2 = new Array(clustermaxn);
var groups2 = new Array(clustermaxn);
var groupsd2 = new Array(clustermaxn);
var groupsn1 = new Array(clustermaxn);
var groups1 = new Array(clustermaxn);
var groupsd1 = new Array(clustermaxn);
for (var n = 1; n < clustermaxn + 1; n++) {
    groupsn3[n] = new Array(itemmaxn.value);
    groups3[n] = new Array(itemmaxn.value);
    groupsd3[n] = new Array(5);
    groupsn2[n] = new Array(itemmaxn.value);
    groups2[n] = new Array(itemmaxn.value);
    groupsd2[n] = new Array(5);
    groupsn1[n] = new Array(itemmaxn.value);
    groups1[n] = new Array(itemmaxn.value);
    groupsd1[n] = new Array(5);
    for (var nn = 1; nn < clustermaxn + 1; nn++) {
        groups3[n][nn] = new Array(clustermaxn.value);
        groups2[n][nn] = new Array(clustermaxn.value);
        groups1[n][nn] = new Array(clustermaxn.value);
    }
}
var clusterr1 = new Array(clustermaxn);
var clusterr2 = new Array(clustermaxn);
var clusterr3 = new Array(clustermaxn);
 
for (var n = 1; n < clustermaxn + 1; n++) {
    clusterr1[n] = new Array(itemmaxn);
    for (var nn = 1; nn < itemmaxn; nn++) {
        clusterr1[n][nn] = new Array(6);
    }
    clusterr2[n] = new Array(itemmaxn);
    for (var nn = 1; nn < itemmaxn; nn++) {
        clusterr2[n][nn] = new Array(6);
    }
    clusterr3[n] = new Array(itemmaxn);
    for (var nn = 1; nn < itemmaxn; nn++) {
        clusterr3[n][nn] = new Array(6);
    }
     
}


var participantdr = new Array(participantmaxn);
for (var n = 1; n < participantmaxn + 1; n++) {
    participantdr[n] = new Array(dimensionn + 1);
    for (var nn = 1; nn < dimensionn + 1; nn++) {
        participantdr[n][nn] = new Array(6);
    }
}
var participantdrg = new Array(participantGroupMaxN);
for (var n = 1; n < participantGroupMaxN + 1; n++) {
    participantdrg[n] = new Array(dimensionn + 1);
    for (var nn = 1; nn < dimensionn + 1; nn++) {
        participantdrg[n][nn] = new Array(6);
    }
}
var participantdrgn = new Array(participantGroupMaxN);

var clusternames = new Array(999);
var clusternamesdr = new Array(999);
for (var r = 1; r < 999 + 1; r++) {
    clusternamesdr[r] = new Array(dimensionn.value);
}

groups3[1][1][1] = 1;
groupsn3[1][1] = 1;
groupsn3[1][2] = 1;
groupsn3[2][1] = 1;

var partnames = new Array(participantmaxn.value);
var cardt = new Array(itemmaxn.value);

var eigen = new Array(itemmaxn.value);

var itemx = new Array(itemmaxn.value);
var itemy = new Array(itemmaxn.value);
var itemz = new Array(itemmaxn.value);

var partx = new Array(participantmaxn.value);
var party = new Array(participantmaxn.value);

var partgx = new Array(participantmaxn.value);
var partgy = new Array(participantmaxn.value);

var cnamex = new Array(participantmaxn.value);
var cnamey = new Array(participantmaxn.value);

var itemrating = new Array(itemmaxn.value);
var itemratingn = new Array(itemmaxn.value);
for (var n = 1; n < itemmaxn ; n++) {
    itemrating[n] = new Array(7);
    itemratingn[n] = new Array(7);
}

var sortdataraw = new Array(itemmaxn);
for (var n = 1; n < itemmaxn + 1; n++) {
    sortdataraw[n] = new Array(itemmaxn + 1);    
}

var ratedefinition = new Array(7);
for (var n = 0; n < 8; n++) {
    ratedefinition[n] = new Array(7);
}
 

//DATA FIELDS
var dft, dfe,  dfc3, dfc2, dfr, dfrc, dfpdr, dfpn;

//CLUSTER NAMES OF HIERARCHIE;

var yellowth = new Array(clustermaxn + 5);
for (var r = 1; r < clustermaxn + 1; r++) {
    yellowth[r] = new Array(3);
}

//DIMESION NAMES

var yellowt = new Array(clustermaxn + 5);




function readdataall() {

    //FILL CLUSTER AND DIMENSION NAMES IF NEEDED

    if (MapCN.value == "") {
        for (var g = 1; g < clustermaxn + 1; g++) {
            for (var r = 1; r < 2 + 1; r++) {
                yellowth[g][r] = g + '-' + r;
            }
        }
        var names = ""
        for (var g = 0; g < clustermaxn ; g++) {

            names += fixedLength(yellowth[g + 1][1], 90) + fixedLength(yellowth[g + 1][2], 90);
        }
        MapCN.value = names;
       
    }


    if (MapDN.value == "") {
        yellowt[clustermaxn + 1] = "Horizental Dimension Left";
        yellowt[clustermaxn + 2] = "Horizental Dimension right";
        yellowt[clustermaxn + 3] = "Vertical Dimension top";
        yellowt[clustermaxn + 4] = "Vertical Dimension bottom";
        var names = ""
        names += fixedLength(yellowt[clustermaxn + 1], 90);
        names += fixedLength(yellowt[clustermaxn + 2], 90);
        names += fixedLength(yellowt[clustermaxn + 3], 90);
        names += fixedLength(yellowt[clustermaxn + 4], 90);
        MapDN.value = names;
    }

    //ITEMS
    if (dft) {
        cardn = parseInt(dft.value.substr(0, 3));
        for (var i = 0; i < cardn; i++) {

            cardt[i + 1] = trim(dft.value.substr(3 + i * maxtextlength, maxtextlength));
        }
    }

    //PARTICIPANTS 
    if (dfpn) {
        participantn = parseInt(dfpn.value.substr(0, 3));
        for (i = 0; i < participantn; i++) {

            partnames[i + 1] = trim(dfpn.value.substr(3 + i * maxtextlength, maxtextlength));
        }
    }

    //ITEM COORDINATES
    if (dfe) {
        var pos = 0;
        for (var d = 0; d < dimensionn; d++) {

            eigen[d + 1] = parseFloat(dfe.value.substr(pos, 10));
            pos += 10;
            for (i = 0; i < cardn; i++) {

                itemz[i + 1] = 0;
                if (d == 0) itemx[i + 1] = parseFloat(dfe.value.substr(pos, 10));
                if (d == 1) itemy[i + 1] = parseFloat(dfe.value.substr(pos, 10));
                if (d == 2) itemz[i + 1] = parseFloat(dfe.value.substr(pos, 10));
                pos += 10;
            }
        }
    }


    //CLUSTER
    if (dfc3) {
        var pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {

            //var g = 8;

            for (c = 1; c < g + 1; c++) {
                groupsn3[g][c] = parseInt(dfc3.value.substr(pos, 3));
                pos += 3;
            }

            for (c = 1; c < g + 1; c++) {


                for (var i = 1; i < groupsn3[g][c] + 1; i++) {

                    groups3[g][c][i] = parseInt(dfc3.value.substr(pos, 3));
                    pos += 3;
                }
            }
        }
    }
    if (dfc2) {
        var pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {

            //var g = 8;

            for (c = 1; c < g + 1; c++) {
                groupsn2[g][c] = parseInt(dfc2.value.substr(pos, 3));
                pos += 3;
            }

            for (c = 1; c < g + 1; c++) {


                for (i = 1; i < groupsn2[g][c] + 1; i++) {

                    groups2[g][c][i] = parseInt(dfc2.value.substr(pos, 3));
                    pos += 3;
                }
            }
        }
    }
    if (dfc1) {
        var pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {

            //var g = 8;

            for (c = 1; c < g + 1; c++) {
                groupsn1[g][c] = parseInt(dfc1.value.substr(pos, 3));
                pos += 3;
            }

            for (c = 1; c < g + 1; c++) {


                for (i = 1; i < groupsn1[g][c] + 1; i++) {

                    groups1[g][c][i] = parseInt(dfc1.value.substr(pos, 3));
                    pos += 3;
                }
            }
        }
    }
    //CLUSTER DEVISIONS
    if (dfcd3) {
        var pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {
             //for (c = 1; c < g + 1; c++) {
                groupsd3[g][1] = parseInt(dfcd3.value.substr(pos, 3));
                pos += 3;
                groupsd3[g][2] = parseInt(dfcd3.value.substr(pos, 3));
                pos += 3;
                groupsd3[g][3] = parseInt(dfcd3.value.substr(pos, 3));
                pos += 3;
                groupsd3[g][4] = parseInt(dfcd3.value.substr(pos, 3));
                pos += 3;
            //}          
        }
        pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {
            //for (c = 1; c < g + 1; c++) {
                groupsd2[g][1] = parseInt(dfcd2.value.substr(pos, 3));
                pos += 3;
                groupsd2[g][2] = parseInt(dfcd2.value.substr(pos, 3));
                pos += 3;
                groupsd2[g][3] = parseInt(dfcd2.value.substr(pos, 3));
                pos += 3;
                groupsd2[g][4] = parseInt(dfcd2.value.substr(pos, 3));
                pos += 3;
            //}
        }
        pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {
            //for (c = 1; c < g + 1; c++) {
                groupsd1[g][1] = parseInt(dfcd1.value.substr(pos, 3));
                pos += 3;
                groupsd1[g][2] = parseInt(dfcd1.value.substr(pos, 3));
                pos += 3;
                groupsd1[g][3] = parseInt(dfcd1.value.substr(pos, 3));
                pos += 3;
                groupsd1[g][4] = parseInt(dfcd1.value.substr(pos, 3));
                pos += 3;
           // }
        }
    }

    //rates per item
    if (dfr1) {
        var pos = 0;

        for (i = 1; i < cardn + 1; i++) {
            itemratingn[i][1] = parseFloat(dfr1.value.substr(pos, 3)); itemrating[i][1] = parseFloat(dfr1.value.substr(pos + 3, 4));
            itemratingn[i][2] = parseFloat(dfr2.value.substr(pos, 3)); itemrating[i][2] = parseFloat(dfr2.value.substr(pos + 3, 4));
            itemratingn[i][3] = parseFloat(dfr3.value.substr(pos, 3)); itemrating[i][3] = parseFloat(dfr3.value.substr(pos + 3, 4));
            itemratingn[i][4] = parseFloat(dfr4.value.substr(pos, 3)); itemrating[i][4] = parseFloat(dfr4.value.substr(pos + 3, 4));
            itemratingn[i][5] = parseFloat(dfr5.value.substr(pos, 3)); itemrating[i][5] = parseFloat(dfr5.value.substr(pos + 3, 4));
            pos += 7;
        }


    }
    //rates for all clusters per cluster solution
    if (dfrc11) {
        var pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {
            for (c = 1; c < g + 1; c++) {
                clusterr1[g][c][1] = parseFloat(dfrc11.value.substr(pos, 4));
                clusterr1[g][c][2] = parseFloat(dfrc21.value.substr(pos, 4));
                clusterr1[g][c][3] = parseFloat(dfrc31.value.substr(pos, 4));
                clusterr1[g][c][4] = parseFloat(dfrc41.value.substr(pos, 4));
                clusterr1[g][c][5] = parseFloat(dfrc51.value.substr(pos, 4));
                pos += 4;
            }
        }
    }
    
    if (dfrc21) {
        var pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {


            for (c = 1; c < g + 1; c++) {
                clusterr2[g][c][1] = parseFloat(dfrc12.value.substr(pos, 4));
                clusterr2[g][c][2] = parseFloat(dfrc22.value.substr(pos, 4));
                clusterr2[g][c][3] = parseFloat(dfrc32.value.substr(pos, 4));
                clusterr2[g][c][4] = parseFloat(dfrc42.value.substr(pos, 4));
                clusterr2[g][c][5] = parseFloat(dfrc52.value.substr(pos, 4));
                pos += 4;

            }
        }
    }
    if (dfrc31) {
        var pos = 0;
        for (g = 1; g < clustermaxn + 1; g++) {


            for (c = 1; c < g + 1; c++) {
                clusterr3[g][c][1] = parseFloat(dfrc13.value.substr(pos, 4));
                clusterr3[g][c][2] = parseFloat(dfrc23.value.substr(pos, 4));
                clusterr3[g][c][3] = parseFloat(dfrc33.value.substr(pos, 4));
                clusterr3[g][c][4] = parseFloat(dfrc43.value.substr(pos, 4));
                clusterr3[g][c][5] = parseFloat(dfrc53.value.substr(pos, 4));
                
                pos += 4;

            }
        }
    }
    //participants dimension rates
    if (dfpdr1) {
        var pos = 0;
        participantn = parseInt(dfpdr1.value.substr(0, 3));
        pos = 3;
        for (var p = 1; p < participantn + 1; p++) {
            for (d = 1; d < dimensionn + 1; d++) {

                participantdr[p][d][1] = parseFloat(dfpdr1.value.substr(pos, 10));
                participantdr[p][d][2] = parseFloat(dfpdr2.value.substr(pos, 10));
                participantdr[p][d][3] = parseFloat(dfpdr3.value.substr(pos, 10));
                participantdr[p][d][4] = parseFloat(dfpdr4.value.substr(pos, 10));
                participantdr[p][d][5] = parseFloat(dfpdr5.value.substr(pos, 10));
                pos += 10;

            }
        }
    }

    //participants group dimension rates
    if (dfpdrg1) {
        var pos = 0;
        participantgroupn = parseInt(dfpdrg1.value.substr(0, 3));
        pos = 3;
        for (var p = 1; p < participantgroupn + 1; p++) {
            for (d = 1; d < dimensionn + 1; d++) {

                participantdrg[p][d][1] = parseFloat(dfpdrg1.value.substr(pos, 10));
                participantdrg[p][d][2] = parseFloat(dfpdrg2.value.substr(pos, 10));
                participantdrg[p][d][3] = parseFloat(dfpdrg3.value.substr(pos, 10));
                participantdrg[p][d][4] = parseFloat(dfpdrg4.value.substr(pos, 10));
                participantdrg[p][d][5] = parseFloat(dfpdrg5.value.substr(pos, 10));
                pos += 10;

            }
        }
    }

    //participants group  names
    if (dfpdrgn) {
        var pos = 0;
        participantgroupn = parseInt(dfpdrgn.value.substr(0, 3));
        pos = 3;
        for (var p = 1; p < participantgroupn + 1; p++) {

            participantdrgn[p] =  dfpdrgn.value.substr(pos, 30);
            pos += 30;

         }
    }

    //clusternames & dimensions
    if (dfcdr) {
        var pos = 0;
        clusternamesn = parseInt(dfcdr.value.substr(0, 3));
        pos = 3;
        for (var r = 1; r < clusternamesn + 1; r++) {
            clusternames[r] = dfcdr.value.substr(pos, 90);
            pos += 100;
            for (d = 1; d < dimensionn + 1; d++) {
                clusternamesdr[r][d] = parseFloat(dfcdr.value.substr(pos, 10));
                pos += 10;

            }
        }
    }

    //raw sort matrix
    if (dfrsd) {
        var pos = -1;
        for (var i = 1; i < cardn+1; i++) {
            for (var ii = i; ii < cardn+1; ii++) {
                pos += 1;
                sortdataraw[i][ii] = dfrsd.value.substr(pos * 10, 10).trim();
            }
        }
    }

    //rate definition
        
    if (rv1.value.substr(0, 1) == "1") {
        ratedefinition[0][1] = rv1.value.substr(1, 2).trim();
        ratedefinition[1][1] = rv1.value.substr(3, 30).trim();
        if (ratedefinition[0][1].valueOf() > 0) ratedefinition[2][1] = rv1.value.substr(33, 30).trim();
        if (ratedefinition[0][1].valueOf() > 1) ratedefinition[3][1] = rv1.value.substr(63, 30).trim();
        if (ratedefinition[0][1].valueOf() > 2) ratedefinition[4][1] = rv1.value.substr(93, 30).trim();
        if (ratedefinition[0][1].valueOf() > 3) ratedefinition[5][1] = rv1.value.substr(123, 30).trim();
        if (ratedefinition[0][1].valueOf() > 4) ratedefinition[6][1] = rv1.value.substr(153, 30).trim();
    }
    else {
        ratedefinition[0][1] = 5
        ratedefinition[1][1] = "importance";
        ratedefinition[2][1] = "not important";
        ratedefinition[3][1] = "less important";
        ratedefinition[4][1] = "in between";
        ratedefinition[5][1] = "important";
        ratedefinition[6][1] = "very important";
    }
    if (rv2.value.substr(0, 1) == "1") {
        ratedefinition[0][2] = rv2.value.substr(1, 2).trim();
        ratedefinition[1][2] = rv2.value.substr(3, 30).trim();
        if (ratedefinition[0][2].valueOf() > 0) ratedefinition[2][2] = rv2.value.substr(33, 30).trim();
        if (ratedefinition[0][2].valueOf() > 1) ratedefinition[3][2] = rv2.value.substr(63, 30).trim();
        if (ratedefinition[0][2].valueOf() > 2) ratedefinition[4][2] = rv2.value.substr(93, 30).trim();
        if (ratedefinition[0][2].valueOf() > 3) ratedefinition[5][2] = rv2.value.substr(123, 30).trim();
        if (ratedefinition[0][2].valueOf() > 4) ratedefinition[6][2] = rv2.value.substr(153, 30).trim();
    }
    else { ratedefinition[0][2] = 0 }
    if (rv3.value.substr(0, 1) == "1") {
        ratedefinition[0][3] = rv3.value.substr(1, 2).trim();
        ratedefinition[1][3] = rv3.value.substr(3, 30).trim();
        if (ratedefinition[0][3].valueOf() > 0) ratedefinition[2][3] = rv3.value.substr(33, 30).trim();
        if (ratedefinition[0][3].valueOf() > 1) ratedefinition[3][3] = rv3.value.substr(63, 30).trim();
        if (ratedefinition[0][3].valueOf() > 2) ratedefinition[4][3] = rv3.value.substr(93, 30).trim();
        if (ratedefinition[0][3].valueOf() > 3) ratedefinition[5][3] = rv3.value.substr(123, 30).trim();
        if (ratedefinition[0][3].valueOf() > 4) ratedefinition[6][3] = rv3.value.substr(153, 30).trim();
    }
    else { ratedefinition[0][3] = 0 }
    if (rv4.value.substr(0, 1) == "1") {
        ratedefinition[0][4] = rv4.value.substr(1, 2).trim();
        ratedefinition[1][4] = rv4.value.substr(3, 30).trim();
        if (ratedefinition[0][4].valueOf() > 0) ratedefinition[2][4] = rv4.value.substr(33, 30).trim();
        if (ratedefinition[0][4].valueOf() > 1) ratedefinition[3][4] = rv4.value.substr(63, 30).trim();
        if (ratedefinition[0][4].valueOf() > 2) ratedefinition[4][4] = rv4.value.substr(93, 30).trim();
        if (ratedefinition[0][4].valueOf() > 3) ratedefinition[5][4] = rv4.value.substr(123, 30).trim();
        if (ratedefinition[0][4].valueOf() > 4) ratedefinition[6][4] = rv4.value.substr(153, 30).trim();
    }
    else { ratedefinition[0][4] = 0 }
    if (rv5.value.substr(0, 1) == "1") {
        ratedefinition[0][5] = rv5.value.substr(1, 2).trim();
        ratedefinition[1][5] = rv5.value.substr(3, 30).trim();
        if (ratedefinition[0][5].valueOf() > 0) ratedefinition[2][5] = rv5.value.substr(33, 30).trim();
        if (ratedefinition[0][5].valueOf() > 1) ratedefinition[3][5] = rv5.value.substr(63, 30).trim();
        if (ratedefinition[0][5].valueOf() > 2) ratedefinition[4][5] = rv5.value.substr(93, 30).trim();
        if (ratedefinition[0][5].valueOf() > 3) ratedefinition[5][5] = rv5.value.substr(123, 30).trim();
        if (ratedefinition[0][5].valueOf() > 4) ratedefinition[6][5] = rv5.value.substr(153, 30).trim();
    }
    else { ratedefinition[0][5] = 0 }
     
            //if (nc > 0)  rateVar.Add(rateVarString.Substring(23, 20).Trim());
            //if (nc > 1)  rateVar.Add(rateVarString.Substring(43, 20).Trim());
            //if (nc > 2)  rateVar.Add(rateVarString.Substring(63, 20).Trim());
            //if (nc > 3)  rateVar.Add(rateVarString.Substring(83, 20).Trim());
            //if (nc > 4)  rateVar.Add(rateVarString.Substring(103, 20).Trim());
        
    
 


}



 
 