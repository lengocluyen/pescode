﻿<%@ Page MasterPageFile="~/SiteMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewGroup.aspx.cs" Inherits="PESWeb.Groups.ViewGroup" %>

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
                Nhóm</h2>
        </div>
        <div class="divContainerRow">
            <asp:Label ForeColor="Red" ID="lblMessage" runat="server"></asp:Label>
            <asp:Panel ID="pnlPublic" runat="server">
                <div style="float:none;">
                    <div style="float:left;margin:10px"><asp:Image ID="imgGroupLogo" runat="server" /></div>
                    <div style="text-align:right;">
                        <asp:Label ID="lblPrivateMessage" ForeColor="Red" runat="server" Text="Nhóm riêng tư!"></asp:Label> 
                        <asp:LinkButton ID="lbRequestMembership" OnClick="lbRequestMembership_Click" Text="Gia nhập nhóm" runat="server"></asp:LinkButton>
                    </div>
                </div>
                Ngày tạo: <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
                Lần cập nhật cuối: <asp:Label ID="lblUpdateDate" runat="server"></asp:Label><br />
                <asp:Label ID="lblDescription" runat="server"></asp:Label><br /><br />
            </asp:Panel>
            <asp:Panel ID="pnlPrivate" runat="server">
                <%--<asp:LinkButton ID="lbForum" OnClick="lbForum_Click" Text="View Forum" runat="server"></asp:LinkButton>&nbsp;--%>
                <asp:LinkButton ID="lbViewMembers" OnClick="lbViewMembers_Click" Text="Danh sách thành viên" runat="server"></asp:LinkButton> 
                <asp:Label ID="lblBody" runat="server"></asp:Label>
            </asp:Panel>          
        </div>
</div>
</asp:Content>