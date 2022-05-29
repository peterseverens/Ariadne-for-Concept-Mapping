


using System.Data;
using System.Data.SqlClient;

using System;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web;
using System.Xml;
using System.IO;
using System.Web.Configuration;
using System.Text;







public class AriadneUsers
{

    public Guid userGuid;
    DataHandling dh = new DataHandling();

    public string createAriadneRoles()
    {

        string ErrorMessage = "";
        try
        {
            if (Roles.RoleExists("user") == false) Roles.CreateRole("user");
            if (Roles.RoleExists("organizer") == false) Roles.CreateRole("organizer");
            if (Roles.RoleExists("administrator") == false) Roles.CreateRole("administrator");

        }
        catch (Exception e)
        {
            ErrorMessage += e.Message;
        }
        return ErrorMessage;

    }

    public string loginAsUser(string name, string pass)
    {

        string roleNow = "";
        if (Membership.ValidateUser(name, pass))
        {

            FormsAuthentication.RedirectFromLoginPage(name, true);

            string[] rolesNow = new string[99];
            rolesNow = Roles.GetRolesForUser(name);

            //if (Roles.IsUserInRole("administrator")) return "administrator";

            switch (rolesNow[0])
            {
                case "administrator":
                    roleNow = "administrator";
                    break;
                case "organizer":
                    roleNow = "organizer";
                    break;
                case "user":
                    roleNow = "user";
                    break;

                default:

                    break;
            }
            return roleNow;
        }
        else
        {
            return "Login failed. Please check your user name and password and try again.";

        }
    }

  

    public string AddAriadneUser(string name, string pass, string email, string role)
    {
        string ErrorMessage = ""; string ErrorMessage2 = "";
        MembershipCreateStatus result;
        MembershipUser newUser;

        try
        {
            // Create new user.



            if (Membership.RequiresQuestionAndAnswer)
            {
                newUser = Membership.CreateUser(
                name,
                pass,
                email,
                "noPassQuestionYet",
                "noPassAnswerYet",
                false,
                out result);
                userGuid = (Guid)newUser.ProviderUserKey;
            }
            else
            {
                newUser = Membership.CreateUser(
                name,
                pass,
                email);
                userGuid = (Guid)newUser.ProviderUserKey;
            }

            //Response.Redirect("login.aspx");
        }
        catch (MembershipCreateUserException e)
        {
            ErrorMessage = GetErrorMessage(e.StatusCode);
        }
        catch (HttpException e)
        {
            ErrorMessage = e.Message;
        }

        try
        {
            Roles.AddUserToRole(name, role);
        }
        catch (Exception e)
        {
            ErrorMessage2 = e.Message;
        }

        if (ErrorMessage == "" && ErrorMessage2 == "")
        {

            if (role == "organizer" || role == "administrator")
            {
                dh.AddNewOrganizer(name, pass, email,userGuid);
                //loginAsUser(name, pass);

                createUserPathOrg(userGuid, "map_csv");
                createUserPathOrgArp(userGuid, "map_csv");
            }

            return "OK";
        }
        else
        {
            return " e1: " + ErrorMessage + " e2: " + ErrorMessage2;
        }

    }

    public string DeleteAriadneUser(string name)
    {
        string ErrorMessage = ""; string ErrorMessage2 = "";

        Boolean deleteResult;
        try
        {

            deleteResult = Membership.DeleteUser(name);

        }
        catch (MembershipCreateUserException e)
        {
            ErrorMessage = GetErrorMessage(e.StatusCode);
        }
        catch (HttpException e)
        {
            ErrorMessage = e.Message;
        }



        if (ErrorMessage == "")
        {

            Boolean deleteResult2 = dh.DeleteOrganizer(name);
            //loginAsUser(name, pass);

            //createUserPathOrg(userGuid);
            //createUserPathOrgArp(userGuid);


            return "OK";
        }
        else
        {
            return " e1: " + ErrorMessage + " e2: " + ErrorMessage2;
        }

    }

    public string ResetPassword(string Username)
    {
        string t = "";
        string oldPassword;
        string newPassword;
        string passOld = "";
        MembershipUser u = Membership.GetUser(Username, false);

        if (u == null)
        {
            //Msg.Text = "Username " + Server.HtmlEncode(UsernameTextBox.Text) + " not found. Please check the value and re-enter.";
            return "No user name";
        }

        try
        {
            if (u.IsLockedOut) { u.UnlockUser(); };
            //oldPassword = u.GetPassword();
            newPassword = u.ResetPassword();
        }

        catch (Exception e)
        {
            return e.Message;
        }

        if (newPassword != null)
        {
              t = "Password reset. Your new password is: " + newPassword;
            bool result2 = dh.UpdateOrganizer(Username, passOld, newPassword);
            
        }
        else
        {
             t = "Password reset failed. Please re-enter your values and try again.";
             
        }
         return t;   
    }

    public string ChangePassAriadneUser(string name, string passOld, string passNew)
    {
        MembershipUser u = Membership.GetUser(name);
        string result1 = "";
        Boolean result2 =false ;
        try
        {
            if (u.ChangePassword(passOld, passNew))
            {
                result1 = "Password changed.";
            }
            else
            {
                result1 = "Password change failed. Please re-enter your values and try again.";
            }
        }
        catch (Exception e)
        {
            result1 = "An exception occurred: " + e.Message + ". Please re-enter your values and try again.";
        }

        if (result1 == "Password changed.")
        {

            result2 = dh.UpdateOrganizer(name, passOld, passNew);
            //loginAsUser(name, pass);

            //createUserPathOrg(userGuid);
            //createUserPathOrgArp(userGuid);


            return "OK";
        }
        else
        {
            
        }
        return result1 + " " + result2;
    }

    public string DeleteAllParticipants()
    {

        foreach (MembershipUser u in Membership.GetAllUsers())
        {
            if (dh.AriadneProjectExists(u.UserName)==false)
            {
                if (u.UserName.Trim().Length == 36)
                {
                    Membership.DeleteUser(u.UserName, true);
                }
            }
        }

        return "";
    }

    public string GetErrorMessage(MembershipCreateStatus status)
    {
        switch (status)
        {
            case MembershipCreateStatus.DuplicateUserName:
                return "Username already exists. Please enter a different user name.";

            case MembershipCreateStatus.DuplicateEmail:
                return "A username for that e-mail address already exists. Please enter a different e-mail address.";

            case MembershipCreateStatus.InvalidPassword:
                return "The password provided is invalid. Please enter a valid password value.";

            case MembershipCreateStatus.InvalidEmail:
                return "The e-mail address provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.InvalidAnswer:
                return "The password retrieval answer provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.InvalidQuestion:
                return "The password retrieval question provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.InvalidUserName:
                return "The user name provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.ProviderError:
                return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

            case MembershipCreateStatus.UserRejected:
                return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

            default:
                return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        }
    }

    public Boolean createUserPathOrg(Guid organizerId,string baseDir)
    {

        string dir = XmlConvert.ToString(organizerId);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/"+baseDir+"/" + dir;
        string pathOrg2 = "~/" + baseDir + "/" + dir;
        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(pathOrg))
            {
               // Console.WriteLine("That path exists already.");

            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(pathOrg);

            //System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration( pathOrg2 );
            //AuthorizationSection authorization = (AuthorizationSection)configuration.GetSection("system.web/authorization");
            //AuthorizationRule accessRule = new AuthorizationRule(AuthorizationRuleAction.Allow);
            //accessRule.Users.Add("organizer");
            //authorization.Rules.Add(accessRule);
            //configuration.Save(ConfigurationSaveMode.Minimal); 

            buildwebconfig("peter22", "organizer", "POST", pathOrg2);



            return true;

        }
        catch (Exception ee)
        {
            //Console.WriteLine("The process failed: {0}", ee.ToString());
            return false;
        }
        finally
        {

        }


    }

    public Boolean createUserPathOrgArp(Guid organizerId, string baseDir)
    {

        string dir = XmlConvert.ToString(organizerId);
        string pathOrgArp = System.Web.HttpContext.Current.Server.MapPath("~")+ "/"+baseDir+"/" + dir + "/arp/";
        string pathOrgArp2 = "~/" + baseDir + "/" + dir + "/arp/";
        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(pathOrgArp))
            {
               // Console.WriteLine("That path exists already.");

            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(pathOrgArp);

            //System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
            //AuthorizationSection authorization = (AuthorizationSection)configuration.GetSection("system.web/authorization");
            //AuthorizationRule accessRule = new AuthorizationRule(AuthorizationRuleAction.Allow);
            //accessRule.Users.Add("organizer");
            //authorization.Rules.Add(accessRule);
            //configuration.Save(ConfigurationSaveMode.Minimal);

            buildwebconfig("peter22", "organizer", "POST", pathOrgArp2);

            return true;

        }
        catch (Exception ee)
        {
            //Console.WriteLine("The process failed: {0}", ee.ToString());
            return false;
        }
        finally
        {

        }


    }

    public Boolean createUserPathPro(Guid organizerId, Guid projectId)
    {
        string dir = XmlConvert.ToString(organizerId);
        string pro = XmlConvert.ToString(projectId);

        // Specify the directory you want to manipulate.
        string pathPro = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir + "/" + pro;
        string pathPro2 = "~/map_csv/" + dir + "/" + pro;
        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(pathPro))
            {
                Console.WriteLine("That path exists already.");
                return true;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(pathPro);

            //System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
            //AuthorizationSection authorization = (AuthorizationSection)configuration.GetSection("system.web/authorization");
            //AuthorizationRule accessRule = new AuthorizationRule(AuthorizationRuleAction.Allow);
            //accessRule.Users.Add("organizer");
            //authorization.Rules.Add(accessRule);
            //configuration.Save(ConfigurationSaveMode.Minimal); 

            buildwebconfig("peter22", "organizer", "POST", pathPro2);

            return true;
            //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

            // Delete the directory.
            //di.Delete();
            //Console.WriteLine("The directory was deleted successfully.");
        }
        catch (Exception e)
        {
            //Console.WriteLine("The process failed: {0}", e.ToString());
            return false;
        }
        finally { }
    }

    public string buildwebconfig(string user, string role, string verb, string pathOrg2)
    {




        System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration(pathOrg2);
        AuthorizationSection authorization = (AuthorizationSection)configuration.GetSection("system.web/authorization");
        AuthorizationRule accessRule = new AuthorizationRule(AuthorizationRuleAction.Allow);
        accessRule.Users.Add(user);
        accessRule.Roles.Add(role);
        accessRule.Verbs.Add(verb);  //POST

        authorization.Rules.Add(accessRule);

        configuration.Save(ConfigurationSaveMode.Minimal);


        System.Configuration.Configuration updateWebConfig;
        updateWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/uploads");

        return "";

    }

    public void removeVisit(Guid visitid)
    {


        object result = dh.RemoveUserInfo(visitid);


    }



    public string outputUser(Guid organizerId)
    {

        string dataFile = "";
        String Day = DateTime.Now.Day.ToString();
        String Month = DateTime.Now.Month.ToString();
        String Year = DateTime.Now.Year.ToString();
        String Hour = DateTime.Now.Hour.ToString();
        String Minute = DateTime.Now.Minute.ToString();

        string Version = " " + Month + "-" + Day + "-" + Year + " " + Hour + "-" + Minute;

        string dir = XmlConvert.ToString(organizerId);
        string pathOrg = System.Web.HttpContext.Current.Server.MapPath("~") + "/map_csv/" + dir;
        //if (createUserPathOrg(organizerId))
        if (Directory.Exists(pathOrg))
        {

            string dataFileName = "user_report" + Version + ".csv";
             dataFile = pathOrg + "/" + dataFileName;

            //using (StreamWriter outfile2 = new StreamWriter(dataFile))

            using (var sw = new StreamWriter(new FileStream(dataFile, FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8))
            {
                StringBuilder sb = new StringBuilder();


                //PROJECTNAME
                string tt = "";
                tt += dataFileName;
                sb.AppendLine(tt);



                //VARIABLES

                tt = "";
                tt = "variables";
                sb.AppendLine(tt);


                ArrayList userlist = dh.getAllUsersClicks(); tt = "";
                for (int i = 0; i < userlist.Count; i+=10)
                {
                    tt = "";

                    tt += XmlConvert.ToString((Guid)userlist[i+0]); tt += ",";

                    tt += ((DateTime)userlist[i + 1]).Date; tt += ",";
                    tt += (string)userlist[i + 2]; tt += ",";
                    tt += (string)userlist[i + 3]; tt += ",";
                    tt += (Boolean)userlist[i + 4]; tt += ",";
                    tt += (Boolean)userlist[i + 5]; tt += ",";
                    tt += (string)userlist[i + 6]; tt += ",";
                    tt += (string)userlist[i + 7]; tt += ",";
                    tt += (string)userlist[i + 8]; tt += ",";
                    tt += (string)userlist[i + 9]; tt += ",";


                    sb.AppendLine(tt);
                }
                sw.Write(sb.ToString());
                sb.Clear(); 
            }
            
        }
        return dataFile;
    }
}




