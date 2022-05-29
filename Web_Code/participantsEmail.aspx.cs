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
using System.Net.Mail;


public partial class _ParticipantsEmail : System.Web.UI.Page
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
        string UserPass = e.CommandArgument.ToString();
        int ll = UserPass.IndexOf(";");
        string ProjectPart = UserPass.Substring(0, 36);
        string user = UserPass.Substring(36, ll - 36);
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





    protected void BuildEmails_Click(object sender, EventArgs e)
    {
        ArrayList part = dh.GetAllParticipantsInfoPlus(ActiveProject);
        string textToCopy = ""; string textToCopyT = "";
        for (int p = 0; p < part.Count; p += 7)
        {
            textToCopy = "";

            string firstName = (string)part[p + 0];
            string lastName = (string)part[p + 1];
            string user = (string)part[p + 2];
            string pass = (string)part[p + 3];
            Guid partGuid = (Guid)part[p + 4];
            string ProjectPart = XmlConvert.ToString(partGuid);
            string email = (string)part[p + 5];

            string PartUrl = "http://www.minds21.biz/Web_Code/participate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + ProjectPart.Trim() + "&username=" + user.Trim() + "&passname=" + pass.Trim();

            string PartLink = "<a href=" + "'" + PartUrl + "'" + ">Please follow this link to participate</a>";

            textToCopy += email; textToCopy += "\r\n"; textToCopy += "\r\n";

            textToCopy += "<p> <img alt='' src='http://www.minds21.biz/images_public/ARIADNE for CM.png'  width='20%' /></p>";

            if (lastName.Trim() != "")
            { textToCopy += "<p>Dear " + salutationText.Text + " " + firstName + " " + lastName + ",</p>"; textToCopy += "\r\n"; }
            else
            { textToCopy += "<p>Dear " + salutationText.Text + " " + firstName + ","+ "</p>"; textToCopy += "\r\n"; }

            textToCopy += "<p>" + mailTextBeforeLink.Text.Trim() + "</p>"; textToCopy += "\r\n";
            textToCopy += "<p>" + PartLink + "</p>"; textToCopy += "\r\n";
            textToCopy += "<p>" + mailTextAfterLink.Text.Trim() + "</p>"; textToCopy += "\r\n";

            textToCopyT += textToCopy;
            sendMail("peter.severens@gmail.com", textToCopy);
        }
        EmailFile.Text = textToCopyT;
    }

    private void sendMail(string emailAddress, string mailText)
    {
        try
        {

            MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("send.one.com");
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            //mail.From = new MailAddress("peter.severens@minds21.org");
            mail.From = new MailAddress("ariadneforconceptmapping@gmail.com");
            
            mail.To.Add(emailAddress);
            //mail.ReplyToList.Add(emailAddress);
            //mail.ReplyToList.Add("peter.severens@gmail.com");
            mail.ReplyToList.Add("peter.severens@minds21.org");
            mail.Subject = "Test Mail";
            mail.IsBodyHtml = true;
            mail.Body = mailText;

            //SmtpServer.Port = 465;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = true;
            SmtpServer.EnableSsl = true;
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("peter.severens@minds21.org", "openslaandedeuren");
            SmtpServer.Credentials = new System.Net.NetworkCredential("ariadneforconceptmapping@gmail.com", "Troubleshooting67^&");
            SmtpServer.Timeout = 20000;

            SmtpServer.Send(mail);
            warninglabel.Text = "mail Send";



        }
        catch (Exception ex)
        {
            warninglabel.Text = ex.ToString();
        }
    }
}
