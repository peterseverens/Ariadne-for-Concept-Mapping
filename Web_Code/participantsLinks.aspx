<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="participantsLinks.aspx.cs" Inherits="_Participants" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <div id="Div2" class="horizentalblock2" runat="server">

        <h2>ARIADNE LINKS FOR PROJECT PARTICIPANTS  </h2>
        <p>On this page you find the participants URL links to the sort and rating task. You can add the link (URL) for a participant to an email to that participant.  </p>
        <p>When a participant clicks on the provided link he will log in to minds21.com and he will be shown his rate and sort task.</p>

    </div>


    <div id="PartBlock" class="horizentalblock2" runat="server">

        <asp:LinkButton ID="LinkButton" runat="server">click on ''URL'' get the URL to a participants page</asp:LinkButton>

    </div>




    <div id="Div1" class="horizentalblock2" runat="server">


        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:platformDB3 %>"
            SelectCommand="SELECT participant.Firstname, participant.Lastname,   participant.participantId, participant.username, participant.passname 
            FROM participant INNER JOIN LinkProjectParticipant ON participant.participantId = LinkProjectParticipant.participantid WHERE LinkProjectParticipant.projectId = @ProjectId
            order by participant.created"
            OnSelecting="participant_Selecting">
            <SelectParameters>
                <asp:Parameter Name="ProjectId" />
                <asp:Parameter Name="start" />
                <asp:Parameter Name="end" />

            </SelectParameters>

        </asp:SqlDataSource>


        <h1>project participants&nbsp;
        </h1>
        <br />

        <asp:DataList ID="participantlist" runat="server" DataSourceID="SqlDataSource2"
            BackColor="White"
            CellPadding="4" BorderStyle="None"
            Width="80%" Height="56px" GridLines="Horizontal" HorizontalAlign="Center"
            OnEditCommand="toParticipantPage_Command"
            OnDeleteCommand="ShowSortParticipant_Command"         
            OnCancelCommand="ShowRateParticipant_Command">
            
            <ItemTemplate>

                <asp:Button CssClass="databutton" ID="Button5" runat="server" CommandName="Edit" Text='URL' CommandArgument='<%# Eval("participantId") + "" + Eval("username" )  + ";" +   Eval("passname") %>' Width="40px" />
                <asp:Label CssClass="datalabels" ID="EditParticipantButton" runat="server" Text='<%#    Eval("Firstname" )  + " " +   Eval("Lastname") %>' Width="48%" />
                <asp:Button CssClass="databutton" ID="Button3" runat="server" CommandName="Delete" Text='sort results' CommandArgument='<%# Eval("participantId") %>'  />
                <asp:Button CssClass="databutton" ID="Button4" runat="server" CommandName="Cancel" Text='rate I  ' CommandArgument='<%# "1" +Eval("participantId") %>'   />
                <asp:Button CssClass="databutton" ID="Button1" runat="server" CommandName="Cancel" Text='rate II ' CommandArgument='<%# "2" +Eval("participantId") %>'   />
                <asp:Button CssClass="databutton" ID="Button2" runat="server" CommandName="Cancel" Text='rate III' CommandArgument='<%# "3" +Eval("participantId") %>'   />
                <asp:Button CssClass="databutton" ID="Button6" runat="server" CommandName="Cancel" Text='rate VI ' CommandArgument='<%# "4" +Eval("participantId") %>'   />
                <asp:Button CssClass="databutton" ID="Button7" runat="server" CommandName="Cancel" Text='rate V  ' CommandArgument='<%# "5" + Eval("participantId") %>'   />

            </ItemTemplate>

        </asp:DataList>
     
         <p>

           <asp:Button ID="BuildEmails" class="button" runat="server" Text="Build Email File" OnClick="BuildEmails_Click" />

        </p>
    </div>







</asp:Content>
