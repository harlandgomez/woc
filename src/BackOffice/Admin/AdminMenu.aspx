<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="WOC.Book.Admin.AdminMenu" MasterPageFile="~/Admin/Admin.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Admin
    </h2>
    <center>
    <table style="width:90%" border="0px" >
        <tr>
            <td align="center"><a href="Staff.aspx"><img alt="" src="../Images/MenuIcons/access_level_128.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="Setting.aspx"><img alt="" src="../Images/MenuIcons/setting_128.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="EmailTemplate.aspx"><img alt="" src="../Images/MenuIcons/email_template_256.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
        </tr>
        <tr>
            <td align="center">Access Level</td>
            <td align="center">Settings</td>
            <td align="center">Email Template</td>
        </tr>
    </table>
    </center>
</asp:Content>