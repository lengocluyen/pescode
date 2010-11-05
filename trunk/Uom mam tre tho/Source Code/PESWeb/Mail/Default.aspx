<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PESWeb.Mail.Default" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<%@ Register Src="~/Mail/UserControls/Folders.ascx" TagPrefix="PES" TagName="Folders" %>
<asp:Content ID="Folders" ContentPlaceHolderID="FoldersMail" runat="server">
    <PES:Folders ID="Folders1" runat="server"></PES:Folders>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_9">
        <div class="page-heading hr">
            <h2>
                Hòm thư</h2>
        </div>
        <div class="divContainerRow">
        <table width="100%">
            <tr>
                <td align="left">
                    <asp:Button ID="btnDelete" CssClass="button" Text="Xóa" runat="server" OnClick="btnDelete_Click" />
                </td>
                <td colspan="2">
                    <asp:HyperLink ID="linkPrevious" runat="server" Text="Previous" />
                    <asp:PlaceHolder ID="phPages" runat="server"></asp:PlaceHolder>
                    <asp:HyperLink ID="linkNext" runat="server" Text="Next" />
                </td>
            </tr>
            <asp:Repeater ID="repMessages" runat="server" OnItemDataBound="repMessages_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td width="10">
                            <asp:CheckBox ID="chkMessage" runat="server" />
                        </td>
                        <td width="100" align="left">
                            <asp:HyperLink ID="linkProfile" runat="server" Text='<%# ((MessageWithRecipient)Container.DataItem).Sender.Username %>'></asp:HyperLink>
                        </td>
                        <td align="left">
                            <asp:HyperLink ID="linkMessage" runat="server" Text='<%# ((MessageWithRecipient)Container.DataItem).Message.Subject %>'></asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        </div>
    </div>
    
    
    <div class="grid_4" style="margin-top: 35px">
        <div class="box">
            <PES:Friends runat="server" ID="friens" />
        </div>
    </div>
</asp:Content>
