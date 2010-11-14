<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PESWeb.Mail.Default" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<%@ Register Src="~/Mail/UserControls/Folders.ascx" TagPrefix="PES" TagName="Folders" %>
<%--<asp:Content ID="Folders" ContentPlaceHolderID="FoldersMail" runat="server">
    <PES:Folders ID="Folders1" runat="server"></PES:Folders>
</asp:Content>
--%>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <div class="grid_4">
        LeftContent
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
                <a href="#">Hop Thu Ca nhan</a></h1>
        </div>
        <PES:Folders ID="Folders1" runat="server"></PES:Folders>
        <div class="clear">
        </div>
        <div class="toolbar">
            <div class="buttons">
                <div class="alignleft">
                    <asp:Button ID="btnDelete" CssClass="button gray" Text="Xóa" runat="server" OnClick="btnDelete_Click" />
                    <asp:Button ID="Button1" CssClass="button gray" Text="Đánh dấu" runat="server" OnClick="btnDelete_Click" />
                </div>
                <div class="alignright">
                    <asp:HyperLink ID="linkPrevious" runat="server" Text="&lt Trước"></asp:HyperLink>
                    |
                    <asp:HyperLink ID="linkNext" runat="server" Text="Sau &gt"></asp:HyperLink>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="mailselect">
            <span>Chọn: <a href="#">Tất cả</a>, <a href="#">Bỏ chọn</a></span>
        </div>
        <div class="mail-list">
            <asp:Repeater ID="repMessages" runat="server" OnItemDataBound="repMessages_ItemDataBound">
                <ItemTemplate>
                    <div class="index-mail">
                        <table>
                            <tr>
                                <td class="im-checkbox">
                                    <asp:CheckBox ID="chkMessage" runat="server" />
                                </td>
                                <td class="im-icon">
                                    <div class="im-icon">
                                        <a href='profiles/profile.aspx?AccountID=<%# ((MessageWithRecipient)Container.DataItem).Sender.AccountID%>'>
                                            <img alt="" style="height:40px" src="../images/ProfileAvatar/ProfileImage.aspx?AccountID=<%#((MessageWithRecipient)Container.DataItem).Sender.AccountID%>"
                                                /></a>
                                    </div>
                                </td>
                                <td class="im-envelope">
                                    <div class="im-author line">
                                        <b>
                                        <asp:HyperLink ID="linkProfile" runat="server" Text='<%# ((MessageWithRecipient)Container.DataItem).Sender.Username %>'></asp:HyperLink></b>
                                    </div>
                                    <div class="im-date tagline">
                                        <span><%# ((MessageWithRecipient)Container.DataItem).Message.CreateDate.ToShortDateString()%></span>
                                    </div>
                                </td>
                                <td class="im-detail">
                                    <b><asp:HyperLink ID="linkMessage" runat="server" Text='<%# ((MessageWithRecipient)Container.DataItem).Message.Subject %>'></asp:HyperLink></b>
                                    <div class="im-preview tagline">
                                        <%# Substring(((MessageWithRecipient)Container.DataItem).Message.Body, 100) %>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="mailtoolbar">
            <div class="alignright">
                <asp:HyperLink ID="HyperLink_BootomNPrev" runat="server" Text="&lt Trước"></asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink_BootomNext" runat="server" Text="Sau &gt"></asp:HyperLink>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
