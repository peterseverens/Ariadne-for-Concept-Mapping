using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _OptionsOrganisers : System.Web.UI.Page
{

    public   Guid Activeorganizer;

    AriadneUsers usr = new AriadneUsers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        else
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
                if (Roles.IsUserInRole("administrator"))
                {

                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
        }

    }

   

    //protected void Login_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Account/login.aspx");
    //}
    //protected void Register_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Account/register.aspx");
    //}

    public void Addorganizer_Click(object sender, EventArgs e)
    {

        string result = usr.AddAriadneUser(nameBox.Text.Trim(), passBox.Text.Trim(), emailBox.Text.Trim(), "organizer");
        MsgLabel.Text = result;
        organizerlist.DataBind();
    }

    
     
    
    protected void EditOrganizer_Command(Object sender, DataListCommandEventArgs e)
    {
        string result = usr.ResetPassword((string)e.CommandArgument);
        //string result = usr.ChangePassAriadneUser(((string)e.CommandArgument), oldPassBox.Text, newPassBox.Text);
        MsgLabel.Text = result;
        organizerlist.DataBind();
    }

    protected void UpdateOrganizer_Command(Object sender, DataListCommandEventArgs e)
    {
        //usr.ResetPassword((string)e.CommandArgument);
        string result = usr.ChangePassAriadneUser(((string)e.CommandArgument), oldPassBox.Text, newPassBox.Text);
        MsgLabel.Text = result;
        organizerlist.DataBind();
    }


    public void RemoveOrganizer_Command(Object sender, DataListCommandEventArgs e)
    {
        string result = usr.DeleteAriadneUser((string)e.CommandArgument);
        organizerlist.DataBind();
    }


    public void RemoveAllParticipants_Click(object sender, EventArgs e)
    {
        string result = usr.DeleteAllParticipants();
        organizerlist.DataBind();
    }
}
