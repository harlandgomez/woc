<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusAndDriver.aspx.cs" Inherits="WOC.Book.Operation.BusAndDriver" MasterPageFile="Operation.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 77px;
        }
        .style3
        {
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
        .style10
        {
            width: 452px;
        }
        .style11
        {
            width: 452px;
            height: 26px;
        }
        .style12
        {
        }
        .style13
        {
            width: 238px;
            height: 26px;
        }
        .style14
        {
            width: 87px;
            height: 26px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <script language="javascript" type="text/javascript">
         $(document).ready(function () {

             $("#MainContent_txtDriverDateStatus").datepicker();
             $("#MainContent_txtBusDateStatus").datepicker();
             

             $("#MainContent_txtDriverSearchDateFrom").datepicker();
             $("#MainContent_txtDriverSearchDateTo").datepicker();
             

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

             // Tabs
             $('#tabs').accordion({
                 cookie: {
                     // store cookie for a day, without, it would be a session cookie
                     expires: 1
                 }
             });


             var search = document.getElementById('MainContent_txtDriverStatus').value;
             $('#MainContent_txtDriverStatus').autocomplete("../AutocompleteData/AutocompleteDriverStatus.ashx?category=drivername&parameter=" + search);
             $('#MainContent_txtDriverSearchDriver').autocomplete("../AutocompleteData/AutocompleteDriverStatus.ashx?category=drivername&parameter=" + search);

             var search = document.getElementById('MainContent_txtBusStatus').value;
             $('#MainContent_txtBusStatus').autocomplete("../AutocompleteData/AutocompleteBusStatus.ashx?category=BusNo&parameter=" + search);
            
         });

    

  </script>
    
    <div>
    
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
    
    </div>

   <div id="tabs">

    <ul>
				<li><a href="#tabs-1">Driver / Bus Status</a></li>
				<li><a href="#tabs-2">Search Driver/Bus</a></li>
                <li><a href="#tabs-3">Driver / Bus Status</a></li>
                <li><a href="#tabs-4">Available Bus</a></li>
			
	</ul>
 
    <div id="tabs-1">
             <div id="accordion1">
	            <div>
                <h3><a href="#">Add New Driver Status</a></h3>
				<div>
                
                <table style="width:100%;">
            <tr>
                <td class="style1">
                    Driver:</td>
                <td class="style10">
                    <asp:TextBox ID="txtDriverStatus" runat="server" Width="428px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtDriverStatus" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="AddDriver"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Date:</td>
                <td class="style11">
                    <asp:TextBox ID="txtDriverDateStatus" runat="server" Width="429px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    Time (From):</td>
                <td class="style11">
                    <asp:TextBox ID="txtDriverTimeFrom" runat="server" Width="167px"></asp:TextBox>
                    Time (To):<asp:TextBox ID="txtDriverTimeTo" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
               <tr>
                <td class="style4">
                    Status:</td>
                <td class="style11">
                    <asp:TextBox ID="txtNewDriverStatus" runat="server" Width="429px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            
            <tr>
                <td class="style1">
                   </td>
                <td class="style10">
                   
                    <asp:Button ID="btnAddDriverStatus" runat="server" Text="Add" Width="77px" 
                        onclick="btnAddDriverStatus_Click" ValidationGroup="AddDriver" />
                   
                    <asp:Label ID="lblDriverMessage" runat="server"></asp:Label>
                   
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
                </div>
			   </div>
				<h3><a href="#">Add New Bus Status</a></h3>
				<div>
                 
                  <table style="width:100%;">
            <tr>
                <td class="style1">
                    Bus:</td>
                <td class="style10">
                    <asp:TextBox ID="txtBusStatus" runat="server" Width="428px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtBusStatus" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="AddBus"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Date:</td>
                <td class="style11">
                    <asp:TextBox ID="txtBusDateStatus" runat="server" Width="429px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    Time (From):</td>
                <td class="style11">
                    <asp:TextBox ID="txtBusTimeFrom" runat="server" Width="176px"></asp:TextBox>
                    Time (To):<asp:TextBox ID="txtBusTimeTo" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td class="style6">
                    </td>
            </tr>
               <tr>
                <td class="style1">
                    Status:</td>
                <td class="style10">
                    <asp:TextBox ID="txtNewBusStatus" runat="server" Width="429px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
               <tr>
                <td class="style1">
                    PO:</td>
                <td class="style10">
                    <asp:TextBox ID="txtPoNumber" runat="server" Width="429px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style1">
                   </td>
                <td class="style10">
                   
                    <asp:Button ID="btnAddBusStatus" runat="server" Text="Add" Width="77px" 
                        onclick="btnAddBusStatus_Click" ValidationGroup="AddBus" 
                        style="height: 26px" />
                   
                    <asp:Label ID="lblBusMessage" runat="server"></asp:Label>
                   
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

                </div>
            </div> 	
	</div>
 
    <div id="tabs-2">

      <div id="accordion2">
          
          <div>
				<h3><a href="#">Search Driver Status</a></h3>
				<div>
                  <table style="width:100%; height: 140px;">
                        <tr>
                            <td class="style1">
                                Date From:</td>
                            <td class="style12">
                                <asp:TextBox ID="txtDriverSearchDateFrom" runat="server" Width="154px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                &nbsp;</td>
                                 <td>
                                     &nbsp;</td>
                                 <td>
                                     &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Date To:</td>
                            <td class="style13">
                                <asp:TextBox ID="txtDriverSearchDateTo" runat="server" Width="153px"></asp:TextBox>
                            </td>
                            <td class="style14">
                                </td>
                                 <td class="style6">
                                     </td>
                                 <td class="style6">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Time (From):</td>
                            <td class="style13">
                                <asp:TextBox ID="txtDriverSearchTimeFrom" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td class="style14">
                                Time (To):</td>
                                 <td class="style6">
                                <asp:TextBox ID="txtDriverSearchTimeTo" runat="server" Width="157px"></asp:TextBox>
                                     </td>
                                 <td class="style6">
                                     </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Driver:</td>
                            <td class="style12">
                                <asp:TextBox ID="txtDriverSearchDriver" runat="server" Width="153px"></asp:TextBox>
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
                  
                      <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="909px">
                          <Columns>
                              <asp:BoundField DataField="Driver" HeaderText="Driver" />
                              <asp:BoundField DataField="OperationDate" HeaderText="Operation Date" />
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
          </div>
          <div>
				<h3><a href="#">Available Bus Search<asp:GridView ID="GridView1" runat="server" 
                        AutoGenerateColumns="False" Width="837px">
                    <Columns>
                        <asp:BoundField DataField="DriverStatus" HeaderText="Driver" />
                        <asp:BoundField />
                        <asp:BoundField />
                        <asp:BoundField />
                    </Columns>
                    </asp:GridView>
                    </a></h3>
				<div>
                  <table style="width:100%;">
            <tr>
                <td class="style1">
                    Date From:</td>
                <td class="style12">
                    <asp:TextBox ID="TextBox5" runat="server" Width="153px"></asp:TextBox>
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
                    Date To:</td>
                <td class="style12">
                    <asp:TextBox ID="TextBox7" runat="server" Width="153px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Time (From):</td>
                <td class="style13">
                    <asp:TextBox ID="TextBox8" runat="server" Width="154px"></asp:TextBox>
                </td>
                <td class="style14">
                    Time (To):</td>
                     <td class="style6">
                    <asp:TextBox ID="TextBox215" runat="server" Width="167px"></asp:TextBox>
                         </td>
                     <td class="style6">
                         </td>
            </tr>
               <tr>
                <td class="style1">
                    Driver:</td>
                <td class="style12">
                    <asp:TextBox ID="TextBox15" runat="server" Width="157px"></asp:TextBox>
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
                    Bus:</td>
                <td class="style12">
                    <asp:TextBox ID="TextBox17" runat="server" Width="155px"></asp:TextBox>
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
                <td class="style12">
                   
                    <asp:Button ID="Button2" runat="server" Text="Search" Width="77px" />
                   
                </td>
                <td class="style3">
                    &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
            </tr>
        </table>
                   
               </div>
          </div>

      </div>


    </div>
    
    <div id="tabs-3">
        <table style="width:100%;" border="1px">
            <tr>
                <td><strong>BusNo</strong></td>
                <td><strong>Driver</strong></td>
                <td><strong>Date/Time</strong></td>
                <td><strong>Status</strong></td>
            </tr>     
            <tr>
                 <td>PA111Z</td>
                 <td>Romy Chan</td>
                <td >12/12/2011 12:30</td>
                <td>Ok</td>
            </tr>

             <tr>
                 <td>PA1112</td>
                 <td>Romy Chan</td>
                <td >12/12/2011 12:30</td>
                <td>Ok</td>
            </tr>
            <tr>
                 <td>PA1113</td>
                 <td>Romy Chan</td>
                <td >12/12/2011 12:30</td>
                <td>Ok</td>
            </tr>
            <tr>
                 <td>PA1114</td>
                 <td>Romy Chan</td>
                <td >12/12/2011 12:30</td>
                <td>Ok</td>
            </tr>
        </table>
    </div>
    <div id="tabs-4">
         <table style="width:100%; height: 145px;" border="1px">
            <tr>
                <td><strong>BusNo</strong></td>
                <td><strong>Last Trip</strong></td>
                <td><strong>Time</strong></td>
                <td><strong>Next Trip</strong></td>
                <td><strong>Time</strong></td>
                <td><strong>Parking</strong></td>
            </tr>     
            <tr>
                <td>PA123Z</td>
                <td>Loyang 1 Pasir Ris, Singapore 502345</td>
                <td>1/1/2011 12:30</td>
                <td>Bukit Panjang </td>
                <td>23/12/2011 18:30</td>
                <td>Can!</td>
            </tr>
            <tr>
                <td>PA123A</td>
                <td>Loyang 1 Pasir Ris, Singapore 502345</td>
                <td>1/1/2011 12:30</td>
                <td>Bukit Panjang </td>
                <td>23/12/2011 18:30</td>
                <td>Cannot!</td>
            </tr>
            <tr>
                <td>PA124Z</td>
                <td>Loyang 1 Pasir Ris, Singapore 502345</td>
                <td>1/1/2011 12:30</td>
                <td>Bukit Panjang </td>
                <td>23/12/2011 18:30</td>
                <td>Cannot what?!</td>
            </tr>
            <tr>
                <td>PA124Z</td>
                <td>Loyang 1 Pasir Ris, Singapore 502345</td>
                <td>1/1/2011 12:30</td>
                <td>Bukit Panjang </td>
                <td>23/12/2011 18:30</td>
                <td>Cannot Leh!</td>
            </tr>
        </table>
    </div>

</div>
     
       
</asp:Content>


