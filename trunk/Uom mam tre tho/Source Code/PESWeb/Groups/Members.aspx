<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="PESWeb.Groups.Members" %>

<%@Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="PES" TagName="Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Groups" runat="server">
<div style="padding-left:10px;">
     <ul class="menu1" style="margin-top:8px;">
        <li><a href="/Groups/ManageGroup.aspx">
            <img src="/images/group.gif" alt="" />Tạo nhóm mới</a></li>
        <li><a href="/Groups/mygroups.aspx">
            <img src="/images/group.gif" alt="" />Nhóm của tôi</a></li>
    </ul>
</div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
   <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Thành viên của nhóm</h2>
        </div>
            <div class="divContainerRow">
                <div style="float:left;"><asp:LinkButton OnClick="lbBack_Click" ID="lbBack" runat="server" Text="Back"></asp:LinkButton>&nbsp;</div>
                <div style="float:left;"><asp:LinkButton OnClick="lbPrevious_Click" ID="lbPrevious" runat="server" Text="Previous"></asp:LinkButton>&nbsp;</div>
                <div style="text-align:right;"><asp:LinkButton OnClick="lbNext_Click" ID="lbNext" runat="server" Text="Next"></asp:LinkButton>&nbsp;</div>
            </div>
            <div class="divContainerTitle">Chọn thành viên:</div>
            <div class="divContainerRow">
                <asp:Repeater ID="repMembersToApprove" runat="server" OnItemDataBound="repMembersToApprove_ItemDataBound">
                    <ItemTemplate>
                             <div style="width:100%"><div style="float:left;padding:15px 10px 20px 10px"><asp:CheckBox ID="chkProfile" runat="server" /></div><div style="float:left;"><PES:Profile ID="Profile1" ShowDeleteButton="false" runat="server" /></div></div>
                            <div class="clear"></div>
                     </ItemTemplate>
                </asp:Repeater>
            </div>    
            <div class="divContainerTitle">Thành viên</div>
            <div class="divContainerRow">            
                <asp:Repeater ID="repMembers" runat="server" OnItemDataBound="repMembers_ItemDataBound">
                    <HeaderTemplate><table><tr><td>&nbsp;</td><td>&nbsp;</td></tr></HeaderTemplate>
                    <ItemTemplate>
                        <tr><td>
                            <asp:CheckBox ID="chkProfile" runat="server" />
                        </td><td>
                            <PES:Profile ID="Profile1" ShowDeleteButton="false" runat="server" />
                        </td></tr>
                    
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="divContainerRow">            
                <asp:Label ForeColor="Red" runat="server" ID="lblMessage"></asp:Label>
            </div>
            <div class="divContainerFooter">&nbsp;
                <asp:Panel ID="pnlButtons" runat="server">
                    <asp:Button ID="btnApprove" CssClass="button" OnClick="btnApprove_Click" runat="server" Text="Chấp thuận" />
                    <asp:Button ID="btnDelete" CssClass="button" OnClick="btnDelete_Click" runat="server" Text="Xóa" />
                    <asp:Button ID="btnPromoteToAdmin" CssClass="button" OnClick="btnPromoteToAdmin_Click" runat="server" Text="Nâng cấp Quản trị" />
                    <asp:Button ID="btnDemoteAdmins" CssClass="button" OnClick="btnDemoteAdmins_Click" runat="server" Text="Hạ cấp Quản trị" />
                </asp:Panel>
            </div>
        </div>
</asp:Content>