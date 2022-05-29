<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AriadneConceptSelectedMap.aspx.cs" Inherits="ariadneConceptSelectedMap" %>

<!DOCTYPE html PUBLIC  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">




<html xmlns="http://www.w3.org/1999/xhtml">



<head runat="server">

    <title></title>
</head>
<body id="body1" style="overflow: scroll">

    <link href="../Css/ariadne.css" rel="Stylesheet" type="text/css" />

    <form id="form1" runat="server">
        <div id="buttonForm">
        </div>
        
        <div id="conceptForm" runat="server">
            <div id="div">
                <canvas id="MapCanvas" width="1740" height="850" runat="server" cssclass="sortcanvas">als je dit ziet heb je een hele oude browser.. gebruik Chrome of Internet Explorer 9 </canvas>
            </div>
            <asp:Button ID="UploadDataFile" class="buttongetdatasel" runat="server" Text="download data" OnClick="UploadDataFile_Click" />
            <asp:Button ID="UploadStatisticsFile" class="buttongetgetstatdatasel" runat="server" Text="download statistics" OnClick="UploadStatisticsFile_Click" />
            <asp:Button ID="UploadCanvasImageFile" class="buttongetgetCanvasImageFile" runat="server" Text="download image" OnClick="UploadCanvasImageFile_Click" />
        </div>
        <div id="datablock">


             <asp:TextBox ID="activeselectiontext" runat="server"></asp:TextBox>
            <asp:TextBox ID="projectName" runat="server"></asp:TextBox>
            <asp:TextBox ID="itemData" runat="server"></asp:TextBox>
            <asp:TextBox ID="coordinateData" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterData1" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterData2" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterData3" runat="server"></asp:TextBox>

            <asp:TextBox ID="clusterDataD1" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterDataD2" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterDataD3" runat="server"></asp:TextBox>

            <asp:TextBox ID="rates1" runat="server"></asp:TextBox>
            <asp:TextBox ID="rates2" runat="server"></asp:TextBox>
            <asp:TextBox ID="rates3" runat="server"></asp:TextBox>
            <asp:TextBox ID="rates4" runat="server"></asp:TextBox>
            <asp:TextBox ID="rates5" runat="server"></asp:TextBox>

            <asp:TextBox ID="clusterRates1" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates2" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates3" runat="server"></asp:TextBox>

            <asp:TextBox ID="clusterRates21" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates22" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates23" runat="server"></asp:TextBox>

            <asp:TextBox ID="clusterRates31" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates32" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates33" runat="server"></asp:TextBox>

            <asp:TextBox ID="clusterRates41" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates42" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates43" runat="server"></asp:TextBox>

            <asp:TextBox ID="clusterRates51" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates52" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterRates53" runat="server"></asp:TextBox>

            <asp:TextBox ID="participantDimensions" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantDimensions2" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantDimensions3" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantDimensions4" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantDimensions5" runat="server"></asp:TextBox>

            <asp:TextBox ID="participantGroupsDimensions" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantGroupsDimensions2" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantGroupsDimensions3" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantGroupsDimensions4" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantGroupsDimensions5" runat="server"></asp:TextBox>

            <asp:TextBox ID="participantGroupsNames" runat="server"></asp:TextBox>
            <asp:TextBox ID="participantNames" runat="server"></asp:TextBox>
            <asp:TextBox ID="clusterNamesCoord" runat="server"></asp:TextBox>
            <asp:TextBox ID="rawSortData" runat="server"></asp:TextBox>

            <asp:TextBox ID="pageStatus" runat="server"></asp:TextBox>

            <asp:TextBox ID="ratedef1" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef2" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef3" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef4" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef5" runat="server"></asp:TextBox>

           
            <asp:TextBox ID="subtitletext" runat="server" Width="400" BorderStyle="Solid"></asp:TextBox>
            <asp:TextBox ID="MapClusterNames" runat="server"   />
            <asp:TextBox ID="MapDimensionNames" runat="server"   />

        </div>
    </form>
</body>
</html>
<script type="text/javascript" charset="utf-8">
    if (typeof console == "undefined") {
        this.console = {
            log: function () {
            }, info: function () {
            }, error: function () {
            }, warn: function () {
            }
        };
    }
</script>

<script type="text/javascript" src="../javascript/wordcloud2.js"></script>
<script type="text/javascript" src="../mrdoob-three.js-3a8c437/build/three.js"></script>
<script type="text/javascript" src="../javascript/trackballcontrols.js"></script>


<script type="text/javascript" src="../javascript/readpagedata.js"></script>
<script type="text/javascript" src="../javascript/LayoutUtils.js"></script>
<script type="text/javascript" charset="utf-8" src="../javascript/mapmenu.js"></script>


<script type="text/javascript" charset="utf-8" src="../javascript/ariadneconceptworld4.js"></script>

<script type="text/javascript" charset="utf-8" src="../javascript/ariadneconceptmap7.js"></script>
 



<script type="text/javascript" charset="utf-8" src="../javascript/canvas2image.js"></script>
<script type="text/javascript" charset="utf-8" src="../javascript/base64.js"></script>


<script type="text/javascript" src="../javascript/jquery-1.8.3.min.js"></script>

<script type="text/javascript" src="../javascript/json2.min.js"></script>

<script type="text/javascript" charset="utf-8" src="../javascript/startmapbuilding.js"></script>
<script type="text/javascript" src="../javascript/jscolor.js"></script>
