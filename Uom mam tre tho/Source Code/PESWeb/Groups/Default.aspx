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
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
