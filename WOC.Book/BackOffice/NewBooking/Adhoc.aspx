<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adhoc.aspx.cs" Inherits="WOC.Book.NewBooking.Adhoc" MasterPageFile ="~/NewBooking/NewBooking.Master"%>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../Controls/AgentDropdown.ascx" tagname="AgentDropdown" tagprefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 59px;
        }
        .style2
        {
            width: 243px;
        }
        .style3
        {
            width: 215px;
        }
        .style7
        {
            width: 57px;
        }
        .style8
        {
            width: 527px;
        }
        .style9
        {
            width: 558px;
        }
        .style10
        {
            width: 114px;
        }
        .style13
        {
            width: 14px;
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
            $("#MainContent_rprAdhoc_txtAdhocBookDate_0").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_1").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_2").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_3").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_4").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_5").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_6").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_7").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_8").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_9").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_10").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_11").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_12").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_13").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_14").datepicker();
            $("#MainContent_rprAdhoc_txtAdhocBookDate_15").datepicker();

            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_0").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_1").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_2").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_3").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_4").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_5").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_6").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_7").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_8").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_9").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_10").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_11").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_12").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_13").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_14").datepicker();
            $("#MainContent_rprEditAdhoc_txtAdhocBookDate_15").datepicker();

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



            $("#MainContent_txtPendingAdhocBookDate").datepicker();
            $("#MainContent_txtPendingAdhocBookDate").hide();
            $("#MainContent_cboPendingAgent_cboAgent").hide();
            $("#MainContent_txtPendingSearch").hide();

            SwitchBySelected($("#MainContent_ddlPendingCategory").val());


            $("#MainContent_ddlPendingCategory").change(function () {

                $("#MainContent_txtPendingAdhocBookDate").hide();
                $("#MainContent_cboPendingAgent_cboAgent").hide();
                $("#MainContent_txtPendingSearch").hide();
                SwitchBySelected(this.value);
            });
        });

        function SwitchBySelected(selectedValue) {
            switch (selectedValue) {
                case 'AdhocBookDate':
                    $("#MainContent_txtPendingAdhocBookDate").show();
                    break;
                case 'Pending':
                    $("#MainContent_cboPendingAgent_cboAgent").show();
                    $("#MainContent_txtPendingAdhocBookDate").val('');
                    $("#MainContent_txtPendingSearch").val('');
                    break;
                case 'Confirm':
                    $("#MainContent_cboPendingAgent_cboAgent").show();
                    $("#MainContent_txtPendingAdhocBookDate").val('');
                    $("#MainContent_txtPendingSearch").val('');
                    break;
                case 'Route':
                    $("#MainContent_txtPendingSearch").show();
                    break;
            }
        }

        function SelectLastTab() {
            $('#tabs').tabs('select', 2); // switch to third tab
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
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteAdhoc.ashx?category=" + val + "&paremeter=" + txtSearch);

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
	    <li><a href="#tabs-1">Adhoc Booking</a></li>
	    <li><a href="#tabs-2">Adhoc Search</a></li>
        <li><a href="#tabs-3">Adhoc Update</a></li>
		<li><a href="#tabs-4">Pending E-booking</a></li>	
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
    <h3>
       Add New Adhoc Booking
    </h3>
     <table style="width:100%;">
        <tr>
          <td>
             Agent:
            </td>
            <td>
                <asp:DropDownList ID="ddlAgent" runat="server" Width="210px" AutoPostBack="True" onselectedindexchanged="ddlAgent_SelectedIndexChanged">   
                </asp:DropDownList>
            </td>
            
        </tr>
       
    </table>
    <asp:Repeater id="rprAdhoc" runat="server" onitemdatabound="rprAdhoc_ItemDataBound" OnItemCommand="rprAdhoc_ItemCommand" >
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
                        <asp:TextBox ID="txtAdhocBookDate" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "AdhocBookDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
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
        <h3>Search By Category</h3>
        <table style="width: 100%;">
      
            <tr>
               <td class="style10">
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="20px" Width="245px">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                         
                            <asp:ListItem Value="Agent">Agent</asp:ListItem>
                            <asp:ListItem Value="AdhocCode">Ref No</asp:ListItem>
                            <asp:ListItem Value="AdhocBookDate">Departure Date</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td runat="server" id = "tdSearch">
                     <asp:TextBox ID="txtSearch" runat="server" Width="400px" CssClass="SearchText"></asp:TextBox>
                </td>
                <td class="style9" runat="server" id = "tdDepartureDateFrom">
                    From <asp:TextBox ID="txtFromDate" runat="server" 
                        Width="200px"></asp:TextBox>

                </td>
                <td class="style9" runat="server" id = "tdDepartureDateTo">
                    To <asp:TextBox ID="txtToDate" runat="server" 
                        Width="200px"></asp:TextBox>

                </td>
                <td>
                        <asp:DropDownList ID="ddlPagingNumber" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPagingNumber_SelectedIndexChanged">
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
               <td class="style10">
                        &nbsp;</td>
                <td class="style9">
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnSearch_Click" CausesValidation="False" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                        style="width: 100%;" AllowPaging="True" 
                        onpageindexchanging="gv_PageIndexChanging" DataKeyNames = "AdhocCode" 
                        onrowcommand="gv_RowCommand" onrowdatabound="gv_RowDataBound"   OnRowDeleting="gv_RowDeleting"
>
                        <Columns>
                            <asp:BoundField DataField="Agent" HeaderText="Agent" />
                            <asp:BoundField DataField="AdhocCode" HeaderText="Ref No." />
                            <asp:BoundField DataField="AdhocBookDate" dataformatstring="{0:dd/MM/yyyy}" HeaderText="Departure Date" />
                            <asp:BoundField DataField="TimeDepart" dataformatstring="{0:HHmm}" HeaderText="Start Time" />
                            <asp:BoundField DataField="TimeReturn" dataformatstring="{0:HHmm}" HeaderText="End Time" />
                            <asp:BoundField DataField="Destination" HeaderText="Destination" />
                            <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                            <asp:BoundField DataField="PersonInCharge" HeaderText="Person In Charge" />
                            <asp:BoundField DataField="Contact" HeaderText="Contact" />
                            <asp:CommandField SelectText="Void" DeleteText="Void" ShowDeleteButton="True" />
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Voided" >
                            <ControlStyle Width="0px" />
                            <FooterStyle Width="0px" />
                            <HeaderStyle Width="0px" />
                            <ItemStyle Width="0px" />
                            </asp:BoundField>
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
                <td  colspan="3" align="right">
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
         <h3>
       Update Adhoc Booking
    </h3>
     <table style="width:100%;">
        <tr>
          <td class="style13">
             Agent:
            </td>
          <td class="style16">
                <asp:DropDownList ID="ddlEditAgent" runat="server" Width="210px" 
                    AutoPostBack="True" onselectedindexchanged="ddlAgent_SelectedIndexChanged">
                       
                    </asp:DropDownList>
            </td>

             <td class="style15">
                 Ref No:</td>

             <td class="style7">
                 <asp:TextBox ID="txtAdhocCode" runat="server" style="margin-left: 0px" Enabled = "false"></asp:TextBox>
            </td>
            
        </tr>


       
    </table>

     <asp:Repeater id="rprEditAdhoc" runat="server"  onitemdatabound="rprEditAdhoc_ItemDataBound"  onitemcommand="rprEditAdhoc_ItemCommand">
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
                        <asp:TextBox ID="txtAdhocBookDate" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "AdhocBookDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
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
    <!-- End Of Third Tab -->

    <!-- Fourth Tab -->
    <div id="tabs-4">
        <h3>Confirm/Reject E-Booking</h3>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlPendingCategory" runat="server" Height="20px" Width="245px">
                        <asp:ListItem Value="AdhocBookDate">Date Book</asp:ListItem>
                        <asp:ListItem Value="Pending" Selected="True">Pending</asp:ListItem>
                        <asp:ListItem Value="Confirm">Confirm</asp:ListItem>
                        <asp:ListItem Value="Route">Route</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtPendingAdhocBookDate" runat="server" Width="400px"></asp:TextBox>
                    <asp:TextBox ID="txtPendingSearch" runat="server" Width="400px"></asp:TextBox>
                    <uc1:AgentDropdown ID="cboPendingAgent" runat="server"  Width="406px" />
                </td>
                <td >
                    <asp:DropDownList ID="ddlPendingPaging" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPagingNumber_SelectedIndexChanged">
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
                    <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="False" Font-Size="X-Small"
                        style="width: 100%;" AllowPaging="True" DataKeyNames="adhoccode" ShowFooter="True"
                        onpageindexchanging="gvPending_PageIndexChanging" 
                        onrowcreated="gvPending_RowCreated" 
                        onrowdatabound="gvPending_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Agent" HeaderText="Agent" >
                            <ItemStyle Width="100px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="adhocbookdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
                            <asp:BoundField DataField="PersonInCharge" HeaderText="In Charge" />
                            <asp:BoundField DataField="contact" HeaderText="Contact" />
                            <asp:BoundField DataField="timedepart" DataFormatString="{0:HHmm}" 
                                HeaderText="Depart Time" />
                            <asp:BoundField DataField="timereturn" DataFormatString="{0:HHmm}" HeaderText="Depart To" />
                            <asp:BoundField DataField="Destination" HeaderText="Route">
                            <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="adhoccode" HeaderText="Ref No" />
                            <asp:TemplateField ItemStyle-Width="36px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkConfirm" runat="server" ToolTip="Tick to confirm/reject booking" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imgConfirm" runat="server" onclick="imgConfirm_Click" 
                                    ImageUrl="~/Images/MiscIcons/Tick.png" ToolTip="Confirm Booking" />
                                    <asp:ImageButton ID="imgReject" runat="server" onclick="imgReject_Click" 
                                    ImageUrl="~/Images/MiscIcons/Cancel.png" ToolTip="Reject Booking" />
                                </FooterTemplate>
                                <ItemStyle Width="38px"></ItemStyle>
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
    <!-- End Of Fourth Tab -->
</div>
<!-- End Of Tabs -->
</asp:Content>

