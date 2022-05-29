using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    DataHandling dh = new DataHandling();
    public string SaveRateData(string rateData)
    {
        int ratetype = Convert.ToInt32(rateData.Substring(0, 1));
        Guid ActiveProject = XmlConvert.ToGuid(rateData.Substring(1, 36));
        Guid ActiveParticipant = XmlConvert.ToGuid(rateData.Substring(37, 36));
        string rateResults = rateData.Substring(73, rateData.Length-73);

        object result = dh.AddItemRateData(ActiveProject, ActiveParticipant, rateResults, ratetype);

        if (result == null) { return "save OK!"; } else { return string.Format((string)result); }
       
       
    }

     
}
