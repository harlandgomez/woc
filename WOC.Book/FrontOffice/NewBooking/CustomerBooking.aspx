<%@ Page Title="" Language="C#" MasterPageFile="~/NewBooking/NewBooking.Master" AutoEventWireup="true" CodeBehind="CustomerBooking.aspx.cs" Inherits="FrontOffice.NewBooking.CustomerBooking" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style8
        {
            width: 527px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_rprCustomer_txtCustomerBookDate_0").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_1").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_2").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_3").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_4").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_5").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_6").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_7").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_8").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_9").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_10").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_11").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_12").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_13").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_14").datepicker();
            $("#MainContent_rprCustomer_txtCustomerBookDate_15").datepicker();

            $("#MainContent_rprEditCustomer_txtCustomerBookDate_0").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_1").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_2").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_3").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_4").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_5").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_6").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_7").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_8").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_9").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_10").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_11").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_12").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_13").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_14").datepicker();
            $("#MainContent_rprEditCustomer_txtCustomerBookDate_15").datepicker();

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
        });

        function SelectEditTab() {
            $('#tabs').tabs('select', 1); // switch to edit tab
            return false;
        }
        function checkNumeric(txt) {

            var s_len = txt.value.length;

            var s_charcode = 0;

            for (var s_i = 0; s_i < s_len; s_i++) {
                s_charcode = txt.value.charCodeAt(s_i);
                if (!((s_charcode >= 48 && s_charcode <= 57))) {
                    alert("Only Numeric Values Allowed");
                    txt.value = '';
                    txt.focus();
                    return false;
                }
            }
            return true;

        }
        function EnableReturn(txtTimeDepart, txtTimeReturn) {
            document.getElementById(txtTimeReturn).disabled = false;

        }
        function DisableReturn(txtTimeDepart, txtTimeReturn) {

            document.getElementById(txtTimeReturn).disabled = true;
        }

        function SwitchControl() {
            var val = $('#MainContent_ddlCategory').val();
            var fromDate = $('#MainContent_tdDepartureDateFrom');
            var toDate = $('#MainContent_tdDepartureDateTo');
            var search = $('#MainContent_tdSearch');

            var txtSearch = $('MainContent_txtSearch').value;
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteCustomer.ashx?category=" + val + "&paremeter=" + txtSearch);

            switch (val.toString()) {
                case "AdhocBookDate":
                    $("#MainContent_txtFromDate").datepicker();
                    $("#MainContent_txtToDate").datepicker();

                    fromDate.show();
                    toDate.show();
                    search.hide();
                    break;
                default:
                    fromDate.hide();
                    toDate.hide();
                    search.show();
                    break;
            }
        }
  </script>
   <div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
   </div>
<!-- Begin of Tabs -->
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Customer Booking</a></li>
        <li><a href="#tabs-2">Customer Update</a></li>
		<li><a href="#tabs-3">Pending E-booking</a></li>	
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
    <h3>
        New Booking<asp:HiddenField ID="hdnAgentID" runat="server" />
    </h3>
    <asp:Repeater id="rprCustomer" runat="server" onitemdatabound="rprCustomer_ItemDataBound" OnItemCommand="rprCustomer_ItemCommand" >
        <itemtemplate>
            <table style="width:100%;">
                <tr>
                    <td >
                        Date:</td>
                    <td >
                        <asp:TextBox ID="txtCustomerBookDate" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "AdhocBookDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                    </td>
                    <td > Item No:</td>
                    <td style="font-weight: bold"><asp:Label ID="lblItemNumber" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "Item")%>'></asp:Label></td>
                    <td align="right">
                        <asp:ImageButton ID="btnDeleteItem" runat="server" ImageUrl="../Images/MiscIcons/DeleteRule.png" Height="20px" Width="20px" 
                            CommandName="Delete" CommandArgument='<%# Eval("Item") %>' ToolTip="Delete this trip" AlternateText="Delete" />
                    </td>
                </tr>
                <tr>
                    <td>Trip Type:</td>
                    <td >
                        <asp:RadioButtonList ID="rblTripType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="One Way"  Value="One Way"></asp:ListItem>
                            <asp:ListItem Text="Two Ways" Selected = "true" Value="Two Ways"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table width="100%">
                            <tr>
                                <td >
                                    Venue:</td>
                                <td >
                                    From: 
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtFromVenue" runat="server" Width="240px" Text = '<%# DataBinder.Eval(Container.DataItem, "TripFrom")%>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvFromVenue" runat="server" ValidationGroup="Add" ControlToValidate="txtFromVenue" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>
                                  </td>
                                <td></td>
                                <td>To:</td>
                                <td>
                                    <asp:TextBox ID="txtToVenue" runat="server" Width="240px" ValidationGroup="Add" Text = '<%# DataBinder.Eval(Container.DataItem, "TripTo")%>'></asp:TextBox><asp:RequiredFieldValidator ID="rfvToVenue" runat="server"  ValidationGroup="Add" ControlToValidate="txtToVenue"  ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                                <tr>
                                <td>Time:</td>
                                <td>Depart:</td>
                                <td>
                                    <asp:TextBox ID="txtTimeDepart" MaxLength = "4" runat="server" Width="80px" onChange='checkNumeric(this)' ValidationGroup="Add" Text = '<%# DataBinder.Eval(Container.DataItem, "TimeDepart","{0:HHmm}")%>'></asp:TextBox>
                                </td>
                                <td><asp:RequiredFieldValidator ID="rfvTimeDepart" runat="server"  ValidationGroup="Add" ControlToValidate="txtTimeDepart" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                                <td>Return:</td>
                                <td>
                                    <asp:TextBox ID="txtTimeReturn" MaxLength = "4"  runat="server" Width="80px"  onChange='checkNumeric(this)' Text = '<%# DataBinder.Eval(Container.DataItem, "TimeReturn","{0:HHmm}")%>'></asp:TextBox>
                                </td>
                                <td><asp:RequiredFieldValidator ID="rfvTimeReturn"  ValidationGroup="Add" runat="server" ControlToValidate="txtTimeReturn" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
                            </tr>  
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>Seater</td>
                    <td>
                        <asp:TextBox ID="txtSeater" runat="server" onChange='checkNumeric(this)' MaxLength = "4" Text = '<%# DataBinder.Eval(Container.DataItem,"Seater")%>'></asp:TextBox>
                    </td>
                    <td>Purpose:</td>
                    <td colspan="3"><asp:TextBox ID="txtPurpose" runat="server" Width="480px" Text = '<%# DataBinder.Eval(Container.DataItem, "Purpose")%>'></asp:TextBox></td>
                </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                <tr>
                    <td nowrap="nowrap">In Charge:</td>
                    <td>
                        <asp:TextBox ID="txtPersonInCharge" runat="server" Width="210px" Text = '<%# DataBinder.Eval(Container.DataItem, "PersonInCharge")%>'></asp:TextBox>
                    </td>
                    <td>Contact:</td>
                    <td>
                        <asp:TextBox ID="txtContact" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "Contact")%>' ></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Driver Claim</td>
                    <td>
                        <asp:TextBox ID="txtDriverClaim" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem,"DriverClaim")%>'></asp:TextBox>
                    </td>
                    <td nowrap="nowrap">Cash Order</td>
                    <td>
                        <asp:RadioButtonList ID="rblCashOrder" runat="server" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCashOrder" runat="server" Width="185px" onChange='checkNumeric(this)' MaxLength = "16"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </itemtemplate>
        <separatortemplate>
            <hr>
        </separatortemplate>
       </asp:Repeater> 
     <table>
        <tr>
            <td>
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" 
                    onclick="btnConfirm_Click" ValidationGroup="Add" />
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Width="75px" 
                    onclick="btnAdd_Click"   ValidationGroup="Add" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="75px" 
                    onclick="btnClear_Click" CausesValidation="False" />
            </td>
            <td class="style8">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:HiddenField ID="hdnSavedCode" runat="server" />
            </td>
            <td>&nbsp;</td>
        </tr>
       
    </table>

    </div>
    <!-- End Of First Tab -->
 

    <!-- Second Tab -->
    <div id="tabs-2">
    <h3>
        Update Booking (Ref No: <asp:Label ID="lblCustomerCode" runat="server" style="margin-left: 0px" Enabled = "false"></asp:Label> )
        <asp:HiddenField ID="hdnEditAgentID" runat="server" />
    </h3>
     <asp:Repeater id="rprEditCustomer" runat="server"  onitemdatabound="rprEditCustomer_ItemDataBound"  onitemcommand="rprEditCustomer_ItemCommand">
        <itemtemplate>
        <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td >
                        Date:</td>
                    <td >
                        <asp:TextBox ID="txtCustomerBookDate" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "AdhocBookDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                    </td>
                    <td > Item No:</td>
                    <td style="font-weight: bold"><asp:Label ID="lblItemNumber" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "Item")%>'></asp:Label></td>
                    <td align="right">
                        <asp:ImageButton ID="btnDeleteItem" runat="server" ImageUrl="../Images/MiscIcons/DeleteRule.png" Height="20px" Width="20px" 
                            CommandName="Delete" CommandArgument='<%# Eval("Item") %>' ToolTip="Delete this trip" AlternateText="Delete" />
                    </td>
                </tr>
                <tr>
                    <td>Trip Type:</td>
                    <td >
                        <asp:RadioButtonList ID="rblTripType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="One Way"  Value="One Way"></asp:ListItem>
                            <asp:ListItem Text="Two Ways" Selected = "true" Value="Two Ways"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table width="100%">
                            <tr>
                                <td >
                                    Venue:</td>
                                <td >
                                    From: 
                                </td>
                                <td >
                                    <asp:TextBox ID="txtFromVenue" runat="server" Width="240px" Text = '<%# DataBinder.Eval(Container.DataItem, "TripFrom")%>'></asp:TextBox>
                                  </td>
                                <td><asp:RequiredFieldValidator ID="rfvFromVenue" runat="server" ValidationGroup="Add" ControlToValidate="txtFromVenue" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator> </td>
                                <td>To:</td>
                                <td>
                                    <asp:TextBox ID="txtToVenue" runat="server" Width="240px" ValidationGroup="Add" Text = '<%# DataBinder.Eval(Container.DataItem, "TripTo")%>'></asp:TextBox>
                                </td>
                                <td><asp:RequiredFieldValidator ID="rfvToVenue" runat="server"  ValidationGroup="Add" ControlToValidate="txtToVenue"  ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
                            </tr>
                                <tr>
                                <td>Time:</td>
                                <td>Depart:</td>
                                <td>
                                    <asp:TextBox ID="txtTimeDepart" MaxLength = "4" runat="server" Width="80px" onChange='checkNumeric(this)' ValidationGroup="Add" Text = '<%# DataBinder.Eval(Container.DataItem, "TimeDepart","{0:HHmm}")%>'></asp:TextBox>
                                </td>
                                <td><asp:RequiredFieldValidator ID="rfvTimeDepart" runat="server"  ValidationGroup="Add" ControlToValidate="txtTimeDepart" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                                <td>Return:</td>
                                <td>
                                    <asp:TextBox ID="txtTimeReturn" MaxLength = "4"  runat="server" Width="80px"  onChange='checkNumeric(this)' Text = '<%# DataBinder.Eval(Container.DataItem, "TimeReturn","{0:HHmm}")%>'></asp:TextBox>
                                </td>
                                <td><asp:RequiredFieldValidator ID="rfvTimeReturn"  ValidationGroup="Add" runat="server" ControlToValidate="txtTimeReturn" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
                            </tr>  
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>Seater</td>
                    <td>
                        <asp:TextBox ID="txtSeater" runat="server" onChange='checkNumeric(this)' MaxLength = "4" Text = '<%# DataBinder.Eval(Container.DataItem,"Seater")%>'></asp:TextBox>
                    </td>
                    <td>Purpose:</td>
                    <td colspan="3"><asp:TextBox ID="txtPurpose" runat="server" Width="480px" Text = '<%# DataBinder.Eval(Container.DataItem, "Purpose")%>'></asp:TextBox></td>
                </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                <tr>
                    <td nowrap="nowrap">In Charge:</td>
                    <td>
                        <asp:TextBox ID="txtPersonInCharge" runat="server" Width="210px" Text = '<%# DataBinder.Eval(Container.DataItem, "PersonInCharge")%>'></asp:TextBox>
                    </td>
                    <td>Contact:</td>
                    <td>
                        <asp:TextBox ID="txtContact" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "Contact")%>' ></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Driver Claim</td>
                    <td>
                        <asp:TextBox ID="txtDriverClaim" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem,"DriverClaim")%>'></asp:TextBox>
                    </td>
                    <td nowrap="nowrap">Cash Order</td>
                    <td>
                        <asp:RadioButtonList ID="rblCashOrder" runat="server"
                            RepeatDirection="Horizontal">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCashOrder" runat="server" Width="185px" onChange='checkNumeric(this)' MaxLength = "16"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </itemtemplate>
        <separatortemplate>
            <hr>
        </separatortemplate>
       </asp:Repeater> 
     <table>
        <tr>
          <td>
              <asp:Button ID="btnEditConfirm" runat="server" Text="Update" 
                  onclick="btnEditConfirm_Click" />
                &nbsp;<asp:Button ID="btnEditAdd" runat="server" Text="Add" Width="75px" 
                  onclick="btnEditAdd_Click" ValidationGroup="Edit" />
            </td>
          <td class="style8">
                <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
       
    </table>

    </div>
    <!-- End Of Second Tab -->

    <!-- Third Tab -->
    <div id="tabs-3">
     <h3>Confirm/Pending Booking</h3>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlPendingCategory" runat="server" Height="20px" Width="245px">
                        <asp:ListItem Value="All">All Booking</asp:ListItem>
                        <asp:ListItem Value="Pending" Selected>Pending</asp:ListItem>
                        <asp:ListItem Value="Confirm">Confirm</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                        <asp:TextBox ID="txtPendingSearch" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td >
                <asp:DropDownList ID="ddlPendingPaging" runat="server" >
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
                <td>
                    &nbsp;</td>
                <td>
                   <asp:Button ID="btnPendingSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnPendingSearch_Click" />
                </td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                        style="width: 100%;" AllowPaging="True" DataKeyNames="adhoccode" 
                        onrowcommand="gv_RowCommand" onrowdatabound="gv_RowDataBound" >
                        <Columns>
                            <asp:BoundField DataField="Adhocbookdate" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderText="Date" />
                            <asp:BoundField DataField="PersonInCharge" HeaderText="Person In Charge" />
                            <asp:BoundField DataField="contact" HeaderText="Contact" />
                            <asp:BoundField DataField="timedepart" DataFormatString="{0:HHmm}" 
                                HeaderText="Depart Time" />
                            <asp:BoundField DataField="timereturn" DataFormatString="{0:HHmm}" 
                                HeaderText="Depart To" />
                            <asp:BoundField DataField="Destination" HeaderText="Route">
                            <ItemStyle Width="300px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="adhoccode" HeaderText="Ref No" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete" ImageUrl="~/Images/MiscIcons/DeleteRule.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandName="Select" ImageUrl="~/Images/MiscIcons/Edit.png" CommandArgument='<%# Eval("AdhocCode") %>'/>
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
        </table>
    </div>
    <!-- End Of Third Tab -->
</div>
<!-- End Of Tabs -->
</asp:Content>