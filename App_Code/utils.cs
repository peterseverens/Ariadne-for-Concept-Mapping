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
using System.Text;





public  class Utils
{

    public static Random random = new Random();

    public static String DBplatform = "platformDB3";
    public static Guid ActiveProject;

    //string  DBplatform  = "platformDB3";

    //Todo: Change this to use a database query through the middle tier

    DataHandling dh = new DataHandling();
    UtilsDataStrings uts = new UtilsDataStrings();
   
    AriadneUsers usr = new AriadneUsers();

   

  

    public   Guid GetOldData(string fileName)
    {
       
        if (fileName == "")
        {

            //using (System.IO.BinaryReader b = new BinaryReader(File.Open("file.bin", FileMode.Open)))

            fileName = System.Web.HttpContext.Current.Server.MapPath("~") + "/ariadnedata/roos.arp";
            // fileName = System.Web.HttpContext.Current.Server.MapPath("~") + "/ariadnedata/EUservice180506.arp";
            // fileName = System.Web.HttpContext.Current.Server.MapPath("~") + "/ariadnedata/pij maat.arp";
            // fileName = System.Web.HttpContext.Current.Server.MapPath("~") + "/ariadnedata/cbo.arp";
        }


        int itemN = 0;
        int partN = 0;
        string[] items = new String[101];
        string[] part = new string[101];
        int[,] rate = new int[101, 101];
        int[, ,] sort = new int[101, 13, 51];



        if (File.Exists(fileName))
        {

        }
        FileStream fs = new FileStream(fileName, FileMode.Open);
        BinaryReader b = new BinaryReader(fs);
        int length = (int)b.BaseStream.Length;

        //van vaste posities lezen!!
        //fs.Seek(100, SeekOrigin.Begin);
        //int read = b.ReadByte();

        int pos = 0;
        byte xxx;
        //while (pos < length)
        //{

        pos += sizeof(Int16);
        itemN = b.ReadInt16();
        if (itemN > 98) itemN = 98;
        for (int i = 0; i < itemN; i++)
        {
            pos += 240;
            byte[] tvByteArray = new byte[240];
            tvByteArray = b.ReadBytes(240);

            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string tvTemp = enc.GetString(tvByteArray);

            //remove all the \0 and trim the string  
            var ii = i + 1;
            //items[i] = ii.ToString() + ":" + tvTemp.Replace("\0", "").Trim();
            items[i] = tvTemp.Replace("\0", "").Trim();

            //for (int ii = 0; ii < 240; ii++)
            //{
            //pos += 1;
            //items[i] += (b.ReadChar()).ToString();

            //}
        }
        //int start = 0;
        int start = 2 + itemN * 240;
        for (int i = start; i < 67000; i++)
        {
            pos += 1;
            if (pos < length - 2) xxx = b.ReadByte();


        }

        pos += sizeof(Int16);
        partN = b.ReadInt16();

        for (int i = 0; i < partN; i++)
        {
            pos += 400;
            byte[] tvByteArray = new byte[400];
            tvByteArray = b.ReadBytes(400);

            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string tvTemp = enc.GetString(tvByteArray);

            //remove all the \0 and trim the string  
            part[i] = tvTemp.Replace("\0", "").Trim();
            //for (int ii = 0; ii < 400; ii++)
            //{
            //    pos += 1;
            //    //pos = 67000 + i * 1803 + ii;
            //    part[i] += (b.ReadChar()).ToString();
            //}
            for (int ii = 0; ii < 101; ii++)
            {
                pos += 2;
                //pos = 67000 + i * 1803 + ii;
                rate[i, ii] = b.ReadInt16();
            }
            for (int ii = 0; ii < 12; ii++)
            {
                for (int iii = 0; iii < 50; iii++)
                {
                    pos += 2;
                    //pos = 67000 + i * 1803 + ii;
                    if (pos < length)
                    {
                        sort[i, ii, iii] = b.ReadInt16();
                    }
                }
            }
            for (int ii = 0; ii < 1; ii++)
            {
                pos += 1;
                if (pos < length - 2) xxx = b.ReadByte();
            }
        }

        //for (int i = 0; i < 67000; i++)
        //{
        //pos += 1;
        //if (pos < length - 12) xxx = b.ReadByte();


        // }

        //}
        fs.Close();

        //ADD TO DATABASE
        Guid ActiveProject0 = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
        Guid ActiveProject = dh.AddProject((Guid)Membership.GetUser().ProviderUserKey, ActiveProject0, "uploaded project", fileName, "", "", "", "", "",200);

        for (int p = 0; p < partN; p++)
        {
            string pp = part[p];

            char[] specialChars = new char[] { '"', ':', '(', ')' };
            int ll = pp.Length;
            if (ll > 30) ll = 30;
            string ppp = (pp.Trim(specialChars)).Substring(0, ll - 1);

            string pass = XmlConvert.ToString(System.Guid.NewGuid());
            string name = XmlConvert.ToString(System.Guid.NewGuid());
            string result = usr.AddAriadneUser(name, pass, "noEmail", "user");

            Guid ActiveProjectPart = dh.AddNewParticipantToCurrentProject(ActiveProject, name, pass, ppp, "", "", "", "", "", "", "", "", "");
            string itemSortData = "";
            string itemRateData = "";
            string itemPosXData = "";
            string itemPosYData = "";
            //sort[p, ii,iii]
            int groupMaxN = 10;
            int[] nn = new int[101];


            ///WATCH THIS

            for (int g = 0; g < groupMaxN; g++)
            {
                nn[g] = 0;
                for (int i = 0; i < 50; i++)
                {
                    if (sort[p, g, i] > 0 & sort[p, g, i] < 100) nn[g] += 1;
                }

                itemSortData += String.Format("{0:00}", nn[g]);
            }
            for (int g = 0; g < groupMaxN; g++)
            {
                for (int i = 0; i < nn[g]; i++)
                {
                    //itemSortData += String.Format("{0:00}", groups2[g, i]);
                    itemSortData += sort[p, g, i].ToString("00", CultureInfo.InvariantCulture);
                }
            }
            for (int i = 0; i < itemN; i++)
            {
                itemRateData += rate[p, i].ToString("00", CultureInfo.InvariantCulture); ;
                itemPosXData += "0.0000";
                itemPosYData += "0.0000";
            }

             
            object result1 = dh.AddItemSortData(ActiveProject, ActiveProjectPart, itemSortData, ""); //LET OP xcoord, ycoord en order hier nog bij....
            object result2 = dh.AddItemRateData(ActiveProject, ActiveProjectPart, itemRateData,1);
            object result3 = dh.AddItemPosDataX(ActiveProject, ActiveProjectPart, itemPosXData);
            object result4 = dh.AddItemPosDataY(ActiveProject, ActiveProjectPart, itemPosYData);
        }
        for (int i = 0; i < itemN; i++)
        {
            int ll = items[i].Length;
            if (ll > 99) ll = 99;
            Guid ActiveProjectItem = dh.AddNewItem(ActiveProject, items[i].Substring(0, ll));
        }

        return ActiveProject;
    }




    public   void testdata(int method)
    {
    

        Guid ActiveProject0 = XmlConvert.ToGuid("00000000-0000-0000-0000-000000000000");
        if (method == 1) ActiveProject = dh.AddProject((Guid)Membership.GetUser().ProviderUserKey, ActiveProject0, "Test project random", "Test project met random gegenereerde data","","","","","",200);
        if (method == 2) ActiveProject = dh.AddProject((Guid)Membership.GetUser().ProviderUserKey, ActiveProject0, "Test project 3 groups", "Test project met 3 groepen","","","","","",200);
        if (method == 3) ActiveProject = dh.AddProject((Guid)Membership.GetUser().ProviderUserKey, ActiveProject0, "Test project both", "Test project met 3 groepen en random","","","","","",200);
        int itemN = 60;
        int partN = 20;

        for (int i = 1; i < itemN + 1; i++)
        {
            Guid Item = dh.AddNewItem(ActiveProject, "this is item" + String.Format("{0:00}", i));
        }
        for (int i = 1; i < partN + 1; i++)
        {
            string pass = XmlConvert.ToString(System.Guid.NewGuid());
            string name = XmlConvert.ToString(System.Guid.NewGuid());
            string result = usr.AddAriadneUser(name, pass, "noEmail", "user");
            Guid ActiveProjectPart = dh.AddNewParticipantToCurrentProject(ActiveProject,name,pass, "firstname" + String.Format("{0:00}", i), "lastname" + String.Format("{0:00}", i), "", "", "", "", "", "", "", "");
            if (method == 1) createSortData(itemN, ActiveProject, ActiveProjectPart);
            if (method == 2) createSortDataNotRandom(itemN, ActiveProject, ActiveProjectPart);
            if (method == 3)
            {
                if (i <= 8) createSortDataNotRandom(itemN, ActiveProject, ActiveProjectPart);
                if (i > 8) createSortData(itemN, ActiveProject, ActiveProjectPart);
            }
        }

    }

    public   void createSortData(int itemN, Guid projectId, Guid participantId)
    {
       

        int groupMaxN = 10;
        int[] groupsN = new int[groupMaxN + 1];
        int[,] groups2 = new int[groupMaxN + 1, itemN + 1];
        string itemSortData = "";

        for (int i = 1; i < itemN + 1; i++)
        {

            int randomGroup = random.Next(1, groupMaxN + 1);
            groupsN[randomGroup] += 1;
            groups2[randomGroup, groupsN[randomGroup]] = i;
        }
        for (int g = 1; g < groupMaxN + 1; g++)
        {
            itemSortData += String.Format("{0:00}", groupsN[g]);
        }
        for (int g = 1; g < groupMaxN + 1; g++)
        {
            for (int i = 1; i < groupsN[g] + 1; i++)
            {
                itemSortData += String.Format("{0:00}", groups2[g, i]);
            }
        }
        object result = dh.AddItemSortData(projectId, participantId, itemSortData, "");
    }

    public   void createSortDataNotRandom(int itemN, Guid projectId, Guid participantId)
    {
        

        int groupMaxN = 10;
        int[] groupsN = new int[groupMaxN + 1];
        int[,] groups2 = new int[groupMaxN + 1, itemN + 1];
        string itemSortData = "";

        for (int i = 1; i < 10 + 1; i++)
        {
            groupsN[1] += 1;
            groups2[1, groupsN[1]] = i;
        }
        for (int i = 11; i < 20 + 1; i++)
        {
            groupsN[2] += 1;
            groups2[2, groupsN[2]] = i;
        }
        for (int i = 21; i < 30 + 1; i++)
        {
            groupsN[3] += 1;
            groups2[3, groupsN[3]] = i;
        }
        for (int i = 31; i < 40 + 1; i++)
        {
            groupsN[4] += 1;
            groups2[4, groupsN[4]] = i;
        }
        for (int i = 41; i < 50 + 1; i++)
        {
            groupsN[5] += 1;
            groups2[5, groupsN[5]] = i;
        }
        for (int i = 51; i < itemN + 1; i++)
        {
            groupsN[6] += 1;
            groups2[6, groupsN[6]] = i;
        }
        for (int g = 1; g < groupMaxN + 1; g++)
        {
            itemSortData += String.Format("{0:00}", groupsN[g]);
        }
        for (int g = 1; g < groupMaxN + 1; g++)
        {
            for (int i = 1; i < groupsN[g] + 1; i++)
            {
                itemSortData += String.Format("{0:00}", groups2[g, i]);
            }
        }
        object result = dh.AddItemSortData(projectId, participantId, itemSortData, "");
    }


    //'items : max = 98 : i=1 to item_n

    //'item_n  pos 1-2                               (integer)
    //'item(i) pos 3 + ((i - 1) * 240)               (string)

    //'variables : max=5 : v = 1 To var_n
    //'var_n   pos 25001                             (integer
    //'var(i)  pos 25003 + ((i - 1) * 500), varsave  (string)

    //'selections Participants             p= q to part_n
    // ' part_s(98)  pos 29003 + (i - 1) * 2            (integer)

    //'selections Items                    i= 1 to item_n
    // ' item_s(98)  pos 29203 + (i - 1) * 2            (integer)

    //'selections Variables                v= 1 to 5 c= 1 to 9
    // ' var_s(5, 9) pos 29403 + ((v-1)*20) + ((c-1)*2) (integer)

    //'latent preferences i= 1 to item_n : d=1,2,3,4,5
    //  'd_score(i,d) pos 30006 + ((d-1) * 400) + (i-1) * 4)       (integer)    (++ space for 17 dimensions)

    //  'cluster members      i = 1 to item_n : c=1 to 18                     (1=no clusters)
    //  'cl(i,c)      pos 32006 + ((c-1) * 200) + ((i-1) * 2)       (integer)

    //'clusternames         clus = 1 to 18 : clus_n=2 to 18                     (1=no clusters)
    //  'cluslabel1(clus,clus_n)   pos 34006 + ((clus_n-2) * 1080) + (clus-1 * 60)  (string)    (18*18*80=32,320)
    //   'cluslabel1(clus,clus_n)   pos 34006 + ((clus_n-2) * 1080) + (clus-1 * 60)+30  (string)    (18*18*80=32,320)

    //'participants : max = ? : p = 1 to part_n
    // 'part_n  pos  67000                               (integer)
    // 'part(p) post 67003 + ((p - 1) * 1803)            (string*400)

    //'participants and rates : max = ? : p=1 to part_n : r=1 to item_n
    //  'rate(p,r) pos  67003 + ((p - 1) * 1803) +  400 + ((i-1) * 2)

    //'participants and sort  : max = ? : p=1 to part_n : s=1 to item_n
    //  'sort(p,s)  pos  67003 + ((p - 1) * 1803) +  600 + (ij * 2)


   
  
}
             
     
 


 