<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="PESWeb.UserControls.Comments" %>
<div class="commentcontainer">
    <div class="index-comment">
        <span class="morecomments"><a href="#">Xem tất cả</a></span>
    </div>
    <asp:Repeater ID="repComment" runat="server">
        <ItemTemplate>
            <div class="index-comment">
                <div class="ic-avatar">
                    <a href='profiles/profile.aspx?AccountID=<%#Eval("CommentByAccountID")%>'>
                        <img alt="" src="images/ProfileAvatar/ProfileImage.aspx?AccountID=<%#Eval("CommentByAccountID")%>"
                            class="avatar" />
                    </a>
                </div>
                <div class="ic-text">
                    <div class="ic-meta ic-author">
                        <a href='profiles/profile.aspx?AccountID=<%#Eval("CommentByAccountID")%>' class="url">
                            <%#Eval("CommentByUsername") %></a>
                    </div>
                    <div class="ic-content">
                        <%#Eval("Body")%>
                    </div>
                    <div class="ic-meta ic-date">
                        <%# Eval("CreateDate", "{0:dd/MM/yyyy lúc hh:mm}")  %></div>
                </div>
                <div class="ic-edit" style="display: none">
                  <%--  <a class="del15 confirm" url="/Services/DeleteComment" data='commentId-<%#Eval("CommentID")%>'>
                    </a>--%>
                    <asp:HyperLink ID="lnkDel" runat="server" CssClass="del15 confirm" Visible="false" />
                </div>
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <div class="clear">
            </div>
        </SeparatorTemplate>
    </asp:Repeater>
</div>
<div class="index-comment">
    <textarea class="respondtext" id='respondtext-<%=SystemObjectRecordID%>'>Viết cảm nhận ...</textarea>
</div>
<div id='commentform-<%=SystemObjectRecordID%>' class="index-comment comment-form"
    style="display: none">
    <div class="form_comment">
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="focus" />
    </div>
    <div class="form_submit form_submit_right">
        <asp:Button CssClass="button blue" Text="Đăng" ID="btnAddComment" runat="server"
            OnClick="btnAddComment_Click" />
    </div>
</div>
