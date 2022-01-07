<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="WOC.Book.NewBooking.Contract"  MasterPageFile="~/NewBooking/NewBooking.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 77px;
        }
        .style3
        {
            width: 87px;
        }
        .style7
        {
            width: 249px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtStartDate").datepicker();
            $("#MainContent_txtStopDate").datepicker();

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

            var e = document.getElementById("MainContent_ddlCategory");
            var ddlCategory = e.options[e.selectedIndex].value;
            var search = document.getElementById('MainContent_txtSearch').value;
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteContract.ashx?category=" + ddlCategory + "&paremeter=" + search);
        });

        function SelectLastTab() {
            $('#tabs').tabs('select', 2); // switch to third tab
            return false;
        }

        function EnableTextbox(ObjChkId, ObjStartTxtId, ObjEndTxtId) {
            var isOneWay = document.getElementById("MainContent_rbtnOneWay").checked;

            if (document.getElementById(ObjChkId).checked){
                document.getElementById(ObjStartTxtId).disabled = false;

                if (isOneWay != true) {
                    document.getElementById(ObjEndTxtId).disabled = false;
                }
            }
            else{
                document.getElementById(ObjStartTxtId).disabled = true;
                document.getElementById(ObjEndTxtId).disabled = true;
            }
        }

        function ValidateTime(txtID) {
            var txtVal = $('#' + txtID).val();
            var errMsg = 'Invalid Time Format: Must be [0000 - 2359]';

            if ($.isNumeric(txtVal) == false) {
                alert(errMsg);
                $('#' + txtID).focus();
                return false;
            }

            if (parseInt(txtVal.substr(0, 2)) > 23 || parseInt(txtVal.substr(2, 2)) > 59) {
                alert(errMsg);
                $('#' + txtID).focus();
                return false;
            }
            return true;
        }

        //This function disables End Textboxes in Add Tab
        function DisableEditEndTextOneWay () {
            var isOneWay = document.getElementById("MainContent_rbtnEditOneWay").checked;
            if (isOneWay) {
                document.getElementById("MainContent_txtEditEndMon").disabled = true;
                document.getElementById("MainContent_txtEditEndTue").disabled = true;
                document.getElementById("MainContent_txtEditEndWed").disabled = true;
                document.getElementById("MainContent_txtEditEndThu").disabled = true;
                document.getElementById("MainContent_txtEditEndFri").disabled = true;
                document.getElementById("MainContent_txtEditEndSat").disabled = true;
                document.getElementById("MainContent_txtEditEndSun").disabled = true;
            }
        }

        //This function disables End Textboxes in Update Tab
        function DisableEndTextOneWay() {
            var isOneWay = document.getElementById("MainContent_rbtnOneWay").checked;
            if (isOneWay) {
                document.getElementById("MainContent_txtEndMon").disabled = true;
                document.getElementById("MainContent_txtEndTue").disabled = true;
                document.getElementById("MainContent_txtEndWed").disabled = true;
                document.getElementById("MainContent_txtEndThu").disabled = true;
                document.getElementById("MainContent_txtEndFri").disabled = true;
                document.getElementById("MainContent_txtEndSat").disabled = true;
                document.getElementById("MainContent_txtEndSun").disabled = true;
            }
        }

        //This function ticks or unticks all checkboxes and enabled or disable start and end textboxes in Add Tab
        function EnableDisableDays(CheckAll) {

            document.getElementById("MainContent_chkMon").checked = CheckAll.checked;
            document.getElementById("MainContent_chkTue").checked = CheckAll.checked;
            document.getElementById("MainContent_chkWed").checked = CheckAll.checked;
            document.getElementById("MainContent_chkThu").checked = CheckAll.checked;
            document.getElementById("MainContent_chkFri").checked = CheckAll.checked;
            document.getElementById("MainContent_chkSat").checked = CheckAll.checked;
            document.getElementById("MainContent_chkSun").checked = CheckAll.checked;

            document.getElementById("MainContent_txtStartMon").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtStartTue").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtStartWed").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtStartThu").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtStartFri").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtStartSat").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtStartSun").disabled = !CheckAll.checked;

            document.getElementById("MainContent_txtEndMon").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEndTue").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEndWed").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEndThu").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEndFri").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEndSat").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEndSun").disabled = !CheckAll.checked;
            
            DisableEndTextOneWay();
        }

        //This function ticks or unticks all checkboxes and enabled or disable start and end textboxes in Update Tab
        function EnableDisableEditDays(CheckAll) {
            document.getElementById("MainContent_chkEditMon").checked = CheckAll.checked;
            document.getElementById("MainContent_chkEditTue").checked = CheckAll.checked;
            document.getElementById("MainContent_chkEditWed").checked = CheckAll.checked;
            document.getElementById("MainContent_chkEditThu").checked = CheckAll.checked;
            document.getElementById("MainContent_chkEditFri").checked = CheckAll.checked;
            document.getElementById("MainContent_chkEditSat").checked = CheckAll.checked;
            document.getElementById("MainContent_chkEditSun").checked = CheckAll.checked;

            document.getElementById("MainContent_txtEditStartMon").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditStartTue").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditStartWed").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditStartThu").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditStartFri").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditStartSat").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditStartSun").disabled = !CheckAll.checked;

            document.getElementById("MainContent_txtEditEndMon").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditEndTue").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditEndWed").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditEndThu").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditEndFri").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditEndSat").disabled = !CheckAll.checked;
            document.getElementById("MainContent_txtEditEndSun").disabled = !CheckAll.checked;

            DisableEditEndTextOneWay()
        }

        function InvoiceTextDefault() {
            var isOneWay = document.getElementById("MainContent_rbtnOneWay").checked;
            var arrow = ((isOneWay == true) ? " > " : " <> ");
            var invoiceText = document.getElementById("MainContent_txtFrom").value + arrow + document.getElementById("MainContent_txtTo").value;
            document.getElementById("MainContent_txtInvoiceText").value = invoiceText;
            document.getElementById("MainContent_txtEndCopyAll").disabled = isOneWay;

        }

        function InvoiceTextEditDefault() {
            var isOneWay = document.getElementById("MainContent_rbtnEditOneWay").checked;
            var arrow = ((isOneWay == true) ? " > " : " <> ");
            var invoiceText = document.getElementById("MainContent_txtEditFrom").value + arrow + document.getElementById("MainContent_txtEditTo").value
            document.getElementById("MainContent_txtEditInvoiceText").value = invoiceText;
            document.getElementById("MainContent_txtEditEndCopyAll").disabled = isOneWay;
        }

        function CopyAllStartTime() {
            var timeValue = document.getElementById("MainContent_txtStartCopyAll").value;
            document.getElementById("MainContent_txtStartMon").value = ((document.getElementById("MainContent_chkMon").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtStartTue").value = ((document.getElementById("MainContent_chkTue").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtStartWed").value = ((document.getElementById("MainContent_chkWed").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtStartThu").value = ((document.getElementById("MainContent_chkThu").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtStartFri").value = ((document.getElementById("MainContent_chkFri").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtStartSat").value = ((document.getElementById("MainContent_chkSat").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtStartSun").value = ((document.getElementById("MainContent_chkSun").checked == true) ? timeValue : "");
        }

        function CopyAllEndTime() {
            var timeValue = document.getElementById("MainContent_txtEndCopyAll").value;
            document.getElementById("MainContent_txtEndMon").value = ((document.getElementById("MainContent_chkMon").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEndTue").value = ((document.getElementById("MainContent_chkTue").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEndWed").value = ((document.getElementById("MainContent_chkWed").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEndThu").value = ((document.getElementById("MainContent_chkThu").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEndFri").value = ((document.getElementById("MainContent_chkFri").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEndSat").value = ((document.getElementById("MainContent_chkSat").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEndSun").value = ((document.getElementById("MainContent_chkSun").checked == true) ? timeValue : "");
        }

        function CopyAllEditStartTime() {
            var timeValue = document.getElementById("MainContent_txtEditStartCopyAll").value;
            document.getElementById("MainContent_txtEditStartMon").value = ((document.getElementById("MainContent_chkEditMon").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditStartTue").value = ((document.getElementById("MainContent_chkEditTue").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditStartWed").value = ((document.getElementById("MainContent_chkEditWed").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditStartThu").value = ((document.getElementById("MainContent_chkEditThu").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditStartFri").value = ((document.getElementById("MainContent_chkEditFri").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditStartSat").value = ((document.getElementById("MainContent_chkEditSat").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditStartSun").value = ((document.getElementById("MainContent_chkEditSun").checked == true) ? timeValue : "");
        }

        function CopyAllEditEndTime() {
            var timeValue = document.getElementById("MainContent_txtEditEndCopyAll").value;
            document.getElementById("MainContent_txtEditEndMon").value = ((document.getElementById("MainContent_chkEditMon").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditEndTue").value = ((document.getElementById("MainContent_chkEditTue").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditEndWed").value = ((document.getElementById("MainContent_chkEditWed").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditEndThu").value = ((document.getElementById("MainContent_chkEditThu").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditEndFri").value = ((document.getElementById("MainContent_chkEditFri").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditEndSat").value = ((document.getElementById("MainContent_chkEditSat").checked == true) ? timeValue : "");
            document.getElementById("MainContent_txtEditEndSun").value = ((document.getElementById("MainContent_chkEditSun").checked == true) ? timeValue : "");
        }

        function HasRequiredTime(txtID) {
            var txtVal = $('#' + txtID).val();
            var txtlength = $('#' + txtID).val().length;

            if (length != 4 && $.isNumeric(txtVal) == false) {
                $('#' + txtID).focus();
                return false;
            }
            return true;
        }

  </script>
<!-- Begin of Tabs -->
<div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
</div>
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Contract Booking</a></li>
	    <li><a href="#tabs-2">Contract Search</a></li>
        <li><a href="#tabs-3">Contract Update</a></li>
			
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
        <h3>Add New Contract Booking</h3>
            <table style="width:100%;">
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td >&nbsp;</td>
                     <td>&nbsp;</td>
                     <td align="right">
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    Agent:</td>
                <td class="style2">
                    <asp:DropDownList ID="ddlAgent" runat="server" Width="220px">
                    </asp:DropDownList>
                </td>
                <td >P.O. No:</td>
                     <td><asp:TextBox ID="txtPONo" runat="server" Width="150px"></asp:TextBox>
                    </td>
                     <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td >&nbsp;</td>
                     <td>&nbsp;</td>
                     <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    Start
                    Date:</td>
                <td class="style2">
                    <asp:TextBox ID="txtStartDate" runat="server" Width="220px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" 
                        ControlToValidate="txtStartDate" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    Stop Date:</td>
                <td class="style2">
                    <asp:TextBox ID="txtStopDate" runat="server" Width="216px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1" style="white-space: nowrap;">
                    Venue:</td>
                <td class="style2" colspan="4">
                    <table>
                        <tr>
                            <td>From:</td>
                            <td><asp:TextBox ID="txtFrom" runat="server" Width="250px" onchange="InvoiceTextDefault();"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="rfvFrom" runat="server" ControlToValidate="txtFrom" ErrorMessage="*" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator></td>
                            <td>To:</td>
                            <td><asp:TextBox ID="txtTo" runat="server" Width="250px" onchange="InvoiceTextDefault();"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="rfvTo" runat="server" ControlToValidate="txtTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </td>
            </tr>
               <tr>
                <td class="style1" style="white-space: nowrap;">
                    Seater</td>
                <td class="style2">
                    <asp:TextBox ID="txtSeater" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvSeater" runat="server" ControlToValidate="txtSeater" 
                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Person In Charge:</td>
                <td class="style2">
                    <asp:TextBox ID="txtPersonInCharge" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style3">
                    Contact:</td>
                     <td>
                    <asp:TextBox ID="txtContact" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Trip Type:
                 </td>
                <td>
                    <input id="rbtnOneWay" type="radio" runat="server" name="Add" value="One Way" onclick="InvoiceTextDefault();" checked/>One Way
                    <input id="rbtnTwoWay" type="radio" runat="server" name="Add" value="Two Way" onclick="InvoiceTextDefault();" />Two Way</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">&nbsp;</td>
                <td class="style2">&nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>&nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">Day </td>
                <td colspan="4" rowspan="3" style="width: 100%">
                    <table style="width: 90%">
                        <tr>
                            <td><asp:CheckBox ID="chkMon" runat="server" Text="Monday" /></td>
                            <td><asp:CheckBox ID="chkTue" runat="server" Text="Tuesday"/></td>
                            <td><asp:CheckBox ID="chkWed" runat="server" Text="Wednesday"/></td>
                            <td><asp:CheckBox ID="chkThu" runat="server" Text="Thursday"/></td>
                            <td><asp:CheckBox ID="chkFri" runat="server" Text="Friday"/></td>
                            <td><asp:CheckBox ID="chkSat" runat="server" Text="Saturday"/></td>
                            <td><asp:CheckBox ID="chkSun" runat="server" Text="Sunday"/></td>
                            <td><asp:CheckBox ID="chkAll" runat="server" onclick="EnableDisableDays(this);"/></td>
                            <td>Check All</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtStartMon" runat="server" width="68px" Enabled="False" ></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTue" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartWed" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartThu" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartFri" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartSat" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartSun" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <img alt="Copy To All Start Time" src="../Images/MiscIcons/CopyTime.png" onclick="CopyAllStartTime();" onmouseover="this.style.cursor='pointer'" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartCopyAll" runat="server" Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStartCopyAll" runat="server" 
                                    ControlToValidate="txtStartCopyAll" ErrorMessage="*" ForeColor="Red" 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEndMon" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTue" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndWed" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndThu" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndFri" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndSat" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndSun" runat="server" Width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td><img alt="Copy To All End Time" src="../Images/MiscIcons/CopyTime.png" onclick="CopyAllEndTime();" onmouseover="this.style.cursor='pointer'" /></td>
                            <td>
                                <asp:TextBox ID="txtEndCopyAll" runat="server" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                    </table></td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Start:</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    End:</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Rate Type:</td>
                <td class="style2" rowspan="2">
                    <asp:RadioButtonList ID="rbtnRates" runat="server">
                        <asp:ListItem Value="1" Selected="True">Contract</asp:ListItem>
                        <asp:ListItem Value="2">Daily</asp:ListItem>
                    </asp:RadioButtonList>
                 </td>
                <td>&nbsp;
                </td>
                <td class="style1" style="white-space: nowrap;">
                    Rates:
                </td>
                <td>
                    <asp:TextBox ID="txtCharge" runat="server" width="140px" ValidationGroup="Add"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRates" runat="server" 
                        ControlToValidate="txtCharge" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvRates" runat="server" ControlToValidate="txtCharge" 
                        ErrorMessage="*" ForeColor="Red" MaximumValue="9999999999" 
                        MinimumValue="0.0001" ValidationGroup="Add"></asp:RangeValidator>
                </td>
            </tr>
           
             <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
            </tr>
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Invoice Text</td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="txtInvoiceText" runat="server" Width="400px" MaxLength="500"></asp:TextBox>
                 </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Remarks 1</td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="txtRemarks1" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                 </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Remarks 2</td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="txtRemarks2" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                 </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Driver Claim</td>
                <td class="style2">
                    <asp:TextBox ID="txtDriverClaim" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style3">
                   
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="77px" 
                        onclick="btnConfirm_Click" ValidationGroup="Add" />
                   
                    </td>
                     <td colspan="2">
                   
                         <asp:Label ID="lblMessage" runat="server"></asp:Label>
                   
                    </td>
            </tr>
           
            <tr>
                <td class="style1" style="white-space: nowrap;">
                   </td>
                <td class="style2">
                   
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                   
                         &nbsp;</td>
                     <td>
                   
                         &nbsp;</td>
            </tr>
        </table>
    </div>
    <!-- End Of First Tab -->

    <!-- Second Tab -->
    <div id="tabs-2">
        <h3>Search Contract Booking</h3>
        <table style="width: 100%;">
      
            <tr>
                <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="20px" 
                        Width="245px" AutoPostBack="True">
                            <asp:ListItem Selected="True">Select</asp:ListItem>
                            <asp:ListItem>Agent</asp:ListItem>
                            <asp:ListItem Value="BookingCode">Ref No</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td>
                        <asp:TextBox ID="txtSearch" runat="server" Width="400px" CssClass="SearchText"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPagingNumber" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlPagingNumber_SelectedIndexChanged">
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                        <asp:ListItem>200</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:RadioButtonList ID="rbtnActiveStatus" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">InActive</asp:ListItem>
                        <asp:ListItem Value="2">All</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                <td class="style7">
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnSearch_Click" ValidationGroup="Search" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        
            <tr>
                <td class="style3" colspan="3">
        
        
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"   
                        DataKeyNames = "ContractID" AllowPaging="true"
                    Width="665px" onrowcommand="gv_RowCommand" onrowdatabound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Prefix" HeaderText="Prefix" />
                        <asp:BoundField DataField="Agent" HeaderText="Agent" />
                        <asp:BoundField DataField="BookingCode" HeaderText="Ref" />
                        <asp:BoundField DataField="Route" HeaderText="Route" />
                        <asp:BoundField DataField="Seater" HeaderText="Seater" />
                        <asp:BoundField DataField="ContractRate" HeaderText="Contract Rate" />
                        <asp:BoundField DataField="DailyRate" HeaderText="Daily Rate" />
                        <asp:CommandField ShowSelectButton="True" />
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
                <td class="style3" colspan="4" align="right">
                <asp:ImageButton ID="ibtnListAllPDF" runat="server" 
                        ImageUrl="~/Images/MenuIcons/pdf_icon.png" Height="20px" Width="20px" 
                        CausesValidation="False" onclick="ibtnListAllPDF_Click" />
                    <asp:Image ID="imgSeparator" runat="server" ImageUrl="~/Images/MenuIcons/separator_icon.png" Height="20px" Width="5px"/>                
                    <asp:ImageButton ID="ibtnListAll" runat="server" ImageUrl="~/Images/MenuIcons/excel_icon.png" Height="20px" onclick="ibtnListAll_Click" Width="20px" CausesValidation="False" />
        
        
                    </td>
            </tr>
        </table>
    </div>
    <!-- End Of Second Tab -->

    <!-- Third Tab -->
    <div id="tabs-3">
     <h3>Update Contract Booking</h3>
          <table style="width:100%;">
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td >&nbsp;</td>
                     <td>&nbsp;</td>
                     <td align="right">
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    Agent:</td>
                <td class="style2">
                    <asp:DropDownList ID="ddlEditAgent" runat="server" Width="220px">
                    </asp:DropDownList>
                </td>
                <td >&nbsp;</td>
                     <td>Booking Ref No: </td>
                     <td><asp:TextBox ID="txtEditBookingRefNo" runat="server" Width="150px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td >&nbsp;</td>
                     <td>PO. No.:</td>
                     <td><asp:TextBox ID="txtEditPONo" runat="server" Width="150px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    Start
                    Date:</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditStartDate" runat="server" Width="220px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEditStartDate" runat="server" 
                        ControlToValidate="txtEditStartDate" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         <asp:HiddenField ID="hdnId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    Stop Date:</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditStopDate" runat="server" Width="216px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">Venue:</td>
                <td class="style2" colspan="4">
                    <table>
                        <tr>
                            <td>From:</td>
                            <td><asp:TextBox ID="txtEditFrom" runat="server" Width="250px" onchange="InvoiceTextEditDefault();" ></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="rfvEditFrom" runat="server" 
                                    ControlToValidate="txtEditFrom" ErrorMessage="*" ForeColor="Red" 
                                    ValidationGroup="Edit"></asp:RequiredFieldValidator></td>
                            <td>To:</td>
                            <td><asp:TextBox ID="txtEditTo" runat="server" Width="250px"  onchange="InvoiceTextEditDefault();"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="rfvEditTo" runat="server" ControlToValidate="txtEditTo" ErrorMessage="*" ForeColor="Red" 
                                    ValidationGroup="Edit"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">Seater</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditSeater" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvEditSeater" runat="server" 
                        ControlToValidate="txtEditSeater" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td class="style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Person In Charge:</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditPersonInCharge" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style3">
                    Contact:</td>
                     <td>
                    <asp:TextBox ID="txtEditContact" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Trip Type:
                 </td>
                <td >
                    <input id="rbtnEditOneWay" type="radio" runat="server" name="Update" value="One Way" onclick="InvoiceTextEditDefault();" checked />One Way
                    <input id="rbtnEditTwoWay" type="radio" runat="server" name="Update" value="Two Way" onclick="InvoiceTextEditDefault();" />Two Way
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Day</td>
                <td colspan="4" rowspan="3" style="width: 100%">
                    <table style="width: 90%">
                        <tr>
                            <td><asp:CheckBox ID="chkEditMon" runat="server" Text="Monday"/></td>
                            <td><asp:CheckBox ID="chkEditTue" runat="server" Text="Tuesday"/></td>
                            <td><asp:CheckBox ID="chkEditWed" runat="server" Text="Wednesday"/></td>
                            <td><asp:CheckBox ID="chkEditThu" runat="server" Text="Thursday"/></td>
                            <td><asp:CheckBox ID="chkEditFri" runat="server" Text="Friday"/></td>
                            <td><asp:CheckBox ID="chkEditSat" runat="server" Text="Saturday"/></td>
                            <td><asp:CheckBox ID="chkEditSun" runat="server" Text="Sunday"/></td>
                            <td><asp:CheckBox ID="chkEditAll" runat="server" onclick="EnableDisableEditDays(this);"/></td>
                            <td>Check All</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEditStartMon" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditStartTue" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditStartWed" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditStartThu" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditStartFri" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditStartSat" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditStartSun" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td><img alt="Copy To All Start Time" src="../Images/MiscIcons/CopyTime.png" onclick="CopyAllEditStartTime();" onmouseover="this.style.cursor='pointer'" /></td>
                            <td>
                                <asp:TextBox ID="txtEditStartCopyAll" runat="server" Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEditStartCopyAll" runat="server" 
                                    ControlToValidate="txtEditStartCopyAll" ErrorMessage="*" ForeColor="Red" 
                                    ValidationGroup="Edit"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEditEndMon" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditEndTue" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditEndWed" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="margin-left: 40px">
                                <asp:TextBox ID="txtEditEndThu" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditEndFri" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditEndSat" runat="server" width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditEndSun" runat="server" Width="68px" Enabled="False"></asp:TextBox>
                            </td>
                            <td><img alt="Copy To All End Time" src="../Images/MiscIcons/CopyTime.png" onclick="CopyAllEditEndTime();" onmouseover="this.style.cursor='pointer'" /></td>
                            <td>
                                <asp:TextBox ID="txtEditEndCopyAll" runat="server" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                    </table></td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Start:</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    End:</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Rate Type:</td>
                <td class="style2" rowspan="2">
                    <asp:RadioButtonList ID="rbtnEditRates" runat="server">
                        <asp:ListItem Value="1">Contract</asp:ListItem>
                        <asp:ListItem Value="2">Daily</asp:ListItem>
                    </asp:RadioButtonList>
                 </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         Rates:</td>
                     <td>
                        <asp:TextBox ID="txtEditCharge" runat="server" width="140px" ReadOnly="true"></asp:TextBox>
                     </td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">&nbsp;</td>
                <td class="style3">&nbsp;</td>
                <td></td>
                <td></td>
            </tr>
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Invoice Text</td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="txtEditInvoiceText" runat="server" Width="400px"></asp:TextBox>
                 </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Remarks 1</td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="txtEditRemarks1" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                 </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Remarks 2</td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="txtEditRemarks2" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                 </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1" style="white-space: nowrap;">
                    Driver Claim</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditDriverClaim" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style3">
                   
                    <asp:Button ID="btnEditConfirm" runat="server" Text="Confirm" Width="77px" 
                        onclick="btnEditConfirm_Click" ValidationGroup="Edit" />
                   
                    &nbsp;</td>
                     <td colspan="2">
                   
                         <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
                    </td>
            </tr>
           
            <tr>
                <td class="style1" style="white-space: nowrap;">
                   </td>
                <td class="style2">
                   
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                   
                         &nbsp;</td>
                     <td>
                   
                         &nbsp;</td>
            </tr>
        </table>
    </div>
    <!-- End Of Third Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>