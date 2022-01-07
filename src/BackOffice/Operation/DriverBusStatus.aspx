<%@ Page Title="" Language="C#" MasterPageFile="~/Operation/Operation.Master" AutoEventWireup="true" CodeBehind="DriverBusStatus.aspx.cs" Inherits="WOC.Book.Operation.DriverBusStatus" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 77px;
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
            width: 452px;
        }
        .style8
        {
            width: 452px;
            height: 26px;
        }
        .style9
        {
            width: 453px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {

            $("#MainContent_txtDriverDateStatus").datepicker();
            $("#MainContent_txtBusDateStatus").datepicker();
            $("#MainContent_txtDriverBusSearchDateFrom").datepicker();
            $("#MainContent_txtDriverBusSearchDateTo").datepicker();
            $("#MainContent_txtCOSDateFrom").datepicker();
            $("#MainContent_txtCOSDateTo").datepicker();

            // Tabs
            $('#tabs').tabs({
                cookie: {
                    // store cookie for a day, without, it would be a session cookie
                    expires: 1
                }
            });

          
            var searchDriver = document.getElementById('MainContent_txtDriverStatus').value;
            $('#MainContent_txtDriverStatus').autocomplete("../AutocompleteData/AutocompleteDriverStatus.ashx?category=drivername&parameter=" + searchDriver);

            var searchBus = document.getElementById('MainContent_txtBusStatus').value;
            $('#MainContent_txtBusStatus').autocomplete("../AutocompleteData/AutocompleteBusStatus.ashx?category=BusNo&parameter=" + searchDriver);
        

        });

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
    

  </script>
  <div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
 </div>
<!-- Begin of Tabs -->
 
<div id="tabs"> 

<!-- Main Tabs -->
    <ul>
	    <li><a href="#tabs-1">Add Driver/Bus Status</a></li>
	    <li><a href="#tabs-2">Search Driver/Bus Status</a></li>
        <li><a href="#tabs-3">Cash Order Search</a></li>
			
    </ul>
    <!-- First Tab -->
    <div id="tabs-1">
         <asp:Button ID="btnAddDriverPanel" runat="server" Text="Add Driver Status" 
                Width="128px" onclick="btnAddDriverPanel_Click" />
            <asp:Button ID="btnAddBusPanel" runat="server" Text="Add Bus Status" 
                Width="128px" onclick="btnAddBusPanel_Click" />
        <asp:Panel ID="pnlAddDriver" runat="server">
          <h3>Add Driver Status</h3>
          <table style="width:100%;">
            <tr>
                <td class="style1">
                    Driver:</td>
                <td class="style7">
                    <asp:TextBox ID="txtDriverStatus" runat="server" Width="433px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAddDriver" runat="server" 
                        ControlToValidate="txtDriverStatus" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="AddDriver"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Date:</td>
                <td class="style8">
                    <asp:TextBox ID="txtDriverDateStatus" runat="server" Width="433px" 
                        MaxLength="10"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    Time (From):</td>
                <td class="style7">
                    <asp:TextBox ID="txtDriverTimeFrom" runat="server" Width="167px" 
                        onChange='checkNumeric(this)' MaxLength="4"></asp:TextBox>
                    Time (To):<asp:TextBox ID="txtDriverTimeTo" runat="server" Width="192px" 
                        onChange='checkNumeric(this)' MaxLength="4"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    Status:</td>
                <td class="style7">
                    <asp:TextBox ID="txtNewDriverStatus" runat="server" Width="433px" Height="63px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style1">
                   </td>
                <td class="style7">
                   
                    <asp:Button ID="btnAddDriverStatus" runat="server" Text="Add" Width="77px" 
                         ValidationGroup="AddDriver" onclick="btnAddDriverStatus_Click" />
                   
                    <asp:Label ID="lblDriverMessage" runat="server"></asp:Label>
                   
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>
      
        
        <asp:Panel ID="pnlAddBus" runat="server" Visible = "false">
        <h3>Add Bus Status</h3>
              <table style="width:100%;">
            <tr>
                <td class="style1">
                    Bus:</td>
                <td class="style9">
                    <asp:TextBox ID="txtBusNo" runat="server" Width="428px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAddBus" runat="server" 
                        ControlToValidate="txtBusStatus" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="AddBus"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Date:</td>
                <td class="style9">
                    <asp:TextBox ID="txtBusDateStatus" runat="server" Width="429px" MaxLength="10"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    Time (From):</td>
                <td class="style9">
                    <asp:TextBox ID="txtBusTimeFrom" runat="server" Width="176px" 
                        onChange='checkNumeric(this)' MaxLength="5"></asp:TextBox>
                    Time (To):<asp:TextBox ID="txtBusTimeTo" runat="server" Width="175px" 
                        onChange='checkNumeric(this)' MaxLength="4"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
               <tr>
                <td class="style1">
                    Status:</td>
                <td class="style9">
                    <asp:TextBox ID="txtBusStatus" runat="server" Width="429px" Height="69px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
               <tr>
                <td class="style1">
                    PO:</td>
                <td class="style9">
                    <asp:TextBox ID="txtPoNumber" runat="server" Width="429px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style1">
                   </td>
                <td class="style9">
                   
                    <asp:Button ID="btnAddBusStatus" runat="server" Text="Add" Width="77px" 
                        onclick="btnAddBusStatus_Click" ValidationGroup="AddBus" 
                        style="height: 26px" />
                   
                    <asp:Label ID="lblBusMessage" runat="server"></asp:Label>
                   
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    <!-- End Of First Tab -->

    <!-- Second Tab -->
    <div id="tabs-2">
        <h3>Search Driver / Bus Statusatus</h3>
        <table style="width:100%; height: 140px;">
                        <tr>
                            <td class="style15">
                                Date From:</td>
                            <td class="style16">
                                <asp:TextBox ID="txtDriverBusSearchDateFrom" runat="server" Width="160px"></asp:TextBox>
                            </td>
                            <td class="style16">
                                Date To:</td>
                                 <td class="style16">
                                <asp:TextBox ID="txtDriverBusSearchDateTo" runat="server" Width="160px"></asp:TextBox>
                                     </td>
                                 <td class="style16">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Time (From):</td>
                            <td class="style13">
                                <asp:TextBox ID="txtDriverSearchTimeFrom" runat="server" Width="160px" 
                                    onChange='checkNumeric(this)' MaxLength="4"></asp:TextBox>
                            </td>
                            <td class="style14">
                                Time (To):</td>
                                 <td class="style6">
                                <asp:TextBox ID="txtDriverSearchTimeTo" runat="server" Width="160px" 
                                         onChange='checkNumeric(this)' MaxLength="4" ></asp:TextBox>
                                     </td>
                                 <td class="style6">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Driver:</td>
                            <td class="style6">
                                <asp:TextBox ID="txtDriverBusSearchDriver" runat="server" Width="160px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                </td>
                                 <td class="style6">
                                     </td>
                                 <td class="style6">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Bus No:</td>
                            <td class="style12">
                                <asp:TextBox ID="txtDriverBusSearchBusNo" runat="server" Width="160px"></asp:TextBox>
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
                               </td>
                            <td class="style12" colspan="3">
                   
                                <asp:Button ID="btnSearchDriver" runat="server" Text="Search" Width="77px" 
                                    onclick="btnSearchDriver_Click" />
                   
                                <asp:Label ID="lblSearchDriver" runat="server" Visible="False"></asp:Label>
                   
                            </td>
                                 <td>
                                     &nbsp;</td>
                        </tr>
                  </table>
        <table style="width:100%; height: 140px;">
                  <tr>
                  <td>
                  
                      <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%">
                          <Columns>
                              <asp:BoundField DataField="BusNo" HeaderText="Bus No" />
                              <asp:BoundField DataField="Driver" HeaderText="Driver" />
                              <asp:BoundField DataField="OperationDate" HeaderText="Time"  />
                              <asp:BoundField DataField="Status" HeaderText="Status" />
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
    <!-- End Of Second Tab -->

    <!-- Third Tab -->
    <div id="tabs-3">
     <h3>Cash Order Search</h3>
     
        <table style="width:100%; height: 140px;">
                        <tr>
                            <td class="style15">
                                Date From:</td>
                            <td class="style16">
                                <asp:TextBox ID="txtCOSDateFrom" runat="server" Width="160px"></asp:TextBox>
                            </td>
                            <td class="style16">
                                Date To:</td>
                                 <td class="style16">
                                <asp:TextBox ID="txtCOSDateTo" runat="server" Width="160px"></asp:TextBox>
                                     </td>
                                 <td class="style16">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Time (From):</td>
                            <td class="style13">
                                <asp:TextBox ID="txtCOSTimeFrom" runat="server" Width="160px" 
                                    onChange='checkNumeric(this)' MaxLength="4"></asp:TextBox>
                            </td>
                            <td class="style14">
                                Time (To):</td>
                                 <td class="style6">
                                <asp:TextBox ID="txtCOSTimeTo" runat="server" Width="160px" 
                                         onChange='checkNumeric(this)' MaxLength="4" ></asp:TextBox>
                                     </td>
                                 <td class="style6">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Driver:</td>
                            <td class="style6">
                                <asp:TextBox ID="txtCOSDriver" runat="server" Width="160px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                </td>
                                 <td class="style6">
                                     </td>
                                 <td class="style6">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Bus No:</td>
                            <td class="style12">
                                <asp:TextBox ID="txtCOSBusDriver" runat="server" Width="160px"></asp:TextBox>
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
                               </td>
                            <td class="style12" colspan="3">
                   
                                <asp:Button ID="btnSearchCOS" runat="server" Text="Search" Width="77px" 
                                    onclick="btnSearchCOS_Click" />
                   
                                <asp:Label ID="lblCOSMessage" runat="server" Visible="False"></asp:Label>
                   
                            </td>
                                 <td>
                                     &nbsp;</td>
                        </tr>
                  </table>
        <table style="width:100%; height: 140px;">
                  <tr>
                  <td>
                  
                      <asp:GridView ID="gvCOS" runat="server" AutoGenerateColumns="False" 
                          Width="100%">
                          <Columns>
                              <asp:BoundField DataField="OperationDate" HeaderText="Date" dataformatstring="{0:dd/MM/yyyy}" />
                              <asp:BoundField DataField="BusNo" HeaderText="Bus No" />
                              <asp:BoundField DataField="Driver" HeaderText="Driver" />
                              <asp:BoundField DataField="Route" HeaderText="Route" />
                              <asp:BoundField DataField="Customer" HeaderText="Customer" />
                              <asp:BoundField DataField="Contact" HeaderText="Contact" />
                              <asp:BoundField DataField="Amount" HeaderText="Amount" />
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
    <!-- End Of Third Tab -->
</div>

<!-- End Of Tabs -->
</asp:Content>