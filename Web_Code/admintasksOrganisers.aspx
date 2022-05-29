<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="admintasksOrganisers.aspx.cs" Inherits="_OptionsOrganisers" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        ARIADNE ADMINISTRATOR CUBICLE!
    </h2>
    
      
      

    <div id="BackupListBlock"  runat="server"  >
        <div class="midblock"   >
             <h2>Add organizer </h2>
              name:<br /> <asp:TextBox ID="nameBox" runat="server"></asp:TextBox><br />
              pass:<br /> <asp:TextBox ID="passBox" runat="server"></asp:TextBox><br />
              email:<br /> <asp:TextBox ID="emailBox" runat="server"></asp:TextBox> 
            <p>
             <asp:Button ID="Addorganizer" Cssclass="button3"  runat="server" Text="Add organizer" OnClick="Addorganizer_Click" />
            </p>
             old pass:<br /> <asp:TextBox ID="oldPassBox"   runat="server"></asp:TextBox><br />
             new pass:<br /> <asp:TextBox ID="newPassBox"   runat="server"></asp:TextBox><br />
            <p>
             <asp:Label ID="MsgLabel"    runat="server"  />
            </p>
        </div>
    

       <div class="midblock"  >
 

          
           <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
              SelectCommand=" select organizerid, name, pass, email FROM organizer ORDER BY name "
            >
                   
                    
           </asp:SqlDataSource>

           
           <h1  >
               Current Organizers&nbsp;
           </h1>
          
         <center> 
         <asp:DataList ID="organizerlist" runat="server" DataSourceID="SqlDataSource" 
               Width="1038px" Height="50px" GridLines="Horizontal"                   
               BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
               CellPadding="4" 
               OnEditCommand="EditOrganizer_Command"
             OnUpdateCommand="UpdateOrganizer_Command"
               OnDeleteCommand="RemoveOrganizer_Command"
  
                  >
            <ItemTemplate >    
               <div  class="datalabels" >  
                  <asp:label id="ll1" runat="server" Width="100" Text='<%#   Eval("name" )   %>' /> 
                  <asp:label id="ll2" runat="server" Width="100" Text='<%#   Eval("pass" )   %>' /> 
                  <asp:label id="ll3" runat="server" Width="100" Text='<%#   Eval("email")   %>' /> 
                  <asp:Button id="EditOrganizerButton" runat="server" Cssclass="databutton"    CommandName="Edit" Text='reset password'    CommandArgument =   '<%# Eval("name") %>'   />       
                     <asp:Button id="UpdateOrganizerButton" runat="server" Cssclass="databutton"    CommandName="Update" Text='change password'    CommandArgument =   '<%# Eval("name") %>'   />           
                  <asp:Button id="RemoveOrganizerButton" runat="server" Cssclass="databutton" CommandName="Delete" Text='remove' commandargument=   '<%# Eval("name") %>'  />
               </div  >
            </ItemTemplate>
   
         </asp:DataList> 
         </center> 
     </div>
     
         
     <div class="midblock"  >
             <p>
             <asp:Button ID="removeallusers" Cssclass="button3"  runat="server" Text="remove all participants logins" OnClick="RemoveAllParticipants_Click" />
            </p>
    </div>

 


 










   </div>

</asp:Content>
