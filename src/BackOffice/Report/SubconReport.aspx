<%@ Page Title="" Language="C#" MasterPageFile="~/Report/Report.Master" AutoEventWireup="true" CodeBehind="SubconReport.aspx.cs" Inherits="WOC.Book.Report.SubconReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../Controls/SubConDropdown.ascx" tagname="SubConDropdown" tagprefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <telerik:RadScriptBlock ID="rsbDatePicker" runat="server">
        <script type="text/javascript" language="javascript">
            function OpenPreviewPage() {
                var tripDate = $('#' + '<%= txtDate.ClientID %>').val();
                window.open('SubconExportXLS.aspx?TripDate=' + tripDate);
            }
        </script>
    </telerik:RadScriptBlock>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtDate").datepicker();
        });
  </script>
  <div>
        <asp:Label ID="lblSystemError" runat="server" ForeColor="Red" ></asp:Label>
   </div>
    <h2>
        Subcon Export</h2>
        
        <table width="100%" style="margin-right: 0px" id = "tblSubcon">
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Subcon:</td>
                <td>
                    <uc1:SubConDropdown ID="cboSubcon" runat="server" Width="200px" />
                </td>
            </tr>
            <tr>
                <td >Date:</td>
                <td >
                    <asp:TextBox ID="txtDate" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>  
             <tr>
                <td ></td>
                <td >
                    <input id="btnExport" type="button" value="Export To XLS" 
                        onclick="OpenPreviewPage();" style="width: 100px" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                 <td><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
            </tr>  
                       
        </table>
  
   
</asp:Content>