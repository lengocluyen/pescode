<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PESWeb.Default" %>

<%@ Register TagPrefix="PES" Namespace="PESWeb" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagPrefix="PES" TagName="Comments" %>
<%@ Register Src="~/UserControls/Tags.ascx" TagPrefix="PES" TagName="Tags" %>
<%@ Register Src="~/UserControls/Ratings.ascx" TagPrefix="PES" TagName="Ratings" %>
<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!--Rating-->
    <%--<PES:Ratings ID="Rating1" runat="server" SystemObjectID="5" SystemObjectRecordID="127"/>--%>
    <!--Tagd-->
    <%--<PES:Tags Display="ShowCloudAndTagBox" runat="server" SystemObjectID="5" SystemObjectRecordID="114" />--%>
    <div class="grid_9 suffix_4">
        <div class="page-heading">
            <div class="yui-gc">
                <div class="yui-u first">
                    <div class="ui-block-link">
                        <i class="ui-image icon-friend-req"></i>
                        <h2>
                            News Feed</h2>
                    </div>
                </div>
                <div class="yui-u align-right">
                    <a href="#" class="current">Top News</a> <a href="#">Most Recent</a>
                </div>
            </div>
        </div>
    </div>
    <!-- MID COLUMN -->
    <div class="grid_9">
        <div class="status">
            <asp:TextBox ID="txtStatus" Text="Bạn đang nghĩ gì?" runat="server" TextMode="MultiLine" />
            <div class="yui-g">
                <div class="yui-u first">
                </div>
                <div class="yui-u align-right">
                    <asp:Button ID="btnAddStatus" runat="server" CssClass="button" Text="Chia sẽ" />
                </div>
            </div>
        </div>
        <div class="box">
            <div class="block">
                <asp:Repeater ID="repFilter" runat="server">
                    <ItemTemplate>
                        <div class="Alert">
                            <asp:Label ID="lblMessage" runat="server" Text='<%# ((Alert)Container.DataItem).Message  %>'></asp:Label>
                            <PES:Comments ID="HK" runat="server" SystemObjectRecordID='<%# ((Alert)Container.DataItem).AlertID  %>'
                                SystemObjectID="7" />
                        </div>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <div class="AlertSeparator">
                        </div>
                    </SeparatorTemplate>
                </asp:Repeater>
                <%-- <asp:UpdatePanel ID="upFeeds" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                <asp:Panel runat="server">
                    <asp:PlaceHolder ID="ph_exFeeds" runat="server" Visible="false">
                        <asp:Repeater ID="rp_exFead" runat="server">
                            <ItemTemplate>
                                <div class="Alert">
                                    <asp:Label ID="lblMessage2" runat="server" Text='<%# ((Alert)Container.DataItem).Message  %>'></asp:Label>
                                    <PES:Comments ID="HK2" runat="server" SystemObjectRecordID='<%# ((Alert)Container.DataItem).AlertID  %>'
                                        SystemObjectID="7" />
                                </div>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <div class="AlertSeparator">
                                </div>
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </asp:PlaceHolder>
                </asp:Panel>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <div style="float: right; margin-top: 5px;">
                    <asp:ImageButton ID="bt_exFeeds" runat="server" ImageUrl="/images/more.jpg" />
                </div>
                <%-- </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="bt_exFeeds" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
    <div class="grid_4">
        <div class="box">
            <PES:Friends runat="server" ID="friens" />
        </div>
        <div class="box">
            <h2>
                Requests<a class="subtitle" href="#">See All</a>
            </h2>
            <div class="block-c">
                <div class="ui-block-link">
                    <i class="ui-image icon-friend-req"></i><a href="#"><span><strong>2</strong> friends
                        request</span></a>
                </div>
                <div class="ui-block-link">
                    <i class="ui-image icon-friend-req"></i><a href="#"><span><strong>2</strong> friends
                        request</span></a>
                </div>
            </div>
        </div>
        <div class="box">
            <h2>
                Get Connected<a class="subtitle" href="#">See all</a>
            </h2>
            <div class="block-c">
                <div class="ui-block-content">
                    <i class="ui-image icon-friend-req"></i>
                    <div class="ui-content">
                        <a href="#">Apply to be a beta tester </a>and get the first look at upcoming Flychips
                        products.
                    </div>
                </div>
                <div class="ui-block-content">
                    <i class="ui-image icon-friend-req"></i>
                    <div class="ui-content">
                        <div>
                            Viet Nam</div>
                        <a href="#">Apply to be a beta tester </a>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="box b">
            <h2>
                Thông tin cá nhân<a class="subtitle edit" href="#"></a>
            </h2>
            <div class="block-c">
                <div class="ui-block-content">
                    <i class="ui-image icon-friend-req"></i>
                    <div class="ui-content">
                        <a href="#">Apply to be a beta tester </a>and get the first look at upcoming Facebook
                        products.
                    </div>
                </div>
                <div class="ui-block-content">
                    <i class="ui-image icon-friend-req"></i>
                    <div class="ui-content">
                        <div>
                            Who&#39;s on Facebook?</div>
                        <a href="#">Apply to be a beta tester </a>
                    </div>
                </div>
            </div>
        </div>--%>
        <%--<div class="box">
            <h2>
                <a href="#" id="toggle-login-forms" class="visible">Login Form</a></h2>
            <div class="block" id="login-forms">
                <fieldset class="login">
                    <legend>Login </legend>
                    <p class="notice">
                        Login to complete your purchase.</p>
                    <p>
                        <label>
                            Username:</label>
                        <input type="text" class="text" />
                    </p>
                    <p>
                        <label>
                            Password:</label>
                        <input type="text" class="text" />
                    </p>
                </fieldset>
                <fieldset>
                    <legend>Register</legend>
                    <p>
                        If you do not already have an account, please create a new account to register.</p>
                    <input type="submit" value="Create Account" class="button" />
                </fieldset>
            </div>
        </div>--%>
        <!-- Articles box -->
        <%-- <div class="box articles">
            <h2>
                <a href="#" class="visible" id="toggle-articles">Articles</a></h2>
            <div class="block" id="articles">
                <div class="first article">
                    <h3>
                        <a href="#">Article Heading</a></h3>
                    <h4>
                        Subheading</h4>
                    <p class="meta">
                        Vancouver, BC - Wednesday, 23 April 2008</p>
                    <a href="#" class="image">
                        <img src="images/photo_60x60.jpg" alt="photo" />
                    </a>
                    <p>
                        Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                        euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad
                        minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip
                        ex ea commodo consequat. <a href="#">Visit site.</a></p>
                </div>
                <div class="article">
                    <h3>
                        <a href="#">Article Heading</a>
                    </h3>
                    <h4>
                        Subheading</h4>
                    <p class="meta">
                        Vancouver, BC — Wednesday, 23 April 2008</p>
                    <a href="#" class="image">
                        <img src="../../../img/photo_60x60.jpg" width="60" height="60" alt="photo" />
                    </a>
                    <p>
                        Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                        euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad
                        minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip
                        ex ea commodo consequat. <a href="#">Visit site.</a></p>
                </div>
            </div>
        </div>--%>
    </div>
</asp:Content>
