using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _OptionsClicks : System.Web.UI.Page
{

    public   Guid Activeorganizer;

    AriadneUsers usr = new AriadneUsers();

    int pageSize = 5;
    int totalUsers;
    int totalPages;
    int currentPage = 1;

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
                    if (!IsPostBack)
                    {
                        GetUsers();
                    }  
                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
        }

    }

    private void GetUsers()
    {
        UsersOnlineLabel.Text = Membership.GetNumberOfUsersOnline().ToString();

        UserGrid.DataSource = Membership.GetAllUsers(currentPage - 1, pageSize, out totalUsers);
        totalPages = ((totalUsers - 1) / pageSize) + 1;

        // Ensure that we do not navigate past the last page of users.

        if (currentPage > totalPages)
        {
            currentPage = totalPages;
            GetUsers();
            return;
        }

        UserGrid.DataBind();
        CurrentPageLabel.Text = currentPage.ToString();
        TotalPagesLabel.Text = totalPages.ToString();

        if (currentPage == totalPages)
            NextButton.Visible = false;
        else
            NextButton.Visible = true;

        if (currentPage == 1)
            PreviousButton.Visible = false;
        else
            PreviousButton.Visible = true;

        if (totalUsers <= 0)
            NavigationPanel.Visible = false;
        else
            NavigationPanel.Visible = true;
    }

    public void NextButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage++;
        GetUsers();
    }

    public void PreviousButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage--;
        GetUsers();
    }


    public void RemoveVisit_Command(Object sender, DataListCommandEventArgs e)
    {


        Guid visitid = XmlConvert.ToGuid((string)e.CommandArgument);
        usr.removeVisit(visitid);
        //ActiveProject2 = XmlConvert.ToGuid((string)e.CommandArgument); //e.CommandArgument.ToString
        SqlDataSource2.DataBind();
        DataList2.DataBind();
    }

    protected void getclicks_Click(object sender, EventArgs e)
    {
            string dataFile= usr.outputUser(Activeorganizer);
            if (dataFile.Trim() != "")
        {


            string fileName =  dataFile.Trim(); //.FileName;

            string fileNow = "clicks.csv";


            byte[] data = File.ReadAllBytes(fileName);

            FileStream file = File.Create(fileName);

            file.Write(data, 0, data.Length);
            file.Close();


            //String FileName = "FileName.txt";
            //String FilePath = "C:/"; //Replace this
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "csv";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileNow + ";");
            response.TransmitFile(fileName);
            response.Flush();
            response.End();


        }

    }
}
