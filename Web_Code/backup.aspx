<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="backup.aspx.cs" Inherits="_backup" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">



    <div id="BackupBlock" class="horizentalblock2" runat="server">


        <h1>Data and Statistic </h1>
        <p>Download project data or statistics to your desktop. </p>
        <p>Re-upload project data and build a new project from them. </p>

    </div>







    <div id="downloaddataBlock" class="horizentalblock2" runat="server">
        >
         <h1>Data & map statistics on file system</h1>


        <asp:DataList ID="DataList2" runat="server"
            BackColor="White"
            CellPadding="4" BorderStyle="None"
            Width="85%" Height="56px" GridLines="Horizontal" HorizontalAlign="Center"
            OnEditCommand="DownloadFile_Command"
            OnDeleteCommand="RestoreFromFile_Command"
            OnUpdateCommand="RemoveFileBackup_Command">
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />

            <ItemTemplate>


                <asp:Label CssClass="datalabels" ID="fileLabel" runat="server" Width="50%" Text=' <%# Container.DataItem %>' />
                <asp:Button CssClass="databutton" ID="EditParticipantButton" runat="server" class="databutton" CommandName="Edit" Text='download' CommandArgument=' <%# Container.DataItem %>' Width="70px" />
                <asp:Button CssClass="databutton" ID="restore" runat="server" CommandName="Delete" Text='restore to new project' class="databutton" CommandArgument=' <%# Container.DataItem %>' Width="120px" />
                <asp:Button CssClass="databutton" ID="Button1" runat="server" CommandName="Update" Text='remove' CommandArgument=' <%# Container.DataItem %>' Width="60px" />

            </ItemTemplate>

        </asp:DataList>

           <asp:TextBox id="TextResult" Height="300px" Width="100%" runat="server" BorderColor="#FF3300" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
    </div>



    <div id="uploaddataBlock" class="horizentalblock2" runat="server">


        <h1>Upload data&nbsp;to file system
        </h1>

        <asp:FileUpload ID="FileUpload" runat="server" BackColor="White" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" />
        <asp:Button ID="UploadFile" class="button" runat="server" Text="Upload" OnClick="UploadFile_Click" />





    </div>

     <div id="Div1" class="horizentalblock2" runat="server">

         When uploading a datafile not made with this program, be carefull! The datafile has a very specific format.
         <br />
         Make first a backup datafile with this program, than edit it or use it as a template. Apart from that, alway enclose strings (not the numbers) with only this quote: &quot;..
         <br />
         To make a backup datafile go to the organiser window, click on &#39;concept map&#39; (from a project) then select &#39;download ras data&#39;</div>

    <div id="uploadOldCMdataBlock" class="horizentalblock2" runat="server">


        <h1>Upload data&nbsp; from Old Ariadne program
        </h1>



        <asp:DataList ID="DataList3" runat="server"
            BackColor="White"
            CellPadding="4" BorderStyle="None"
            Width="85%" Height="56px" GridLines="Horizontal" HorizontalAlign="Center"
            OnEditCommand="GetOldFile_Command">


            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />

            <ItemTemplate>

                <asp:Label CssClass="datalabels" ID="fileLabel2" runat="server" Width="60%" Text=' <%# Container.DataItem %>' />
                <asp:Button CssClass="databutton" ID="EditParticipantButton" runat="server" CommandName="Edit" Text='upload and restore to new project' CommandArgument=' <%# Container.DataItem %>' Width="180px" />


            </ItemTemplate>

        </asp:DataList>



    </div>











</asp:Content>
