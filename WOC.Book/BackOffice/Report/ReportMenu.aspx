<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportMenu.aspx.cs" Inherits="WOC.Book.Report.ReportMenu" MasterPageFile ="~/Report/Report.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Reports
    </h2>
    <center>
    <table style="width:90%" border="0px" >
        <tr>
            <td align="center"><a href="StatementOfAccount.aspx"><img alt="" src="../Images/MenuIcons/statementofaccount.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="SalesReportByCustomer.aspx"><img alt="" src="../Images/MenuIcons/salesreport_128.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="SubconReport.aspx"><img alt="" src="../Images/MenuIcons/subconreport_256.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
        </tr>
        <tr>
            <td align="center">Statement Of Account</td>
            <td align="center">Sales Report</td>
            <td align="center">Subcon Report</td>
        </tr>
    </table>
    </center>
</asp:Content>