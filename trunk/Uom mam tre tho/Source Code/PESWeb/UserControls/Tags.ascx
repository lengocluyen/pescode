<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tags.ascx.cs" Inherits="PESWeb.UserControls.Tags" %>
<%--<asp:UpdatePanel runat="server">--%>
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlTag" Visible="false">
            <div class="txtTag" style="padding-top: 10px; font-weight: bold;cursor:pointer">
                Tag</div>
            <div class="hiddenTag">
                <asp:TextBox ID="txtTag" runat="server"></asp:TextBox>
                <asp:Button CssClass="button green" ID="btnTag" runat="server" Text="Tag" OnClick="btnTag_Click" />
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlTagCloud" Visible="false">
            <asp:PlaceHolder ID="phTagCloud" runat="server"></asp:PlaceHolder>
        </asp:Panel>
    </ContentTemplate>
<%--</asp:UpdatePanel>--%>
