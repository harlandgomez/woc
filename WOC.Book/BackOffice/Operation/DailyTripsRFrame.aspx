<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyTripsRFrame.aspx.cs" Inherits="WOC.Book.Operation.DailyTripsRFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        input {
            border: 1px solid #000000; 
        }
    </style>
    <script type="text/javascript" src="../Jquery/js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../Jquery/js/jquery-ui-1.8.13.custom.min.js"></script>
    <script language="javascript" type="text/javascript">
        function SaveRouteAjax(fieldName, txtValue, opsDate, id) {
            var module = "operation";
            var action = "updateroute";
            var queryString = "?module=" + module + "&action=" + action + "&fieldname=" + fieldName + "&id=" + id + "&value=" + txtValue.value + "&opsdate=" + opsDate;

            $.get("OperationAjax.aspx" + queryString, function (response) {
                if (response.indexOf("Successfully") != -1) {
                    alert(response + ' (' + fieldName.toUpperCase() + ')');
                }
            });

        }

        function InsertRouteAjax(e, opsId, busno, driver, contactNo, opsDate, tripTime, route, agent, person, contact) {
//            e = e || window.event;
//            var code = e.keyCode || e.which;
//            if (code == 13) {
                var module = "operation";
                var action = "saveroute";
                var reqParams = "&opsid=" + opsId.value + "&busno=" + busno.value + "&driver=" + driver.value + "&contactno=" + contactNo.value + "&opsdate=" + opsDate;
                var params = "&triptime=" + tripTime.value + "&route=" + route.value + "&agent=" + agent.value + "&person=" + person.value + "&contact=" + contact.value;
                var queryString = "?module=" + module + "&action=" + action + reqParams + params;
                $.get("OperationAjax.aspx" + queryString, function (response) {
                    if (response.indexOf("Successfully") != -1) {
                        alert(response);
                        window.location.reload();
                    }
                });
//            }



            }

            function RefreshParent(opsDate) {
                var url = window.parent.location.href;
                var newUrl = url.split("?")[0];
                window.parent.location.href = newUrl + '?opsdate=' + opsDate;
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Calibri">
    <asp:Repeater ID="rpt" runat="server" onitemdatabound="rpt_ItemDataBound" >
          <ItemTemplate>  
                <a id="<%# Eval("BusNo") %>" style="width:0px"/>
                <table cellspacing="0" rules="all" border="1" id="tblItemRrptr" style="width:562px;border-collapse:collapse;">
                    <thead>
                        <td><asp:Label id="lblBusNo" Text='<%# Eval("BusNo")%>' runat="server" Width="57px"></asp:Label></td>
                        <td style="width:327px"><%# Eval("Driver") %>&nbsp;<%# Eval("Contact") %></td>
                        <td style="width:64px">Customer</td>
                        <td style="width:64px">Person</td>
                        <td style="width:64px">Contact</td>
                    </thead>
                </table>
                <asp:HiddenField ID="hdnSubcon" runat="server" Value='<%# Eval("IsSubcon") %>' /> 
               <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"  ShowHeader="false" OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_RowCommand" OnRowDeleting="gv_RowDeleting">
                    <Columns>
                        <asp:templatefield>
                            <itemtemplate>
                               <asp:TextBox ID="txtPickup" Text='<%#Eval("TripTime","{0:HHmm}")%>' runat="server" Width="55px" Font-Size="Small"></asp:TextBox>
                            </itemtemplate>
                        </asp:templatefield>  
                        <asp:templatefield>
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("OperationDetailID") %>' />
                                <asp:TextBox ID="txtRoute" runat="server" Text='<%# Eval("DriverRoute") %>' Width="298px" Height="16" Font-Size="Small" Font-Names="Calibri"></asp:TextBox>
                                <asp:HiddenField ID="hdnOpsID" runat="server" Value='<%# Eval("OperationID") %>' />
                                <asp:HiddenField ID="hdnBusNo" runat="server" Value='<%# Eval("BusNo") %>' />
                                <asp:HiddenField ID="hdnDriverName" runat="server" Value='<%# Eval("DriverName") %>' />
                                <asp:HiddenField ID="hdnDriverContact" runat="server" Value='<%# Eval("DriverContact") %>' />
                                <asp:HiddenField ID="hdnSegmentType" runat="server" Value='<%# Eval("SegmentType") %>' />
                            </ItemTemplate>
                        </asp:templatefield>
                        <asp:templatefield>
                            <ItemTemplate>
                                <asp:TextBox ID="txtAgent" runat="server" Text='<%# Eval("Customer") %>' Width="62px" Height="16" Font-Size="Small" Font-Names="Calibri"></asp:TextBox>
                            </ItemTemplate>
                        </asp:templatefield>
                        <asp:templatefield>
                            <ItemTemplate>
                                <asp:TextBox ID="txtPerson" runat="server" Text='<%# Eval("Person") %>' Width="60px" Height="16" Font-Size="Small" Font-Names="Calibri"></asp:TextBox>
                            </ItemTemplate>
                        </asp:templatefield>
                        <asp:templatefield>
                            <ItemTemplate>
                                <asp:TextBox ID="txtContact" runat="server" Text='<%# Eval("Contact") %>' Width="61px" Height="16" Font-Size="Small" Font-Names="Calibri"></asp:TextBox>
                            </ItemTemplate>
                        </asp:templatefield>
                        <asp:CommandField ShowDeleteButton="True" ItemStyle-Font-Size="Smaller" />
                    </Columns>
               </asp:GridView>    
              </ItemTemplate>  
            <SeparatorTemplate>
            <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
               <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" 
        ShowHeader="False" >
                    <Columns>
                        <asp:templatefield>
                            <itemtemplate>
                               <%#Eval("PickUp")%>
                            </itemtemplate>
                            <ItemStyle Width="65px" Wrap="False" />
                        </asp:templatefield>  
                        <asp:templatefield>
                            <ItemTemplate>
                                <asp:TextBox ID="txtRoute" runat="server" Text='<%# Eval("Route") %>' Width="300px" Height="16" Font-Size="Smaller"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="300px" Wrap="False" />
                        </asp:templatefield>  
                        <asp:BoundField DataField="Customer" />
                        <asp:BoundField DataField="Person" />
                        <asp:BoundField DataField="Contact" />
                    </Columns>
               </asp:GridView> 
    </form>
</body>
</html>
                        <!-- <asp:TemplateField ControlStyle-Width="0px" ControlStyle-BorderWidth="0px" ItemStyle-Wrap="False">
                            <HeaderTemplate>
                                <div>Driver</div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a id="<%# Eval("BusNo") %>"/>
                                <div><%# Eval("BusNo")%></div>
                            </ItemTemplate>
                        </asp:TemplateField>-->
