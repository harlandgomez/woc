<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewBookingMenu.aspx.cs" Inherits="WOC.Book.NewBooking.NewBookingMenu" MasterPageFile ="~/NewBooking/NewBooking.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       New Booking
    </h2>
    <center>
    <table style="width:80%; height:100%" border="0px">
        <tr>
            <td align="center"><a href="Adhoc.aspx"><img alt="" src="../Images/MenuIcons/adhoc_256.png" height="180px" width="180px" border="0"  class="menuImage" /></a></td>
            <td align="center"><a href="Contract.aspx"><img alt="" src="../Images/MenuIcons/contract_256.png" height="180px" width="180px"  border="0"  class="menuImage"/></a></td>
            <td align="center"><a href="EBookingStatus.aspx"><img alt="" src="../Images/MenuIcons/booking_status.png" height="180px" width="180px"  border="0" class="menuImage" /></a></td>
        </tr>
        <tr>
            <td align="center">Adhoc Booking</td>
            <td align="center" >Contract Booking</td>
            <td align="center" >E-Booking Status</td>
        </tr>
    </table>
    </center>
</asp:Content>

