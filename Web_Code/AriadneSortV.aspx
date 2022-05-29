<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AriadneSortV.aspx.cs" Inherits="ariadneSort" %>

<!DOCTYPE html PUBLIC  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<style>
    body {
        margin: 0;
        width: 100%;
        height: 100%;
        overflow: hidden;
    }

    form {
        margin: 0;
        width: 100%;
        height: 100%;
        overflow: hidden;
    }

    .SortCanvas {
        margin: 0;
        width: 100%;
        height: 100%;
        overflow: hidden;
    }
    
    html {
        margin: 0;
        width: 100%;
        height: 100%;
        overflow: hidden;
    }
</style>

<head runat="server">
    <title></title>
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="expires" content="-1" />
    <meta name="viewport" content="width=width, maximum-scale=1.0" />
    <link href="../Css/ariadne.css" rel="Stylesheet" type="text/css" />
</head>
<body>

    

    <form id="form1" runat="server">
              
        <div id="div">
            <canvas id="SortCanvas" width="1740" height="850" runat="server" CssClass="sortcanvas">als je dit ziet heb je een hele oude browser.. gebruik Chrome of Internet Explorer 9 </canvas>
        </div>

        <asp:ImageButton ID="savesortresulttoserverandback" CssClass="savebuttonbp" runat="server" Text="Save & back" OnClick="savesortresultandback_Click" ImageUrl="~/images/icon-home.png"></asp:ImageButton>
        <asp:Label ID="firstName" CssClass="savebuttonbp2" runat="server"></asp:Label>

        <div id="datablock">

            <textarea id="YellowText" cols="0" rows="4" position: absolute overflow: hidden></textarea>

            <asp:TextBox ID="itemData" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="sortData" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="rateData" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="xData" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="yData" CssClass="hiddendatabutton" runat="server"></asp:TextBox>

            <asp:TextBox ID="clusterNames" CssClass="hiddendatabutton" runat="server"></asp:TextBox>

            <asp:TextBox ID="rateType" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxProject" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxParticipant" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="saveResult" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
            <asp:TextBox ID="saveThis" CssClass="hiddendatabutton" runat="server"></asp:TextBox>
        </div>


    </form>

</body>

<script type="text/javascript" src="../javascript/jquery-1.8.3.min.js"></script> 
<script type="text/javascript" src="../javascript/LayoutUtils.js"></script>
<script type="text/javascript" charset="utf-8" src="../javascript/ariadnesort3.js"></script>
