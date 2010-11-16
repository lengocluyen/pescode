<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewView.aspx.cs" Inherits="PESWeb.Photos.ViewView" %>

<%@ Register Src="~/UserControls/Tags.ascx" TagName="Tags" TagPrefix="PES" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagName="Comments" TagPrefix="PES" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_20">
        <div id="title">
            <h1>
                Album Ảnh:
                <asp:Label ID="lblAlbumName" runat="server" /></h1>
        </div>
        <div class="toolbar">
            <div class="buttons">
                <div class="alignleft">
                    <asp:Label Style="font-weight: bold;" ID="lblFileName" runat="server"></asp:Label>
                </div>
                <div class="alignright">
                    <asp:HyperLink ID="linkNext" CssClass="button gray" runat="server">Trước</asp:HyperLink>
                    &nbsp;&nbsp;<asp:HyperLink ID="linkPrivious" CssClass="button gray" runat="server">Sau</asp:HyperLink>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div id="photos">
            <div class="index-photo">
                <div class="ip-img">
                    <asp:HyperLink ID="linkImage" runat="server"></asp:HyperLink>
                </div>
                <asp:Literal Visible="false" ID="litImageName" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litFileExtension" runat="server"></asp:Literal>
                <div class="ip-desc">
                    <asp:Label ID="lblDescription" runat="server"> </asp:Label>
                </div>
                <asp:Literal Visible="false" ID="litFileID" runat="server"></asp:Literal>
                <div style="margin:10px 0">
                    <PES:Tags ID="Tags1" runat="server" SystemObjectID="5" Display="ShowCloudAndTagBox" />
                </div>
                <div class="post-text">
                    <div class="body">
                    </div>
                    <div class="meta">
                        <asp:Label ID="lblCreated" runat="server"></asp:Label>
                        - <a href="#" id='respondlink-<%=fileID %>' class="respondlink">Cảm nhận</a>
                    </div>
                    <PES:Comments ID="comments" SystemObject="Files" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
