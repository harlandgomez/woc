<%@ Page Title="" Language="C#" MasterPageFile="~/Registration/Registration.Master" AutoEventWireup="true" CodeBehind="Agent.aspx.cs" Inherits="WOC.Book.Agent" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 285px;
        }
        .style3
        {
        }
        .style4
        {
            width: 156px;
        }
        .style5
        {
            width: 156px;
            height: 26px;
        }
        .style6
        {
            width: 331px;
            height: 26px;
        }
        .style7
        {
            width: 285px;
            height: 26px;
        }
        .style8
        {
            width: 408px;
        }
        .style9
        {
            width: 128px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
    $(document).ready(function () {

        $("#MainContent_txtStopDate").datepicker();
        $("#MainContent_txtEditStopDate").datepicker();
        
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
        $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteAgent.ashx?category=" + ddlCategory + "&paremeter=" + search);
        $('#MainContent_txtPrefix').autocomplete("../AutocompleteData/AutocompletePrefixCode.ashx");
        $('#MainContent_txtEditPrefix').autocomplete("../AutocompleteData/AutocompletePrefixCode.ashx");
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
	    <li><a href="#tabs-1">Agent Registration</a></li>
	    <li><a href="#tabs-2">Agent Search</a></li>
        <li><a href="#tabs-3">Agent Update</a></li>
			
    </ul>
    <div>
        <asp:Label ID="lblSysMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <!-- First Tab -->
    <div id="tabs-1">
    <h3>Add New Agent Registration</h3>
    <telerik:RadAjaxLoadingPanel ID="rlpnlAdd" runat="server" Skin="Default" />
    <telerik:RadAjaxPanel ID="rpnlAdd" runat="server" Height="100%" Width="100%" LoadingPanelID="rlpnlAdd"  >
    <table style="width:100%;">
            <tr>
                <td class="style4">
                    Agent:</td>
                <td class="style3">
                    <asp:TextBox ID="txtAgent" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtAgent" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    &nbsp;</td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
            <tr>
                <td>Prefix:</td>
                <td><asp:TextBox ID="txtPrefix" runat="server" Width="149px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrefix" runat="server" 
                        ControlToValidate="txtPrefix" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    Postal Code:</td>
                     <td class="style7">
                    <asp:TextBox ID="txtPostalCode" runat="server" Width="184px"></asp:TextBox>
                         </td>
            </tr>
            <tr>
                <td class="style4">
                    Address:</td>
                <td class="style3">
                    <asp:TextBox ID="txtAddress" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style2">
                    Country:</td>
                     <td class="style2">
                         <telerik:RadComboBox ID="cboCountry" Runat="server" Width="194px" 
                             MarkFirstMatch="True">
                         </telerik:RadComboBox>
                </td>
            </tr>
               <tr>
                <td class="style4">
                    Email:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEmail" runat="server" Width="192px"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;</td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style4">
                    Tel:</td>
                <td class="style3">
                    <asp:TextBox ID="txtTelephone" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;</td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style5">
                    Fax:</td>
                <td class="style6">
                    <asp:TextBox ID="txtFax" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td class="style7">
                    </td>
                     <td class="style7">
                         </td>
            </tr>
               <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style4">
                    Contact Person 1:</td>
                <td class="style3">
                    <asp:TextBox ID="txtContactPerson1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    
                    Contact Person 2:</td>
                     <td class="style2">
                    
                    <asp:TextBox ID="txtContactPerson2" runat="server" Width="185px"></asp:TextBox>
                   </td>
            </tr>
           
             <tr>
                <td class="style4">
                    Destination:</td>
                <td class="style3">
                    <asp:TextBox ID="txtDestination1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    Destination:</td>
                     <td class="style2">
                    <asp:TextBox ID="txtDestination2" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
           
             <tr>
                <td class="style4">
                    HP:</td>
                <td class="style3">
                    <asp:TextBox ID="txtHP1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    HP:</td>
                     <td class="style2">
                    <asp:TextBox ID="txtHP2" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
           
             <tr>
                <td class="style4">
                    Tel:</td>
                <td class="style3">
                    <asp:TextBox ID="txtContactTelephone1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    Tel:</td>
                     <td style="font-weight: 700" class="style2">
                    <asp:TextBox ID="txtTelephone2" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
           
             <tr>
                <td class="style4">
                    Stop:</td>
                <td class="style3">
                    <asp:RadioButtonList ID="rdlStop" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style2">
                    Stop Date:</td>
                     <td style="font-weight: 700" class="style2">
                    <asp:TextBox ID="txtStopDate" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
           
             <tr>
                <td class="style4">&nbsp;</td>
                <td class="style3">&nbsp;</td>
                <td class="style2">&nbsp;</td>
                <td style="font-weight: 700" class="style2">&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style4">
                    For Adhoc</td>
                <td class="style3">&nbsp;</td>
                <td class="style2">&nbsp;</td>
                <td style="font-weight: 700" class="style2">&nbsp;</td>
            </tr>
            <tr>
                <td>Username</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Width="193px" AutoPostBack="true" ontextchanged="txtUserName_TextChanged"></asp:TextBox>
                </td>
                <td>Password</td>
                <td style="font-weight: 700">
                    <asp:TextBox ID="txtPassword" runat="server" Width="191px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4"></td>
                <td colspan="3">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="77px" ValidationGroup="Add" onclick="btnAdd_Click" />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</div>
    <!-- End Of First Tab -->

    <!-- Second Tab -->
    <div id="tabs-2">
        <h3>Search By Categoryyy</h3>
        <table style="width: 100%;">
            <tr>
               <td class="style9">
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="25px" Width="170px" AutoPostBack="True">
                        
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem Value="AgentCode">Agent Code</asp:ListItem>
                            <asp:ListItem Value="Agent">Agent</asp:ListItem>
                            <asp:ListItem Value="Address">Address</asp:ListItem>
                            <asp:ListItem Value="Email">Email</asp:ListItem>
                            <asp:ListItem Value="Fax">Fax</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td class="style8">
                        <asp:TextBox ID="txtSearch" runat="server" Width="400px" CssClass="SearchText"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPagingNumber" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlPagingNumber_SelectedIndexChanged">
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>100</asp:ListItem>
                    <asp:ListItem>200</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
      
            <tr>
               <td class="style9">
                        &nbsp;</td>
                <td class="style8">
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnSearch_Click" CausesValidation="False" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                     <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"  
                        DataKeyNames = "AgentCode" onrowcommand="gv_RowCommand" Width = "100%" 
                        AllowPaging="True" onpageindexchanging="gv_PageIndexChanging" 
                         CellPadding="4" ForeColor="#333333" GridLines="None" 
                         onrowdatabound="gv_RowDataBound">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="AgentCode" HeaderText="Agent Code" />
                            <asp:BoundField DataField="Agent" HeaderText="Agent" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Fax" HeaderText="Fax" />
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
     <h3>Agent Registration Card</h3>
    <telerik:RadAjaxLoadingPanel ID="rlpnlEdit" runat="server" Skin="Default" />
    <telerik:RadAjaxPanel ID="rpnlEdit" runat="server" Height="100%" Width="100%" LoadingPanelID="rlpnlEdit"  >
    <table style="width:100%;">
            <tr>
                <td class="style4">
                  Agent:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditAgent" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEditAgent" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    Agent Code</td>
                     <td class="style2">
                    <asp:TextBox ID="txtEditAgentCode" runat="server" Width="149px" Enabled="False"></asp:TextBox>
                         </td>
            </tr>
            <tr>
                <td class="style4">
                  Prefix:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditPrefix" runat="server" Width="149px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEditPrefix" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    Postal Code:</td>
                     <td class="style7">
                    <asp:TextBox ID="txtEditPostalCode" runat="server" Width="149px"></asp:TextBox>
                         </td>
            </tr>
            <tr>
                <td class="style4">
                    Address:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditAddress" runat="server" Width="250px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style2">
                    Country:</td>
                     <td class="style2">
                         <telerik:RadComboBox ID="cboEditCountry" Runat="server" MarkFirstMatch="True">
                         </telerik:RadComboBox>
                </td>
            </tr>
               <tr>
                <td class="style4">
                    Email:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditEmail" runat="server" Width="192px"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;</td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style4">
                    Tel:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditTelephone" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;</td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style5">
                    Fax:</td>
                <td class="style6">
                    <asp:TextBox ID="txtEditFax" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td class="style7">
                    </td>
                     <td class="style7">
                         </td>
            </tr>
               <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style4">
                    Contact Person 1:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditContactPerson1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    
                    Contact Person 2:</td>
                     <td class="style2">
                    
                    <asp:TextBox ID="txtEditContactPerson2" runat="server" Width="185px"></asp:TextBox>
                   </td>
            </tr>
           
             <tr>
                <td class="style4">
                    Destination:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditDestination1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    Destination:</td>
                     <td class="style2">
                    <asp:TextBox ID="txtEditDestination2" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
           
             <tr>
                <td class="style4">
                    HP:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditHP1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    HP:</td>
                     <td class="style2">
                    <asp:TextBox ID="txtEditHP2" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
           
             <tr>
                <td class="style4">
                    Tel:</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditContactTelephone1" runat="server" Width="193px"></asp:TextBox>
                </td>
                <td class="style2">
                    Tel:</td>
                     <td style="font-weight: 700" class="style2">
                    <asp:TextBox ID="txtEditContactTelephone2" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
           
             <tr>
                <td class="style4">
                    Stop</td>
                <td class="style3">
                    <asp:RadioButtonList ID="rblEditStop" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style2">
                    Date</td>
                     <td style="font-weight: 700" class="style2">
                    <asp:TextBox ID="txtEditStopDate" runat="server" Width="185px"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                     <td style="font-weight: 700" class="style2">
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style4">
                    For Adhoc</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                     <td style="font-weight: 700" class="style2">
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style4">
                    Username</td>
                <td class="style3">
                    <asp:TextBox ID="txtEditUserName" runat="server" Width="193px" AutoPostBack="true"
                        ontextchanged="txtEditUserName_TextChanged"></asp:TextBox>
                </td>
                <td class="style2">
                    Password</td>
                     <td style="font-weight: 700" class="style2">
                         <telerik:RadTextBox ID="rtxtEditPassword" Runat="server" 
                             EmptyMessage="Enter to update the password" MaxLength="50" Width="185px">
                         </telerik:RadTextBox>
                 </td>
            </tr>
            <tr>
                <td class="style4">
                   </td>
                <td class="style3" colspan="3">
            
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="77px" 
                        onclick="btnConfirm_Click" ValidationGroup="Edit" />
                   
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="77px" 
                        onclick="btnDelete_Click" CausesValidation="False" />
                   
                    <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
                </td>
            </tr>
        </table>
        </telerik:RadAjaxPanel>
    </div>
    <!-- End Of Third Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>

