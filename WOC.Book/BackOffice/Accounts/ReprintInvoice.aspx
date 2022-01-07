<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReprintInvoice.aspx.cs" Inherits="WOC.Book.Accounts.ReprintInvoice"  MasterPageFile="~/Accounts/Accounts.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 309px;
        }
        .style4
        {
            width: 125px;
        }
        .style24
        {
            width: 490px;
        }
        .hiddencol
        {
            display:none;
        }
        .viscol
        {
            display:block;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <script language="javascript" type="text/javascript">
      $(document).ready(function () {
          $("#MainContent_txtStartDate").datepicker();
          $("#MainContent_txtEndDate").datepicker();

          // Tabs
          $('#tabs').tabs({
              cookie: {
                  // store cookie for a day, without, it would be a session cookie
                  expires: 1
              }
          });

      });
      function SelectLastTab() {
          $('#tabs').tabs('select', 1); // switch to second tab
          return false;
      }
       </script>
<!-- Begin of Tabs -->
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Reprint Invoice</a></li>
	    <li><a href="#tabs-2">List of Invoice</a></li>
		
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
        <table style="width:100%;">
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="style4">
                    Agent:</td>
                <td class="style24">
                    <asp:ListBox ID="lboAgent" runat="server" Height="100px" Width="300px">
                    </asp:ListBox>
                </td>
                <td class="style2">&nbsp;</td>
                     <td class="style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Invoice No:</td>
                <td class="style24">
                    <asp:DropDownList ID="ddlInvoice" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
                <td class="style2">&nbsp;</td>
                     <td class="style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Start Date:</td>
                <td class="style24">
                    <asp:TextBox ID="txtStartDate" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    End Start:</td>
                     <td class="style2">
                    <asp:TextBox ID="txtEndDate" runat="server" Width="184px"></asp:TextBox>
                         </td>
            </tr>
            <tr>
                <td class="style4">
                   </td>
                <td>&nbsp;</td>
                <td class="style2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        onclick="btnSearch_Click" UseSubmitBehavior="False" />
                </td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
          
        </table>
    </div>
    <!-- End Of First Tab -->
     
    <!-- Second Tab -->
    <div id="tabs-2">
        <table style="width: 100%;" border="0px">
            <tr>
                <td>
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width = "100%" 
                         CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames = "InvoiceID,InvoiceDate"
                        onrowcreated="gv_RowCreated" onrowcommand="gv_RowCommand">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="AgentID" HeaderText="AgentID" />
                            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" />
                            <asp:BoundField DataField="InvoiceDate" HeaderText="Date" />
                            <asp:BoundField DataField="InvoiceCode" HeaderText="Invoice Number" />
                            <asp:BoundField DataField="AgentName" HeaderText="Agent" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
                            <asp:BoundField DataField="Outstanding" HeaderText="Outstanding" />
                            <asp:ButtonField CommandName="Select" Text="View" />
                            <asp:ButtonField CommandName="Edit" Text="Edit" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                         <SortedAscendingCellStyle BackColor="#E9E7E2" />
                         <SortedAscendingHeaderStyle BackColor="#506C8C" />
                         <SortedDescendingCellStyle BackColor="#FFFDF8" />
                         <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
    <!-- End Of Second Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>