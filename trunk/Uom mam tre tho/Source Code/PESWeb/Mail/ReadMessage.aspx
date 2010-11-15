<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ReadMessage.aspx.cs" Inherits="PESWeb.Mail.ReadMessage" %>

<%@ Register Src="~/Mail/UserControls/Folders.ascx" TagPrefix="PES" TagName="Folders" %>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <div class="grid_4">
        LeftContent
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
                <%=MessageReci.Message.Subject%>
            </h1>
        </div>
        <PES:Folders ID="Folders1" runat="server"></PES:Folders>
        <div class="clear">
        </div>
        <div class="toolbar">
            <div class="buttons">
                <div class="alignleft">
                    <asp:Button CssClass="button gray" Style="text-align: center" ID="btnReply" runat="server"
                        OnClick="btnReply_Click" Text="Phản hồi" />
                </div>
                <div class="alignright">
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="mail-list">
            <div>
                <table style="font-weight: normal">
                    <tr>
                        <td>
                            <div class="im-icon">
                                <asp:HyperLink ID="Hyp_Account" runat="server">
                                    <asp:Image ID="img_Account" runat="server" Style="height: 40px" /></asp:HyperLink>
                            </div>
                            <b>
                                <asp:HyperLink ID="linkFrom" runat="server"></asp:HyperLink></b>|
                            <%=MessageReci.Message.CreateDate.ToShortDateString() %>| <a href="#" text="Thư rác">
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                                <%=MessageReci.Message.Body %>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
