<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="MyGroups.aspx.cs" Inherits="PESWeb.Groups.MyGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Groups" runat="server">
    <div style="padding-left: 10px;">
        <ul class="menu1" style="margin-top: 8px;">
            <li>
                <img src="/images/group.gif" alt="" /><a href="/Groups/ManageGroup.aspx">Tạo nhóm mới</a></li>
            <li>
                <img src="/images/group.gif" alt="" /><a href="/Groups/mygroups.aspx">Nhóm của tôi</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_19">
        <div id="title">
            <h1>
                Nhóm Của Tôi</h1>
            <div class="alignright">
                <a href="../Groups/ManageGroup.aspx" class="button green">Tạo nhóm mới</a>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="post">
            <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
            <asp:ListView ID="lvGroups" GroupItemCount="4" runat="server" OnItemDataBound="lvGroups_ItemDataBound">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate>
                    <table class="photo-grid">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </table>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <asp:Literal Visible="false" ID="litImageID" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).FileID %>'></asp:Literal>
                        <asp:Literal ID="litPageName" Visible="false" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).PageName %>'></asp:Literal>
                        <div style="text-align: right;">
                            <asp:ImageButton ID="ibEdit" OnClick="ibEdit_Click" runat="server" ImageUrl="/images/icon_pencil.gif" />
                            <asp:ImageButton ID="ibDelete" OnClick="ibDelete_Click" runat="server" ImageUrl="/images/icon_close.gif" />
                        </div>
                        <asp:HyperLink ID="lnkImage" runat="server">
                            <div class="pg-album">
                                <asp:Image ID="imgGroupImage" runat="server" />
                            </div>
                        </asp:HyperLink>
                        <div class="pg-detail">
                            <div class="pg-name">
                                <asp:LinkButton OnClick="lbPageName_Click" ID="lbPageName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:LinkButton>
                            </div>
                        </div>
                        <%--<asp:Label ID="lblName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:Label>--%>
                        <asp:Literal Visible="false" ID="litGroupID" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).GroupID %>'></asp:Literal>
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                    Bạn chưa gia nhập Group nào!
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
