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


public partial class _Participants : System.Web.UI.Page
{

    public static Guid Activeorganizer;
    public static Guid ActiveProject;
    public static Guid ActiveProjectPart;
    public static Guid ActiveProjectItem;

    public static Random random = new Random();

 

    public static int paMax = 20;
    public static int paStart = 1;
    public static int paEnd = paMax;

    DataHandling dh = new DataHandling();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            MembershipUser user = Membership.GetUser(User.Identity.Name);
            if (user == null)
            {
                Response.Redirect("~/Account/Login.aspx");

                // throw new InvalidOperationException("User [" +
                //     User.Identity.Name + " ] not found.");
            }

            if (Page.User.Identity.IsAuthenticated)
            {

                Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;


            }

            if (Request.QueryString["project"] != null)
            {
                ActiveProject = XmlConvert.ToGuid(Request.QueryString["project"]);
                if (ActiveProject == XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000"))
                {
                    PartBlock.Visible = false;

                }
                else
                {
                    PartBlock.Visible = true;

                }
                SqlDataSource2.DataBind();
                participantlist.DataBind();




            }
        }
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

    protected void toParticipantPage_Command(Object sender, DataListCommandEventArgs e)
    {
        //string etext = "";
        string UserPass =  e.CommandArgument.ToString() ;
        int ll = UserPass.IndexOf(";");
        string ProjectPart = UserPass.Substring(0, 36);
        string user = UserPass.Substring(36, ll-36);
        string pass = UserPass.Substring(ll + 1, 36);
        string PartUrl = "~/Web_Code/participate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + ProjectPart.Trim() + "&username=" + user.Trim() + "&passname=" + pass.Trim();
        LinkButton.Text = PartUrl;
        LinkButton.PostBackUrl = PartUrl;
         
        //if (Membership.ValidateUser(user, pass))
        //    FormsAuthentication.RedirectFromLoginPage(user, true);
        //else
        //    etext = "Login failed. Please check your user name and password and try again.";

        //ActiveProjectPart = XmlConvert.ToGuid((string)ProjectPart);
        //Response.Redirect("~/Web_Code/AriadneSort.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveProjectPart));
    }
     
    protected void ShowSortParticipant_Command(Object sender, DataListCommandEventArgs e)
    {

        ArrayList objl = new ArrayList();
        ActiveProjectPart = XmlConvert.ToGuid((string)e.CommandArgument);
        Response.Redirect("~/Web_Code/AriadneSort.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveProjectPart) + "&save=no");

    }

    //protected void ShowRateParticipant1_Command(Object sender, DataListCommandEventArgs e)
    //{
//
//        ArrayList objl = new ArrayList();
//        ActiveProjectPart = XmlConvert.ToGuid((string)e.CommandArgument);
//        Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveProjectPart) + "&ratetype=1" + "&save=no");
//
//    }
   
    protected void ShowRateParticipant_Command(Object sender, DataListCommandEventArgs e)
    {

        ArrayList objl = new ArrayList();
        string Argument = (string)e.CommandArgument;
        string RateNumber = Argument.Substring(0, 1);
        ActiveProjectPart = XmlConvert.ToGuid(Argument.Substring(1,36));
        Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveProjectPart) + "&ratetype=" + RateNumber + "&save=no");

    }



    protected void BuildEmails_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web_Code/participantsEmail.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) );
    }
}
