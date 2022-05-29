<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="admintasksBuildTables.aspx.cs" Inherits="_AdminBuildTables" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        ARIADNE ADMINISTRATOR CUBICLE!
    </h2>
    
      
      

    <div id="BackupListBlock"  runat="server"  >
        
     
         
   
 
     <div class="midblock"  >
         <center> 
         <div   >
             <h2>Project Database </h2>
             <asp:Button ID="BuildTables" Cssclass="button3"  runat="server" Text="Build Ariadne Database Tables" OnClick="BuildTables_Click" />
         </div>
             
         <div   >
             <h2>Excerpt Database </h2>
             <asp:Button ID="BuildExcerptTables" Cssclass="button3"  runat="server" Text="Build Ariadne Excerpt Tables" OnClick="BuildExcerptTables_Click" />
         </div>
          <div   >
             <h2>Usage Info Database </h2>
             <asp:Button ID="Button1" Cssclass="button3"  runat="server" Text="Build Usage Info Tables" OnClick="BuildUsageInfoTables_Click" />
         </div>
            
         
         <p></p>

         <div >
             <h2>Build Projects (Use with caution!)</h2>
            
             <asp:Button ID="BuildTestDataRandom" Cssclass="button3"  runat="server" Text="test project random" OnClick="BuildTestData_Click"    />
             <asp:Button ID="BuildTestDataNotRandom" Cssclass="button3" runat="server" Text="test project 3 groups" OnClick="BuildTestDataNotRandom_Click"    />
             <asp:Button ID="BuildTestDataBoth" Cssclass="button3" runat="server" Text="test project combined" OnClick="BuildTestDataBoth_Click"    />
         
             
         </div>

         <p></p>

         <div   >
             <asp:TextBox ID="TextResult" runat="server" Height="273px" Width="627px" BorderColor="#FF3300" BorderWidth="10px"></asp:TextBox>
         </div>

         </center>
   
     </div>

 

 






   </div>

</asp:Content>
