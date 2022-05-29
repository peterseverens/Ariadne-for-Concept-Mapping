using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{

    public static Guid Activeorganizer;
    public static Guid Activeparticipant;
    public static Guid Activeproject;

    DataHandling dh = new DataHandling();

    protected void Page_Load(object sender, EventArgs e)
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
                if (roles[i] == "organiser") organiser = true;
            }
        }
        //dh.AddUserInfo("Default.aspx", ip, usrnm, user, organiser);

        //END USER STATISTICS

        if (Page.User.Identity.IsAuthenticated)
        {

            if (Roles.IsUserInRole("user"))
            {
                Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
                string username = Membership.GetUser().UserName;

                string passname = dh.GetParticipantPasname(username);

                Activeparticipant  = dh.GetParticipantId(username);

                Activeproject = dh.GetParticipantProject(Activeparticipant);

                string project = XmlConvert.ToString(Activeproject);
                string participant = XmlConvert.ToString(Activeparticipant);

                string qq= "?userName=" + username + "&passName=" +passname + "&project=" + project+ "&participant=" + participant;
                Response.Redirect("~/Web_Code/participate.aspx" + qq);
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
    //protected void LinkButton_Click(object sender, EventArgs e)
    //{
    //    string result =AriadneUsers.loginAsUser("Peter22", "bieten22");
    //    if (result=="administrator") Response.Redirect("organise.aspx");
    //}
}
