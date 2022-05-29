using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Cluster
{

    //public static int partMaxN = 50;
    //public static int itemMaxN = 100;
    //public static int groupMaxN = 10;

    //public static int partN;
    //public static int itemN;
    //public static string[] items = new string[itemMaxN + 1];

    //public static int[,] groupsN = new int[partMaxN + 1, groupMaxN + 1];
    //public static int[, ,] groups2 = new int[partMaxN + 1, groupMaxN + 1, itemMaxN + 1];
    //public static string itemSortData = "";

    //public static int[,] sortMatrixRaw = new int[itemMaxN + 1, itemMaxN + 1];
    //public static Double[,] sortMatrixInput = new Double[itemMaxN + 1, itemMaxN + 1];

    //public static int dimensionN = 2;

    //public static int clusterSaveN = 10;
    //public static double[] EigenValuesS = new double[itemMaxN + 1];
    //public static double[,] EigenVectorsS = new double[dimensionN + 1, itemMaxN + 1];
    //public static double[,] clusterItemN = new double[clusterSaveN + 1, itemMaxN + 1];
    //public static double[, ,] clusterItem = new double[clusterSaveN + 1, clusterSaveN + 1, itemMaxN + 1];


    //CLUSTER PROCEDURE
    //public static int clusopl_n = 8;

    //public static double[,] cluq = new double[dimensionN + 1, itemMaxN + 1];  //(ndim, nrow)
 
    //public static double[] clumean = new double[dimensionN + 1];  //(nrow)  


    //public static double[,] Q = new double[dimensionN + 1, itemMaxN + 1]; //(clus_n,nrow)



    public  int clusterSeed(double[,] Q, int nrow, int n_dim, int clusopl_n)
    {

        int[,] clus = new int[n_dim + 1, clusopl_n + 1];
        int opnieuw = 0;
        int iter_n = 0;


        for (int clus_n = 2; clus_n <= clusopl_n; clus_n++)
        {


            ////ReDim center(ndim, clus_n)
            double[,] center = new double[n_dim + 1, clus_n + 1];

            for (int c = 1; c <= clus_n; c++)
            {
                for (int d = 1; d <= n_dim ; d++)
                {

                    center[d, c] = Q[d, c];
                }
            }

            int last_i = clus_n;

           
            double[,] dist = new double[clus_n, nrow];


            for (int iter = 1; iter <= 40; iter++)
            {
                for (int i = 1; i <= nrow; i++)
                {
                    for (int c = 1; c <= clus_n; c++)
                    {

                        dist[c, i] = Math.Pow((center[1, c] - Math.Pow(Q[i, 1], 2) + (center[2, c] - Math.Pow(Q[i, 2], 2))), 0.5);
                    }
                }


                for (int i = 1; i <= nrow; i++)
                {
                    double h = 100;

                    for (int c = 1; c <= clus_n; c++)
                    {
                        if (dist[c, i] < h)
                        {
                            clus[i, clus_n] = c;
                            h = dist[c, i];
                        }
                    }
                }

                //double[,] center = new double[n_dim+ 1,clus_n + 1];
                double[] ccn = new double[clus_n + 1];




                for (int i = 1; i <= nrow; i++)
                {
                    for (int d = 1; d <= n_dim; d++)
                    {

                        center[d, clus[i, clus_n]] = center[d, clus[i, clus_n]] + Q[i, d];
                    }
                    ccn[clus[i, clus_n]] = ccn[clus[i, clus_n]] + 1;
                    if (ccn[clus[i, clus_n]] == 0) opnieuw = 1; else opnieuw = 0;
                }
                for (int c = 1; c <= clus_n; c++)
                {

                    for (int d = 1; d <= n_dim; d++)
                    {

                        if (ccn[c] > 0)
                        {
                            center[d, c] = center[d, c] / ccn[c];
                        }
                        else
                        {
                            if (last_i < nrow) last_i += 1; else last_i = 1;
                            center[d, c] = Q[last_i, d];
                        }
                    }
                }

                iter_n += 1;
                if (opnieuw == 1 && iter_n < 100) iter -= 1;
            }
        }
        return 1;
    }

    //public static double[,] Iscore = new double[itemMaxN, dimensionN];
    //public static int[,] clusw = new int[itemMaxN, itemMaxN];

    public   int[,,] cluster_hn_world(double[,] Iscore, int ndim, int nrow, int clusterSaveN)
    {


     
        //HIERARCHICAL CLUSTERING 
        //int clusterSaveN = 10;

        double lowest;

        //LET OP :!! ITEM_S ERIN !!!!!


        double[,] cluqw = new double[ndim + 1, nrow + 1];
        double[,] distw = new double[nrow + 1, nrow + 1];
        double[] clumeanw = new double[ndim + 1];
        int arrayN = clusterSaveN;
        if (clusterSaveN < nrow) arrayN =nrow;
        int[,] clusw = new int[arrayN + 1, nrow + 1];
        int[, ,] clusterItem = new int[clusterSaveN + 1, clusterSaveN + 1, nrow + 1];

        for (int i = 1; i <= nrow; i++)
        {
            clusw[ nrow,i] = i;
        }
        //double[,] cluqw = (double[,])Iscore.Clone();
        for (int i = 1; i <= nrow; i++)
        {
            for (int d = 1; d <= ndim; d++)
            {
                cluqw[d, i] = Iscore[d, i];
                
            }
        }

        for (int clus_n = nrow; clus_n >= 2; clus_n--)
        {
            // clustersolution : " & Str$(clus_n) & " clusters 
            for (int i = 1; i <= nrow; i++)
            {
                for (int ii = i + 1; ii <= nrow; ii++)
                {
                    if (ndim == 2) distw[i, ii] = Math.Pow(Math.Pow(cluqw[1, i] - cluqw[1, ii], 2) + Math.Pow(cluqw[2, i] - cluqw[2, ii], 2), .5);
                    if (ndim == 3) distw[i, ii] = Math.Pow(Math.Pow(cluqw[1, i] - cluqw[1, ii], 2) + Math.Pow(cluqw[2, i] - cluqw[2, ii], 2) + Math.Pow(cluqw[3, i] - cluqw[3, ii], 2), .5);
                }
            }

            lowest = 10000;
            int lc = 0; int lcc = 0; int lccc = 0;

            for (int i = 1; i <= nrow; i++)
            {
                for (int ii = i + 1; ii <= nrow; ii++)
                {
                    if (clusw[clus_n, i] != clusw[clus_n, ii])
                    {
                        if (distw[i, ii] < lowest)
                        {
                            lowest = distw[i, ii];
                            lc = clusw[clus_n, i];
                            lcc = clusw[clus_n, ii];
                        }
                    }
                }
            }

            //clustergemiddelden van ind. items : NIET OP BEWAARDE AFSTANDEN (geen kopie van cluq)

            for (int d = 1; d <= ndim; d++)
            {

                int nni = 0; clumeanw[d] = 0;
                for (int i = 1; i <= nrow; i++)
                {
                    if (clusw[clus_n, i] == lc || clusw[clus_n, i] == lcc)
                    {
                        clumeanw[d] = clumeanw[d] + Iscore[d, i]; //cluqw(d, i)
                        nni = nni + 1;
                    }
                }
                clumeanw[d] = clumeanw[d] / nni;
            }

            if (lcc < lc)
            {
                lccc = lc; lc = lcc; lcc = lccc;
            }

            for (int i = 1; i <= nrow; i++)
            {
                if (clusw[clus_n, i] == lc || clusw[clus_n, i] == lcc)
                {
                    clusw[clus_n - 1, i] = lc;
                    for (int d = 1; d <= ndim; d++)
                    {
                        cluqw[d, i] = clumeanw[d];
                    }
                }
                else
                {
                    if (clusw[clus_n, i] < lcc) clusw[clus_n - 1, i] = clusw[clus_n, i];
                    if (clusw[clus_n, i] > lcc) clusw[clus_n - 1, i] = clusw[clus_n, i] - 1;
                }
            }
        }


        for (int c = 1; c <= clusterSaveN; c++)
        {
            for (int i = 1; i <= nrow; i++)
            {

                clusterItem[c, clusw[c, i], 0] += 1;
                clusterItem[c, clusw[c, i], clusterItem[c, clusw[c, i], 0]] = i;

            }

        }

        return clusterItem;
    }

    public int[, ,] cluster_hn_world_sorted(double[,] Iscore, int ndim, int nrow, int clusterSaveN)
    {

        var NrowOrClustersaveN = 0;

        if (clusterSaveN > nrow) { NrowOrClustersaveN = clusterSaveN; } else { NrowOrClustersaveN = nrow; }

        //HIERARCHICAL CLUSTERING 
        //int clusterSaveN = 10;

        double lowest;

        //LET OP :!! ITEM_S ERIN !!!!!


        double[,] cluqw = new double[ndim + 1, nrow + 1];
        double[,] distw = new double[nrow + 1, nrow + 1];
        double[] clumeanw = new double[ndim + 1];
        
        int arrayN = clusterSaveN;
        if (clusterSaveN < nrow) arrayN = nrow;
        int[,] clusw = new int[arrayN + 1, nrow + 1];
        int[, ,] clusterItem = new int[clusterSaveN + 1, clusterSaveN + 1, nrow + 1];
        int[,] clusterDevided = new int[NrowOrClustersaveN + 1, 3];
        string[,] clusterFingerprint = new string[clusterSaveN + 1,clusterSaveN + 1];

        for (int i = 1; i <= nrow; i++)
        {
            clusw[nrow, i] = i;
        }
        //double[,] cluqw = (double[,])Iscore.Clone();
        for (int i = 1; i <= nrow; i++)
        {
            for (int d = 1; d <= ndim; d++)
            {
                cluqw[d, i] = Iscore[d, i];

            }
        }

        for (int clus_n = nrow; clus_n >= 2; clus_n--)
        {
            // clustersolution : " & Str$(clus_n) & " clusters 
            for (int i = 1; i <= nrow; i++)
            {
                for (int ii = i + 1; ii <= nrow; ii++)
                {
                    if (ndim == 2) distw[i, ii] = Math.Pow(Math.Pow(cluqw[1, i] - cluqw[1, ii], 2) + Math.Pow(cluqw[2, i] - cluqw[2, ii], 2), .5);
                    if (ndim == 3) distw[i, ii] = Math.Pow(Math.Pow(cluqw[1, i] - cluqw[1, ii], 2) + Math.Pow(cluqw[2, i] - cluqw[2, ii], 2) + Math.Pow(cluqw[3, i] - cluqw[3, ii], 2), .5);
                }
            }

            lowest = 10000;
            int lc = 0; int lcc = 0; int lccc = 0;

            for (int i = 1; i <= nrow; i++)
            {
                for (int ii = i + 1; ii <= nrow; ii++)
                {
                    if (clusw[clus_n, i] != clusw[clus_n, ii])
                    {
                        if (distw[i, ii] < lowest)
                        {
                            lowest = distw[i, ii];
                            lc = clusw[clus_n, i];
                            lcc = clusw[clus_n, ii];
                        }
                    }
                }
            }

            //clustergemiddelden van ind. items : NIET OP BEWAARDE AFSTANDEN (geen kopie van cluq)

            for (int d = 1; d <= ndim; d++)
            {

                int nni = 0; clumeanw[d] = 0;
                for (int i = 1; i <= nrow; i++)
                {
                    if (clusw[clus_n, i] == lc || clusw[clus_n, i] == lcc)
                    {
                        clumeanw[d] = clumeanw[d] + Iscore[d, i]; //cluqw(d, i)
                        nni = nni + 1;
                    }
                }
                clumeanw[d] = clumeanw[d] / nni;
            }

            if (lcc < lc)
            {
                lccc = lc; lc = lcc; lcc = lccc;
            }
            //if (clus_n == 5)
            //{
            //    int weg = 1;
            //}
            for (int i = 1; i <= nrow; i++)
            {
                if (clusw[clus_n, i] == lc || clusw[clus_n, i] == lcc)
                {
                    clusw[clus_n - 1, i] = lc;
                    for (int d = 1; d <= ndim; d++)
                    {
                        cluqw[d, i] = clumeanw[d];
                    }
                }
                else
                {

                    if (clusw[clus_n, i] < lcc) clusw[clus_n - 1, i] = clusw[clus_n, i];
                    if (clusw[clus_n, i] > lcc) clusw[clus_n - 1, i] = clusw[clus_n, i] - 1;
                }
            }

            
            clusterDevided[clus_n, 1] = lc;
            clusterDevided[clus_n, 2] = lcc;

            //int clusterNow = 0;
            //for (int i = 1; i <= nrow; i++)
            //{
            //    clusterNow = clusw[clus_n, i];
            //    if (clusterNow <= lc) { }
            //    if (clusterNow > lc && clusterNow < lcc) { clusw[clus_n, i] = clusterNow + 1; }
            //    if (clusterNow == lcc) { clusw[clus_n, i] = lc + 1; }
            //    if (clusterNow > lcc) { }
            //}
        }


        for (int g = 1; g <= clusterSaveN; g++)
        {
            for (int c = 1; c <= nrow; c++)
            {

                clusterItem[g, clusw[g, c], 0] += 1;
                clusterItem[g, clusw[g, c], clusterItem[g, clusw[g, c], 0]] = c;
 
            }
            clusterItem[g, 0, 1] = clusterDevided[g, 1]  ;
            clusterItem[g, 0, 2] = clusterDevided[g, 2];
        }

        for (int g = 1; g <= clusterSaveN; g++)
        {
            for (int c = 1; c <= clusterSaveN; c++)
            {

                for (int i = 1; i <= clusterItem[g, c, 0]; i++)
                {
                    clusterFingerprint[g, c] += clusterItem[g, c, i].ToString("000", CultureInfo.InvariantCulture);
                }

            }
        }

        for (int g = 3; g <= clusterSaveN; g++)
        {
            for (int gg = g; gg > 1; gg--)
            {
                for (int c = 1; c <= g; c++)
                {
                    if (clusterFingerprint[gg, c] == clusterFingerprint[g-1, clusterDevided[g, 1]]) { clusterItem[g, 0, 3] = gg; clusterItem[g, 0, 4] = c; }
                }
            }
        }

        return clusterItem;
    }


    public int[, ,] cluster_hn_world_sorted_old(double[,] Iscore, int ndim, int nrow, int clusterSaveN)
    {



        //HIERARCHICAL CLUSTERING 
        //int clusterSaveN = 10;

        double lowest;

        //LET OP :!! ITEM_S ERIN !!!!!


        double[,] cluqw = new double[ndim + 1, nrow + 1];
        double[,] distw = new double[nrow + 1, nrow + 1];
        double[] clumeanw = new double[ndim + 1];
        int arrayN = clusterSaveN;
        if (clusterSaveN < nrow) arrayN = nrow;
        int[,] clusw = new int[arrayN + 1, nrow + 1];
        int[, ,] clusterItem = new int[clusterSaveN + 1, clusterSaveN + 1, nrow + 1];
        int[, ,] clusterItem2 = new int[clusterSaveN + 1, clusterSaveN + 1, nrow + 1];
        int[,] clusterDevided = new int[nrow + 1, 3];

        for (int i = 1; i <= nrow; i++)
        {
            clusw[nrow, i] = i;
        }
        //double[,] cluqw = (double[,])Iscore.Clone();
        for (int i = 1; i <= nrow; i++)
        {
            for (int d = 1; d <= ndim; d++)
            {
                cluqw[d, i] = Iscore[d, i];

            }
        }

        for (int clus_n = nrow; clus_n >= 2; clus_n--)
        {
            // clustersolution : " & Str$(clus_n) & " clusters 
            for (int i = 1; i <= nrow; i++)
            {
                for (int ii = i + 1; ii <= nrow; ii++)
                {
                    if (ndim == 2) distw[i, ii] = Math.Pow(Math.Pow(cluqw[1, i] - cluqw[1, ii], 2) + Math.Pow(cluqw[2, i] - cluqw[2, ii], 2), .5);
                    if (ndim == 3) distw[i, ii] = Math.Pow(Math.Pow(cluqw[1, i] - cluqw[1, ii], 2) + Math.Pow(cluqw[2, i] - cluqw[2, ii], 2) + Math.Pow(cluqw[3, i] - cluqw[3, ii], 2), .5);
                }
            }

            lowest = 10000;
            int lc = 0; int lcc = 0; int lccc = 0;

            for (int i = 1; i <= nrow; i++)
            {
                for (int ii = i + 1; ii <= nrow; ii++)
                {
                    if (clusw[clus_n, i] != clusw[clus_n, ii])
                    {
                        if (distw[i, ii] < lowest)
                        {
                            lowest = distw[i, ii];
                            lc = clusw[clus_n, i];
                            lcc = clusw[clus_n, ii];
                        }
                    }
                }
            }

            //clustergemiddelden van ind. items : NIET OP BEWAARDE AFSTANDEN (geen kopie van cluq)

            for (int d = 1; d <= ndim; d++)
            {

                int nni = 0; clumeanw[d] = 0;
                for (int i = 1; i <= nrow; i++)
                {
                    if (clusw[clus_n, i] == lc || clusw[clus_n, i] == lcc)
                    {
                        clumeanw[d] = clumeanw[d] + Iscore[d, i]; //cluqw(d, i)
                        nni = nni + 1;
                    }
                }
                clumeanw[d] = clumeanw[d] / nni;
            }

            if (lcc < lc)
            {
                lccc = lc; lc = lcc; lcc = lccc;
            }

            //eerst huidige (clus_n-1) sorteren

            for (int i = 1; i <= nrow; i++)
            {
                if (clusw[clus_n, i] == lc || clusw[clus_n, i] == lcc)
                {
                    clusw[clus_n - 1, i] = clus_n - 1; // lc;
                    for (int d = 1; d <= ndim; d++)
                    {
                        cluqw[d, i] = clumeanw[d];
                    }
                }
                else
                {
                    if (clusw[clus_n, i] < lc && clusw[clus_n, i] < lcc) clusw[clus_n - 1, i] = clusw[clus_n, i];
                    if (clusw[clus_n, i] > lc && clusw[clus_n, i] < lcc) clusw[clus_n - 1, i] = clusw[clus_n, i] - 1;
                    if (clusw[clus_n, i] > lcc) clusw[clus_n - 1, i] = clusw[clus_n, i] - 2;
                }
            }

            clusterDevided[clus_n, 1] = lc;
            clusterDevided[clus_n, 2] = lcc;

        }

        for (int c = 1; c <= clusterSaveN; c++)
        {
            for (int i = 1; i <= nrow; i++)
            {
                //clusterItem[c, clusw[c, i], 0] += 1;
                //clusterItem[c, clusw[c, i], clusterItem[c, clusw[c, i], 0]] = i;

                clusterItem2[c, clusw[c, i], 0] += 1;
                clusterItem2[c, clusw[c, i], clusterItem2[c, clusw[c, i], 0]] = i;
            }
        }

        var NextCLusterDevided = 0; var NextCLusterDevidedOld = 2;
        for (int c = 3; c <= clusterSaveN; c++)
        {

            NextCLusterDevided = -1;
            if (clusterDevided[c, 2] == c) NextCLusterDevided = c;
            if (clusterDevided[c, 2] < c || clusterDevided[c, 1] < c) NextCLusterDevided = c - 1;
            if (clusterDevided[c, 2] < c && clusterDevided[c, 1] < c) NextCLusterDevided = c - 2;

            //if (NextCLusterDevided == -1)
            //{
            //    int iii = 1;
            //}

            for (int g = 1; g <= c; g++)
            {
                if (g < NextCLusterDevidedOld)
                {
                    if (g < clusterDevided[c, 1]) { clusterItem[c, g, 0] = clusterItem2[c, g, 0]; };
                    //if (g == clusterDevided[c, 1]) { clusterItem[c, g, 0] = clusterItem2[c, g + 1, 0]; };
                    if (g >= clusterDevided[c, 1] && g < clusterDevided[c, 2] && g < clusterSaveN - 1) { clusterItem[c, g, 0] = clusterItem2[c, g + 1, 0]; };
                    if (g >= clusterDevided[c, 2] && g < clusterSaveN - 2) { clusterItem[c, g, 0] = clusterItem2[c, g + 2, 0]; };
                    if (g == c - 1) clusterItem[c, NextCLusterDevidedOld, 0] = clusterItem2[c, clusterDevided[c, 1], 0];
                    if (g == c - 0) clusterItem[c, NextCLusterDevidedOld + 1, 0] = clusterItem2[c, clusterDevided[c, 2], 0];

                    for (int i = 1; i < clusterItem[c, g, 0] + 1; i++)
                    {
                        if (g < clusterDevided[c, 1]) { clusterItem[c, g, i] = clusterItem2[c, g, i]; };
                        //if (g == clusterDevided[c, 1]) { clusterItem[c, g, i] = clusterItem2[c, g + 1, i]; };
                        if (g >= clusterDevided[c, 1] && g < clusterDevided[c, 2] && g < clusterSaveN - 1) { clusterItem[c, g, i] = clusterItem2[c, g + 1, i]; };
                        if (g >= clusterDevided[c, 2] && g < clusterSaveN - 2) { clusterItem[c, g, i] = clusterItem2[c, g + 2, i]; };
                        if (g == c - 1) clusterItem[c, NextCLusterDevidedOld, i] = clusterItem2[c, clusterDevided[c, 1], i];
                        if (g == c - 0) clusterItem[c, NextCLusterDevidedOld + 1, i] = clusterItem2[c, clusterDevided[c, 2], i];
                    }
                }
            }
            NextCLusterDevidedOld = NextCLusterDevided;
        }


        return clusterItem;
    }

    public  int[, ,] clusterHnew(double[,] EigenVectorsR, int ndim, int nrow, int clusterSaveN)
    {
        //int clusterSaveN = 10;
        //int[,] clusterItemN = new int[clusterSaveN + 1, nrow + 1];
        int[, ,] clusterItem = new int[clusterSaveN + 1, clusterSaveN + 1, nrow + 1];

        Double[,] dist = new Double[nrow + 1, nrow + 1];
        Double distL = 999; int iL = 0, iiL = 0;
        Double newX = 0; Double newY = 0;
        int minI = 0;  

        int clusterN = nrow;
        int clusterStep = 0;
        int[,] clN = new int[nrow + 1, nrow + 1];
        int[, ,] clG = new int[nrow + 1, nrow + 1, nrow + 1];

        for (int i = 1; i < nrow + 1; i++)
        {
            clN[0, i] = 1;
            clG[0, i, 1] = i;
        }
        do
        {


            distL = 9999;
            for (int i = 1; i < clusterN + 1; i++)
            {
                for (int ii = i + 1; ii < clusterN + 1; ii++)
                {
                    if (ndim==2) dist[i, ii] = Math.Pow(EigenVectorsR[1, i] - EigenVectorsR[1, ii], 2) + Math.Pow(EigenVectorsR[2, i] - EigenVectorsR[2, ii], 2);
                    if (ndim == 3) dist[i, ii] = Math.Pow(EigenVectorsR[1, i] - EigenVectorsR[1, ii], 2) + Math.Pow(EigenVectorsR[2, i] - EigenVectorsR[2, ii], 2) + Math.Pow(EigenVectorsR[3, i] - EigenVectorsR[3, ii], 2);
                    if (dist[i, ii] < distL)
                    {
                        distL = dist[i, ii]; iL = i; iiL = ii;
                    }
                }
            }

            newX = (EigenVectorsR[1, iL] + EigenVectorsR[1, iiL]) / 2;  //ONGEWOGEN
            newY = (EigenVectorsR[2, iL] + EigenVectorsR[2, iiL]) / 2;

            //newX = EigenVectorsR[1, iL] - (EigenVectorsR[1, iL] - EigenVectorsR[1, iiL]) / 2;  //ONGEWOGEN
            //newY = EigenVectorsR[2, iL] - (EigenVectorsR[2, iL] - EigenVectorsR[2, iiL]) / 2;
            //newX = EigenVectorsR[1,iL] - ((EigenVectorsR[1,iL] - EigenVectorsR[1,iiL]) * clN[clusterStep, iiL] / (clN[clusterStep, iL] + clN[clusterStep, iiL])); //GEWOGEN
            //newY = EigenVectorsR[2,iL] - ((EigenVectorsR[2,iL] - EigenVectorsR[2,iiL]) * clN[clusterStep, iiL] / (clN[clusterStep, iL] + clN[clusterStep, iiL]));

            minI = 0;  
            for (int i = 1; i < clusterN + 1; i++)
            {
                clN[clusterStep + 1, i - minI] = clN[clusterStep, i];
                for (int c = 1; c < clN[clusterStep, i] + 1; c++)
                {
                    clG[clusterStep + 1, i - minI, c] = clG[clusterStep, i, c];
                }
                if (i == iL || i == iiL) minI += 1;
            }
            for (int d = 1; d < ndim + 1; d++)
            {
                minI = 0;
                for (int i = 1; i < clusterN + 1; i++)
                {
                    EigenVectorsR[d, i - minI] = EigenVectorsR[d, i];

                    if (i == iL || i == iiL) minI += 1;
                }
            }

            clusterStep += 1;
            clusterN -= 1;
            EigenVectorsR[1, clusterN] = newX; EigenVectorsR[2, clusterN] = newY;

            clN[clusterStep, clusterN] = clN[clusterStep - 1, iL] + clN[clusterStep - 1, iiL];
            for (int c = 1; c < clN[clusterStep - 1, iL] + 1; c++)
            {
                clG[clusterStep, clusterN, c] = clG[clusterStep - 1, iL, c];
            }
            for (int c = 1; c < clN[clusterStep - 1, iiL] + 1; c++)
            {
                clG[clusterStep, clusterN, c + clN[clusterStep - 1, iL]] = clG[clusterStep - 1, iiL, c];
            }


        } while (clusterN != 1);

        //for (int s = 1; s < nrow + 1; s++)
        //{
        //    for (int c = 1; c < clN[clusterStep - 1, iiL] + 1; c++)
        //    {
                //clG[s, c, 0] = clN[s, c];  //STORE CLUSTER N PER CLUSTER IN ZERO
        //    }
        //}

        //int[] cln4 = new int[4 ];
        //int[,] cl4 = new int[4, itemN + 1];
        //for (int c = 1; c < 4; c++)
        //{
        //    cln4[c ] = clN[57, c];   //bij 58 items twee clusters , by 59 1 ckuster
        //    for (int i = 0; i < itemN+1; i++)
        //    {
        //        cl4[ c, i]= clG[57, c, i];
        //    }
        //}


        for (int c = 1; c < clusterSaveN + 1; c++)
        {
            for (int g = 1; g < c + 1; g++)
            {
                //clusterItemN[c, g] = clN[nrow - c, g];
                clusterItem[c, g, 0] = clN[nrow - c, g];
                //if (clusterItem[c, g, 0] > 0)
                //{
                //    int iii = clusterItem[c, g, 0];
                //}
                //for (int i = 1; i < clusterItemN[c, g] + 1; i++)
                for (int i = 1; i < clusterItem[c, g, 0] + 1; i++)
                {
                    clusterItem[c, g, i] = clG[nrow - c, g, i];
                }
            }

        }

        return clusterItem;

    }
}
 
 