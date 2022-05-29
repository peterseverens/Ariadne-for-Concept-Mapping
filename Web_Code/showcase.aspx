<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="showcase.aspx.cs" Inherits="_Showcase" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
      <div id="BackupBlock" class="horizentalblock2"   runat="server"  >

      
  
          <h1  > Project history</h1>   
          <p> This is the place where you can present your project. Just send - peter.severens@talcott.nl - an excerpt of a concept mapping with Ariadne project with a maximum of 3000 characters and it will be published here. </p>
         

   </div>
 
      <div id="editParticipantScreen"  class="horizentalblock2"   runat="server">   
         
        <h2> 
           <asp:TextBox ID="ProjectTitle"   CssClass ="textbox" runat="server" Width="800px"></asp:TextBox><br />
        </h2>
         <h2> 
           <asp:TextBox ID="ProjectAuthor"   CssClass ="textbox" runat="server" Width="800px"></asp:TextBox><br />
        </h2>
       <h2>
           <asp:TextBox ID="ProjectExcerptShort"   CssClass ="textbox" runat="server" Width="800px" Height="67px" TextMode="MultiLine"></asp:TextBox>
        </h2>
        <h2>
           <asp:TextBox ID="ProjectExcerpt"    CssClass ="textbox" runat="server" Width="800px" Height="519px" TextMode="MultiLine"></asp:TextBox>         
        </h2>
 
       
         <asp:Button ID="CancelButton" Cssclass="button"  runat="server" Text="cancel" OnClick ="CancelButton_Click"    />
        
     </div>
     
     <div id="EditButtonDiv"     runat="server">   
  
              <h2>
              <asp:Button ID="NewExcerptButton" runat="server" Cssclass="button" OnClick="NewExcerptButton_Click" Text="new excerpt" />
              <asp:Button ID="UpdateExcerptButton" runat="server" Cssclass="button" OnClick="UpdateExcerptButton_Click" Text="update" />
              <asp:Button ID="RemoveExcerptButton" runat="server" Cssclass="button" OnClick="RemoveExcerptButton_Click" Text="remove" />
              </h2>

     </div>  

     <div id="projectBlock" class="horizentalblock2"   runat="server"   >

         

        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
              SelectCommand="SElECT excerptid, title, excerptshort, excerpt, author FROM excerpts  " >
                     
                    
        </asp:SqlDataSource>
        
      
        <h1> Projects</h1>
          
        <center>
        <asp:DataList ID="ProjectList" runat="server" DataSourceID="SqlDataSource"
          BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
          CellPadding="4"    
          Width="1040px" Height="0px" GridLines="Horizontal" 
          OnEditCommand="Edit_Command"
         >
 

          <ItemTemplate>      
            <div  class="datalabels" > 
              <p>
                <asp:Button  Cssclass="databutton"  id="EditButton" runat="server" CommandName="Edit" Text='<%# Eval("title") %>' commandargument=   '<%# Eval("excerptid") %>' />
              </p>
              <p>
                <asp:Label ID="AuthorLabel" Cssclass="datalabel" runat="server" Text='<%# Eval("author") %>'      />
             </p>
              <p>
                <asp:Label ID="ProjectDescriptionLabel" Cssclass="datalabel" runat="server" Text='<%# Eval("excerptshort") %>'      />
             </p>
            

            </div>
          </ItemTemplate>
           

        </asp:DataList>
        </center>


        
     </div>
      
</asp:Content>
