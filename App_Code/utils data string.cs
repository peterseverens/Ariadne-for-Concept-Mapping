using System;
using System.Collections.Generic;

//using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web.Security;
using System.Xml;
using System.Globalization;





public  class UtilsDataStrings
{

    public static Random random = new Random();

   
    //READ STRINGS

    public   int[,] getSortFromString(int itemN2, int groupMaxN, string itemSortData)
    {
        int[] groupsN = new int[groupMaxN + 1];
        int[,] groups2 = new int[groupMaxN + 1, itemN2 + 2];


        if (itemSortData.Length > 0)
        {
            for (int g = 1; g < groupMaxN + 1; g++)
            {
                groupsN[g] = Convert.ToInt32(itemSortData.Substring((g - 1) * 2, 2));
            }
            int pos = 0;

            int ni = 0;
            for (int g = 1; g < groupMaxN + 1; g++)
            {
                groups2[g, 0] = groupsN[g];
                for (int i = 1; i < groupsN[g] + 1; i++)
                {
                    ni += 1;
                    if (groupMaxN * 2 + 3 + (ni - 1) * 3 <= itemSortData.Length) groups2[g, i] = Convert.ToInt32(itemSortData.Substring(groupMaxN * 2 + pos * 3, 3));
                    pos += 1;
                }
            }
        }
        return groups2;
    }

    public int[] getRatesFromString(int itemN2, int groupMaxN, string itemRateData)
    {

        int[] rates2 = new int[itemN2 + 2];
        if (itemRateData.Length > 0)
        {
          
                for (int i = 1; i < itemN2 + 1; i++)
                {
                    if (2 + (i - 1) * 2 <= itemRateData.Length) rates2[i] = Convert.ToInt32(itemRateData.Substring((i - 1) * 2, 2));
                }

            

        }
        return rates2;
    }

    public   double[] getItemCoordinatesFromString(int itemN2, int groupMaxN, string itemCoordData)
    {
        double[] coord = new double[itemN2 + 2];

        if (itemCoordData.Length > 0)
        {
            for (int i = 1; i < itemN2 + 1; i++)
            {

                if (6 + (i - 1) * 6 <= itemCoordData.Length) coord[i] = Convert.ToDouble(itemCoordData.Substring((i - 1) * 6, 6));
             }
        }
        return coord;
    }

    public ArrayList getRateVars(string rateVarString)
    {

        ArrayList rateVar = new ArrayList();
        if (rateVarString.Length > 0 && rateVarString.Substring(0, 1) == "1")
        {
            rateVar.Add(rateVarString.Substring(3, 30).Trim());
            int nc = Convert.ToInt32(rateVarString.Substring(1, 2));
            {
                if (nc > 0) rateVar.Add(rateVarString.Substring(33, 30).Trim());
                if (nc > 1) rateVar.Add(rateVarString.Substring(63, 30).Trim());
                if (nc > 2) rateVar.Add(rateVarString.Substring(93, 30).Trim());
                if (nc > 3) rateVar.Add(rateVarString.Substring(123, 30).Trim());
                if (nc > 4) rateVar.Add(rateVarString.Substring(153, 30).Trim());
            }
        }
        return rateVar;
    }

    // BUILD STRINGS

    public string BuildItemString(int itemN,   ArrayList items)
    {
        string itemData = "";
        
        itemData= String.Format("{0:000}", itemN); //itemN.ToString();
        
        for (int i = 0; i < itemN; i++)
        {
            
            //itemData  += String.Format("{0,-100}", items[i]);
            
            string itemG = XmlConvert.ToString((Guid)items[2*i]);
            //string itemS = String.Format("{0,-100}", items[2 * i + 1]);
            //string itemS = String.Format("{0,-100}", ((string)items[2 * i + 1]).Trim());
            string item = ((string)items[2 * i + 1]).Trim();
            string replaceWith = " ";
            string itemremovedBreaks = item.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();
            string itemS = String.Format("{0,-100}", itemremovedBreaks.Trim()) ;
            itemData += itemG + itemS.Substring(0, 100);
        }

        return itemData;
    }

    public string BuildSortString(int p, int itemN, int groupMaxN, int[,] groupsN, int[, ,] groups2, Guid[] itemGuids)
    {

        string sort = "";
        sort += itemN.ToString("000", CultureInfo.InvariantCulture);
        for (int g = 1; g < groupMaxN + 1; g++)
        {
            sort += groupsN[p, g].ToString("00", CultureInfo.InvariantCulture);   ///NOG OGEDE FORMAT
        }


        for (int g = 1; g < groupMaxN + 1; g++)
        {
            for (int c = 1; c < groupsN[p, g] + 1; c++)
            {
                sort += XmlConvert.ToString(itemGuids[groups2[p, g, c]]);
                //sort += groups2[p, g, c].ToString("000", CultureInfo.InvariantCulture);
            }
        }

        return sort;
    }

    public string BuildClusterNamesString(int p, int groupMaxN, string[,] clusterName)
    {
        string names = "";

        for (int g = 1; g <  groupMaxN + 1; g++)
        {

            names += ( clusterName[p, g] + "                                                                                                              ").Substring(0, 90);

        }

        return names;
    }


    public string BuildRateString(int p, int itemN, int[, ,] rates, Guid[ ] itemGuids, int maxRate, int rateType)
    {
        string ratestring = "";
        ratestring += itemN.ToString("000", CultureInfo.InvariantCulture);
        for (int i = 1; i < itemN + 1; i++)
        {

            if (AriadneStatistics.maxRate >= rates[p, i, rateType])
            {

                ratestring += XmlConvert.ToString(itemGuids[i]);
                ratestring += rates[p, i, rateType].ToString("00", CultureInfo.InvariantCulture);
     
            }
        }

        return ratestring;
    }

    public string BuildPosString(int p, int itemN, double[,] posMatrixRawX, double[,] posMatrixRawY, Guid[] itemGuids, string xory)
    {
        string position = "";
        position += itemN.ToString("000", CultureInfo.InvariantCulture);
        for (int i = 1; i <  itemN + 1; i++)
        {
            position += XmlConvert.ToString(itemGuids[i]);
            if (xory == "x") position +=  posMatrixRawX[p, i].ToString("0.0000", CultureInfo.InvariantCulture);
            if (xory == "y") position +=  posMatrixRawY[p, i].ToString("0.0000", CultureInfo.InvariantCulture);

        }

        return position;
    }

    

   
    public string BuildRatesAggrString(double[,] ratesAggr, int[,] ratesAggrN, int itemN, int rateType)
    {
        string rates = "";
        for (int i = 1; i < itemN + 1; i++)
        {
            rates += ratesAggrN[i, rateType].ToString("000", CultureInfo.InvariantCulture) + ratesAggr[i, rateType].ToString("0.00", CultureInfo.InvariantCulture);
        }
        return rates;
    }


    public string BuildRateVar( string var, string c1, string c2, string c3, string c4, string c5)
    {
        int Ncat = 0;


        if (var.Trim() != "" && c1.Trim() != "") { Ncat = 1; }
        if (var.Trim() != "" && c2.Trim() != "") { Ncat = 2; }   
        if (var.Trim() != "" && c3.Trim() != "") { Ncat = 3; }
        if (var.Trim() != "" && c4.Trim() != "") { Ncat = 4; }
        if (var.Trim() != "" && c5.Trim() != "") { Ncat = 5; }

        string ratestring = "0" ;

        if (Ncat > 0)
        {
            ratestring = "1" + String.Format("{0,2}", Ncat.ToString());
            ratestring += String.Format("{0,30}", var.Trim());

            if (Ncat > 0) { ratestring += String.Format("{0,30}", c1.Trim()); }
            if (Ncat > 1) { ratestring += String.Format("{0,30}", c2.Trim()); }
            if (Ncat > 2) { ratestring += String.Format("{0,30}", c3.Trim()); }
            if (Ncat > 3) { ratestring += String.Format("{0,30}", c4.Trim()); }
            if (Ncat > 4) { ratestring += String.Format("{0,30}", c5.Trim()); }
        }
        return ratestring;

    }


   

     
}
             
     
 


 