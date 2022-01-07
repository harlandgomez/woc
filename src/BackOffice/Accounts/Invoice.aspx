<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="WOC.Book.Accounts.Invoice" MasterPageFile="~/Accounts/Accounts.Master" %>

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
            $("#MainContent_txtInvoiceDate").datepicker();

            if (HasQueryString()) {
                SelectLastTab();
            }
            else {
                SelectFirstTab();
            }

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

        function SelectFirstTab() {
            $('#tabs').tabs('select', 0); // switch to second tab
            return false;
        }

        function HasQueryString() {
            var field = 'InvoiceID';
            var url = window.location.href;
            if (url.indexOf('?' + field + '=') != -1)
                return 1;
            else if (url.indexOf('&' + field + '=') != -1)
                return 1;
            return 0
        }

        function ComputeTotal(erpID, surchargeID, unitID, totalID) {
            var erp = $('#' + erpID).val();
            var surcharge = $('#' + surchargeID).val();
            var unit = $('#' + unitID).val();
            var isNotNumber = false;

            if ($.isNumeric(erp) == false) {
                alert('ERP must be numeric!');
                isNotNumber = true;
                $('#' + erpID).focus();
                return false;
            }
            else if ($.isNumeric(surcharge) == false) {
                alert('Surcharge must be numeric!');
                isNotNumber = true;
                $('#' + surchargeID).focus();
                return false;
            }
            else if ($.isNumeric(unit) == false) {
                alert('Unit Price must be numeric!');
                isNotNumber = true;
                $('#' + unitID).focus();
                return false;
            }

            if (isNotNumber == false) {
                $('#' + totalID).val(parseFloat(unit) + parseFloat(surcharge) + parseFloat(erp));
            }
        }



    </script>
<!-- Begin of Tabs -->
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Prepare Invoice</a></li>
	    <li><a href="#tabs-2">Generate Invoice</a></li>
		
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
                    <asp:ListBox ID="lboAgent" runat="server" Height="100px" Width="300px"></asp:ListBox>
                    <asp:RequiredFieldValidator ID="rfvAgent" runat="server" 
                        ControlToValidate="lboAgent" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">&nbsp;</td>
                     <td class="style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Start Date:</td>
                <td class="style24">
                    <asp:TextBox ID="txtStartDate" runat="server" Width="193px"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvStartDate" runat="server" 
                        ControlToValidate="txtStartDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    End Date:</td>
                     <td class="style2">
                    <asp:TextBox ID="txtEndDate" runat="server" Width="184px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" 
                             ControlToValidate="txtEndDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                         </td>
            </tr>
            <tr>
                <td class="style4">
                   </td>
                <td>Contract: <asp:CheckBox ID="chkContract" runat="server" />&nbsp; 
                    Adhoc: <asp:CheckBox ID="chkAdhoc" runat="server" />
                </td>
                <td class="style2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
                </td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblSearchMessage" runat="server" Text="" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <table runat="server" id="tblImport" visible="false" width="100%">
                        <tr>
                            <td valign="top" >Route:</td>
                            <td>
                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width = "100%" 
                                AllowPaging="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
                                onrowcreated="gv_RowCreated" DataKeyNames="AdhocID,TimeDepart,TimeReturn" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="AdhocID" HeaderText="ID" />
                                    <asp:BoundField DataField="AdhocBookDate" HeaderText="Date" />
                                    <asp:BoundField DataField="RefNumber" HeaderText="Ref No" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" >
                                    <ItemStyle HorizontalAlign="Center" Width="85px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description" >
                                    <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Seater" HeaderText="Pax" >
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RateType" HeaderText="Rate Type" />
                                    <asp:BoundField DataField="Rates" HeaderText="Amount">
                            
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                            
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="gvCheckbox" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TimeDepart" HeaderText="StartTime" />
                                    <asp:BoundField DataField="TimeReturn" HeaderText="EndTime" />
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
                            <td valign="top" ><asp:HiddenField ID="hdnAgentPrefix" runat="server" />
                            </td>
                            <td align="right"><asp:HiddenField ID="hdnHasRegenerateID" runat="server" />
                                <asp:Button ID="btnImport" runat="server" Text="Import" onclick="btnImport_Click" Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" ><asp:HiddenField ID="hdnInvoiceCode" runat="server" /></td>
                            <td align="right">
                                <asp:DropDownList ID="ddlAddTo" runat="server" Font-Size="Small" Width="150px"></asp:DropDownList>
                                &nbsp;
                                <asp:Button ID="btnAddTo" runat="server" Text="Add To Invoice" Width="120px" onclick="btnAddTo_Click" Font-Size="Small" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:DropDownList ID="ddlReuse" runat="server" Font-Size="Small" Width="150px"></asp:DropDownList>
                                &nbsp;
                                <asp:Button ID="btnReuse" runat="server" Text="Reuse Invoice No." Width="120px" onclick="btnReuse_Click" Font-Size="Small" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of First Tab -->
     
    <!-- Second Tab -->
    <div id="tabs-2">
        <table style="width: 100%;" border="0px">
            <tr>
                <td>To:</td>
                <td><asp:TextBox ID="txtPerson1" runat="server" Width="300px"></asp:TextBox></td>
                <td>Invoice Date:</td>
                <td><asp:TextBox ID="txtInvoiceDate" runat="server" ></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInvoiceDate" 
                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Generate"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Address:</td>
                <td><asp:TextBox ID="txtAddress" runat="server" Width="300px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                <td>Remarks:</td>
                <td><asp:TextBox ID="txtRemarks" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td>Attn:</td>
                <td><asp:TextBox ID="txtAttention" runat="server" Width="300px"></asp:TextBox></td>
                <td>GST:</td>
                <td><asp:DropDownList ID="ddlGST" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td>Title:</td>
                <td colspan="3"><asp:TextBox ID="txtTitle" runat="server" Width="640px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvImported" runat="server" AutoGenerateColumns="False" 
                        Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="InvoiceDetailID,StartTime,EndTime"
                        onrowcreated="gvImported_RowCreated" 
                        onrowdatabound="gvImported_RowDataBound" >
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="BookingID" HeaderText="ID" />
                            <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                            <asp:BoundField DataField="EndTime" HeaderText="EndTime" />
                            <asp:BoundField DataField="RatesType" HeaderText="Rate Type" />
                            <asp:BoundField DataField="ItemDate" HeaderText="Date" >
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle Font-Size="Small" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RefNo" HeaderText="Ref No"  >
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle Font-Size="Small" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Time">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTime" runat="server" Text='<%# FormatTime(Eval("StartTime"), Eval("EndTime")) %>' Width="80px"  Font-Size="Small"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' Width="150px" TextMode="MultiLine"  Font-Size="Small"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pax">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPax" runat="server" Text='<%# Eval("Pax") %>' Width="20px" Font-Size="Small"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ERP">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtERP" runat="server" Width="40px" Font-Size="Small"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Surcharge">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSurcharge" runat="server" Width="40px" Font-Size="Small"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Price">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>' Width="50px" Font-Size="Small"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTotal" runat="server" Text='<%# Eval("UnitPrice") %>' Width="60px" Font-Size="Small" ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sel">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSel" runat="server" Text='<%# Eval("SortOrder") %>' Width="20px" Font-Size="Small"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="gvImportedCheckbox" runat="server" Checked="true"/>
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
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="4" align="right">

                </td>
            </tr>
            <tr>
                <td colspan="4" align="right">

                </td>
            </tr>
            <tr>
                <td colspan="4" align="right">&nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:Button ID="btnGenerate" runat="server" 
                        Text="Generate Invoice" onclick="btnGenerate_Click" Width="150px" 
                        Font-Size="Small" ValidationGroup="Generate" /></td>
            </tr>
        </table>
    </div>
    <!-- End Of Second Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>
