<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubconExportXLS.aspx.cs" Inherits="WOC.Book.Report.SubconExportXLS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .headerRow 
        { 
            font-weight:bold; 
            font-size:9pt; 
        }
        .itemRow
        {
            font-size:8pt; 
        }
        .separateRow
        {
            border-left-color:White;
            border-left-style:none;
            border-right-color:White;           
            border-right-style:none;
            border-collapse:collapse;
            font-size:8pt; 
            font-family:Arial;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <% 
        Response.AppendHeader("Content-Disposition", String.Format("attachment; filename=Subcon_{0}.xls", DateTime.Now.ToString(WOC.Book.Properties.WebResources.fileSuffixFormat)));
        Response.ContentType = "application/vnd.ms-excel";
    %>
    <asp:Table ID="tblMain" runat="server" CellPadding="0" BorderWidth="0" CellSpacing="0" CssClass="separateRow" Font-Size="XX-Small"></asp:Table>
    </form>
</body>
</html>
