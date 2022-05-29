// by Chtiwi Malek on CODICODE.COM
using System;
using System.Web;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Web.Security;

[ScriptService]
public partial class Save_Picture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
    }

    [WebMethod()]
    public static void UploadPic(string imageData)
    {
        string Activeorganizer = XmlConvert.ToString((Guid)Membership.GetUser().ProviderUserKey);

        string Pic_Path = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + Activeorganizer + "/CanvasPicture.png";

        //string Pic_Path = HttpContext.Current.Server.MapPath("MyPicture.png");
        using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                byte[] data = Convert.FromBase64String(imageData);
                bw.Write(data);
                bw.Close();
            }
        }
    }
}