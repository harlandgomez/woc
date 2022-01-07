<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Driver.aspx.cs" Inherits="WOC.Book.Driver" MasterPageFile="~/Registration/Registration.Master" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 59px;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            width: 286px;
        }
        .style5
        {
            width: 80px;
            height: 24px;
        }
        .style6
        {
            width: 286px;
            height: 24px;
        }
        .style7
        {
            height: 24px;
        }
        .style10
        {
            width: 80px;
            height: 30px;
        }
        .style11
        {
            width: 286px;
            height: 30px;
        }
        .style12
        {
            height: 30px;
        }
        .style13
        {
            width: 80px;
        }
        .style14
        {
            width: 245px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtDateJoin").datepicker();
            $("#MainContent_txtEditDateJoin").datepicker();
            $("#MainContent_txtExpiry1").datepicker();
            $("#MainContent_txtExpiry2").datepicker();
            $("#MainContent_txtExpiry3").datepicker();
            $("#MainContent_txtEditExpiry1").datepicker();
            $("#MainContent_txtEditExpiry2").datepicker();
            $("#MainContent_txtEditExpiry3").datepicker();
            $("#MainContent_txtResignedDate").datepicker();

            $("#MainContent_txtDOB").datepicker({
                changeMonth: true,
                changeYear: true,
                gotoCurrent: true,
                defaultDate: '-18y',
                yearRange: '1920:2000'
            });

            $("#MainContent_txtEditDOB").datepicker({
                changeMonth: true,
                changeYear: true,
                gotoCurrent: true,
                defaultDate: '-18y',
                yearRange: '1920:2000'
            });

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
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteDriver.ashx?category=" + ddlCategory + "&paremeter=" + search);

            var search = document.getElementById('MainContent_txtBusNumber').value;
            $('#MainContent_txtBusNumber').autocomplete("../AutocompleteData/AutocompleteBus.ashx?category=BusNo&paremeter=" + search);

            var search = document.getElementById('MainContent_txtEditBusNumber').value;
            $('#MainContent_txtEditBusNumber').autocomplete("../AutocompleteData/AutocompleteBus.ashx?category=BusNo&paremeter=" + search);
            
        });
        

        function SelectLastTab() {
            $('#tabs').tabs('select', 2); // switch to third tab
            return false;
        }

        function SelectTab(tab) {
            $('#tabs').tabs('select', (tab - 1)); // switch to third tab
            return false;
        }

       </script>
<!-- Begin of Tabs -->
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Driver Registration</a></li>
	    <li><a href="#tabs-2">Driver Search</a></li>
        <li><a href="#tabs-3">Driver Update</a></li>
			
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
    <h3>
       Add New Driver Registration
    </h3>

     <table style="width:100%;">
            <tr>
                <td class="style13">
                    Name:</td>
                <td class="style4">
                    <asp:TextBox ID="txtName" runat="server" Width="253px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red" 
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
                <td class="style13">
                    IC/Fin:</td>
                <td class="style4">
                    <asp:TextBox ID="txtFIN" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    Address:</td>
                <td class="style6">
                    <asp:TextBox ID="txtAddress1" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style7">
                    </td>
                     <td class="style7">
                         </td>
                     <td class="style7">
                         </td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style4">
                    <asp:TextBox ID="txtAddress2" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style4">
                    <asp:TextBox ID="txtAddress3" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style13">
                    Contact:</td>
                <td class="style4">
                    <asp:TextBox ID="txtContact" runat="server" Width="254px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtContact" ErrorMessage="*" ForeColor="Red" 
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
                <td class="style13">
                    Date Join</td>
                <td class="style4">
                    <asp:TextBox ID="txtDateJoin" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style13">
                    DOB</td>
                <td class="style4">
                    <asp:TextBox ID="txtDOB" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style10">
                    Country</td>
                <td class="style11">
                         <telerik:RadComboBox ID="cboCountry" Runat="server" Width="194px" 
                             MarkFirstMatch="True">
                         </telerik:RadComboBox>
                </td>
                <td class="style12">
                    &nbsp;</td>
                     <td>&nbsp;</td>
                     <td class="style12">
                         </td>
            </tr>
               <tr>
                <td class="style13">
                    Bus no</td>
                <td class="style4">
                    <asp:DropDownList ID="ddlBusNumber" runat="server" Height="20px" Width="200px">
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style13">
                    Passes</td>
                <td class="style4">
                    <asp:TextBox ID="txtPasses1" runat="server" Width="182px"></asp:TextBox>
                </td>
                <td class="style3">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtExpiry1" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style13">
                    Passes</td>
                <td class="style4">
                    <asp:TextBox ID="txtPasses2" runat="server" Width="182px"></asp:TextBox>
                </td>
                <td class="style3">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtExpiry2" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style13">
                    Passes</td>
                <td class="style4">
                    <asp:TextBox ID="txtPasses3" runat="server" Width="181px"></asp:TextBox>
                </td>
                <td class="style3">
                    Expiry</td>
                     <td style="font-weight: 700">
                    <asp:TextBox ID="txtExpiry3" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                   </td>
                <td class="style2" colspan="3">
                   
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="77px" 
                        onclick="btnAdd_Click" ValidationGroup="Add" />
                   
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
               <td class="style14">
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="20px" Width="245px"  AutoPostBack="True">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem Value="DriverName">Name</asp:ListItem>
                            <asp:ListItem Value="FIN">IC/FIN</asp:ListItem>
                            <asp:ListItem Value="Contact">Contact</asp:ListItem>
                            <asp:ListItem Value="DOB">DOB</asp:ListItem>
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
                <td>
                    &nbsp;
                </td>
            </tr>
      
            <tr>
               <td class="style14">
                        &nbsp;</td>
                <td>
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnSearch_Click" CausesValidation="False" />
                </td>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        DataKeyNames = "DriverCode" onrowcommand="gv_RowCommand" Width="100%" 
                        onpageindexchanging="gv_PageIndexChanging" onrowdatabound="gv_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DriverName" HeaderText="Name" />
                            <asp:BoundField DataField="FIN" HeaderText="FIN" />
                            <asp:BoundField DataField="Contact" HeaderText="Contact" />
                            <asp:BoundField DataField="DOB" HeaderText="DOB" />
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
                <td colspan="4" align="right">
                    <asp:ImageButton ID="ibtnListAllPDF" runat="server" ImageUrl="~/Images/MenuIcons/pdf_icon.png" Height="20px" Width="20px" CausesValidation="False" onclick="ibtnListAllPDF_Click" />
                    <asp:Image ID="imgSeparator" runat="server" ImageUrl="~/Images/MenuIcons/separator_icon.png" Height="20px" Width="5px"/>                
                    <asp:ImageButton ID="ibtnListAll" runat="server" ImageUrl="~/Images/MenuIcons/excel_icon.png" Height="20px" onclick="ibtnListAll_Click" Width="20px" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of Second Tab -->

    <!-- Third Tab -->
    <div id="tabs-3">
     <h3>Driver Registration Card</h3>
          <table style="width:100%;">
           
             <tr>
                <td class="style13">
                    Driver Code</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditCode" runat="server" Width="253px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style13">
                    Name:</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditName" runat="server" Width="253px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEditName" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                    IC/Fin:</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditFIN" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    Address:</td>
                <td class="style6">
                    <asp:TextBox ID="txtEditAddress1" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style7">
                    </td>
                     <td class="style7">
                         </td>
                     <td class="style7">
                         </td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditAddress2" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditAddress3" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style13">
                    Contact:</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditContact" runat="server" Width="254px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEditContact" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style13">
                    Date Join</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditDateJoin" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style13">
                    DOB</td>
                <td class="style4">
                    <asp:TextBox ID="txtEditDOB" runat="server" Width="254px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style10">
                    Country</td>
                <td class="style11">
                    <telerik:RadComboBox ID="cboEditCountry" Runat="server" MarkFirstMatch="True" 
                        Width="262px">
                    </telerik:RadComboBox>
                </td>
                <td class="style12">
                    </td>
                     <td class="style12">
                         </td>
                     <td class="style12">
                         </td>
            </tr>

               <tr>
                <td class="style1">
                    Bus no</td>
                <td class="style2">
                    <asp:DropDownList ID="ddlEditBusNumber" runat="server" Height="20px" 
                        Width="200px">
                    </asp:DropDownList>
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
                    Passes</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditPasses1" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style3">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtEditExpiry1" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditPasses2" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style3">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtEditExpiry2" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes</td>
                <td class="style2">
                    <asp:TextBox ID="txtEditPasses3" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style3">
                    Expiry</td>
                     <td style="font-weight: 700">
                    <asp:TextBox ID="txtEditExpiry3" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Resigned</td>
                <td class="style2">
                    <asp:RadioButtonList ID="rdlResigned" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style3">
                    Date</td>
                     <td style="font-weight: 700">
                    <asp:TextBox ID="txtResignedDate" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                   
                    <asp:Button ID="btnConfirm" runat="server" onclick="btnConfirm_Click" 
                        Text="Confirm" ValidationGroup="Edit" />
                   
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="77px" 
                        onclick="btnDelete_Click" />
                   
                    <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of Third Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>

