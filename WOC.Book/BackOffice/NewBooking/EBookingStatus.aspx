<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EBookingStatus.aspx.cs" Inherits="WOC.Book.Accounts.EBookingStatus" MasterPageFile ="~/NewBooking/NewBooking.Master"%>
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
        .style4
        {
            width: 135px;
        }
        .style5
        {
            width: 146px;
        }
        .style6
        {
            width: 158px;
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
        .style15
        {
            width: 73px;
        }
        .style16
        {
            width: 222px;
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
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteAdhoc.ashx?category=" + ddlCategory + "&paremeter=" + search);
        });

        function SelectLastTab() {
            $('#tabs').tabs('select', 2); // switch to third tab
            return false;
        }
  </script>
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
          <td class="style7">
             Agent:
            </td>
          <td>
                <asp:DropDownList ID="ddlAgent" runat="server" Width="210px" 
                    AutoPostBack="True" onselectedindexchanged="ddlAgent_SelectedIndexChanged">
                       
                    </asp:DropDownList>
            </td>
            
        </tr>
       
    </table>
     <asp:Repeater id="rprAdhoc" runat="server" 
            onitemdatabound="rprAdhoc_ItemDataBound">
                  <itemtemplate>
     <table style="width:100%;">
            
            <tr>
                <td class="style1">
                   </td>
               
                <td class="style2">
                  
                </td>
                <td >&nbsp;</td>
                     <td>Item No:</td>
                      <td >
                         <asp:TextBox ID="txtItemNumber" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "Item")%>'></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    Date:</td>
                <td class="style2">
                   <asp:TextBox ID="txtAdhocBookDate" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "AdhocBookDate","{0:d}")%>'></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Trip Type:
                 </td>
                <td class="style2">
                    <asp:RadioButtonList ID="rblTripType" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Text="One Way" Selected = "true" Value="One Way"></asp:ListItem>
                        <asp:ListItem Text="Two Ways" Value="Two Ways"></asp:ListItem>
                       
                    </asp:RadioButtonList>
                </td>
                <td class="style3">
                    </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Venue:</td>
                <td class="style2">
                    From: 
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtFromVenue" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "TripFrom")%>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFromVenue" runat="server" ValidationGroup="Add" 
                        ControlToValidate="txtFromVenue" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator> </td>
                     <td>
                         To:</td>
                     <td>
                         <asp:TextBox ID="txtToVenue" runat="server" Width="185px" ValidationGroup="Add" Text = '<%# DataBinder.Eval(Container.DataItem, "TripTo")%>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvToVenue" runat="server"  ValidationGroup="Add" ControlToValidate="txtToVenue"  ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
            </tr>
               <tr>
                <td class="style1">
                    Time:</td>
                <td class="style2">
                    Depart: 
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTimeDepart" runat="server" Width="185px" ValidationGroup="Add" Text = '<%# DataBinder.Eval(Container.DataItem, "TimeDepart","{0:HHmm}")%>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTimeDepart" runat="server"  ValidationGroup="Add" ControlToValidate="txtTimeDepart" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>
                     <td>
                         Return</td>
                     <td>
                         <asp:TextBox ID="txtTimeReturn" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "TimeReturn","{0:HHmm}")%>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvTimeReturn"  ValidationGroup="Add" runat="server" ControlToValidate="txtTimeReturn" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                         </td>
            </tr>
               <tr>
                <td class="style1">
                    Seater</td>
                <td class="style2">
                  
                        <asp:TextBox ID="txtSeater" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem,"Seater")%>'></asp:TextBox>
                  
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
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
                <td class="style1">
                    Purpose:</td>
                <td class="style2" colspan="3">
                    <asp:TextBox ID="txtPurpose" runat="server" Width="481px" Text = '<%# DataBinder.Eval(Container.DataItem, "Purpose")%>'></asp:TextBox>
                </td>
                <td class="style3">&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Person In Charge:</td>
                <td class="style2">
                    <asp:TextBox ID="txtPersonInCharge" runat="server" Width="210px" Text = '<%# DataBinder.Eval(Container.DataItem, "PersonInCharge")%>'></asp:TextBox>
                </td>
                <td class="style3">
                    Contact:</td>
                     <td>
                    <asp:TextBox ID="txtContact" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "Contact")%>' ></asp:TextBox>
                 </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Driver Claim</td>
                <td class="style2">
                   <asp:TextBox ID="txtDriverClaim" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem,"DriverClaim")%>'></asp:TextBox>
                  
                </td>
                <td class="style3">
                    Cash Order</td>
                     <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList>
                 </td>
                     <td>
                         <asp:TextBox ID="TextBox30" runat="server" Width="185px"></asp:TextBox>
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
            </td>
            <td>
                &nbsp;</td>
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
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="20px" Width="245px"  
                            AutoPostBack="True">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                           <%-- <asp:ListItem Value="AdhocBookDate">Departure Date</asp:ListItem>--%>
                            <asp:ListItem Value="Agent">Agent</asp:ListItem>
                            <asp:ListItem Value="AdhocCode">Ref No</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td class="style9">
                    
                        <asp:TextBox ID="txtSearch" runat="server" Width="417px"></asp:TextBox>
                    
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
                <td colspan="3">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                        style="width: 100%;" AllowPaging="True" 
                        onpageindexchanging="gv_PageIndexChanging" DataKeyNames = "AdhocCode" 
                        onrowcommand="gv_RowCommand" onrowdatabound="gv_RowDataBound" 
                        onrowdeleting="gv_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="Agent" HeaderText="Agent" />
                            <asp:BoundField DataField="AdhocCode" HeaderText="Ref No." />
                            <asp:BoundField DataField="AdhocBookDate" dataformatstring="{0:dd/MM/yyyy}" HeaderText="Departure Date" />
                            <asp:BoundField DataField="TimeDepart" dataformatstring="{0:hh:mm tt}" HeaderText="Start Time" />
                            <asp:BoundField DataField="TimeReturn" dataformatstring="{0:hh:mm tt}" HeaderText="End Time" />
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
                <td class="style3" colspan="3" align="right">
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

     <asp:Repeater id="rprEditAdhoc" runat="server" 
            onitemdatabound="rprAdhoc_ItemDataBound">
                  <itemtemplate>
     <table style="width:100%;">
            
            <tr>
                <td class="style1">
                   </td>
               
                <td class="style2">
                  
                </td>
                <td >&nbsp;</td>
                     <td>Item No:</td>
                      <td >
                         <asp:TextBox ID="txtItemNumber" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "Item")%>'></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    Date:</td>
                <td class="style2">
                   <asp:TextBox ID="txtAdhocBookDate" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem, "AdhocBookDate","{0:d}")%>'></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Trip Type:
                 </td>
                <td class="style2">
                    <asp:RadioButtonList ID="rblTripType" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Text="One Way" Selected = "true" Value="One Way"></asp:ListItem>
                        <asp:ListItem Text="Two Ways" Value="Two Ways"></asp:ListItem>
                       
                    </asp:RadioButtonList>
                </td>
                <td class="style3">
                    </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Venue:</td>
                <td class="style2">
                    From: 
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtFromVenue" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "TripFrom")%>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFromVenue" ValidationGroup="Edit" runat="server" 
                        ControlToValidate="txtFromVenue" ErrorMessage="*" ForeColor="Red"    ></asp:RequiredFieldValidator> </td>
                     <td>
                         To:</td>
                     <td>
                         <asp:TextBox ID="txtToVenue" runat="server" Width="185px" ValidationGroup="Edit"  Text = '<%# DataBinder.Eval(Container.DataItem, "TripTo")%>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvToVenue" runat="server" ControlToValidate="txtToVenue"  ErrorMessage="*" ForeColor="Red"   ></asp:RequiredFieldValidator>
                    </td>
            </tr>
               <tr>
                <td class="style1">
                    Time:</td>
                <td class="style2">
                    Depart: 
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTimeDepart" runat="server" Width="185px" ValidationGroup="Edit" Text = '<%# DataBinder.Eval(Container.DataItem, "TimeDepart","{0:HHmm}")%>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTimeDepart" runat="server" ControlToValidate="txtTimeDepart" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Edit"   ></asp:RequiredFieldValidator>
                </td>
                     <td>
                         Return</td>
                     <td>
                         <asp:TextBox ID="txtTimeReturn" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "TimeReturn","{0:HHmm}")%>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvTimeReturn" runat="server" ControlToValidate="txtTimeReturn" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Edit" ></asp:RequiredFieldValidator>
                         </td>
            </tr>
               <tr>
                <td class="style1">
                    Seater</td>
                <td class="style2">
                    <asp:TextBox ID="txtSeater" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem,"Seater")%>'></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
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
                <td class="style1">
                    Purpose:</td>
                <td class="style2" colspan="3">
                    <asp:TextBox ID="txtPurpose" runat="server" Width="481px" Text = '<%# DataBinder.Eval(Container.DataItem, "Purpose")%>'></asp:TextBox>
                </td>
                <td class="style3">&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Person In Charge:</td>
                <td class="style2">
                    <asp:TextBox ID="txtPersonInCharge" runat="server" Width="210px" Text = '<%# DataBinder.Eval(Container.DataItem, "PersonInCharge")%>'></asp:TextBox>
                </td>
                <td class="style3">
                    Contact:</td>
                     <td>
                    <asp:TextBox ID="txtContact" runat="server" Width="185px" Text = '<%# DataBinder.Eval(Container.DataItem, "Contact")%>'></asp:TextBox>
                 </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Driver Claim</td>
                <td class="style2">
                    <asp:TextBox ID="txtDriverClaim" runat="server" Text = '<%# DataBinder.Eval(Container.DataItem,"DriverClaim")%>'></asp:TextBox>
                  
                </td>
                <td class="style3">
                    Cash Order</td>
                     <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList>
                 </td>
                     <td>
                         <asp:TextBox ID="TextBox30" runat="server" Width="185px"></asp:TextBox>
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
                        Search:</td>
                <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" 
                        Width="245px">
                            <asp:ListItem>Person In Charge</asp:ListItem>
                            <asp:ListItem>Route</asp:ListItem>
                            <asp:ListItem>Ref No</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
      
            <tr>
               <td>
                        &nbsp;</td>
                <td>
                   <asp:Button ID="Button2" runat="server" Text="Search" Width="96px" />
                </td>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <table border="1px" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:650pt" width="620">
                        <colgroup>
                            <col  />
                            <col span="2" style="width:48pt" width="64" />
                            <col  />
                            <col style="width:48pt" width="64" />
                        </colgroup>
                        <tr>
                            <td width="69" class="style5">
                                Date</td>
                            <td width="64" class="style5">
                                Person In Charge</td>
                            <td width="64" class="style5">
                                Route</td>
                            <td class="style6">
                                Contact</td>
                            <td class="style6" nowrap="nowrap">
                                Depart<br />
                                Time</td>
                            <td class="style6">
                                Return<br />
                                Time </td>
                            <td class="style6">
                                Status</td>
                            <td  width="64" class="style5">
                                Ref No</td>
                            <td  width="64" class="style5">
                                &nbsp;</td>
                            <td  width="64" class="style5">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server">Confirm</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server">Reject</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server">Confirm</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton4" runat="server">Reject</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton5" runat="server">Confirm</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton6" runat="server">Reject</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton7" runat="server">Confirm</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton8" runat="server">Reject</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton9" runat="server">Confirm</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton10" runat="server">Reject</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton11" runat="server">Confirm</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton12" runat="server">Reject</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of Fourth Tab -->
</div>
<!-- End Of Tabs -->
</asp:Content>

