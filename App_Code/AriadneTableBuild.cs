


using System.Data;
using System.Data.SqlClient;

using System;
using System.Configuration;
using System.Collections;
using System.Web.Security;


 
    public  class AriadneBuildTables
    {
        AriadneUsers usr = new AriadneUsers();


        

        public  string BuildTables()
        {
            string roleResult = usr.createAriadneRoles();

            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Profile.DBplatform].ConnectionString);
            string[] sql = new string[100];

            sql[1] = "DROP TABLE organizer ";
            sql[2] = "CREATE TABLE organizer  (organizerId  uniqueidentifier, name nvarchar(MAX), pass nvarchar(MAX), email nvarchar(MAX))";

            sql[3] = "DROP TABLE projects ";
            sql[4] = "CREATE TABLE projects (organizerId  uniqueidentifier, projectId  uniqueidentifier, projectName nvarchar(MAX) , projectDescription nvarchar(999) ,projectType integer, created datetime, locktype nvarchar(MAX), max_item_n integer, itemratedefenition1  nvarchar(MAX),itemratedefenition2  nvarchar(MAX),itemratedefenition3  nvarchar(MAX),itemratedefenition4  nvarchar(MAX),itemratedefenition5  nvarchar(MAX))";

            sql[5] = "DROP TABLE Items ";
            sql[6] = "CREATE TABLE Items (organizerId  uniqueidentifier, projectId  uniqueidentifier, itemId  uniqueidentifier, itemtext nvarchar(199), created datetime, x float,  y float)";

            sql[7] = "DROP TABLE participant";
            sql[8] = "CREATE TABLE participant (organizerId uniqueidentifier, projectId  uniqueidentifier, participantId  uniqueidentifier, Firstname nvarchar(MAX), Lastname nvarchar(MAX), email nvarchar(MAX), created datetime, username nvarchar(MAX), passname nvarchar(MAX) ,  var1 nvarchar(MAX), var2 nvarchar(MAX), var3 nvarchar(MAX), var4 nvarchar(MAX), var5 nvarchar(MAX), Jobfunction nvarchar(MAX), Organisation nvarchar(MAX))";

            sql[9] = "DROP TABLE LinkProjectParticipant ";
            sql[10] = "CREATE TABLE LinkProjectParticipant (organizerId  uniqueidentifier, projectId  uniqueidentifier, participantId  uniqueidentifier, itemsortdata varchar(MAX), itemratedata1 varchar(MAX), itemratedata2 varchar(MAX), itemratedata3 varchar(MAX), itemratedata4 varchar(MAX), itemratedata5 varchar(MAX), created datetime, xcoord varchar(MAX), ycoord varchar(MAX), clusternames nvarchar(MAX), items_selected varchar(MAX) )";

            sql[11] = "DROP TABLE backups";
            sql[12] = "CREATE TABLE backups (organizerId  uniqueidentifier, projectId  uniqueidentifier, projectName nvarchar(MAX),  version nvarchar(MAX), created datetime )";

            sql[13] = "DROP TABLE selections ";
            sql[14] = "CREATE TABLE selections  (projectId  uniqueidentifier, selectionId  uniqueidentifier,  selection varchar(MAX), analysesinfo integer, subtitle nvarchar(MAX), clusterlabels nvarchar(MAX), dimensionlabels nvarchar(MAX), date datetime)";

             

            string result = " creating roles: " + roleResult + " crateing tables: ";

            for (int i = 1; i <= 14; i++)
            {

                result += string.Format("{0,0}", i) + " : " + buildTablesExecute(sql[i], "platformDB3") + " ; ";
            }

            return result;
        }


        


        public  string BuildExcerptTables()
        {
            //string roleResult = AriadneUsers.createAriadneRoles();

            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Profile.DBplatform].ConnectionString);
            string[] sql = new string[100];

            sql[1] = "DROP TABLE excerpts ";
            sql[2] = "CREATE TABLE excerpts (excerptid  uniqueidentifier, title nvarchar(100), excerptshort nvarchar(300), excerpt nvarchar(2000), author nvarchar(100))";



            string result = " creating tables: ";

            for (int i = 1; i <= 2; i++)
            {

                result += string.Format("{0,0}", i) + " : " + buildTablesExecute(sql[i], "platformDB3") + " ; ";
            }

            return result;
        }

        public   string BuildUsageTables()
        {
            //string roleResult = AriadneUsers.createAriadneRoles();

            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Profile.DBplatform].ConnectionString);
            string[] sql = new string[100];

            sql[1] = "DROP TABLE usage ";
            sql[2] = "CREATE TABLE usage (visitid uniqueidentifier, opendate datetime, ip nvarchar(99), username nvarchar(199), organiser bit, useronly bit, project_name nvarchar(199), username_name nvarchar(199), organizer_name nvarchar(199), pagevisited nvarchar(299))";



            string result = " creating tables: ";

            for (int i = 1; i <= 2; i++)
            {

                result += string.Format("{0,0}", i) + " : " + buildTablesExecute(sql[i], "platformDB3") + " ; ";
            }

            return result;
        }


     
         public  string buildTablesExecute(string sql, string DBplatform)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            //connection.Close();
            connection.Open();

            try
            {
                object result = command.ExecuteScalar();
                connection.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                connection.Close();
                return  ex.ToString();
            }
            
        }




        public  string buildProceduresExecute(string sql, string DBplatform)
        {


            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBplatform].ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                object result = command.ExecuteNonQuery();
                connection.Close();
                return "OK";

            }

            catch (Exception ex)
            {
                connection.Close();
                return ex.ToString();
            }


            


        }

       

    }
 
   

 
