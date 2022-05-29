<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  
    CodeFile="tableUpload.aspx.cs" Inherits="_upload"   %>
 
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
       
      
        <div id ="datablock">
  
           <asp:TextBox ID="tableFileNameField" runat="server"></asp:TextBox>
           <asp:TextBox ID="tableProjectNameField" runat="server"></asp:TextBox>
            <asp:TextBox ID="tableBurtMatrix" runat="server"></asp:TextBox>
             <asp:TextBox ID="tableLabels" runat="server"></asp:TextBox>
           <asp:TextBox ID="tableDataField" runat="server"></asp:TextBox>
           <asp:TextBox ID="tableSelectField" runat="server"></asp:TextBox>
         

        </div>

        <div id="BackupBlock" class="horizentalblock2"   runat="server"  >
 
          <h1  > Data and Statistic </h1>   
          <p> Download project data or statistics to your desktop. </p>
          <p> Re-upload project data and build a new project from them. </p>
        
       </div>
     <div id="div">
            <canvas id="TableCanvas" width="1740" height="400" runat="server" CssClass="sortcanvas">als je dit ziet heb je een hele oude browser.. gebruik Chrome of Internet Explorer 9 </canvas>
        </div>
   
   
 
 <div id="downloaddataBlock" class="horizentalblock2"  runat="server"  >
    
     >
         <h1  >
               
               Data & map statistics on file system</h1>  
         
          <center >  
          <asp:DataList ID="DataList2" runat="server"  
               Width="1038px" Height="50px" GridLines="Horizontal"                   
               BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
               CellPadding="4" 
               OnEditCommand="DownloadFile_Command"
               OnDeleteCommand="getTableFromFile_Command"
               OnUpdateCommand="removeTableFile_Command"
            >
            <ItemTemplate >   
                
              <div  class="datalabels" >   
                 <asp:label id="fileLabel" runat="server" Width="700"  Text=' <%# Container.DataItem %>'  />
                 <asp:Button id="EditParticipantButton" runat="server" class="databutton"   CommandName="Edit" Text= 'download'  CommandArgument =  ' <%# Container.DataItem %>'   />
                 <asp:Button id="restore" runat="server"    CommandName="Delete" Text= 'restore to new project' class="databutton"    CommandArgument =  ' <%# Container.DataItem %>'   />
                   <asp:Button id="Button1" runat="server"    CommandName="Update" Text= 'remove' class="databutton"    CommandArgument =  ' <%# Container.DataItem %>'   />
               </div  >
            </ItemTemplate>
   
        </asp:DataList> 
        </center >               
          
      </div>    

  

  <div id="uploaddataBlock" class="horizentalblock2" runat="server"  >
    
  
         <h1  >
               
               Upload data&nbsp;to file system
         </h1>  

         <asp:FileUpload ID="FileUpload"   runat="server" BackColor="White" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" />      
         <asp:Button id="UploadFile" class="button" runat="server" Text="Upload" OnClick="UploadFile_Click" />
   

  </div>
   
  <script type="text/javascript" src="../javascript/LayoutUtils.js"></script>
 <script type="text/javascript" src="../javascript/table.js"></script>
</asp:Content>

