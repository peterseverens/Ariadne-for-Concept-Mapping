


using System.Data;
using System.Data.SqlClient;

using System;
using System.Configuration;
using System.Collections;

using DotNetMatrix;

using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Globalization;
//using NagLibrary;




public  class AriadneStatistics
{

    //AriadneStatistics ars = new AriadneStatistics();

    public Random random = new Random();

    public   string dataFile = "";
    public   string dataFileName = "";
    public   string statisticsFile = "";
    public   string statisticsFileName = "";

    public static int maxRate =5;


    public static int partMaxN = 999; //test kinga// public  static int partMaxN = 300;
     public static int itemMaxN = 200;
    public static int groupMaxN = 10;
    public static int participantGroupMaxN = 100;

    //PARTICIPANT DATA

    public int partN;
 
    public int partNpreselected = 0;
    public int itemNpreselected = 0;

    //public int partN2
    //{
    //    get
    //    {
    //        return this.partN;
    //    }
    //    set
    //    {
    //        this.partN = value;
    //    }
    //}

    public string[] participants = new string[partMaxN + 1];

    public string[] p_firstname = new string[partMaxN + 1];
    public string[] p_lastname = new string[partMaxN + 1];
    public string[] p_email = new string[partMaxN + 1];
    public string[] p_username = new string[partMaxN + 1];
    public string[] p_passname = new string[partMaxN + 1];
    public string[] p_var1 = new string[partMaxN + 1];
    public string[] p_var2 = new string[partMaxN + 1];
    public string[] p_var3 = new string[partMaxN + 1];
    public string[] p_var4 = new string[partMaxN + 1];
    public string[] p_var5 = new string[partMaxN + 1];
    public string[] p_jobfunction = new string[partMaxN + 1];
    public string[] p_organisation = new string[partMaxN + 1];
    public Guid[] p_participant_id = new Guid[partMaxN + 1];


    //ITEM DATA

    public int itemN;
    public int maxItemNinQuest;

    public string[] items = new string[itemMaxN + 1];
    public Guid[] itemGuids = new Guid[itemMaxN + 1];

    //GROUP DATA

    public int[,] groupsN = new int[partMaxN + 1, groupMaxN + 2];
    public int[, ,] groups2 = new int[partMaxN + 1, groupMaxN + 2, itemMaxN + 1];
    public string itemSortData = "";
    public string clusterNames = "";

    //POSITION DATA

    public Double[,] posMatrixRawX = new Double[partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrixRawY = new Double[partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrixRawDX = new Double[partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrixRawDY = new Double[partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrixRawMX = new Double[partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrixRawMY = new Double[partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrixRawUX = new Double[partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrixRawUY = new Double[partMaxN + 1, itemMaxN + 1];
    public string itemCoordDataX = "";
    public string itemCoordDataY = "";

    public Double[,] posMatrixT = new Double[2 * partMaxN + 1, itemMaxN + 1];
    public Double[,] posMatrix = new Double[itemMaxN + 1, itemMaxN + 1];

    //RATE DATA

    public int[, ,] rates = new int[partMaxN + 1, itemMaxN + 1, 5+1];
    public string[] itemRateData = new string[6];
 
    public string[,] clusterName = new string[partMaxN + 1, groupMaxN + 1];

    //SORT MATRIX

    public Double[,] sortMatrixRaw = new Double[itemMaxN + 1, itemMaxN + 1];
    public Double[,] sortMatrixRaw2 = new Double[itemMaxN + 1, itemMaxN + 1];
    public Double[,] sortMatrixInput = new Double[itemMaxN + 1, itemMaxN + 1];



    //EIGENVALUES ITEMS

    public static int dimensionN = 3;



    public double[] EigenValuesS = new double[itemMaxN + 1];
    public double[,] EigenVectorsS = new double[dimensionN + 1, itemMaxN + 1];
    public double[,] EigenVectorsW = new double[dimensionN + 1, itemMaxN + 1];
    public double[,] EigenVectorsFW = new double[dimensionN + 1, itemMaxN + 1];
    public double[] EigenValuesR = new double[itemMaxN + 1];
    public double[,] EigenVectorsR = new double[dimensionN + 1, itemMaxN + 1];

    public static int readFromEigenvaluesStart;

    //CLUSTERS

    public int[] sortAggrPN = new int[partMaxN + 1];

    public static int clusterSaveN2 = 20;

    public int[,] clusterItemN3 = new int[clusterSaveN2 + 1, itemMaxN + 1];
    public int[,] clusterItemN2 = new int[clusterSaveN2 + 1, itemMaxN + 1];
    public int[,] clusterItemN1 = new int[clusterSaveN2 + 1, itemMaxN + 1];
    public int[, ,] clusterItem3 = new int[clusterSaveN2 + 1, clusterSaveN2 + 1, itemMaxN + 1];
    public int[, ,] clusterItem2 = new int[clusterSaveN2 + 1, clusterSaveN2 + 1, itemMaxN + 1];
    public int[, ,] clusterItem1 = new int[clusterSaveN2 + 1, clusterSaveN2 + 1, itemMaxN + 1];


    //AGGREGATED RATES

    public double[,] ratesAggr = new double[itemMaxN + 1,5+1];
    public double[,] ratesSTDV = new double[itemMaxN + 1,5+1];
    public int[,] ratesAggrN = new int[itemMaxN + 1, 5 + 1];
    public int[,] ratesAggrPN = new int[partMaxN + 1, 5 + 1];
    //AGGREGATED CLUSTER RATES

  

    public double[,,] clusterRatesAggr1 = new double[clusterSaveN2 + 1, itemMaxN + 1,5+1];
    public int[, ,] clusterRatesAggrN1 = new int[clusterSaveN2 + 1, itemMaxN + 1, 5 + 1];
    public double[, ,] clusterRatesAggr2 = new double[clusterSaveN2 + 1, itemMaxN + 1, 5 + 1];
    public int[, ,] clusterRatesAggrN2 = new int[clusterSaveN2 + 1, itemMaxN + 1, 5 + 1];
    public double[, ,] clusterRatesAggr3 = new double[clusterSaveN2 + 1, itemMaxN + 1, 5 + 1];
    public int[, ,] clusterRatesAggrN3 = new int[clusterSaveN2 + 1, itemMaxN + 1, 5 + 1];

    //EIGENVALUES PARTICIPANTS (ITEMRATES * EIGENVALUES ITEMS)

    public double[,,] participantDimensionRates = new double[partMaxN + 1, dimensionN + 1,5+1];

    //EIGENVALUES PARTICIPANTS GROUPS (ITEMRATES * EIGENVALUES ITEMS)

    public double[,,] participantGroupsDimensionRates = new double[participantGroupMaxN + 1, dimensionN + 1,5+1];
    public string[] participantGroups = new string[participantGroupMaxN + 1];
    public int participantGroupsN = 0;
    public int participantGroupsMaxN = 50;
    public int[] participantGroupsNn = new int[participantGroupMaxN + 1];


    //EIGENVALUES PARTICIPANTS GROUP VARIABLES (ITEMRATES * EIGENVALUES ITEMS)

    public string[,] participantGroupsV = new string[7, partMaxN + 1];
    public int[] participantGroupsVN = new int[7];
    public int[,] participantGroupsVNn = new int[7, partMaxN + 1];

    public int[,] participantGroupsNr = new int[participantGroupMaxN + 1, partMaxN];
    public Boolean[,] participantGroupsSelected = new Boolean[7, participantGroupMaxN + 1];
    public Boolean[] participantPreSelected = new Boolean[partMaxN + 1];
    public Boolean[] participantSelected = new Boolean[partMaxN + 1];

    public Boolean[] varSelected = new Boolean[8];
    public Boolean[] itemPreSelected = new Boolean[itemMaxN + 1];
    public Boolean[] itemSelected = new Boolean[itemMaxN + 1];

     

    //EIGENVALUES CLUSTERNAMES (ITEMRATES * EIGENVALUES ITEMS)

    public double[, ,] participantDimensionClusterNames = new double[partMaxN + 1, groupMaxN + 1, dimensionN + 1];
    public double[,] clusterNamesDimScoresSelected = new double[2000 + 1, dimensionN + 1];

    //SELCTED (eigenvalues particpants,eigenvalues clusternames)

    public string[] clusterNamesSelected = new string[2000 + 1];
    public string[] clusterParticipantNamesSelected = new string[2000 + 1];
    public int nClusterNames = 0;

    //clusternames and dimension names defined in COncept MAP

    public int analysesInfo;
    public string mapSubTitle;
    public string mapClusterNames;
    public string mapDimensionNames;



    Utils ut = new Utils();
    UtilsDataStrings uts = new UtilsDataStrings();
    DataHandling dh = new DataHandling();
    AriadneUsers usr = new AriadneUsers();
    Cluster cl = new Cluster();

    public void deleteOldData()
    {

        for (int p = 1; p < partMaxN + 1; p++)
        {
            for (int g = 1; g < groupMaxN + 1; g++)
            {
                groupsN[p, g] = 0;
                clusterName[p, g] = "";
                for (int i = 1; i < itemMaxN + 1; i++)
                {
                    groups2[p, g, i] = 0;
                }
            }
        }
        for (int p = 1; p < partMaxN + 1; p++)
        {
            for (int i = 1; i < itemMaxN + 1; i++)
            {
                
                posMatrixRawX[p, i] = 0;
                posMatrixRawY[p, i] = 0;
            }
        }
        for (int r = 1; r < 5 + 1; r++)
        {
            for (int p = 1; p < partMaxN + 1; p++)
            {
                for (int i = 1; i < itemMaxN + 1; i++)
                {
                    rates[p, i, r] = 0;
                }
            }
        }
    }

    public void GetSelection(Guid projectId, Guid selectionId)
    {

        ArrayList selectionInfo = dh.GetSelection(projectId, selectionId);
        
        string selectionS = (string)selectionInfo[0];

        analysesInfo =(int)selectionInfo[1]  ;
        
        mapSubTitle = (string)selectionInfo[2];
        mapClusterNames = (string)selectionInfo[3];
        mapDimensionNames = (string)selectionInfo[4];

        int Pn = 0; ; int In = 0; int Cn = 0;
        for (int p = 1; p < partN + 1; p++)
        {
             participantPreSelected[p] = false;
        }
        Guid partIdNow;
        Pn = Convert.ToInt32(selectionS.Substring(0, 3));
        for (int pp = 1; pp < Pn + 1; pp++)
        {
            partIdNow = XmlConvert.ToGuid(selectionS.Substring(3 + (pp - 1) * 36, 36));
            for (int p = 1; p <  partN + 1; p++)
            {
                if ( p_participant_id[p] == partIdNow) {  participantPreSelected[p] = true; }
            }

        }
        for (int i = 1; i <  itemN + 1; i++)
        {
             itemPreSelected[i] = false;
        }
        Guid itemIdNow;
        In = Convert.ToInt32(selectionS.Substring(3 + Pn * 36, 3));
        for (int ii = 1; ii < In + 1; ii++)
        {
            itemIdNow = XmlConvert.ToGuid(selectionS.Substring(3 + Pn * 36 + 3 + (ii - 1) * 36, 36));
            for (int i = 1; i <  itemN + 1; i++)
            {
                if ( itemGuids[i] == itemIdNow) {  itemPreSelected[i] = true; }
            }
        }
        //for (int v = 1; v < 6 + 1; v++)
        //{

         //   participantGroupsVN[v]

        //    int test = Convert.ToInt32(selectionS.Substring(3 + Pn * 36 + 3 + In * 36 + (v - 1) * 1, 1));
        //    //if (varSelected[v] == true) { Vin += "1"; } else { Vin += "0"; }
        //}
        int totcatN = 0;
        for (int v = 1; v < 6 + 1; v++)
        {
            for (int c = 1; c <  participantGroupsVN[v] + 1; c++)
            {
                 participantGroupsSelected[v, c] = false;  
            }
            string selectedCat = "";
            Cn = 0;
            Cn = Convert.ToInt32(selectionS.Substring(3 + Pn * 36 + 3 + In * 36 + (v - 1) * 3 + totcatN * 50, 3));
            if (Cn > 0) { varSelected[v] = true; }
            for (int cc = 1; cc < Cn + 1; cc++)
            {
                selectedCat = selectionS.Substring(3 + Pn * 36 + 3 + In * 36 + 3 + (v - 1) * 3 + totcatN * 50, 50);
                totcatN += 1;
                for (int c = 1; c < participantGroupsVN[v] + 1; c++)   //7 0 !!!!
                {
                    if ( participantGroupsV[v, c].Trim() == selectedCat.Trim()) { participantGroupsSelected[v, c] = true; }

                }
            }


        }

    }

    public Guid saveSelection(Guid projectId, int analysesinfo, string subtitle, string clusterlabels, string dimensionlabels)
    {
        string Selection = "";
        string Pg = ""; string Ig = ""; string Vin = ""; string Cin = "";
        int Pn = 0; ; int In = 0; int Cn = 0;

        for (int p = 1; p < partN + 1; p++)
        {
            if (participantPreSelected[p] == true) { Pn += 1; Pg += XmlConvert.ToString(p_participant_id[p]); }
        }
        Selection += Pn.ToString("000", CultureInfo.InvariantCulture) + Pg;
        for (int i = 1; i < itemN + 1; i++)
        {
            if (itemPreSelected[i] == true) { In += 1; Ig += itemGuids[i]; };
        }
        Selection += In.ToString("000", CultureInfo.InvariantCulture) + Ig;
        for (int v = 1; v < 6 + 1; v++)
        {
            if (varSelected[v] == true) { Vin += "1"; } else { Vin += "0"; }
        }
        for (int v = 1; v < 6 + 1; v++)
        {
            Cin = ""; Cn = 0;
            for (int g = 1; g < participantGroupsVN[v] + 1; g++)
            {
                if (participantGroupsSelected[v, g] == true) { Cin += String.Format("{0,-50}",participantGroupsV[v, g]); Cn += 1; }
            }

            Selection += Cn.ToString("000", CultureInfo.InvariantCulture) + Cin;
        }

        Guid selectionId = dh.AddSelection(projectId, Selection, analysesinfo, subtitle, clusterlabels, dimensionlabels);
        return selectionId;

    }




    public StringBuilder GetBackupProjectFromFile(Guid XorganizerId, string[] data)
    {

        StringBuilder sb = new StringBuilder(); string t;

        try
        {


            int linNr = 0;

            string line = "";


            Guid XprojectIdNew = System.Guid.NewGuid();
            Guid[] PartipantGuid = new Guid[AriadneStatistics.partMaxN + 1];


            line = data[linNr];
            string[] values = line.Split(',');
            string projectname = values[0];



            linNr = 2;
            values = data[linNr].Split(',');

            itemN = Convert.ToInt32(values[0]);
            partN = Convert.ToInt32(values[1]);

            if (values[2].Trim() != "") { maxItemNinQuest = Convert.ToInt32(values[2]); } else {maxItemNinQuest = 0;}

            linNr = 3;

            values = data[linNr].Split(',');

            string rateName1 = "";
            string rateName2 = "";
            string rateName3 = "";
            string rateName4 = "";
            string rateName5 = "";

            if (values[0] == "variables")
            {
                values = data[linNr + 1].Split(',');
                if (values.Length > 5) { rateName1 = uts.BuildRateVar(values[0], values[1], values[2], values[3], values[4], values[5]); }
                values = data[linNr + 2].Split(',');
                if (values.Length > 5) { rateName2 = uts.BuildRateVar(values[0], values[1], values[2], values[3], values[4], values[5]); }
                values = data[linNr + 3].Split(',');
                if (values.Length > 5) { rateName3 = uts.BuildRateVar(values[0], values[1], values[2], values[3], values[4], values[5]); }
                values = data[linNr + 4].Split(',');
                if (values.Length > 5) { rateName4 = uts.BuildRateVar(values[0], values[1], values[2], values[3], values[4], values[5]); }
                values = data[linNr + 5].Split(',');
                if (values.Length > 5) { rateName5 = uts.BuildRateVar(values[0], values[1], values[2], values[3], values[4], values[5]); }
                linNr = 10;
            }
            else
            {
                linNr = 4;
            }

            dh.AddProject(XorganizerId, XprojectIdNew, projectname, "uploaded from csv file", rateName1, rateName2, rateName3, rateName4, rateName5, maxItemNinQuest);

            t = "Restore Phase 1: Empty project defined";
            t += "\r\n"; sb.Append(t); t = "";

            string[] StringSeparators = new string[] { "," };
            //  "Restore Phase 1"  "Empty project defined" 

            for (int i = 1; i < itemN + 1; i++)
            {
                //int ii = data[linNr].IndexOf(",\"");
                //string item = data[linNr].Substring(ii+1 , data[linNr].Length- (ii+1));
                values = data[linNr].Split(StringSeparators, StringSplitOptions.None);
                //values = data[linNr].Split(',');
                if (i == Convert.ToInt32(values[0]))
                {
                    items[i] = values[1];
                    itemGuids[i] = dh.AddNewItem(XprojectIdNew, items[i].Replace("\"", "").Trim());
                    //itemGuids[i] = dh.AddNewItem(XprojectIdNew, item.Replace("\"", "").Trim());
                    linNr += 1;
                }
                t = "Restore Phase 2: item added: " + items[i].Replace("\"", "").Trim();
                //t = "Restore Phase 2: item added: " + item.Replace("\"", "").Trim();
                t += "\r\n"; sb.Append(t); t = "";

            }
            // Restore Phase 1", text: "Items added to empty project" 

            linNr += 1;
            for (int p = 1; p < partN + 1; p++)
            {
                //values = data[linNr].Split(',');
                values = data[linNr].Split(StringSeparators, StringSplitOptions.None);
                if (p == Convert.ToInt32(values[0]))
                {
                    int nn = values.Length;
                    p_firstname[p] = values[1].Replace("\"", "").Trim();
                    if (nn > 2) p_lastname[p] = values[2].Replace("\"", "").Trim(); else p_lastname[p] = "";
                    if (nn > 3) p_email[p] = values[3].Replace("\"", "").Trim(); else p_email[p] = "";
                    if (nn > 4) p_username[p] = values[4].Replace("\"", "").Trim(); else p_username[p] = "";
                    if (nn > 5) p_passname[p] = values[5].Replace("\"", "").Trim(); else p_passname[p] = "";
                    if (nn > 6) p_var1[p] = values[6].Replace("\"", "").Trim(); else p_var1[p] = "";
                    if (nn > 7) p_var2[p] = values[7].Replace("\"", "").Trim(); else p_var2[p] = "";
                    if (nn > 8) p_var3[p] = values[8].Replace("\"", "").Trim(); else p_var3[p] = "";
                    if (nn > 9) p_var4[p] = values[9].Replace("\"", "").Trim(); else p_var4[p] = "";
                    if (nn > 10) p_var5[p] = values[10].Replace("\"", "").Trim(); else p_var5[p] = "";
                    if (nn > 11) p_jobfunction[p] = values[11].Replace("\"", "").Trim(); else p_jobfunction[p] = "";
                    if (nn > 12) p_organisation[p] = values[12].Replace("\"", "").Trim(); else p_organisation[p] = "";

                    //Guid Gname;  Gname = System.Guid.NewGuid();
                    // Guid Gpass;  Gpass = System.Guid.NewGuid();
                    //AriadneUsers.AddAriadneUser(XmlConvert.ToString(Gname), XmlConvert.ToString(Gpass), values[3], "user");


                    participants[p] = p_firstname[p] + " " + p_lastname[p];
                    string pass = XmlConvert.ToString(System.Guid.NewGuid());
                    string name = XmlConvert.ToString(System.Guid.NewGuid());
                    //test kinga// string result = usr.AddAriadneUser(name, pass, p_username[p], "user");
                    PartipantGuid[p] = dh.AddNewParticipantToCurrentProject(XprojectIdNew, name, pass, p_firstname[p], p_lastname[p], p_email[p], p_jobfunction[p], p_organisation[p], p_var1[p], p_var2[p], p_var3[p], p_var4[p], p_var5[p]);

                    t = "Restore Phase 3: participant added: " + p_firstname[p].Trim() + p_lastname[p].Trim();
                    t += "\r\n"; sb.Append(t); t = "";

                }
                linNr += 1;
            }
            linNr += 1;
            if (data.Length > linNr)
            {
                for (int p = 1; p < partN + 1; p++)
                {
                    for (int g = 1; g < AriadneStatistics.groupMaxN + 1; g++)
                    {
                        values = data[linNr].Split(',');
                        int pp = Convert.ToInt32(values[0]);
                        int gg = Convert.ToInt32(values[1]);
                        int nn = Convert.ToInt32(values[2]);
                        groupsN[p, g] = nn;
                        string gname = values[3].Replace("\"", "").Trim();
                        clusterName[p, g] = gname;
                        for (int c = 1; c < groupsN[p, g] + 1; c++)
                        {
                            groups2[p, g, c] = Convert.ToInt32(values[3 + c]);
                        }
                        linNr += 1;
                    }
                    dh.AddItemSortData(XprojectIdNew, PartipantGuid[p], uts.BuildSortString(p, itemN, AriadneStatistics.groupMaxN, groupsN, groups2, itemGuids), uts.BuildClusterNamesString(p, AriadneStatistics.groupMaxN, clusterName));
                    t = "Restore Phase 4: clusters added from: " + p_firstname[p].Trim() + p_lastname[p].Trim();
                    t += "\r\n"; sb.Append(t); t = "";
                }

                linNr += 1;
                for (int r = 1; r < 5 + 1; r++)
                {
                    values = data[linNr].Split(',');
                    if (values[0].Length < 10)
                    {
                        //if (values[0].Substring(0, 11) != "participant")
                        //{
                        for (int p = 1; p < partN + 1; p++)
                        {
                            values = data[linNr].Split(',');
                            int pp = Convert.ToInt32(values[0]);


                            for (int i = 1; i < itemN + 1; i++)
                            {
                                int rate = Convert.ToInt32(values[i]);
                                if (AriadneStatistics.maxRate >= rate)
                                {
                                    rates[p, i, r] = rate;

                                }
                            }

                            dh.AddItemRateData(XprojectIdNew, PartipantGuid[p], uts.BuildRateString(p, itemN, rates, itemGuids, AriadneStatistics.maxRate, r), r);
                            linNr += 1;
                            t = "Restore Phase 5: rate added from: " + p_firstname[p].Trim() + p_lastname[p].Trim() + " rate: " + r.ToString();
                            t += "\r\n"; sb.Append(t); t = "";
                        }
                    }

                    //}
                }
                linNr += 1; int even = 0; int ppp = 0;
                if (partN <=200) {
                for (int p = 1; p < partN * 2 + 1; p++)
                {
                    values = data[linNr].Split(',');
                    int pp = Convert.ToInt32(values[0]);

                    if (.5 * p == (int)(.5 * p))
                    {
                        even = 1;
                    }
                    else
                    {
                        even = 0;
                        ppp += 1;
                    }
                    for (int i = 1; i < itemN + 1; i++)
                    {


                        double position = Convert.ToDouble(values[i]);

                        if (even == 0) posMatrixRawX[ppp, i] = position;
                        if (even == 1) posMatrixRawY[ppp, i] = position;

                    }

                    if (even == 0) { dh.AddItemPosDataX(XprojectIdNew, PartipantGuid[ppp], uts.BuildPosString(ppp, itemN, posMatrixRawX, posMatrixRawY, itemGuids, "x")); }
                    if (even == 1) { dh.AddItemPosDataY(XprojectIdNew, PartipantGuid[ppp], uts.BuildPosString(ppp, itemN, posMatrixRawX, posMatrixRawY, itemGuids, "y")); }
                    linNr += 1;
                    if (p <= partN)
                    {
                        if (even == 1) { t = "Restore Phase 6: coordinates added from: " + p_firstname[p].Trim() + p_lastname[p].Trim() + " x coordinates: "; }
                        if (even == 0) { t = "Restore Phase 6: coordinates added from: " + p_firstname[p].Trim() + p_lastname[p].Trim() + " y coordinates: "; }
                        t += "\r\n"; sb.Append(t); t = "";
                    }
                }
                }
                
            }
            t = "Restore SUCCESFULL";
            t += "\r\n"; sb.Append(t); t = "";

            return sb;
        }
        catch (Exception ex)
        {
            t = "ERROR: " + ex.Message;
            t += "\r\n"; sb.Append(t); t = "";
            return sb;
        }
    }


    public   int getData(Guid projectId,Boolean select)
    {
        DataHandling dh = new DataHandling();

        deleteOldData();

        ArrayList projectInfo = dh.EditProject(projectId);

        maxItemNinQuest = (int)projectInfo[9];

        ArrayList itemlist = dh.SelectAllItems(projectId);
        itemNpreselected = itemlist.Count / 2;
        int[] itemsNewNr = new int[itemMaxN + 1];

        if (select == true)
        {
            for (int i = 0; i < itemlist.Count / 2; i++)
            {
                itemSelected[i + 1] = true;
                if (itemPreSelected[i + 1] != true)
                {
                    itemSelected[i + 1] = false;
                }
            }
        }
        else
        {
            itemN = itemlist.Count / 2;
            for (int i = 0; i < itemlist.Count / 2; i++)
            {
                itemSelected[i + 1] = true;
            }
        }
        int ii = 0;
        for (int i = 0; i < itemlist.Count / 2; i++)
        {
            itemsNewNr[i + 1] = 0;
            if (itemSelected[i + 1] == true)
            {
                ii += 1;
                itemsNewNr[i + 1] = ii;
            }
        }

        for (int i = 0; i < itemlist.Count / 2; i++)
        {
            if (itemsNewNr[i + 1] != 0)
            {
                //items[itemsNewNr[i + 1]] = (string)itemlist[1 + i * 2];
                items[itemsNewNr[i + 1]] = ((string)itemlist[1 + i * 2]).Trim();
                itemGuids[itemsNewNr[i + 1]] = (Guid)itemlist[i * 2];
            
                itemN = itemsNewNr[i + 1];
            }
        }

       
          ArrayList itemdatalist = dh.GetAllData2(projectId);
        int pii = 0;

        if (select == true)
        {
            for (int ri = 0; ri < itemdatalist.Count; ri += 10)
            {


                pii += 1;

                participantSelected[pii] = true;
                for (int v = 1; v < 6 + 1; v++)
                {
               
                    //participantGroupsN = 0;
                    for (int c = 1; c < participantGroupsVN[v] + 1; c++)
                    {

                        if (participantGroupsSelected[v, participantGroupsNr[v,pii]] != true)
                        {
                            participantSelected[pii] = false;
                        }
                    }
                }

                for (int p = 1; p < AriadneStatistics.partMaxN + 1; p += 1)
                {
                    if (participantPreSelected[pii] != true)
                    {
                        participantSelected[pii] = false;
                    }
                }
            }

        }
        else
        {
            for (int p = 1; p < AriadneStatistics.partMaxN + 1; p += 1)
            {
                 participantSelected[p] = true;
            }
        }
        partN = 0; int pi = 0; pii = 0;



        for (int ri = 0; ri < itemdatalist.Count; ri += 10)
        {

            pii += 1;

            if (participantSelected[pii] == true)
            {

                pi += 1;

                Guid partId = (Guid)itemdatalist[ri + 0];
                itemSortData = (string)itemdatalist[ri + 1];
                itemRateData[1] = (string)itemdatalist[ri + 2];
                itemCoordDataX = (string)itemdatalist[ri + 3];
                itemCoordDataY = (string)itemdatalist[ri + 4];
                clusterNames = (string)itemdatalist[ri + 5];
                itemRateData[2] = (string)itemdatalist[ri + 6];
                itemRateData[3] = (string)itemdatalist[ri + 7];
                itemRateData[4] = (string)itemdatalist[ri + 8];
                itemRateData[5] = (string)itemdatalist[ri + 9];

                //PARTICIPANTS FIELDS
                ArrayList partlist = dh.GetParticipant2(partId);
                if (partlist.Count > 0)
                {
                    p_firstname[pi] = ((string)partlist[0]).Trim();
                    p_lastname[pi] = ((string)partlist[1]).Trim();
                    p_email[pi] = ((string)partlist[2]).Trim();
                    p_username[pi] = ((string)partlist[3]).Trim();
                    p_passname[pi] = ((string)partlist[4]).Trim();
                    p_var1[pi] = ((string)partlist[5]).Trim();
                    p_var2[pi] = ((string)partlist[6]).Trim();
                    p_var3[pi] = ((string)partlist[7]).Trim();
                    p_var4[pi] = ((string)partlist[8]).Trim();
                    p_var5[pi] = ((string)partlist[9]).Trim();
                    p_jobfunction[pi] = ((string)partlist[10]).Trim();
                    p_organisation[pi] = ((string)partlist[11]).Trim();
                    p_participant_id[pi] = ((Guid)partlist[12]);

                    participants[pi] = p_firstname[pi] + " " + p_lastname[pi];
                }
                else
                { p_firstname[pi] = "participant deleted!"; participants[pi] = "participant deleted!"; }
                if (p_participant_id[pi] != partId)
                {
                    //return 0;
                }

                //PARTICIPANTS DATA FIELDS
                //SORT
                int pos2 = 0; int ni = 0;
                int nSaved = 0;
                Guid guidNow = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
                if (itemSortData.Trim().Length >= 3)
                {
                    nSaved = Convert.ToInt32(itemSortData.Substring(0, 3));
                    for (int g = 1; g < groupMaxN + 1; g++)
                    {
                        groupsN[pi, g] = Convert.ToInt32(itemSortData.Substring(3 + (g - 1) * 2, 2));
                    }
                    pos2 = 0;
                    for (int g = 1; g < groupMaxN + 1; g++)
                    {
                        ni = 0;
                        for (int inow = 1; inow < groupsN[pi, g] + 1; inow++)
                        {

                            ///////////////////

                            string err = "";
                            try
                            {
                                Guid guidTest = XmlConvert.ToGuid(itemSortData.Substring(3 + groupMaxN * 2 + pos2 * 36, 36));
                            }
                            catch (Exception ex)
                            {
                                err = ex.Message;
                            }

                            ///////////////////

                            if (err == "")
                            {
                                //if (3 + groupMaxN * 2 + pos2 * 36 + 36 <= itemSortData.Length)
                                //{
                                guidNow = XmlConvert.ToGuid(itemSortData.Substring(3 + groupMaxN * 2 + pos2 * 36, 36));

                                //}
                                for (int i = 0; i < itemlist.Count / 2; i++)
                                {
                                    if (itemsNewNr[i + 1] != 0)
                                    {
                                        if (guidNow == itemGuids[itemsNewNr[i + 1]]) { ni += 1; groups2[pi, g, ni] = itemsNewNr[i + 1]; }
                                    }
                                }
                            }
                            pos2 += 1;

                        }
                        groupsN[pi, g] = ni;
                    }
                }


                //RATE
                nSaved = 0; ; int rateNow = 0;
                for (int r = 1; r < 5 + 1; r++)
                {
                    if (itemRateData[r].Trim().Length > 0)
                    {

                        string err = "";
                        try
                        {
                            nSaved = Convert.ToInt32(itemRateData[r].Substring(0, 3));
                        }
                        catch (Exception ex)
                        {
                            err = ex.Message;
                        }
                        if (err == "")
                        {
                            nSaved = Convert.ToInt32(itemRateData[r].Substring(0, 3));
                            for (int inow = 0; inow < nSaved; inow++)
                            {

                                ///////////////////
                                rateNow = 0;
                                err = "";
                                try
                                {
                                    Guid guidTest = XmlConvert.ToGuid(itemRateData[r].Substring(3 + inow * 38, 36));
                                    int rateTest = Convert.ToInt32(itemRateData[r].Substring(3 + inow * 38 + 36, 2));
                                }
                                catch (Exception ex)
                                {
                                    err = ex.Message;
                                }

                                ///////////////////

                                if (err == "")
                                {

                                    guidNow = XmlConvert.ToGuid(itemRateData[r].Substring(3 + inow * 38, 36));
                                    rateNow = Convert.ToInt32(itemRateData[r].Substring(3 + inow * 38 + 36, 2));
                                    for (int i = 0; i < itemlist.Count / 2; i++)
                                    {
                                        if (itemsNewNr[i + 1] != 0)
                                        {
                                            if (guidNow == itemGuids[itemsNewNr[i + 1]]) { rates[pi, itemsNewNr[i + 1], r] = rateNow; }

                                        }
                                    }
                                }
                            }
                        }
                    }

                }

                //  if (2 + i * 2 <= itemRateData.Length) { rates[pi, itemsNewNr[i + 1], r] = Convert.ToInt32(itemRateData.Substring(i * 2, 2)); } }


                //COORDINATES X and Y
                if (itemCoordDataX.Trim().Length > 0)
                {

                    nSaved = 0; ; double posNow = 0;
                    nSaved = Convert.ToInt32(itemCoordDataX.Substring(0, 3));
                    for (int inow = 0; inow < nSaved; inow++)
                    {
                        posNow = 0;
                        string err = "";
                        try
                        {
                            guidNow = XmlConvert.ToGuid(itemCoordDataX.Substring(3 + inow * 42, 36));
                            posNow = Convert.ToDouble(itemCoordDataX.Substring(3 + inow * 42 + 36, 6));
                        }
                        catch (Exception ex)
                        {
                            err = ex.Message;
                        }

                        ///////////////////

                        if (err == "")
                        {
                            guidNow = XmlConvert.ToGuid(itemCoordDataX.Substring(3 + inow * 42, 36));
                            posNow = Convert.ToDouble(itemCoordDataX.Substring(3 + inow * 42 + 36, 6));

                            for (int i = 0; i < itemlist.Count / 2; i++)
                            {
                                if (itemsNewNr[i + 1] != 0)
                                {
                                    if (guidNow == itemGuids[itemsNewNr[i + 1]]) { posMatrixRawX[pi, itemsNewNr[i + 1]] = posNow; }

                                }
                            }
                        }
                    }

                }
                if (itemCoordDataY.Length > 0)
                {
                    nSaved = 0; ; double posNow = 0;
                    nSaved = Convert.ToInt32(itemCoordDataY.Substring(0, 3));
                    for (int inow = 0; inow < nSaved; inow++)
                    {
                        posNow = 0;
                        string err = "";
                        try
                        {
                            guidNow = XmlConvert.ToGuid(itemCoordDataY.Substring(3 + inow * 42, 36));
                            posNow = Convert.ToDouble(itemCoordDataY.Substring(3 + inow * 42 + 36, 6));
                        }
                        catch (Exception ex)
                        {
                            err = ex.Message;
                        }

                        ///////////////////

                        if (err == "")
                        {
                            guidNow = XmlConvert.ToGuid(itemCoordDataY.Substring(3 + inow * 42, 36));
                            posNow = Convert.ToDouble(itemCoordDataY.Substring(3 + inow * 42 + 36, 6));

                            for (int i = 0; i < itemlist.Count / 2; i++)
                            {
                                if (itemsNewNr[i + 1] != 0)
                                {
                                    if (guidNow == itemGuids[itemsNewNr[i + 1]]) { posMatrixRawY[pi, itemsNewNr[i + 1]] = posNow; }

                                }
                            }
                        }
                    }

                }


                

                //CLUSTERNAMES           
                if (clusterNames.Length > 0)
                {
                    for (int g = 1; g < groupMaxN + 1; g++)
                    {
                        if (g * 90 <= clusterNames.Length)
                        {
                            clusterName[pi, g] = clusterNames.Substring((g - 1) * 90, 90);
                        }
                    }
                }

                //CLUSTERNAMES           
                if (clusterNames.Length > 0)
                {
                    for (int g = 1; g < groupMaxN + 1; g++)
                    {
                        string cname = "";
                        if (90 + (g - 1) * 90 <= clusterNames.Length)
                            cname = clusterNames.Substring((g - 1) * 90, 90);
                        clusterName[pi, g] = cname.Replace(",", " -"); ;
                    }
                }

                //ASSING partN
                partN = pi;
                if (select == false)
                {
                    partNpreselected = pi;
                }

            }

           
        }
        
       
        //computeMap(projectId);
        return 1;

    }


    public void outputData(Guid organizerId, Guid projectId, string ProjectName, string Version, string ratedef1, string ratedef2, string ratedef3, string ratedef4, string ratedef5)
    {


        String Day = DateTime.Now.Day.ToString();
        String Month = DateTime.Now.Month.ToString();
        String Year = DateTime.Now.Year.ToString();
        String Hour = DateTime.Now.Hour.ToString();
        String Minute = DateTime.Now.Minute.ToString();

        Version += " " + Month + "-" + Day + "-" + Year + " " + Hour + "-" + Minute;

        string dir = XmlConvert.ToString(organizerId);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;
        //if (createUserPathOrg(organizerId))
        if (Directory.Exists(pathOrg))
        {

            dataFileName = ProjectName + " " + Version + ".csv";
            dataFile = pathOrg + "/" + dataFileName;

            //using (StreamWriter outfile2 = new StreamWriter(dataFile))

            using (var sw = new StreamWriter(new FileStream(dataFile, FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8))

            {
                StringBuilder sb = new StringBuilder();


                //PROJECTNAME
                string tt = "";
                tt += ProjectName + " " + Version;
                sb.AppendLine(tt);

                // ITEM N and PARTICIPANT N

                tt = "";
                tt += "Item N, paticipant N, max per particpant N";
                sb.AppendLine(tt);

                tt = "";
                tt += itemN.ToString();
                tt += ",";
                tt += partN.ToString();
                tt += ",";
                tt += maxItemNinQuest.ToString();
                tt += ",";
                sb.AppendLine(tt);

                //VARIABLES

                tt = "";
                tt = "variables";
                sb.AppendLine(tt);


                ArrayList ratevar = uts.getRateVars(ratedef1); tt = "";
                if (ratevar.Count > 0)
                {
                    tt = ((string)ratevar[0]).Trim() + ",";
                    if (ratevar.Count > 1) { tt += ((string)ratevar[1]).Trim() + ","; };
                    if (ratevar.Count > 2) { tt += ((string)ratevar[2]).Trim() + ","; };
                    if (ratevar.Count > 3) { tt += ((string)ratevar[3]).Trim() + ","; };
                    if (ratevar.Count > 4) { tt += ((string)ratevar[4]).Trim() + ","; };
                    if (ratevar.Count > 5) { tt += ((string)ratevar[5]).Trim() + ","; };
                }
                sb.AppendLine(tt);

                ratevar = uts.getRateVars(ratedef2); tt = "";
                if (ratevar.Count > 0)
                {
                    tt = ((string)ratevar[0]).Trim() + ",";
                    if (ratevar.Count > 1) { tt += ((string)ratevar[1]).Trim() + ","; };
                    if (ratevar.Count > 2) { tt += ((string)ratevar[2]).Trim() + ","; };
                    if (ratevar.Count > 3) { tt += ((string)ratevar[3]).Trim() + ","; };
                    if (ratevar.Count > 4) { tt += ((string)ratevar[4]).Trim() + ","; };
                    if (ratevar.Count > 5) { tt += ((string)ratevar[5]).Trim() + ","; };
                }
                sb.AppendLine(tt);

                ratevar = uts.getRateVars(ratedef3); tt = "";
                if (ratevar.Count > 0)
                {
                    tt = ((string)ratevar[0]).Trim() + ",";
                    if (ratevar.Count > 1) { tt += ((string)ratevar[1]).Trim() + ","; };
                    if (ratevar.Count > 2) { tt += ((string)ratevar[2]).Trim() + ","; };
                    if (ratevar.Count > 3) { tt += ((string)ratevar[3]).Trim() + ","; };
                    if (ratevar.Count > 4) { tt += ((string)ratevar[4]).Trim() + ","; };
                    if (ratevar.Count > 5) { tt += ((string)ratevar[5]).Trim() + ","; };
                }
                sb.AppendLine(tt);

                ratevar = uts.getRateVars(ratedef4); tt = "";
                if (ratevar.Count > 0)
                {
                    tt = ((string)ratevar[0]).Trim() + ",";
                    if (ratevar.Count > 1) { tt += ((string)ratevar[1]).Trim() + ","; };
                    if (ratevar.Count > 2) { tt += ((string)ratevar[2]).Trim() + ","; };
                    if (ratevar.Count > 3) { tt += ((string)ratevar[3]).Trim() + ","; };
                    if (ratevar.Count > 4) { tt += ((string)ratevar[4]).Trim() + ","; };
                    if (ratevar.Count > 5) { tt += ((string)ratevar[5]).Trim() + ","; };
                }
                sb.AppendLine(tt);

                ratevar = uts.getRateVars(ratedef5); tt = "";
                if (ratevar.Count > 0)
                {
                    tt = ((string)ratevar[0]).Trim() + ",";
                    if (ratevar.Count > 1) { tt += ((string)ratevar[1]).Trim() + ","; };
                    if (ratevar.Count > 2) { tt += ((string)ratevar[2]).Trim() + ","; };
                    if (ratevar.Count > 3) { tt += ((string)ratevar[3]).Trim() + ","; };
                    if (ratevar.Count > 4) { tt += ((string)ratevar[4]).Trim() + ","; };
                    if (ratevar.Count > 5) { tt += ((string)ratevar[5]).Trim() + ","; };
                }
                sb.AppendLine(tt);

                //ITEMS

                tt = "";
                tt = "item number,item text";
                sb.AppendLine(tt);

                for (int i = 1; i < itemN + 1; i++)
                {
                    tt = "";
                    tt += i.ToString();
                    tt += ",\"";

                    string replaceWith = " ";
                    string itemremovedBreaks = items[i].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();

                    tt += itemremovedBreaks.Trim() + "\"";
                    sb.AppendLine(tt);

                }

                //PARTICIPANTS

                tt = "participant number,particpant name";
                sb.AppendLine(tt);
                for (int p = 1; p < partN + 1; p++)
                {
                    tt = "";
                    tt += p.ToString();


                    tt += ",\"";
                    tt +=   p_firstname[p]  ;
                    tt += "\",\"";
                    tt +=   p_lastname[p]  ;
                    tt += "\",\"";
                    tt +=   p_email[p]  ;
                    tt += "\",\"";
                    tt +=   p_username[p]  ;
                    tt += "\",\"";
                    tt +=   p_passname[p]  ;
                    tt += "\",\"";
                    tt +=   p_var1[p]  ;
                    tt += "\",\"";
                    tt +=   p_var2[p]  ;
                    tt += "\",\"";
                    tt +=   p_var3[p]  ;
                    tt += "\",\"";
                    tt +=  p_var4[p]  ;
                    tt += "\",\"";
                    tt +=  p_var5[p]  ;
                    tt += "\",\"";
                    tt +=   p_jobfunction[p]  ;
                    tt += "\",\"";
                    tt +=   p_organisation[p]  ;
                    tt += "\"";


                    sb.AppendLine(tt);

                }


                // public static int[,] groupsN = new int[partMaxN + 1, groupMaxN + 1];
                //public static int[, ,] groups2 = new int[partMaxN + 1, groupMaxN + 1, itemMaxN + 1];

                //tt = "SORT DATA";


                //for (int p = 1; p < partN + 1; p++)
                //{

                //    tt += p.ToString();
                //    tt += ",";
                //}
                //sb.AppendLine(tt);
                tt = "CLUSTER DATA : particpant number,cluster number, cluster N, cluster name";
                sb.AppendLine(tt);

                for (int p = 1; p < partN + 1; p++)
                {
                    //tt = "";
                    //tt +=  "participant,";
                    //tt += "cluster";

                    //for (int g = 1; g < groupMaxN + 1; g++)
                    //{
                    //    tt += g.ToString();
                    //    tt += ",";
                    //}
                    //sb.AppendLine(tt);

                    for (int g = 1; g < AriadneStatistics.groupMaxN + 1; g++)
                    {
                        tt = "";
                        tt += p.ToString();
                        tt += ",";
                        tt += g.ToString();
                        tt += ",";
                        tt +=  groupsN[p, g];
                        tt += ",\"";
                        string replaceWith = " ";;
                        string clusterremovedBreaks = clusterName[p, g].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim().Replace(",", " ").Trim();
                        tt += clusterremovedBreaks.Trim() +  "\"";
                        tt += ",";
                        for (int c = 1; c <  groupsN[p, g] + 1; c++)
                        {
                            tt +=  groups2[p, g, c];
                            tt += ",";


                        }
                        sb.AppendLine(tt);

                    }
                }


                tt = "RATE DATA ";

                tt += " : participant,";
                for (int i = 1; i <  itemN + 1; i++)
                {
                    tt += i.ToString();
                    tt += ",";
                }
                sb.AppendLine(tt);

                for (int r = 1; r < 5 + 1; r++)
                {
                    for (int p = 1; p <  partN + 1; p++)
                    {
                        tt = "";
                        tt += p.ToString();
                        tt += ",";
                        for (int i = 1; i <  itemN + 1; i++)
                        {
                            tt +=  rates[p, i, r];
                            tt += ",";
                        }
                        sb.AppendLine(tt);
                    }
                }


                tt = "SORT POSITIONS : participant,";
                for (int i = 1; i <  itemN + 1; i++)
                {
                    tt += i.ToString();
                    tt += ",";
                }
                sb.AppendLine(tt);


                for (int p = 1; p <  partN + 1; p++)
                {
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i <  itemN + 1; i++)
                    {
                        tt +=  posMatrixRawX[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                    tt = "";
                    tt += p.ToString();
                    tt += ",";
                    for (int i = 1; i <  itemN + 1; i++)
                    {
                        tt +=  posMatrixRawY[p, i];
                        tt += ",";
                    }
                    sb.AppendLine(tt);
                }



                //outfile2.Write(sb.ToString());
                sw.Write(sb.ToString());
                sb.Clear();

            }
        }
    }
    
     public  void getVars(){

   //int participantGroupMaxN = 100;
            
            string[] participantGroupsVar = new String[partMaxN + 1];
            int nn = 0;
            //int firstTime = 0;
            //int firstTimeEmpty = 1;
            int startNow = 0;
            //int participantGroupsN = 0;

            for (int v = 1; v < 6 + 1; v++)
            {
                participantGroupsVN[v] = 0;
                for (int p = 1; p <  partN + 1; p++)
                {
                    participantGroupsNr[v,p] = 0;

                    switch (v)
                    {
                        case 1:
                            if (p_jobfunction[p] != null) { int l = p_jobfunction[p].Trim().Length; if (l > 40) { l = 40; } participantGroupsVar[p] = p_jobfunction[p].Trim().ToLower().Substring(0, l); } else { participantGroupsVar[p] = "participant deleted"; }
                            break;
                        case 2:
                            if (p_var1[p] != null) { int l = p_var1[p].Trim().Length; if (l > 40) { l = 40; } participantGroupsVar[p] = p_var1[p].Trim().ToLower().Substring(0, l); } else { participantGroupsVar[p] = "participant deleted"; }
                            break;
                        case 3:
                            if (p_var2[p] != null) { int l = p_var2[p].Trim().Length; if (l > 40) { l = 40; } participantGroupsVar[p] = p_var2[p].Trim().ToLower().Substring(0, l); } else { participantGroupsVar[p] = "participant deleted"; }
                            break;
                        case 4:
                            if (p_var3[p] != null) { int l = p_var3[p].Trim().Length; if (l > 40) { l = 40; } participantGroupsVar[p] = p_var3[p].Trim().ToLower().Substring(0, l); } else { participantGroupsVar[p] = "participant deleted"; }
                            break;
                        case 5:
                            if (p_var4[p] != null) { int l = p_var4[p].Trim().Length; if (l > 40) { l = 40; } participantGroupsVar[p] = p_var4[p].Trim().ToLower().Substring(0, l); } else { participantGroupsVar[p] = "participant deleted"; }
                            break;
                        case 6:
                            if (p_var5[p] != null) { int l = p_var5[p].Trim().Length; if (l > 40) { l = 40; } participantGroupsVar[p] = p_var5[p].Trim().ToLower().Substring(0, l); } else { participantGroupsVar[p] = "participant deleted"; }
                            break;
                        default:
                            //Console.WriteLine("Default case");
                            participantGroupsVar[p] = "";
                            break;
                    }



                }
                for (int p = 1; p <  partN + 1; p++)
                {
                    participantGroupsVNn[v, p] = 0;
                    participantGroupsV[v, p] = "";
                }
                for (int g = 1; g < partN + 1; g++)
                {
                    startNow = 0;
                    for (int p = 1; p < partN + 1; p++)
                    {
                        if (participantGroupsNr[v,p] == 0)
                        {
                            startNow = p;
                            break;
                        }
                    }
                    if (startNow > 0)
                    {


                        participantGroupsVN[v] += 1;

                        participantGroupsV[v, participantGroupsVN[v]] = participantGroupsVar[startNow];
                        nn = 0;
                        //firstTime = 0;
                        for (int p = 1; p < partN + 1; p++)
                        {
                            if (participantGroupsVar[p] == participantGroupsV[v, participantGroupsVN[v]])
                            {
                                nn += 1;
                                participantGroupsNr[v, p] = participantGroupsVN[v];
                                 
                            }
                            //else
                            //{
                            //    if (firstTime == 0)
                            //    {
                            //        firstTime = 1;
                            //        firstTimeEmpty = p;
                            //    }
                            //}
                        }

                        participantGroupsVNn[v,g] = nn;
                        if (participantGroupsVar[startNow].Trim().ToLower() != "")
                        {
                            participantGroupsV[v, participantGroupsVN[v]] = "(n=" + nn.ToString("0", CultureInfo.InvariantCulture) + ") " + participantGroupsVar[startNow].Trim().ToLower();
                        }
                        else
                        {
                            string msg = "";
                            switch (v)
                            {
                                case 1:
                                    msg = "missing functions";
                                    break;
                                case 2:
                                    msg = "missing var1";
                                    break;
                                case 3:
                                    msg = "missing var2";
                                    break;
                                case 4:
                                    msg = "missing var3";
                                    break;
                                case 5:
                                    msg = "missing var4";
                                    break;
                                case 6:
                                    msg = "missing var5";
                                    break;
                                default:
                                    //Console.WriteLine("Default case");
                                    msg = "ERROR";
                                    break;
                            }
                            participantGroupsV[v, participantGroupsVN[v]] = "(n=" + nn.ToString("0", CultureInfo.InvariantCulture) + ") " + msg;
                        }
                        
                    }
                    //participantGroupsVN[v] = participantGroupsN;
                }
            }
}
    //SORT
    public    GeneralMatrix sort(int n)
    {
        double[][] M = new double[n][];
        for (int i = 0; i < n; i++)
        {
            M[i] = new double[n];
        }
        for (int i = 1; i < itemN + 1; i++)
        {
            for (int ii = 1; ii < itemN + 1; ii++)
            {
                M[i - 1][ii - 1] = sortMatrixInput[i, ii];
            }

        }
        return new GeneralMatrix(M);
    }

    public int computeMap(Guid projectId, int analysesInfo)
    {

       
        Boolean useSMSQisOne = false;

        if (analysesInfo == 0) {useSMSQisOne = false;} else {useSMSQisOne = true;}
         
        for (int p = 1; p < partN + 1; p++)
        {
            sortAggrPN[p] = 0;
            for (int g = 1; g < groupMaxN + 1; g++)
            {
                sortAggrPN[p] += groupsN[p, g];

               // if (sortAggrPN[p] > 112)
               // {
               //     int nn = 0;
               // }

            }
        }

          //COORDINATES

        for (int p = 1; p < partN + 1; p++)
        {
            double Hx = -9999; double Hy = -9999;
            double Lx = 9999; double Ly = 9999;
            double Tx = 0; double Ty = 0;
            double Vx = 0; double Vy = 0;
            int itn = 0;
            for (int i = 1; i < itemN + 1; i++)
            {
                if (posMatrixRawX[p, i] > 0 && rates[p, i,1] != 0) 
                {
                    if (posMatrixRawX[p, i] < Lx) Lx = posMatrixRawX[p, i];
                    if (posMatrixRawY[p, i] < Ly) Ly = posMatrixRawY[p, i];

                    if (posMatrixRawX[p, i] > Hx) Hx = posMatrixRawX[p, i];
                    if (posMatrixRawY[p, i] > Hy) Hy = posMatrixRawY[p, i];
                }
            }
            for (int i = 1; i < itemN + 1; i++)
            {
                if (posMatrixRawX[p, i] > 0 && rates[p, i,1] != 0)
                {
                    itn += 1;
                    posMatrixRawDX[p, i] = (posMatrixRawX[p, i] - Lx) / (Hx - Lx);
                    posMatrixRawDY[p, i] = (posMatrixRawY[p, i] - Ly) / (Hy - Ly);

                    Tx += posMatrixRawDX[p, i];
                    Ty += posMatrixRawDY[p, i];
                }
            }

            for (int i = 1; i < itemN + 1; i++)
            {
                if (posMatrixRawX[p, i] > 0 && rates[p, i,1] != 0)
                {
                    posMatrixRawMX[p, i] = posMatrixRawDX[p, i] - (Tx / itn);
                    posMatrixRawMY[p, i] = posMatrixRawDX[p, i] - (Ty / itn);

                    Vx += Math.Pow(posMatrixRawMX[p, i], 2);
                    Vy += Math.Pow(posMatrixRawMY[p, i], 2);
                }
            }
            for (int i = 1; i < itemN + 1; i++)
            {
                if (posMatrixRawX[p, i] > 0 && rates[p, i,1] != 0)
                {
                    posMatrixRawUX[p, i] = posMatrixRawMX[p, i] / Math.Pow(Vx, .5);
                    posMatrixRawUY[p, i] = posMatrixRawMX[p, i] / Math.Pow(Vy, .5);

                }
            }
        }
        for (int p = 1; p < partN + 1; p++)
        {
            for (int i = 1; i < itemN + 1; i++)
            {
                posMatrixT[p, i] += posMatrixRawUX[p, i];
            }

        }
        for (int p = 1; p < partN + 1; p++)
        {
            for (int i = 1; i < itemN + 1; i++)
            {
                posMatrixT[partN+ p, i] += posMatrixRawY[p, i];
            }

        }

        for (int i = 1; i < itemN + 1; i++)
            {
       
           double vv = 0;
           for (int p = 1; p <partN + 1; p++)
           {
                if (posMatrixRawX[p, i] > 0 && rates[p, i,1] != 0)
                {
                    vv += posMatrixT[p, i];
                }

            }
           for (int p = 1; p <  partN + 1; p++)
           {
                if (posMatrixRawX[p, i] > 0 && rates[p, i,1] != 0)
                {
                    posMatrixT[p, i] = posMatrixT[p, i] / vv;
                }

            }

        }

        for (int i = 1; i < itemN + 1; i++)
        {
            for (int ii = 1; ii < itemN + 1; ii++)
            {
                posMatrix[i, ii] = 0;
            }

        }
        for (int i = 1; i < itemN + 1; i++)
        {
            for (int ii = 1; ii < itemN + 1; ii++)
            {

                for (int pp = 1; pp < 2* partN + 1; pp++)
                {
                    posMatrix[i, ii] += posMatrixT[pp, i] * posMatrixT[pp, ii];
                }

            }
        }

        //SORT GROUPS
        for (int i = 1; i < itemN + 1; i++)
        {
            for (int ii = 1; ii < itemN + 1; ii++)
            {
                sortMatrixRaw[i, ii] = 0;
            }

        }
        for (int p = 1; p < partN + 1; p++)
        {
            for (int g = 1; g < groupMaxN + 1; g++)
            {
                for (int i = 1; i < groupsN[p, g] + 1; i++)
                {
                    for (int ii = 1; ii < groupsN[p, g] + 1; ii++)
                    {
                        //if (i != ii)
                        //{
                        sortMatrixRaw[groups2[p, g, ii], groups2[p, g, i]] += 1;
                        //}

                    }
                }

            }
        }
        //STRES TEST

        double stressTest = 0;  //KAN NOOIT KLOPPEN!!! geeft nauwelijks verschil in de sortmatrix
        if (stressTest > 0)
        {
 
            Random random = new Random();
            for (int p = 1; p < partN + 1; p++)
            {

                for (int i = 1; i < itemN + 1; i++)
                {

                    int randomNumber = random.Next(0, 10001);  //10000 not included
                    if (randomNumber < Convert.ToInt32(stressTest * 10001))
                    {

                        //for (int ii = 1; ii < itemN + 1; ii++)
                        //{
                        int iR1 = random.Next(1, itemN + 1);
                        int iR2 = random.Next(1, itemN + 1);
                        int iR3 = random.Next(1, itemN + 1);
                        int iR4 = random.Next(1, itemN + 1);

                        sortMatrixRaw[iR3, iR1] -= 1;
                        sortMatrixRaw[iR4, iR2] += 1;
                        //}

                    }

                }
            }
        }
                           


        int Method = -1;  


        if (Method == -2)
        {//method ELSE uit data2 (2007)  gebaseerd op CHI square logica
            double t = 0;
            int item_n = itemN;
            for (int i = 1; i < item_n + 1; i++)
            {
                for (int ii = 1; ii < item_n + 1; ii++)
                {
                    sortMatrixInput[i, ii] = 0;
                    //if (i == ii) sortMatrixRaw[i, ii] = 0;
                }
            }
            for (int i = 1; i < item_n + 1; i++)
            {
                for (int ii = 1; ii < item_n + 1; ii++)
                {
                    //  If i_nr <> j_nr Then t = t + smat(i_nr, j_nr)
                    if (i != ii) t += sortMatrixRaw[i, ii];
                }
            }
            //t = t / (contr_i ^ 2 - contr_i)
            t = t / (Math.Pow(item_n, 2) - item_n);
            for (int i = 1; i < item_n + 1; i++)
            {
                for (int ii = 1; ii < item_n + 1; ii++)
                {

                    //matrix(i, j) = (mx(i, j) - t) / (((mx(i, i) - t) ^ 0.5 * (mx(j, j) - t) ^ 0.5))
                    sortMatrixInput[i, ii] = (sortMatrixRaw[i,ii] -t) / (Math.Pow(sortMatrixRaw[i,i] - t, .5) * Math.Pow(sortMatrixRaw[ii, ii] - t, .5));
                }
            }
        }
        if (Method == -1)  //default method 1 uit data2 (2007) zelfde als method 1
        {
            double t, m, var;

            int item_n = itemN;

            for (int i = 1; i < item_n + 1; i++)
            {
                for (int ii = 1; ii < item_n + 1; ii++)
                {
                    sortMatrixInput[i, ii] = 0;
                    sortMatrixRaw2[i, ii] = 0;
                    //if (i == ii) sortMatrixRaw[i, ii] = 0;
                }
            }
            for (int i = 1; i < item_n + 1; i++)
            {
                                t = 0;
                m = 0;
                var = 0;
                 
                for (int ii = 1; ii < item_n + 1; ii++)
                {
                    // mx(i, j) = smat(i_nr, j_nr);
                    // t = t + mx(i, j) ;
                      
                    t += sortMatrixRaw[i, ii];
                   
                    
                }
                m = t / item_n;
                for (int ii = 1; ii < item_n + 1; ii++)
                {
                    //mx(i, j) = mx(i, j) - m
                    //var = var + mx(i, j) ^ 2
                    sortMatrixRaw2[i, ii] = sortMatrixRaw[i, ii] -m;
                    var += Math.Pow(sortMatrixRaw2[i, ii],2);
                 
                }
                for (int ii = 1; ii < item_n + 1; ii++)
                {
                    //If var > 0 Then mx(i, j) = mx(i, j) / var ^ 0.5
                    if (var > 0) sortMatrixRaw2[i, ii] = sortMatrixRaw2[i, ii] / Math.Pow(var,.5);
                }
            }

            for (int i = 1; i < item_n + 1; i++)
            {
                for (int ii = 1; ii < item_n + 1; ii++)
                {
                    for (int j  = 1; j  < item_n + 1; j ++)
                    {
                        //matrix(i, ii) = matrix(i, ii) + (mx(i, j) * mx(ii, j))
                        sortMatrixInput[i, ii] +=  sortMatrixRaw2[i, j] * sortMatrixRaw2[ii, j];
                    }
                }
            }



        }
        if (Method == 0) //basale methode waarin de matrix gedeeld wordt door de randtotalen
        {
            readFromEigenvaluesStart = 1;
            for (int i = 1; i < itemN + 1; i++)
            {
                for (int ii = 1; ii < itemN + 1; ii++)
                {
                    sortMatrixInput[i, ii] = sortMatrixRaw[i, ii];

                    //int randomNumber = random.Next(1, 5);
                    //sortMatrixInput[i, ii] = sortMatrixInput[i, ii] / (partN + randomNumber);

                    //sortMatrixInput[i, ii] = sortMatrixInput[i, ii] / partN;
                    sortMatrixInput[i, ii] = sortMatrixInput[i, ii] / Math.Pow(sortMatrixRaw[i, i] * sortMatrixRaw[ii, ii], .5);
                }

            }
        }
        if (Method == 1)
        {
            readFromEigenvaluesStart = 0;
            double t = 0; double m = 0; double var = 0;

            for (int i = 1; i < itemN + 1; i++)
            {
                for (int ii = 1; ii < itemN + 1; ii++)
                {
                    //  matrix(i, ii) = matrix(i, ii) + (mx(i, j) * mx(ii, j))
                    sortMatrixRaw2[i, ii] = 0;
                    sortMatrixInput[i, ii] = 0;
                }
            }

            for (int i = 1; i < itemN + 1; i++)
            {
                t = 0; m = 0; var = 0;
                for (int ii = 1; ii < itemN + 1; ii++)
                {
                    t += sortMatrixRaw[i, ii];
                }
                m = t / itemN;
                for (int ii = 1; ii < itemN + 1; ii++)
                {
                    sortMatrixRaw2[i, ii] = sortMatrixRaw[i, ii] - m;
                    var += Math.Pow(sortMatrixRaw2[i, ii], 2);
                }
                for (int ii = 1; ii < itemN + 1; ii++)
                {
                    if (var > 0) sortMatrixRaw2[i, ii] = sortMatrixRaw2[i, ii] / Math.Pow(var, .5);
                }
            }
            
            for (int i = 1; i < itemN + 1; i++)
            {

                for (int ii = 1; ii < itemN + 1; ii++)
                {
                    for (int j = 1; j < itemN + 1; j++)
                    {
                        //  matrix(i, ii) = matrix(i, ii) + (mx(i, j) * mx(ii, j))
                        sortMatrixInput[i, ii] += sortMatrixRaw2[i, j] * sortMatrixRaw2[ii, j];
                    }
                }
            }

        }
        //double[][] evals = { new double[] { 1.0, 1.0, 0.0, 0.0 }, new double[] { 1.0, 1.0, 2e-7, 0.0 }, new double[] { 0.0, -2e-7, 1.0, 1.0 }, new double[] { 0.0, 0.0, 1.0, 1.0 } };
        //GeneralMatrix A2 = new GeneralMatrix(evals);
        //EigenvalueDecomposition Eig2 = A2.Eigen();
        //GeneralMatrix D2 = Eig2.D;
        //GeneralMatrix V2 = Eig2.GetV();

        //EIGENVALUE DECOMPOSITION
        //GeneralMatrix MMMM = magic(3); 
        GeneralMatrix M = sort(itemN); //magic(itemN); 
        //GeneralMatrix MMM = sort(itemN); //magic(itemN); 

        EigenvalueDecomposition Eig = M.Eigen();
        GeneralMatrix D = Eig.D;
        GeneralMatrix V = Eig.GetV();

        double[][] EigenValues = D.ArrayCopy;
        double[][] EigenVectors = V.ArrayCopy;
        //SingularValueDecomposition Svd = MMM.SVD();
        //GeneralMatrix DD = Svd.S;
        //GeneralMatrix VV = Svd.GetV();
        //GeneralMatrix UU = Svd.GetU();

        //EigenvalueDecomposition E = new EigenvalueDecomposition(M.Add(M.Transpose()).Multiply(0.5));
        //EigenvalueDecomposition E = new EigenvalueDecomposition(M);
        //double[] EigenValues = E.RealEigenvalues;
        //SingularValueDecomposition E = new SingularValueDecomposition(M);

        //GeneralMatrix MM = E.GetV();
        //GeneralMatrix MMU = E.GetU();


        //TRANSLATE RESULTS



        //double[] EigenValuesR = new double[itemN + 1];
        //double[,] EigenVectorsR = new double[dimensionN + 1, itemN + 1];



        int plus = readFromEigenvaluesStart;
        for (int i = 1; i < itemN + 1; i++)
        {
            //clN[0, i] = 1;
            //clG[0, i, 1] = i;
            int pos = 0;
            EigenValuesR[itemN + 1 - (i + plus)] = EigenValues[i - 1][i - 1];
            EigenValuesS[itemN + 1 - (i + plus)] = EigenValues[i - 1][i - 1];
            for (int ii = itemN; ii > itemN - (dimensionN + plus); ii--)
            {
                pos += 1;
                EigenVectorsR[pos - plus, i] = EigenVectors[i - 1][ii - 1];
                EigenVectorsS[pos - plus, i] = EigenVectors[i - 1][ii - 1];
            }
        }
        //TIMES EIGENVALUE

        for (int d = 1; d < dimensionN + 1; d++)
        {
            for (int i = 1; i < itemN + 1; i++)
            {

                if (useSMSQisOne == false)
                {
                    EigenVectorsR[d, i] = EigenVectorsS[d, i] * Math.Pow(EigenValuesS[d], .5);  // SUMSQ= 1 : niet hetzelfde als vb versie (andere clustering):
                }
                else
                {
                    EigenVectorsR[d, i] = EigenVectorsS[d, i]; // SUMSQ= EIGENVALUE (bijna dezelfde clustering als in VB programma)
                }
                EigenVectorsS[d, i] = EigenVectorsS[d, i] * Math.Pow(EigenValuesS[d], .5);

            }
        }

        //CLUSTER

        for (int i = 1; i <= itemN; i++)
        {
            EigenVectorsFW[1, i] = EigenVectorsR[1, i] / Math.Pow(Math.Pow(EigenVectorsR[1, i], 2) + Math.Pow(EigenVectorsR[2, i], 2), .5);
            EigenVectorsFW[2, i] = EigenVectorsR[2, i] / Math.Pow(Math.Pow(EigenVectorsR[1, i], 2) + Math.Pow(EigenVectorsR[2, i], 2), .5);           
        }

        clusterItem1 = cl.cluster_hn_world_sorted(EigenVectorsFW, 2, itemN, clusterSaveN2);
        for (int c = 1; c < clusterSaveN2 + 1; c++)
        {
            for (int g = 1; g < c + 1; g++)
            {
               
                clusterItemN1[c, g] = clusterItem1[c, g, 0];
            }
        }

        clusterItem2 = cl.cluster_hn_world_sorted(EigenVectorsR, 2, itemN, clusterSaveN2);
        for (int c = 1; c < clusterSaveN2 + 1; c++)
        {
            for (int g = 1; g < c + 1; g++)
            {
                clusterItemN2[c, g] = clusterItem2[c, g, 0];
            }
        }



        for (int i = 1; i <= itemN; i++)
            {
                EigenVectorsW[1, i] = EigenVectorsR[1, i] / Math.Pow(Math.Pow(EigenVectorsR[1, i], 2) + Math.Pow(EigenVectorsR[2, i], 2) + Math.Pow(EigenVectorsR[3, i], 2), .5);
                EigenVectorsW[2, i] = EigenVectorsR[2, i] / Math.Pow(Math.Pow(EigenVectorsR[1, i], 2) + Math.Pow(EigenVectorsR[2, i], 2) + Math.Pow(EigenVectorsR[3, i], 2), .5);
                EigenVectorsW[3, i] = EigenVectorsR[3, i] / Math.Pow(Math.Pow(EigenVectorsR[1, i], 2) + Math.Pow(EigenVectorsR[2, i], 2) + Math.Pow(EigenVectorsR[3, i], 2), .5);
            }

        clusterItem3 = cl.cluster_hn_world_sorted(EigenVectorsW, dimensionN, itemN, clusterSaveN2);
        for (int c = 1; c < clusterSaveN2 + 1; c++)
        {
            for (int g = 1; g < c + 1; g++)
            {
                clusterItemN3[c, g] = clusterItem3[c, g, 0];
            }
        }
 
        //RATINGS PER ITEM
        for (int r = 1; r < 5 + 1; r++)
        {
            for (int i = 1; i < itemN + 1; i++)
            {
                ratesAggr[i, r] = 0;
                ratesSTDV[i, r] = 0;
                ratesAggrN[i, r] = 0;
            }
            for (int p = 1; p < partN + 1; p++)
            {
                ratesAggrPN[p, r] = 0;
            }
            for (int p = 1; p < partN + 1; p++)
            {

                for (int i = 1; i < itemN + 1; i++)
                {
                    if (rates[p, i,r] > 0 && rates[p, i,r] <= maxRate)
                    {
                        ratesAggr[i, r] += (double)rates[p, i,r];
                        ratesAggrN[i, r] += 1;
                        ratesAggrPN[p, r] += 1;
                    }
                }
            }

            for (int i = 1; i < itemN + 1; i++)
            {
                if (ratesAggrN[i, r] > 0)
                {
                    ratesAggr[i, r] = ratesAggr[i, r] / ratesAggrN[i, r];
                }
                else
                {
                    ratesAggr[i, r] = 0;
                }
            }

            //STDV


            for (int i = 1; i < itemN + 1; i++)
            {
                for (int p = 1; p < partN + 1; p++)
                {
                    if (rates[p, i,r] > 0 && rates[p, i,r] <= maxRate)
                    {
                        ratesSTDV[i,r] += Math.Pow(rates[p, i,r] - ratesAggr[i,r], 2);
                    }
                }
                ratesSTDV[i,r] = Math.Pow(ratesSTDV[i,r] / (ratesAggrN[i,r] - 1), .5);
            }
        }

        //CLUSTER RATINGS PER ITEM (2d circle)

        for (int r = 1; r < 5 + 1; r++)
        {
            for (int c = 1; c < clusterSaveN2 + 1; c++)
            {
                for (int g = 1; g < c + 1; g++)
                {
                    clusterRatesAggr1[c, g, r] = 0;
                    clusterRatesAggrN1[c, g, r] = 0;
                }
            }

            for (int p = 1; p < partN + 1; p++)
            {
                for (int c = 1; c < clusterSaveN2 + 1; c++)
                {
                    for (int g = 1; g < c + 1; g++)
                    {
                        for (int i = 1; i < itemN + 1; i++)
                        {
                            if (rates[p, clusterItem1[c, g, i], r] > 0 && rates[p, clusterItem1[c, g, i], r] <= maxRate)
                            {
                                clusterRatesAggr1[c, g, r] += rates[p, clusterItem1[c, g, i], r];
                                clusterRatesAggrN1[c, g, r] += 1;

                            }
                            //if (clusterItem[c, g, 0] > 0) {
                            //    int iii = clusterItem[c, g, 0];
                            //}
                        }
                    }
                }
            }

            for (int c = 1; c < clusterSaveN2 + 1; c++)
            {
                for (int g = 1; g < c + 1; g++)
                {

                    clusterRatesAggr1[c, g,r] = clusterRatesAggr1[c, g,r] / clusterRatesAggrN1[c, g,r];

                }
            }
        }

        //CLUSTER RATINGS PER ITEM (2d)
        for (int r = 1; r < 5 + 1; r++)
        {
            for (int c = 1; c < clusterSaveN2 + 1; c++)
            {
                for (int g = 1; g < c + 1; g++)
                {
                    clusterRatesAggr2[c, g, r] = 0;
                    clusterRatesAggrN2[c, g, r] = 0;
                }
            }
            for (int p = 1; p < partN + 1; p++)
            {
                for (int c = 1; c < clusterSaveN2 + 1; c++)
                {
                    for (int g = 1; g < c + 1; g++)
                    {
                        for (int i = 1; i < itemN + 1; i++)
                        {
                            if (rates[p, clusterItem2[c, g, i], r] > 0 && rates[p, clusterItem2[c, g, i], r] <= maxRate)
                            {
                                clusterRatesAggr2[c, g, r] += rates[p, clusterItem2[c, g, i], r];
                                clusterRatesAggrN2[c, g, r] += 1;
                            }

                            //if (clusterItem[c, g, 0] > 0) {
                            //    int iii = clusterItem[c, g, 0];
                            //}
                        }
                    }
                }
            }

            for (int c = 1; c < clusterSaveN2 + 1; c++)
            {
                for (int g = 1; g < c + 1; g++)
                {

                    clusterRatesAggr2[c, g, r] = clusterRatesAggr2[c, g, r] / clusterRatesAggrN2[c, g, r];

                }

            }
        }

        //CLUSTER RATINGS PER ITEM (3d)
        for (int r = 1; r < 5 + 1; r++)
        {
            for (int c = 1; c < clusterSaveN2 + 1; c++)
            {
                for (int g = 1; g < c + 1; g++)
                {
                    clusterRatesAggr3[c, g, r] = 0;
                    clusterRatesAggrN3[c, g, r] = 0;
                }
            }

            for (int p = 1; p < partN + 1; p++)
            {
                for (int c = 1; c < clusterSaveN2 + 1; c++)
                {
                    for (int g = 1; g < c + 1; g++)
                    {
                        for (int i = 1; i < itemN + 1; i++)
                        {
                            if (rates[p, clusterItem3[c, g, i], r] > 0 && rates[p, clusterItem3[c, g, i], r] <= maxRate)
                            {
                                clusterRatesAggr3[c, g, r] += rates[p, clusterItem3[c, g, i], r];
                                clusterRatesAggrN3[c, g, r] += 1;
                            }
                            //if (clusterItem[c, g, 0] > 0) {
                            //    int iii = clusterItem[c, g, 0];
                            //}
                        }
                    }
                }
            }


            for (int c = 1; c < clusterSaveN2 + 1; c++)
            {
                for (int g = 1; g < c + 1; g++)
                {

                    clusterRatesAggr3[c, g,r] = clusterRatesAggr3[c, g,r] / clusterRatesAggrN3[c, g,r];

                }
            }
        }
        //CORRELTAION CLUSTER RATINGS PER PERSON WITH EIGENVALUES

        for (int r = 1; r < 5 + 1; r++)
        {
            double np = 0; double tp = 0; double mp = 0; double varp = 0;
            double[] ratesUN = new double[itemMaxN + 1];
            for (int p = 1; p < partN + 1; p++)
            {
                np = 0; tp = 0; mp = 0; varp = 0;
                for (int i = 1; i < itemN + 1; i++)
                {
                    if (rates[p, i,r] > 0)
                    {
                        np += 1;
                        tp += (double)rates[p, i,r];
                    }
                }
                mp = tp / np;
                for (int i = 1; i < itemN + 1; i++)
                {
                    if (rates[p, i,r] > 0)
                    {
                        ratesUN[i] = (double)rates[p, i,r] - mp;
                        varp += Math.Pow(ratesUN[i], 2);
                    }
                }
                for (int i = 1; i < itemN + 1; i++)
                {
                    if (rates[p, i,r] > 0)
                    {
                        if (varp > 0) ratesUN[i] = ratesUN[i] / Math.Pow(varp, .5);
                    }
                }
                for (int i = 1; i < itemN + 1; i++)
                {
                    for (int d = 1; d < dimensionN + 1; d++)
                    {
                        participantDimensionRates[p, d,r] = 0;
                    }
                }
                for (int i = 1; i < itemN + 1; i++)
                {
                    for (int d = 1; d < dimensionN + 1; d++)
                    {
                        participantDimensionRates[p, d,r] += ratesUN[i] * EigenVectorsS[d, i] / Math.Pow(EigenValuesS[d], .5);
                    }
                }
            }
        }
         //CORRELTAION CLUSTER RATINGS PER GROUP OF PERSONS WITH EIGENVALUES


        for (int r = 1; r < 5 + 1; r++)
        {
            int[] participantGroupsNr2 = new int[partMaxN + 1];
            string[] participantGroupsVar = new String[partMaxN + 1];
            int nn = 0;
            //int firstTime = 0;
            //int firstTimeEmpty = 1;
            int startNow = 0;
            participantGroupsN = 0;

            for (int v = 1; v < 6 + 1; v++)
            {
                if (varSelected[v] == true)  
                {
                    for (int p = 1; p < partN + 1; p++)
                    {
                        participantGroupsNr2[p] = 0;

                        switch (v)
                        {
                            case 1:
                                if (p_jobfunction[p] == null) { p_jobfunction[p] = ""; }
                                participantGroupsVar[p] = p_jobfunction[p].Trim().ToLower();
                                break;
                            case 2:
                                if (p_var1[p] == null) { p_var1[p] = ""; }
                                participantGroupsVar[p] = p_var1[p].Trim().ToLower();
                                break;
                            case 3:
                                if (p_var2[p] == null) { p_var2[p] = ""; }
                                participantGroupsVar[p] = p_var2[p].Trim().ToLower();
                                break;
                            case 4:
                                if (p_var3[p] == null) { p_var3[p] = ""; }
                                participantGroupsVar[p] = p_var3[p].Trim().ToLower();
                                break;
                            case 5:
                                if (p_var4[p] == null) { p_var4[p] = ""; }
                                participantGroupsVar[p] = p_var4[p].Trim().ToLower();
                                break;
                            case 6:
                                if (p_var5[p] == null) { p_var5[p] = ""; }
                                participantGroupsVar[p] = p_var5[p].Trim().ToLower();
                                break;
                            default:
                                //Console.WriteLine("Default case");
                                participantGroupsVar[p] = "";
                                break;
                        }



                    }

                    for (int g = 1; g < participantGroupMaxN + 1; g++)
                    {
                        startNow = 0;
                        for (int p = 1; p < partN + 1; p++)
                        {

                            if (participantGroupsNr2[p] == 0)
                            {
                                startNow = p;
                                break;

                            }
                        }
                        if (startNow > 0)
                        {


                            participantGroupsN += 1;
                            for (int d = 1; d < dimensionN + 1; d++)
                            {
                                participantGroupsDimensionRates[participantGroupsN, d, r] = 0;
                            }
                            participantGroups[participantGroupsN] = participantGroupsVar[startNow];
                            nn = 0;
                            //firstTime = 0;
                            for (int p = 1; p < partN + 1; p++)
                            {
                                if (participantGroupsVar[p] == participantGroups[participantGroupsN])
                                {
                                    nn += 1;
                                    participantGroupsNr2[p] = 1;
                                    for (int d = 1; d < dimensionN + 1; d++)
                                    {
                                        participantGroupsDimensionRates[participantGroupsN, d, r] += participantDimensionRates[p, d, r];

                                    }
                                }
                                //else
                                //{
                                //    if (firstTime == 0)
                                //    {
                                //        firstTime = 1;
                                //        firstTimeEmpty = p;
                                //    }
                                //}
                            }
                            for (int d = 1; d < dimensionN + 1; d++)
                            {
                                participantGroupsDimensionRates[participantGroupsN, d, r] = participantGroupsDimensionRates[participantGroupsN, d, r] / nn;
                            }
                            participantGroupsNn[participantGroupsN] = nn;
                            if (participantGroupsVar[startNow].Trim().ToLower() != "")
                            {
                                participantGroups[participantGroupsN] = "(n=" + nn.ToString("0", CultureInfo.InvariantCulture) + ") " + participantGroupsVar[startNow].Trim().ToLower();
                            }
                            else
                            {
                                string msg = "";
                                switch (v)
                                {
                                    case 1:
                                        msg = "missing functions";
                                        break;
                                    case 2:
                                        msg = "missing var1";
                                        break;
                                    case 3:
                                        msg = "missing var2";
                                        break;
                                    case 4:
                                        msg = "missing var3";
                                        break;
                                    case 5:
                                        msg = "missing var4";
                                        break;
                                    case 6:
                                        msg = "missing var5";
                                        break;
                                    default:
                                        //Console.WriteLine("Default case");
                                        msg = "ERROR";
                                        break;
                                }
                                participantGroups[participantGroupsN] = "(n=" + nn.ToString("0", CultureInfo.InvariantCulture) + ") " + msg;
                            }

                        }
                    }
                }
            }
        }
         //CORRELTAION CLUSTERNAMES PER PERSON WITH EIGENVALUES

        nClusterNames = 0;


        for (int p = 1; p < partN + 1; p++)
        {
           for (int g = 1; g < groupMaxN + 1; g++)
            {
                string replaceWith = " ";
                string itemremovedBreaks =  clusterName[p, g].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();

                if (itemremovedBreaks != "" && itemremovedBreaks != null)
                {
                    double score = 0;
                    for (int d = 1; d < dimensionN + 1; d++)
                    {
                        participantDimensionClusterNames[p, g, d] = 0;
                    }
                    for (int gi = 1; gi < groupsN[p, g] + 1; gi++)
                    {

                        for (int d = 1; d < dimensionN + 1; d++)
                        {
                            //participantDimensionClusterNames[p,g, d] += groups2[p, g, i] * EigenVectorsS[d, i] / Math.Pow(EigenValuesS[d], .5);
                            participantDimensionClusterNames[p, g, d] += EigenVectorsS[d, groups2[p, g, gi]] / (Math.Pow(EigenValuesS[d], .5) * groupsN[p, g]);
                        }
                        
                       
                    }
                    for (int d = 1; d < dimensionN + 1; d++)
                    {

                        score += Math.Pow(participantDimensionClusterNames[p, g, d], 2);
                    }
                    score = Math.Pow(score, .5);
                    if (score > .12)
                    {
                        nClusterNames += 1;
                        clusterNamesSelected[nClusterNames] = itemremovedBreaks;
                        clusterParticipantNamesSelected[nClusterNames] = participants[p];
                        for (int d = 1; d < dimensionN + 1; d++)
                        {
                            clusterNamesDimScoresSelected[nClusterNames, d] = participantDimensionClusterNames[p, g, d];
                        }
                    }
                }
            }
        }

         

        
        return 1;

    }
     


}
 
   

 
