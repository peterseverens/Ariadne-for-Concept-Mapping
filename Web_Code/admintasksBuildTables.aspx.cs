using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _AdminBuildTables : System.Web.UI.Page
{

    //public static Guid Activeorganizer;

    Utils ut = new Utils();
    AriadneBuildTables artb = new AriadneBuildTables();

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
                //Roles.AddUserToRole("peter22", "administrator");
                //Roles.AddUserToRole("peter22", "organizer");
                //Roles.AddUserToRole("peter22", "user");
                //Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
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

    protected void BuildTables_Click(object sender, EventArgs e)
    {
        string result=artb.BuildTables();
        TextResult.Text = result;
    }
     
    protected void BuildExcerptTables_Click(object sender, EventArgs e)
    {
        string result = artb.BuildExcerptTables();
        TextResult.Text = result;
    }

    protected void BuildUsageInfoTables_Click(object sender, EventArgs e)
    {
        string result = artb.BuildUsageTables();
        TextResult.Text = result;
    }

    
    

    
    protected void BuildTestData_Click(object sender, EventArgs e)
    {
        ut.testdata(1);
        Response.Redirect("~/Web_Code/Organise.aspx");
    }

    protected void BuildTestDataNotRandom_Click(object sender, EventArgs e)
    {
        ut.testdata(2);
        Response.Redirect("~/Web_Code/Organise.aspx");
    }

    protected void BuildTestDataBoth_Click(object sender, EventArgs e)
    {
        ut.testdata(3);
        Response.Redirect("~/Web_Code/Organise.aspx");
    }
    
    
}
