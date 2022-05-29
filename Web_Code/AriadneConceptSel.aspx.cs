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


//using System.Collections.Generic;

 

public partial class ariadneConceptSel : System.Web.UI.Page
{

    //string[] items = new string[6];

    //ArrayList items;
  
 

    int NrateVar = 1;

    Guid Activeorganizer;
    Guid ActiveProject;
    Guid ActiveParticipant;

    string subtitle = "";

    //int dimensionN = 3;
    //int clusterSaveN = 18;

    public string pathPro = "";
    public string pathOrg = "";
    public string pathOrgArp = "";



    System.Web.UI.WebControls.CheckBox[,] varcatc = new CheckBox[9, AriadneStatistics.partMaxN];
    System.Web.UI.WebControls.Label[,] varcatcr = new Label[12, AriadneStatistics.partMaxN];
     DataHandling dh = new DataHandling();
    Utils ut = new Utils();
    UtilsDataStrings uts = new UtilsDataStrings();

    AriadneStatistics arst = new AriadneStatistics();  //WORDT OVERSCHREVEN NA REFRESH!!


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["project"] != null)
        {
            Activeorganizer = XmlConvert.ToGuid(Request.QueryString["organizer"]);
            ActiveProject = XmlConvert.ToGuid(Request.QueryString["project"]);


            GetDataNotSelected();

            //if (!Page.IsPostBack)
            //{
            int analysesinfo = 0;
            if (eigenTreatment.Checked == false) { analysesinfo = 0; } else { analysesinfo = 1; }
                int result = arst.computeMap(ActiveProject, analysesinfo);
                projectName.Text = GetProjectName() + " (Pn= " + arst.partN.ToString() + ") " + " (In= " + arst.itemN.ToString() + ")";
            //}
            buildChecks2();
            
 
        }
 
        if (Request.QueryString["organizer"] != null)
        {
            Guid Activeorganizer = XmlConvert.ToGuid(Request.QueryString["organizer"]);
        }

    } 

    protected void buildChecks2()
    {
        int m = 30;
        int h = 14;
        int hm = 3;
        int Lvar = 160;
        int Lpart = 300;
        int Litem = 400;
        int Lcat = 100;
        int hpar = 40;

        int endPosvars = 0;
        int endPosvars2 = 0;
       
        projectName.Style.Add("position", "absolute");
        projectName.Style.Add("top", m.ToString() + "px");
        projectName.Style.Add("Left", m.ToString() + "px");

        int vv = 1;

        subtitlelabel.Style.Add("Font-Size", "12px");
        subtitlelabel.Style.Add("position", "absolute");
        subtitlelabel.Style.Add("top", (m  ).ToString() + "px");
        subtitlelabel.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");

        vv = 1;
        subtitletext.Style.Add("Font-Size", "12px");
        subtitletext.Style.Add("position", "absolute");
        subtitletext.Style.Add("top", (h + m  ).ToString() + "px");
        subtitletext.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");

        vv = 3;
        eigenTreatment.Style.Add("Font-Size", "12px");
        eigenTreatment.Style.Add("position", "absolute");
        eigenTreatment.Style.Add("top", (h + m  ).ToString() + "px");
        eigenTreatment.Style.Add("left", (3 * m + (vv - 1) * (Lvar + m)).ToString() + "px");

        Line0.Text = "";
        // Line1.Style.Add("Font-Size", "12px");
        Line0.Style.Add("position", "absolute");
        Line0.Style.Add("top", (h + m + hpar * .8).ToString() + "px");
        Line0.Style.Add("left", m.ToString() + "px");
        Line0.Height = 0;
        Line0.Width = 1480;
        Line0.BorderWidth = 2;

        vv = 1;
        v1.Style.Add("Font-Size", "12px");
        v1.Style.Add("position", "absolute");
        v1.Style.Add("top", (hpar + h + m).ToString() + "px");
        v1.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");
        vv = 2;
        v2.Style.Add("Font-Size", "12px");
        v2.Style.Add("position", "absolute");
        v2.Style.Add("top", (hpar + h + m).ToString() + "px");
        v2.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");
        vv = 3;
        v3.Style.Add("Font-Size", "12px");
        v3.Style.Add("position", "absolute");
        v3.Style.Add("top", (hpar + h + m).ToString() + "px");
        v3.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");
        vv = 4;
        v4.Style.Add("Font-Size", "12px");
        v4.Style.Add("position", "absolute");
        v4.Style.Add("top", (hpar + h+m).ToString() + "px");
        v4.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");
        vv = 5;
        v5.Style.Add("Font-Size", "12px");
        v5.Style.Add("position", "absolute");
        v5.Style.Add("top", (hpar + h + m).ToString() + "px");
        v5.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");
        vv = 6;
        v6.Style.Add("Font-Size", "12px");
        v6.Style.Add("position", "absolute");
        v6.Style.Add("top", (hpar + h + m).ToString() + "px");
        v6.Style.Add("left", (m + (vv - 1) * (Lvar + m)).ToString() + "px");

        

        //Panel.Width = m+6 * (m + l);
        //Panel.Height = 200;

        for (int v = 1; v < 6 + 1; v++)
        {
            
            varcatc[v, 0] = new CheckBox();

            //varcatc[v, 0].Attributes.Add("runat","server");
            //varcatc[v, g].ID = "sfgs";
            varcatc[v, 0].Text = "show in map";
            varcatc[v, 0].Height = h;
            varcatc[v, 0].Width = Lvar;

            varcatc[v, 0].BorderWidth = 0;
            //varcat[v, g].ImageUrl = "objecticonfetchsized.ashx?sizew=260&sizeh=350&IconId=" & AllObjects.Item((4 * i) + 2).ToString
            varcatc[v, 0].Style.Add("position", "absolute");
            varcatc[v, 0].Style.Add("top", (hpar + h + m +   m ).ToString() + "px");
            varcatc[v, 0].Style.Add("left", (m + (v - 1) * (Lvar + m)).ToString() + "px");
            //varcat[v, g].ToolTip = "check checkmark";
            varcatc[v, 0].Visible = true;

            varcatc[v, 0].Checked = true;
            varcatc[v, 0].Style.Add("Font-Size", "12px");

            selectionsForm.Controls.Add(varcatc[v, 0]);
        }

        for (int v = 1; v < 6 + 1; v++)
        {

             
            for (int g = 1; g < arst.participantGroupsVN[v] + 1; g++)
            {

                int posNowY = hpar + h + m + m + m +  (g - 1) * (h + hm);

                //checkbox
                varcatc[v, g] = new CheckBox();

                //varcatc[v, g].ID = "sfgs";
                varcatc[v, g].Text = arst.participantGroupsV[v, g];
                varcatc[v, g].Height = h;
                varcatc[v, g].Width = Lvar;

                varcatc[v, g].BorderWidth = 0;
                //varcat[v, g].ImageUrl = "objecticonfetchsized.ashx?sizew=260&sizeh=350&IconId=" & AllObjects.Item((4 * i) + 2).ToString
                varcatc[v, g].Style.Add("position", "absolute");
                varcatc[v, g].Style.Add("top", (posNowY).ToString() + "px");
                varcatc[v, g].Style.Add("left", (m + (v - 1) * (Lvar + m)).ToString() + "px");
                //varcat[v, g].ToolTip = "check checkmark";
                varcatc[v, g].Visible = true;

                varcatc[v, g].Checked = true;

                varcatc[v, g].Style.Add("Font-Size", "10px");

                selectionsForm.Controls.Add(varcatc[v, g]);
                
                
                if (posNowY > endPosvars)  endPosvars = posNowY;
            }
        }
        Line1.Text = "";
        // Line1.Style.Add("Font-Size", "12px");
        Line1.Style.Add("position", "absolute");
        Line1.Style.Add("top", (endPosvars + hpar * .8).ToString() + "px");
        Line1.Style.Add("left", m.ToString() + "px");
        Line1.Height = 0;
        Line1.Width = 1480;
        Line1.BorderWidth = 2;

        vv = 7;
        v7.Style.Add("position", "absolute");
        v7.Style.Add("top", (endPosvars + hpar ).ToString() + "px");
        //v7.Style.Add("left", (m + (vv - 1) * (l + lm)).ToString() + "px");
        v7.Style.Add("left", (m  ).ToString() + "px");
        v7.Style.Add("Font-Size", "12px");
       
        for (int p = 1; p < arst.partNpreselected + 1; p++)
        {
            int v = 7;
            //checkbox
            varcatc[v, p] = new CheckBox();

            //varcatc[v, g].ID = "sfgs";
            //string NrateItems = "";
            //for (int r = 1; r < NrateVar + 1; r++)
            //{
            //    NrateItems += "("+arst.ratesAggrPN[p, r].ToString("0", CultureInfo.InvariantCulture)+")";
            //}
            //string Nclusteritems = "[" + arst.sortAggrPN[p].ToString("0", CultureInfo.InvariantCulture) + "]";
            varcatc[v, p].Text = arst.participants[p];
            varcatc[v, p].Height = h;
            varcatc[v, p].Width = Litem;

            varcatc[v, p].BorderWidth = 0;
            //varcat[v, g].ImageUrl = "objecticonfetchsized.ashx?sizew=260&sizeh=350&IconId=" & AllObjects.Item((4 * i) + 2).ToString
            varcatc[v, p].Style.Add("position", "absolute");
            //varcatc[v, p].Style.Add("top", (  hpar + h + m + h + m + h + m + p * (h + hm)).ToString() + "px");
            varcatc[v, p].Style.Add("top", (endPosvars + hpar +  m + (p-1) * (h + hm)).ToString() + "px");
            //varcatc[v, p].Style.Add("left", (m + (v - 1) * (l + lm)).ToString() + "px");
            varcatc[v, p].Style.Add("left", (m  ).ToString() + "px");
            //varcat[v, g].ToolTip = "check checkmark";
            varcatc[v, p].Visible = true;

            varcatc[v, p].Checked = true;
            varcatc[v, p].Style.Add("Font-Size", "10px");
            selectionsForm.Controls.Add(varcatc[v, p]);
 
        }

        int[] nCat = new int[6];
        ArrayList rateVar = uts.getRateVars(ratedef1.Text);
        r00.Text = "sort";
        if (rateVar.Count > 0) { nCat[1] = rateVar.Count - 1; r01.Text = ((string)rateVar[0]).Trim()  ; } else { r01.Text = "importance (Nc = 5)"; nCat[1] = 5; }
        rateVar = uts.getRateVars(ratedef2.Text);
        if (rateVar.Count > 0) { nCat[2] = rateVar.Count - 1; r02.Text = ((string)rateVar[0]).Trim()  ; } else { r02.Text = "not defined"; }
        rateVar = uts.getRateVars(ratedef3.Text);
        if (rateVar.Count > 0) { nCat[3] = rateVar.Count - 1; r03.Text = ((string)rateVar[0]).Trim()  ; } else { r03.Text = "not defined"; }
        rateVar = uts.getRateVars(ratedef4.Text);
        if (rateVar.Count > 0) { nCat[4] = rateVar.Count - 1; r04.Text = ((string)rateVar[0]).Trim()  ; } else { r04.Text = "not defined"; }
        rateVar = uts.getRateVars(ratedef5.Text);
        if (rateVar.Count > 0) { nCat[5] = rateVar.Count - 1; r05.Text = ((string)rateVar[0]).Trim()  ; } else { r05.Text = "not defined"; }

        r00.Style.Add("position", "absolute");
        r00.Style.Add("top", (endPosvars + hpar).ToString() + "px");
        r00.Style.Add("left", (m + Lpart  + 0 * (Lcat + m)  ).ToString() + "px");
        r00.Style.Add("Font-Size", "12px");

        r01.Style.Add("position", "absolute");
        r01.Style.Add("top", (endPosvars + hpar).ToString() + "px");
        r01.Style.Add("left", (m + Lpart + 1 * (Lcat + m)  ).ToString() + "px");
        r01.Style.Add("Font-Size", "12px");

        //if (ratedef2.Text.Length > 0) r2.Text = ratedef2.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[2].ToString() + ")"; else r2.Text = "not defined";
        r02.Style.Add("position", "absolute");
        r02.Style.Add("top", (endPosvars + hpar).ToString() + "px");
        r02.Style.Add("left", (m + Lpart + 2 * (Lcat + m)    ).ToString() + "px");
        r02.Style.Add("Font-Size", "12px");

        //if (ratedef3.Text.Length > 0) r3.Text = ratedef3.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[3].ToString() + ")"; else r3.Text = "not defined";
        r03.Style.Add("position", "absolute");
        r03.Style.Add("top", (endPosvars + hpar).ToString() + "px");
        r03.Style.Add("left", (m + Lpart + 3 * (Lcat + m)  ).ToString() + "px");
        r03.Style.Add("Font-Size", "12px");

        //if (ratedef4.Text.Length > 0) r4.Text = ratedef4.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[4].ToString() + ")"; else r4.Text = "not defined";
        r04.Style.Add("position", "absolute");
        r04.Style.Add("top", (endPosvars + hpar).ToString() + "px");
        r04.Style.Add("left", (m + Lpart + 4 * (Lcat + m)  ).ToString() + "px");
        r04.Style.Add("Font-Size", "12px");

        //if (ratedef5.Text.Length > 0) r5.Text = ratedef5.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[5].ToString() + ")"; else r5.Text = "not defined";
        r05.Style.Add("position", "absolute");
        r05.Style.Add("top", (endPosvars + hpar).ToString() + "px");
        r05.Style.Add("left", (m + Lpart + 5 * (Lcat + m) ).ToString() + "px");
        r05.Style.Add("Font-Size", "12px");

        for (int r = 0; r < 5 + 1; r++)
        {

            if (nCat[r] > 0 || r == 0)
            {

                for (int p = 1; p < arst.partNpreselected + 1; p++)
                {


                    int posNowY2 = endPosvars + hpar + m + (p - 1) * (h + hm);
                    //checkbox
                    varcatcr[r + 5, p] = new Label();

                    //if (r == 0)
                    //{
                    varcatcr[r + 5, p].Width = Lcat;
                    if (r == 0)
                    {
                        varcatcr[r + 5, p].Text = "(n=" + arst.sortAggrPN[p].ToString("0", CultureInfo.InvariantCulture) + ") ";
                    }
                    else
                    {
                        varcatcr[r + 5, p].Text = "(n=" + arst.ratesAggrPN[p, r].ToString("0", CultureInfo.InvariantCulture) + ") ";
                    }
                    // }
                    // else
                    // {
                    //     varcatcr[r + 5, p].Text = "(n=" + arst.ratesAggrPN[p, r].ToString("0", CultureInfo.InvariantCulture) + ") ";
                    //     if (arst.ratesAggr[p, r] > 0) { varcatcr[r + 5, p].Width = Lcat; } else { varcatcr[r + 5, p].Width = 0; }
                    //  }
                    varcatcr[r + 5, p].Height = h;


                    //if (arst.ratesAggr[p, r] > 0) { varcatcr[r + 5, p].Width = Lcat; } else { varcatcr[r, p].Width = 0; }

                    varcatcr[r + 5, p].BorderWidth = 0;
                    varcatcr[r + 5, p].Style.Add("position", "absolute");
                    varcatcr[r + 5, p].Style.Add("top", posNowY2.ToString() + "px");

                    varcatcr[r + 5, p].Style.Add("left", (m + Lpart +   r * (Lcat + m)  ).ToString() + "px");
                    varcatcr[r + 5, p].Visible = true;
                    //varcatcr[r, i].BackColor = System.Drawing.Color.Green;
                    //varcatcr[r, i].ForeColor = System.Drawing.Color.White;
                    varcatcr[r + 5, p].Style.Add("Font-Size", "10px");

                    //varcatcr[r, i].Checked = true;

                    selectionsForm.Controls.Add(varcatcr[r + 5, p]);

                    if (posNowY2 > endPosvars2) endPosvars2 = posNowY2;
                }
            }

        }

        Line2.Text = "";
        // Line1.Style.Add("Font-Size", "12px");
        Line2.Style.Add("position", "absolute");
        Line2.Style.Add("top", (endPosvars2 + hpar * .8).ToString() + "px");
        Line2.Style.Add("left", m.ToString() + "px");
        Line2.Height = 0;
        Line2.Width = 1480;
        Line2.BorderWidth = 2;


        vv = 8;
        v8.Style.Add("position", "absolute");
        v8.Style.Add("top", (  endPosvars2 + hpar ).ToString() + "px");
        //v8.Style.Add("left", (m + (vv - 1) * (l + lm)).ToString() + "px");
        v8.Style.Add("left", (m  ).ToString() + "px");
        v8.Style.Add("Font-Size", "12px");
       

        for (int i = 1; i < arst.itemNpreselected + 1; i++)
        {

            int v = 8;
            //checkbox
            varcatc[v, i] = new CheckBox();

            //varcatc[v, g].ID = "sfgs";
            varcatc[v, i].Text = arst.items[i];
            varcatc[v, i].Height = h;
            varcatc[v, i].Width =  Litem;

            varcatc[v, i].BorderWidth = 0;
            //varcat[v, g].ImageUrl = "objecticonfetchsized.ashx?sizew=260&sizeh=350&IconId=" & AllObjects.Item((4 * i) + 2).ToString
            varcatc[v, i].Style.Add("position", "absolute");
            //varcatc[v, i].Style.Add("top", (  hpar +  m + h + m + h + m + (i-1) * (h + hm)).ToString() + "px");
            varcatc[v, i].Style.Add("top", (    endPosvars2 + hpar + m + (i - 1) * (h + hm)).ToString() + "px");
  
                                         
            //varcatc[v, i].Style.Add("left", (m + (v - 1) * (l + lm)).ToString() + "px");
            varcatc[v, i].Style.Add("left", (m   ).ToString() + "px");
            //varcat[v, g].ToolTip = "check checkmark";
            varcatc[v, i].Visible = true;

            varcatc[v, i].Checked = true;
              varcatc[v, i].Style.Add("Font-Size", "10px");
            selectionsForm.Controls.Add(varcatc[v, i]);

        }
        //int[] nCat = new int[6];
        rateVar = uts.getRateVars(ratedef1.Text);
        if (rateVar.Count > 0) {   r1.Text = ((string)rateVar[0]).Trim() + " (" + nCat[1].ToString() + ")"; } else { r1.Text = "importance (Nc = 5)"; nCat[1] = 5; }
        rateVar = uts.getRateVars(ratedef2.Text);
        if (rateVar.Count > 0) {   r2.Text = ((string)rateVar[0]).Trim() + " (" + nCat[2].ToString() + ")"; } else { r2.Text = "not defined"; }
        rateVar = uts.getRateVars(ratedef3.Text);
        if (rateVar.Count > 0) {   r3.Text = ((string)rateVar[0]).Trim() + " (" + nCat[3].ToString() + ")"; } else { r3.Text = "not defined"; }
        rateVar = uts.getRateVars(ratedef4.Text);
        if (rateVar.Count > 0) {   r4.Text = ((string)rateVar[0]).Trim() + " (" + nCat[4].ToString() + ")"; } else { r4.Text = "not defined"; }
        rateVar = uts.getRateVars(ratedef5.Text);
        if (rateVar.Count > 0) {   r5.Text = ((string)rateVar[0]).Trim() + " (" + nCat[5].ToString() + ")"; } else { r5.Text = "not defined"; }

        
        //if (ratedef1.Text.Length > 0) { if (ratedef1.Text.Substring(0, 1) == "1") nCat[1] = Convert.ToInt32(ratedef1.Text.Substring(1, 2)); } else { nCat[1] = 5; }
        //if (ratedef2.Text.Length > 0) if (ratedef2.Text.Substring(0, 1) == "1") nCat[2] = Convert.ToInt32(ratedef2.Text.Substring(1, 2));
        //if (ratedef3.Text.Length > 0) if (ratedef3.Text.Substring(0, 1) == "1") nCat[3] = Convert.ToInt32(ratedef3.Text.Substring(1, 2));
        //if (ratedef4.Text.Length > 0) if (ratedef4.Text.Substring(0, 1) == "1") nCat[4] = Convert.ToInt32(ratedef4.Text.Substring(1, 2));
        //if (ratedef5.Text.Length > 0) if (ratedef5.Text.Substring(0, 1) == "1") nCat[5] = Convert.ToInt32(ratedef5.Text.Substring(1, 2));

        //if (ratedef1.Text.Length > 0) r1.Text = ratedef1.Text.Substring(3, 23).Trim() + "(n cat = "+ nCat[1].ToString() + ")"; else r1.Text = "importance";
        r1.Style.Add("position", "absolute");
        r1.Style.Add("top", (     endPosvars2 + hpar).ToString() + "px");
        r1.Style.Add("left", (m + Litem + m + (1 - 1) * (Lcat + m)).ToString() + "px");
        r1.Style.Add("Font-Size", "12px");

        //if (ratedef2.Text.Length > 0) r2.Text = ratedef2.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[2].ToString() + ")"; else r2.Text = "not defined";
        r2.Style.Add("position", "absolute");
        r2.Style.Add("top", (    endPosvars2 + hpar).ToString() + "px");
        r2.Style.Add("left", (m + Litem + m + (2 - 1) * (Lcat + m)).ToString() + "px");
        r2.Style.Add("Font-Size", "12px");

        //if (ratedef3.Text.Length > 0) r3.Text = ratedef3.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[3].ToString() + ")"; else r3.Text = "not defined";
        r3.Style.Add("position", "absolute");
        r3.Style.Add("top", (   endPosvars2 + hpar).ToString() + "px");
        r3.Style.Add("left", (m + Litem + m + (3 - 1) * (Lcat + m)).ToString() + "px");
        r3.Style.Add("Font-Size", "12px");

        //if (ratedef4.Text.Length > 0) r4.Text = ratedef4.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[4].ToString() + ")"; else r4.Text = "not defined";
        r4.Style.Add("position", "absolute");
        r4.Style.Add("top", (    endPosvars2 + hpar).ToString() + "px");
        r4.Style.Add("left", (m + Litem + m + (4 - 1) * (Lcat + m)).ToString() + "px");
        r4.Style.Add("Font-Size", "12px");

        //if (ratedef5.Text.Length > 0) r5.Text = ratedef5.Text.Substring(3, 23).Trim() + "(n cat = " + nCat[5].ToString() + ")"; else r5.Text = "not defined";
        r5.Style.Add("position", "absolute");
        r5.Style.Add("top", (    endPosvars2 + hpar).ToString() + "px");
        r5.Style.Add("left", (m + Litem + m + (5 - 1) * (Lcat + m)).ToString() + "px");
        r5.Style.Add("Font-Size", "12px");
        //SelectAll();
        //GetDataSelected(); 
        subtitle = subtitletext.Text;

        

      

        for (int r = 1; r < 5 + 1; r++)
        {

            if (nCat[r] > 0)
            {

                for (int i = 1; i < arst.itemNpreselected + 1; i++)
                {

                    //checkbox
                    varcatcr[r, i] = new Label();

                    varcatcr[r, i].Text = "(n=" + arst.ratesAggrN[i, r].ToString("0", CultureInfo.InvariantCulture) + ") "+ arst.ratesAggr[i, r].ToString("0.00", CultureInfo.InvariantCulture);
                    varcatcr[r, i].Height = h;


                    //if (arst.ratesAggr[i, r] > 0)
                    //{
                        varcatcr[r, i].Width = Lcat;
                    //}
                    //else
                    //{
                    //    varcatcr[r, i].Width = 0;
                    //}

                    varcatcr[r, i].BorderWidth = 0;
                    varcatcr[r, i].Style.Add("position", "absolute");
                    varcatcr[r, i].Style.Add("top", (   endPosvars2 + hpar + m + (i - 1) * (h + hm)).ToString() + "px");
                                                 
                    //varcatcr[r, i].Style.Add("left", (m + Lpart+m+ Litem + (r - 1) * (Lcat + m) + lm).ToString() + "px");
                    varcatcr[r, i].Style.Add("left", ( m + Litem + m + (r - 1) * (Lcat + m)).ToString() + "px");
                    varcatcr[r, i].Visible = true;
                    //varcatcr[r, i].BackColor = System.Drawing.Color.Green;
                    //varcatcr[r, i].ForeColor = System.Drawing.Color.White;
                    varcatcr[r, i].Style.Add("Font-Size", "10px");

                    //varcatcr[r, i].Checked = true;

                    selectionsForm.Controls.Add(varcatcr[r, i]);
                }
            }

        }
    }
    public string GetProjectName()
    {
        ArrayList objl = new ArrayList();
        objl = dh.EditProject(ActiveProject);
        //Activeorganizer = (Guid)objl[0];
        //ActiveProject = (Guid)objl[1];

        if (objl.Count > 4) { ratedef1.Text = objl[4].ToString(); if (ratedef1.Text != "") { NrateVar = 1; } } else { ratedef1.Text = ""; }
        if (objl.Count > 5) { ratedef2.Text = objl[5].ToString(); if (ratedef2.Text != "") { NrateVar = 2; } } else { ratedef2.Text = ""; }
        if (objl.Count > 6) { ratedef3.Text = objl[6].ToString(); if (ratedef3.Text != "") { NrateVar = 3; } } else { ratedef3.Text = ""; }
        if (objl.Count > 7) { ratedef4.Text = objl[7].ToString(); if (ratedef4.Text != "") { NrateVar = 4; } } else { ratedef4.Text = ""; }
        if (objl.Count > 8) { ratedef5.Text = objl[8].ToString(); if (ratedef5.Text != "") { NrateVar = 5; } } else { ratedef5.Text = ""; }

        return objl[2].ToString();
    }

    

    protected void GetDataNotSelected()
    {
  
        for (int p = 1; p < AriadneStatistics.partMaxN + 1; p += 1)
        {
            arst.participantSelected[p] = true;
        }
        arst.getData(ActiveProject, false);
        arst.getVars();
       
    }

    protected void GetDataSelected()
    {

        for (int p = 1; p < AriadneStatistics.partMaxN + 1; p += 1)
        {
            //arst.participantSelected[p] = true;
        }
        arst.getData(ActiveProject, true);
        arst.getVars();
        
    }

    
    protected void ReadSelectionScreen()
    {
        for (int v = 1; v < 6 + 1; v++)
        {
            arst.varSelected[v] = varcatc[v, 0].Checked;
        }
        for (int v = 1; v < 6 + 1; v++)
        {
            for (int g = 1; g < arst.participantGroupsVN[v] + 1; g++)
            {
                arst.participantGroupsSelected[v, g] = varcatc[v, g].Checked;
            }
        }
        for (int p = 1; p < arst.partNpreselected + 1; p++)
        {
            int v = 7;
            arst.participantPreSelected[p] = varcatc[v, p].Checked;
        }
        for (int i = 1; i < arst.itemNpreselected + 1; i++)
        {
            int v = 8;
            arst.itemPreSelected[i] = varcatc[v, i].Checked;
            //AriadneStatistics.itemPreSelected[i] = true;
        }
        
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
            if (arst.itemPreSelected[i] == true) { In += 1; Ig +=  arst.itemGuids[i] ; };
        }
        Selection += In.ToString("000", CultureInfo.InvariantCulture) + Ig;
        for (int v = 1; v < 6 + 1; v++)
        {
            if (arst.varSelected[v] == true) { Vin += "1"; } else { Vin += "0"; }
        }
        for (int v = 1; v < 6 + 1; v++)
        {
            Cin = ""; Cn = 0;
            for (int g = 1; g < arst.participantGroupsVN[v] + 1; g++)
            {
                if (arst.participantGroupsSelected[v, g] == true) { Cin += String.Format("{0,-50}", varcatc[v, g].Text); Cn += 1; }
            }

            Selection += Cn.ToString("000", CultureInfo.InvariantCulture) + Cin;
        }

        Guid selectionId= dh.AddSelection(projectId, Selection,0, "","","");
        return selectionId;

    }
     
    protected void GetSelection_del(Guid projectId, Guid selectionId)
    {

        ArrayList selectionlist= dh.GetSelection(projectId, selectionId);
        string selectionS = (string)selectionlist[0];
        string clusterlabels = (string)selectionlist[1];
       
        int Pn = 0; ; int In = 0; int Cn = 0;
        for (int p = 1; p < arst.partN + 1; p++)
        {
              arst.participantPreSelected[p] = false; varcatc[7, p].Checked = false;  
        }
        Guid partIdNow;
        Pn = Convert.ToInt32(selectionS.Substring(0, 3));
        for (int pp = 1; pp < Pn + 1; pp++)
        {
            partIdNow = XmlConvert.ToGuid(selectionS.Substring(3 + (pp - 1) * 36, 36));
            for (int p = 1; p < arst.partN + 1; p++)
            {
                if (arst.p_participant_id[p] == partIdNow) { arst.participantPreSelected[p] = true; varcatc[7, p].Checked = true;  
            }
        }
        for (int i = 1; i < arst.itemN + 1; i++)
        {
              arst.itemPreSelected[i] = false; varcatc[8, i].Checked = false; }
        }
        Guid itemIdNow;
        In = Convert.ToInt32(selectionS.Substring(3 + Pn * 36, 3));
        for (int ii = 1; ii < In + 1; ii++)
        {
            itemIdNow =  XmlConvert.ToGuid(selectionS.Substring(3 + Pn * 36 + 3 + (ii - 1) * 36, 36));
            for (int i = 1; i < arst.itemN + 1; i++)
            {
                if (arst.itemGuids[i] == itemIdNow) { arst.itemPreSelected[i] = true; varcatc[8, i].Checked = true; }  
            }
        }
        int totcatN=0;
        for (int v = 1; v < 6 + 1; v++)
        {
            for (int c = 1; c < arst.participantGroupsVN[v] + 1; c++)
            {
                arst.participantGroupsSelected[v, c] = false; varcatc[v, c].Checked = false;
            }
            string selectedCat ="";
            Cn = Convert.ToInt32(selectionS.Substring(3 + Pn * 36 + 3 + In * 36 + (v - 1) * 3 + totcatN * 50, 3));

            for (int cc = 1; cc < Cn + 1; cc++)
            {
                selectedCat = selectionS.Substring(3 + Pn * 36 + 3 + In * 36 + 3 + (v-1)*3 +  totcatN * 50, 50) ;
                totcatN += 1;
                for (int c = 1; c < arst.participantGroupsVN[v] + 1; c++)
                {
                    if (arst.participantGroupsV[v, c].Trim() == selectedCat.Trim()) { arst.participantGroupsSelected[v, c] = true; varcatc[v, c].Checked = true; }
                        
                }
            }

            
        }

    }


    protected void showSelection()
    {
        subtitletext.Text = arst.mapSubTitle;

        for (int p = 1; p < arst.partN + 1; p++)
        {
            if (arst.participantPreSelected[p] == false) { varcatc[7, p].Checked = false; } else { varcatc[7, p].Checked = true; };
        }
        for (int i = 1; i < arst.itemN + 1; i++)
        {
            if (arst.itemPreSelected[i] == false) { varcatc[8, i].Checked = false; } else { varcatc[8, i].Checked = true; }
        }

        for (int v = 1; v < 6 + 1; v++)
        {
            for (int c = 1; c < arst.participantGroupsVN[v] + 1; c++)
            {
                if (arst.participantGroupsSelected[v, c] == false) { varcatc[v, c].Checked = false; } else { varcatc[v, c].Checked = true; }
            }

            for (int c = 1; c < arst.participantGroupsVN[v] + 1; c++)
            {
                if (arst.participantGroupsSelected[v, c] == false) { arst.participantGroupsSelected[v, c] = true; varcatc[v, c].Checked = true; }
            }
        }
    }
      
     




    protected void getdata_Click(object sender, EventArgs e)
    {
        arst.outputData(Activeorganizer, ActiveProject, GetProjectName() + " (Pn= " + arst.partN.ToString() + ") " + " (In= " + arst.itemN.ToString() + ")", "No Selection", ratedef1.Text, ratedef2.Text, ratedef3.Text, ratedef4.Text, ratedef5.Text);
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

    protected void UploadDataFile_Click(object sender, EventArgs e)
    {
        arst.outputData(Activeorganizer, ActiveProject, GetProjectName() + " (Pn= " + arst.partN.ToString() + ") " + " (In= " + arst.itemN.ToString() + ")", "After Selection",ratedef1.Text,ratedef2.Text,ratedef3.Text,ratedef4.Text,ratedef5.Text);
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




    protected void buildmap_Click(object sender, EventArgs e)
    {


        ReadSelectionScreen();
        //Guid SelectionId = saveSelection(ActiveProject); SelectionList.DataBind();

        int analysesinfo = 0;
        if (eigenTreatment.Checked == false) { analysesinfo = 0; } else { analysesinfo = 1; }

        Guid SelectionId = arst.saveSelection(ActiveProject, analysesinfo, subtitletext.Text, "", ""); SelectionList.DataBind();
        //subtitle = subtitletext.Text;
        //Response.Redirect("~/Web_Code/AriadneConceptSelectedMap.aspx?" + "organizer=" + XmlConvert.ToString(Activeorganizer) + "&project=" + XmlConvert.ToString(ActiveProject) + "&selection=" + XmlConvert.ToString(SelectionId) + "&subtitle=" + subtitletext.Text);
        Response.Redirect("~/Web_Code/AriadneConceptSelectedMap.aspx?" + "organizer=" + XmlConvert.ToString(Activeorganizer) + "&project=" + XmlConvert.ToString(ActiveProject) + "&selection=" + XmlConvert.ToString(SelectionId)  );

      }


    protected void Selection_Selecting(object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
    {

        if (Page.User.Identity.IsAuthenticated)
        {
            e.Command.Parameters["@projectid"].Value = ActiveProject; //XmlConvert.ToString(Activeorganizer);
            //e.Command.Parameters["@start"].Value = pStart;
            //e.Command.Parameters["@end"].Value = pEnd;
        }
        else
        {
            e.Command.Parameters["@projectid"].Value = DBNull.Value;
        }

    }

    protected void EditSelection_Command(Object sender, DataListCommandEventArgs e)
    {


        //SelectionInProgress.Text = "yes";
       
        Guid selectionIdNow = XmlConvert.ToGuid((string)e.CommandArgument);
        buildChecks2();
        arst.GetSelection(ActiveProject, selectionIdNow);
        showSelection();
       //ActiveProject = ActiveProject2;
        //e.CommandArgument.ToString
       // TextBoxProject.Text = XmlConvert.ToString(ActiveProject2);
       // ProjectStatus(3, ActiveProject2);


    }
    protected void ShowMapFromSelection_Command(Object sender, DataListCommandEventArgs e)
    {

        Guid selectionIdNow = XmlConvert.ToGuid((string)e.CommandArgument);
        //Response.Redirect("~/Web_Code/AriadneConceptSelectedMap.aspx?" + "organizer=" + XmlConvert.ToString(Activeorganizer) + "&project=" + XmlConvert.ToString(ActiveProject) + "&selection=" + XmlConvert.ToString(selectionIdNow) + "&subtitle=" + subtitletext.Text);
        Response.Redirect("~/Web_Code/AriadneConceptSelectedMap.aspx?" + "organizer=" + XmlConvert.ToString(Activeorganizer) + "&project=" + XmlConvert.ToString(ActiveProject) + "&selection=" + XmlConvert.ToString(selectionIdNow)  );
    
   }

    public void RemoveSelection_Command(Object sender, DataListCommandEventArgs e)
    {

        //Guid ActiveProject2;
       // ActiveProject2 = XmlConvert.ToGuid((string)e.CommandArgument);

        Guid selectionId = XmlConvert.ToGuid((string)e.CommandArgument);
         //DateTime dateNow=Convert.ToDateTime(e.CommandArgument) ;
         dh.RemoveSelection(ActiveProject, selectionId);
         SelectionList.DataBind();

       // usr.removeVisit(visitid);
       // //ActiveProject2 = XmlConvert.ToGuid((string)e.CommandArgument); //e.CommandArgument.ToString
       // SqlDataSource2.DataBind();
       // DataList2.DataBind();
    }

    public void RemoveAllSelections_Command(Object sender, DataListCommandEventArgs e)
    {

        //Guid ActiveProject2;
        // ActiveProject2 = XmlConvert.ToGuid((string)e.CommandArgument);

        

        // usr.removeVisit(visitid);
        // //ActiveProject2 = XmlConvert.ToGuid((string)e.CommandArgument); //e.CommandArgument.ToString
        // SqlDataSource2.DataBind();
        // DataList2.DataBind();
    }
    protected void RemoveSelectionsAll_Click(object sender, EventArgs e)
    {
        Guid selectionId = ActiveProject;
        dh.RemoveSelectionsAll(ActiveProject);
        SelectionList.DataBind();
    }
}


 