<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="organise.aspx.cs" Inherits="_organizer" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="Div3" class="horizentalblock2" runat="server" style="text-align: center">
    organiser:<asp:Label ID="TextBoxOrganiser" runat="server" BorderStyle="None" Visible="True"></asp:Label>
    project:<asp:Label ID="TextBoxProject" runat="server" BorderStyle="None" Visible="True"></asp:Label>
    item:<asp:Label ID="TextBoxItem" runat="server" BorderStyle="None" Visible="True"></asp:Label>
    participant:<asp:Label ID="TextBoxParticipant" runat="server" BorderStyle="None" Visible="True"></asp:Label>
          </div>
    <asp:CheckBox ID="ParticipantsOrItems" runat="server" Visible="False" />
       
    <div id="DeletePopup" class="deletepopup" runat="server" style="text-align: center">

        <p>You will lose all projectdata  </p>
        <p>Are you sure?</p>
        <asp:Button ID="YesGiveDeletePermissionButtonProject" CssClass="button" runat="server" OnClick="YesGiveDeletePermissionProject_Click" Text="Yes" />
        <asp:Button ID="YesGiveDeletePermissionButtonItem" CssClass="button" runat="server" OnClick="YesGiveDeletePermissionItem_Click" Text="Yes" />
        <asp:Button ID="YesGiveDeletePermissionButtonParticipant" CssClass="button" runat="server" OnClick="YesGiveDeletePermissionParticipant_Click" Text="Yes" />

        <asp:Button ID="NoGiveDeletePermissionButton" CssClass="button" runat="server" OnClick="NoGiveDeletePermission_Click" Text="No" />

    </div>

    <div id="Div2" class="horizentalblock2" runat="server" style="text-align: center">
        <h1>ARIADNE PROJECT organizer CUBICLE  </h1>

        <p>On this page you find everything to organise your Ariadne meeting. You plan it, define items, register participants and invite them by email.  </p>

    </div>


    <div id="Div1" class="horizentalblock2" runat="server" style="text-align: center">
        <p>
            <asp:Button ID="CancelProjectButton" CssClass="button" runat="server" Text="<< Back to projects <<" OnClick="CancelProjectButton_Click" />
            <asp:Label ID="ProjectLabel" runat="server" Text="No Active Project"></asp:Label>
            <asp:Button ID="EditProject" CssClass="button" runat="server" Text="Edit name & description" OnClick="EditProjectButton_Click" />

        </p>
        <p>
            <asp:Label ID="LockLabel" CssClass="warninglabel" runat="server" Text="LOCK ITEMS BEFORE STARTING A PROJECT" />
        </p>
        <p>
            <asp:Button ID="SwitchView" CssClass="button" runat="server" Text="Show Items" OnClick="SwitchView_Click" />
            <asp:Button ID="LockButton" CssClass="button" runat="server" Text="lock items in this project" OnClick="LockButton_Click" />

        </p>
    </div>





    <div id="editProjectScreen" class="horizentalblock2" runat="server">

        <h2>Name to identify the project and description<br />
            <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server" Width="20%" placeholder="project name"></asp:TextBox>
            <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server" Width="40%" placeholder="project description"></asp:TextBox>
        </h2>
        <h2>Rate Definitions and categories<br />
        </h2>
        <h2>
            <asp:TextBox ID="RateTextBox1" CssClass="textbox" runat="server" Width="20%" placeholder="rate definition 1"></asp:TextBox>
            <asp:TextBox ID="RateTextBox11" CssClass="textbox" runat="server" Width="15%" placeholder="category 1"></asp:TextBox>
            <asp:TextBox ID="RateTextBox12" CssClass="textbox" runat="server" Width="15%" placeholder="category 2"></asp:TextBox>
            <asp:TextBox ID="RateTextBox13" CssClass="textbox" runat="server" Width="15%" placeholder="category 3"></asp:TextBox>
            <asp:TextBox ID="RateTextBox14" CssClass="textbox" runat="server" Width="15%" placeholder="category 4"></asp:TextBox>
            <asp:TextBox ID="RateTextBox15" CssClass="textbox" runat="server" Width="15%" placeholder="category 5"></asp:TextBox>
        </h2>
        <h2>
            <asp:TextBox ID="RateTextBox2" CssClass="textbox" runat="server" Width="20%" placeholder="rate definition 2"></asp:TextBox>
            <asp:TextBox ID="RateTextBox21" CssClass="textbox" runat="server" Width="15%" placeholder="category 1"></asp:TextBox>
            <asp:TextBox ID="RateTextBox22" CssClass="textbox" runat="server" Width="15%" placeholder="category 2"></asp:TextBox>
            <asp:TextBox ID="RateTextBox23" CssClass="textbox" runat="server" Width="15%" placeholder="category 3"></asp:TextBox>
            <asp:TextBox ID="RateTextBox24" CssClass="textbox" runat="server" Width="15%" placeholder="category 4"></asp:TextBox>
            <asp:TextBox ID="RateTextBox25" CssClass="textbox" runat="server" Width="15%" placeholder="category 5"></asp:TextBox>
        </h2>
        <h2>
            <asp:TextBox ID="RateTextBox3" CssClass="textbox" runat="server" Width="20%" placeholder="rate definition 3"></asp:TextBox>
            <asp:TextBox ID="RateTextBox31" CssClass="textbox" runat="server" Width="15%" placeholder="category 1"></asp:TextBox>
            <asp:TextBox ID="RateTextBox32" CssClass="textbox" runat="server" Width="15%" placeholder="category 2"></asp:TextBox>
            <asp:TextBox ID="RateTextBox33" CssClass="textbox" runat="server" Width="15%" placeholder="category 3"></asp:TextBox>
            <asp:TextBox ID="RateTextBox34" CssClass="textbox" runat="server" Width="15%" placeholder="category 4"></asp:TextBox>
            <asp:TextBox ID="RateTextBox35" CssClass="textbox" runat="server" Width="15%" placeholder="category 5"></asp:TextBox>
        </h2>
        <h2>
            <asp:TextBox ID="RateTextBox4" CssClass="textbox" runat="server" Width="20%" placeholder="rate definition 4"></asp:TextBox>
            <asp:TextBox ID="RateTextBox41" CssClass="textbox" runat="server" Width="15%" placeholder="category 1"></asp:TextBox>
            <asp:TextBox ID="RateTextBox42" CssClass="textbox" runat="server" Width="15%" placeholder="category 2"></asp:TextBox>
            <asp:TextBox ID="RateTextBox43" CssClass="textbox" runat="server" Width="15%" placeholder="category 3"></asp:TextBox>
            <asp:TextBox ID="RateTextBox44" CssClass="textbox" runat="server" Width="15%" placeholder="category 4"></asp:TextBox>
            <asp:TextBox ID="RateTextBox45" CssClass="textbox" runat="server" Width="15%" placeholder="category 5"></asp:TextBox>
        </h2>
        <h2>
            <asp:TextBox ID="RateTextBox5" CssClass="textbox" runat="server" Width="20%" placeholder="rate definition 5"></asp:TextBox>
            <asp:TextBox ID="RateTextBox51" CssClass="textbox" runat="server" Width="15%" placeholder="category 1"></asp:TextBox>
            <asp:TextBox ID="RateTextBox52" CssClass="textbox" runat="server" Width="15%" placeholder="category 2"></asp:TextBox>
            <asp:TextBox ID="RateTextBox53" CssClass="textbox" runat="server" Width="15%" placeholder="category 3"></asp:TextBox>
            <asp:TextBox ID="RateTextBox54" CssClass="textbox" runat="server" Width="15%" placeholder="category 4"></asp:TextBox>
            <asp:TextBox ID="RateTextBox55" CssClass="textbox" runat="server" Width="15%" placeholder="category 5"></asp:TextBox>
        </h2>

        <!--...
             <asp:Panel ID="Panel1" runat="server"  Width="200px"    HorizontalAlign="Left"  BorderWidth="1" BorderStyle="Solid">
                items
                <asp:RadioButtonList ID="RadioButtonList2"   ToolTip="You can choose wether you want an " runat="server" Font-Size="X-Small" Width="208px">
                   <asp:ListItem>use existing items</asp:ListItem>
                   <asp:ListItem>define items groupswise</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                session 
                <asp:RadioButtonList ID="RadioButtonList1"  ToolTip="You can choose wether you want an " runat="server" Font-Size="X-Small" Width="208px">
                  <asp:ListItem>define items in a session on location</asp:ListItem>
                  <asp:ListItem>define items in a session on internet</asp:ListItem>           
                </asp:RadioButtonList>
                <br /> 
                session content
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" Width="208px" Font-Size="X-Small">
                  <asp:ListItem>score (and select) items on relevance before grouping</asp:ListItem>
                  <asp:ListItem>group items into clusters</asp:ListItem>
                  <asp:ListItem Value="score items on importance">score items on importance</asp:ListItem>
                  <asp:ListItem>discuss map groupwise</asp:ListItem>
               </asp:CheckBoxList>
            </asp:Panel>
              -->
         <h2>
        maximum number of item to show to repsondents:&nbsp; <asp:TextBox ID="MaxItemNTextBox" CssClass="textbox" runat="server" Width="15%" placeholder="100"></asp:TextBox> &nbsp;(items will be randomly selected)
         </h2>

        <asp:Button ID="AddProjectButton" CssClass="button" runat="server" Text="Add project" OnClick="AddProjectButton_Click" />
        <asp:Button ID="CancelEditProjectButton" CssClass="button" runat="server" Text="Cancel" OnClick="CancelEditProjectButton_Click" />





    </div>


    <div id="projectBlock" class="horizentalblock2" runat="server">

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
            SelectCommand="SELECT projects.projectID, projects.projectName, projects.projectDescription, projects.organizerID FROM projects  WHERE projects.organizerId=@ownerid ORDER BY created"
            OnSelecting="project_Selecting">
            <SelectParameters>
                <asp:Parameter Name="ownerid" />
            </SelectParameters>

        </asp:SqlDataSource>



        <asp:Button ID="NewProjectButton" CssClass="button" runat="server" Text="Start a new project" OnClick="NewProjectButton_Click" />
        <h1>Existing Projects</h1>
        <br />

        <asp:DataList ID="ProjectList" runat="server" DataSourceID="SqlDataSource1"
            BackColor="White"
            CellPadding="4" BorderStyle ="None"
            Width="85%" Height="56px" GridLines="Horizontal" HorizontalAlign="Center"
            OnEditCommand="Edit_Command"
            OnDeleteCommand="Delete_Command"
            OnUpdateCommand="ShowConceptMap_Command"
            OnCancelCommand="ShowParticipantsLinks_Command">

            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />


            <ItemTemplate>

                <asp:Label CssClass="datalabels" ID="ProjectnameLabel" runat="server" Text='<%# Eval("projectname") %>' Width="25%" />
                <asp:Label CssClass="datalabels" ID="ProjectDescriptionLabel" runat="server" Text='<%# Eval("ProjectDescription") %>' Width="25%" />

                <asp:Button CssClass="databutton" ID="EditButton" runat="server" CommandName="Edit" Text='edit' CommandArgument='<%# Eval("ProjectId") %>'  />
                <asp:Button CssClass="databutton" ID="Button3" runat="server" CommandName="Update" Text='Concept Map' CommandArgument='<%# Eval("projectId") %>'  />
                <asp:Button CssClass="databutton" ID="Button20" runat="server" CommandName="Cancel" Text='Participant Links' CommandArgument='<%# Eval("projectId") %>'   />
                <asp:Button CssClass="databutton" ID="Button18" runat="server" CommandName="Delete" Text='remove' CommandArgument='<%# Eval("projectId") %>'   />


            </ItemTemplate>


        </asp:DataList>


        <br />
        <br />
        <asp:Button ID="ButtonBackup" runat="server" CssClass="button" Font-Size="12px" OnClick="ALLBackupButton_click" Text="backups" />



    </div>



    <div runat="server">





        <div id="editParticipantScreen" class="horizentalblock2" runat="server">


            <h1>Project Particpant </h1>
            <h2>Name, Organisation and Email</h2>
            <h2>
                <asp:TextBox ID="Pfirstname" CssClass="textbox" runat="server" Width="200px" placeholder="first name"></asp:TextBox><br />
                <asp:TextBox ID="Plastname" CssClass="textbox" runat="server" Width="200px" placeholder="surname"></asp:TextBox><br />

                <asp:TextBox ID="Porganisation" CssClass="textbox" runat="server" Width="200px" placeholder="organisation"></asp:TextBox><br />
                <asp:TextBox ID="Pemail" CssClass="textbox" runat="server" Width="200px" placeholder="email"></asp:TextBox><br />
            </h2>
            <h2>Reporting Variables</h2>
            <h2>
                <asp:TextBox ID="Pfunction" CssClass="textbox" runat="server" Width="240px" placeholder="function/duty"></asp:TextBox> 
                 <asp:Label CssClass="datalabels" ID="Lf" runat="server" Text='max 40 characters, max 10 functions' Width="26%" />
                <br />
                <asp:TextBox ID="pvar1" CssClass="textbox" runat="server" Width="240px" placeholder="characteristic 1"></asp:TextBox>
                  <asp:Label CssClass="datalabels" ID="Label1" runat="server" Text='max 40 characters, max 10 categories' Width="26%" />
                <br />
                <asp:TextBox ID="pvar2" CssClass="textbox" runat="server" Width="240px" placeholder="characteristic 2"></asp:TextBox>
                  <asp:Label CssClass="datalabels" ID="Label2" runat="server" Text='max 40 characters, max 10 categories' Width="26%" />
                <br />
                <asp:TextBox ID="pvar3" CssClass="textbox" runat="server" Width="240px" placeholder="characteristic 3"></asp:TextBox>
                  <asp:Label CssClass="datalabels" ID="Label3" runat="server" Text='max 40 characters, max 10 categories' Width="26%" />
                <br />
                <asp:TextBox ID="pvar4" CssClass="textbox" runat="server" Width="240px" placeholder="characteristic 4"></asp:TextBox>
                  <asp:Label CssClass="datalabels" ID="Label4" runat="server" Text='max 40 characters, max 10 categories' Width="26%" />
                <br />
                <asp:TextBox ID="pvar5" CssClass="textbox" runat="server" Width="240px" placeholder="characteristic 5"></asp:TextBox>
                  <asp:Label CssClass="datalabels" ID="Label5" runat="server" Text='max 40 characters, max 10 categories' Width="26%" />
                <br />

            </h2>


            <asp:Button ID="AddProjectParticipantButton" CssClass="button" runat="server" OnClick="addnewprojectparticipantbutton_Click" Text="Add Participant" />
            <asp:Button ID="CancelProjectParticipantButton" CssClass="button" runat="server" Text="Cancel" OnClick="CancelProjectParticipantButton_Click" />


        </div>




        <div id="ParticipantBlock" class="horizentalblock2" runat="server">

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
                SelectCommand="SELECT participant.Firstname, participant.Lastname, participant.Email, participant.participantId, participant.Jobfunction, participant.Organisation FROM participant INNER JOIN LinkProjectParticipant ON participant.participantId = LinkProjectParticipant.participantid WHERE LinkProjectParticipant.projectId = @ProjectId"
                OnSelecting="participant_Selecting">
                <SelectParameters>
                    <asp:Parameter Name="ProjectId" />
                    <asp:Parameter Name="start" />
                    <asp:Parameter Name="end" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:Button ID="NewProjectParticipantButton" CssClass="button" runat="server" OnClick="NewProjectParticipantButton_Click" Text="New Participant" />
            <h1>Existing project participants;
            </h1>
             <br />
            <asp:DataList ID="participantlist" runat="server" DataSourceID="SqlDataSource2"
                BackColor="White"
                CellPadding="4" BorderStyle ="None"
                Width="80%" Height="56px" GridLines="Horizontal" HorizontalAlign="Center"
                OnEditCommand="EditParticipant_Command"
                OnDeleteCommand="RemoveProjectParticipant_Command">
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />

                <ItemTemplate>

                    <asp:Label CssClass="datalabels" ID="Lf" runat="server" Text='<%#  Eval("Firstname" ) %>' Width="16%" />
                    <asp:Label CssClass="datalabels" ID="Ll" runat="server" Text='<%#  Eval("Lastname")   %>' Width="16%" />
                    <asp:Label CssClass="datalabels" ID="Lfu" runat="server" Text='<%#  Eval("Jobfunction")   %>' Width="16%" />
                    <asp:Label CssClass="datalabels" ID="Lc" runat="server" Text='<%#  Eval("Organisation")   %>' Width="16%" />
                    <asp:Label CssClass="datalabels" ID="Le" runat="server" Text='<%#  Eval("Email")   %>' Width="16%" />
                    <asp:Button CssClass="databutton" ID="EditParticipantButton" runat="server" CommandName="Edit" Text='edit' CommandArgument='<%# Eval("participantId") %>'   />
                    <asp:Button CssClass="databutton" ID="Button19" runat="server" CommandName="Delete" Text='remove' CommandArgument='<%# Eval("participantId") %>' />

                </ItemTemplate>

            </asp:DataList>

           

            <!--
        <div  style="visibility: hidden"> 
       
         <asp:SqlDataSource  ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
               SelectCommand="WITH MyDerivedTable AS (select ROW_NUMBER() OVER (ORDER BY Participant.created  ) AS RowNum,LinkProjectParticipant.participantid from participant, LinkProjectParticipant
where (LinkProjectParticipant.projectId !=  @ProjectId) and (participant.participantId = LinkProjectParticipant.participantid))
select  participant.Firstname, participant.Lastname, participant.participantId,MyDerivedTable.RowNum from LinkProjectParticipant, participant, MyDerivedTable
Where  (participant.participantId = LinkProjectParticipant.participantid) and
       (LinkProjectParticipant.participantid = MyDerivedTable.participantid) and
       (MyDerivedTable.RowNum between @start and @end)
order by participant.created"
                OnSelecting="all_participant_Selecting" >
               <SelectParameters>
                   <asp:Parameter Name="ProjectId" />
                        <asp:Parameter Name="start" />
                      <asp:Parameter Name="end" />
               </SelectParameters>
           </asp:SqlDataSource>
           <h1>projects participants</h1>  
           <asp:DataList ID="otherparticipantlist" runat="server"    DataSourceID="SqlDataSource3" 
               Width="304px"   GridLines="Horizontal"                   
               BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
               CellPadding="4" 
               OnEditCommand="addexistingparticipanttoCurrentproject_Command"  >
            <ItemTemplate>
              <div  style="background-color: #FFFFCC">  
                <asp:Button id="EditParticipantButton" runat="server" CommandName="Edit"  Text='<%#   Eval("Firstname" ) + " " +   Eval("Lastname")   %>'  commandargument=   '<%# Eval("participantid") %>'
                  style="background-color: #FFFFCC" Font-Size="12px" Height="16px" Width="280px" BorderStyle="None" />
              </div>
            </ItemTemplate>
        </asp:DataList>

        <asp:Button ID="Button14" class="button"  runat="server" Text="<<" OnClick="ShowFirstPO" Font-Size="12px" Width="30px"  />
        <asp:Button ID="Button15" class="button"  runat="server" Text="<" OnClick="ShowPreviousPO" Font-Size="12px" Width="20px"  />
        <asp:Button ID="Button16" class="button"  runat="server" Text=">" OnClick="ShowNextPO" Font-Size="12px" Width="20px"  />
        <asp:Button ID="Button17" class="button"  runat="server" Text=">>" OnClick="ShowLastPO" Font-Size="12px" Width="30px"  />
      </div> 
        ...-->

        </div>

    </div>


    <div>
        <div id="editItemScreen" class="horizentalblock2" runat="server">

            <h1>Project Item</h1>

            <h2>item<br />
                <asp:TextBox ID="ItemText" CssClass="textbox" runat="server" Height="50px" Width="373px" TextMode="MultiLine"></asp:TextBox>
                <br />
            </h2>


            <asp:Button ID="AddProjectItemButton" CssClass="button" runat="server" OnClick="addProjectItem_Click" Text="Add Item" />
            <asp:Button ID="CancelProjectItemButton" CssClass="button" runat="server" Text="Cancel" OnClick="CancelProjectItemButton_Click" />
            <br />

            <h2>
                <br />
                <asp:Label ID="ItemNText" runat="server" Height="50px" Width="373px" TextMode="MultiLine" ForeColor="#FF3300" Font-Size="Large" BorderStyle="None"></asp:Label>
                <br />
            </h2>
        </div>
        <div id="ItemBlock" class="horizentalblock2" runat="server" style="font-size: 12pt">

            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
                SelectCommand="SELECT itemId, itemtext FROM items WHERE projectId=@ProjectId"
                OnSelecting="all_items_Selecting">
                <SelectParameters>
                    <asp:Parameter Name="ProjectId" />
                    <asp:Parameter Name="start" />
                    <asp:Parameter Name="end" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:Button ID="NewProjectItemButton" CssClass="button" runat="server" OnClick="NewProjectItem_Click" Text="New Item" />
            <h1>Existing project items
            </h1>
             <br />
            <asp:DataList ID="itemlist" runat="server" DataSourceID="SqlDataSource4"
                BackColor="White"
                CellPadding="4" BorderStyle ="None"
                Width="80%" Height="56px" GridLines="Horizontal" HorizontalAlign="Center"
                OnEditCommand="EditProjectItem_Command"
                OnDeleteCommand="DeleteProjectItem_Command">
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                <ItemTemplate>
                    <div class="datalabels">
                        <asp:Label ID="Button14" CssClass="datalabels" runat="server" Text='<%#  Eval("itemtext" )    %>' Width="80%" />
                        <asp:Button ID="EditItemButton" CssClass="databutton" runat="server" CommandName="Edit" Text='edit' CommandArgument='<%# Eval("itemid") %>'  />
                        <asp:Button ID="DeleteItemButton" CssClass="databutton" runat="server" CommandName="Delete" Text='remove' CommandArgument='<%# Eval("itemid") %>'   />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>







</asp:Content>
