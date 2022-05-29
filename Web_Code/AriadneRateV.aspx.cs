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


//using System.Collections.Generic;

 

public partial class ariadneSort : System.Web.UI.Page
{

    //string[] items = new string[6];

      ArrayList items;
     int itemN;
     //string itemSortData;
     //string itemRateData;

      Guid Activeorganizer;
      Guid ActiveProject;
      Guid ActiveParticipant;

    //public static string currentPage;
      string PrevPage;

    //public static string currentPage;

      
     DataHandling dh  = new DataHandling();
     UtilsDataStrings uts = new UtilsDataStrings();

     protected override void OnUnload(EventArgs e)
     {
          
          
     }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);

        if (!IsPostBack)
        {

            if (Request.UrlReferrer != null)
            {
                PrevPage = Request.UrlReferrer.ToString();
            }

            saveThis.Text = "yes";
            if (Request.QueryString["save"] != null) { saveThis.Text = Request.QueryString["save"].Trim(); };

            if (Request.QueryString["ratetype"] != null)
            {
                rateType.Text = Request.QueryString["ratetype"];
            }
            if (Request.QueryString["project"] != null)
            {
                ActiveProject = XmlConvert.ToGuid(Request.QueryString["project"]);


                if (Request.QueryString["participant"] != null)
                {
                    ActiveParticipant = XmlConvert.ToGuid(Request.QueryString["participant"]);
                    //if (!IsPostBack)
                    //{
                        itemsLoad(ActiveProject);
                        //itemSortData = DataHandling.GetItemSortData(ActiveProject, ActiveParticipant);
                        //sortData.Text = itemSortData;

                        rateData.Text = dh.GetItemRateData(ActiveProject, ActiveParticipant, Convert.ToInt16(rateType.Text));

                    
                        ArrayList objl = new ArrayList();

                        objl = dh.EditProject(ActiveProject);

                        RateTextBox1.Text = "";
                        RateTextBox11.Text = "";
                        RateTextBox12.Text = "";
                        RateTextBox13.Text = "";
                        RateTextBox14.Text = "";
                        RateTextBox15.Text = "";

                        ArrayList rateVar =new ArrayList();
                        int rt = Convert.ToInt16(rateType.Text);
                        if (rt == 1) rateVar = uts.getRateVars(objl[4].ToString());
                        if (rt == 2) rateVar = uts.getRateVars(objl[5].ToString());
                        if (rt == 3) rateVar = uts.getRateVars(objl[6].ToString());
                        if (rt == 4) rateVar = uts.getRateVars(objl[7].ToString());
                        if (rt == 5) rateVar = uts.getRateVars(objl[8].ToString());
                        if (rateVar.Count > 0)
                        {
                            RateTextBox1.Text = ((string)rateVar[0]).Trim();
                            if (rateVar.Count > 1) RateTextBox11.Text = ((string)rateVar[1]).Trim();
                            if (rateVar.Count > 2) RateTextBox12.Text = ((string)rateVar[2]).Trim();
                            if (rateVar.Count > 3) RateTextBox13.Text = ((string)rateVar[3]).Trim();
                            if (rateVar.Count > 4) RateTextBox14.Text = ((string)rateVar[4]).Trim();
                            if (rateVar.Count > 5) RateTextBox15.Text = ((string)rateVar[5]).Trim();
                        }
                        RateTextBox1N.Text = Convert.ToString(rateVar.Count);
                        TextBoxProject.Text = XmlConvert.ToString(ActiveProject);
                        TextBoxParticipant.Text = XmlConvert.ToString(ActiveParticipant);
                        //ActiveProject = XmlConvert.ToGuid(TextBoxProject.Text);
                        //ActiveProjectPart = XmlConvert.ToGuid(TextBoxParticipant.Text);

                        //rateData.Text = dh.GetItemRateData(ActiveProject, ActiveParticipant);
                    //}
                    firstName.Text = dh.GetFirstnameFromParticipantName(XmlConvert.ToString(ActiveParticipant)) + " " + dh.GetLastnameFromParticipantName(XmlConvert.ToString(ActiveParticipant));

                   
                }
            }
            if (Request.QueryString["organizer"] != null)
            {
                Activeorganizer = XmlConvert.ToGuid(Request.QueryString["organizer"]);
            }
        }

    }


    protected void itemsLoad(Guid projectId)
    {

        items =dh.SelectAllItems(projectId);
        itemN = items.Count/2;

        itemData.Text = uts.BuildItemString(itemN, items);

        //itemData.Text = String.Format("{0:000}", itemN); //itemN.ToString();
        //for (int i = 0; i < itemN; i++)
        //{
        //    itemData.Text += String.Format("{0,-100}", items[i]); ;
        //}

    }


    protected void saverateresult_Click(object sender, EventArgs e)  // DIT GAAT OVER SORT NIET OVER RATING  *ERROR*  
    {

        string username = Membership.GetUser().UserName;
        string passname = dh.GetParticipantPasname(username);

        Guid ActiveParticipant2 = dh.GetParticipantId(username);

        Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        string itemRateData = rateData.Text;
        object result = dh.AddItemRateData(ActiveProject2, ActiveParticipant2, itemRateData, Convert.ToInt16(rateType.Text));


        itemsLoad(ActiveProject2);

        rateData.Text = dh.GetItemRateData(ActiveProject2, ActiveParticipant2, Convert.ToInt16(rateType.Text));
        string nameNow = dh.GetFirstnameFromParticipantName(XmlConvert.ToString(ActiveParticipant2)) + " " + dh.GetLastnameFromParticipantName(XmlConvert.ToString(ActiveParticipant2));
        //saverateresulttoserver.Text = "Save (" + nameNow.Trim() + ")";


        //string itemRateData = rateData.Text;
        //object result = DataHandling.AddItemRateData(ActiveProject, ActiveParticipant, itemRateData );
    }
    protected void saverateresultandback_Click(object sender, EventArgs e)  // DIT GAAT OVER SORT NIET OVER RATING  *ERROR*  
    {

        string username = Membership.GetUser().UserName;
        string passname = dh.GetParticipantPasname(username);

        Guid ActiveParticipant2 = dh.GetParticipantId(username);

        Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        string itemRateData = rateData.Text;
        object result = dh.AddItemRateData(ActiveProject2, ActiveParticipant2, itemRateData, Convert.ToInt16(rateType.Text));

        string project = XmlConvert.ToString(ActiveProject2);
        string participant = XmlConvert.ToString(ActiveParticipant2);

        string qq = "?userName=" + username + "&passName=" + passname + "&project=" + project + "&participant=" + participant;
        Response.Redirect("~/Web_Code/participate.aspx" + qq);
        
       
        
        
        //string itemRateData = rateData.Text;
        //object result = DataHandling.AddItemRateData(ActiveProject, ActiveParticipant, itemRateData);
        //Response.Redirect(PrevPage);
        



    }
}


 