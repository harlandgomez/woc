<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payroll.aspx.cs" Inherits="WOC.Book.Accounts.Payroll"  MasterPageFile="~/Accounts/Accounts.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 309px;
        }
        .style4
        {
            width: 125px;
        }
        .style24
        {
            width: 490px;
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
          $("#MainContent_txtStartDate").datepicker();
          $("#MainContent_txtEndDate").datepicker();

          // Tabs
          $('#tabs').tabs({
              cookie: {
                  // store cookie for a day, without, it would be a session cookie
                  expires: 1
              }
          });
          var search = document.getElementById('MainContent_txtDriver').value;
          $('#MainContent_txtDriver').autocomplete("../AutocompleteData/AutocompleteDriver.ashx?category=DriverName&paremeter=" + search);
      });

      function SelectLastTab() {
          $('#tabs').tabs('select', 1); // switch to second tab
          return false;
      }

      function SelectFirstTab() {
          $('#tabs').tabs('select', 0); // switch to second tab
          return false;
      }

      function HasQueryString() {
          var field = 'InvoiceID';
          var url = window.location.href;
          if (url.indexOf('?' + field + '=') != -1)
              return true;
          else if (url.indexOf('&' + field + '=') != -1)
              return true;
          return false
      }

      function ShowHideControls(ddlTimeFactorName, ddlFromDayName, txtFromDateName, txtFromTimeName, ddlToDayName, txtToDateName, txtToTimeName) {
          var val = $('#' + ddlTimeFactorName).val();
          
          var fromDay = $('#' + ddlFromDayName);
          var fromDate = $('#' + txtFromDateName);
          var fromTime = $('#' + txtFromTimeName);

          var toDay = $('#' + ddlToDayName);
          var toDate = $('#' + txtToDateName);
          var toTime = $('#' + txtToTimeName);

          fromDate.datepicker();
          toDate.datepicker();

          switch (val.toString()) {
              case "1":
                  fromDay.show();
                  fromDate.hide();
                  fromTime.hide();
                  toDay.show();
                  toDate.hide();
                  toTime.hide();
                  break;
              case "2":
                  fromDay.hide();
                  fromDate.show();
                  fromTime.hide();
                  toDay.hide();
                  toDate.show();
                  toTime.hide();
                  break;
              case "3":
                  fromDay.hide();
                  fromDate.hide();
                  fromTime.show();
                  toDay.hide();
                  toDate.hide();
                  toTime.show();
                  break;
          }
      }
    </script>

<!-- Begin of Tabs -->
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Payroll</a></li>
	    <li><a href="#tabs-2">Rule Page</a></li>
		
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
        <table style="width:100%;">
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="style4">
                    From Date:</td>
                <td class="style24">
                    <asp:TextBox ID="txtStartDate" runat="server" Width="200px"></asp:TextBox>
                &nbsp;<asp:RegularExpressionValidator ID="revFromDate" runat="server" 
                        ControlToValidate="txtStartDate" ErrorMessage="*" ForeColor="Red" 
                        ValidationExpression="^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$" 
                        ValidationGroup="Search"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" 
                        ControlToValidate="txtStartDate" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Search"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    To Date:</td>
                     <td class="style2">
                    <asp:TextBox ID="txtEndDate" runat="server" Width="200px"></asp:TextBox>
                         &nbsp;<asp:RegularExpressionValidator ID="revToDate" runat="server" 
                             ControlToValidate="txtEndDate" ErrorMessage="*" ForeColor="Red" 
                             ValidationExpression="^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$" 
                             ValidationGroup="Search"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="rfvToDate" runat="server" 
                             ControlToValidate="txtEndDate" ErrorMessage="*" ForeColor="Red" 
                             ValidationGroup="Search"></asp:RequiredFieldValidator>
                         </td>
            </tr>
            <tr>
                <td class="style4">
                    Driver</td>
                <td><asp:TextBox ID="txtDriver" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        onclick="btnSearch_Click" ValidationGroup="Search" 
                        />
                </td>
                     <td class="style2">
                         &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4"><asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width = "100%" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px" 
                        onrowdatabound="gv_RowDataBound" onprerender="gv_PreRender">
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="DriverName" HeaderText="Name" HeaderStyle-BorderWidth="1px" >
                                <ItemStyle BorderWidth="1px"/>
                            </asp:BoundField>

                            <asp:BoundField DataField="BusNo" HeaderText="BusNo" HeaderStyle-BorderWidth="1px" >
                                <ItemStyle BorderWidth="1px"/>
                            </asp:BoundField>
                                                        
                            <asp:BoundField DataField="TripTime" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" HeaderStyle-BorderWidth="1px" >
                                <ItemStyle BorderWidth="1px"/>
                            </asp:BoundField>

                            <asp:BoundField DataField="TripTime" HeaderText="Time" DataFormatString="{0:HHmm}" HeaderStyle-BorderWidth="1px">
                                <ItemStyle BorderWidth="1px"/>
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="DriverRoute" HeaderText="Route" HeaderStyle-BorderWidth="1px"  >
                                <ItemStyle Width="300px" BorderWidth="1px"/>
                            </asp:BoundField>

                            <asp:BoundField DataField="Claim" HeaderText="Claim" HeaderStyle-BorderWidth="1px" >
                                <ItemStyle BorderWidth="1px"/>
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                             BorderStyle="Solid" BorderWidth="1px" />
                         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderStyle="Solid" 
                             BorderWidth="1px" />
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
                    <asp:ImageButton ID="ibtnListAll" runat="server" 
                        ImageUrl="~/Images/MenuIcons/excel_icon.png" Height="20px"  Width="20px" 
                        CausesValidation="False" Visible="false" onclick="ibtnListAll_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <!-- End Of First Tab -->
     
    <!-- Second Tab -->
    <div id="tabs-2">
        <table style="width: 100%;" border="0px">
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvRule" runat="server" AutoGenerateColumns="False" 
                        Width="80%" CellPadding="4" ForeColor="#333333" GridLines="None" 
                        DataKeyNames="RuleID" onrowcreated="gvRule_RowCreated" 
                        onrowdatabound="gvRule_RowDataBound" >
                         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Time Factor">
                                <ItemTemplate>
                                    <asp:DropDownList ID="gvRuleDropDownTimeFactor" runat="server" Width="100px" >
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Date">
                                <ItemTemplate>
                                    <asp:DropDownList ID="gvRuleDropdownFromDate" runat="server" Width="100px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="gvRuleTextboxFromDate" runat="server" Width="100px" Text='<%# Convert.ToDateTime(Eval("StartDate")).ToString(WOC.Book.Properties.WebResources.dateformat) %>'></asp:TextBox>
                                    <asp:TextBox ID="gvRuleTextboxFromTime" runat="server" Width="100px" Text='<%# Eval("StartTime") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date">
                                <ItemTemplate>
                                    <asp:DropDownList ID="gvRuleDropdownToDate" runat="server" Width="100px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="gvRuleTextboxToDate" runat="server" Width="100px"  Text='<%# Convert.ToDateTime(Eval("EndDate")).ToString(WOC.Book.Properties.WebResources.dateformat) %>'></asp:TextBox>
                                    <asp:TextBox ID="gvRuleTextboxToTime" runat="server" Width="100px"  Text='<%# Eval("EndTime") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Operator">
                                <ItemTemplate>
                                    <asp:DropDownList ID="gvRuleDropdownOperator" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvTextboxAmount" runat="server" Font-Size="Small" 
                                        Text='<%# Eval("Amount") %>' Width="100px"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderImageUrl="../Images/MiscIcons/DeleteRule.png" HeaderStyle-Width="20px" HeaderStyle-Height="20px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="gvCheckBoxDelete" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="Small" />
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
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="3" >
                    <asp:Button ID="btnAddRule" runat="server" Text="Add Rule" Width="100px" 
                        onclick="btnAddRule_Click" />&nbsp;
                    <asp:Button ID="btnSaveRule" runat="server" Text="Save" Width="100px" 
                        onclick="btnSaveRule_Click" />&nbsp;<asp:Label ID="lblRuleMessage" runat="server"></asp:Label>
                </td>
                <td><asp:Button ID="btnDeleteRule" runat="server" Text="Delete" Width="100px" 
                        onclick="btnDeleteRule_Click" /></td>
            </tr>
            <tr>
                <td colspan="4" align="right">
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" align="right">&nbsp;&nbsp;</td>
            </tr>
        </table>
    </div>
    <!-- End Of Second Tab -->

</div>
<!-- End Of Tabs -->
</asp:Content>
