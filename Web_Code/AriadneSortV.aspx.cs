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

      string PrevPage;

      DataHandling dh = new DataHandling();
      UtilsDataStrings uts = new UtilsDataStrings();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            if (Request.UrlReferrer != null)
            {
                PrevPage = Request.UrlReferrer.ToString();
            }

            saveThis.Text = "yes";
            if (Request.QueryString["save"] != null) { saveThis.Text = Request.QueryString["save"].Trim(); };

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
                        rateType.Text = "1";
                        TextBoxProject.Text = XmlConvert.ToString(ActiveProject);
                        TextBoxParticipant.Text = XmlConvert.ToString(ActiveParticipant);

                        ArrayList sortDataList = dh.GetItemSortDataAll(ActiveProject, ActiveParticipant);
                        if (sortDataList.Count > 0)
                        {
                            sortData.Text = sortDataList[0].ToString();
                            if (sortDataList.Count > 1)
                            {
                                xData.Text = sortDataList[1].ToString();
                                yData.Text = sortDataList[2].ToString();
                                clusterNames.Text = sortDataList[3].ToString();


                            }
                         
                            rateData.Text = dh.GetItemRateData(ActiveProject, ActiveParticipant,1);
                            
                        }
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

        items = dh.SelectAllItems(projectId);
        itemN = items.Count/2;

        itemData.Text = uts.BuildItemString(itemN, items);

        //itemData.Text = String.Format("{0:000}", itemN); //itemN.ToString();
        //for (int i = 0; i < itemN; i++)
        //{
        //    itemData.Text += String.Format("{0,-100}", items[i]); ;
        //}

    }


    protected void savesortresult_Click(object sender, EventArgs e)
    {

        string username = Membership.GetUser().UserName;
        string passname = dh.GetParticipantPasname(username);

        Guid ActiveParticipant2 = dh.GetParticipantId(username);

        Guid  ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        string itemSortData = sortData.Text;
        string xcoord = xData.Text;
        string ycoord = yData.Text;
     
        string names = clusterNames.Text;
        object result = dh.AddItemSortDataAll(ActiveProject2, ActiveParticipant2, itemSortData, xcoord, ycoord,  names);

        itemsLoad(ActiveProject2);
        ArrayList sortDataList = dh.GetItemSortDataAll(ActiveProject2, ActiveParticipant2);
        if (sortDataList.Count > 0)
        {
            sortData.Text = sortDataList[0].ToString();
            if (sortDataList.Count > 1)
            {
                xData.Text = sortDataList[1].ToString();
                yData.Text = sortDataList[2].ToString();            
                clusterNames.Text = sortDataList[3].ToString();
            }
             
            rateData.Text = dh.GetItemRateData(ActiveProject2, ActiveParticipant2,1);
        }
        //}
        //string nameNow = dh.GetFirstnameFromParticipantName(XmlConvert.ToString(ActiveParticipant2)) + " " + dh.GetLastnameFromParticipantName(XmlConvert.ToString(ActiveParticipant2));

        //savesortresulttoserver.Text = "Save (" + nameNow.Trim() + ")";


        //string itemSortData = sortData.Text;
        //string xcoord = xData.Text;
        //string ycoord = yData.Text;
        //string order = cardOrder.Text;
        //string names = clusterNames.Text;
        //object result = DataHandling.AddItemSortDataAll(ActiveProject, ActiveParticipant, itemSortData, xcoord, ycoord, order,names);
    }

    protected void savesortresultandback_Click(object sender, EventArgs e)  // DIT GAAT OVER SORT NIET OVER RATING  *ERROR*  
    {

        string username = Membership.GetUser().UserName;
        string passname = dh.GetParticipantPasname(username);

        Guid ActiveParticipant2 = dh.GetParticipantId(username);

        Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        string itemSortData = sortData.Text;
        string xcoord = xData.Text;
        string ycoord = yData.Text;
         
        string names = clusterNames.Text;
        object result = dh.AddItemSortDataAll(ActiveProject2, ActiveParticipant2, itemSortData, xcoord, ycoord,   names);

        string project = XmlConvert.ToString(ActiveProject2);
        string participant = XmlConvert.ToString(ActiveParticipant2);

        string qq = "?userName=" + username + "&passName=" + passname + "&project=" + project + "&participant=" + participant;
        Response.Redirect("~/Web_Code/participate.aspx" + qq);

        //string itemSortData = sortData.Text;
        //string xcoord = xData.Text;
        //string ycoord = yData.Text;
        //string order = cardOrder.Text;
        //string names = clusterNames.Text;
        //object result = DataHandling.AddItemSortDataAll(ActiveProject, ActiveParticipant, itemSortData, xcoord, ycoord, order, names);
        //Response.Redirect(PrevPage);

    }
}


 