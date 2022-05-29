using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Drawing;
//using System.Collections.Generic;

//using System;
using System.IO;
using System.Xml;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;


public partial class _organizer : System.Web.UI.Page
{

    public  Guid Activeorganizer;
    public  Guid ActiveProject;
    public  Guid ActiveProjectPart;
    public  Guid ActiveProjectItem;

    public  string ActiveProjectName="";

    public  Random random = new Random();

    public  int pMax = 15;
    public  int pStart = 1;
    public  int pEnd = 15;

    public  int paMax = 8;
    public  int paStart = 1;
    public  int paEnd = 8;

    public  int paoMax = 10;
    public  int paoStart = 1;
    public  int paoEnd = 10;

    public  int itMax = 15;
    public  int itStart = 1;
    public  int itEnd = 15;

   

    public   string locktype = "";
    //public   byte ShowParticipantOrItem = 0;

    DataHandling dh = new DataHandling();
    AriadneUsers usr = new AriadneUsers();
    Utils ut = new Utils();
    UtilsDataStrings uts = new UtilsDataStrings();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)

        {

            //USER STATISTICS
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

            dh.AddUserInfo("organise.aspx",ip, usrnm, user, organiser,"","","");
            
            //END USER STATISTICS

            ActiveProject =  XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
            
            //MembershipUser user = Membership.GetUser(User.Identity.Name);
            //if (user == null)  Response.Redirect("Account/Login.aspx"); 


            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                if (Page.User.Identity.IsAuthenticated)

                    if (Roles.IsUserInRole("administrator") || Roles.IsUserInRole("organizer"))
                    {
                        Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
                        TextBoxOrganiser.Text = XmlConvert.ToString(Activeorganizer);
                        if (ActiveProject == XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000"))
                        {


                            ProjectStatus(0, ActiveProject);
                        }
                        else
                        {
                            editProjectScreen.Visible = true;
                            editParticipantScreen.Visible = false;
                            editItemScreen.Visible = false;
                            ParticipantBlock.Visible = true;
                            ItemBlock.Visible = true;
                            ProjectStatus(3, ActiveProject);

                        }

    
                    }
                    else
                    {
                        Response.Redirect("~/default.aspx");
                    }



            }

            
           
            ProjectStatus(0, ActiveProject);

        }
        Activeorganizer = XmlConvert.ToGuid(TextBoxOrganiser.Text);
        if (TextBoxProject.Text != "") ActiveProject = XmlConvert.ToGuid(TextBoxProject.Text);
        if (TextBoxItem.Text != "") ActiveProjectItem = XmlConvert.ToGuid(TextBoxItem.Text);
        if (TextBoxParticipant.Text != "") ActiveProjectPart = XmlConvert.ToGuid(TextBoxParticipant.Text);
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

    protected void ProjectStatus(int status, Guid InputProjectID)
    {
        DeletePopup.Visible = false;
        if (status == 0) //start new project 
        {

            ProjectLabel.Text = "No Active Project";
            CancelProjectButton.Visible = false;
            AddProjectButton.Visible = false;        

            editProjectScreen.Visible = false;
            projectBlock.Visible = true;

            ParticipantStatus(-1, ActiveProject, ActiveProjectPart);
            ItemStatus(-1, ActiveProject, ActiveProjectItem);

            EditProject.Visible = false;
            showitemorparticipant(false, false);
            showlock(false);
            //BackupButton.Visible = false;

        }

        if (status == 1) //start new project 
        {
            ActiveProject = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
            TextBoxProject.Text = XmlConvert.ToString(ActiveProject);
            ProjectLabel.Text = "New Project Definition";
            
            editProjectScreen.Visible = true;
            projectBlock.Visible = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
     
            AddProjectButton.Visible = true;         
            AddProjectButton.Text = "Add";
            CancelProjectButton.Visible = true;
           

            SqlDataSource1.DataBind();
            ProjectList.DataBind();

            ParticipantStatus(-1, ActiveProject, ActiveProjectPart);
            ItemStatus(-1, ActiveProject, ActiveProjectItem);

            EditProject.Visible = false;
            showitemorparticipant(false, false);
            showlock(false);
            //BackupButton.Visible = false;

                        
           
        }
        if (status == 2) //save a project for the first time
        {

            string rateName1 = uts.BuildRateVar(RateTextBox1.Text, RateTextBox11.Text, RateTextBox12.Text, RateTextBox13.Text, RateTextBox14.Text, RateTextBox15.Text);
            string rateName2 = uts.BuildRateVar(RateTextBox2.Text, RateTextBox21.Text, RateTextBox22.Text, RateTextBox23.Text, RateTextBox24.Text, RateTextBox25.Text);
            string rateName3 = uts.BuildRateVar(RateTextBox3.Text, RateTextBox31.Text, RateTextBox32.Text, RateTextBox33.Text, RateTextBox34.Text, RateTextBox35.Text);
            string rateName4 = uts.BuildRateVar(RateTextBox4.Text, RateTextBox41.Text, RateTextBox42.Text, RateTextBox43.Text, RateTextBox44.Text, RateTextBox45.Text);
            string rateName5 = uts.BuildRateVar(RateTextBox5.Text, RateTextBox51.Text, RateTextBox52.Text, RateTextBox53.Text, RateTextBox54.Text, RateTextBox55.Text);

            int maxItemNinQuest =0;
            if (MaxItemNTextBox.Text.Trim() !="") {maxItemNinQuest = Convert.ToInt32(MaxItemNTextBox.Text);}
            editProjectScreen.Visible = false;
            //string test = XmlConvert.ToString(ActiveProject);
            if (XmlConvert.ToString(InputProjectID) == "00000000-0000-0000-0000-000000000000") 
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    Guid ActiveProject0 = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
                    ActiveProject = dh.AddProject((Guid)Membership.GetUser().ProviderUserKey, ActiveProject0, TextBox1.Text, TextBox2.Text, rateName1, rateName2, rateName3, rateName4, rateName5, maxItemNinQuest);
                    TextBoxProject.Text = XmlConvert.ToString(ActiveProject);
                    SqlDataSource1.DataBind();
                    ProjectList.DataBind();
                    AddProjectButton.Visible = true;
                    
                    AddProjectButton.Text = "Update";
                   
                    
                }
                else
                {
                }
            }
            else
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    object result = dh.UpdateProject(InputProjectID, TextBox1.Text, TextBox2.Text, rateName1, rateName2, rateName3, rateName4, rateName5, maxItemNinQuest);
                    SqlDataSource1.DataBind();
                    ProjectList.DataBind();
                }
            }
            SqlDataSource1.DataBind();
            ProjectList.DataBind();

            SqlDataSource2.DataBind();
            participantlist.DataBind();

            SqlDataSource3.DataBind();
            otherparticipantlist.DataBind();

            SqlDataSource4.DataBind();
            itemlist.DataBind();

            CancelProjectButton.Visible = true;
            projectBlock.Visible = false;
            ProjectLabel.Text = "Current Active Project: " + TextBox1.Text + " : " + TextBox2.Text;
            ParticipantStatus(0, ActiveProject, ActiveProjectPart);
            ItemStatus(0, ActiveProject, ActiveProjectItem);

            EditProject.Visible = true;
            ParticipantStatus(0, ActiveProject, ActiveProjectPart);
            ItemStatus(-1, ActiveProject, ActiveProjectItem);
            showitemorparticipant(true, false);
            showlock(true);

             
 
                

        }
        if (status == 3) //Edit the project items or particiapant 
        {

            editProjectScreen.Visible = false;

            ArrayList objl = new ArrayList();

            objl = dh.EditProject(InputProjectID);
            Activeorganizer = (Guid)objl[0];
            ActiveProject = (Guid)objl[1];
            ActiveProjectName = objl[2].ToString();
            TextBox1.Text = objl[2].ToString();
            TextBox2.Text = objl[3].ToString();
            if (objl.Count > 9) { MaxItemNTextBox.Text = ((int)objl[9]).ToString(); } else { MaxItemNTextBox.Text = ""; }

            RateTextBox1.Text = "";
            RateTextBox11.Text = "";
            RateTextBox12.Text = "";
            RateTextBox13.Text = "";
            RateTextBox14.Text = "";
            RateTextBox15.Text = "";

            ArrayList rateVar = uts.getRateVars(objl[4].ToString());
            if (rateVar.Count > 0)
            {
                RateTextBox1.Text = ((string)rateVar[0]).Trim();
                if (rateVar.Count > 1) RateTextBox11.Text = ((string)rateVar[1]).Trim();
                if (rateVar.Count > 2) RateTextBox12.Text = ((string)rateVar[2]).Trim();
                if (rateVar.Count > 3) RateTextBox13.Text = ((string)rateVar[3]).Trim();
                if (rateVar.Count > 4) RateTextBox14.Text = ((string)rateVar[4]).Trim();
                if (rateVar.Count > 5) RateTextBox15.Text = ((string)rateVar[5]).Trim();
            }

            RateTextBox2.Text = "";
            RateTextBox21.Text = "";
            RateTextBox22.Text = "";
            RateTextBox23.Text = "";
            RateTextBox24.Text = "";
            RateTextBox25.Text = "";

             rateVar = uts.getRateVars(objl[5].ToString());
            if (rateVar.Count > 0)
            {
                RateTextBox2.Text = ((string)rateVar[0]).Trim();
                if (rateVar.Count > 1) RateTextBox21.Text = ((string)rateVar[1]).Trim();
                if (rateVar.Count > 2) RateTextBox22.Text = ((string)rateVar[2]).Trim();
                if (rateVar.Count > 3) RateTextBox23.Text = ((string)rateVar[3]).Trim();
                if (rateVar.Count > 4) RateTextBox24.Text = ((string)rateVar[4]).Trim();
                if (rateVar.Count > 5) RateTextBox25.Text = ((string)rateVar[5]).Trim();
            }

            RateTextBox3.Text = "";
            RateTextBox31.Text = "";
            RateTextBox32.Text = "";
            RateTextBox33.Text = "";
            RateTextBox34.Text = "";
            RateTextBox35.Text = "";

            rateVar = uts.getRateVars(objl[6].ToString());
            if (rateVar.Count > 0)
            {
                RateTextBox3.Text = ((string)rateVar[0]).Trim();
                if (rateVar.Count > 1) RateTextBox31.Text = ((string)rateVar[1]).Trim();
                if (rateVar.Count > 2) RateTextBox32.Text = ((string)rateVar[2]).Trim();
                if (rateVar.Count > 3) RateTextBox33.Text = ((string)rateVar[3]).Trim();
                if (rateVar.Count > 4) RateTextBox34.Text = ((string)rateVar[4]).Trim();
                if (rateVar.Count > 5) RateTextBox35.Text = ((string)rateVar[5]).Trim();
            }

            RateTextBox4.Text = "";
            RateTextBox41.Text = "";
            RateTextBox42.Text = "";
            RateTextBox43.Text = "";
            RateTextBox44.Text = "";
            RateTextBox45.Text = "";

            rateVar = uts.getRateVars(objl[7].ToString());
            if (rateVar.Count > 0)
            {
                RateTextBox4.Text = ((string)rateVar[0]).Trim();
                if (rateVar.Count > 1) RateTextBox41.Text = ((string)rateVar[1]).Trim();
                if (rateVar.Count > 2) RateTextBox42.Text = ((string)rateVar[2]).Trim();
                if (rateVar.Count > 3) RateTextBox43.Text = ((string)rateVar[3]).Trim();
                if (rateVar.Count > 4) RateTextBox44.Text = ((string)rateVar[4]).Trim();
                if (rateVar.Count > 5) RateTextBox45.Text = ((string)rateVar[5]).Trim();
            }


            RateTextBox5.Text = "";
            RateTextBox51.Text = "";
            RateTextBox52.Text = "";
            RateTextBox53.Text = "";
            RateTextBox54.Text = "";
            RateTextBox55.Text = "";

            rateVar = uts.getRateVars(objl[8].ToString());
            if (rateVar.Count > 0)
            {
                RateTextBox5.Text = ((string)rateVar[0]).Trim();
                if (rateVar.Count > 1) RateTextBox51.Text = ((string)rateVar[1]).Trim();
                if (rateVar.Count > 2) RateTextBox52.Text = ((string)rateVar[2]).Trim();
                if (rateVar.Count > 3) RateTextBox53.Text = ((string)rateVar[3]).Trim();
                if (rateVar.Count > 4) RateTextBox54.Text = ((string)rateVar[4]).Trim();
                if (rateVar.Count > 5) RateTextBox55.Text = ((string)rateVar[5]).Trim();
            }

 
            AddProjectButton.Visible = true;
            AddProjectButton.Text = "Update";
            CancelProjectButton.Visible = true;

            ProjectLabel.Text = "Current Active Project: " + objl[2].ToString() + " : " + objl[3].ToString();


            //SqlDataSource1.DataBind();
            //ProjectList.DataBind();

            SqlDataSource2.DataBind();
            participantlist.DataBind();


            SqlDataSource3.DataBind();
            otherparticipantlist.DataBind();

            SqlDataSource4.DataBind();
            itemlist.DataBind();

            //editProjectScreen.Visible = false;
            projectBlock.Visible = false;

            if (ParticipantsOrItems.Checked==false)
            { 
              ParticipantStatus(0, ActiveProject, ActiveProjectPart);
              ItemStatus(-1, ActiveProject, ActiveProjectItem);
              showitemorparticipant(true,true);
            }
            else
            {
              ParticipantStatus(-1, ActiveProject, ActiveProjectPart);
              ItemStatus(0, ActiveProject, ActiveProjectItem);
              showitemorparticipant(true, false);
            }

            EditProject.Visible = true;
            
            
            showlock(true);

        }
        if (status == 31) //Edit the project name and description
        {

            editProjectScreen.Visible = true;

            ArrayList objl = new ArrayList();

            objl = dh.EditProject(InputProjectID);
            Activeorganizer = (Guid)objl[0];
            ActiveProject = (Guid)objl[1];
            ActiveProjectName = objl[2].ToString();
            TextBox1.Text = objl[2].ToString();
            TextBox2.Text = objl[3].ToString();


            AddProjectButton.Visible = true;
            AddProjectButton.Text = "Update";
            CancelProjectButton.Visible = true;

            ProjectLabel.Text = "Current Active Project: " + objl[2].ToString() + " : " + objl[3].ToString();


            //SqlDataSource1.DataBind();
            //ProjectList.DataBind();

            SqlDataSource2.DataBind();
            participantlist.DataBind();


            SqlDataSource3.DataBind();
            otherparticipantlist.DataBind();

            SqlDataSource4.DataBind();
            itemlist.DataBind();


            projectBlock.Visible = false;
            ParticipantStatus(-1, ActiveProject, ActiveProjectPart);
            ItemStatus(-1, ActiveProject, ActiveProjectItem);

            EditProject.Visible = false;
            showitemorparticipant(false, true);
            showlock(true);

        }
        if (status == 4) //Delete 
        {
            //string msg;
            //string title;
            editProjectScreen.Visible = false;

            dh.DeleteProject(InputProjectID);
            ActiveProject = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");

            TextBox1.Text = "";
            TextBox2.Text = "";

            ProjectLabel.Text = "No Active Project";
            AddProjectButton.Visible = false;
            CancelProjectButton.Visible = false;

            SqlDataSource1.DataBind();
            ProjectList.DataBind();

            projectBlock.Visible = true;
            ParticipantStatus(-1, ActiveProject, ActiveProjectPart);
            ItemStatus(-1, ActiveProject, ActiveProjectItem);

            EditProject.Visible = false;
            showitemorparticipant(false, false);
            showlock(false);
           
          
        }

    }

    protected void ShowLast(object s, System.EventArgs e)
    {
        int n = dh.countprojectsPerorganizer((Guid)Membership.GetUser().ProviderUserKey);
        pStart =1+ n-pMax;
        pEnd = n;
        if (pStart < 0) pStart = 1;
        SqlDataSource1.DataBind();
        ProjectList.DataBind();

    }
    protected void ShowNext(object s, System.EventArgs e)
    {
        int n = dh.countprojectsPerorganizer((Guid)Membership.GetUser().ProviderUserKey);
        if (n > pEnd)
        {
            pStart += pMax;
            pEnd += pMax;
            SqlDataSource1.DataBind();
            ProjectList.DataBind();
        }

    }
    protected void ShowPrevious(object s, System.EventArgs e)
    {
        //int pMax2 = pMax;
        //if (pEnd < pMax + 1) pMax2 = pEnd - 1;
        //pStart -= pMax2;
        //pEnd -= pMax2;
        //SqlDataSource1.DataBind();
        //ProjectList.DataBind();


        if (pStart > pMax)
        {
            pStart -= pMax;
            pEnd -= pMax;
        }
        if (pStart <= pMax)
        {
            pStart = 1;
            pEnd = pMax;

        }
        SqlDataSource1.DataBind();
        ProjectList.DataBind();
    }
    protected void ShowFirst(object s, System.EventArgs e)
    {
        pStart = 1;
        pEnd = pMax;
        SqlDataSource1.DataBind();
        ProjectList.DataBind();
    }

    protected void showlock(Boolean show)
    {

        if (show == false) {
            LockLabel.Visible = false;
            LockButton.Visible = false;
        }
        else
        {
            LockLabel.Visible = true;
            LockButton.Visible = true;
            //BackupButton.Visible = true;

            locktype = dh.GetLockTypeProject(ActiveProject);
            if (locktype == "")
            {
                LockLabel.Text = "LOCK ITEMS BEFORE STARTING A PROJECT";
                NewProjectItemButton.Text = "new item";
                LockButton.Text = "lock items in this project";
            }
            if (locktype == "ITEMS")
            {
                LockLabel.Text = "ITEMS LOCKED";
                NewProjectItemButton.Text = "items locked";
                LockButton.Text = "unlock items in this project";
            }
        }
    }

    protected void project_Selecting(object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
    {

        if (Page.User.Identity.IsAuthenticated)
        {
            e.Command.Parameters["@ownerid"].Value = Activeorganizer; //XmlConvert.ToString(Activeorganizer);
            //e.Command.Parameters["@start"].Value = pStart;
            //e.Command.Parameters["@end"].Value = pEnd;
        }
        else
        {
            e.Command.Parameters["@ownerid"].Value = DBNull.Value;
        }

    }

    protected void CancelProjectButton_Click(Object sender, System.EventArgs e)
    {
         
        ProjectStatus(0, ActiveProject);
    }

    protected void CancelEditProjectButton_Click(Object sender, System.EventArgs e) {

        ProjectStatus(3, ActiveProject);

    }

    protected void EditProjectButton_Click(Object sender, System.EventArgs e)
    {

        ProjectStatus(31, ActiveProject);
       
    }

    protected void SwitchView_Click(Object sender, System.EventArgs e)
    {

     
        ActiveProject = XmlConvert.ToGuid(TextBoxProject.Text);
        if (ParticipantsOrItems.Checked == true)
        {
            ParticipantsOrItems.Checked = false;
            //SwitchView.Text = "Show Items";
            //ProjectStatus(3, ActiveProject);
        }
        else
        {
            ParticipantsOrItems.Checked = true;
            //SwitchView.Text = "Show Participants";
            //ProjectStatus(3, ActiveProject);
        }
        ProjectStatus(3, ActiveProject);
         
    }

    protected void showitemorparticipant(Boolean show, Boolean partoritem)
    {
        if (show == true)
        {
            SwitchView.Visible = true;
            if (ParticipantsOrItems.Checked == false)
            {
                //ParticipantsOrItems.Checked=false;
                SwitchView.Text = "Show Items";
                
            }
            else
            {
                //ParticipantsOrItems.Checked = true;
                SwitchView.Text = "Show Participants";
                 
            }
        }
        else
        {
            SwitchView.Visible = false;
        }
}

    protected void LockButton_Click(Object sender, System.EventArgs e)
    {
        
        locktype = dh.GetLockTypeProject(ActiveProject);
        if (locktype == "ITEMS")
        {
            dh.SetLockTypeProject(ActiveProject, "");
             
          

        }
        else
        {
            dh.SetLockTypeProject(ActiveProject, "ITEMS");

            
        }
        showlock(true);

    }

    protected void ALLBackupButton_click(Object sender, System.EventArgs e)
    {
        Response.Redirect("~/Web_Code/backup.aspx");
    }
    
    //protected void BackupButton_Click(Object sender, System.EventArgs e)
    //{
    //     string BackupUrl = "~/Web_Code/backupproject.aspx?" + "organizer=" + XmlConvert.ToString(Activeorganizer) + "&project=" + XmlConvert.ToString(ActiveProject) + "&projectname=" + ActiveProjectName;
    //     Response.Redirect(BackupUrl);
    //}

    protected void NewProjectButton_Click(Object sender, System.EventArgs e)
    {

        ProjectStatus(1, ActiveProject);
    }

    protected void AddProjectButton_Click(Object sender, System.EventArgs e)
    {

        //string test = XmlConvert.ToString(ActiveProject);
        //if (XmlConvert.ToString(ActiveProject) == "00000000-0000-0000-0000-000000000000")
        //{
        
        ProjectStatus(2, ActiveProject);
        //}
        //else 
        //{
        //    ProjectStatus(4, ActiveProject);

        //}

    }

    protected void Edit_Command(Object sender, DataListCommandEventArgs e)
    {

        //int projectN;
        //projectN = dh.countprojects();


        Guid ActiveProject2;

        ActiveProject2 = XmlConvert.ToGuid((string)e.CommandArgument); //e.CommandArgument.ToString

        TextBoxProject.Text = XmlConvert.ToString(ActiveProject2);

        ProjectStatus(3, ActiveProject2);


    }
    protected void YesGiveDeletePermissionProject_Click(Object sender, System.EventArgs e)
    {


        ActiveProject = XmlConvert.ToGuid(TextBoxProject.Text);
        DeletePopup.Visible = false;
        ProjectStatus(4, ActiveProject);

    }

    protected void YesGiveDeletePermissionItem_Click(Object sender, System.EventArgs e)
    {


        ActiveProjectItem= XmlConvert.ToGuid(TextBoxItem.Text);
        DeletePopup.Visible = false;
        ItemStatus(4, ActiveProject,ActiveProjectItem);

    }

    protected void YesGiveDeletePermissionParticipant_Click(Object sender, System.EventArgs e)
    {


        ActiveProjectPart = XmlConvert.ToGuid(TextBoxParticipant.Text);
        DeletePopup.Visible = false;
        ParticipantStatus(4, ActiveProject,ActiveProjectPart);

    }


    protected void NoGiveDeletePermission_Click(Object sender, System.EventArgs e)
    {
        DeletePopup.Visible = false;

    }
    
 

     protected void Delete_Command(Object sender, DataListCommandEventArgs e)
     
    {   
        ActiveProject = XmlConvert.ToGuid((string)e.CommandArgument);

        TextBoxProject.Text = XmlConvert.ToString(ActiveProject);

        YesGiveDeletePermissionButtonProject.Visible = true;
        YesGiveDeletePermissionButtonItem.Visible = false;
        YesGiveDeletePermissionButtonParticipant.Visible = false;

        DeletePopup.Visible = true;


    }

    protected void ParticipantStatus(int status, Guid InputProjectID, Guid InputProjectPartID)
    {
        if (status == -1) //cancel 
        {

            editParticipantScreen.Visible = false;
            ParticipantBlock.Visible = false;

            AddProjectParticipantButton.Visible = false;
            CancelProjectParticipantButton.Visible = false;

          


        }

        if (status == 0) //cancel 
        {

            editParticipantScreen.Visible = false;
            ParticipantBlock.Visible = true;
            
            AddProjectParticipantButton.Visible = false;
            CancelProjectParticipantButton.Visible = false;

          

        }

        if (status == 1) //new  
        {
            ActiveProjectPart = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
            TextBoxParticipant.Text = XmlConvert.ToString(ActiveProjectPart);
            editParticipantScreen.Visible = true;

            Pfirstname.Text = "";
            Plastname.Text = "";
            
            pvar1.Text = "";
            pvar2.Text = "";
            pvar3.Text = "";
            pvar4.Text = "";
            pvar5.Text = "";

            Pfunction.Text = "";
            Porganisation.Text = "";
            Pemail.Text = "";
            
            AddProjectParticipantButton.Visible = true;
            AddProjectParticipantButton.Text = "Add";
            CancelProjectParticipantButton.Visible = true;

           


        }
        if (status == 2) //Save or Update 
        {

            //is dubbel (ook al check bij wegschrijven database..)
            string PFN = "";
            string PLN = "";
            string PEM = "";
            string PFU = "";
            string POR = "";
            string PV1 = "";
            string PV2 = "";
            string PV3 = "";
            string PV4 = "";
            string PV5 = "";

            if (Pfirstname.Text.Trim().Length <= 50) { PFN = Pfirstname.Text.Trim(); } else { PFN = Pfirstname.Text.Trim().Substring(0, 50); }
            if (Plastname.Text.Trim().Length <= 50) { PLN = Plastname.Text.Trim(); } else { PLN = Plastname.Text.Trim().Substring(0, 50); }
            if (Pemail.Text.Trim().Length <= 50) { PEM = Pemail.Text.Trim(); } else { PEM = Pemail.Text.Trim().Substring(0, 50); }
            if (Pfunction.Text.Trim().Length <= 50) { PFU = Pfunction.Text.Trim(); } else { PFU = Pfunction.Text.Trim().Substring(0, 50); }
            if (Porganisation.Text.Trim().Length <= 50) { POR = Porganisation.Text.Trim(); } else { POR = Porganisation.Text.Trim().Substring(0, 50); }
            if (pvar1.Text.Trim().Length <= 20) { PV1 = pvar1.Text.Trim(); } else { PV1 = pvar1.Text.Trim().Substring(0, 20); }
            if (pvar2.Text.Trim().Length <= 20) { PV2 = pvar2.Text.Trim(); } else { PV2 = pvar2.Text.Trim().Substring(0, 20); }
            if (pvar3.Text.Trim().Length <= 20) { PV3 = pvar3.Text.Trim(); } else { PV3 = pvar3.Text.Trim().Substring(0, 20); }
            if (pvar4.Text.Trim().Length <= 20) { PV4 = pvar4.Text.Trim(); } else { PV4 = pvar4.Text.Trim().Substring(0, 20); }
            if (pvar5.Text.Trim().Length <= 20) { PV5 = pvar5.Text.Trim(); ;} else { PV5 = pvar5.Text.Trim().Substring(0, 20); } 

            //string test = XmlConvert.ToString(ActiveProject);
            if (XmlConvert.ToString(InputProjectPartID) == "00000000-0000-0000-0000-000000000000") //save for the first time
            {
              

                //string pf = Pfirstname.Text.Trim();

                if ( Pfirstname.Text.Trim() != "" || Plastname.Text.Trim() != "") 
                {
                    string pass = XmlConvert.ToString(System.Guid.NewGuid());
                    string name = XmlConvert.ToString(System.Guid.NewGuid());
                    string result = usr.AddAriadneUser(name, pass, Pemail.Text.Trim(), "user");
                    //ActiveProjectPart = dh.AddNewParticipantToCurrentProject(InputProjectID, name, pass, Pfirstname.Text.Trim(), Plastname.Text.Trim(), Pemail.Text.Trim(), Pfunction.Text.Trim(), Porganisation.Text.Trim(), pvar1.Text.Trim(), pvar2.Text.Trim(), pvar3.Text.Trim(), pvar4.Text.Trim(), pvar5.Text.Trim());
                    ActiveProjectPart = dh.AddNewParticipantToCurrentProject(InputProjectID, name, pass, PFN, PLN, PEM, PFU, POR, PV1, PV2, PV3, PV4, PV5);
              
                    TextBoxParticipant.Text = XmlConvert.ToString(ActiveProjectPart);
                    AddProjectParticipantButton.Visible = true;               
                    AddProjectParticipantButton.Text = "Update";

 
                }

                else
                {
                }
            }
            else //Update  
            {
                object result = dh.UpdateParticipantToCurrentProject(InputProjectPartID, PFN, PLN, PEM, PFU, POR, PV1, PV2, PV3, PV4, PV5);
 
            }

            CancelProjectParticipantButton.Visible = false;
            editParticipantScreen.Visible = false;


        }
        if (status == 3) //Edit  
        {
            ArrayList objl = new ArrayList();


            editParticipantScreen.Visible = true;

            objl = dh.EditParticipant(InputProjectPartID);
            ActiveProjectPart = (Guid)objl[0]; // XmlConvert.ToGuid((string)objl[0]);
            Pfirstname.Text = (string)objl[1];
            Plastname.Text = (string)objl[2];
            Pemail.Text = (string)objl[3];
            Pfunction.Text = (string)objl[4];
            Porganisation.Text = (string)objl[5];

            pvar1.Text = (string)objl[6];
            pvar2.Text = (string)objl[7];
            pvar3.Text = (string)objl[8];
            pvar4.Text = (string)objl[9];
            pvar5.Text = (string)objl[10];

            AddProjectParticipantButton.Visible = true;
            
            AddProjectParticipantButton.Text = "Update";
            CancelProjectParticipantButton.Visible = true;

          

          

            //

        }

        if (status == 4) //Delete
        {
            //string msg;
            //string title;

            dh.DeleteParticipantFromCurrentProject(InputProjectID, InputProjectPartID);

            editParticipantScreen.Visible = false;

            Pfirstname.Text = "";
            Plastname.Text = "";
            Pemail.Text = "";

            
            AddProjectParticipantButton.Visible = false;
            CancelProjectParticipantButton.Visible = false;



 

        }
        if (status == 5) //Add from other particioants list..
        {
            object result = dh.ExistingParticipantToCurrentProject(InputProjectPartID, InputProjectID);
            SqlDataSource2.DataBind();
            participantlist.DataBind();

 

        }

        SqlDataSource2.DataBind();
        participantlist.DataBind();

        SqlDataSource3.DataBind();
        otherparticipantlist.DataBind();

    }

    protected void NewProjectParticipantButton_Click(object sender, EventArgs e)
    {
        ParticipantStatus(1, ActiveProject, ActiveProjectPart);
    }

    protected void addnewprojectparticipantbutton_Click(Object sender, System.EventArgs e)
    {
        ParticipantStatus(2, ActiveProject, ActiveProjectPart);

    }

    protected void addexistingparticipanttoCurrentproject_Command(Object sender, DataListCommandEventArgs e)
    {

        Guid Part;
        Part = XmlConvert.ToGuid((string)e.CommandArgument);
        ParticipantStatus(5, ActiveProject, Part);


    }



    protected void EditParticipant_Command(Object sender, DataListCommandEventArgs e)
    {
        Guid ActiveProjectPart2;
        ActiveProjectPart2 = XmlConvert.ToGuid((string)e.CommandArgument);
        TextBoxParticipant.Text = XmlConvert.ToString(ActiveProjectPart2);
        ParticipantStatus(3, ActiveProject, ActiveProjectPart2);

    }



    protected void RemoveProjectParticipantButton_Click(object sender, EventArgs e)
    {

        TextBoxParticipant.Text = XmlConvert.ToString(ActiveProjectPart);
        ParticipantStatus(4, ActiveProject, ActiveProjectPart);
        
    }

    protected void RemoveProjectParticipant_Command(Object sender, DataListCommandEventArgs e)
    {

        //Guid ActiveProjectPart2;
        //ActiveProjectPart2 = XmlConvert.ToGuid((string)e.CommandArgument);
        //ParticipantStatus(4, ActiveProject, ActiveProjectPart2);

        ActiveProjectPart  = XmlConvert.ToGuid((string)e.CommandArgument);
        TextBoxParticipant.Text = XmlConvert.ToString(ActiveProjectPart);
 
        YesGiveDeletePermissionButtonProject.Visible = false;
        YesGiveDeletePermissionButtonItem.Visible = false;
        YesGiveDeletePermissionButtonParticipant.Visible = true;

        DeletePopup.Visible = true;


    }

    protected void CancelProjectParticipantButton_Click(object sender, EventArgs e)
    {

        ParticipantStatus(0, ActiveProject, ActiveProjectItem);

    }
 
    protected void ShowLastP(object s, System.EventArgs e)
    {
        int n = dh.countparticipantsPerorganizer(ActiveProject);
        paStart = 1 + n - paMax;
        paEnd = n;
        SqlDataSource2.DataBind();
        participantlist.DataBind();
 

    }
    protected void ShowNextP(object s, System.EventArgs e)
    {

        int n = dh.countparticipantsPerorganizer(ActiveProject);
        if (n > paEnd)
        {
            paStart += paMax;
            paEnd += paMax;
            SqlDataSource2.DataBind();
            participantlist.DataBind();
        }


 
    }
    protected void ShowPreviousP(object s, System.EventArgs e)
    {
        if (paStart > paMax)
        {
            paStart -= paMax;
            paEnd -= paMax;
        }
        if (paStart <= paMax)
        {
            paStart = 1;
            paEnd = paMax;

        }
        SqlDataSource2.DataBind();
        participantlist.DataBind();
 
    }
    protected void ShowFirstP(object s, System.EventArgs e)
    {
        paStart = 1;
        paEnd = paMax;
        SqlDataSource2.DataBind();
        participantlist.DataBind();
 
    }

    protected void ShowLastPO(object s, System.EventArgs e)
    {
        int n = dh.countNonparticipantsPerorganizer(ActiveProject);
        paoStart = 1 + n - paoMax;
        paoEnd = n;
 

        SqlDataSource3.DataBind();
        otherparticipantlist.DataBind();

    }
    protected void ShowNextPO(object s, System.EventArgs e)
    {

        int n = dh.countNonparticipantsPerorganizer(ActiveProject);
        if (n > paoEnd)
        {
            paoStart += paoMax;
            paoEnd += paoMax;
            SqlDataSource3.DataBind();
            otherparticipantlist.DataBind();
        }

    }
    protected void ShowPreviousPO(object s, System.EventArgs e)
    {
        if (paoStart > paoMax)
        {
            paoStart -= paoMax;
            paoEnd -= paoMax;
        }
        if (paoStart <= paoMax)
        {
            paoStart = 1;
            paoEnd = paoMax;

        }
        SqlDataSource3.DataBind();
        otherparticipantlist.DataBind();
    }
    protected void ShowFirstPO(object s, System.EventArgs e)
    {
        paoStart = 1;
        paoEnd = paoMax;
        SqlDataSource3.DataBind();
        otherparticipantlist.DataBind();
    }

    protected void participant_Selecting(Object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
    {

        if (Page.User.Identity.IsAuthenticated)
        {
            //e.Command.Parameters("@organizerId").Value = Activeorganizer;
            e.Command.Parameters["@ProjectId"].Value = ActiveProject;
            e.Command.Parameters["@start"].Value = paStart;
            e.Command.Parameters["@end"].Value = paEnd;
        }
        else
        {
            //e.Command.Parameters["@organizerId"].Value = DBNull.Value;
            e.Command.Parameters["@ProjectId"].Value = DBNull.Value;

        }
    }

    protected void all_participant_Selecting(Object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            //e.Command.Parameters["@organizerid"].Value = Membership.GetUser().ProviderUserKey.ToString;
            e.Command.Parameters["@ProjectId"].Value = ActiveProject;
            e.Command.Parameters["@start"].Value = paoStart;
            e.Command.Parameters["@end"].Value = paoEnd;
        }
        else
        {
            e.Command.Parameters["@organizerId"].Value = DBNull.Value;
            e.Command.Parameters["@ProjectId"].Value = DBNull.Value;
        }
    }



    protected void MemberSqlDataSource_Selecting(Object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            //e.Command.Parameters["@ownerid"].Value = Membership.GetUser().ProviderUserKey.ToString;
        }
        else
        {
            e.Command.Parameters["@ownerid"].Value = DBNull.Value;
        }
    }

    protected void MemberDetailsSqlDataSource_Selecting(Object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            //'''e.Command.Parameters("@ownerid").Value = Membership.GetUser().ProviderUserKey.ToString
        }
        else
        {
            // '''e.Command.Parameters("@ownerid").Value = DBNull.Value
        }
    }


    //ITEM HANDLING 

     //SelectCommand="SELECT items.itemid, items.itemtext FROM items WHERE  ProjectId = @ProjectId"


    protected void all_items_Selecting(Object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            e.Command.Parameters["@projectid"].Value = ActiveProject;
            e.Command.Parameters["@start"].Value = itStart;
            e.Command.Parameters["@end"].Value = itEnd;
        }
        else
        {
            e.Command.Parameters["@projectid"].Value = DBNull.Value;
        }
    }


    protected void ItemStatus(int status, Guid InputProjectID, Guid InputProjectItemID)
    {
        if (status == -1) //cancel 
        {

            editItemScreen.Visible = false;
            ItemBlock.Visible = false;

            AddProjectItemButton.Visible = false;
            CancelProjectItemButton.Visible = false;


        }
        if (status == 0) //cancel 
        {

            editItemScreen.Visible = false;
            ItemBlock.Visible = true;

            AddProjectItemButton.Visible = false;
            CancelProjectItemButton.Visible = false;


        }
        if (status == 1) //start new  
        {
            ActiveProjectItem = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
            TextBoxItem.Text = XmlConvert.ToString(ActiveProjectItem);

            editItemScreen.Visible = true;
            ItemText.Text = "";
    
            AddProjectItemButton.Visible = true;
      
            AddProjectItemButton.Text = "Add";
            CancelProjectItemButton.Visible = true;

            int ItemN = dh.countitems(ActiveProject);
            ItemNText.Text = "Number of items up to now: " + ItemN.ToString("0");

        }
        if (status == 2)
        {

            //string test = XmlConvert.ToString(ActiveProject);
            if (XmlConvert.ToString(InputProjectItemID) == "00000000-0000-0000-0000-000000000000") //save a item for the first time
            {


                if (ItemText.Text != "")
                {
                    ActiveProjectItem = dh.AddNewItem(InputProjectID, ItemText.Text);
                    TextBoxItem.Text = XmlConvert.ToString(ActiveProjectItem);

                    AddProjectItemButton.Visible = true;
                    AddProjectItemButton.Text = "Update";
    
                }

                else
                {
                }
            }
            else
            {
                object result = dh.UpdateItem(InputProjectID, InputProjectItemID, ItemText.Text);

    
            }
            CancelProjectItemButton.Visible = false;
            editItemScreen.Visible = false;

        }
        if (status == 3) //Edit a project
        {

            ArrayList objl = new ArrayList();
            objl = dh.EditItem(InputProjectItemID);
            ActiveProjectItem = (Guid)objl[0]; // XmlConvert.ToGuid((string)objl[0]);

            editItemScreen.Visible  = true;

            ItemText.Text = (string)objl[1];
 
            AddProjectItemButton.Visible = true;
        
            AddProjectItemButton.Text = "Update";
            CancelProjectItemButton.Visible = true;

     

            AddProjectParticipantButton.Text = "Update";
            //
            int ItemN = dh.countitems(ActiveProject);
            ItemNText.Text = "Number of items up to now: " + ItemN.ToString("0");

        }

        if (status == 4) //Delete a project
        {
            //string msg;
            //string title;

            dh.DeleteItem(InputProjectID, InputProjectItemID);

            editItemScreen.Visible  = false;
            ItemText.Text = "";

       
            AddProjectItemButton.Visible = false;
         
            CancelProjectItemButton.Visible = false;

 


        }

        SqlDataSource4.DataBind();
        itemlist.DataBind();

    }

    protected void ShowLastI(object s, System.EventArgs e)
    {
        int n = dh.countitemsPerorganizer( ActiveProject);
        itStart = 1 + n - itMax;
        itEnd = n;
        SqlDataSource4.DataBind();
        itemlist.DataBind();

    }
    protected void ShowNextI(object s, System.EventArgs e)
    {
        int n = dh.countitemsPerorganizer(ActiveProject);
        if (n > itEnd)
        {
            itStart += itMax;
            itEnd += itMax;
            SqlDataSource4.DataBind();
            itemlist.DataBind();
        }
    }
    protected void ShowPreviousI(object s, System.EventArgs e)
    {
        if (itStart > itMax)
        {
            itStart -= itMax;
            itEnd -= itMax;
        }
        if (itStart <= itMax)
        {
            itStart = 1;
            itEnd = itMax;

        }
        SqlDataSource4.DataBind();
        itemlist.DataBind();
    }
    protected void ShowFirstI(object s, System.EventArgs e)
    {
        itStart = 1;
        itEnd = itMax;
        SqlDataSource4.DataBind();
        itemlist.DataBind();
    }

   

    protected void NewProjectItem_Click(object sender, EventArgs e)
    {
        if (locktype != "ITEMS") ItemStatus(1, ActiveProject, ActiveProjectItem);

    }

    protected void addProjectItem_Click(object sender, EventArgs e)
    {

        if (locktype != "ITEMS")  ItemStatus(2, ActiveProject, ActiveProjectItem);

    }

    protected void EditProjectItem_Command(Object sender, DataListCommandEventArgs e)
    {

        if (locktype != "ITEMS")
        {
            Guid ActiveProjectItem2 = XmlConvert.ToGuid((string)e.CommandArgument);
            TextBoxItem.Text = XmlConvert.ToString(ActiveProjectItem2);

            ItemStatus(3, ActiveProject, ActiveProjectItem2);
        }



    }

    //protected void RemoveProjectItem_Click(object sender, EventArgs e)
    //{

    //    ItemStatus(4, ActiveProject, ActiveProjectItem);

    //}


    protected void DeleteProjectItem_Command(Object sender, DataListCommandEventArgs e)
    {
        locktype = dh.GetLockTypeProject(ActiveProject);
        if (locktype != "ITEMS")
        {
            //Guid ActiveProjectItem2 = XmlConvert.ToGuid((string)e.CommandArgument);
            //ItemStatus(4, ActiveProject, ActiveProjectItem2);


            ActiveProjectItem = XmlConvert.ToGuid((string)e.CommandArgument);
            TextBoxItem.Text = XmlConvert.ToString(ActiveProjectItem);

            YesGiveDeletePermissionButtonProject.Visible = false;
            YesGiveDeletePermissionButtonItem.Visible = true;
            YesGiveDeletePermissionButtonParticipant.Visible = false;

            DeletePopup.Visible = true;


        }
    }


    protected void CancelProjectItemButton_Click(object sender, EventArgs e)
    {

        ItemStatus(0, ActiveProject, ActiveProjectItem);

    }
    

    protected void showitems_click(Object sender, System.Web.UI.ImageClickEventArgs e)
    {
        int ItemN;
        ArrayList objl = new ArrayList();
        ItemN = dh.countitems(ActiveProject);
        objl = dh.SelectAllItems(ActiveProject);
        string ss;
        for (int i = 1; i <= ItemN; i++)
        {
            ss = (string)objl[i - 1];
        }
    }

 
    //protected void ShowSortParticipant_Command(Object sender, DataListCommandEventArgs e)
    //{

    //    ArrayList objl = new ArrayList();
    //    ActiveProjectPart = XmlConvert.ToGuid((string)e.CommandArgument);
    //    TextBoxParticipant.Text = XmlConvert.ToString(ActiveProjectPart);
    //    Response.Redirect("~/Web_Code/AriadneSort?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveProjectPart) + "&save=no");

    //}

    //protected void ShowRateParticipant_Command(Object sender, DataListCommandEventArgs e)
    //{

    //    ArrayList objl = new ArrayList();
    //    ActiveProjectPart = XmlConvert.ToGuid((string)e.CommandArgument);
    //    TextBoxParticipant.Text = XmlConvert.ToString(ActiveProjectPart);
    //    Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveProjectPart) + "&ratetype=1" + "&save=no");

    //}

     
    protected void ShowConceptMap_Command(Object sender, DataListCommandEventArgs e)
    {
        ActiveProject = XmlConvert.ToGuid((string)e.CommandArgument);
        TextBoxProject.Text = XmlConvert.ToString(ActiveProject);
        //Response.Redirect("~/Web_Code/AriadneConceptSelAndMap.aspx?" + "organizer=" + XmlConvert.ToString(Activeorganizer) + "&project=" + XmlConvert.ToString(ActiveProject));
        Response.Redirect("~/Web_Code/AriadneConceptSel.aspx?" + "organizer=" + XmlConvert.ToString(Activeorganizer) + "&project=" + XmlConvert.ToString(ActiveProject));
    }


    protected void ShowParticipantsLinks_Command(Object sender, DataListCommandEventArgs e)
    {
        ActiveProject = XmlConvert.ToGuid((string)e.CommandArgument);
        TextBoxProject.Text = XmlConvert.ToString(ActiveProject);
        Response.Redirect("~/Web_Code/participantsLinks.aspx?" + "project=" + XmlConvert.ToString(ActiveProject));
    }


}
