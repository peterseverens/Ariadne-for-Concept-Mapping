<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="participate.aspx.cs" Inherits="_Participate" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <meta http-equiv="cache-control" content="no-cache" />

    <meta http-equiv="pragma" content="no-cache" />

    <meta http-equiv="expires" content="-1" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:TextBox ID="TextBoxProject" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="TextBoxParticipant" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="usernameInfo"   Visible="False" runat="server"></asp:TextBox>
    <asp:TextBox ID="passnameInfo"   Visible="False" runat="server"></asp:TextBox>

    <div id="PartBlock" class="horizentalblock2" runat="server">
        <center>
        
         <
          <h1>
               Welcome to Minds21
          </h1>
          <h1> 
             <asp:Label ID="usernameLabel" runat="server" Text="No User"></asp:Label>
          </h1>
          <h2> </h2>
          <h2>To participate click first on the first button, then on the second etc. Please carefully read the instructions provided. </h2>
             

          <p> <asp:Button ID="ImageButtonRate" CssClass="userbutton" runat="server"   text="Importance"  onclick="ImageButtonRate_Click"  ></asp:Button> </p>
          <p> <asp:Button ID="ImageButtonRate2" CssClass="userbutton" runat="server"   text="not yet defined"  onclick="ImageButtonRate2_Click"  ></asp:Button> </p>
          <p> <asp:Button ID="ImageButtonRate3" CssClass="userbutton" runat="server"   text="not yet defined"  onclick="ImageButtonRate3_Click"  ></asp:Button> </p>
          <p> <asp:Button ID="ImageButtonRate4" CssClass="userbutton" runat="server"   text="not yet defined"  onclick="ImageButtonRate4_Click"  ></asp:Button> </p>
          <p> <asp:Button ID="ImageButtonRate5" CssClass="userbutton" runat="server"   text="not yet defined"  onclick="ImageButtonRate5_Click"  ></asp:Button> </p>
          <p> <asp:Button ID="ImageButtonSort" CssClass="userbutton" runat="server"   text="clustering"  onclick="ImageButtonSort_Click"  ></asp:Button> </p>
          
          
      </center>
    </div>
    

</asp:Content>
