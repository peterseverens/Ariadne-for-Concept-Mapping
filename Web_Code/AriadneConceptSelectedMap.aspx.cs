using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using System.IO;
using System.Xml;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Globalization;
using System.Text;
using System.Web.Services;

 
//using System.Collections.Generic;



public partial class ariadneConceptSelectedMap : System.Web.UI.Page
{

    //string[] items = new string[6];

    ArrayList items;
    int itemN;
    string itemSortData;

    Guid Activeorganizer;
    Guid ActiveProject;
    Guid ActiveSelection;
    Guid ActiveParticipant;
    
    

    int dimensionN = 3;
    int clusterSaveN = 18;

    public string pathPro = "";
    public string pathOrg = "";
    public string pathOrgArp = "";



    System.Web.UI.WebControls.CheckBox[,] varcatc = new CheckBox[9, AriadneStatistics.partMaxN];
    System.Web.UI.WebControls.Label[,] varcatcr = new Label[6, AriadneStatistics.itemMaxN];
    DataHandling dh = new DataHandling();
    Utils ut = new Utils();
    UtilsDataStrings uts = new UtilsDataStrings();

    AriadneStatistics arst = new AriadneStatistics();  //WORDT OVERSCHREVEN NA REFRESH!!


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        if (Request.QueryString["project"] != null)
        {
            Activeorganizer = XmlConvert.ToGuid(Request.QueryString["organizer"]);
            ActiveProject = XmlConvert.ToGuid(Request.QueryString["project"]);
            ActiveSelection = XmlConvert.ToGuid(Request.QueryString["selection"]);
            //subtitletext.Text = Request.QueryString["subtitle"].Trim();
            activeselectiontext.Text = Request.QueryString["selection"].Trim();

            
            //BUILD SELECTIONS

            if (!Page.IsPostBack)
            {
                //pageStatus.Text = "select";
            }
            else
            {
                //pageStatus.Text = "show"; getc
            }

            for (int p = 1; p < AriadneStatistics.partMaxN + 1; p += 1)
            {
                arst.participantSelected[p] = true;
            }
            arst.getData(ActiveProject, false);
            arst.getVars();
            arst.GetSelection(ActiveProject, ActiveSelection);
           
            arst.getData(ActiveProject, true);



            int result = arst.computeMap(ActiveProject, arst.analysesInfo);

            projectName.Text = GetProjectName().Trim(); //+ " (Participants: " + arst.partN.ToString() + ") " + " (Items: " + arst.itemN.ToString() + ")";
 
            itemsLoad(ActiveProject);
            coordinatesLoad(ActiveProject);
            clustersLoad(ActiveProject);
            clustersDevisionsLoad(ActiveProject);
            ratesLoad(ActiveProject);
            clusterRatesLoad(ActiveProject);
            participantDimensionRatesLoad(ActiveProject);
            participantNmemesLoad(ActiveProject);
            clusterNamesCoordLoad();
            rawDistancesLoad();
            mapNamesLoad();

            Page.Controls.AddAt(1, new LiteralControl("<style> body {width:50%; height:100%; overflow:hidden, margin:0}  html {width:100%; height:100%; overflow:hidden} </style>"));

            // GetDataNotSelected();

            
            conceptForm.Style.Add("visibility", "visible");





        }
        //buildChecks();
        if (Request.QueryString["organizer"] != null)
        {
            Guid Activeorganizer = XmlConvert.ToGuid(Request.QueryString["organizer"]);
        }

    }

    public string GetProjectName()
    {
        ArrayList objl = new ArrayList();
        objl = dh.EditProject(ActiveProject);
        //Activeorganizer = (Guid)objl[0];
        //ActiveProject = (Guid)objl[1];

        //if (objl.Count > 4) ratedef1.Text = objl[4].ToString(); else ratedef1.Text = "";
        //if (objl.Count > 5) ratedef2.Text = objl[5].ToString(); else ratedef2.Text = "";
        //if (objl.Count > 6) ratedef3.Text = objl[6].ToString(); else ratedef3.Text = "";
        //if (objl.Count > 7) ratedef4.Text = objl[7].ToString(); else ratedef4.Text = "";
        //if (objl.Count > 8) ratedef5.Text = objl[8].ToString(); else ratedef5.Text = "";

        ArrayList rateVar;
        //if (objl.Count > 4) { rateVar = uts.getRateVars(objl[4].ToString()); if (rateVar.Count > 0) { ratedef1.Text = ((string)rateVar[0]).Trim() + " (n cat = " + (rateVar.Count - 1).ToString() + ")"; } } else { ratedef1.Text = "1005importance (n cat = 5)"; }
        //if (objl.Count > 5) { rateVar = uts.getRateVars(objl[5].ToString()); if (rateVar.Count > 0) { ratedef2.Text = ((string)rateVar[0]).Trim() + " (n cat = " + (rateVar.Count - 1).ToString() + ")"; } } else { ratedef2.Text = "not defined"; }
        //if (objl.Count > 6) { rateVar = uts.getRateVars(objl[6].ToString()); if (rateVar.Count > 0) { ratedef3.Text = ((string)rateVar[0]).Trim() + " (n cat = " + (rateVar.Count - 1).ToString() + ")"; } } else { ratedef3.Text = "not defined"; }
        //if (objl.Count > 7) { rateVar = uts.getRateVars(objl[7].ToString()); if (rateVar.Count > 0) { ratedef4.Text = ((string)rateVar[0]).Trim() + " (n cat = " + (rateVar.Count - 1).ToString() + ")"; } } else { ratedef4.Text = "not defined"; }
        //if (objl.Count > 8) { rateVar = uts.getRateVars(objl[8].ToString()); if (rateVar.Count > 0) { ratedef5.Text = ((string)rateVar[0]).Trim() + " (n cat = " + (rateVar.Count - 1).ToString() + ")"; } } else { ratedef5.Text = "not defined"; }

        if (objl.Count > 4) { rateVar = uts.getRateVars(objl[4].ToString()); if (rateVar.Count > 0) { ratedef1.Text = objl[4].ToString(); } } else { ratedef1.Text = "1005Importance"; };
        if (objl.Count > 5) { rateVar = uts.getRateVars(objl[5].ToString()); if (rateVar.Count > 0) { ratedef2.Text = objl[5].ToString(); } } else { ratedef2.Text = "not defined"; }
        if (objl.Count > 6) { rateVar = uts.getRateVars(objl[6].ToString()); if (rateVar.Count > 0) { ratedef3.Text = objl[6].ToString(); } } else { ratedef3.Text = "not defined"; }
        if (objl.Count > 7) { rateVar = uts.getRateVars(objl[7].ToString()); if (rateVar.Count > 0) { ratedef4.Text = objl[7].ToString(); } } else { ratedef4.Text = "not defined"; }
        if (objl.Count > 8) { rateVar = uts.getRateVars(objl[8].ToString()); if (rateVar.Count > 0) { ratedef5.Text = objl[8].ToString(); } } else { ratedef5.Text = "not defined"; }


        return objl[2].ToString();
    }



     


    protected Guid saveSelection_del(Guid projectId)
    {
        string Selection = "";
        string Pg = ""; string Ig = ""; string Vin = ""; string Cin = "";
        int Pn = 0; ; int In = 0; int Cn = 0;

        for (int p = 1; p < arst.partN + 1; p++)
        {
            if (arst.participantPreSelected[p] == true) { Pn += 1; Pg += XmlConvert.ToString(arst.p_participant_id[p]); }
        }
        Selection += Pn.ToString("000", CultureInfo.InvariantCulture) + Pg;
        for (int i = 1; i < arst.itemN + 1; i++)
        {
            if (arst.itemPreSelected[i] == true) { In += 1; Ig += arst.itemGuids[i]; };
        }
        Selection += In.ToString("000", CultureInfo.InvariantCulture) + Ig;
        for (int v = 1; v < 6 + 1; v++)
        {
            if (arst.varSelected[v] == true) { Vin += "1"; } else { Vin += "0"; }
        }
        for (int v = 1; v < 6 + 1; v++)
        {
            for (int g = 1; g < arst.participantGroupsVN[v] + 1; g++)
            {
                if (arst.participantGroupsSelected[v, g] == true) { Cin += String.Format("{0,-50}", varcatc[v, g].Text); Cn += 1; }
            }

            Selection += Cn.ToString("000", CultureInfo.InvariantCulture) + Cin;
        }

        Guid selectionId_del = dh.AddSelection(projectId, Selection,0,"","","");
        return selectionId_del;

    }

    protected void GetSelection_del(Guid projectId, Guid selectionId)
    {

        ArrayList selectionSO = dh.GetSelection(projectId, selectionId);
        string selectionS = (string)selectionSO[0];

        int Pn = 0; ; int In = 0; int Cn = 0;
        for (int p = 1; p < arst.partN + 1; p++)
        {
            arst.participantPreSelected[p] = false;
        }
        Guid partIdNow;
        Pn = Convert.ToInt32(selectionS.Substring(0, 3));
        for (int pp = 1; pp < Pn + 1; pp++)
        {
            partIdNow = XmlConvert.ToGuid(selectionS.Substring(3 + (pp - 1) * 36, 36));
            for (int p = 1; p < arst.partN + 1; p++)
            {
                if (arst.p_participant_id[p] == partIdNow) { arst.participantPreSelected[p] = true; }
            }

        }
        for (int i = 1; i < arst.itemN + 1; i++)
        {
            arst.itemPreSelected[i] = false;
        }
        Guid itemIdNow;
        In = Convert.ToInt32(selectionS.Substring(3 + Pn * 36, 3));
        for (int ii = 1; ii < In + 1; ii++)
        {
            itemIdNow = XmlConvert.ToGuid(selectionS.Substring(3 + Pn * 36 + 3 + (ii - 1) * 36, 36));
            for (int i = 1; i < arst.itemN + 1; i++)
            {
                if (arst.itemGuids[i] == itemIdNow) { arst.itemPreSelected[i] = true; }
            }
        }
        int totcatN = 0;
        for (int v = 1; v < 6 + 1; v++)
        {
            for (int c = 1; c < arst.participantGroupsVN[v] + 1; c++)
            {
                arst.participantGroupsSelected[v, c] = false; varcatc[v, c].Checked = false;
            }
            string selectedCat = "";
            Cn = Convert.ToInt32(selectionS.Substring(3 + Pn * 36 + 3 + In * 36 + (v - 1) * 3 + totcatN * 50, 3));

            for (int cc = 1; cc < Cn + 1; cc++)
            {
                selectedCat = selectionS.Substring(3 + Pn * 36 + 3 + In * 36 + 3 + (v - 1) * 3 + totcatN * 50, 50);
                totcatN += 1;
                for (int c = 1; c < arst.participantGroupsVN[v] + 1; c++)
                {
                    if (arst.participantGroupsV[v, c].Trim() == selectedCat.Trim()) { arst.participantGroupsSelected[v, c] = true; }

                }
            }


        }

    }

    protected void itemsLoad(Guid projectId)
    {

        //items =  DataHandling.SelectAllItems(projectId);
        //itemN = items.Count;
        //int itemN = AriadneStatistics.itemN;
        //string testt = AriadneStatistics.items[1];

        itemData.Text = String.Format("{0:000}", arst.itemN); //itemN.ToString();

        int maxItemLength = 99;
        int maxLength = 0;
        //String itemText = "";
        for (int i = 1; i < arst.itemN + 1; i++)
        {
            maxLength = arst.items[i].Length;
            if (maxLength > maxItemLength) { maxLength = maxItemLength; }

            /////

            string item = arst.items[i].Substring(0, maxLength).Trim();
            string replaceWith = " ";
            string itemremovedBreaks = item.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"","").Trim();
            string itemS = String.Format("{0,-100}", itemremovedBreaks.Trim());
            itemData.Text += itemS;

            ////


            //itemText = String.Format("{0,-100}", arst.items[i].Substring(0, maxLength));
            //itemData.Text += itemText;

        }

    }

    protected void coordinatesLoad(Guid projectId)
    {
        for (int d = 1; d <= dimensionN; d++)
        {
            coordinateData.Text += String.Format("{0,10:0.0000}", arst.EigenValuesS[d]);
            for (int i = 1; i < arst.itemN + 1; i++)
            {
                coordinateData.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.EigenVectorsS[d, i]);
                //coordinateData.Text +=   AriadneStatistics.EigenVectorsS[d, i].ToString("00000.0000", CultureInfo.InvariantCulture);
                //coordinateData.Text += AriadneStatistics.EigenVectorsS[d, i].ToString("00.00", CultureInfo.InvariantCulture);

            }
        }
        for (int i = 1; i < arst.itemN + 1; i++)
        {

            dh.UpdateItemMapScores(arst.itemGuids[i], arst.EigenVectorsS[1, i], arst.EigenVectorsS[2, i]);
        }

    }
    protected void clustersLoad(Guid projectId)
    {

        for (int c = 1; c <= clusterSaveN; c++)
        {
            for (int g = 1; g <= c; g++)
            {
                clusterData3.Text += String.Format("{0,-3}", arst.clusterItemN3[c, g]);
            }
            for (int g = 1; g <= c; g++)
            {
                for (int i = 1; i < arst.clusterItemN3[c, g] + 1; i++)
                {
                    clusterData3.Text += String.Format("{0,-3}", arst.clusterItem3[c, g, i]);
                }
            }

        }
        for (int c = 1; c <= clusterSaveN; c++)
        {
            for (int g = 1; g <= c; g++)
            {
                clusterData2.Text += String.Format("{0,-3}", arst.clusterItemN2[c, g]);
            }
            for (int g = 1; g <= c; g++)
            {
                for (int i = 1; i < arst.clusterItemN2[c, g] + 1; i++)
                {
                    clusterData2.Text += String.Format("{0,-3}", arst.clusterItem2[c, g, i]);
                }
            }

        }
        for (int c = 1; c <= clusterSaveN; c++)
        {
            for (int g = 1; g <= c; g++)
            {
                clusterData1.Text += String.Format("{0,-3}", arst.clusterItemN1[c, g]);
            }
            for (int g = 1; g <= c; g++)
            {
                for (int i = 1; i < arst.clusterItemN1[c, g] + 1; i++)
                {
                    clusterData1.Text += String.Format("{0,-3}", arst.clusterItem1[c, g, i]);
                }
            }

        }
    }

    protected void clustersDevisionsLoad(Guid projectId)
    {
        for (int c = 1; c <= clusterSaveN; c++)
        {

            clusterDataD3.Text += String.Format("{0,-3}", arst.clusterItem3[c, 0, 1]);
            clusterDataD3.Text += String.Format("{0,-3}", arst.clusterItem3[c, 0, 2]);
            clusterDataD3.Text += String.Format("{0,-3}", arst.clusterItem3[c, 0, 3]);
            clusterDataD3.Text += String.Format("{0,-3}", arst.clusterItem3[c, 0, 4]);

            clusterDataD2.Text += String.Format("{0,-3}", arst.clusterItem2[c, 0, 1]);
            clusterDataD2.Text += String.Format("{0,-3}", arst.clusterItem2[c, 0, 2]);
            clusterDataD2.Text += String.Format("{0,-3}", arst.clusterItem2[c, 0, 3]);
            clusterDataD2.Text += String.Format("{0,-3}", arst.clusterItem2[c, 0, 4]);

            clusterDataD1.Text += String.Format("{0,-3}", arst.clusterItem1[c, 0, 1]);
            clusterDataD1.Text += String.Format("{0,-3}", arst.clusterItem1[c, 0, 2]);
            clusterDataD1.Text += String.Format("{0,-3}", arst.clusterItem1[c, 0, 3]);
            clusterDataD1.Text += String.Format("{0,-3}", arst.clusterItem1[c, 0, 4]);
        }
    }

    protected void ratesLoad(Guid projectId)
    {


        //for (int i = 1; i < AriadneStatistics.itemN + 1; i++)
        //{
        //    rates.Text += AriadneStatistics.ratesAggr[i].ToString("0.00", CultureInfo.InvariantCulture);
        //}
        //rates.Text = ut.BuildRatesAggrString();
        rates1.Text = uts.BuildRatesAggrString(arst.ratesAggr, arst.ratesAggrN, arst.itemN, 1);
        rates2.Text = uts.BuildRatesAggrString(arst.ratesAggr, arst.ratesAggrN, arst.itemN, 2);
        rates3.Text = uts.BuildRatesAggrString(arst.ratesAggr, arst.ratesAggrN, arst.itemN, 3);
        rates4.Text = uts.BuildRatesAggrString(arst.ratesAggr, arst.ratesAggrN, arst.itemN, 4);
        rates5.Text = uts.BuildRatesAggrString(arst.ratesAggr, arst.ratesAggrN, arst.itemN, 5);

    }

    protected void clusterRatesLoad(Guid projectId)
    {
        for (int r = 1; r < 5 + 1; r++)
        {
            for (int c = 1; c <= clusterSaveN; c++)
            {
                for (int i = 1; i < c + 1; i++)
                {
                    //clusterRates.Text += String.Format("{0,00 }", AriadneStatistics.clusterRatesAggr[c,i] );

                    if (double.IsNaN(arst.clusterRatesAggr1[c, i, r])) arst.clusterRatesAggr1[c, i, r] = 0;
                    if (double.IsNaN(arst.clusterRatesAggr2[c, i, r])) arst.clusterRatesAggr2[c, i, r] = 0;
                    if (double.IsNaN(arst.clusterRatesAggr3[c, i, r])) arst.clusterRatesAggr3[c, i, r] = 0;

                    if (r == 1)
                    {
                        clusterRates1.Text += arst.clusterRatesAggr1[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates2.Text += arst.clusterRatesAggr2[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates3.Text += arst.clusterRatesAggr3[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                    }
                    if (r == 2)
                    {
                        clusterRates21.Text += arst.clusterRatesAggr1[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates22.Text += arst.clusterRatesAggr2[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates23.Text += arst.clusterRatesAggr3[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                    }
                    if (r == 3)
                    {
                        clusterRates31.Text += arst.clusterRatesAggr1[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates32.Text += arst.clusterRatesAggr2[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates33.Text += arst.clusterRatesAggr3[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                    }
                    if (r == 4)
                    {
                        clusterRates41.Text += arst.clusterRatesAggr1[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates42.Text += arst.clusterRatesAggr2[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates43.Text += arst.clusterRatesAggr3[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                    }
                    if (r == 5)
                    {
                        clusterRates51.Text += arst.clusterRatesAggr1[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates52.Text += arst.clusterRatesAggr2[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                        clusterRates53.Text += arst.clusterRatesAggr3[c, i, r].ToString("0.00", CultureInfo.InvariantCulture);
                    }
                }
            }
        }
    }

    protected void participantDimensionRatesLoad(Guid projectId)
    {
        for (int r = 1; r < 5 + 1; r++)
        {
            if (r == 1) participantDimensions.Text = String.Format("{0:000}", arst.partN);
            if (r == 2) participantDimensions2.Text = String.Format("{0:000}", arst.partN);
            if (r == 3) participantDimensions3.Text = String.Format("{0:000}", arst.partN);
            if (r == 4) participantDimensions4.Text = String.Format("{0:000}", arst.partN);
            if (r == 5) participantDimensions5.Text = String.Format("{0:000}", arst.partN);

            for (int p = 1; p < arst.partN + 1; p++)
            {

                for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                {

                    if (r == 1) participantDimensions.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantDimensionRates[p, d, r]);
                    if (r == 2) participantDimensions2.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantDimensionRates[p, d, r]);
                    if (r == 3) participantDimensions3.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantDimensionRates[p, d, r]);
                    if (r == 4) participantDimensions4.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantDimensionRates[p, d, r]);
                    if (r == 5) participantDimensions5.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantDimensionRates[p, d, r]);
                }

            }

            if (r == 1) participantGroupsDimensions.Text = String.Format("{0:000}", arst.participantGroupsN);
            if (r == 1) participantGroupsDimensions2.Text = String.Format("{0:000}", arst.participantGroupsN);
            if (r == 1) participantGroupsDimensions3.Text = String.Format("{0:000}", arst.participantGroupsN);
            if (r == 1) participantGroupsDimensions4.Text = String.Format("{0:000}", arst.participantGroupsN);
            if (r == 1) participantGroupsDimensions5.Text = String.Format("{0:000}", arst.participantGroupsN);

            if (r == 1) { participantGroupsNames.Text = String.Format("{0:000}", arst.participantGroupsN); }
            for (int p = 1; p < arst.participantGroupsN + 1; p++)
            {
                if (r == 1) participantGroupsNames.Text += (arst.participantGroups[p] + "                              ").Substring(0, 30);

                for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                {


                    if (r == 1) participantGroupsDimensions.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantGroupsDimensionRates[p, d, r]);
                    if (r == 2) participantGroupsDimensions2.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantGroupsDimensionRates[p, d, r]);
                    if (r == 3) participantGroupsDimensions3.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantGroupsDimensionRates[p, d, r]);
                    if (r == 4) participantGroupsDimensions4.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantGroupsDimensionRates[p, d, r]);
                    if (r == 5) participantGroupsDimensions5.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.participantGroupsDimensionRates[p, d, r]);

                    //AriadneStatistics.participantDimensionRates[p, d].ToString("0.00", CultureInfo.InvariantCulture);
                }

            }
        }
    }
    protected void participantNmemesLoad(Guid projectId)
    {

        //itemData.Text = String.Format("{0:000}", arst.itemN); //itemN.ToString();
        //for (int i = 1; i < arst.itemN + 1; i++)
        //{
        //    itemData.Text += String.Format("{0,-100}", arst.items[i]);
        //}


        participantNames.Text = String.Format("{0:000}", arst.partN);
        for (int p = 1; p < arst.partN + 1; p++)
        {
            participantNames.Text += String.Format("{0,-100}", arst.participants[p]);

            //AriadneStatistics.participantDimensionRates[p, d].ToString("0.00", CultureInfo.InvariantCulture);
        }
    }

    protected void clusterNamesCoordLoad()
    {

        clusterNamesCoord.Text = String.Format("{0:000}", arst.nClusterNames); //itemN.ToString();
        for (int r = 1; r < arst.nClusterNames + 1; r++)
        {
            string replaceWith = " ";
            string itemremovedBreaks = arst.clusterNamesSelected[r].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "");
            clusterNamesCoord.Text += String.Format("{0,-100}", itemremovedBreaks.Trim());
            for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
            {
                //clusterNamesCoord.Text += String.Format("{0:000}", AriadneStatistics.clusterNamesDimScoresSelected[r, d]);
                clusterNamesCoord.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", arst.clusterNamesDimScoresSelected[r, d]);
            }
        }

    }

    protected void rawDistancesLoad()
    {
        for (int i = 1; i < arst.itemN + 1; i++)
        {
            for (int ii = i; ii < arst.itemN + 1; ii++)
            {
                rawSortData.Text += String.Format(CultureInfo.InvariantCulture, "{0,10:0}", arst.sortMatrixRaw[i, ii]); 
            }
        }
    }
    protected void mapNamesLoad()
    {
       subtitletext.Text = arst.mapSubTitle;
       MapClusterNames.Text = arst.mapClusterNames;
       MapDimensionNames.Text = arst.mapDimensionNames;

    }

    protected void UploadDataFile_Click(object sender, EventArgs e)
    {
        arst.outputData(Activeorganizer, ActiveProject, GetProjectName() + " (Pn= " + arst.partN.ToString() + ") " + " (In= " + arst.itemN.ToString() + ")", "After Selection", ratedef1.Text, ratedef2.Text, ratedef3.Text, ratedef4.Text, ratedef5.Text);

        if (arst.dataFile.Trim() != "")
        {


            string fileName = arst.dataFile.Trim(); //.FileName;

            string fileNow = arst.dataFileName.Trim();


            byte[] data = File.ReadAllBytes(fileName);

            FileStream file = File.Create(fileName);

            file.Write(data, 0, data.Length);
            file.Close();


            //String FileName = "FileName.txt";
            //String FilePath = "C:/"; //Replace this
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "csv";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileNow + ";");
            response.TransmitFile(fileName);
            response.Flush();
            response.End();

        }
    }
 
    protected void UploadStatisticsFile_Click(object sender, EventArgs e)
    {
       
    
        outputStatistics(Activeorganizer, ActiveProject, GetProjectName() + " (Pn= " + arst.partN.ToString() + ") " + " (In= " + arst.itemN.ToString() + ")", "After Selection");
        if (arst.statisticsFile.Trim() != "")
        {
            

            string fileName = arst.statisticsFile.Trim(); //.FileName;

            string fileNow = arst.statisticsFileName.Trim();


            byte[] data = File.ReadAllBytes(fileName);

            FileStream file = File.Create(fileName);

            file.Write(data, 0, data.Length);
            file.Close();


            //String FileName = "FileName.txt";
            //String FilePath = "C:/"; //Replace this
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "csv";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileNow + ";");
            response.TransmitFile(fileName);
            response.Flush();
            response.End();

        }

    }


    protected void UploadCanvasImageFile_Click(object sender, EventArgs e)
    {
        string Activeorganizer = XmlConvert.ToString((Guid)Membership.GetUser().ProviderUserKey);
        string fileName = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + Activeorganizer + "/CanvasPicture.png";
 
         

        byte[] data = File.ReadAllBytes(fileName);

        FileStream file = File.Create(fileName);

        file.Write(data, 0, data.Length);
        file.Close();

        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "csv";
        response.AddHeader("Content-Disposition", "attachment; filename=" + "Map.png" + ";");
        response.TransmitFile(fileName);
        response.Flush();
        response.End();
 
    }

    [WebMethod()]
    public static void UploadPic(string imageData)
    {     
        string Activeorganizer = XmlConvert.ToString((Guid)Membership.GetUser().ProviderUserKey);
        string fileName = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + Activeorganizer + "/CanvasPicture.png";

        //string Pic_Path = HttpContext.Current.Server.MapPath("MyPicture.png");
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                byte[] data = Convert.FromBase64String(imageData);
                bw.Write(data);
                bw.Close();
            }
        }
     }

    [System.Web.Services.WebMethod()]
    public static string saveMapNamesToServer(string activeSelectionS, string subTitle, string clusterNames, string dimensionNames )
    {  
        DataHandling dh2 = new DataHandling();
        object result = dh2.UpdateSelectionWithMapNames(activeSelectionS, subTitle, clusterNames, dimensionNames);
        return "";
    }
     


    public static void SavePic2()
    {
        string Activeorganizer = XmlConvert.ToString((Guid)Membership.GetUser().ProviderUserKey);

        string Pic_Path = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + Activeorganizer + "/CanvasPicture.png";

        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "csv";
        response.AddHeader("Content-Disposition", "attachment; filename=" + "mapPicture.png" + ";");
        response.TransmitFile(Pic_Path);
        response.Flush();
        //response.End();
    }

    public void outputStatistics(Guid organizerId, Guid projectId, string ProjectName, string Version)
    {
        String Day = DateTime.Now.Day.ToString();
        String Month = DateTime.Now.Month.ToString();
        String Year = DateTime.Now.Year.ToString();
        String Hour = DateTime.Now.Hour.ToString();
        String Minute = DateTime.Now.Minute.ToString();


        Version += " " + Month + "-" + Day + "-" + Year + " " + Hour + "-" + Minute;

        string replaceWith = " ";

        string dir = XmlConvert.ToString(organizerId);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;
        //if (createUserPathOrg(organizerId))
        if (Directory.Exists(pathOrg))
        {

            arst.statisticsFileName = ProjectName + " " + Version + ".csv";
            arst.statisticsFile = pathOrg + "/" + arst.statisticsFileName;

            using (var sw = new StreamWriter(new FileStream(arst.statisticsFile, FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8))
      
 
           
            {
                StringBuilder sb = new StringBuilder();
                
                //PROJECTNAME
                string tt = ProjectName + " " + Version;
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);


         
                tt = "INPUT DATA FOR MAP";
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);
                sb.AppendLine(tt);

                       
               

                //ITEMS 

                tt = "ITEMS: eigenvalues and eigenvectors and mean rates per item and standard deviation";
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);
                tt = "";
                tt += ",,";
                for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                {
                    tt += "eigenvalues" + d.ToString() + ",";
                }
                sb.AppendLine(tt);
                tt = "";
                tt += ",,";
                for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                {
                    tt += arst.EigenValuesS[d].ToString() + ",";
                }
                sb.AppendLine(tt);
                tt = "";


                tt += "item" + ",,";
                for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                {
                    tt += "eigenvectors" + d.ToString() + ",";
                } for (int r = 1; r < 5 + 1; r++)
                {
                    tt += "mean rate " + r.ToString() + ",";
                    tt += "standard deviation" + r.ToString() + ",";
                }
                sb.AppendLine(tt);
                tt = "";

                for (int i = 1; i < arst.itemN + 1; i++)
                {


                    string itemremovedBreaks = arst.items[i].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();

                    //tt += '"' + itemremovedBreaks.Trim() + '"';
                    tt += i.ToString() + ',' + '"' + itemremovedBreaks.Trim() + '"' + ",";
                    //tt +="item" + i.ToString() + ",";
                    for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                    {

                        tt += arst.EigenVectorsS[d, i].ToString() + ",";
                    }
                    for (int r = 1; r < 5 + 1; r++)
                    {
                        tt += arst.ratesAggr[i, r].ToString() + ",";
                        tt += arst.ratesSTDV[i, r].ToString("0.00000", CultureInfo.InvariantCulture) + ",";
                    }
                    sb.AppendLine(tt);
                    tt = "";
                }

                tt = "";
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);

                tt = "PARTICIPANTS AND PARTICIPANTS GRUEPS: scores on eigenvectors";
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);
                tt = "";

                //PARTICIPANTS DIMENSION RATES 
                tt = "participants dimension rates ";
                sb.AppendLine(tt);
                tt += "participant" + ",";
                for (int r = 1; r < 5 + 1; r++)
                {


                    for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                    {
                        tt += "rating " + r.ToString() + " dim " + d.ToString() + ",";
                    }

                }
                sb.AppendLine(tt);

                tt = "";
                for (int p = 1; p < arst.partN + 1; p++)
                {
                    tt += '"' + arst.participants[p].Trim() + '"' + ",";
                    for (int r = 1; r < 5 + 1; r++)
                    {

                       
                        //tt += "participant" + p.ToString() + ",";
                        for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                        {
                            tt += arst.participantDimensionRates[p, d, r].ToString() + ",";
                        }

                        
                    }
                    sb.AppendLine(tt);
                    tt = "";
                }
                
                tt = "";
                sb.AppendLine(tt);
                //PARTICIPANTS GROUPS DIMENSION RATES 


                tt = "participants groups dimension rates ";
                sb.AppendLine(tt);
                tt += "group" + ",";
                tt += "group N (participants)" + ",";
                for (int r = 1; r < 5 + 1; r++)
                {
                    for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                    {
                        tt += "dim " + d.ToString() + ",";
                    }
                    
                }
                sb.AppendLine(tt);
                tt = "";
                for (int p = 1; p < arst.participantGroupsN + 1; p++)
                {
                    tt += "participant group: " + '"' + arst.participantGroups[p].ToString() + '"' + ",";
                    tt += arst.participantGroupsNn[p].ToString() + ",";
                    for (int r = 1; r < 5 + 1; r++)
                    {



                        for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                        {
                            tt += arst.participantGroupsDimensionRates[p, d, r].ToString() + ",";
                        }
                        
                    }
                    sb.AppendLine(tt);
                    tt = "";
                }

                tt = "";
                sb.AppendLine(tt);
                sb.AppendLine(tt);



                tt = "CLUSTERS";
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);
                tt = "";
                //ITEMS PER CLUSTER

                tt = "items per cluster (two dimensional solution)";
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);
                for (int c = 2; c <= clusterSaveN; c++)
                {
              

                    for (int g = 1; g <= c; g++)
                    {
                        tt = "cluster solution with " + c.ToString("0", CultureInfo.InvariantCulture) + " clusters: cluster " + g.ToString("0", CultureInfo.InvariantCulture);
                        sb.AppendLine(tt);
                        tt = ",,";
                        for (int r = 1; r < 5 + 1; r++)
                        {
                            tt += "Mean rating " + r.ToString() + ",";
                        }
                        sb.AppendLine(tt);


                        tt = ",,";
                        for (int r = 1; r < 5 + 1; r++)
                        {
                            tt += arst.clusterRatesAggr2[c, g, r].ToString("0.00", CultureInfo.InvariantCulture) + ",";
                        }
                        sb.AppendLine(tt);
                        tt = "item number,item,rate1,rate2,rate3,rate4,rate5";
                        sb.AppendLine(tt);
                        for (int i = 1; i < arst.clusterItemN2[c, g] + 1; i++)
                        {
                            tt = arst.clusterItem2[c, g, i].ToString() + ",";


                            string itemremovedBreaks = arst.items[arst.clusterItem2[c, g, i]].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();
                            tt += '"' + itemremovedBreaks.Trim() + '"' + ","; ;
                            for (int r = 1; r < 5 + 1; r++)
                            {
                                tt += arst.ratesAggr[arst.clusterItem2[c, g, i], r].ToString() + ",";
                                //tt += arst.ratesSTDV[i, r].ToString("0.00000", CultureInfo.InvariantCulture) + ",";
                            }

                            sb.AppendLine(tt);
                        }
                    }


                }


                tt = "";
                sb.AppendLine(tt);
                tt = "";

                //MEAN RATE PER CLUSTER
                for (int r = 1; r < 5 + 1; r++)
                {
                   
                    tt = "mean rates per cluster (two dimensional solution)";
                    sb.AppendLine(tt);
                    tt = "rating " + r.ToString() + ",";
                    for (int c = 1; c <= clusterSaveN; c++)
                    {
                        tt += "cluster " + c.ToString("0", CultureInfo.InvariantCulture) + ",";
                    }
                    sb.AppendLine(tt);
                    for (int c = 1; c <= clusterSaveN; c++)
                    {
                        tt = "cluster solution with " + c.ToString("0", CultureInfo.InvariantCulture) + " clusters,";
                        for (int cc = 1; cc < c + 1; cc++)
                        {
                            //clusterRates.Text += String.Format("{0,00 }", arst.clusterRatesAggr[c,i] );

                            //clusterRates1.Text += arst.clusterRatesAggr1[c, i].ToString("0.00", CultureInfo.InvariantCulture);
                            tt += arst.clusterRatesAggr2[c, cc, r].ToString("0.00", CultureInfo.InvariantCulture) + ",";
                            //clusterRates3.Text += arst.clusterRatesAggr3[c, i].ToString("0.00", CultureInfo.InvariantCulture);
                        }
                        sb.AppendLine(tt);
                    }

                }

         
                tt = "";
                sb.AppendLine(tt);
                sb.AppendLine(tt);
                

                //DIMENSION SCORES PER PARTICIPANT CLUSTERNAME
                tt = "dimensionscores of the participants clusternames";
                sb.AppendLine(tt);
                tt = ",,,";
                for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                {
                    tt += "dim " + d.ToString() + ",";
                }
                sb.AppendLine(tt);
                tt = "";
                for (int p = 1; p < arst.partN + 1; p++)
                {
                    //tt += "participant" + p.ToString() + ",";

                    for (int g = 1; g < AriadneStatistics.groupMaxN + 1; g++)
                    {
                        string participantremovedBreaks = arst.participants[p].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();
                        tt += '"' + participantremovedBreaks + '"' + ",";
                        tt += "group " + g.ToString() + ":,";
                        string itemremovedBreaks = arst.clusterName[p, g].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();
                        tt += '"' + itemremovedBreaks + '"' + ",";  
                        for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                        {
                            tt += arst.participantDimensionClusterNames[p, g, d].ToString() + ",";
                        }
                        sb.AppendLine(tt);
                        tt = "";
                    }

                }
                sb.AppendLine(tt);
                tt = "";
                sb.AppendLine(tt);
                tt = "";
                tt = "dimensionscores of the participants clusternames (above treshold value)";
                sb.AppendLine(tt);
                tt = ",,,";
                for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                {
                    tt += "dim " + d.ToString() + ",";
                }
                sb.AppendLine(tt);
                tt = "";
                for (int r = 1; r < arst.nClusterNames + 1; r++)
                {
                    string itemremovedBreaks = arst.clusterNamesSelected[r].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "");
                    tt += arst.clusterParticipantNamesSelected[r] + "," +'"'+ itemremovedBreaks+'"' + ",";
                    for (int d = 1; d < AriadneStatistics.dimensionN + 1; d++)
                    {

                        tt += arst.clusterNamesDimScoresSelected[r, d].ToString() + ",";
                    }

                    sb.AppendLine(tt);
                    tt = "";
                }

                tt = "";
                sb.AppendLine(tt);              
                sb.AppendLine(tt);

                //MATRIX

                tt = "Raw sort matrix";
                sb.AppendLine(tt);
                tt = "items";
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt += ",";
                    tt += i.ToString();

                }
                sb.AppendLine(tt);
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt = i.ToString(); ;
                    for (int ii = 1; ii < arst.itemN + 1; ii++)
                    {
                        tt += ",";
                        tt += arst.sortMatrixRaw[i, ii].ToString();

                    }
                    sb.AppendLine(tt);
                }
                tt = "";
                sb.AppendLine(tt);
                sb.AppendLine(tt);

                tt = "Input sort matrix";
                sb.AppendLine(tt);
                tt = "items";
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt += ",";
                    tt += i.ToString();

                }
                sb.AppendLine(tt);
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt = i.ToString(); ;
                    for (int ii = 1; ii < arst.itemN + 1; ii++)
                    {
                        tt += ",";
                        tt += arst.sortMatrixInput[i, ii].ToString();

                    }
                    sb.AppendLine(tt);
                }



                tt = "";
                sb.AppendLine(tt);
                sb.AppendLine(tt);     

                sb.AppendLine(tt);
                sb.AppendLine(tt);
                sb.AppendLine(tt);
                sb.AppendLine(tt);

                tt = "BETA TESTING UNTIL NOW!! : CALCULATION OF DISTANCE MATRIX PURE ON DISTANCES BETEEEN ITEMS, NOT ON GROUPS";
                sb.AppendLine(tt);


                tt = "";
                sb.AppendLine(tt);
                tt = "";

                tt = "DIF Positions";
                sb.AppendLine(tt);
                tt = "participant,";
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt += i.ToString();
                    tt += ",";
                }
                sb.AppendLine(tt);


                for (int p = 1; p < arst.partN + 1; p++)
                {
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i < arst.itemN + 1; i++)
                    {
                        tt += arst.posMatrixRawDX[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i < arst.itemN + 1; i++)
                    {
                        tt += arst.posMatrixRawDY[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                }

                tt = "MEAN Positions";
                sb.AppendLine(tt);
                tt = "participant,";
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt += i.ToString();
                    tt += ",";
                }
                sb.AppendLine(tt);


                for (int p = 1; p < arst.partN + 1; p++)
                {
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i < arst.itemN + 1; i++)
                    {
                        tt += arst.posMatrixRawMX[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i < arst.itemN + 1; i++)
                    {
                        tt += arst.posMatrixRawMY[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                }

                tt = "UN Positions";
                sb.AppendLine(tt);
                tt = "participant,";
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt += i.ToString();
                    tt += ",";
                }
                sb.AppendLine(tt);


                for (int p = 1; p < arst.partN + 1; p++)
                {
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i < arst.itemN + 1; i++)
                    {
                        tt += arst.posMatrixRawUX[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i < arst.itemN + 1; i++)
                    {
                        tt += arst.posMatrixRawUY[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                }

                tt = "Coord matrix";
                sb.AppendLine(tt);
                tt = ",";
                tt = "item,";
                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt += i.ToString();
                    tt += ",";
                }
                sb.AppendLine(tt);


                for (int i = 1; i < arst.itemN + 1; i++)
                {
                    tt = "";
                    tt += i.ToString();
                    tt += ",";
                    for (int ii = 1; ii < arst.itemN + 1; ii++)
                    {
                        tt += arst.posMatrix[i, ii];
                        tt += ",";
                    }
                    sb.AppendLine(tt);

                }


                sw.Write(sb.ToString());
                sb.Clear();

            }
        }
    }




}


