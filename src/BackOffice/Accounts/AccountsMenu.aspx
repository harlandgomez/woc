<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsMenu.aspx.cs" Inherits="WOC.Book.Accounts.AccountsMenu"  MasterPageFile ="~/Accounts/Accounts.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Accounts
    </h2>
    <center>
    <table style="width:90%" border="0px">
        <tr>
            <td align="center"><a href="Invoice.aspx"><img alt="" src="../Images/MenuIcons/searchyet_256.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="ReprintInvoice.aspx"><img alt="" src="../Images/MenuIcons/print_256.png" height="180px" width="180px"  border="0" class="menuImage" /></a></td>
            <td align="center"><a href="DebtorSettlement.aspx"><img alt="" src="../Images/MenuIcons/debtor_128.png" height="180px" width="180px"  border="0" class="menuImage" /></a></td>
        </tr>
        <tr>
            <td align="center">Search Yet To Invoice</td>
            <td align="center">Reprint Invoice</td>
            <td align="center">Debtor Settlement</td>
        </tr>
         <tr>
            <td align="center"><a href="CreditNote.aspx"><img alt="" src="../Images/MenuIcons/creditnote_128.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
            <td align="center"><a href="Payroll.aspx"><img alt="" src="../Images/MenuIcons/payroll_256.png" height="180px" width="180px" border="0" class="menuImage" /></a></td>
        </tr>
        <tr>
            <td align="center">Credit Notes</td>
            <td align="center">Payroll</td>
        </tr>
    </table>
    </center>
</asp:Content>