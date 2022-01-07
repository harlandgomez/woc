<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="WOC.Book.Company" MasterPageFile="~/Registration/Registration.Master" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 77px;
        }
        .style3
        {
            width: 87px;
        }
        .style4
        {
            width: 77px;
            height: 26px;
        }
        .style6
        {
            height: 26px;
        }
        .style7
        {
            width: 249px;
        }
        .style8
        {
            width: 455px;
        }
        .style9
        {
            width: 455px;
            height: 26px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_TextBox1").datepicker();

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
            $('#MainContent_txtSearch').autocomplete("../AutocompleteData/AutocompleteCompany.ashx?category=" + ddlCategory + "&paremeter=" + search);

        });

        function SelectLastTab() {
            $('#tabs').tabs('select', 2); // switch to third tab
            return false;
        }
        
        function SelectTab(tab) {
            $('#tabs').tabs('select', (tab-1)); // switch to third tab
            return false;
        }
        
  </script>
<!-- Begin of Tabs -->
<div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
</div>
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Company Registration</a></li>
	    <li><a href="#tabs-2">Company Search</a></li>
        <li><a href="#tabs-3">Company Update</a></li>
			
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
        <h3>Add New Company Registration</h3>
            <table style="width:100%;">
                <tr>
                    <td class="style1">
                        Company:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtCompany" runat="server" Width="428px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCompany" runat="server" 
                            ControlToValidate="txtCompany" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Add"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        Address:</td>
                    <td class="style9">
                        <telerik:RadTextBox ID="txtAddress" Runat="server" Height="40px" 
                            TextMode="MultiLine" Width="428px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style6">
                        </td>
                </tr>
                   <tr>
                    <td class="style1">
                        Tel:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox>
                        Fax:<asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td >
                        &nbsp; 
                    </td>
                </tr>
                   <tr>
                    <td class="style1">
                        Email</td>
                    <td class="style8">
                        <asp:TextBox ID="txtEmail" runat="server" Width="429px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                   <tr>
                    <td class="style1">
                        Website</td>
                    <td class="style8">
                         <asp:TextBox ID="txtWebsite" runat="server" Width="429px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                   <tr>
                    <td class="style1">
                        ROC</td>
                    <td class="style8">
                        <asp:TextBox ID="txtROC" runat="server" Width="429px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>Prefix</td>
                    <td>
                        <table width="100%" border="0px" cellpadding="0px" cellspacing="0px">
                            <tr>
                                <td width="15%"><asp:TextBox ID="txtPrefixCode" runat="server" Width="60px" 
                                        ValidationGroup="AddPrefix"></asp:TextBox></td>
                                <td width="5%"><asp:RequiredFieldValidator ID="rfvPrefixCode" runat="server" ControlToValidate="txtPrefixCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="AddPrefix"></asp:RequiredFieldValidator></td>
                                <td width="50%"><asp:TextBox ID="txtPrefixName" runat="server" Width="250px" ValidationGroup="AddPrefix"></asp:TextBox></td>
                                <td width="5%"><asp:RequiredFieldValidator ID="rfvPrefixName" runat="server" ControlToValidate="txtPrefixName" ErrorMessage="*" ForeColor="Red" ValidationGroup="AddPrefix"></asp:RequiredFieldValidator></td>
                                <td width="25%">
                                    <asp:Button ID="btnAddPrefix" runat="server" Text="Add Prefix" Width="80px" 
                                        ValidationGroup="AddPrefix" Height="23px" onclick="btnAddPrefix_Click" /></td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:GridView ID="gvPrefix" runat="server" AutoGenerateColumns="False" 
                            Width="97%" onrowdeleting="gvPrefix_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="PrefixCode" HeaderText="Prefix" />
                            <asp:BoundField DataField="PrefixName" HeaderText="Name">
                            <ItemStyle Width="300px" />
                            </asp:BoundField>
                            <asp:CommandField ShowDeleteButton="True" CausesValidation="False"/>
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
                    <td></td>
                </tr>
                <tr>
                    <td>
                        GST</td>
                    <td class="style8">
                        <asp:DropDownList ID="ddlGST" runat="server" Height="20px" Width="210px">
                            <asp:ListItem Value="NO">NO GST</asp:ListItem>
                            <asp:ListItem Value="INC">INC GST</asp:ListItem>
                            <asp:ListItem Value="EXEC">EXEC GST</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Reflect To Operation</td>
                    <td class="style8">
                        <asp:RadioButtonList ID="rblReflectToOps" runat="server" Height="17px" 
                            RepeatDirection="Horizontal" Width="93px">
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Letter Head</td>
                    <td class="style8">
                        <asp:FileUpload ID="fluLetterHead" runat="server"  />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                       </td>
                    <td class="style8" colspan="2">
                   
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="77px" 
                            onclick="btnAdd_Click" ValidationGroup="Add" />
                   
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
                        Width="245px" AutoPostBack="True">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Company</asp:ListItem>
                            <asp:ListItem>Address</asp:ListItem>
                            <asp:ListItem>Tel</asp:ListItem>
                            <asp:ListItem>Fax</asp:ListItem>
                            <asp:ListItem>Email</asp:ListItem>
                            <asp:ListItem>Website</asp:ListItem>
                            <asp:ListItem>ROC</asp:ListItem>
                            <asp:ListItem>Prefix</asp:ListItem>
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                    </td>
                <td class="style7">
                   <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" 
                        CausesValidation="False" ValidationGroup="Search" OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;</td>
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
                <td>
                    &nbsp;</td>
            </tr>
        
            <tr>
                <td class="style3" colspan="4">
        
        
                <asp:GridView ID="gvCompany" runat="server" AutoGenerateColumns="False"   DataKeyNames = "CompanyCode"
                    Width="100%" onrowcommand="gvCompany_RowCommand" AllowPaging="True" 
                        onrowdatabound="gvCompany_RowDataBound" 
                        onpageindexchanging="gvCompany_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Company" HeaderText="Company" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Telephone" HeaderText="Tel" />
                        <asp:BoundField DataField="Fax" HeaderText="Fax" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Website" HeaderText="Website" />
                        <asp:BoundField DataField="ROC" HeaderText="ROC" />
                        <asp:BoundField DataField="Prefix" HeaderText="Prefix" />
                        <asp:CommandField ShowSelectButton="True" 
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
                <td class="style3" colspan="4" align="right">
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
     <h3>Company Registration Card</h3>
          <table style="width:100%;">
            <tr>
                <td class="style1">
                    Company Code</td>
                <td class="style8">
                    <asp:TextBox ID="txtEditCompanyCode" runat="server" Width="428px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td rowspan="11" valign="top">
                <img src="" alt="" runat="server" ID="imgLetterHead" style="height:360px;width:100%"/>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Company:</td>
                <td class="style8">
                    <asp:TextBox ID="txtEditCompany" runat="server" Width="428px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEditCompany" runat="server" 
                        ControlToValidate="txtEditCompany" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Address:</td>
                <td class="style9">
                    <telerik:RadTextBox ID="txtEditAddress" Runat="server" Height="40px" 
                        TextMode="MultiLine" Width="428px">
                    </telerik:RadTextBox>
                </td>
            </tr>
               <tr>
                <td class="style1">
                    Tel:</td>
                <td class="style8">
                    <asp:TextBox ID="txtEditTel" runat="server" Width="200px"></asp:TextBox>
                    Fax:<asp:TextBox ID="txtEditFax" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="style1">
                    Email</td>
                <td class="style8">
                    <asp:TextBox ID="txtEditEmail" runat="server" Width="429px"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="style1">
                    Website</td>
                <td class="style8">
                     <asp:TextBox ID="txtEditWebsite" runat="server" Width="429px"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="style1">
                    ROC</td>
                <td class="style8">
                    <asp:TextBox ID="txtEditROC" runat="server" Width="429px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Prefix</td>
                <td>
                    <table width="100%" border="0px" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td width="15%"><asp:TextBox ID="txtEditPrefixCode" runat="server" Width="60px" 
                                    ValidationGroup="EditPrefix"></asp:TextBox></td>
                            <td width="5%"><asp:RequiredFieldValidator ID="rfvEditPrefixCode" runat="server" ControlToValidate="txtEditPrefixCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="EditPrefix"></asp:RequiredFieldValidator></td>
                            <td width="50%"><asp:TextBox ID="txtEditPrefixName" runat="server" Width="250px" ValidationGroup="EditPrefix"></asp:TextBox></td>
                            <td width="5%"><asp:RequiredFieldValidator ID="rfvEditPrefixName" runat="server" ControlToValidate="txtEditPrefixName" ErrorMessage="*" ForeColor="Red" ValidationGroup="EditPrefix"></asp:RequiredFieldValidator></td>
                            <td width="25%">
                                <asp:Button ID="btnEditPrefix" runat="server" Text="Add Prefix" Width="80px" 
                                    ValidationGroup="EditPrefix" Height="23px" onclick="btnEditPrefix_Click" /></td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:GridView ID="gvEditPrefix" runat="server" AutoGenerateColumns="False" 
                            Width="97%" onrowdeleting="gvEditPrefix_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="PrefixCode" HeaderText="Prefix" />
                            <asp:BoundField DataField="PrefixName" HeaderText="Name">
                            <ItemStyle Width="300px" />
                            </asp:BoundField>
                            <asp:CommandField ShowDeleteButton="True" CausesValidation="False"/>
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
                    <td></td>
            </tr>
            <tr>
                <td class="style1">
                    GST</td>
                <td class="style8">
                    <asp:DropDownList ID="ddlEditGST" runat="server" Height="20px" Width="220px">
                        <asp:ListItem Value="NO">NO GST</asp:ListItem>
                        <asp:ListItem Value="INC">INC GST</asp:ListItem>
                        <asp:ListItem Value="EXEC">EXEC GST</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Reflect To Operation</td>
                <td class="style8">
                    <asp:RadioButtonList ID="rblEditReflectToOps" runat="server" Height="17px" 
                        RepeatDirection="Horizontal" Width="93px">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Letter Head</td>
                <td class="style8">
                    <asp:FileUpload ID="fluEditLetterHead" runat="server"  />
                </td>
            </tr>
            <tr>
                <td class="style1">
                   </td>
                <td class="style8" colspan="2">
                   
                    <asp:Button ID="btnViewLetterHead" runat="server" Text="View Letter Head" 
                        Width="150px" ValidationGroup="Edit" onclick="btnViewLetterHead_Click" />
                   
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="77px" 
                        onclick="btnConfirm_Click" ValidationGroup="Edit"/>
                   
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="77px" 
                        onclick="btnDelete_Click" ValidationGroup="Edit"/>
                   
                &nbsp;
                    <asp:Label ID="lblEditMessage" runat="server"></asp:Label>
                   
                    <asp:HiddenField ID="hdnID" runat="server" />
                   
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of Third Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>