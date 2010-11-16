<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Members.aspx.cs" Inherits="PESWeb.Groups.Members" %>

<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="PES" TagName="Profile" %>
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
                Thành viên của nhóm</h1>
            <%--<div class="alignright">
                <a href="#" class="button gray">Tạo nhóm</a>
            </div>--%>
        </div>
        <div class="clear">
        </div>
        <div class="toolbar">
            <div class="buttons">
                <div class="alignleft">
                    <asp:Label ForeColor="Red" runat="server" ID="lblMessage"></asp:Label>
                </div>
                <div class="alignright">
                    <asp:Panel ID="pnlButtons" runat="server">
                        <asp:Button ID="btnApprove" CssClass="button gray" OnClick="btnApprove_Click" runat="server"
                            Text="Chấp thuận" />
                        <asp:Button ID="btnDelete" CssClass="button gray" OnClick="btnDelete_Click" runat="server"
                            Text="Xóa" />
                        <asp:Button ID="btnPromoteToAdmin" CssClass="button gray" OnClick="btnPromoteToAdmin_Click"
                            runat="server" Text="Nâng cấp Quản trị" />
                        <asp:Button ID="btnDemoteAdmins" CssClass="button gray" OnClick="btnDemoteAdmins_Click"
                            runat="server" Text="Hạ cấp Quản trị" />
                    </asp:Panel>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="divContainerRow">
            <div style="float: left;">
                <asp:LinkButton OnClick="lbBack_Click" ID="lbBack" runat="server" Text="Trở lại"></asp:LinkButton>&nbsp;</div>
            <div style="float: left;">
                <asp:LinkButton OnClick="lbPrevious_Click" ID="lbPrevious" runat="server" Text="Trước đó"></asp:LinkButton>&nbsp;</div>
            <div style="text-align: right;">
                <asp:LinkButton OnClick="lbNext_Click" ID="lbNext" runat="server" Text="Kế tiếp"></asp:LinkButton>&nbsp;</div>
        </div>
        <asp:Panel ID="pnMemeber" runat="server">
            <asp:Panel ID="pnchooseMember" runat="server">
                <div class="title"><h2>
                    Chọn thành viên</h2></div>
                <asp:Repeater ID="repMembersToApprove" runat="server" OnItemDataBound="repMembersToApprove_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td style="width:3%;">
                            <asp:CheckBox ID="chkProfile" runat="server" /></div>
                        </td>
                        <td style="width:94%;">
                            <PES:Profile ID="Profile1" ShowDeleteButton="false" runat="server" />
                        </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
            </asp:Panel>
            <asp:Panel ID="pnMemberdisplay" runat="server">
                <div class="title"><h2>
                    Thành viên</h2></div>
                <asp:Repeater ID="repMembers" runat="server" OnItemDataBound="repMembers_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="width:3%;">
                                <asp:CheckBox ID="chkProfile" runat="server" />
                            </td>
                            <td style="width:94%;">
                                <PES:Profile ID="Profile1" ShowDeleteButton="false" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
            </asp:Panel>
        </asp:Panel>
    </div>
</asp:Content>
