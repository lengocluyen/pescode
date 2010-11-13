<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="PESWeb.UserControls.Comments" %>
<div class="commentcontainer">
    <div class="index-comment">
        <span class="morecomments"><a href="#">Xem tất cả</a></span>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddComment" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:PlaceHolder ID="phComments" runat="server"></asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
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
