<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PESWeb.Groups.Default" %>

<asp:Content ContentPlaceHolderID="Groups" runat="server">
<div style="padding-left:10px;">
    <ul class="menu1">
        <li><a href="/Groups/ManageGroup.aspx">
            <img src="/images/mnu01.gif" alt="" />Groups mới</a></li>
        <li><a href="/Groups/mygroups.aspx">
            <img src="/images/mnu01.gif" alt="" />Groups của tôi</a></li>
    </ul>
</div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Groups</h2>
        </div>
        <div class="divContainerRow">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                        <asp:ListView ID="lvGroups" runat="server" OnItemDataBound="lvGroups_ItemDataBound">
                            <LayoutTemplate>
                                <ul class="groupsList">
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <li>
                                    <asp:Literal Visible="false" ID="litImageID" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).FileID %>'></asp:Literal>
                                    <asp:Literal ID="litPageName" Visible="false" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).PageName %>'></asp:Literal>
                                    <asp:LinkButton OnClick="lbPageName_Click" ID="lbPageName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:LinkButton>
                                    <asp:Image ID="imgGroupImage" runat="server" />
                                    <asp:Label ID="lblName" runat="server" Text='<%# ((Pes.Core.Group)Container.DataItem).Name %>'></asp:Label>
                                </li>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
