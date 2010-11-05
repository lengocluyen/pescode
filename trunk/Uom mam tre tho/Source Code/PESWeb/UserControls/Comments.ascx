<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="PESWeb.UserControls.Comments" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="float:left;width:100%;">
        <asp:Panel runat="server" ID="pnlComment">
         <!--Views All Comments-->
         <asp:PlaceHolder ID="phComments" runat="server">
         
         </asp:PlaceHolder>
        <div class="txtCmt" style="float:left;width:60px;cursor:pointer;font-weight:bold"><%=Resources.PESResources.Comment%></div>
        <!--Create New Comments-->
        
        <div class="hiddenCmt" style="clear:both;width:100%"> 
            <asp:TextBox ID="txtComment" runat="server" Width="88%"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button CssClass="button"
                Text="Đăng" ID="btnAddComment" runat="server" OnClick="btnAddComment_Click" />
        </div>
        <div style="clear:both;height:1px;width:100%;">&nbsp</div>
        </asp:Panel>
        </div>
        <div style="clear:both;height:1px;width:100%;"></div>
    </ContentTemplate>
</asp:UpdatePanel>
