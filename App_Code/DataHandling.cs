using System;
using System.Collections.Generic;

//using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web.Security;
using System.Xml;
using System.Globalization;





public  class DataHandling
{

    public   Random random = new Random();

    public   String DBplatform = "platformDB3";
    public   Guid ActiveProject;

    //AriadneUsers usr = new AriadneUsers();

    //string  DBplatform  = "platformDB3";

    //Todo: Change this to use a database query through the middle tier

    //Utils ut = new Utils();
   

    public  String AddNewOrganizer(string name, string pass, string email, Guid userGuid)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("INSERT INTO organizer (organizerid, name, pass, email) VALUES ( @organizerid, @name, @pass, @email); select SCOPE_IDENTITY()", connection);


        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
        param[0].Value = name;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@pass", System.Data.SqlDbType.NVarChar);
        param[1].Value = pass;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
        param[2].Value = email;
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@organizerid", System.Data.SqlDbType.UniqueIdentifier);
        param[3].Value = userGuid;
        command.Parameters.Add(param[3]);



        connection.Open();
        Object result = command.ExecuteScalar();

        connection.Close();
        return "";


    }

    public   Boolean DeleteOrganizer(string name)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE organizer WHERE name=@name ", connection);
     
         
        //DELETE projects WHERE projectid=@projectid

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
        param[0].Value = name;
        command.Parameters.Add(param[0]);



        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        if (result == null)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    public Boolean UpdateOrganizer(string name, string passOld, string passNew)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE organizer SET pass=@pass WHERE name=@name ", connection);
        //DELETE projects WHERE projectid=@projectid

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
        param[0].Value = name;
        command.Parameters.Add(param[0]);

        
        param[1] = new SqlParameter("@pass", System.Data.SqlDbType.NVarChar);
        param[1].Value = passNew;
        command.Parameters.Add(param[1]);

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        if (result == null)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    public string getOrganizerName(Guid organizerId)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT name FROM organizer WHERE organizerid=@organizerid", connection);
        //DELETE projects WHERE projectid=@projectid

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@organizerid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = organizerId;
        command.Parameters.Add(param[0]);

         

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        if (result != DBNull.Value)
        {
            return (string)result;
        }

        else
        {
            return "not found";
        }

    }



    public   int countprojects()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM projects", connection);

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();
        return (int)result;

        
    }

 

    public   int countprojectsPerorganizer(Guid Xorganizerid)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM projects WHERE organizerId=@organizerId", connection);


        SqlParameter[] param = new SqlParameter[9];

        param[1] = new SqlParameter("@organizerId", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = Xorganizerid;
        command.Parameters.Add(param[1]);

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();
        return (int)result;

      
    }

    public   Guid AddProject(Guid Xorganizerid, Guid Xprojectid, string Xprojectname, string Xprojectdescription, string rateName1,string rateName2, string rateName3, string rateName4, string rateName5, int maxItemN )
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("INSERT INTO Projects (organizerid, projectid, ProjectName, ProjectDescription, created, locktype, itemratedefenition1, itemratedefenition2, itemratedefenition3, itemratedefenition4, itemratedefenition5, max_item_n) VALUES ( @organizerid, @projectid, @projectname, @projectdescription, @created, @locktype, @itemratedefenition1, @itemratedefenition2, @itemratedefenition3, @itemratedefenition4, @itemratedefenition5, @max_item_n ); select SCOPE_IDENTITY()", connection);


        Guid prid2;
        if (XmlConvert.ToString(Xprojectid) == "00000000-0000-0000-0000-000000000000")
        {
            prid2 = System.Guid.NewGuid();
        }
        else
        {
            prid2 = Xprojectid;
        }

        //ActiveProject = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");


        SqlParameter[] param = new SqlParameter[12];

        int start = 0; int end = 0;

 
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = prid2;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@projectname", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xprojectname.Length; if (end > 29) end = 30;
        //param[1].Value = Xprojectname.Substring(start, end); ;
        param[1].Value = Xprojectname.Trim();
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@projectdescription", System.Data.SqlDbType.NVarChar);
        //start = Xprojectdescription.Length - 99; if (start < 0) start = 0;
        //end = Xprojectdescription.Length; if (end > 99) end = 99;
        //param[2].Value = Xprojectdescription.Substring(start, end);
        param[2].Value = Xprojectdescription.Trim();
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@organizerId", System.Data.SqlDbType.UniqueIdentifier);
        param[3].Value = Xorganizerid;
        command.Parameters.Add(param[3]);

        DateTime created = DateTime.UtcNow;
        param[4] = new SqlParameter("@created", System.Data.SqlDbType.DateTime);
        param[4].Value = created;
        command.Parameters.Add(param[4]);

        param[5] = new SqlParameter("@locktype", System.Data.SqlDbType.NVarChar);
        param[5].Value = "";
        command.Parameters.Add(param[5]);

        param[6] = new SqlParameter("@itemratedefenition1", System.Data.SqlDbType.NVarChar);
        param[6].Value = rateName1;
        command.Parameters.Add(param[6]);

        param[7] = new SqlParameter("@itemratedefenition2", System.Data.SqlDbType.NVarChar);
        param[7].Value = rateName2;
        command.Parameters.Add(param[7]);

        param[8] = new SqlParameter("@itemratedefenition3", System.Data.SqlDbType.NVarChar);
        param[8].Value = rateName3;
        command.Parameters.Add(param[8]);

        param[9] = new SqlParameter("@itemratedefenition4", System.Data.SqlDbType.NVarChar);
        param[9].Value = rateName4;
        command.Parameters.Add(param[9]);

        param[10] = new SqlParameter("@itemratedefenition5", System.Data.SqlDbType.NVarChar);
        param[10].Value = rateName5;
        command.Parameters.Add(param[10]);

        param[11] = new SqlParameter("@max_item_n", System.Data.SqlDbType.Int);
        param[11].Value = maxItemN;
        command.Parameters.Add(param[11]);

        connection.Open();
        object result = command.ExecuteScalar();

        connection.Close();

        return prid2;



    }


    public object UpdateProject(Guid Xprojectid, string Xprojectname, string Xprojectdescription, string rateName1, string rateName2, string rateName3, string rateName4, string rateName5, int maxItemN)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        //SqlCommand command = new SqlCommand("UPDATE Projects (organizerid, projectid, ProjectName, ProjectDescription) VALUES ( @organizerid, @projectid, @projectname, @projectdescription ); select SCOPE_IDENTITY()", connection);

        SqlCommand command = new SqlCommand("UPDATE Projects SET projectid=@projectid,projectname=@projectname ,projectdescription=@projectdescription, itemratedefenition1=@itemratedefenition1, itemratedefenition2=@itemratedefenition2, itemratedefenition3=@itemratedefenition3, itemratedefenition4=@itemratedefenition4, itemratedefenition5=@itemratedefenition5, max_item_n=@max_item_n  WHERE projectid=@projectid", connection);


        SqlParameter[] param = new SqlParameter[9];


        int start = 0; int end = 0;

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = Xprojectid;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@projectname", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xprojectname.Length; if (end > 29) end = 29;
        //param[1].Value = Xprojectname.Substring(start, end); ;
        param[1].Value = Xprojectname.Trim();
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@projectdescription", System.Data.SqlDbType.NVarChar);
        //start = Xprojectdescription.Length - 99; if (start < 0) start = 0;
        //end = Xprojectdescription.Length; if (end > 99) end = 99;
        //param[2].Value = Xprojectdescription.Substring(start, end);
        param[2].Value = Xprojectdescription.Trim();
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@itemratedefenition1", System.Data.SqlDbType.NVarChar);
        param[3].Value = rateName1;
        command.Parameters.Add(param[3]);

        param[4] = new SqlParameter("@itemratedefenition2", System.Data.SqlDbType.NVarChar);
        param[4].Value = rateName2;
        command.Parameters.Add(param[4]);

        param[5] = new SqlParameter("@itemratedefenition3", System.Data.SqlDbType.NVarChar);
        param[5].Value = rateName3;
        command.Parameters.Add(param[5]);

        param[6] = new SqlParameter("@itemratedefenition4", System.Data.SqlDbType.NVarChar);
        param[6].Value = rateName4;
        command.Parameters.Add(param[6]);

        param[7] = new SqlParameter("@itemratedefenition5", System.Data.SqlDbType.NVarChar);
        param[7].Value = rateName5;
        command.Parameters.Add(param[7]);

        param[8] = new SqlParameter("@max_item_n", System.Data.SqlDbType.Int);
        param[8].Value = maxItemN;
        command.Parameters.Add(param[8]);

        connection.Open();
        object result = command.ExecuteScalar();

        connection.Close();

        return result;



    }

    public  object SetLockTypeProject(Guid Xprojectid, string lockType)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        //SqlCommand command = new SqlCommand("UPDATE Projects (organizerid, projectid, ProjectName, ProjectDescription) VALUES ( @organizerid, @projectid, @projectname, @projectdescription ); select SCOPE_IDENTITY()", connection);

        SqlCommand command = new SqlCommand("UPDATE Projects SET  locktype=@locktype    WHERE projectid=@projectid", connection);


        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = Xprojectid;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@locktype", System.Data.SqlDbType.NVarChar);
        param[1].Value = lockType;
        command.Parameters.Add(param[1]);

        connection.Open();
        object result = command.ExecuteScalar();

        connection.Close();

        return result;
        
    }

    public   string GetLockTypeProject(Guid XprojectId)
    {


        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT locktype  FROM Projects   WHERE projectid=@projectid   ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XprojectId;
        command.Parameters.Add(param[0]);


        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return (string)result;


    }


    public  ArrayList EditProject(Guid XprojectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT organizerid,Projectid, ProjectName, ProjectDescription, itemratedefenition1 , itemratedefenition2 , itemratedefenition3 , itemratedefenition4 , itemratedefenition5, max_item_n FROM Projects   WHERE projectid=@projectid   ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XprojectId;
        command.Parameters.Add(param[0]);


        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();

        //if (reader.HasRows)
        //{
        while (reader.Read())
        {

            if (!reader.IsDBNull(0))
            {
                objl.Add(reader.GetGuid(0));
            }
            if (!reader.IsDBNull(1))
            {
                objl.Add(reader.GetGuid(1));
            }
            if (!reader.IsDBNull(2))
            {
                objl.Add(reader.GetString(2));
            }
            if (!reader.IsDBNull(3))
            {
                objl.Add(reader.GetString(3));
            }

            if (!reader.IsDBNull(4))
            {
                objl.Add(reader.GetString(4));
            }
            if (!reader.IsDBNull(5))
            {
                objl.Add(reader.GetString(5));
            }
            if (!reader.IsDBNull(6))
            {
                objl.Add(reader.GetString(6));
            }
            if (!reader.IsDBNull(7))
            {
                objl.Add(reader.GetString(7));
            }
            if (!reader.IsDBNull(8))
            {
                objl.Add(reader.GetString(8));
            }
            if (!reader.IsDBNull(9))
            {
                objl.Add(reader.GetInt32(9));
            }
            else
            { 
                objl.Add(0); 
            }
        }
        connection.Close();
        return objl;

        

    }

     

    public int getMaxItemNinQuest(Guid XprojectId)
    {
        int maxItemNinQuest = 0;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT max_item_n FROM Projects   WHERE projectid=@projectid   ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XprojectId;
        command.Parameters.Add(param[0]);


        connection.Open();
        object result = command.ExecuteScalar();
        //if (result.ToString() != "")
            if (result != DBNull.Value)
        {
            maxItemNinQuest = (int)command.ExecuteScalar();
        }
            connection.Close();
        return maxItemNinQuest;

         
    }

    public   int DeleteProject(Guid Xprojectid)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE projects WHERE projectid=@projectid ", connection);



        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@ProjectId", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = Xprojectid;
        command.Parameters.Add(param[0]);

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        if (result == null)
        {
            return 0;
        }

        else
        {
            return 1;
        }




    }


    public   string ExistingParticipantToCurrentProject(Guid XPartid, Guid Xprojectid)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("INSERT INTO LinkProjectParticipant (projectid,participantid) VALUES ( @projectid, @partid); select SCOPE_IDENTITY()", connection);

        string prid2;
        prid2 = System.Guid.NewGuid().ToString();

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = Xprojectid;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = XPartid;
        command.Parameters.Add(param[1]);


        connection.Open();
        object result = command.ExecuteScalar();

        //return (string)result;

        connection.Close();

        if (result == null)
        {
            return "OK?";
        }

        else
        {
            return "OK?";
        }
    }


    public  Guid AddNewParticipantToCurrentProject(Guid Xprojectid, string name, string pass, string Xfirstname, string Xlastname, string Xemail, string function, string organisation, string v1,string v2, string v3, string v4, string v5)
    {
        
        //string pass = XmlConvert.ToString(System.Guid.NewGuid());
        //string name = XmlConvert.ToString(System.Guid.NewGuid());

        //string result = AriadneUsers.AddAriadneUser(name, pass, Xemail, "user");

        SqlConnection connection3 = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command3 = new SqlCommand("INSERT INTO LinkProjectParticipant (projectid,participantid,created) VALUES ( @projectid, @partid,@created); select SCOPE_IDENTITY()", connection3);

        SqlConnection connection4 = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command4 = new SqlCommand("INSERT INTO participant (participantid, FirstName, LastName, email, created, username, passname, Jobfunction, Organisation, var1, var2, var3, var4, var5) VALUES (@partid, @firstname, @lastname, @email, @created, @name, @pass, @jobfunction, @organisation, @var1, @var2, @var3, @var4, @var5); select SCOPE_IDENTITY()", connection4);


        Guid prid2 = System.Guid.NewGuid();

        SqlParameter[] param = new SqlParameter[25];

        int start = 0; int end = 0;

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = Xprojectid;
        command3.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = prid2;
        command3.Parameters.Add(param[1]);

        DateTime created = DateTime.UtcNow;
        param[2] = new SqlParameter("@created", System.Data.SqlDbType.DateTime);
        param[2].Value = created;
        command3.Parameters.Add(param[2]);

        param[11] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[11].Value = prid2;
        command4.Parameters.Add(param[11]);

        param[12] = new SqlParameter("@firstname", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xfirstname.Length; if (end > 49) end = 49;
        ///param[12].Value = Xfirstname.Substring(start,end);
        param[12].Value = Xfirstname.Trim();
        command4.Parameters.Add(param[12]);


        param[13] = new SqlParameter("@lastname", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xlastname.Length; if (end > 49) end = 49;
        //param[13].Value = Xlastname.Substring(start, end);
        param[13].Value = Xlastname.Trim();
        command4.Parameters.Add(param[13]);


        param[14] = new SqlParameter("@created", System.Data.SqlDbType.DateTime);
        param[14].Value = created;
        command4.Parameters.Add(param[14]);

        param[15] = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
        param[15].Value = name;
        command4.Parameters.Add(param[15]);

        param[16] = new SqlParameter("@pass", System.Data.SqlDbType.NVarChar);
        param[16].Value = pass;
        command4.Parameters.Add(param[16]);

        param[17] = new SqlParameter("@jobfunction", System.Data.SqlDbType.NVarChar);
        //end = function.Length; if (end > 49) end = 49;
        //param[17].Value = function.Substring(start, end);
        param[17].Value = function.Trim();
        command4.Parameters.Add(param[17]);

        param[18] = new SqlParameter("@organisation", System.Data.SqlDbType.NVarChar);
        //end = organisation.Length; if (end > 49) end = 49;
        //param[18].Value = organisation.Substring(start, end);
        param[18].Value = organisation.Trim();
        command4.Parameters.Add(param[18]);

        param[19] = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xemail.Length; if (end > 49) end = 49;
        //param[19].Value = Xemail.Substring(start, end);
        param[19].Value = Xemail.Trim();
        command4.Parameters.Add(param[19]);


        param[20] = new SqlParameter("@var1", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v1.Length; if (end > 19) end = 19;
        //param[20].Value = v1.Substring(start, end);
        param[20].Value = v1.Trim();
        command4.Parameters.Add(param[20]);

        param[21] = new SqlParameter("@var2", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v2.Length; if (end > 19) end = 19;
        //param[21].Value = v2.Substring(start, end);
        param[21].Value = v2.Trim();
        command4.Parameters.Add(param[21]);

        param[22] = new SqlParameter("@var3", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v3.Length; if (end > 19) end = 19;
        //param[22].Value = v3.Substring(start, end);
        param[22].Value = v3.Trim();
        command4.Parameters.Add(param[22]);

        param[23] = new SqlParameter("@var4", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v4.Length; if (end > 19) end = 19;
        //param[23].Value = v4.Substring(start, end);
        param[23].Value = v4.Trim();
        command4.Parameters.Add(param[23]);

        param[24] = new SqlParameter("@var5", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v5.Length; if (end > 19) end = 19;
        //param[24].Value = v5.Substring(start, end);
        param[24].Value = v5.Trim();
        command4.Parameters.Add(param[24]);

        connection3.Open();
        object result1 = command3.ExecuteScalar();
        connection3.Close();

        connection4.Open();
        object result2 = command4.ExecuteScalar();
        connection4.Close();

        //ArrayList objl;

        return prid2;
 
    }



    public   object UpdateParticipantToCurrentProject(Guid Xpartid, string Xfirstname, string Xlastname, string email, string function, string organisation, string v1, string v2, string v3, string v4, string v5)
    {

        // SqlCommand command = new SqlCommand("UPDATE Projects SET projectid=@projectid,projectname=@projectname ,projectdescription=@projectdescription FROM guididentity WHERE projectid=@projectid", connection);


        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE participant SET participantid=@partid, FirstName=@firstname, email=@email, LastName=@lastname, Jobfunction=@jobfunction, Organisation=@organisation, var1= @var1 , var2= @var2 , var3= @var3 , var4= @var4 , var5= @var5 WHERE participantid=@partid", connection);


        Guid prid2 = System.Guid.NewGuid();

        SqlParameter[] param = new SqlParameter[25];

        //param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        //param[0].Value = Xprojectid;
        //command.Parameters.Add(param[0]);

        int start = 0; int end = 0;

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = Xpartid;
        command.Parameters.Add(param[1]);


        param[3] = new SqlParameter("@firstname", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xfirstname.Length; if (end > 49) end = 49;
        //param[3].Value = Xfirstname.Substring(start, end)  ;
        param[3].Value = Xfirstname.Trim();
        command.Parameters.Add(param[3]);

        param[4] = new SqlParameter("@lastname", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xlastname.Length; if (end > 49) end = 49;
        //param[4].Value = Xlastname.Substring(start, end);
        param[4].Value = Xlastname.Trim();
        command.Parameters.Add(param[4]);

        param[5] = new SqlParameter("@jobfunction", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = function.Length; if (end > 49) end = 49;
        //param[5].Value = function.Substring(start, end);
        param[5].Value = function.Trim();  
        command.Parameters.Add(param[5]);

        param[6] = new SqlParameter("@organisation", System.Data.SqlDbType.NVarChar);
        //end = organisation.Length; if (end > 49) end = 49;
        //param[6].Value = organisation.Substring(start, end);
        param[6].Value = organisation.Trim();
        command.Parameters.Add(param[6]);

        param[7] = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = email.Length; if (end > 49) end = 49;
        //param[7].Value = email.Substring(start, end);
        param[7].Value = email.Trim();
        command.Parameters.Add(param[7]);

        param[20] = new SqlParameter("@var1", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v1.Length; if (end > 19) end = 19;
        //param[20].Value = v1.Substring(start, end);
        param[20].Value = v1.Trim();
        command.Parameters.Add(param[20]);

        param[21] = new SqlParameter("@var2", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v2.Length; if (end > 19) end = 19;
        //param[21].Value = v2.Substring(start, end);
        param[21].Value = v2.Trim();
        command.Parameters.Add(param[21]);

        param[22] = new SqlParameter("@var3", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v3.Length; if (end > 19) end = 19;
        //param[22].Value = v3.Substring(start, end);
        param[22].Value = v3.Trim();
        command.Parameters.Add(param[22]);

        param[23] = new SqlParameter("@var4", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v4.Length; if (end > 19) end = 19;
        //param[23].Value = v4.Substring(start, end);
        param[23].Value = v4.Trim();
        command.Parameters.Add(param[23]);

        param[24] = new SqlParameter("@var5", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = v5.Length; if (end > 19) end = 19;
        //param[24].Value = v5.Substring(start, end);
        param[24].Value = v5.Trim();
        command.Parameters.Add(param[24]);


        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }
    public  ArrayList EditParticipant(Guid XPartId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);

        string selectCommand = "SELECT participantid, firstname, lastname, email, jobfunction, organisation, var1, var2, var3, var4, var5 FROM  participant   WHERE   participantid=@partid";
        SqlCommand command = new SqlCommand(selectCommand, connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@partId", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XPartId;
        command.Parameters.Add(param[0]);

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();

        //if (reader.HasRows)
        //{
        while (reader.Read())
        {
            if (!reader.IsDBNull(0))
            {
                objl.Add(reader.GetGuid(0));

            }
            if (!reader.IsDBNull(1))
            {
                objl.Add(reader.GetString(1));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(2))
            {
                objl.Add(reader.GetString(2));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(3))
            {
                objl.Add(reader.GetString(3));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(4))
            {
                objl.Add(reader.GetString(4));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(5))
            {
                objl.Add(reader.GetString(5));
            }
            else
            {
                objl.Add("");
            }

            if (!reader.IsDBNull(6))
            {
                objl.Add(reader.GetString(6));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(7))
            {
                objl.Add(reader.GetString(7));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(8))
            {
                objl.Add(reader.GetString(8));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(9))
            {
                objl.Add(reader.GetString(9));
            }
            else
            {
                objl.Add("");
            }
            if (!reader.IsDBNull(10))
            {
                objl.Add(reader.GetString(10));
            }
            else
            {
                objl.Add("");
            }

        }
        //}

        connection.Close();

        return objl;

        //if (reader.HasRows)
        //{
        //    return objl;
        //}



    }

    public   string GetParticipantPasname(string username)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT  passname   FROM  participant   WHERE   username=@username  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
        param[0].Value = username;
        command.Parameters.Add(param[0]);

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();

        return (string)result;
 
    }

    public   Guid GetParticipantId(string username)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT  participantid   FROM  participant   WHERE   username=@username  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
        param[0].Value = username;
        command.Parameters.Add(param[0]);

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();

        if (result == null) {return XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000"); } else { return (Guid)result; }

        

    }

    public   string GetFirstnameFromUserName(string username)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT  firstname   FROM  participant   WHERE   username=@username  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
        param[0].Value = username;
        command.Parameters.Add(param[0]);

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();

        return  (string)result;

    }

    public   string GetLastnameFromUserName(string username)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT  lastname   FROM  participant   WHERE   username=@username  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
        param[0].Value = username;
        command.Parameters.Add(param[0]);

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();

        return (string)result;

    }

    public   string GetFirstnameFromParticipantName(string partname)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT  firstname   FROM  participant   WHERE   participantid=@participantid  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@participantid", System.Data.SqlDbType.NVarChar);
        param[0].Value = partname;
        command.Parameters.Add(param[0]);

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();

        return (string)result;

    }



    public   string GetLastnameFromParticipantName(string partname)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT  lastname   FROM  participant   WHERE   participantid=@participantid  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@participantid", System.Data.SqlDbType.NVarChar);
        param[0].Value = partname;
        command.Parameters.Add(param[0]);

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();

        return (string)result;

    }

 

    public   Guid GetParticipantProject(Guid participantid)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT  projectId   FROM  linkprojectparticipant   WHERE   participantId=@participantid  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@participantid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = participantid;
        command.Parameters.Add(param[0]);

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();

        if (result == null) { return XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000"); } else { return (Guid)result; }

    }

    public   object DeleteParticipantFromCurrentProject(Guid Xprojectid, Guid XPartid)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE LinkProjectParticipant WHERE participantId=@partid and projectId=@projectId", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectId", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = Xprojectid;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = XPartid;
        command.Parameters.Add(param[1]);


        connection.Open();
        //Dim result2 As Object = command2.ExecuteScalar()
        Object result = command.ExecuteScalar();
        connection.Close();

        return result;




    }

    public object DeleteParticipant(Guid XPartid)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE  Participant WHERE participantId=@partid  ", connection);

        SqlParameter[] param = new SqlParameter[9];
        
        param[0] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XPartid;
        command.Parameters.Add(param[0]);


        connection.Open();
        //Dim result2 As Object = command2.ExecuteScalar()
        Object result = command.ExecuteScalar();
        connection.Close();

        return result;




    }

    public   int countparticipantsPerorganizer(Guid XProjectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM participant INNER JOIN LinkProjectParticipant ON participant.participantId = LinkProjectParticipant.participantid  WHERE LinkProjectParticipant.projectId =  @projectid ", connection);

        SqlParameter[] param = new SqlParameter[9];


        param[1] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = XProjectId;
        command.Parameters.Add(param[1]);

        connection.Open();
        object result = command.ExecuteScalar();

        connection.Close();

        if (result != null)
        {
            return (int)result;
        }

        else
        {
            int rr = 0;
            return rr;
        }

    }
    public   int countNonparticipantsPerorganizer(Guid XProjectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM participant INNER JOIN LinkProjectParticipant ON participant.participantId = LinkProjectParticipant.participantid  WHERE LinkProjectParticipant.projectId !=  @projectid ", connection);

        SqlParameter[] param = new SqlParameter[9];


        param[1] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = XProjectId;
        command.Parameters.Add(param[1]);

        connection.Open();
        object result = command.ExecuteScalar();

        connection.Close();

        if (result != null)
        {
            return (int)result;
        }

        else
        {
            int rr = 0;
            return rr;
        }

    }

    public int countitems(Guid XProjectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM items WHERE projectid=@projectid ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XProjectId;
        command.Parameters.Add(param[0]);

        connection.Open();
        object result = command.ExecuteScalar();

        connection.Close();

        if (result != null)
        {
            return (int)result;
        }

        else
        {
            int rr = 0;
            return rr;
        }

    }
    public  int countitemsPerorganizer(Guid XProjectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM items WHERE projectid=@projectid ", connection);

        SqlParameter[] param = new SqlParameter[9];


        param[1] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = XProjectId;
        command.Parameters.Add(param[1]);

        connection.Open();
        object result = command.ExecuteScalar();

        connection.Close();

        if (result != null)
        {
            return (int)result;
        }

        else
        {
            int rr = 0;
            return rr;
        }

    }

    public ArrayList SelectAllItems(Guid XProjectId)
    {

        //Dim ni As Integer
        //ni = countitems(XProjectId)

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT ALL itemId, itemtext FROM items WHERE projectid=@projectid  ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XProjectId;
        command.Parameters.Add(param[0]);

        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
       
        while (reader.Read())
        {
            
            if (!reader.IsDBNull(0)) { objl.Add(reader.GetGuid(0)); }
              if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); }  
        }
     
        connection.Close();
        return objl;
    }


  

   

    public   Guid AddNewItem(Guid Xprojectid, string Xitemtext)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("INSERT INTO items (ItemId,ProjectId,itemtext,created) VALUES ( @itemid,@projectid, @itemtext,@created); select SCOPE_IDENTITY()", connection);

        Guid prid2;
        prid2 = System.Guid.NewGuid();

        int start = 0; int end = 0;

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@itemid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = prid2;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = Xprojectid;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@itemtext", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xitemtext.Length; if (end > 149) end = 149;
        //param[2].Value = Xitemtext.Substring(start, end); ;
        param[2].Value = Xitemtext.Trim();  
        command.Parameters.Add(param[2]);

        DateTime created = DateTime.UtcNow;
        param[3] = new SqlParameter("@created", System.Data.SqlDbType.DateTime);
        param[3].Value = created;
        command.Parameters.Add(param[3]);

        connection.Open();
        Object result = command.ExecuteScalar();

        connection.Close();
        return prid2;




    }

    public Object UpdateItem(Guid Xprojectid, Guid XItemId, string Xitemtext)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE items SET projectid=@projectid , itemid=@itemid, itemtext=@itemtext WHERE itemid=@itemid", connection);
 
        SqlParameter[] param = new SqlParameter[9];

        int start = 0; int end = 0;

        param[0] = new SqlParameter("@itemid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XItemId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = Xprojectid;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@itemtext", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = Xitemtext.Length; if (end > 149) end = 149;
        //param[2].Value = Xitemtext.Substring(start, end); ;
        param[2].Value = Xitemtext.Trim();  
  
        command.Parameters.Add(param[2]);


        connection.Open();
        Object result = command.ExecuteScalar();

        connection.Close();
        return result;




    }

    public int DeleteItem(Guid Xprojectid, Guid XItemId)
    {


        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE items WHERE  ItemId=@itemid", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@itemid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XItemId;
        command.Parameters.Add(param[0]);

        connection.Open();

        Object result = command.ExecuteScalar();
        connection.Close();

        if (result != null)
        {
            return (int)result;
        }

        else
        {
            int rr = 0;
            return rr;
        }
    }

    public Object UpdateItemMapScores( Guid XItemId, double x, double y)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE items SET x=@x , y=@y  WHERE itemid=@itemid", connection);


        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@itemid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XItemId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@x", System.Data.SqlDbType.Float);
        param[1].Value = x;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@y", System.Data.SqlDbType.Float);
        param[2].Value = y;
        command.Parameters.Add(param[2]);


        connection.Open();
        Object result = command.ExecuteScalar();

        connection.Close();
        return result;

    }
    public   ArrayList EditItem(Guid XItemId)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT itemid, itemtext  FROM  items   WHERE itemid=@itemid  ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@itemid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XItemId;
        command.Parameters.Add(param[0]);


        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetGuid(0)); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); }
            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;



    }

     
  

    public object AddItemSortData(Guid projectId, Guid participantId, string itemSortData , string clusterNames)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE LinkProjectParticipant SET ItemSortData=@ItemSortData, clusternames=@clusternames FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@ItemSortData", System.Data.SqlDbType.VarChar);
        param[2].Value = itemSortData;
        command.Parameters.Add(param[2]);

        param[2] = new SqlParameter("@clusternames", System.Data.SqlDbType.NVarChar);
        param[2].Value = clusterNames;
        command.Parameters.Add(param[2]);
 
        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }

    public  object AddItemSortDataAll(Guid projectId, Guid participantId, string itemSortData, string xCoord, string yCoord, string clusterNames)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE LinkProjectParticipant SET ItemSortData=@ItemSortData, xcoord=@xcoord , ycoord=@ycoord , clusternames=@clusternames FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@ItemSortData", System.Data.SqlDbType.VarChar);
        param[2].Value = itemSortData;
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@xcoord", System.Data.SqlDbType.VarChar);
        param[3].Value = xCoord;
        command.Parameters.Add(param[3]);

        param[4] = new SqlParameter("@ycoord", System.Data.SqlDbType.VarChar);
        param[4].Value = yCoord;
        command.Parameters.Add(param[4]);

        param[5] = new SqlParameter("@clusternames", System.Data.SqlDbType.NVarChar);
        param[5].Value = clusterNames;
        command.Parameters.Add(param[5]);


        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }

    public   object AddItemRateData(Guid projectId, Guid participantId, string itemRateData,int rateType)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
       
        
        SqlCommand command = new SqlCommand("", connection);


        switch (rateType)
        {
            case 1:
                command = new SqlCommand("UPDATE LinkProjectParticipant SET ItemRateData1=@ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 2:
                command = new SqlCommand("UPDATE LinkProjectParticipant SET ItemRateData2=@ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 3:
                command = new SqlCommand("UPDATE LinkProjectParticipant SET ItemRateData3=@ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 4:
                command = new SqlCommand("UPDATE LinkProjectParticipant SET ItemRateData4=@ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 5:
                command = new SqlCommand("UPDATE LinkProjectParticipant SET ItemRateData5=@ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            default:
                Console.WriteLine("Default case");
                break;
        }

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@ItemRateData", System.Data.SqlDbType.VarChar);
        param[2].Value = itemRateData;
        command.Parameters.Add(param[2]);

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }

    public object AddItemPosDataX(Guid projectId, Guid participantId, string itemPosDataX )
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE LinkProjectParticipant SET xcoord=@ItemPosDataX FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@ItemPosDataX", System.Data.SqlDbType.VarChar);
        param[2].Value = itemPosDataX;
        command.Parameters.Add(param[2]);


        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }

        public object AddItemPosDataY(Guid projectId, Guid participantId, string itemPosDataY)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE LinkProjectParticipant SET ycoord=@ItemPosDataY FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@ItemPosDataY", System.Data.SqlDbType.VarChar);
        param[2].Value = itemPosDataY;
        command.Parameters.Add(param[2]);

       

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }


        public string makeSelection(Guid projectId, Guid participantId, int maxItemNinQuest)
        {

            int maxItemNinQuestNow = 0;
            string itemsSelected = "";
            ArrayList items = SelectAllItems(projectId);
            Random rnd = new Random();

            if (maxItemNinQuest < items.Count / 2)
            {
                for (int i = 0; i < items.Count; i += 2)
                {
                    int dice = rnd.Next(1, items.Count / 2);
                    if (dice <= maxItemNinQuest) { itemsSelected += XmlConvert.ToString((Guid)items[i]); maxItemNinQuestNow += 1; }
                }

                itemsSelected = String.Format("{0:000}", maxItemNinQuestNow) + itemsSelected;
            }
            
            return itemsSelected;
        }


        public string GetItemSelectedData(Guid projectId, Guid participantId, int maxItemNinQuest)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
            SqlCommand command = new SqlCommand("SELECT items_selected FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);

            SqlParameter[] param = new SqlParameter[19];

            param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
            param[0].Value = projectId;
            command.Parameters.Add(param[0]);

            param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
            param[1].Value = participantId;
            command.Parameters.Add(param[1]);

            


            connection.Open();
            object result = command.ExecuteScalar();
            connection.Close();

            if (result != DBNull.Value) { return (string)result; }
            else
            {
                
                //return "no selection data";
                string itemSelection = makeSelection(projectId, participantId, maxItemNinQuest);
                if (itemSelection != "")
                {
                    string result2 = UpdateItemSelectedData(projectId, participantId, itemSelection);
                }
                return itemSelection;
            }
        }

     public string UpdateItemSelectedData(Guid projectId, Guid participantId, string ItemSelection)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
            SqlCommand command = new SqlCommand("UPDATE LinkProjectParticipant SET  items_selected=@items_selected FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);


            SqlParameter[] param = new SqlParameter[19];

            param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
            param[0].Value = projectId;
            command.Parameters.Add(param[0]);

            param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
            param[1].Value = participantId;
            command.Parameters.Add(param[1]);

            param[2] = new SqlParameter("@items_selected", System.Data.SqlDbType.VarChar);
            param[2].Value = ItemSelection;
            command.Parameters.Add(param[2]);

            


            connection.Open();
            object result = command.ExecuteScalar();
            connection.Close();

            return (string)result;
        }

    public   string GetItemSortData(Guid projectId, Guid participantId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT ItemSortData FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

        //param[2] = new SqlParameter("@ItemSortData", System.Data.SqlDbType.VarChar);
        //param[2].Value = itemSortData;
        //command.Parameters.Add(param[2]);


        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        if (result != DBNull.Value) { return (string)result; }
        else { return "no sort data"; }

    }

    public   ArrayList GetItemSortDataAll(Guid projectId, Guid participantId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT ItemSortData, xcoord  , ycoord ,  clusternames FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

       


        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        //if (reader.HasRows) 
        //{
        int i = 0;
        //objl.Add(CStr(ni))
        while (reader.Read())
        {
            i += 1;
            if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); }
            if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
            if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); }
            if (!reader.IsDBNull(3)) { objl.Add(reader.GetString(3)); } else { objl.Add(""); }
        }
        connection.Close();
        return objl;

    }


    public string GetItemRateData(Guid projectId, Guid participantId, int rateType)
         //public  string GetItemRateData(Guid projectId, Guid participantId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand();
        switch (rateType)
        {
            case 1:
                 command = new SqlCommand("SELECT ItemRateData1 FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 2:
                 command = new SqlCommand("SELECT ItemRateData2 FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 3:
                command = new SqlCommand("SELECT ItemRateData3 FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 4:
                command = new SqlCommand("SELECT ItemRateData4 FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
            case 5:
                command = new SqlCommand("SELECT ItemRateData5 FROM LinkProjectParticipant WHERE projectid=@projectid AND participantId=@partId", connection);
                break;
             
            default:
                Console.WriteLine("Default case");
                break;
        }

       

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@partid", System.Data.SqlDbType.UniqueIdentifier);
        param[1].Value = participantId;
        command.Parameters.Add(param[1]);

      


        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        if (result != DBNull.Value) { return (string)result; }
        else { return "no sort data"; }

    }

    // CONCEPT MAP

    

    public   ArrayList GetAllItemSortData2(Guid participantId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT ItemSortData, clusternames FROM LinkProjectParticipant WHERE participantId=@participantId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@participantId", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = participantId;
        command.Parameters.Add(param[0]);


        


        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;

    }

  

    public   ArrayList GetAllItemCoordData2(Guid participantId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT xcoord, ycoord FROM LinkProjectParticipant WHERE participantId=@participantId", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@participantId", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = participantId;
        command.Parameters.Add(param[0]);


         



        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;

    }
    public   ArrayList GetAllItemSortRateDataPartId(Guid projectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT ItemSortData, ItemRateData, participantId FROM LinkProjectParticipant WHERE projectid=@projectid", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);


      



        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
                if (!reader.IsDBNull(2)) { objl.Add(reader.GetGuid(2)); }
            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;

    }


    public ArrayList GetParticipant2(Guid participantId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        //SqlCommand command = new SqlCommand("SELECT ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid", connection);

        SqlCommand command = new SqlCommand("SELECT   Firstname, Lastname,  email  , username   , passname   ,  var1  , var2  , var3  , var4  , var5  , Jobfunction , Organisation, participant.participantId FROM participant WHERE  participant.participantId =  @participantId ", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@participantId", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = participantId;
        command.Parameters.Add(param[0]);


      



        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
                if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); }
                if (!reader.IsDBNull(3)) { objl.Add(reader.GetString(3)); } else { objl.Add(""); }
                if (!reader.IsDBNull(4)) { objl.Add(reader.GetString(4)); } else { objl.Add(""); }
                if (!reader.IsDBNull(5)) { objl.Add(reader.GetString(5)); } else { objl.Add(""); }
                if (!reader.IsDBNull(6)) { objl.Add(reader.GetString(6)); } else { objl.Add(""); }
                if (!reader.IsDBNull(7)) { objl.Add(reader.GetString(7)); } else { objl.Add(""); }
                if (!reader.IsDBNull(8)) { objl.Add(reader.GetString(8)); } else { objl.Add(""); }
                if (!reader.IsDBNull(9)) { objl.Add(reader.GetString(9)); } else { objl.Add(""); }
                if (!reader.IsDBNull(10)) { objl.Add(reader.GetString(10)); } else { objl.Add(""); }
                if (!reader.IsDBNull(11)) { objl.Add(reader.GetString(11)); } else { objl.Add(""); }
                if (!reader.IsDBNull(12)) { objl.Add(reader.GetGuid(12)); }

            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;

    }
    
    public  ArrayList GetAllParticipantsInfo(Guid projectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        //SqlCommand command = new SqlCommand("SELECT ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid", connection);
        //SqlCommand command = new SqlCommand("WITH MyDerivedTable AS (select ROW_NUMBER() OVER (ORDER BY Participant.created) AS RowNum,LinkProjectParticipant.participantid from participant, LinkProjectParticipant where (LinkProjectParticipant.projectId=@ProjectId) and (participant.participantId = LinkProjectParticipant.participantid)) select  participant.Firstname, participant.Lastname,  participant.username , participant.passname, participant.participantId,MyDerivedTable.RowNum from LinkProjectParticipant, participant, MyDerivedTable Where  (participant.participantId = LinkProjectParticipant.participantid) and (LinkProjectParticipant.participantid = MyDerivedTable.participantid) and  (MyDerivedTable.RowNum between @start and @end) order by participant.created", connection);
        SqlCommand command = new SqlCommand("WITH MyDerivedTable AS (select ROW_NUMBER() OVER (ORDER BY Participant.created) AS RowNum,LinkProjectParticipant.participantid from participant, LinkProjectParticipant where (LinkProjectParticipant.projectId=@ProjectId) and (participant.participantId = LinkProjectParticipant.participantid)) select  participant.Firstname, participant.Lastname,  participant.username , participant.passname, participant.participantId,MyDerivedTable.RowNum from LinkProjectParticipant, participant, MyDerivedTable Where  (participant.participantId = LinkProjectParticipant.participantid) and (LinkProjectParticipant.participantid = MyDerivedTable.participantid) and  (MyDerivedTable.RowNum between 0 and 999) order by participant.created", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);


       


        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();


         // participant.Firstname, participant.Lastname,  participant.username , participant.passname, participant.participantId

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
                if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); }
                if (!reader.IsDBNull(3)) { objl.Add(reader.GetString(3)); } else { objl.Add(""); }
                if (!reader.IsDBNull(4)) { objl.Add(reader.GetGuid(4)); }
            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;

    }


    public ArrayList GetAllParticipantsInfoPlus(Guid projectId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        //SqlCommand command = new SqlCommand("SELECT ItemRateData FROM LinkProjectParticipant WHERE projectid=@projectid", connection);
        //SqlCommand command = new SqlCommand("WITH MyDerivedTable AS (select ROW_NUMBER() OVER (ORDER BY Participant.created) AS RowNum,LinkProjectParticipant.participantid from participant, LinkProjectParticipant where (LinkProjectParticipant.projectId=@ProjectId) and (participant.participantId = LinkProjectParticipant.participantid)) select  participant.Firstname, participant.Lastname,  participant.username , participant.passname, participant.participantId,MyDerivedTable.RowNum from LinkProjectParticipant, participant, MyDerivedTable Where  (participant.participantId = LinkProjectParticipant.participantid) and (LinkProjectParticipant.participantid = MyDerivedTable.participantid) and  (MyDerivedTable.RowNum between @start and @end) order by participant.created", connection);
        SqlCommand command = new SqlCommand("WITH MyDerivedTable AS (select ROW_NUMBER() OVER (ORDER BY Participant.created) AS RowNum,LinkProjectParticipant.participantid from participant, LinkProjectParticipant where (LinkProjectParticipant.projectId=@ProjectId) and (participant.participantId = LinkProjectParticipant.participantid)) select  participant.Firstname, participant.Lastname,  participant.username , participant.passname, participant.participantId, participant.email, MyDerivedTable.RowNum from LinkProjectParticipant, participant, MyDerivedTable Where  (participant.participantId = LinkProjectParticipant.participantid) and (LinkProjectParticipant.participantid = MyDerivedTable.participantid) and  (MyDerivedTable.RowNum between 0 and 999) order by participant.created", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);


      

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();


        // participant.Firstname, participant.Lastname,  participant.username , participant.passname, participant.participantId

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
                if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); }
                if (!reader.IsDBNull(3)) { objl.Add(reader.GetString(3)); } else { objl.Add(""); }
                if (!reader.IsDBNull(4)) { objl.Add(reader.GetGuid(4)); }
                if (!reader.IsDBNull(5)) { objl.Add(reader.GetString(5)); } else { objl.Add(""); }
                if (!reader.IsDBNull(6)) { objl.Add(reader.GetInt64(6)); } else { objl.Add(""); }

            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;

    }
     
     

    public   ArrayList GetAllData2(Guid projectId)
    {

        //12345

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT participantid, ItemSortData, ItemRateData1, xcoord, ycoord, clusternames, ItemRateData2,ItemRateData3,ItemRateData4,ItemRateData5 FROM LinkProjectParticipant WHERE projectid=@projectid", connection);

        SqlParameter[] param = new SqlParameter[19];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

         
         
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetGuid(0)); } else { objl.Add(""); }
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); }
                if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); }
                if (!reader.IsDBNull(3)) { objl.Add(reader.GetString(3)); } else { objl.Add(""); }
                if (!reader.IsDBNull(4)) { objl.Add(reader.GetString(4)); } else { objl.Add(""); }
                if (!reader.IsDBNull(5)) { objl.Add(reader.GetString(5)); } else { objl.Add(""); }
                if (!reader.IsDBNull(6)) { objl.Add(reader.GetString(6)); } else { objl.Add(""); }
                if (!reader.IsDBNull(7)) { objl.Add(reader.GetString(7)); } else { objl.Add(""); }
                if (!reader.IsDBNull(8)) { objl.Add(reader.GetString(8)); } else { objl.Add(""); }
                if (!reader.IsDBNull(9)) { objl.Add(reader.GetString(9)); } else { objl.Add(""); }
            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;

    }



    public  Guid AddNewExcerpt(string title, string excerptshort, string excerpt, string author)
    {

   
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("INSERT INTO excerpts (excerptid, title, excerptshort, excerpt, author) VALUES ( @excerptid, @title, @excerptshort, @excerpt, @author); select SCOPE_IDENTITY()", connection);

        Guid prid2;
        prid2 = System.Guid.NewGuid();

        int start = 0; int end = 0;

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@excerptid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = prid2;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@title", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = title.Length; if (end > 100) end = 100;
        //param[1].Value = title.Substring(start, end); ;
        param[1].Value = title.Trim();  
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@excerptshort", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = excerptshort.Length; if (end > 300) end = 300;
        //param[2].Value = excerptshort.Substring(start, end); ;
        param[2].Value = excerptshort.Trim(); 
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@excerpt", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = excerpt.Length; if (end > 2000) end = 2000;
        //param[3].Value = excerpt.Substring(start, end); ;
        param[3].Value = excerpt.Trim(); 
        command.Parameters.Add(param[3]);

        param[4] = new SqlParameter("@author", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = author.Length; if (end > 100) end = 100;
        //param[4].Value = author.Substring(start, end); ;
        param[4].Value = author.Trim(); 
        command.Parameters.Add(param[4]);

        connection.Open();
        Object result = command.ExecuteScalar();

        connection.Close();
        return prid2;

    }

    public   Object UpdateExcerpt(Guid ExcerptId, string title, string excerptshort, string excerpt, string author)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE excerpts SET excerptid=@excerptid, title=@title, excerptshort=@excerptshort, excerpt=@excerpt, author=@author WHERE excerptid=@excerptid", connection);

        SqlParameter[] param = new SqlParameter[9];

        int start = 0; int end = 0;
 
        param[0] = new SqlParameter("@excerptid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = ExcerptId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@title", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = title.Length; if (end > 100) end = 100;
        //param[1].Value = title.Substring(start, end); ;
        param[1].Value = title.Trim();
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@excerptshort", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = excerptshort.Length; if (end > 300) end = 300;
        //param[2].Value = excerptshort.Substring(start, end); ;
        param[2].Value = excerptshort.Trim();
        command.Parameters.Add(param[2]);

        DateTime created = DateTime.UtcNow;
        param[3] = new SqlParameter("@excerpt", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = excerpt.Length; if (end > 2000) end = 2000;
        //param[3].Value = excerpt.Substring(start, end); ;
        param[3].Value = excerpt.Trim();
        command.Parameters.Add(param[3]);

        param[4] = new SqlParameter("@author", System.Data.SqlDbType.NVarChar);
        //start = 0;
        //end = author.Length; if (end > 100) end = 100;
        //param[4].Value = author.Substring(start, end); ;
        param[4].Value = author.Trim();
        command.Parameters.Add(param[4]);

        connection.Open();
        Object result = command.ExecuteScalar();

        connection.Close();
        return result;

         
    }

    public   object DeleteExcerpt(Guid ExcerptId)
    {

     

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE excerpts WHERE  excerptid=@excerptid", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@excerptid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = ExcerptId;
        command.Parameters.Add(param[0]);

        connection.Open();

        Object result = command.ExecuteScalar();
        connection.Close();

        return result;
    }

    public   ArrayList EditExcerpt(Guid ExcerptId)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT title, excerptshort, excerpt, author  FROM  excerpts   WHERE excerptid=@excerptid  ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@excerptid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = ExcerptId;
        command.Parameters.Add(param[0]);


        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0)) { objl.Add(reader.GetString(0)); } else { objl.Add(""); };
                if (!reader.IsDBNull(1)) { objl.Add(reader.GetString(1)); } else { objl.Add(""); };
                if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); };
                if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); };
            }

        }
        else
        {
            //Console.WriteLine("No rows found.")
        }
        connection.Close();
        return objl;



    }


    public   object AddUserInfo(string page, string ip, string userName, Boolean organiser, Boolean user, string userNameName, string projectName ,string organizerName)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("INSERT INTO usage (visitid, opendate, ip, username, organiser, useronly, pagevisited, username_name, project_name, organizer_name) VALUES (@visitid, @opendate, @ip, @username, @organiser, @useronly, @pagevisited, @username_name, @project_name, @organizer_name); select SCOPE_IDENTITY()", connection);



        SqlParameter[] param = new SqlParameter[11];

 

        param[0] = new SqlParameter("@ip", System.Data.SqlDbType.NVarChar);
        param[0].Value = ip;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
        param[1].Value = userName ;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@organiser", System.Data.SqlDbType.Bit);
        param[2].Value = organiser;
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@useronly", System.Data.SqlDbType.Bit);
        param[3].Value = user;
        command.Parameters.Add(param[3]);

        DateTime created = DateTime.UtcNow;
        param[4] = new SqlParameter("@opendate", System.Data.SqlDbType.DateTime);
        param[4].Value = created;
        command.Parameters.Add(param[4]);


        param[5] = new SqlParameter("@pagevisited", System.Data.SqlDbType.NVarChar);
        param[5].Value = page;
        command.Parameters.Add(param[5]);

        Guid visitid = System.Guid.NewGuid();

        param[6] = new SqlParameter("@visitid", System.Data.SqlDbType.UniqueIdentifier);
        param[6].Value = visitid;
        command.Parameters.Add(param[6]);


        param[7] = new SqlParameter("@username_name", System.Data.SqlDbType.NVarChar);
        param[7].Value = userNameName;
        command.Parameters.Add(param[7]);

        param[8] = new SqlParameter("@project_name", System.Data.SqlDbType.NVarChar);
        param[8].Value = projectName;
        command.Parameters.Add(param[8]);

        param[9] = new SqlParameter("@organizer_name", System.Data.SqlDbType.NVarChar);
        if (organizerName != null) { param[9].Value = organizerName; } else param[9].Value = "no name found";
        command.Parameters.Add(param[9]);

        connection.Open();

        object result;

        try
        {
            
             result = command.ExecuteScalar();

        }

        catch (Exception e)
        {
             
             result = "";
        }

      
        connection.Close();

        return result;



    }

    public   object RemoveUserInfo(Guid visitId)
    {
 
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE usage WHERE visitid=@visitid", connection);
 
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@visitid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = visitId;
        command.Parameters.Add(param[0]);

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }


    public Boolean AriadneProjectExists(string username)
    {
        Guid XparticipantId = GetParticipantId(username);
        Guid XprojectId = GetParticipantProject(XparticipantId);

        

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT organizerid,Projectid FROM Projects   WHERE projectid=@projectid   ", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XprojectId;
        command.Parameters.Add(param[0]);


        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        //ArrayList objl = new ArrayList();

        if (reader.HasRows)
        {
            //while (reader.Read())
            //{
            //    if (!reader.IsDBNull(0))
            //    {
            //        objl.Add(reader.GetGuid(0));
            //    }
            //    if (!reader.IsDBNull(1))
            //    {
            //        objl.Add(reader.GetGuid(1));
            //    }
            //}
            connection.Close();
            return true;
        }
        else
        {
            if (username.Trim().Length > 0)
            {

                if (XmlConvert.ToString(XparticipantId) != "00000000-0000-0000-0000-000000000000")
                {
                    DeleteParticipant(XparticipantId);

                    if (XmlConvert.ToString(XprojectId) != "00000000-0000-0000-0000-000000000000")
                    {
                        DeleteParticipantFromCurrentProject(XprojectId, XparticipantId);
                    }
                }

            }
            connection.Close();
            return false;

        }
 
  
         



    }

    public Guid AddSelection(Guid projectId, string Selection, int analysesinfo, string subtitle, string clusterlabels, string dimensionlabels)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("INSERT INTO selections (projectid, selectionid, analysesinfo, subtitle, selection,clusterlabels,dimensionlabels, date) VALUES ( @projectid, @selectionid, @analysesinfo, @subtitle,  @selection, @clusterlabels, @dimensionlabels, @date); select SCOPE_IDENTITY()", connection);

        Guid selectionId = System.Guid.NewGuid();

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[1] = new SqlParameter("@selection", System.Data.SqlDbType.VarChar);
        param[1].Value = Selection;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@clusterlabels", System.Data.SqlDbType.NVarChar);
        param[2].Value = clusterlabels;
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@dimensionlabels", System.Data.SqlDbType.NVarChar);
        param[3].Value = dimensionlabels;
        command.Parameters.Add(param[3]);

        DateTime created = DateTime.UtcNow;
        param[4] = new SqlParameter("@date", System.Data.SqlDbType.DateTime);
        param[4].Value = created;
        command.Parameters.Add(param[4]);

       
        param[5] = new SqlParameter("@selectionid", System.Data.SqlDbType.UniqueIdentifier);
        param[5].Value = selectionId;
        command.Parameters.Add(param[5]);

        param[6] = new SqlParameter("@subtitle", System.Data.SqlDbType.NVarChar);
        param[6].Value = subtitle;
        command.Parameters.Add(param[6]);

        param[7] = new SqlParameter("@analysesinfo", System.Data.SqlDbType.Int);
        param[7].Value = analysesinfo;
        command.Parameters.Add(param[7]);


        connection.Open();
        Object result = command.ExecuteScalar();

        connection.Close();
        return selectionId;


    }

    public Object UpdateSelectionWithMapNames(string selectionIdS,  string subtitle, string clusterlabels, string dimensionlabels)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("UPDATE selections SET subtitle=@subtitle, clusterlabels=@clusterlabels, dimensionlabels=@dimensionlabels WHERE selectionid=@selectionid", connection);

        SqlParameter[] param = new SqlParameter[9];


        param[0] = new SqlParameter("@selectionid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XmlConvert.ToGuid(selectionIdS);
        command.Parameters.Add(param[0]);

         
        param[1] = new SqlParameter("@subtitle", System.Data.SqlDbType.NVarChar);
        param[1].Value = subtitle;
        command.Parameters.Add(param[1]);

        param[2] = new SqlParameter("@clusterlabels", System.Data.SqlDbType.NVarChar);
        param[2].Value = clusterlabels;
        command.Parameters.Add(param[2]);

        param[3] = new SqlParameter("@dimensionlabels", System.Data.SqlDbType.NVarChar);
        param[3].Value = dimensionlabels;
        command.Parameters.Add(param[3]);
               

        connection.Open();
        Object result = command.ExecuteScalar();
        connection.Close();
        return 0;
    }

 

    

    public ArrayList GetSelection(Guid XprojectId, Guid selectionId)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("SELECT selection, analysesinfo, subtitle, clusterlabels, dimensionlabels FROM selections   WHERE projectid=@projectid AND selectionid=@selectionid  ", connection);

        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = XprojectId;
        command.Parameters.Add(param[0]);

        
        param[3] = new SqlParameter("@selectionid", System.Data.SqlDbType.UniqueIdentifier);
        param[3].Value = selectionId;
        command.Parameters.Add(param[3]);

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();

        //if (reader.HasRows)
        //{
        while (reader.Read())
        {

            if (!reader.IsDBNull(0))
            {
                objl.Add(reader.GetString(0));
                objl.Add(reader.GetInt32(1));
                objl.Add(reader.GetString(2));
                objl.Add(reader.GetString(3));
                objl.Add(reader.GetString(4));
              
            }
           
        }
        connection.Close();
        return objl;

       

    }

    public object RemoveSelection(Guid projectId, Guid selectionId)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE selections WHERE projectid=@projectid AND selectionid=@selectionid", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        param[3] = new SqlParameter("@selectionid", System.Data.SqlDbType.UniqueIdentifier);
        param[3].Value = selectionId;
        command.Parameters.Add(param[3]);

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }

    public object RemoveSelectionsAll(Guid projectId)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("DELETE selections WHERE projectid=@projectid", connection);

        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@projectid", System.Data.SqlDbType.UniqueIdentifier);
        param[0].Value = projectId;
        command.Parameters.Add(param[0]);

        

        connection.Open();
        object result = command.ExecuteScalar();
        connection.Close();

        return result;

    }

    public ArrayList getAllUsersClicks() {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
        SqlCommand command = new SqlCommand("select visitid, opendate , ip, username, organiser, useronly, pagevisited, username_name, project_name, organizer_name FROM usage WHERE username != 'peter33' ORDER BY opendate", connection);

        

        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        ArrayList objl = new ArrayList();

        while (reader.Read())
        {

            if (!reader.IsDBNull(0)) { objl.Add(reader.GetGuid(0)); }
            if (!reader.IsDBNull(1)) { objl.Add(reader.GetDateTime(1)); }
            if (!reader.IsDBNull(2)) { objl.Add(reader.GetString(2)); } else { objl.Add(""); }
            if (!reader.IsDBNull(3)) { objl.Add(reader.GetString(3)); } else { objl.Add(""); }

            if (!reader.IsDBNull(4)) { objl.Add(reader.GetBoolean(4)); } else { objl.Add(false); }
            if (!reader.IsDBNull(5)) { objl.Add(reader.GetBoolean(5)); } else { objl.Add(false); }

            if (!reader.IsDBNull(6)) { objl.Add(reader.GetString(6)); } else { objl.Add(""); }
            if (!reader.IsDBNull(7)) { objl.Add(reader.GetString(7)); } else { objl.Add(""); }
            if (!reader.IsDBNull(8)) { objl.Add(reader.GetString(8)); } else { objl.Add(""); }
            if (!reader.IsDBNull(9)) { objl.Add(reader.GetString(9)); } else { objl.Add(""); }


        }

        connection.Close();
        return objl;

    }
}
             
     
 


 