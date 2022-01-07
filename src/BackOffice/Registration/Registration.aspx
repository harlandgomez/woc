<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WOC.Book.Registration" MasterPageFile ="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Registration
    </h2>
    <table style="width:90%" border="0px">
        <tr>
            <td><a href="Company.aspx"><img alt="" src="Images/MenuIcons/group_add_256.png" height="200px" width="200px" border="0" /></a></td>
            <td><a href="Driver.aspx"><img alt="" src="Images/MenuIcons/puzzle_256.png" height="200px" width="200px"  border="0" /></a></td>
            <td><a href="Bus.aspx"><img alt="" src="Images/MenuIcons/secure_search_256.png" height="200px" width="200px"  border="0" /></a></td>
            <td><a href="Subcon.aspx"><img alt="" src="Images/MenuIcons/rar_reload.png" height="200px" width="200px"  border="0" /></a></td>
        </tr>
        <tr>
            <td align="center">Company</td>
            <td align="center">Driver</td>
            <td align="center">Bus</td>
            <td align="center">Subcon</td>
        </tr>
    </table>
  
</asp:Content>