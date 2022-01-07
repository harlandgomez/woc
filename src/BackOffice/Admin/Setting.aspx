<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="WOC.Book.Admin.Setting" MasterPageFile="~/Admin/Admin.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <script language="javascript" type="text/javascript">
         $(document).ready(function () {
             $("#MainContent_txtDOB").datepicker();
             $("#MainContent_txtEditDOB").datepicker();
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
             $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteSetting.ashx?category=" + ddlCategory + "&paremeter=" + search);

         });

         function SelectLastTab() {
             $('#tabs').tabs('select', 2); // switch to third tab
             return false;
         }

  </script>

   <div id="tabs">

             <ul>
				<li><a href="#tabs-1">Add New Setting</a></li>
				<li><a href="#tabs-2">Search Setting</a></li>
                <li><a href="#tabs-3">Update Setting</a></li>
			
			</ul>
    <!-- First Tab -->
    <div id="tabs-1">
		  <h3>Add New Setting</h3>
          <table style="width:100%; height: 324px;">
            <tr>
                <td>
                    Code:</td>
                <td>
                    <asp:TextBox ID="txtCode" runat="server" Width="222px" Height="21px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqvCode" runat="server" 
                        ControlToValidate="txtCode" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Value:</td>
                <td>
                    <asp:TextBox ID="txtValue" runat="server" Width="750px" Height="21px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Default Value:</td>
                <td>
                    <asp:TextBox ID="txtDefaultValue" runat="server" Width="750px" Height="21px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqvDefaultValue" runat="server" 
                        ControlToValidate="txtDefaultValue" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Description:</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="750px" Height="21px"></asp:TextBox>
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    Locale Aware:</td>
                <td>
                    <asp:CheckBox ID="chkLocaleAware" runat="server" />
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                   </td>
                <td class="style14">
                   
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="77px" 
                        onclick="btnAdd_Click" style="height: 26px" ValidationGroup="Add" />
                   
                    &nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
                   
                </td>
                <td class="style15">
                    </td>
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
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="25px" Width="170px" AutoPostBack="True">
                        <asp:ListItem Value="Select">Select</asp:ListItem>
                        <asp:ListItem Value="SettingCode">Code</asp:ListItem>
                        <asp:ListItem Value="Value">Value</asp:ListItem>
                        <asp:ListItem Value="DefaultValue">DefaultValue</asp:ListItem>
                        <asp:ListItem Value="Description">Description</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td class="style30">
                        <asp:TextBox ID="txtSearch" runat="server" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPagingNumber" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlPagingNumber_SelectedIndexChanged">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                    </td>
                <td class="style30">
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnSearch_Click" CausesValidation="False" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style30">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3">
                     <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"  
                        DataKeyNames = "SettingID" onrowcommand="gv_RowCommand" Width = "100%" 
                        AllowPaging="True" onpageindexchanging="gv_PageIndexChanging" 
                         CellPadding="4" ForeColor="#333333" GridLines="None" 
                         onrowdatabound="gv_RowDataBound">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="SettingCode" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                             <asp:BoundField DataField="LocaleAware" HeaderText="LocaleAware" />
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
     <h3>Update Setting</h3>
      <table style="width:100%; height: 324px;">
            <tr>
                <td>
                    Code:</td>
                <td>
                    <asp:TextBox ID="txtEditCode" runat="server" Width="222px" Height="21px" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEditCode" runat="server" 
                        ControlToValidate="txtEditCode" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Update"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Value:</td>
                <td>
                    <asp:TextBox ID="txtEditValue" runat="server" Width="750px" Height="21px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Default Value:</td>
                <td>
                    <asp:TextBox ID="txtEditDefaultValue" runat="server" Width="750px" Height="21px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEditDefaultValue" runat="server" 
                        ControlToValidate="txtEditDefaultValue" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Update"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Description:</td>
                <td>
                    <asp:TextBox ID="txtEditDescription" runat="server" Width="750px" Height="21px"></asp:TextBox>
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    Locale Aware:</td>
                <td>
                    <asp:CheckBox ID="chkEditLocaleAware" runat="server" />
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                   </td>
                <td class="style14">
                   
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="77px" 
                        style="height: 26px" ValidationGroup="Update" onclick="btnConfirm_Click" />
                   
                    <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
                </td>
                <td class="style15">
                    </td>
            </tr>
        </table>
    </div>
      <!-- End Of Third Tab -->


   </div>
     
       
</asp:Content>
