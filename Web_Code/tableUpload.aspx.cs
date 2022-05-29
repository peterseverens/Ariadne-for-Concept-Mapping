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


public partial class _upload : System.Web.UI.Page
{
    public static Guid Activeorganizer0;
    public static Guid Activeorganizer;
    public static Guid ActiveProject;
    public static string ActiveProjectName;
    public static Guid ActiveProjectPart;
    public static Guid ActiveProjectItem;

    public static Random random = new Random();

 

    public static int paMax = 8;
    public static int paStart = 1;
    public static int paEnd = paMax;

 

    public static string path = "";
    public static string OldDataPath = "";

    Utils ut = new Utils();
    AriadneStatistics arst = new AriadneStatistics();
    tableUtils tblu = new tableUtils();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //tableFileNameField.Text = "???";

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
                     

                    FileDirData();
                    
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

        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/tab/" + dir;

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

        //AriadneReports.createUserPathOrg(Activeorganizer );
        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/tab/" + dir;
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

    protected void getTableFromFile_Command(Object sender, DataListCommandEventArgs e)
    {


        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/tab/" + dir;
        if (Directory.Exists(pathOrg))
        {
 

            string inputFileName = pathOrg + "/" + (string)e.CommandArgument;
 

            String Day = DateTime.Now.Day.ToString();
            String Month = DateTime.Now.Month.ToString();
            String Year = DateTime.Now.Year.ToString();
            String Hour = DateTime.Now.Hour.ToString();
            String Minute = DateTime.Now.Minute.ToString();

            string Version = " " + Month + "-" + Day + "-" + Year + " " + Hour + "-" + Minute;

 
            string dataFileName = "test" + " " + Version + ".csv";
            string outputFileName = pathOrg + "/" + dataFileName;

            tblu.firstRun(inputFileName, outputFileName);

            tableFileNameField.Text = tblu.fileName;
            tableProjectNameField.Text = tblu.projectName;
            tableLabels.Text = tblu.LB;
            tableBurtMatrix.Text = tblu.BM;
            tableDataField.Text = tblu.EV;
            tableSelectField.Text = tblu.ES;
            //tblu.UploadDataFile(outputFileName);
        }

        //Response.Redirect("~/Web_Code/organise.aspx");


    }


   

    protected void removeTableFile_Command(Object sender, DataListCommandEventArgs e)
    {

      
        string dir = XmlConvert.ToString(Activeorganizer);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/tab/" + dir;
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

               string dir = XmlConvert.ToString(Activeorganizer);
               string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/tab/" + dir;
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

        

      

       
}
    
