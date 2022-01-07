<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EmailTemplate.aspx.cs" Inherits="WOC.Book.Admin.EmailTemplate" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table style="background-color:White">
        <tr>
            <td colspan="2"><h2>Email Template</h2></td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>Subject:</td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadEditor ID="reEmailTemplate" Runat="server" CssClass="editor"
                    EditModes="Design, Preview" EnableAjaxSkinRendering="False" 
                    EnableResize="False" EnableTheming="True" EnableViewState="False" 
                    BackColor="White" ></telerik:RadEditor>
            </td>
        </tr>
    </table>

</asp:Content>
