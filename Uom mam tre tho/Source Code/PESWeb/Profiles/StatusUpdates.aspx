<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="StatusUpdates.aspx.cs" Inherits="PESWeb.Profiles.StatusUpdates" %>

<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_15">
        <div id="title">
            <h1>
                <%=Resources.PESResources.newsfeed %></h1>
        </div>
        <!-- end title -->
        <div class="clear">
        </div>
        <div id="composer">
            <div id="c-mention">
                <textarea>Bạn đang nghĩ gì?</textarea>
            </div>
            <div id="c-form" style="display: none">
                <div id="c-input">
                    <%--<asp:TextBox ID="txtStatus" CssClass="focus" runat="server" TextMode="MultiLine" />--%>
                    <textarea class="focus"></textarea>
                </div>
                <div id="c-buttons" class="alignright">
                    <%--<asp:Button ID="btnAddStatus" runat="server" CssClass="submit" Text="Chia sẽ" />--%>
                    <input type="button" class="button green" class="submit" value="Chia sẽ" id="addstatus" />
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <!-- MID COLUMN -->
        <div id="post-container">
            <div id="posts">
                <asp:ListView ID="lvStatus" runat="server" OnItemDataBound="lvStatus_ItemDataBound">
                    <LayoutTemplate>
                        <div class="post-list">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="post">
                            <div class="post-gravatar">
                                <asp:HyperLink ID="linkAvatar" runat="server">
                                    <asp:Image ID="imaAvatar" runat="server" Width="50" Height="50" CssClass="avatar" />
                                </asp:HyperLink>
                            </div>
                            <div class="post-text">
                                <div class="body">
                                    <asp:Label ID="lbStatus" runat="server"></asp:Label>
                                </div>
                                <div class="meta">
                                    <asp:Label ID="lbCreateDate" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="mb blue">
                            "Bạn chưa đăng trạng thái nào!"
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
        <!-- Navigation -->
        <div class="navigation">
            <div class="next">
                <a href="#">Xem thêm</a>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="grid_5">
        <PES:Friends runat="server" ID="friens" />
    </div>
</asp:Content>
