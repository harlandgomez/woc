<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubConDropdown.ascx.cs" Inherits="WOC.Book.Controls.SubConDropdown" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadComboBox ID="cboSubCon" runat="server" DataTextField="Company" 
    DataValueField="SubConID" EmptyMessage="-Select SubCon-" Culture="(Default)">
</telerik:RadComboBox>
