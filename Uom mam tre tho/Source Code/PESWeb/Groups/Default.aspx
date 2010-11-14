<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PESWeb.Groups.Default" %>

<asp:Content ContentPlaceHolderID="Groups" runat="server">
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
    <div class="grid_20">
        <div id="title">
            <h1>
                <%=Resources.PESResources.group%></h1>
            <%--<div class="alignright">
                <a href="#" class="button gray">Tạo nhóm</a>
            </div>--%>
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
                        <asp:LinkButton OnClick="lbPageName_Click" ID="lbPageName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:LinkButton>
                        <asp:Image ID="imgGroupImage" runat="server" />
                        <asp:Label ID="lblName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:Label>
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
