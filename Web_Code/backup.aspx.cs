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
using System.Text;


public partial class _backup : System.Web.UI.Page
{
    //public Guid Activeorganizer0;
    public Guid Activeorganizer;
    //public Guid ActiveProject;
    // public  string ActiveProjectName;
    // public   Guid ActiveProjectPart;
    // public   Guid ActiveProjectItem;

    public Random random = new Random();


    public static int paMax = 8;
    public int paStart = 1;
    public static  int paEnd = paMax;

    public string path = "";
    public string OldDataPath = "";

    Utils ut = new Utils();
    AriadneStatistics arst = new AriadneStatistics();
    AriadneUsers usr = new AriadneUsers();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            if (user == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (Page.User.Identity.IsAuthenticated)
            {
                if (Roles.IsUserInRole("administrator") || Roles.IsUserInRole("organizer"))
                {
                    Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;

 

                    downloaddataBlock.Visible = true;
                    uploaddataBlock.Visible = true;
                    uploadOldCMdataBlock.Visible = true;

                    FileDirData();
                    FileDirOldData();

                    usr.createUserPathOrg(Activeorganizer,"map_csv");
                    usr.createUserPathOrgArp(Activeorganizer, "map_csv");
                }
            }
            else
            {
                Response.Redirect("~/default.aspx");

               
            }
 
        }
    }

    protected void FileDirData( )
    {

        //AriadneReports.createUserPathOrg(Activeorganizer);

        Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;

        DirectoryInfo di = new DirectoryInfo( pathOrg);
        FileInfo[] files = di.GetFiles("*.*");
        ArrayList filesIn = new ArrayList();



        foreach (FileInfo fi in files)
        {
            filesIn.Add(fi);
        }
        DataList2.DataSource = filesIn;
        DataList2.DataBind();
    }
     
   
    

    protected void Edit_Command(Object sender, DataListCommandEventArgs e)
    {

        string version = (string)e.CommandArgument;
        //utdbb.GetBackupProject(Activeorganizer, version);
        Response.Redirect("~/Web_Code/organise.aspx");
    }

    protected void DownloadFile_Command(Object sender, DataListCommandEventArgs e)
    {
        Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
        //AriadneReports.createUserPathOrg(Activeorganizer );
        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;
        string fileNow = (string)e.CommandArgument;
        //DataHandling.GetBackupProject(Activeorganizer, version);
        //Response.Redirect("~/Web_Code/organise.aspx");

        string fileName =  pathOrg + "/" + fileNow;
        //string fileName2 = AriadneReports.path + "/" + "2" + fileNow;

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

    protected void RestoreFromFile_Command(Object sender, DataListCommandEventArgs e)
    {
        Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
        //TextResult.Text = "Please be patient, wait until a restore report appears..";
        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;
        string fileNow = (string)e.CommandArgument;
        //DataHandling.GetBackupProject(Activeorganizer, version);
        //Response.Redirect("~/Web_Code/organise.aspx");

        string fileName =  pathOrg + "/" + fileNow;

        string[] data = File.ReadAllLines(fileName, Encoding.Default);

        StringBuilder sb = arst.GetBackupProjectFromFile(Activeorganizer, data);
        TextResult.Text += sb.ToString(); sb.Clear();
        //Response.Redirect("~/Web_Code/organise.aspx");
    }

    protected void RemoveFileBackup_Command(Object sender, DataListCommandEventArgs e)
    {

        Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;
        string fileNow = (string)e.CommandArgument;
        //DataHandling.GetBackupProject(Activeorganizer, version);
        //Response.Redirect("~/Web_Code/organise.aspx");

        string fileName = pathOrg + "/" + fileNow;
        FileInfo fileDel = new FileInfo(fileName);
        fileDel.Delete();
        FileDirData();

    }

       protected void removeBackup_Command(Object sender, DataListCommandEventArgs e)
    {
    }

       protected void UploadFile_Click(object sender, EventArgs e)
       {
           if (FileUpload.FileName.Trim() != "")
           {
               Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
               string dir = XmlConvert.ToString(Activeorganizer);
               string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;
               string fileName = FileUpload.PostedFile.FileName; //.FileName;

               string fileName2 = pathOrg + "/" + FileUpload.FileName;

               //byte[] data = File.ReadAllBytes(fileName);
               byte[] data = FileUpload.FileBytes;


               FileStream file = File.Create(fileName2);

               file.Write(data, 0, data.Length);
               file.Close();
               FileDirData();
           }
       }

         protected void FileDirOldData( )
       {
           Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
           string dir = XmlConvert.ToString(Activeorganizer);
           string pathOrgArp = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir + "/arp/"; ;

           DirectoryInfo di = new DirectoryInfo(pathOrgArp);
         
           FileInfo[] files = di.GetFiles("*.*");
           ArrayList filesIn2 = new ArrayList();



           foreach (FileInfo fi in files)
           {
               filesIn2.Add(fi);
           }
           DataList3.DataSource = filesIn2;
           DataList3.DataBind();


       }

      

       protected void GetOldFile_Command(Object sender, DataListCommandEventArgs e)
       {

           Activeorganizer = (Guid)Membership.GetUser().ProviderUserKey;
           string dir = XmlConvert.ToString(Activeorganizer);
           string pathOrgArp = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir + "/arp/"; ;
           string fileNow = (string)e.CommandArgument;
           //DataHandling.GetBackupProject(Activeorganizer, version);
           //Response.Redirect("organise.aspx");

           string fileName =  pathOrgArp + "/" + fileNow;

           Guid ActiveProject2 = ut.GetOldData(fileName);
           Response.Redirect("~/Web_Code/Organise.aspx");

       }
}
    
