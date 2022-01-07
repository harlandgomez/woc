<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperationMenu.aspx.cs" Inherits="WOC.Book.Operation.OperationMenu" MasterPageFile ="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Operation
    </h2>
    <center>
    <table style="width:80%; height:100%" border="0px">
        <tr>
            <td align="center"><a href="DailyTrips.aspx"><img alt="" src="../Images/MenuIcons/dailytrips.png" height="180px" width="180px" border="0px" class="menuImage" /></a></td>
            <td align="center"><a href="AgentReport.aspx"><img alt="" src="../Images/MenuIcons/administrator_star_256.png" height="180px" width="180px" border="0px" class="menuImage" /></a></td>
            <td align="center"><a href="DriverBusStatus.aspx"><img alt="" src="../Images/MenuIcons/busanddriver.png" height="180px" width="180px" border="0px" class="menuImage"   /></a></td>
        </tr>
        <tr>
            <td align="center">Daily Trips</td>
            <td align="center" >Agent Report</td>
            <td align="center" >Bus And Driver</td>
        </tr>
    </table>
    </center>
</asp:Content>
