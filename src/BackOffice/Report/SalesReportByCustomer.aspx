<%@ Page Title="" Language="C#" MasterPageFile="~/Report/Report.Master" AutoEventWireup="true" CodeBehind="SalesReportByCustomer.aspx.cs" Inherits="WOC.Book.Report.SalesReportByCustomer" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .style2
        {
            height: 26px;
        }
    </style>
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtDateFrom").datepicker();
            $("#MainContent_txtDateTo").datepicker();
            var search = document.getElementById('MainContent_txtSearch').value;
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompletePrefixCode.ashx" + search);

        });
  </script>
  <div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
   </div>
    <h2>
        SALES REPORT BY CUSTOMER</h2>
        
        <table width="100%" style="margin-right: 0px" id = "tblAgentReport">
            <tr>
                <td>&nbsp;</td>
                <td>
                   
                    
                   
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Prefix:</td>
                <td>
                   
                    
                   
                    <asp:TextBox ID="txtSearch" runat="server" Width="199px"></asp:TextBox>
                   
                    
                   
                </td>
            </tr>
            <tr>
                <td class="style2">Date From:</td>
                <td class="style2">
                    <asp:TextBox ID="txtDateFrom" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>  
             <tr>
                <td>Date To:</td>
                <td>
                    <asp:TextBox ID="txtDateTo" runat="server" Width="200px"></asp:TextBox>
                    
                    <asp:DropDownList ID="ddlPagingNumber" runat="server" AutoPostBack="True" >
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>100</asp:ListItem>
                    <asp:ListItem>200</asp:ListItem>
                    </asp:DropDownList>
                    
                  </td>
                

            </tr>  
             <tr>
                <td class="style1"></td>
                <td class="style1">
                   
                    <asp:CheckBoxList ID="cblPayment" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>Paid</asp:ListItem>
                        <asp:ListItem>Unpaid</asp:ListItem>
                    </asp:CheckBoxList>
                   
                &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>  
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="100px" 
                        Height="26px" onclick="btnSearch_Click1"  />
                    <asp:Button ID="btnPrint" runat="server" Text="Print" 
                        Width="97px" onclick="btnPrint_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gv" runat="server" Width="100%" 
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                            <asp:BoundField DataField="RefNo" HeaderText="Ref No" />
                            <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date"  />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    &nbsp;</td>
            </tr>
        </table>
  
   
</asp:Content>
