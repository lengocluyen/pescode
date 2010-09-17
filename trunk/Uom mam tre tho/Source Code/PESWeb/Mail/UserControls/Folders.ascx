<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Folders.ascx.cs" Inherits="PESWeb.Mail.UserControls.Folders" %>
<li><a href="#" id="toggle-hk-menu" class="more">
    <img src="../../images/mnu02.gif" alt="" />
    Folders</a></li>
<div id="hk-menu">
    <ul class="menu2">
    <li style="padding-left: 10px;" >
    <a href="../../Mail/NewMessage.aspx" runat="server">New</a></li>
        <asp:Repeater ID="repFolders" runat="server" OnItemDataBound="repFolders_ItemDataBound">
            <ItemTemplate>
                <li style="padding-left: 10px;">
                    <asp:HyperLink NavigateUrl="javascript:void;" ID="linkFolder" runat="server">
                        <asp:Image ID="ImageLink" runat="server" /><asp:Label ID="LabelLink" runat="server" />
                    </asp:HyperLink></li></ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
