using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
public class Service2 : IService2
{
    DataHandling dh = new DataHandling();
    public string SaveSortData(string sortData, string xData, string yData, string clusterNames)
    {
        int ratetype = Convert.ToInt32(sortData.Substring(0, 1));
        Guid ActiveProject = XmlConvert.ToGuid(sortData.Substring(1, 36));
        Guid ActiveParticipant = XmlConvert.ToGuid(sortData.Substring(37, 36));
        string sortResults = sortData.Substring(73, sortData.Length - 73);

        //object result = dh.AddItemSortData(ActiveProject, ActiveParticipant, sortResults, clusterNames);
        object result = dh.AddItemSortDataAll(ActiveProject, ActiveParticipant, sortResults, xData, yData, clusterNames);
        if (result == null) { return "save OK!"; } else { return string.Format((string)result); }


    }
}
