<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Folders.ascx.cs" Inherits="PESWeb.Mail.UserControls.Folders" %>
<!-- Categories -->
<div id="categories">
    <ul>
       <%-- <li class="cat-item"><a id="createmaillink" href="NewMessage.aspx" title="Blockquotes">Soạn thư</a></li>
        <li class="cat-item current-cat"><a id="inboxlonk" href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Inbox%>'>Hộp thư đến</a></li>
        <li class="cat-item"><a id="sendlink" href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Sent%>'>Hộp thư đi</a></li>
        <li class="cat-item"><a id="draflink" href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Trash%>'>Thư nháp</a></li>
        <li class="cat-item"><a id="spamlink" href='Default.aspx?folder=<%=(int)Pes.Core.MessageFolders.Spam%>'>Thư rác</a></li>
        <li id="liplus"><a id="plus" href="#" title="More categories.." onclick="showbox(this); return false"
            class="none">&nbsp;</a> </li>--%>
            <%=CatHTML %>
    </ul>
</div>
