<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WOC.Book.Login" MasterPageFile ="~/SiteLogin.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   
    <style type="text/css">
        .RadText
        {
            font-family: Tahoma;
            font-size: small;
        }
    </style>
   
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    <table class="LoginScreen" cellpadding="0px" cellspacing="0px">
        <tr>    
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="7">
                <telerik:RadBinaryImage ID="rimgAccess" runat="server" ImageUrl="Access.png" />
            </td>
            <td>&nbsp;</td>
             <td rowspan="7">
                <telerik:RadBinaryImage ID="rimgLogin" runat="server" ImageUrl="Login.png" />
            </td>
        </tr>
        <tr>
            <td><span class="RadText">Username</span>:</td>
        </tr>
        <tr>
            <td>
                <telerik:RadTextBox ID="rtxtUserName" runat="server" EmptyMessage="Username" 
                    Width="250px" ToolTip="Input the Username" TabIndex="1">
                </telerik:RadTextBox>
                <br />
            </td>

        </tr>
        <tr>
            <td valign="bottom"><span class="RadText">Password</span>:</td>
        </tr>
        <tr>
            <td valign="top">
                <telerik:RadTextBox ID="rtxtPassword" runat="server" EmptyMessage="Password" 
                    Width="250px" TextMode="Password" ToolTip="Input the password" 
                    TabIndex="2">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <telerik:RadButton ID="rbtnLogin" runat="server" Text="Login" Width="100px" 
                    TabIndex="3" onclick="rbtnLogin_Click">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td colspan="3"><asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>&nbsp;</td>
        </tr>
    </table>
</asp:Content>