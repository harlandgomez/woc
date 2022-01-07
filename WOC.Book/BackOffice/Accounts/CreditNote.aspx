<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditNote.aspx.cs" Inherits="WOC.Book.Accounts.CreditNote" MasterPageFile="~/Accounts/Accounts.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .hiddencol
        {
            display:none;
        }
        .viscol
        {
            display:block;
        }
        .saveColor
        {
            background-color:Lime;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        var TargetBaseControl = null;

        window.onload = function () {
            try {
                //get target base control.
                TargetBaseControl =
           document.getElementById('<%= this.gv.ClientID %>'); 
            }
            catch (err) {
                TargetBaseControl = null;
            }
        }

        function ValidateDelete() {
            if (TargetBaseControl == null) return false;

            //get target child control.
            var TargetChildControl = "gvCheckbox";

            //get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
            Inputs[n].checked)
                    return true;

            alert('Select at least one credite note!');
            return false;
        }

        function OpenCreditNote(url) {
            window.open(url);
        }
    </script>
  <script language="javascript" type="text/javascript">
      $(document).ready(function () {
          $("#MainContent_txtCNDate").datepicker();

          // Tabs
          $('#tabs').tabs({
              cookie: {
                  // store cookie for a day, without, it would be a session cookie
                  expires: 1
              }
          });

          if (Action() == 1) {
              SelectLastTab();
          }
          else {
              SelectFirstTab();
          }

          var search = document.getElementById('MainContent_txtCNCode').value;
          $('#MainContent_txtCNCode').autocomplete("../AutocompleteData/AutocompleteCreditNote.ashx?category=CreditNoteCode&paremeter=" + search);
      });

        function SelectLastTab() {
            $('#tabs').tabs('select', 1); // switch to second tab
            return false;
        }

        function SelectFirstTab() 
        {
            $('#tabs').tabs('select', 0); // switch to first tab
            return false;
        }

        function HasQueryString() {
            var field = 'ACTION';
            var url = window.location.href.toString().toUpperCase();
            if (url.indexOf('?' + field + '=') != -1)
                return true;
            else if (url.indexOf('&' + field + '=') != -1)
                return true;
            return false
        }

        function Action() {
            if (HasQueryString()) {
                var actionValue = GetUrlVar('Action');
                if (actionValue == 'Show') {
                    return 0;
                }
                else {
                    return 1;
                }
            }
            else {
                return 0;
            }
        }

        function GetUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

        function GetUrlVar(name) {
            return GetUrlVars()[name];
        }

        function ValidateText(txtAmountID) 
        {
            var value = document.getElementById(txtAmountID).Value;
            if (!IsNumeric(value)) {
                alert("Amount must be greater than 0");
                return false;
            }
            return true;
        }

        function IsNumeric(sText) {
            var validChars = "-0123456789.$";
            for (var i = 0; i < sText.length; i++) {
                if (validChars.indexOf(sText.charAt(i)) == -1) {
                    return false;
                }
            }
            return true;
        }

        function SaveItemByAjax(clientID, category, creditNoteID) 
        {
            var module = "accounts";
            var action = "updatecreditnote";
            var value = $('#' + clientID).val();

            var reqParams = "&category=" + category + "&value=" + value + "&creditnoteid=" + creditNoteID;
            var queryString = "?module=" + module + "&action=" + action + reqParams;
            $.get("AccountsAjax.aspx" + queryString, function (response) {
                if (response.indexOf("Successfully") != -1) {
                    $('#' + clientID).addClass("saveColor");
                }
            });
        }

        function RefreshDebtorSettlement() {
            var agent = window.opener.$("#MainContent_ddlAgents").val();
            var invoice = window.opener.$("#MainContent_txtInvoiceNo").val();
            var url = "DebtorSettlement.aspx";
            var reqParams = "?agent=" + agent + "&invoice=" + invoice;
            url = url + reqParams;
            window.opener.location.href = url;
            self.close();
        }
     </script>
<!-- Begin of Tabs -->
<div id="tabs"> 
<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Search Credit Note</a></li>
	    <li><a href="#tabs-2">Create/Edit Credit Note</a></li>
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
        <table style="width:100%;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblSysMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" >
                    Agent:</td>
                <td>
                    <asp:ListBox ID="lboAgent" runat="server" Height="100px" Width="300px">
                        <asp:ListItem>Agent 1</asp:ListItem>
                        <asp:ListItem>Agent 2</asp:ListItem>
                        <asp:ListItem>Agent 3</asp:ListItem>
                        <asp:ListItem>Agent 4</asp:ListItem>
                        <asp:ListItem>Bedok Secondary School</asp:ListItem>
                        <asp:ListItem>Yishun Secondary School</asp:ListItem>
                    </asp:ListBox>
                </td>
                <td valign="top" >Description:</td>
                     <td >
                    <asp:TextBox ID="txtDescription" runat="server" Width="184px" height="100px" 
                             TextMode="MultiLine"></asp:TextBox>
                         </td>
            </tr>
            <tr>
                <td >
                    CN No:</td>
                <td>
                    <asp:TextBox ID="txtCNCode" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td >
                    CN Date:</td>
                     <td >
                    <asp:TextBox ID="txtCNDate" runat="server" Width="184px"></asp:TextBox>
                         </td>
            </tr>
            <tr>
                <td >
                    Invoice Code:</td>
                <td>
                    <asp:DropDownList ID="ddlInvoiceCode" runat="server" Width="185px">
                    </asp:DropDownList>
                </td>
                <td >
                    Reason Code:</td>
                     <td >
                         <asp:DropDownList ID="ddlReasonCode" runat="server" Width="185px">
                         </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td >
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        onclick="btnSearch_Click" Width="70px" CausesValidation="False" />
                </td>
                     <td >
                         &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width = "100%" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        DataKeyNames="CreditNoteID,AgentID,ReasonCode,GSTTypeCode" onrowdatabound="gv_RowDataBound" 
                        style="font-size: x-small">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="CreditNoteCode" HeaderText="CN No" />
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDate" runat="server" Font-Size="X-Small" Width="60px" Text='<%# Convert.ToDateTime(Eval("CreditNoteDate")).ToString(WOC.Book.Properties.WebResources.dateformat) %>' ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent">
                                <ItemTemplate>
                                    <asp:Label ID="lblAgent" runat="server" Font-Size="X-Small" Width="70px" Text='<%# GetAgentName(Convert.ToString(Eval("AgentID"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InvoiceCode" HeaderText="Invoice Code" />
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAmount" runat="server" Font-Size="X-Small" Width="50px" Text='<%# Eval("CreditNoteAmount") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GST">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlGST" runat="server" Font-Size="X-Small" Width="60px"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason Code">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlReasonCode" runat="server" Font-Size="X-Small" Width="100px"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"  Font-Size="X-Small" 
                                        Width="230px"  Text='<%# Eval("Description") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPrint" runat="server">Print</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sel">
                                <ItemTemplate>
                                    <asp:CheckBox ID="gvCheckbox" runat="server" />
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
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="50px" OnClientClick="javascript:return ValidateDelete();"
                        Visible="False" Font-Size="X-Small" OnClick="btnDelete_Click" />
                &nbsp;<asp:Button ID="btnClose" runat="server" CausesValidation="False" 
                        Font-Size="X-Small" Text="Close" Visible="False" />
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="4" >
                    <asp:HiddenField ID="hdnJQueryDate" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of First Tab -->
     
    <!-- Second Tab -->
    <div id="tabs-2">
        <table style="width: 100%;" border="0px">
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td valign="top">Agent:</td>
                <td valign="top">
                    <asp:ListBox ID="lboAgentSave" runat="server" Height="100px" Width="300px">
                        <asp:ListItem>Agent 1</asp:ListItem>
                        <asp:ListItem>Agent 2</asp:ListItem>
                        <asp:ListItem>Agent 3</asp:ListItem>
                        <asp:ListItem>Agent 4</asp:ListItem>
                        <asp:ListItem>Bedok Secondary School</asp:ListItem>
                        <asp:ListItem>Yishun Secondary School</asp:ListItem>
                    </asp:ListBox>
                    <asp:Label ID="lblAgent" runat="server"></asp:Label>                    
                </td>
                <td valign="top">Description:</td>
                     <td ><asp:TextBox ID="txtDescriptionSave" runat="server" Width="184px" height="100px" 
                             TextMode="MultiLine"></asp:TextBox>
                         
                         </td>
            </tr>
            <tr>
                <td  valign="top">
                    Invoice Code:</td>
                <td valign="top">
                    <asp:DropDownList ID="ddlInvoiceCodeSave" runat="server" Width="185px">
                    </asp:DropDownList>
                </td>
                <td>Reason Code:</td>
                <td>
                    <asp:DropDownList ID="ddlReasonCodeSave" runat="server" Width="185px">
                         </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td >
                    Attention:</td>
                <td>
                    <asp:TextBox ID="txtAttention" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td >GST:</td>
                <td >
                    <asp:DropDownList ID="ddlGST" runat="server" Width="185px">
                    <asp:ListItem>NO</asp:ListItem>
                    <asp:ListItem>INC</asp:ListItem>
                    <asp:ListItem>EXC</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td >
                    Amount:</td>
                     <td >
                         <asp:TextBox ID="txtAmount" runat="server">0.0</asp:TextBox>
                         <asp:RangeValidator ID="rvAmount" runat="server" ControlToValidate="txtAmount" 
                             ErrorMessage="Must be greater than 0" ForeColor="Red" MaximumValue="999999999" 
                             MinimumValue="0.000000001"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMessageSave" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td >
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
                        Width="80px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                        Text="Cancel" Visible="False" Width="80px" />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:HiddenField ID="hdnAgentID" runat="server" />
                </td>
                <td>
                   
                    <asp:HiddenField ID="hdnCNID" runat="server" />
                </td>
                <td >
                    &nbsp;</td>
                     <td >
                         &nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <!-- End Of Second Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>
