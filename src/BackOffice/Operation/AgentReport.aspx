<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentReport.aspx.cs" Inherits="WOC.Book.Operation.AgentReport" MasterPageFile="Operation.Master"  %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style6
        {
            width: 55px;
            font-weight: bold;
        }
        .style7
        {
            width: 52px;
            font-weight: bold;
        }
        .style8
        {
            width: 50px;
        }
        .style9
        {
            width: 201px;
        }
        .style10
        {
            width: 201px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtSearch").datepicker();
        });
  </script>
    <h2>
        Agent Details
    </h2>
        <table width="100%" style="margin-right: 0px" id = "tblAgentReport">
            <tr>
                <td>Date:</td>
                <td>
                    <asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:DropDownList ID="ddlPagingNumber" runat="server" AutoPostBack="True" >
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>100</asp:ListItem>
                    <asp:ListItem>200</asp:ListItem>
                </asp:DropDownList></td>
            </tr>     
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="100px" 
                        onclick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Company" HeaderText="Company" />
                            <asp:BoundField DataField="RefNo" HeaderText="RefNo" />
                            <asp:BoundField DataField="Contact" HeaderText="Contact" />
                              <asp:TemplateField HeaderText="Time Go">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartTime" runat="server" Width="70px" Text ='<%# DataBinder.Eval(Container.DataItem, "StartTime","{0:HHmm}")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:BoundField DataField="StartBusNo" HeaderText="BusNo"  />
                             <asp:TemplateField HeaderText="Time Return">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndTime" runat="server" Width="70px" Text ='<%# DataBinder.Eval(Container.DataItem, "EndTime","{0:HHmm}") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:BoundField DataField="EndBusNo" HeaderText="Bus No" />
                            <asp:BoundField DataField="Route" HeaderText="Route" />
                            <asp:BoundField DataField="CashOrder" HeaderText="Cash Order" />
                        </Columns>
                    </asp:GridView>
                    <asp:ImageButton ID="ibtnListAllPDF" runat="server" 
                        ImageUrl="~/Images/MenuIcons/pdf_icon.png" Height="20px" Width="20px" 
                        CausesValidation="False" onclick="ibtnListAllPDF_Click"/>
                    <asp:Image ID="imgSeparator" runat="server" ImageUrl="~/Images/MenuIcons/separator_icon.png" Height="20px" Width="5px"/>                
                    <asp:ImageButton ID="ibtnListAll" runat="server" 
                        ImageUrl="~/Images/MenuIcons/excel_icon.png" Height="20px" Width="20px" 
                        CausesValidation="False" onclick="ibtnListAll_Click" />
                </td>
            </tr>
        </table>
  
   
</asp:Content>