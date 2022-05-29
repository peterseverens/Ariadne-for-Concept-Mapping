using DotNetMatrix;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Class1
/// </summary>
public class tableUtils
{
    public string fileName = "";
    public String projectName = "";
    public int catN = 0;
    public int[,] burtMatrix = new int[99, 99];
    public int[] catSelect = new int[99];
    public string[] labels = new string[99];
    public string BM = "";
    public string LB = "";
    public string EV = "";
    public string ES = "";

    public void firstRun(string inputFileName, string outputFileName)
    {
         

        fileName = inputFileName;
        GetTable(inputFileName, outputFileName);
        //int catN = burtMatrix.GetLength(0); 

        BM = "";
        BM += String.Format(CultureInfo.InvariantCulture, "{0,10:0}", catN); 
        for (int i = 0; i < catN; i++)
        {

            for (int ii = i; ii < catN; ii++)
            {
                BM += String.Format(CultureInfo.InvariantCulture, "{0,10:0}", burtMatrix[i, ii]); 
            }
        }

        LB = "";
        string replaceWith = " ";
        string label = "";
        string itemremovedBreaks = "";
        for (int i = 0; i < catN; i++)
        {
            itemremovedBreaks = labels[i].Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\"", "").Trim();
            label = String.Format("{0,-100}", itemremovedBreaks.Trim());
            LB += label.Substring(0, 100);
        }

        for (int i = 0; i < catN; i++)
        {
            catSelect[i] = 1;
        }
        ES = "";
        for (int i = 0; i < catN; i++)
        {
            ES += String.Format(CultureInfo.InvariantCulture, "{0,1:0}", catSelect[i]);

        }
        Run();

    }

    public string nextRun( string selectData, string burtData)
    {
        catN = Convert.ToInt32(burtData.Substring(0, 10));
        for (int i = 0; i < catN; i++)
        {
            catSelect[i] = Convert.ToInt32(selectData.Substring(i, 1));
        }
        int ni = -1;
        for (int i = 0; i < catN; i++)
        {

            for (int ii = i; ii < catN; ii++)
            {
                ni += 1;
                burtMatrix[i, ii] = Convert.ToInt32(burtData.Substring(10 + ni * 10, 10));
                burtMatrix[ii, i] = Convert.ToInt32(burtData.Substring(10 + ni * 10, 10));
            }
        }
        for (int i = 0; i < catN; i++)
        {
            for (int ii = i; ii < catN; ii++)
            {
                burtMatrix[ii, i] = burtMatrix[i, ii];
            }
        }
        

        Run();

        return (EV);
    }

    public void Run(){

        int catNS = 0;
        for (int i = 0; i < catN; i++)
        {
            catNS += catSelect[i];
        }

        double[,] burtMatrixD = new double[catNS, catNS];
        int minCi = 0; int minCii = 0;
        for (int i = 0; i < catN; i++)
        {

            if (catSelect[i] == 1)
            {
                minCii = 0;
                for (int ii = 0; ii < catN; ii++)
                {
                    if (catSelect[ii] == 1)
                    {
                        burtMatrixD[i - minCi, ii - minCii] = burtMatrix[i, ii] / (Math.Pow(burtMatrix[i, i], .5) * Math.Pow(burtMatrix[ii, ii], .5));
                    }
                    else
                    {
                        minCii += 1;
                    }
                }
            }
            else
            {
                minCi += 1;
            }
        }
       

        GeneralMatrix M = sort(catNS,catNS, burtMatrixD);  

        EigenvalueDecomposition Eig = M.Eigen();
        GeneralMatrix D = Eig.D;
        GeneralMatrix V = Eig.GetV();

        double[][] EigenValues = D.ArrayCopy;
        double[][] EigenVectors = V.ArrayCopy;


        int dimensionN =2;
       
        Boolean useSMSQisOne = true;

        

        double[] EigenValuesS = new double[catN];
        double[,] EigenVectorsS = new double[dimensionN+1 , catN ];

        double[] EigenValuesR = new double[catN ];
        double[,] EigenVectorsR = new double[dimensionN, catN ];

        
        for (int i = 0; i < catNS ; i++)
        {

            int pos = 0;
            //EigenValuesR[catNS - 1 - i] = EigenValues[i][i];
            EigenValuesS[catNS - 1 - i] = EigenValues[i][i];
            for (int ii = catNS - 1; ii > catNS -(1+ dimensionN+1); ii--)
            {
                
                //EigenVectorsR[pos, i] = EigenVectors[i][ii];
                EigenVectorsS[pos, i] = EigenVectors[i][ii];
                pos += 1;
            }
        }
        //TIMES EIGENVALUE

        for (int d = 0; d < dimensionN ; d++)
        {
            int cMin = 0;
            for (int i = 0; i < catN ; i++)
            {

                if (catSelect[i] == 1)
                {
                    if (useSMSQisOne == false)
                    {
                        EigenVectorsR[d, i] = EigenVectorsS[d+1, i-cMin] * Math.Pow(EigenValuesS[d+1], .5);  // SUMSQ= 1 : niet hetzelfde als vb versie (andere clustering):
                    }
                    else
                    {
                        EigenVectorsR[d, i] = EigenVectorsS[d+1, i - cMin]; // SUMSQ= EIGENVALUE (bijna dezelfde clustering als in VB programma)
                    }
                    //EigenVectorsS[d, i] = EigenVectorsS[d+1, i - cMin] * Math.Pow(EigenValuesS[d+1], .5);
                }
                else
                {
                    EigenVectorsR[d, i] = 0;
                    cMin += 1;
                }
            }
            EigenValuesR[d] = EigenValuesS[d + 1];
        }

        EV = "";
 
        EV += dimensionN.ToString("0.0000", CultureInfo.InvariantCulture);
        EV += catN.ToString("0.0000", CultureInfo.InvariantCulture);

        
        for (int d = 0; d < dimensionN; d++)
        {
            EV+=  String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", EigenValuesR[d]);    


        }
        for (int d = 0; d < dimensionN; d++)
        {
            for (int i = 0; i < catN; i++)
            {
                EV += String.Format(CultureInfo.InvariantCulture, "{0,10:0.0000}", EigenVectorsR[d, i]);  
            }
        }

       
    }

    public GeneralMatrix sort(int n,int catNn,double[,] burtMatrixD)
    {
        double[][] M = new double[n][];
        for (int i = 0; i < n; i++)
        {
            M[i] = new double[n];
        }
        for (int i = 1; i < catNn + 1; i++)
        {
            for (int ii = 1; ii < catNn + 1; ii++)
            {
                M[i - 1][ii - 1] = burtMatrixD[i-1, ii-1];
            }

        }
        return new GeneralMatrix(M);
    }

    public void GetTable(string inputFileName, string outputFileName)
    {

        string[] data = File.ReadAllLines(inputFileName, Encoding.Default);

        int levelsN = 0;
        int rowsN = 0;
        int colsN = 0;

        int linNr = 0;

        string line = "";


        Guid XprojectIdNew = System.Guid.NewGuid();
        Guid[] PartipantGuid = new Guid[AriadneStatistics.itemMaxN + 1];


        line = data[linNr];
        string[] values = line.Split(',');
        string tableName = values[0];

        linNr += 1; values = data[linNr].Split(',');

        levelsN = Convert.ToInt32(values[0]);
        colsN = Convert.ToInt32(values[1]);
        rowsN = data.Count() - 3; Convert.ToInt32(values[1]);


        int[,] dataMatrix = new int[rowsN, colsN];
        String[] labelsC = new String[colsN];
        String[,] labelsR = new String[levelsN, 9];



        linNr += 1; values = data[linNr].Split(',');

        for (int c = 0; c < colsN; c++)
        {
            labelsC[c] = values[c + levelsN].Trim();
        }


        for (int rec = 0; rec < rowsN; rec++)
        {
            linNr += 1;
            values = data[linNr].Split(',');
            for (int l = 0; l < levelsN; l++)
            {
                labelsR[l, rec] = values[l].Trim();
            }
            for (int c = levelsN; c < colsN + levelsN; c++)
            {
                dataMatrix[rec, c - levelsN] = Convert.ToInt32(values[c]);
            }
        }

        // fill labels;

        String labelsRold = "";
        for (int l = 0; l < levelsN; l++)
        {
            labelsRold = "";
            for (int r = 0; r < rowsN; r++)
            {
                if (labelsR[l, r] != "") { labelsRold = labelsR[l, r]; } else { labelsR[l, r] = labelsRold; }
            }
        }

        //categorize labels
        String[,] labelsOrderdedC = new String[levelsN + 1, 99];
        int[] varCatN = new int[levelsN + 1];
        bool found = false;
        varCatN[0] = 0;
        for (int c = 0; c < colsN; c++)
        {
            found = false;

            for (int cc = 0; cc < varCatN[0]; cc++)
            {
                if (labelsC[c] == labelsOrderdedC[0, cc]) found = true;
            }
            if (found == false) { varCatN[0] += 1; labelsOrderdedC[0, varCatN[0] - 1] = labelsC[c]; }
        }

        for (int l = 0; l < levelsN; l++)
        {
            varCatN[l + 1] = 0;
            for (int rec = 0; rec < rowsN; rec++)
            {
                found = false;
                for (int r = 0; r < varCatN[l + 1]; r++)
                {
                    if (labelsR[l, rec] == labelsOrderdedC[l + 1, r]) found = true;
                }
                if (found == false) { varCatN[l + 1] += 1; labelsOrderdedC[l + 1, varCatN[l + 1] - 1] = labelsR[l, rec]; }
            }
        }
        //max and total categories
        int catMax = 0;  
        for (int l = 0; l < levelsN + 1; l++)
        {
            if (varCatN[l] > catMax) { catMax = varCatN[l]; }
            catN += varCatN[l];
        }
        int[, , ,] burtMatrixL = new int[levelsN + 1, levelsN + 1, catMax, catMax];
        

        //fill leveled burt matrix
        int[] rNr = new int[levelsN]; int cNr = 0;
        for (int rec = 0; rec < rowsN; rec++)
        {
            for (int c = 0; c < varCatN[0]; c++)
            {

                for (int cc = 0; cc < varCatN[0]; cc++)
                {
                    if (labelsC[c] == labelsOrderdedC[0, cc]) cNr = cc;
                }
                for (int l = 0; l < levelsN; l++)
                {
                    rNr[l] = 0;
                    for (int r = 0; r < varCatN[l + 1]; r++)
                    {
                        if (labelsR[l, rec] == labelsOrderdedC[l + 1, r]) rNr[l] = r;

                    }
                    burtMatrixL[0, l + 1, cNr, rNr[l]] += dataMatrix[rec, c];
                    burtMatrixL[l + 1, 0, cNr, rNr[l]] += dataMatrix[rec, c];
                }
                burtMatrixL[0, 0, cNr, cNr] += dataMatrix[rec, c];
                for (int l = 0; l < levelsN; l++)
                {
                    for (int ll = 0; ll < levelsN; ll++)
                    {
                        burtMatrixL[l + 1, ll + 1, rNr[l], rNr[ll]] += dataMatrix[rec, c];
                    }
                }
            }
        }
        //burtMatrix as input for analyses
        int cNow = -1; int ccNow = -1;
        for (int l = 0; l < levelsN + 1; l++)
        {
            for (int c = 0; c < varCatN[l]; c++)
            {

                cNow += 1; ccNow = -1;
                labels[cNow] = labelsOrderdedC[l, c];
                for (int ll = 0; ll < levelsN + 1; ll++)
                {
                    for (int cc = 0; cc < varCatN[ll]; cc++)
                    {
                        ccNow += 1;
                        burtMatrix[cNow, ccNow] = burtMatrixL[l, ll, c, cc];
                    }
                }
            }


        }
        //uitkomst niet symmetrisch.. hierna wel..
        for (int i = 0; i < catN; i++)
        {
            for (int ii = i; ii < catN; ii++)
            {
               burtMatrix[ii, i] = burtMatrix[i, ii];
            }
        }
        outputtable(outputFileName, catN, burtMatrix, labels);

         
    }

    
    public void outputtable(string fileName, int catN, int[,] burtMatrix, string[] labels)
    {




        using (StreamWriter outfile = new StreamWriter(fileName))
        {
            StringBuilder sb = new StringBuilder();


            //PROJECTNAME
            string tt = "";
            tt += fileName;
            sb.AppendLine(tt);

            // ITEM N and PARTICIPANT N

            tt = ",";
            for (int c = 0; c < catN; c++)
            {
                tt += labels[c] + ",";
            }
            sb.AppendLine(tt);
            tt = "";
            for (int c = 0; c < catN; c++)
            {
                tt += labels[c] + ",";
                for (int cc = 0; cc < catN; cc++)
                {
                    tt += burtMatrix[c, cc].ToString() + ",";
                }
                sb.AppendLine(tt);
                tt = "";
            }
            outfile.Write(sb.ToString());
            sb.Clear();
        }

    }
     

    public void UploadDataFile(string fileName)
    {

        if (fileName.Trim() != "")
        {


            string fileNow = fileName.Trim();


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
}


