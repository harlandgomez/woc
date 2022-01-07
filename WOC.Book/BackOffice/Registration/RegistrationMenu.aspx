<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationMenu.aspx.cs" Inherits="WOC.Book.Registration.RegistrationMenu" MasterPageFile ="~/Registration/Registration.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Registration
    </h2>
    <center>
    <table style="width:90%" border="0px">
        <tr>
            <td align="center"><a href="Company.aspx"><img alt="" src="../Images/MenuIcons/group_256.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="Driver.aspx"><img alt="" src="../Images/MenuIcons/driver.png" height="180px" width="180px"  border="0" class="menuImage" /></a></td>
            <td align="center"><a href="Bus.aspx"><img alt="" src="../Images/MenuIcons/RegistrationBus.png" height="180px" width="180px"  border="0" class="menuImage" /></a></td>
        </tr>
        <tr>
            <td align="center">Company</td>
            <td align="center">Driver</td>
            <td align="center">Bus</td>
        </tr>
         <tr>
            <td align="center"><a href="Agent.aspx"><img alt="" src="../Images/MenuIcons/administrator_256.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="Subcon.aspx"><img alt="" src="../Images/MenuIcons/user_accounts_256.png" height="180px" width="180px"  border="0" class="menuImage" /></a></td>
            <td align="center">&nbsp;</td>
        </tr>
        <tr>
            <td align="center">Agent</td>
            <td align="center">Subcon</td>
            <td align="center">&nbsp;</td>
        </tr>
    </table>
    </center>
</asp:Content>