<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Folders.ascx.cs" Inherits="PESWeb.Mail.UserControls.Folders" %>
<!-- Categories -->
<div id="categories">
    <ul>
        <li class="cat-item"><a href="NewMessage.aspx" title="Blockquotes">Xoạn thư</a></li>
        <li class="current-cat"><a href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Inbox%>'>Hộp thư đến</a></li>
        <li class="cat-item"><a href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Sent%>'>Hộp thư đi</a></li>
        <li class="cat-item"><a href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Trash%>'>Thư nháp</a></li>
        <li class="cat-item"><a href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Spam%>'>Thư rác</a></li>
        <li id="liplus"><a id="plus" href="#" title="More categories.." onclick="showbox(this); return false"
            class="none">&nbsp;</a> </li>
    </ul>
</div>


<%--<li><a href="#" id="toggle-hk-menu" class="more" style="margin-top: 3px;">
    <img src="../../images/mailbox.gif" alt="" />
    Hộp thư</a></li>
<div id="hk-menu">
    <ul class="menu1">
        <li style="padding-left: 10px;"><a href="../../Mail/NewMessage.aspx" runat="server">
            <img src="../../images/write.gif" />Viết thư mới</a></li>
        <asp:Repeater ID="repFolders" runat="server" OnItemDataBound="repFolders_ItemDataBound">
            <ItemTemplate>
                <li style="padding-left: 10px;">
                    <asp:HyperLink NavigateUrl="javascript:void;" ID="linkFolder" runat="server">
                        <asp:Image ID="ImageLink" runat="server" /><asp:Label ID="LabelLink" runat="server" />
                    </asp:HyperLink></li></ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
--%>