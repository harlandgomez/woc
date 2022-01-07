<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WOC.Book.Staff" MasterPageFile="~/Admin/Admin.Master" %>

<%@ Register src="../Controls/CountryDropdown.ascx" tagname="CountryDropdown" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style3
        {
            width: 37px;
        }
        .style6
        {
            height: 26px;
        }
        .style8
        {
            width: 455px;
        }
        .style13
        {
            width: 135px;
            height: 10px;
        }
        .style14
        {
            width: 476px;
            height: 10px;
        }
        .style15
        {
            height: 10px;
        }
        .style17
        {
            width: 135px;
            height: 26px;
        }
        .style18
        {
            width: 135px;
        }
        .style19
        {
            width: 135px;
            height: 32px;
        }
        .style20
        {
            width: 476px;
            height: 32px;
        }
        .style21
        {
            height: 32px;
        }
        .style22
        {
            width: 476px;
        }
        .style23
        {
            width: 476px;
            height: 26px;
        }
        .style25
        {
            width: 128px;
        }
        .style27
        {
            width: 135px;
            height: 35px;
        }
        .style28
        {
            width: 476px;
            height: 35px;
        }
        .style29
        {
            height: 35px;
        }
        .style30
        {
            width: 407px;
        }
        </style>
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
             $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteStaff.ashx?category=" + ddlCategory + "&paremeter=" + search);

         });

         function SelectLastTab() {
             $('#tabs').tabs('select', 2); // switch to third tab
             return false;
         }

  </script>
   <div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
   </div>
   <div id="tabs">

             <ul>
				<li><a href="#tabs-1">Staff Registration</a></li>
				<li><a href="#tabs-2">Search Staffs</a></li>
                <li><a href="#tabs-3">Update Staff</a></li>
			
			</ul>
    <!-- First Tab -->
    <div id="tabs-1">
		  <h3>Update Staff Registration</h3>
          <table style="width:100%; height: 324px;">
            <tr>
                <td class="style18">
                    Name:</td>
                <td class="style22">
                    <asp:TextBox ID="txtName" runat="server" Width="222px" Height="21px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqvName" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18">
                    IC/Fin:</td>
                <td class="style22">
                    <asp:TextBox ID="txtNRIC" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    Address:</td>
                <td class="style23">
                    <asp:TextBox ID="txtAddress1" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style23">
                    <asp:TextBox ID="txtAddress2" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style23">
                    <asp:TextBox ID="txtAddress3" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style18">
                    Contact:</td>
                <td class="style22">
                    <asp:TextBox ID="txtContact" runat="server" Width="222px" Height="21px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqvContact" runat="server" 
                        ControlToValidate="txtContact" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style18">
                    DOB</td>
                <td class="style22">
                    <asp:TextBox ID="txtDOB" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
               <td>
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style19">
                    Country</td>
                <td class="style20">
                    <uc1:CountryDropdown ID="cboCountry" runat="server" Width="228px" />
                </td>
                <td class="style21">
                    </td>
            </tr>
            <tr>
                <td class="style18">
                    Access
                    Level</td>
                <td class="style22">
                    <asp:DropDownList ID="ddlAccessLevel" runat="server" Height="25px" 
                        Width="228px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style27">
                    Password</td>
                <td class="style28">
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TextMode="Password" 
                        Width="222px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqvPassword" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToCompare="txtRePassword" ControlToValidate="txtPassword" 
                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Add"></asp:CompareValidator>
                   </td>
                <td class="style29">
                    </td>
            </tr>
               <tr>
                <td class="style18">
                    Re-enter Password</td>
                <td class="style22">
                    <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" 
                        Width="222px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqvRePassword" runat="server" 
                        ControlToValidate="txtRePassword" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Add"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtRePassword" 
                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Add"></asp:CompareValidator>
                   </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                   </td>
                <td class="style14">
                   
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="77px" 
                        onclick="btnAdd_Click" style="height: 26px" ValidationGroup="Add" />
                   
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                   
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
                        <asp:ListItem Value="LoginID">Name</asp:ListItem>
                        <asp:ListItem Value="NRIC">FIN</asp:ListItem>
                        <asp:ListItem Value="Address1">Address</asp:ListItem>
                        <asp:ListItem Value="Contact">Contact</asp:ListItem>
                        <asp:ListItem Value="DOB">DOB</asp:ListItem>
                        <asp:ListItem Value="Country">Country</asp:ListItem>
                        <asp:ListItem Value="AccessLevel">AccessLevel</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td class="style30">
                        <asp:TextBox ID="txtSearch" runat="server" Width="400px"></asp:TextBox>
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
                    </asp:DropDownList>
                </td>
               
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
                        DataKeyNames = "LoginID" onrowcommand="gv_RowCommand" Width = "100%" 
                        AllowPaging="True" onpageindexchanging="gv_PageIndexChanging" 
                         CellPadding="4" ForeColor="#333333" GridLines="None" 
                         onrowdatabound="gv_RowDataBound">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="LoginID" HeaderText="LoginID" />
                            <asp:BoundField DataField="NRIC" HeaderText="FIN" />
                             <asp:BoundField DataField="Address1" HeaderText="Address" />
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
     <h3>Update Registration Card</h3>
      <table style="width:100%;">
            <tr>
                <td class="style18">
                    Name:</td>
                <td class="style22">
                    <asp:TextBox ID="txtEditName" runat="server" Width="222px" Height="21px" 
                        Enabled="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtEditName" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18">
                    IC/Fin:</td>
                <td class="style22">
                    <asp:TextBox ID="txtEditNRIC" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    Address:</td>
                <td class="style23">
                    <asp:TextBox ID="txtEditAddress1" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style23">
                    <asp:TextBox ID="txtEditAddress2" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style23">
                    <asp:TextBox ID="txtEditAddress3" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style18">
                    Contact:</td>
                <td class="style22">
                    <asp:TextBox ID="txtEditContact" runat="server" Width="222px" Height="21px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtEditContact" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style18">
                    DOB</td>
                <td class="style22">
                    <asp:TextBox ID="txtEditDOB" runat="server" Width="222px" Height="21px"></asp:TextBox>
                </td>
               <td>
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style19">
                    Country</td>
                <td class="style20">
                    <uc1:CountryDropdown ID="cboEditCountry" runat="server" Width="228px" />
                </td>
                <td class="style21">
                    </td>
            </tr>
            <tr>
                <td class="style18">
                    Access
                    Level</td>
                <td class="style22">
                    <asp:DropDownList ID="ddlEditAccessLevel" runat="server" Height="25px" 
                        Width="228px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
               <tr>
                <td class="style27">
                    Password</td>
                <td class="style28">
                    <asp:TextBox ID="txtEditPassword" runat="server" TextMode="Password" 
                        Width="222px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEditPassword" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToCompare="txtEditRePassword" ControlToValidate="txtEditPassword" 
                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Edit"></asp:CompareValidator>
                   </td>
                <td class="style29">
                    <asp:HiddenField ID="hdnPassword" runat="server" />
                    </td>
            </tr>
               <tr>
                <td class="style18">
                    Re-enter Password</td>
                <td class="style22">
                    <asp:TextBox ID="txtEditRePassword" runat="server" TextMode="Password" 
                        Width="222px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEditRePassword" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Edit"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" 
                        ControlToCompare="txtEditPassword" ControlToValidate="txtEditRePassword" 
                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Edit"></asp:CompareValidator>
                   </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style25">
                   </td>
                <td class="style8">
                   
                    <asp:Button ID="btnResigned" runat="server" Text="Resigned" Width="77px" 
                        onclick="btnResigned_Click" ValidationGroup="Resigned" />
                   
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="77px" 
                        onclick="btnConfirm_Click" ValidationGroup="Edit" />
                   
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="77px" 
                        onclick="btnDelete_Click" ValidationGroup="Delete" />
                   
                    <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table> 
    </div>
      <!-- End Of Third Tab -->
   </div>
     
       
</asp:Content>
