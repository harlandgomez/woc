<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgentDropdown.ascx.cs" Inherits="WOC.Book.Controls.AgentDropdown" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadComboBox ID="cboAgent" runat="server" DataTextField="Agent" ClientIDMode="Predictable"
    DataValueField="AgentID" EmptyMessage="-Select Agent-" Culture="(Default)" 
    CollapseDelay="100" ExpandDelay="50">
</telerik:RadComboBox>