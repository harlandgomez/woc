<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyDropdown.ascx.cs" Inherits="WOC.Book.Controls.CompanyDropdown" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadComboBox ID="cboCompany" runat="server" DataTextField="Company" 
    DataValueField="CompanyID" EmptyMessage="-Select Company-" Culture="(Default)">
</telerik:RadComboBox>
