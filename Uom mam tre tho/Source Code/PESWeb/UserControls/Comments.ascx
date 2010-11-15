<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="PESWeb.UserControls.Comments" %>
<div class="commentcontainer">
    <div class="index-comment morecomments" runat="server" id="pnlMore">
            <asp:HyperLink ID="lnkMore" runat="server" 
                CssClass="viewmore"></asp:HyperLink>
    </div>
    <asp:Repeater ID="repComment" runat="server">
        <ItemTemplate>
            <div class="index-comment">
                <div class="ic-avatar">
                    <a href='/profiles/profile.aspx?AccountID=<%#Eval("CommentByAccountID")%>'>
                        <img alt="" src="/images/ProfileAvatar/ProfileImage.aspx?AccountID=<%#Eval("CommentByAccountID")%>"
                            class="avatar" />
                    </a>
                </div>
                <div class="ic-text">
                    <div class="ic-meta ic-author">
                        <a href='/profiles/profile.aspx?AccountID=<%#Eval("CommentByAccountID")%>' class="url">
                            <%#Eval("CommentByUsername") %></a>
                    </div>
                    <div class="ic-content">
                        <%#Eval("Body")%>
                    </div>
                    <div class="ic-meta ic-date">
                        <%# Eval("CreateDateString")%></div>
                </div>
                <div class="ic-edit" style="display: none">
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
<div class="index-comment" runat="server" id="pnlCommentInput">
    <textarea class="respondtext" id='respondtext-<%=SystemObjectRecordID%>'>Viết cảm nhận ...</textarea>
</div>
<div id='commentform-<%=SystemObjectRecordID%>' class="index-comment comment-form" style="display: none">
    <input type="hidden" value='<%=SystemObjectRecordID%>' 
        attrName="SystemObjectRecordID"/>
    <input type="hidden" value='<%=SystemObjectID%>' 
        attrName="SystemObjectID"/>
    <div class="form_comment">
        <textarea class="focus" attrName="Body"></textarea>
    </div>
    <div class="form_submit form_submit_right">
        <input type="button" class="button blue addcomment" value="Đăng" container='commentform-<%=SystemObjectRecordID%>' />
    </div>
</div>
