<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyTrips.aspx.cs" Inherits="WOC.Book.Operation.DailyTrips" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .flatstyle {
            border: 1px solid #000000; 
        }
    </style>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="../Jquery/css/ui-lightness/jquery-ui-1.8.13.custom.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="../Jquery/jquery.autocomplete.css" />
    	
    <script type="text/javascript" src="../Jquery/js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../Jquery/js/jquery-ui-1.8.13.custom.min.js"></script>
    <script type="text/javascript" src="../Jquery/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="../Jquery/jquery.autocomplete.js"></script>
    
    <telerik:RadScriptBlock ID="rsbDatePicker" runat="server">
        <script type="text/javascript" src="../Jquery/js/datepicker/locale/jquery.ui.datepicker-<%= WOC.Book.Properties.WebResources.datelocale %>.min.js"></script>
        <script type="text/javascript" language="javascript">
            var regionString = '<%= WOC.Book.Properties.WebResources.datelocale %>'
            function OpenPreviewPage() {
                var tripDate = $('#' + '<%= txtDate.ClientID %>').val();
                window.open('PreviewTrip.aspx?TripDate=' + tripDate);
            }
        </script>
    </telerik:RadScriptBlock>
    <!-- navigation keys -->
    <script language="javascript" type="text/javascript">
        $(document).ready(function () 
        {
            var borderColor = "#ECC3BF";
            $.datepicker.setDefaults($.datepicker.regional[regionString]);

            //For navigating using left and right arrow of the keyboard
            $("input[type='text'], select").keydown(
            function (event) {
                if ((event.keyCode == 39) || (event.keyCode == 9 && event.shiftKey == false)) {
                    var inputs = $(this).parents("form").eq(0).find("input[type='text'], select");
                    var idx = inputs.index(this);
                    if (idx == inputs.length - 1) {
                        inputs[0].select()
                    } else {
                        $(this).parents("table").eq(0).find("tr").not(':first').each(function () {
                            $(this).attr("style", "BACKGROUND-COLOR: white; COLOR: #003399");
                        });
                        inputs[idx + 1].parentNode.parentNode.style.backgroundColor = borderColor;
                        inputs[idx + 1].focus();
                    }
                    return false;
                }
                if ((event.keyCode == 37) || (event.keyCode == 9 && event.shiftKey == true)) {
                    var inputs = $(this).parents("form").eq(0).find("input[type='text'], select");
                    var idx = inputs.index(this);
                    if (idx > 0) {
                        $(this).parents("table").eq(0).find("tr").not(':first').each(function () {
                            $(this).attr("style", "BACKGROUND-COLOR: white; COLOR: #003399");
                        });
                        inputs[idx - 1].parentNode.parentNode.style.backgroundColor = borderColor;

                        inputs[idx - 1].focus();
                    }
                    return false;
                }
            });

//            //For navigating using up and down arrow of the keyboard
//            $("input[type='text'], select").keydown(
//            function (event) {
//                if ((event.keyCode == 40)) {
//                    if ($(this).parents("tr").next() != null) {
//                        var nextTr = $(this).parents("tr").next();
//                        var inputs = $(this).parents("tr").eq(0).find("input[type='text'], select");
//                        var idx = inputs.index(this);
//                        nextTrinputs = nextTr.find("input[type='text'], select");
//                        if (nextTrinputs[idx] != null) {
//                            $(this).parents("table").eq(0).find("tr").not(':first').each(function () {
//                                $(this).attr("style", "BACKGROUND-COLOR: white; COLOR: #003399");
//                            });
//                            nextTrinputs[idx].parentNode.parentNode.style.backgroundColor = borderColor;
//                            nextTrinputs[idx].focus();
//                        }
//                    }
//                    else {
//                        $(this).focus();
//                    }
//                }
//                if ((event.keyCode == 38)) {
//                    if ($(this).parents("tr").next() != null) {
//                        var nextTr = $(this).parents("tr").prev();
//                        var inputs = $(this).parents("tr").eq(0).find("input[type='text'], select");
//                        var idx = inputs.index(this);
//                        nextTrinputs = nextTr.find("input[type='text'], select");
//                        if (nextTrinputs[idx] != null) {
//                            $(this).parents("table").eq(0).find("tr").not(':first').each(function () {
//                                $(this).attr("style", "BACKGROUND-COLOR: white; COLOR: #003399");
//                            });
//                            nextTrinputs[idx].parentNode.parentNode.style.backgroundColor = borderColor;
//                            nextTrinputs[idx].focus();
//                        }
//                        return false;
//                    }
//                    else {
//                        $(this).focus();
//                    }
//                }
//            });
        });    
    </script>
    <!-- end of navigation keys-->

    <script language='javascript' type='text/javascript'>
        $(function (e) {
            var widthLen = window.screen.width - (window.screen.width * 0.01);
            var heightLen = window.screen.height - 120;
            //$('#txtDate').datepicker({ showOn: 'button' });
            
            
            $("#dialogDailyTrip").dialog({
                width: widthLen,
                height: heightLen,
                closeOnEscape: true,
                modal: true,
                close: function () {
                    window.location.href = "OperationMenu.aspx"
                }
            });
            $('#btnSearch').focus();
            $('#txtDate').datepicker();

        });

        function InsertOperationAjax(e, startTimeID, startBusNoID, endTimeID, endBusNoID, refNo, remarks, route, pax, searchDate, tripFrom, tripTo, tripType, operationType, tripID)
        {
            e = e || window.event;
            var code = e.keyCode || e.which;
            if (code == 13) {
                
                var startStatus = "0";
                var endStatus = "0";
                var startTime = document.getElementById(startTimeID).value;
                var startBusNo = document.getElementById(startBusNoID).value;
                var endTime = document.getElementById(endTimeID).value;
                var endBusNo = document.getElementById(endBusNoID).value;

                var isConfirmed = confirm("Are you sure do you want to input this trip?");

                if (isConfirmed == false)
                {
                    return false;
                }

                if (document.getElementById(startTimeID).disabled == true) 
                {
                    startStatus = "1";
                }

                if (document.getElementById(endTimeID).disabled == true) {
                    endStatus = "1";
                }

                var module = "operation";
                var action = "saveoperation";
                var reqParams = "&starttime=" + startTime + 
                                "&startbusno=" + startBusNo +
                                "&endtime=" + endTime + 
                                "&endbusno=" + endBusNo +
                                "&refno=" + refNo + 
                                "&remarks=" + remarks +
                                "&route=" + route + 
                                "&pax=" + pax +
                                "&searchdate=" + searchDate +
                                "&startstatus=" + startStatus +
                                "&endstatus=" + endStatus +
                                "&tripfrom=" + tripFrom +
                                "&tripto=" + tripTo +
                                "&tripType=" + tripType +
                                "&operationType=" + operationType +
                                "&tripID=" + tripID;
                var queryString = "?module=" + module + "&action=" + action + reqParams;
                $.get("OperationAjax.aspx" + queryString, function (response) {
                    var objFrame = document.getElementById("rightFrame");
                    switch (response) {
                        case "1":
                            document.getElementById(startTimeID).disabled = true;
                            document.getElementById(startBusNoID).disabled = true;
                            document.getElementById(endTimeID).disabled = true;
                            document.getElementById(endBusNoID).disabled = true;
                            objFrame.src = "DailyTripsRFrame.aspx?opsdate=" + searchDate + "#" + endBusNo;
                            break;
                        case "2":
                            document.getElementById(startTimeID).disabled = true;
                            document.getElementById(startBusNoID).disabled = true;
                            objFrame.src = "DailyTripsRFrame.aspx?opsdate=" + searchDate + "#" + startBusNo;
                            break;
                        case "0":
                            document.getElementById(endTimeID).disabled = true;
                            document.getElementById(endBusNoID).disabled = true;
                            objFrame.src = "DailyTripsRFrame.aspx?opsdate=" + searchDate + "#" + endBusNo;
                            break;
                    }
                    if (response != "99") {
                        window.parent.frames[0].location.reload();
                        var inputs = $(this).parents("form").eq(0).find("input[type='text'], select");
                        var idx = inputs.index(this);
                        if (idx > 0) {
                            $(this).parents("table").eq(0).find("tr").not(':first').each(function () {
                                $(this).attr("style", "BACKGROUND-COLOR: white; COLOR: #003399");
                            });
                            inputs[idx - 1].parentNode.parentNode.style.backgroundColor = borderColor;

                            inputs[idx - 1].focus();
                        }
                        return false;
                        //$('#' + endTimeID).focus();
                    }
                });
            }
        }
    </script>
</head>
<body>
    <form id="dialogDailyTrip" runat="server" submitdisabledcontrols="True" >
    <asp:ScriptManager ID="scmMain" runat="server" /> 
    <table width="100%" style="margin-right: 0px;height:91%">
        <tr  >
            <td valign="top" style="width:58%;height:100%">   
                <table style="width:100%;">
                    <tr><!-- this will divert focus to txtDate -->
                        <td colspan="3">
                           &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>Date:</td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" Width="180px" CssClass="flatstyle"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvSearchDate" runat="server" 
                                ControlToValidate="txtDate" ErrorMessage="Date Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="style1">
                            <asp:Button runat="server" id="btnSearch"  Width="100px" Text="Search" onclick="btnSearch_Click" UseSubmitBehavior="False"/>
                            <input type="button" id="btnPrint" value="Export To Excel" onclick="OpenPreviewPage();" style="width:120px;" disabled=disabled runat="server"/>
                            <asp:Button ID="btnClear" runat="server" onclick="btnClear_Click" Text="Clear" Width="109px" UseSubmitBehavior="False" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="style1">
                            <asp:HiddenField ID="hdnJqueryBus" runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                                AllowPaging="True" Width="100%" Font-Names="Calibri"  DataKeyNames="TripID,OperationType,TripFrom,TripTo,TripType,RefNo"
                                onrowdatabound="gv_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Route">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoute" runat="server" 
                                            Width="300px" Text ='<%# Bind("Route") %>' 
                                            Font-Size="Small" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start<br>Time">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartTime" runat="server" Width="40px" CssClass="flatstyle"
                                            Text ='<%# DataBinder.Eval(Container.DataItem, "StartTime","{0:HHmm}")%>' 
                                            Font-Size="Small" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Bus No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartBusNo" runat="server" Width="60px" CssClass="flatstyle"  
                                            Text ='<%# Bind("StartBusNo") %>' Font-Size="Small" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End<br>Time">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEndTime" runat="server" Width="40px" CssClass="flatstyle" 
                                            Text ='<%# DataBinder.Eval(Container.DataItem, "EndTime","{0:HHmm}") %>' 
                                            Font-Size="Small" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bus No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEndBusNo" runat="server" Width="60px" CssClass="flatstyle"  
                                            Text ='<%# Bind("EndBusNo") %>' Font-Size="Small"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ref No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefNo" runat="server" Width="120px"  Text ='<%# Bind("RefNo") %>' Font-Size="Small"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Pax" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPax" runat="server" Width="30px"  Text ='<%# Bind("Pax") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" Width="150px"  Text ='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
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
                        <td colspan="3">
                            <asp:Label ID="lblRecordFound" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>                    

            </td>
            <td  style="height:100%">
                <telerik:RadAjaxManager ID="scmDailyTrip" runat="server">
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="lpnlDailyTrip" runat="server" Skin="Default" />
                <telerik:RadAjaxPanel ID="pnlDailyTrip" runat="server" Height="100%" Width="100%">
                    <iframe  src="DailyTripsRFrame.aspx" id="rightFrame" scrolling="yes" runat="server" width="100%" height="100%" style="border:1px">
                    </iframe>
                </telerik:RadAjaxPanel>
            </td>
        </tr>

    </table>
        
    </form>
</body>
</html>
