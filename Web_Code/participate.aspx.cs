using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml;
using System.Web.UI.HtmlControls;
using System.Collections;

public partial class _Participate : System.Web.UI.Page
{
    //Guid Activeorganizer;
    Guid ActiveProject;
    Guid ActiveParticipant;
    string PartUrl="";

    string userName = "";
    string passName = "";

    DataHandling dh = new DataHandling();
    AriadneUsers usr = new AriadneUsers();
     UtilsDataStrings uts = new UtilsDataStrings();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //if (Request.UrlReferrer != null)
            //{
            //    currentPage = Request.UrlReferrer.ToString();
            //}

           // HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("BodyContent");
           // body.Attributes.Add("onunload", "UnloadFunction()");


            //MembershipUser user = Membership.GetUser(User.Identity.Name);
            //if (user == null)
            //{
            //    Response.Redirect("~/Account/Login.aspx");

                // throw new InvalidOperationException("User [" +
                //     User.Identity.Name + " ] not found.");
            //}

            //if (Page.User.Identity.IsAuthenticated)
            //{

            //    Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
            //    string usrnm = Membership.GetUser().UserName;
            //    Boolean admin = Roles.IsUserInRole("administrator");

            //    if (admin==true) {
            //        Response.Redirect("~/Web_Code/organise.aspx");           
            //    }
            //    else
            //    {       
            //    }
            //}

            if (Request.QueryString["project"] != null)
            {
                ActiveProject = XmlConvert.ToGuid(Request.QueryString["project"]);
                if (ActiveProject == System.Xml.XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000"))
                {
                }
                else
                {
                    TextBoxProject.Text = XmlConvert.ToString(ActiveProject);
                }
            }
            if (Request.QueryString["participant"] != null) 
                //participate.aspx?project=f564ef55-693a-4613-b603-fa5a9e310b88&participant=75da1d08-56be-4df9-9dc9-fac2d2f42dc4&username=aSAaSAs&passname=5ec110cf-d42e-4d9f-92be-2f65985f4f71
            {
                ActiveParticipant= XmlConvert.ToGuid(Request.QueryString["participant"]);
                if (ActiveProject == System.Xml.XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000"))
                {
                }
                else
                {
                    TextBoxParticipant.Text = XmlConvert.ToString(ActiveParticipant);
                                    }
            }
            if (Request.QueryString["username"] != null)
            {
                userName =  Request.QueryString["username"] ;
                
            }
            if (Request.QueryString["passname"] != null)
            {
                passName = Request.QueryString["passname"];
            }

            if (userName != "" & passName != "")
            {


                string usrnm = "";
                if (Page.User.Identity.IsAuthenticated)
                {
                    usrnm = Membership.GetUser().UserName;
                }
            

                if (usrnm != userName)
                {

//                    if (Membership.ValidateUser(userName, passName))
//                    {
//                        FormsAuthentication.RedirectFromLoginPage(userName, true);
//                        string PartUrl = "participate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveParticipant) + "&username=" + userName + "&passname=" + passName;
//                        Response.Redirect(PartUrl);
//                    }

                    string result = usr.loginAsUser(userName, passName);
                    if (result == "user" || result == "organizer" || result == "administrator")
                    {

                        PartUrl = "~/Web_Code/participate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveParticipant) + "&username=" + userName + "&passname=" + passName;
                       Response.Redirect(PartUrl);

                       
                     
                    }
                    else
                    {
                        //string etext = "Login failed. Please check your user name and password and try again.";
                        Response.Redirect("~/Account/login.aspx");
                    }
                    //Response.Redirect("~/Web_Code/AriadneSort.aspx?" + "project=" + XmlConvert.ToString(ActiveProject) + "&participant=" + XmlConvert.ToString(ActiveParticipant));
                }
                usernameInfo.Text = userName;
                passnameInfo.Text = passName;
                usernameLabel.Text = dh.GetFirstnameFromUserName(userName) + " " + dh.GetLastnameFromUserName(userName);

                        ArrayList objl = new ArrayList();

                        objl = dh.EditProject(ActiveProject);
                        ArrayList rateVar =new ArrayList();

                        rateVar = uts.getRateVars(objl[4].ToString());
                        if (rateVar.Count > 0)
                        {
                            ImageButtonRate.Visible = true; ImageButtonRate.Text = ((string)rateVar[0]).Trim();
                        }
                        else
                        {
                            ImageButtonRate.Visible = true; ImageButtonRate.Text = "Importance";
                        }
                        rateVar = uts.getRateVars(objl[5].ToString()); if (rateVar.Count > 0) { ImageButtonRate2.Visible = true; ImageButtonRate2.Text = ((string)rateVar[0]).Trim(); } else { ImageButtonRate2.Visible = false; }
                        rateVar = uts.getRateVars(objl[6].ToString()); if (rateVar.Count > 0) { ImageButtonRate3.Visible = true; ImageButtonRate3.Text = ((string)rateVar[0]).Trim(); } else { ImageButtonRate3.Visible = false; }
                        rateVar = uts.getRateVars(objl[7].ToString()); if (rateVar.Count > 0) { ImageButtonRate4.Visible = true; ImageButtonRate4.Text = ((string)rateVar[0]).Trim(); } else { ImageButtonRate4.Visible = false; }
                        rateVar = uts.getRateVars(objl[8].ToString()); if (rateVar.Count > 0) { ImageButtonRate5.Visible = true; ImageButtonRate5.Text = ((string)rateVar[0]).Trim(); } else { ImageButtonRate5.Visible = false; }
                       


            }
            else
            {
                Response.Redirect("~/Account/login.aspx");
            }
        }
    }


    protected void ImageButtonSort_Click(object s, System.EventArgs e)
    {
        //string username2 = Membership.GetUser().UserName;
        //string passname2 = dh.GetParticipantPasname(username2);

        //Guid ActiveParticipant2 = dh.GetParticipantId(username2);

        //Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        //Response.Redirect("~/Web_Code/AriadneSort.aspx?" + "project=" + XmlConvert.ToString(ActiveProject2) + "&participant=" + XmlConvert.ToString(ActiveParticipant2) + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);

        Response.Redirect("~/Web_Code/AriadneSort.aspx?" + "project=" + TextBoxProject.Text + "&participant=" + TextBoxParticipant.Text + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);
    }

    protected void ImageButtonRate_Click(object s, System.EventArgs e)
    {

        //string username2 = Membership.GetUser().UserName;
        //string passname2 = dh.GetParticipantPasname(username2);

        //Guid ActiveParticipant2 = dh.GetParticipantId(username2);

        //Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        //Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject2) + "&participant=" + XmlConvert.ToString(ActiveParticipant2) + "&ratetype=1" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);

        Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + TextBoxProject.Text + "&participant=" + TextBoxParticipant.Text + "&ratetype=1" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);
    }

    protected void ImageButtonRate2_Click(object s, System.EventArgs e)
    {

        //string username2 = Membership.GetUser().UserName;
        //string passname2 = dh.GetParticipantPasname(username2);

        //Guid ActiveParticipant2 = dh.GetParticipantId(username2);

        //Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        //Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject2) + "&participant=" + XmlConvert.ToString(ActiveParticipant2) + "&ratetype=2" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);

        Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + TextBoxProject.Text + "&participant=" + TextBoxParticipant.Text + "&ratetype=2" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);
    }

    protected void ImageButtonRate3_Click(object s, System.EventArgs e)
    {

        //string username2 = Membership.GetUser().UserName;
        //string passname2 = dh.GetParticipantPasname(username2);

        //Guid ActiveParticipant2 = dh.GetParticipantId(username2);

        //Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        //Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject2) + "&participant=" + XmlConvert.ToString(ActiveParticipant2) + "&ratetype=3" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);

        Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + TextBoxProject.Text + "&participant=" + TextBoxParticipant.Text + "&ratetype=3" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);
    }

    protected void ImageButtonRate4_Click(object s, System.EventArgs e)
    {

        //string username2 = Membership.GetUser().UserName;
        //string passname2 = dh.GetParticipantPasname(username2);

        //Guid ActiveParticipant2 = dh.GetParticipantId(username2);

        //Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        //Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject2) + "&participant=" + XmlConvert.ToString(ActiveParticipant2) + "&ratetype=4" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);

        Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + TextBoxProject.Text + "&participant=" + TextBoxParticipant.Text + "&ratetype=4" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);
    }

    protected void ImageButtonRate5_Click(object s, System.EventArgs e)
    {

        //string username2 = Membership.GetUser().UserName;
        //string passname2 = dh.GetParticipantPasname(username2);

        //Guid ActiveParticipant2 = dh.GetParticipantId(username2);

        //Guid ActiveProject2 = dh.GetParticipantProject(ActiveParticipant2);

        //Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + XmlConvert.ToString(ActiveProject2) + "&participant=" + XmlConvert.ToString(ActiveParticipant2) + "&ratetype=5" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);

        Response.Redirect("~/Web_Code/AriadneRate.aspx?" + "project=" + TextBoxProject.Text + "&participant=" + TextBoxParticipant.Text + "&ratetype=5" + "&user=" + usernameInfo.Text + "&pass=" + passnameInfo.Text);
    }

}
