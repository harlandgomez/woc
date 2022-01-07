<%@ Page Title="" Language="C#" MasterPageFile="~/Registration/Registration.Master" AutoEventWireup="true" CodeBehind="SubCon.aspx.cs" Inherits="WOC.Book.SubCon"  %>

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
        .style19
        {
            width: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtExpiry1").datepicker();
            $("#MainContent_txtExpiry2").datepicker();
            $("#MainContent_txtEditExpiry1").datepicker();
            $("#MainContent_txtEditExpiry2").datepicker();

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
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteSubcon.ashx?category=" + ddlCategory + "&paremeter=" + search);

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
	    <li><a href="#tabs-1">Subcon Registration</a></li>
	    <li><a href="#tabs-2">Subcon Search</a></li>
        <li><a href="#tabs-3">Subcon Update</a></li>
			
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
        <h3>Add New Subcon Registration</h3>

     <table style="width:100%;">
            <tr>
                <td class="style8">
                    Company:</td>
                <td class="style9">
                    <asp:TextBox ID="txtCompany" runat="server" Width="200px" ValidationGroup="ADD"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCompany" runat="server" 
                        ControlToValidate="txtCompany" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
                <td class="style10">
                    Initial</td>
                     <td class="style11">
                    <asp:TextBox ID="txtInitial" runat="server" Width="200px" ValidationGroup="ADD"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvInitial" runat="server" 
                        ControlToValidate="txtInitial" ErrorMessage="*" ForeColor="Red" 
                             ValidationGroup="ADD"></asp:RequiredFieldValidator>
                         </td>
                     <td class="style11">
                         </td>
            </tr>
            <tr>
                <td class="style4">
                    Person:</td>
                <td class="style5">
                    <asp:TextBox ID="txtPerson" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
                     <td class="style7">
                         </td>
                     <td class="style7">
                         </td>
            </tr>
            <tr>
                <td class="style1">
                    HP:</td>
                <td class="style12">
                    <asp:TextBox ID="txtHP" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style19">
                    </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
               <tr>
                <td class="style4">
                    Tel:</td>
                <td class="style5">
                    <asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
                     <td class="style7">
                         </td>
                     <td class="style7">
                         </td>
            </tr>
               <tr>
                <td class="style1">
                    Fax:</td>
                <td class="style12">
                    <asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox>
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
                    Address:</td>
                <td class="style12">
                    <asp:TextBox ID="txtAddress" runat="server" Width="350px"></asp:TextBox>
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
                    Remarks</td>
                <td class="style12">
                    <asp:TextBox ID="txtRemarks" runat="server" Width="350px"></asp:TextBox>
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
                    Passes</td>
                <td class="style12">
                    <asp:TextBox ID="txtPasses1" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style19">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtExpiry1" runat="server" Width="200px"></asp:TextBox>
                   </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
               <tr>
                <td class="style1">
                    Passes</td>
                <td class="style12">
                    <asp:TextBox ID="txtPasses2" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style19">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtExpiry2" runat="server" Width="200px"></asp:TextBox>
                   </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
            <tr>
                <td class="style1">
                   </td>
                <td class="style12" colspan="3">
                   
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="77px" 
                        onclick="btnAdd_Click" ValidationGroup="ADD" />
                   
                &nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
                   
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
                        <asp:DropDownList ID="ddlCategory" runat="server" Height="20px" 
                        Width="245px">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Company</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Person</asp:ListItem>
                            <asp:ListItem>HP</asp:ListItem>
                            <asp:ListItem>Tel</asp:ListItem>
                            <asp:ListItem>Fax</asp:ListItem>
                            <asp:ListItem>Address</asp:ListItem>
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
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                    </td>
                <td class="style7">
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        onclick="btnSearch_Click" />
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
                    <asp:GridView ID="gvSubCon" runat="server" AutoGenerateColumns="False"   DataKeyNames = "SubconCode"
                        Width="665px" onrowcommand="gvSubCon_RowCommand" 
                        onrowdatabound="gvSubCon_RowDataBound" 
                        onpageindexchanging="gvSubCon_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Company" HeaderText="Company" />
                            <asp:BoundField DataField="Initial" HeaderText="Initial" />
                            <asp:BoundField DataField="Person" HeaderText="Person" />
                            <asp:BoundField DataField="Mobile" HeaderText="HP" />
                            <asp:BoundField DataField="Telephone" HeaderText="Tel" />
                            <asp:BoundField DataField="Fax" HeaderText="Fax" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:CommandField ShowSelectButton="True" ButtonType="Link" 
                                CausesValidation="False"/>
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
     <h3>Subcon Registration Card</h3>
 <table style="width:100%;">
            <tr>
                <td class="style8">
                    Subcon Code</td>
                <td class="style9">
                    <asp:TextBox ID="txtEditSubconCode" runat="server" Width="200px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
                     <td class="style11">
                         <asp:HiddenField ID="hdnID" runat="server" />
                         </td>
                     <td class="style11">
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    Company:</td>
                <td class="style9">
                    <asp:TextBox ID="txtEditCompany" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtEditCompany" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Update"></asp:RequiredFieldValidator>
                </td>
                <td class="style10">
                    Initial</td>
                     <td class="style11">
                    <asp:TextBox ID="txtEditInitial" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEditInitial" ErrorMessage="*" ForeColor="Red" 
                             ValidationGroup="Update"></asp:RequiredFieldValidator>
                         </td>
                     <td class="style11">
                         </td>
            </tr>
            <tr>
                <td class="style4">
                    Person:</td>
                <td class="style5">
                    <asp:TextBox ID="txtEditPerson" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
                     <td class="style7">
                         </td>
                     <td class="style7">
                         </td>
            </tr>
            <tr>
                <td class="style1">
                    HP:</td>
                <td class="style12">
                    <asp:TextBox ID="txtEditHP" runat="server" Width="200px"></asp:TextBox>
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
                    Tel:</td>
                <td class="style12">
                    <asp:TextBox ID="txtEditTel" runat="server" Width="200px"></asp:TextBox>
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
                    Fax:</td>
                <td class="style12">
                    <asp:TextBox ID="txtEditFax" runat="server" Width="200px"></asp:TextBox>
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
                    Address:</td>
                <td class="style12">
                    <asp:TextBox ID="txtEditAddress" runat="server" Width="350px"></asp:TextBox>
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
                    Remarks</td>
                <td class="style12">
                    <asp:TextBox ID="txtEditRemarks" runat="server" Width="350px"></asp:TextBox>
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
                    Passes</td>
                <td class="style12">
                    <asp:TextBox ID="txtEditPasses1" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style19">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtEditExpiry1" runat="server" Width="200px"></asp:TextBox>
                   </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
               <tr>
                <td class="style1">
                    Passes</td>
                <td class="style12">
                    <asp:TextBox ID="txtEditPasses2" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style19">
                    Expiry</td>
                     <td>
                    <asp:TextBox ID="txtEditExpiry2" runat="server" Width="200px"></asp:TextBox>
                   </td>
                     <td>
                         &nbsp;</td>
            </tr>
           
            <tr>
                <td class="style1">
                   </td>
                <td class="style12">
                   
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="77px" 
                        onclick="btnConfirm_Click"  />
                   
                    &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" Width="77px" 
                        onclick="btnDelete_Click" />
                   
                    <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
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
    <!-- End Of Third Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>