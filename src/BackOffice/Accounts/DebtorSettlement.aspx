<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Accounts.Master" AutoEventWireup="true" CodeBehind="DebtorSettlement.aspx.cs" Inherits="WOC.Book.Accounts.DebtorSettlement" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style11
        {
            width: 176px;
            text-align: right;
        }
        .style12
        {
            width: 408px;
        }
        .style13
        {
            width: 176px;
            text-align: right;
            height: 26px;
        }
        .style14
        {
            width: 408px;
            height: 26px;
        }
        .style15
        {
            height: 26px;
        }
        .style17
        {
            width: 155px;
        }
        .style18
        {
            width: 156px;
            text-align: right;
        }
        .style20
        {
            width: 161px;
            text-align: right;
        }
        .style21
        {
            width: 156px;
            text-align: right;
            height: 21px;
        }
        .style22
        {
            width: 155px;
            height: 21px;
        }
        .style23
        {
            width: 161px;
            text-align: right;
            height: 21px;
        }
        .style24
        {
            height: 21px;
        }
        .style27
        {
            width: 513px;
            height: 30px;
        }
        .style28
        {
            height: 30px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <script language="javascript" type="text/javascript">
      $(document).ready(function () {
          $("#MainContent_TextBox1").datepicker();

          // Accordion
          $("#accordion1").accordion({ header: "h3" });

          // Accordion
          $("#accordion2").accordion({ header: "h3" });

          // Tabs
          $('#tabs').tabs({
              cookie: {
                  // store cookie for a day, without, it would be a session cookie
                  expires: 1
              }
          });


          if (HasQueryString()) {
              SelectSecondTab();
          }
          else {
              var agentVal = $('#MainContent_ddlAgents').val();
              var invoiceNoVal = $('#MainContent_txtInvoiceNo').val();
              if (agentVal.toString() == "Select" && invoiceNoVal.toString() == "") {
                  SelectFirstTab();
              }
              else {
                  SelectSecondTab();
              }
          }

          $('#MainContent_txtInvoiceNo').autocomplete("../AutocompleteData/AutocompleteInvoiceCode.ashx");
          $('#MainContent_txtBank').autocomplete("../AutocompleteData/AutocompleteBank.ashx");


      });
        function SelectFirstTab() {
            $('#tabs').tabs('select', 0); // switch to third tab
            return false;
        }
        function SelectSecondTab() {
            var agentVal = $('#MainContent_ddlAgents').val();
            var invoiceNoVal = $('#MainContent_txtInvoiceNo').val();

            if (agentVal.toString() == "" && invoiceNoVal.toString() == "") {
            }
            else {
                $('#tabs').tabs('select', 1); // switch to third tab
            }
          
            return false;
        }
        
        function HasQueryString() {
            var field = 'AGENT';
            var url = window.location.href.toString().toUpperCase();
            if (url.indexOf('?' + field + '=') != -1)
                return true;
            else if (url.indexOf('&' + field + '=') != -1)
                return true;
            return false
        }

        function SelectThirdTab() {
            $('#tabs').tabs('select', 2); // switch to third tab
            return false;
        }
       
        function checkAll(objRef)
        {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex 
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked 
                        //check all checkboxes 
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked 
                        //uncheck all checkboxes 
                        inputList[i].checked = false;
                    }
                }
            }
        }

        function PopupCreditNote(actionText, encInvoiceCode, agentID) {
            var url = 'CreditNote.aspx?Action=' + actionText;
            var reqParams = '&InvoiceCode=' + encInvoiceCode
            var params = '&AgentID=' + agentID;

            url = url + reqParams + params;

            window.open(url);
        }
        function validateDollar(fld) {
            var temp_value = fld.value;

            if (temp_value == "")
            {
                fld.value = "0.00";
                return;
            }
            // var Chars = "0123456789.,$";
            var Chars = "0123456789.,";
            for (var i = 0; i < temp_value.length; i++) 
            {
                if (Chars.indexOf(temp_value.charAt(i)) == -1) 
                {
                    alert("Invalid Character(s)\n\nOnly numbers (0-9), a comma, and a period are allowed in this field.");
                    fld.focus();
                    fld.select();
                    return;
                }
            }

        }

        function ComputeBalance(InvAmtID, CNAmtID, AmtPaidID, AmtDueID, DepID, BalID) {
            var InvAmt = $('#' + InvAmtID).val();
            var CNAmt = $('#' + CNAmtID).val();
            var AmtPaid = $('#' + AmtPaidID).val();
            var AmtDue = $('#' + AmtDueID).val();
            var Deposit = $('#' + DepID).val();
            var isNumeric = true;

            isNumeric = IsNumericAmount(InvAmt, InvAmtID, 'Invoice Amount');
            isNumeric = IsNumericAmount(CNAmt, CNAmtID, 'Credit Amount');
            isNumeric = IsNumericAmount(AmtPaid, AmtPaidID, 'Amount Paid');

            if (isNumeric) {
                $('#' + BalID).val(parseFloat(InvAmt) - (parseFloat(CNAmt) + parseFloat(AmtPaid)));
            }


            ComputeTotalAmountPaid();
        }

        function IsNumericAmount(amt, id, name) {
            if ($.isNumeric(amt) == false) {
                alert(name + ' must be numeric!');
                isNotNumber = true;
                $('#' + id).focus();
                return false;
            }
            return true;
        }

        function ComputeTotalAmountPaid() {
            var grid = document.getElementById("<%= gv.ClientID %>");
            var rowtotal = 0;
            var rowBalance = 0;
            var cellValue = 0;
            var cellAmtPaid;
            var cellBalance;

            for (var i = 0; i < grid.rows.length; i++) 
            {
                cellAmtPaid = grid.rows[i].cells[6]; // Amount Paid
                cellBalance = grid.rows[i].cells[9]; // Balance

                for (j = 0; j < cellAmtPaid.childNodes.length; j++) {
                    if (cellAmtPaid.childNodes[j].type == "text") {
                        rowtotal = rowtotal + parseInt(cellAmtPaid.childNodes[j].value);
                    }

                }

                for (j = 0; j < cellBalance.childNodes.length; j++) {
                    if (cellBalance.childNodes[j].type == "text") {
                        rowBalance = rowBalance + parseInt(cellBalance.childNodes[j].value);
                    }
                }
            }
            document.getElementById('MainContent_txtAmountCollectable').value = parseFloat(rowtotal).toFixed(2);
            document.getElementById('MainContent_txtTransactionDifference').value = parseFloat(rowBalance).toFixed(2);
        }

        function PayAll() {
            var grid = document.getElementById("<%= gv.ClientID %>");
            var cellAmtDue;
            var cellBalance;
            var cellAmtPaid;
            var cellCheck;
            var rowAmtPaid = 0;
            var rowBalance = 0;
            var message = "";
            var checkedList = new Array();

            try {
                for (var i = 1; i < grid.rows.length; i++) {
                    cellCheck = grid.rows[i].cells[0]; // Checkbox

                    for (j = 0; j < cellCheck.childNodes.length; j++) {
                        if (cellCheck.childNodes[j].type == "checkbox" && cellCheck.childNodes[j].checked.toString() == "true") {
                            checkedList.push(i);
                        }
                    }
                }

                for (i = 0; i < checkedList.length; i++) {
                    var checkedIdx = checkedList[i];
                    cellAmtPaid = grid.rows[checkedIdx].cells[6]; // Amount Paid
                    cellAmtDue = grid.rows[checkedIdx].cells[7]; // Amount Due
                    cellBalance = grid.rows[checkedIdx].cells[9]; // Balance
                    for (j = 0; j < cellAmtPaid.childNodes.length; j++) {
                        if (cellAmtPaid.childNodes[j].type == "text" && cellAmtDue.childNodes[j].value > 0) {
                            cellAmtPaid.childNodes[j].value = cellAmtDue.childNodes[j].value;
                        }
                    }

                    for (j = 0; j < cellBalance.childNodes.length; j++) {
                        if (cellBalance.childNodes[j].type == "text" && cellBalance.childNodes[j].value > 0) {
                            cellBalance.childNodes[j].value = 0.0;
                        }
                    }
                }
                ComputeTotalAmountPaid();
            }
            catch (e) {
                alert(e);
            }
        }

        function EnableDisableChequeText() {
            var e = document.getElementById("MainContent_ddlPaymentMode");
            var paymentMode = e.options[e.selectedIndex].value;

            if (paymentMode == "Cheque") {
                document.getElementById("MainContent_txtChequeNumber").disabled = false;
            }
            else {
                document.getElementById("MainContent_txtChequeNumber").disabled = true;
            }
        }
  </script>

  <div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
   </div>
  <div id="tabs">

  <!-- Main Tabs -->
     <ul>
	    <li><a href="#tabs-1">Debtor Settlement</a></li>
	    <li><a href="#tabs-2">Details</a></li>
       
			
    </ul>
     <div id="tabs-1">
        <h3>Search Debtor Settlement</h3>
            <table style="width:100%;">
            <tr>
            <td>
            
                <table style="width:100%;">
                    <tr>
                        <td class="style11">
                            Agent Name:</td>
                        <td class="style12">
                            <asp:DropDownList ID="ddlAgents" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style13">
                            Invoice No:</td>
                        <td class="style14">
                            <asp:TextBox ID="txtInvoiceNo" runat="server" Width="173px"></asp:TextBox>
                        </td>
                        <td class="style15">
                        </td>
                    </tr>
                    <tr>
                         <td colspan="4">
                                <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                         </td>
                         <td class="style27">
                            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                                Text="Search" Width="125px" style="height: 26px" 
                                UseSubmitBehavior="False" />
                        </td>
                        <td class="style28">
                            </td>
                    </tr>

                </table>
            
            </td>
            </tr>
                </table>

    </div>
     <div id="tabs-2">
        <h3>Debtor Settlement </h3>
            <table style="width:100%;">

            <tr>
               <td>
                <table style="width:100%;">
                    <tr>
                        <td class="style18">
                            Agent Name</td>
                        <td class="style17">
                            <asp:Label ID="lblAgentName" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td class="style20">
                            Receipt Date</td>
                        <td>
                            <asp:Label ID="lblReceiptDate" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style17">
                            &nbsp;</td>
                        <td class="style20">
                            Amount Collectable</td>
                        <td>
                            <asp:TextBox ID="txtAmountCollectable" runat="server" Width="150px" 
                                onChange='validateDollar(this)'>0.00</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                            &nbsp;</td>
                        <td class="style17">
                            &nbsp;</td>
                        <td class="style20">
                            Transaction Difference</td>
                        <td>
                            <asp:TextBox ID="txtTransactionDifference" runat="server" Width="150px" 
                                ReadOnly="True">0.00</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style18">
                            Payment Mode</td>
                        <td class="style17">
                            <asp:DropDownList ID="ddlPaymentMode" runat="server" Height="24px" onchange="EnableDisableChequeText();"
                                Width="235px" >
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Cheque</asp:ListItem>
                                <asp:ListItem Selected="True">Cash</asp:ListItem>
                                <asp:ListItem>Giro</asp:ListItem>
                                <asp:ListItem>Bank Transfer</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style20">
                            Cheque Number</td>
                        <td>
                            <asp:TextBox ID="txtChequeNumber" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            Bank</td>
                        <td class="style22">
                            <asp:TextBox ID="txtBank" runat="server" MaxLength="250" Width="250px"></asp:TextBox>
                        </td>
                        <td class="style23">
                            Description</td>
                        <td class="style24">
                            <asp:TextBox ID="txtDescription" runat="server" Width="250px" MaxLength="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style22">
                            &nbsp;</td>
                        <td class="style23">
                            &nbsp;</td>
                        <td class="style24">
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                       
                        <td>
                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                                EmptyDataText="No Record Found" CellPadding="4" ForeColor="#333333" 
                                GridLines="None" onrowdatabound="gvDebut_RowDataBound" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                  <asp:TemplateField >
                                    <HeaderTemplate>
                                      <asp:CheckBox ID="cbxSelectAllRemainders" runat="server" onclick="checkAll(this);" />
                                  </HeaderTemplate>
                                    <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server"  Enabled="true" />
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Invoice Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoiceCode" runat="server" Text='<%# Bind("InvoiceCode") %>'></asp:Label>

                                    </ItemTemplate>
                                   </asp:TemplateField>
                                  <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" DataFormatString="{0:dd/MM/yyyy}" />
                                  <asp:TemplateField HeaderText="CN/DN No">
                                    <ItemTemplate>
                                        <table border="0" width="100px">
                                            <td><asp:LinkButton ID="lnkCNNo" runat="server" Text='<%# Bind("CNLinkLabel") %>' /> </td>
                                            <td align="right"><asp:ImageButton ID="ibtnCreateCN" runat="server" ImageUrl="../Images/MiscIcons/CreateCreditNote.png" AlternateText="Create a new credit note for this invoice." Height="18px" Width="18px" /> </td>
                                        </table>
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                   <asp:TemplateField HeaderText="CN Amount">
                                    <ItemTemplate>
                                    <asp:TextBox ID="txtCNAmount" Font-Size="Small" BorderStyle="Solid" BorderWidth="1px" runat="server" style="text-align:right" Width="50px" Text='<%# Bind("CNAmount","{0:f2}") %>' Enabled = "false"></asp:TextBox>
                                    </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Inv Amount">
                                    <ItemTemplate>
                                     <asp:TextBox ID="txtTotalAmount" Font-Size="Small" BorderStyle="Solid" BorderWidth="1px" runat="server" style="text-align:right" Width="50px" Text='<%# Bind("TotalAmount","{0:f2}") %>' Enabled = "false"></asp:TextBox>
                                    </ItemTemplate>
                                   </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Amount Paid">
                                    <ItemTemplate>
                                     <asp:TextBox ID="txtPaymentAmount" Font-Size="Small" runat="server" Width="50px" Text='0.0' ></asp:TextBox>
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Amount Due">
                                    <ItemTemplate>
                                     <asp:TextBox ID="txtAmountDue"  Font-Size="Small" BorderStyle="Solid" BorderWidth="1px" Text='<%# Bind("Balance") %>' runat="server" Width="50px" Enabled="false" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Deposit">
                                    <ItemTemplate>
                                     <asp:TextBox ID="txtDeposit" Font-Size="Small" runat="server" Width="50px" Text='<%# Bind("Deposit") %>' Enabled="false" ></asp:TextBox>
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Balance">
                                    <ItemTemplate>
                                     <asp:TextBox ID="txtBalance" Font-Size="Small" BorderStyle="Solid" BorderWidth="1px" Text='<%# Bind("Balance") %>' style="text-align:right" runat="server" Width="100px" Enabled="false" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Remark">
                                    <ItemTemplate>
                                     <asp:TextBox ID="txtRemark" Font-Size="Small" runat="server" Width="100px" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                    </ItemTemplate>
                                  </asp:TemplateField>
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
                            <table style="width:100%;">
                                <tr>
                                    <td colspan="3">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" 
                                            UseSubmitBehavior="False" onclick="btnSave_Click" />
                                        <input type="button" value="Pay All" style="width: 80px" onclick="PayAll();" />
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" Width="80px" 
                                            UseSubmitBehavior="False" onclick="btnPrint_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" 
                                            UseSubmitBehavior="False" onclick="btnCancel_Click" />
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                 </td>
            </tr>
           </table>
    </div>
   
  </div>
  

</asp:Content>