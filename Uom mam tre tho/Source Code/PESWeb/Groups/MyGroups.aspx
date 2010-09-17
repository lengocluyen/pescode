<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="MyGroups.aspx.cs" Inherits="PESWeb.Groups.MyGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Groups" runat="server">
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
                Groups Của Tôi</h2>
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
                                </li>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                             Bạn chưa gia nhập Group nào!
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
