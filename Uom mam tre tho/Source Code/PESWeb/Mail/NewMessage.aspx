<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="NewMessage.aspx.cs" Inherits="PESWeb.Mail.NewMessage" %>

<%@ Register Src="~/Mail/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<%@ Register Src="~/Mail/UserControls/Folders.ascx" TagPrefix="PES" TagName="Folders" %>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <div class="grid_4">
        LeftContent
    </div>
</asp:Content>
<asp:Content ID="ContentNewMessages" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <PES:Folders ID="Folders1" runat="server"></PES:Folders>
        <div class="clear">
        </div>
        <div class="toolbar">
            <div class="buttons">
                <div class="alignleft">
                    <h2>
                        Viết thư mới</h2>
                </div>
                <div class="alignright">
                    <asp:Button CssClass="button gray" ID="btnSend" Text="Gửi" runat="server" OnClick="btnSend_Click" />
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlSendMessage" runat="server">
            <p>
                <b />Đến:</p>
            <div>
                <asp:TextBox Width="70%" ID="txtTo" runat="server"></asp:TextBox></div>
            <br />
            <p>
                Tiêu đề:
            </p>
            <div>
                <asp:TextBox Width="70%" ID="txtSubject" runat="server"></asp:TextBox></div>
            <br />
            <div>
                <textarea id="txtMessage" name="txtMessage" cols="92" rows="20" runat="server" /> </div></asp:Panel><asp:Panel Visible="false" runat="server" ID="pnlSent">
            <div>
                Thư của bạn đã được gửi! </div></asp:Panel></div></asp:Content><asp:Content ContentPlaceHolderID="head" runat="server">

    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
