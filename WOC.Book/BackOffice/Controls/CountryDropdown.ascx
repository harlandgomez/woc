<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CountryDropdown.ascx.cs" Inherits="WOC.Book.Controls.CountryDropdown" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadComboBox ID="cboCountry" runat="server" DataTextField="Country" DataValueField="CountryID" EmptyMessage="-Select Country-" Culture="(Default)"></telerik:RadComboBox>