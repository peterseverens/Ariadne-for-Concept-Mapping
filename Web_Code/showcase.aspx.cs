using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml;
using System.Collections;

public partial class _Showcase : System.Web.UI.Page
{

    public static Guid Activeorganizer;
    public static Guid Activeparticipant;
    public static Guid Activeproject;
    public static Guid ActiveExcerpt;

    public static int pMax = 15;
    public static int pStart = 1;
    public static int pEnd = pMax;

    public static int paMax = 8;
    public static int paStart = 1;
    public static int paEnd = paMax;

    public static int paoMax = 10;
    public static int paoStart = 1;
    public static int paoEnd = paoMax;

    public static int itMax = 15;
    public static int itStart = 1;
    public static int itEnd = itMax;

    DataHandling dh = new DataHandling();

    protected void Page_Load(object sender, EventArgs e)
    {
        

        editParticipantScreen.Visible = false;
        if (Page.User.Identity.IsAuthenticated)
        {

            if (Roles.IsUserInRole("administrator"))
            {
                EditButtonDiv.Visible = true;
                UpdateExcerptButton.Visible = true;
                RemoveExcerptButton.Visible = true;
            }
            
        }
        else
        {
            EditButtonDiv.Visible = false;
            UpdateExcerptButton.Visible = false;
            RemoveExcerptButton.Visible = false;
        }
    }

     

    

    
    

    protected void NewExcerptButton_Click(Object sender, System.EventArgs e)
    {
        ProjectTitle.Text = "";
        ProjectExcerptShort.Text ="";
        ProjectExcerpt.Text="";
        ProjectAuthor.Text = "";
        ActiveExcerpt = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
        editParticipantScreen.Visible = true;
    }

    protected void CancelButton_Click(Object sender, System.EventArgs e)
    {
        ProjectTitle.Text = "";
        ProjectExcerptShort.Text = "";
        ProjectExcerpt.Text = "";
        ProjectAuthor.Text = "";
        ActiveExcerpt = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
        editParticipantScreen.Visible = false;
    }

    protected void Edit_Command(Object sender, DataListCommandEventArgs e)
    {

        
        
        ActiveExcerpt = XmlConvert.ToGuid((string)e.CommandArgument); //e.CommandArgument.ToString
        ArrayList objl = dh.EditExcerpt(ActiveExcerpt);
        ProjectTitle.Text = (string)objl[0];
        ProjectExcerptShort.Text = (string)objl[1];
        ProjectExcerpt.Text = (string)objl[2];
        ProjectAuthor.Text = (string)objl[3];
        editParticipantScreen.Visible = true;
        //ProjectStatus(3, ActiveProject2);


    }


    protected void UpdateExcerptButton_Click(Object sender, System.EventArgs e)
    {
        if (XmlConvert.ToString(ActiveExcerpt) == "00000000-0000-0000-0000-000000000000")
        {
            if (ProjectTitle.Text != "")
            {
                ActiveExcerpt = dh.AddNewExcerpt(ProjectTitle.Text, ProjectExcerptShort.Text, ProjectExcerpt.Text, ProjectAuthor.Text);
            }
        }
        else {
            object result = dh.UpdateExcerpt(ActiveExcerpt, ProjectTitle.Text, ProjectExcerptShort.Text, ProjectExcerpt.Text, ProjectAuthor.Text);
        }
        SqlDataSource.DataBind();
        ProjectList.DataBind();
        ProjectTitle.Text = "";
        ActiveExcerpt = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
        editParticipantScreen.Visible = false;

    }

    protected void RemoveExcerptButton_Click(Object sender, System.EventArgs e)
    {

        object result = dh.DeleteExcerpt(ActiveExcerpt);
        SqlDataSource.DataBind();
        ProjectList.DataBind();
        ProjectTitle.Text = "";
        ActiveExcerpt = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
        editParticipantScreen.Visible = false;
    }
   
}
