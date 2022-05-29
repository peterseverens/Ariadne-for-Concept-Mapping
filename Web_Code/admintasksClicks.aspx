<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="admintasksClicks.aspx.cs" Inherits="_OptionsClicks" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>ARIADNE ADMINISTRATOR CUBICLE!
    </h2>


    
    <h1>Number of Users Online :
        <asp:Label ID="UsersOnlineLabel" runat="Server" />
    </h1>
          <asp:Button ID="Button1" CssClass="button" runat="server" Text="download click data" OnClick="getclicks_Click"></asp:Button>
    

    <div class="midblock">

       
        <h1>existing users</h1>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
            SelectCommand="select visitid, opendate , ip, username, organiser, useronly, pagevisited, username_name, project_name, organizer_name FROM usage WHERE username != 'peter33' ORDER BY opendate"></asp:SqlDataSource>

        

        <br />
        <asp:Panel ID="NavigationPanel" Visible="false" runat="server">
            <table border="0" cellpadding="3" cellspacing="3" >
                <tr>
                    <td style="width: 100">Page
                        <asp:Label ID="CurrentPageLabel" runat="server" Font-Size="11px"/>
                        of
                        <asp:Label ID="TotalPagesLabel" runat="server" Font-Size="11px"/></td>
                    <td style="width: 60">
                        <asp:LinkButton ID="PreviousButton" Text="< Prev"
                            OnClick="PreviousButton_OnClick" runat="server" Font-Size="11px" /></td>
                    <td style="width: 60">
                        <asp:LinkButton ID="NextButton" Text="Next >"
                            OnClick="NextButton_OnClick" runat="server"  Font-Size="11px"/></td>
                </tr>
            </table>
        </asp:Panel>

        <asp:DataGrid ID="UserGrid" runat="server"
            CellPadding="2" CellSpacing="1" Font-Size="11px"
            GridLines="Both">
            <HeaderStyle BackColor="darkblue" ForeColor="white" />
        </asp:DataGrid>



        <br />
        <br />


        <h1>Active Users&nbsp;
        </h1>

        <center> 
         <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2" 
               Width="100%" Height="50px" GridLines="Horizontal"                   
               BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
               CellPadding="4" 
               OnDeleteCommand="RemoveVisit_Command"
  
                  >
            <ItemTemplate >    
               <div  class="datalabels" >  
                   <asp:Button id="removevisit" runat="server" Cssclass="databutton"    CommandName="Delete" Text=' x '     CommandArgument =   '<%# Eval("visitid") %>'   /> 
                    <asp:label id="LL0" runat="server" Width="10%" Text='<%#   Eval("pagevisited" )   %>' /> 
                  <asp:label id="ll1" runat="server" Width="10%" Text='<%#   Eval("opendate" )   %>' /> 
                  <asp:label id="ll2" runat="server" Width="10%" Text='<%#   Eval("ip" )   %>' /> 
                  <asp:label id="ll3" runat="server" Width="10%" Text='<%#   Eval("username")   %>' /> 
                   <asp:label id="ll4" runat="server" Width="10%" Text='<%#   Eval("organiser")   %>' /> 
                   <asp:label id="ll5" runat="server" Width="10%" Text='<%#   Eval("useronly")   %>' /> 
                      <asp:label id="Label1" runat="server" Width="10%" Text='<%#   Eval("username_name")   %>' /> 
                      <asp:label id="Label2" runat="server" Width="15%" Text='<%#   Eval("project_name")   %>' /> 
                      <asp:label id="Label3" runat="server" Width="10%" Text='<%#   Eval("organizer_name")   %>' /> 
                </div  >
            </ItemTemplate>
   
        </asp:DataList> 
       </center>


    </div>










    </div>

</asp:Content>
