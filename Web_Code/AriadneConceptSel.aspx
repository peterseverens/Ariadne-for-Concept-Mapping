<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AriadneConceptSel.aspx.cs" Inherits="ariadneConceptSel" %>

<!DOCTYPE html PUBLIC  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">




<html xmlns="http://www.w3.org/1999/xhtml">



<head runat="server">

    <title></title>
</head>
<body>

    <link href="../Css/ariadne.css" rel="Stylesheet" type="text/css" />

    <form id="form1" runat="server">




        <div id="selectionsForm" class="leftblock2 " runat="server">

            <asp:Label ID="Label1" runat="server" Font-Size="20px"></asp:Label>


            <asp:Label ID="subtitlelabel" runat="server" Font-Bold="True">subtitle for map</asp:Label>
            <asp:TextBox ID="subtitletext" CssClass="textbox" runat="server" Width="400" BorderStyle="Solid" placeholder="sub title"></asp:TextBox>
            <asp:CheckBox ID="eigenTreatment" runat="server" Text="SumSq = 1 (for clustering)" />

            <asp:Label ID="v1" runat="server" Font-Bold="True">participant function</asp:Label>
            <asp:Label ID="v2" runat="server" Font-Bold="True">characteristic 1</asp:Label>
            <asp:Label ID="v3" runat="server" Font-Bold="True">characteristic 2</asp:Label>
            <asp:Label ID="v4" runat="server" Font-Bold="True">characteristic 3</asp:Label>
            <asp:Label ID="v5" runat="server" Font-Bold="True">characteristic 4</asp:Label>
            <asp:Label ID="v6" runat="server" Font-Bold="True">characteristic 5</asp:Label>
            <asp:Label ID="v7" runat="server" Font-Bold="True">participants</asp:Label>
            <asp:Label ID="v8" runat="server" Font-Bold="True">items</asp:Label>
            <asp:Label ID="r1" runat="server" Font-Bold="True">rating 1</asp:Label>
            <asp:Label ID="r2" runat="server" Font-Bold="True">rating 2</asp:Label>
            <asp:Label ID="r3" runat="server" Font-Bold="True">rating 3</asp:Label>
            <asp:Label ID="r4" runat="server" Font-Bold="True">rating 4</asp:Label>
            <asp:Label ID="r5" runat="server" Font-Bold="True">rating 5</asp:Label>
            <asp:Label ID="r00" runat="server" Font-Bold="True">sort</asp:Label>
            <asp:Label ID="r01" runat="server" Font-Bold="True">rating 1</asp:Label>
            <asp:Label ID="r02" runat="server" Font-Bold="True">rating 2</asp:Label>
            <asp:Label ID="r03" runat="server" Font-Bold="True">rating 3</asp:Label>
            <asp:Label ID="r04" runat="server" Font-Bold="True">rating 4</asp:Label>
            <asp:Label ID="r05" runat="server" Font-Bold="True">rating 5</asp:Label>

            <asp:Label ID="Line0" runat="server" Font-Bold="True"></asp:Label>
            <asp:Label ID="Line1" runat="server" Font-Bold="True"></asp:Label>
            <asp:Label ID="Line2" runat="server" Font-Bold="True"></asp:Label>


            <asp:Button ID="Try2d" CssClass="savebuttonsel" runat="server" Text="Create new selection and Build Map" OnClick="buildmap_Click"></asp:Button>
            <asp:Button ID="getdatafile" CssClass="buttongetdata" runat="server" Text="download raw data" OnClick="getdata_Click"></asp:Button>
        </div>




        <div id="datablock" hidden="hidden">

            <asp:TextBox ID="projectName" runat="server"></asp:TextBox>

            <asp:TextBox ID="ratedef1" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef2" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef3" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef4" runat="server"></asp:TextBox>
            <asp:TextBox ID="ratedef5" runat="server"></asp:TextBox>


        </div>

        <div class="rightblock2 ">



            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
                SelectCommand="select projectid, selectionid, subtitle, date FROM selections WHERE projectid = @projectid  order by date"
                OnSelecting="Selection_Selecting">

                <SelectParameters>
                    <asp:Parameter Name="projectid" />
                </SelectParameters>

            </asp:SqlDataSource>



            <h1>selections&nbsp;
            </h1>
            <p>
                <asp:Button ID="Button1" runat="server" CssClass="databutton2" Text="Remove All Selections" OnClick="RemoveSelectionsAll_Click"></asp:Button></p>

            <asp:DataList ID="SelectionList" runat="server" DataSourceID="SqlDataSource2"
                BackColor="White"
                CellPadding="4" BorderStyle="None"
                Width="95%" Height="56px" GridLines="Horizontal" HorizontalAlign="Center"
                OnDeleteCommand="RemoveSelection_Command"
                OnEditCommand="ShowMapFromSelection_Command"
                OnUpdateCommand="EditSelection_Command">

                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />

                <ItemTemplate>
                    <div class="datalabels">
                        <asp:Button CssClass="databutton" ID="removeselection" runat="server" CommandName="Delete" Text='x' CommandArgument='<%# Eval("selectionid") %>' />
                        <asp:Button CssClass="databutton" ID="getselection" runat="server" CommandName="Update" Text='use selection' CommandArgument='<%# Eval("selectionid") %>' />
                        <asp:Button CssClass="databutton" ID="getmap" runat="server" CommandName="Edit" Text='show map' CommandArgument='<%# Eval("selectionid") %>' />
                        <asp:Label CssClass="datalabels" ID="Label2" runat="server" Text='<%# Eval("date") %>' Width="100%" />
                        <asp:Label CssClass="datalabels" ID="selectionlabel" runat="server" Text='<%# Eval("subtitle") %>' />
                    </div>
                </ItemTemplate>

            </asp:DataList>



        </div>


    </form>
</body>
</html>

