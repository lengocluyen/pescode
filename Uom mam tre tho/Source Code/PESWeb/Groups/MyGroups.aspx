<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="MyGroups.aspx.cs" Inherits="PESWeb.Groups.MyGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Groups" runat="server">
    <div style="padding-left: 10px;">
        <ul class="menu1" style="margin-top: 8px;">
            <li><a href="/Groups/ManageGroup.aspx">
                <img src="/images/group.gif" alt="" />Tạo nhóm mới</a></li>
            <li><a href="/Groups/mygroups.aspx">
                <img src="/images/group.gif" alt="" />Nhóm của tôi</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_16">
        <div id="title">
            <h1>
                Nhóm Của Tôi</h1>
            <div class="alignright">
                <a href="#" class="button gray">Tạo nhóm</a>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
            <asp:ListView ID="lvGroups" GroupItemCount="4" runat="server" OnItemDataBound="lvGroups_ItemDataBound">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate>
                    <table class="photo-grid">
                        <tr>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </tr>
                    </table>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <asp:Literal Visible="false" ID="litImageID" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).FileID %>'></asp:Literal>
                        <asp:Literal ID="litPageName" Visible="false" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).PageName %>'></asp:Literal>
                        <div>
                            <div style="float: left;">
                                <asp:LinkButton OnClick="lbPageName_Click" ID="lbPageName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:LinkButton></div>
                            <div style="text-align: right;">
                                <asp:ImageButton ID="ibDelete" OnClick="ibDelete_Click" runat="server" ImageUrl="/images/icon_close.gif" />
                                <asp:ImageButton ID="ibEdit" OnClick="ibEdit_Click" runat="server" ImageUrl="/images/icon_pencil.gif" /></div>
                        </div>
                        <asp:Image ID="imgGroupImage" runat="server" />
                        <asp:Label ID="lblName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:Label>
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
