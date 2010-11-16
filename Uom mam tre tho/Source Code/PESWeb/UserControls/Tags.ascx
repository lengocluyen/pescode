<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tags.ascx.cs" Inherits="PESWeb.UserControls.Tags" %>
<div class="comment-form">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlTag" Visible="false">
                <div class="form-input">
                    <div class="label">
                        <h2>Tag</h2></div>
                    <asp:TextBox ID="txtTag" runat="server"></asp:TextBox>
                    <asp:Button CssClass="button green" ID="btnTag" runat="server" Text="Tag" OnClick="btnTag_Click" />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlTagCloud" Visible="false">
                <asp:PlaceHolder ID="phTagCloud" runat="server"></asp:PlaceHolder>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
