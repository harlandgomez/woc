<%@ Page Title="" Language="C#" MasterPageFile="~/Registration/Registration.Master" AutoEventWireup="true" CodeBehind="Bus.aspx.cs" Inherits="WOC.Book.Bus" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="../Controls/CompanyDropdown.ascx" tagname="CompanyDropdown" tagprefix="uc1" %>

<%@ Register src="../Controls/SubConDropdown.ascx" tagname="SubConDropdown" tagprefix="uc2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 59px;
        }
        .style3
        {
            width: 215px;
        }
        .style4
        {
            width: 59px;
            height: 26px;
        }
        .style5
        {
            width: 378px;
            height: 26px;
        }
        .style6
        {
            width: 70px;
            height: 26px;
        }
        .style7
        {
            height: 26px;
        }
        .style8
        {
            width: 59px;
            height: 29px;
        }
        .style9
        {
            width: 378px;
            height: 29px;
        }
        .style10
        {
            width: 70px;
            height: 29px;
        }
        .style11
        {
            height: 29px;
        }
        .style12
        {
            width: 378px;
        }
        .style13
        {
            width: 369px;
            height: 29px;
        }
        .style14
        {
            width: 369px;
            height: 26px;
        }
        .style15
        {
            width: 369px;
        }
        .style16
        {
            width: 67px;
            height: 29px;
        }
        .style17
        {
            width: 67px;
            height: 26px;
        }
        .style18
        {
            width: 67px;
        }
        .style19
        {
            width: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () 
        {

            $("#MainContent_txtExpiry1").datepicker();
            $("#MainContent_txtExpiry2").datepicker();
            $("#MainContent_txtExpiry3").datepicker();
            $("#MainContent_txtEditExpiry1").datepicker();
            $("#MainContent_txtEditExpiry2").datepicker();
            $("#MainContent_txtEditExpiry3").datepicker();
            $("#MainContent_txtScrappedDate").datepicker();
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
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteBus.ashx?category=" + ddlCategory + "&paremeter=" + search);

//            var search = document.getElementById('MainContent_txtSubconInitial').value;
//            $('#MainContent_txtSubconInitial').autocomplete("../AutocompleteData/AutocompleteSubcon.ashx?category=Initial&paremeter=" + search);

//            var search = document.getElementById('MainContent_txtEditSubconInitial').value;
//            $('#MainContent_txtEditSubconInitial').autocomplete("../AutocompleteData/AutocompleteSubcon.ashx?category=Initial&paremeter=" + search);

        });

        function SelectLastTab() {
            $('#tabs').tabs('select', 2); // switch to third tab
            return false;
        }

        function ShowHideTextbox(textboxName, isCheck) {
            if (isCheck) {
                document.getElementById(textboxName).disabled  = false;
            }
            else {
                document.getElementById(textboxName).disabled = true;
            }
            
        } 
  </script>
<!-- Begin of Tabs -->
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Bus Registration</a></li>
	    <li><a href="#tabs-2">Bus Search</a></li>
        <li><a href="#tabs-3">Bus Update</a></li>
			
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
        <h3>Add New Bus Registration</h3>

     <table style="width:100%;">
            <tr>
                <td class="style8">
                    Bus No:</td>
                <td class="style9">
                    <asp:TextBox ID="txtBus1" runat="server" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtBus1" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtBus2" runat="server" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtBus2" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtBus3" runat="server" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtBus3" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td colspan="2">    
                    <telerik:RadAjaxLoadingPanel ID="lpnlSubCon" runat="server" Skin="Default" />
                    <telerik:RadAjaxPanel ID="pnlSubCon" runat="server" LoadingPanelID="lpnlSubCon">
                    <table>
                    <tr>
                        <td>Subcon:</td>
                        <td><asp:CheckBox ID="chkSubcon" runat="server" AutoPostBack="true" 
                                oncheckedchanged="chkSubcon_CheckedChanged" />&nbsp;<uc2:SubConDropdown ID="cboSubcon" runat="server" Width="180" /></td>
                    </tr>
                    </table>
                    </telerik:RadAjaxPanel>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Seater:</td>
                <td class="style5">
                    <asp:TextBox ID="txtSeater" runat="server" Width="214px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
                     <td class="style7">
                         &nbsp;</td>
                     <td class="style7">
                         </td>
            </tr>
            <tr>
                <td class="style1">
                    Company:</td>
                <td class="style12">
                    <uc1:CompanyDropdown ID="cboCompany" runat="server" Width="215px"/>
                </td>
                <td class="style19">
                    </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Brand:</td>
                <td class="style12">
                    <asp:TextBox ID="txtBrand" runat="server" Width="214px"></asp:TextBox>
                </td>
                <td class="style19">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Year:</td>
                <td class="style12">
                    <asp:TextBox ID="txtYear" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style19">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Parking:</td>
                <td class="style12">
                    <asp:TextBox ID="txtParking" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style19">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Type:</td>
                <td class="style12">
                    <asp:RadioButtonList ID="rblType" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Big</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                        <asp:ListItem>Small</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style19">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes:</td>
                <td class="style12">
                    <asp:TextBox ID="txtPasses1" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style19">
                    Expiry:</td>
                     <td>
                    <asp:TextBox ID="txtExpiry1" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes:</td>
                <td class="style12">
                    <asp:TextBox ID="txtPasses2" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style19">
                    Expiry:</td>
                     <td>
                    <asp:TextBox ID="txtExpiry2" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes:</td>
                <td class="style12">
                    <asp:TextBox ID="txtPasses3" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style19">
                    Expiry:</td>
                     <td style="font-weight: 700">
                    <asp:TextBox ID="txtExpiry3" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                   </td>
                <td class="style12">
                   
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="77px" 
                        onclick="btnAdd_Click" ValidationGroup="Add" />
                   
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                   
                </td>
                <td class="style19">
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
        <h3>Search By Category</h3>
        <table style="width: 100%;">
      
            <tr>
                <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="20px" 
                        Width="245px" AutoPostBack="True">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem Value="BusNo">Bus No</asp:ListItem>
                            <asp:ListItem>Seater</asp:ListItem>
                            <asp:ListItem>Company</asp:ListItem>
                            <asp:ListItem>Brand</asp:ListItem>
                            <asp:ListItem>Year</asp:ListItem>
                            <asp:ListItem>Parking</asp:ListItem>
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
                    </asp:DropDownList></td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                    </td>
                <td class="style7">
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnSearch_Click" CausesValidation="False" />
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
                        DataKeyNames = "BusCode" onrowcommand="gv_RowCommand" Width = "100%" AllowPaging="True" 
                        onpageindexchanging="gv_PageIndexChanging" onrowdatabound="gv_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="BusNo" HeaderText="BusNo" />
                            <asp:BoundField DataField="Seater" HeaderText="Seater" />
                            <asp:BoundField DataField="CompanyNameSearch" HeaderText="Company" />
                            <asp:BoundField DataField="Brand" HeaderText="Brand" />
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
     <h3>Bus Registration Card</h3>
        <table style="width:100%;">
            <tr>
                <td class="style8">
                    Bus Code</td>
                <td class="style13">
                    <asp:TextBox ID="txtBusCode" runat="server" Width="132px" Enabled="False"></asp:TextBox>
                </td>
                <td colspan="2">    
                    <telerik:RadAjaxLoadingPanel ID="lpnlEditSubcon" runat="server" Skin="Default" />
                    <telerik:RadAjaxPanel ID="pnlEditSubcon" runat="server" LoadingPanelID="lpnlEditSubcon">
                    <table>
                    <tr>
                        <td>Subcon:</td>
                        <td><asp:CheckBox ID="chkEditSubcon" runat="server" AutoPostBack="true" 
                                oncheckedchanged="chkEditSubcon_CheckedChanged" />&nbsp;<uc2:SubConDropdown 
                                ID="cboEditSubcon" runat="server" Width="180px" /></td>
                    </tr>
                    </table>
                    </telerik:RadAjaxPanel>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Bus No:</td>
                <td class="style13">
                    <asp:TextBox ID="txtEditBusNo1" runat="server" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtEditBusNo1" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEditBusNo2" runat="server" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEditBusNo2" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEditBusNo3" runat="server" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEditBusNo3" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td class="style16">
                    &nbsp;</td>
                     <td class="style11">
                         &nbsp;</td>
                     <td class="style11">
                         </td>
            </tr>
            <tr>
                <td class="style4">
                    Seater:</td>
                <td class="style14">
                    <asp:TextBox ID="txtEditSeater" runat="server" Width="216px"></asp:TextBox>
                </td>
                <td class="style17">
                    </td>
                     <td class="style7">
                         </td>
                     <td class="style7">
                         </td>
            </tr>
            <tr>
                <td class="style1">
                    Company:</td>
                <td class="style15">
                    <uc1:CompanyDropdown ID="cboEditCompany" runat="server" Width="215px" />
                </td>
                <td class="style18">
                    </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Brand:</td>
                <td class="style15">
                    <asp:TextBox ID="txtEditBrand" runat="server" Width="214px"></asp:TextBox>
                </td>
                <td class="style18">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Year:</td>
                <td class="style15">
                    <asp:TextBox ID="txtEditYear" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style18">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Parking:</td>
                <td class="style15">
                    <asp:TextBox ID="txtEditParking" runat="server" Width="184px"></asp:TextBox>
                </td>
                <td class="style18">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style1">
                    Type:</td>
                <td class="style15">
                    <asp:RadioButtonList ID="rblEditType" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Big</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                        <asp:ListItem>Small</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style18">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes</td>
                <td class="style15">
                    <asp:TextBox ID="txtEditPasses1" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style18">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtEditExpiry1" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes</td>
                <td class="style15">
                    <asp:TextBox ID="txtEditPasses2" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style18">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtEditExpiry2" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Passes</td>
                <td class="style15">
                    <asp:TextBox ID="txtEditPasses3" runat="server" Width="185px"></asp:TextBox>
                </td>
                <td class="style18">
                    Expiry</td>
                     <td style="font-weight: 700">
                    <asp:TextBox ID="txtEditExpiry3" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
           
             <tr>
                <td class="style1">
                    Scrapped:</td>
                <td class="style15">
                    <asp:RadioButtonList ID="rblEditScrapped" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style18">
                    Date</td>
                     <td style="font-weight: 700">
                    <asp:TextBox ID="txtScrappedDate" runat="server" Width="185px"></asp:TextBox>
                 </td>
                     <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                   </td>
                <td class="style15" colspan="4">
                   
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="77px" 
                        onclick="btnConfirm_Click" ValidationGroup="Edit" />
                   
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="77px" 
                        onclick="btnDelete_Click" />
                   
                &nbsp;<asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of Third Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>
