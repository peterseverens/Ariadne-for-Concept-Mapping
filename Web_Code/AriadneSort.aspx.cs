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

                    usernameInfo.Text=Request.QueryString["user"];
                    passnameInfo.Text = Request.QueryString["pass"];

                    //if (!IsPostBack)
                    //{
                          string selectedItems="";
                    int MaxItemNinQuest = dh.getMaxItemNinQuest(ActiveProject);
                    if (MaxItemNinQuest > 0) {selectedItems = dh.GetItemSelectedData(ActiveProject, ActiveParticipant, MaxItemNinQuest); }  
                        itemsLoad(ActiveProject, selectedItems);
                        //itemsLoad(ActiveProject);
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
                    
                    firstName.Text = (dh.GetFirstnameFromParticipantName(XmlConvert.ToString(ActiveParticipant)) + " " + dh.GetLastnameFromParticipantName(XmlConvert.ToString(ActiveParticipant))).Trim();

                  
                    
                    //USER STATISTICS

                    ArrayList projectInfo = dh.EditProject(ActiveProject);
                    string organizerName = dh.getOrganizerName((Guid)projectInfo[0]);
                    if (organizerName == null) { organizerName = XmlConvert.ToString((Guid)projectInfo[0]); }

                    string usrnm = "anonymous";
                    string[] roles = new string[99];
                    Boolean organiser = false;
                    Boolean user = false;

                    string ip = GetUserIP();
                    if (Page.User.Identity.IsAuthenticated)
                    {

                        usrnm = Membership.GetUser().UserName;
                        roles = Roles.GetAllRoles();


                        for (int i = 0; i < roles.Length; i++)
                        {
                            if (roles[i] == "user") user = true;
                            if (roles[i] == "organizer") organiser = true;
                        }
                    }
                    dh.AddUserInfo("AriadneSort.aspx", ip, usrnm, user, organiser, firstName.Text, projectInfo[2] + ":" + projectInfo[3], organizerName);

                    //END USER STATISTICS
                     
                }
            }
            if (Request.QueryString["organizer"] != null)
            {
                Activeorganizer = XmlConvert.ToGuid(Request.QueryString["organizer"]);
            }
        }

    }

    private string GetUserIP()
    {
        string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipList))
        {
            return ipList.Split(',')[0];
        }

        return Request.ServerVariables["REMOTE_ADDR"];
    }

    //protected void itemsLoad(Guid projectId)
    //{

    //    items = dh.SelectAllItems(projectId);
    //    itemN = items.Count/2;

    //    itemData.Text = uts.BuildItemString(itemN, items);

       

    //}

    protected void itemsLoad(Guid projectId, string selectedItems)
    {


        ArrayList items = dh.SelectAllItems(projectId);
        itemN = items.Count / 2;
        int foundItem = -1;
        ArrayList items2 = new ArrayList();

        if (selectedItems != "")
        {
            int maxItemNinQuest = Convert.ToInt32(selectedItems.Substring(0, 3));
            Guid[] selections = new Guid[maxItemNinQuest + 2];

            for (int i = 0; i < maxItemNinQuest; i++)
            {
                selections[i] = XmlConvert.ToGuid(selectedItems.Substring(3 + i * 36, 36));
            }
            for (int i = 0; i < items.Count; i += 2)
            {
                foundItem = -1;
                for (int ii = 0; ii < maxItemNinQuest; ii++)
                {
                    if ((Guid)items[i] == selections[ii]) { foundItem = i; }
                }
                if (foundItem > -1) { items2.Add(items[foundItem]); items2.Add(items[foundItem + 1]); }
            }

            itemData.Text = uts.BuildItemString(maxItemNinQuest, items2);
        }
        else
        {
            itemData.Text = uts.BuildItemString(itemN, items);
        }


    }

   
    protected void savesortresultandback_Click(object sender, EventArgs e)  // DIT GAAT OVER SORT NIET OVER RATING  *ERROR*  
    {

        //string username = Membership.GetUser().UserName;
        //string passname = dh.GetParticipantPasname(username);

        string username = usernameInfo.Text;
        string passname = passnameInfo.Text;

        //Guid ActiveParticipant2 = dh.GetParticipantId(username);
        //Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        Guid ActiveProject2 = XmlConvert.ToGuid(TextBoxProject.Text.Trim());
        Guid ActiveParticipant2 = XmlConvert.ToGuid(TextBoxParticipant.Text.Trim());

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

     

    [System.Web.Services.WebMethod()]
    public static string saveSortDataToServer(string sortData, string xData, string yData, string clusterNames)
    {
        DataHandling dh2 = new DataHandling();
        int ratetype = Convert.ToInt32(sortData.Substring(0, 1));
        Guid ActiveProject = XmlConvert.ToGuid(sortData.Substring(1, 36));
        Guid ActiveParticipant = XmlConvert.ToGuid(sortData.Substring(37, 36));
        string sortResults = sortData.Substring(73, sortData.Length - 73);

        //object result = dh.AddItemSortData(ActiveProject, ActiveParticipant, sortResults, clusterNames);
        object result = dh2.AddItemSortDataAll(ActiveProject, ActiveParticipant, sortResults, xData, yData, clusterNames);
        if (result == null) { return "save OK!"; } else { return string.Format((string)result); }
    }



}


 