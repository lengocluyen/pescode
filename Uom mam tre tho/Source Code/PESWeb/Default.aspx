<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PESWeb.Default" %>

<%@ Register TagPrefix="PES" Namespace="PESWeb" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagPrefix="PES" TagName="Comments" %>
<%@ Register Src="~/UserControls/Tags.ascx" TagPrefix="PES" TagName="Tags" %>
<%@ Register Src="~/UserControls/Ratings.ascx" TagPrefix="PES" TagName="Ratings" %>
<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LeftContent" runat="server">
    <div class="grid_4">
        LeftContent
    </div>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!--Rating-->
    <%--<PES:Ratings ID="Rating1" runat="server" SystemObjectID="5" SystemObjectRecordID="127"/>--%>
    <!--Tagd-->
    <%--<PES:Tags Display="ShowCloudAndTagBox" runat="server" SystemObjectID="5" SystemObjectRecordID="114" />--%>
    <div class="grid_14">
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
                    <asp:TextBox ID="txtStatus" CssClass="focus" runat="server" TextMode="MultiLine" />
                </div>
                <div id="c-buttons" class="alignright">
                    <asp:Button ID="btnAddStatus" runat="server" CssClass="submit" Text="Chia sẽ" />
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <!-- MID COLUMN -->
        <div id="post-container">
            <div id="posts">
                <div class="post-list">
                    <asp:Repeater ID="repFilter" runat="server">
                        <ItemTemplate>
                            <div class="post" id='post-<%#Eval("AlertID")  %>'>
                                <div class="post-gravatar">
                                    <a href='profiles/profile.aspx?AccountID=<%#Eval("AccountID")%>'>
                                        <img alt="" src="images/ProfileAvatar/ProfileImage.aspx?AccountID=<%#Eval("AccountID")%>"
                                            width="50" height="50" class="avatar" />
                                    </a>
                                </div>
                                <div class="post-text">
                                    <h2 class="title">
                                            <%# Eval("AccountID")%> Cuong Do
                                    </h2>
                                    <div class="body">
                                        <%# Eval("Message")  %>
                                    </div>
                                    <div class="meta">
                                        <%# Eval("CreateDate", "{0:dd/MM/yyyy lúc HH:mm}")  %>
                                        - <a href="#" id='respondlink-<%#Eval("AlertID")%>' class="respondlink">Cảm nhận</a>
                                    </div>
                                    <PES:Comments runat="server" SystemObject="Alerts" SystemObjectRecordID='<%#((Alert)Container.DataItem).AlertID%>' />
                                </div>
                            </div>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <div class="clear">
                            </div>
                        </SeparatorTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <!-- Navigation -->
        <div class="navigation">
            <div class="next">
                <a href="#">Xem thêm</a>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="grid_6">
        <div class="box">
            <PES:Friends runat="server" ID="friens" />
        </div>
        <div class="box">
            <h2>
                <%=Resources.PESResources.request %><a class="subtitle" href="#"><%=Resources.PESResources.seeAll %></a>
            </h2>
            <div class="block-c">
                <div class="ui-block-link">
                    <i class="ui-image icon-friend-req"></i><a href="#"><span><strong>2</strong>
                        <%=Resources.PESResources.friend %>
                        <%=Resources.PESResources.request %></span></a>
                </div>
                <div class="ui-block-link">
                    <i class="ui-image icon-friend-req"></i><a href="#"><span><strong>2</strong>
                        <%=Resources.PESResources.friend %>
                        <%=Resources.PESResources.request %></span></a>
                </div>
            </div>
        </div>
        <div class="box">
            <h2>
                <%=Resources.PESResources.getConnected %><a class="subtitle" href="#"><%=Resources.PESResources.seeAll %></a>
            </h2>
            <div class="block-c">
                <div class="ui-block-content">
                    <i class="ui-image icon-friend-req"></i>
                    <div class="ui-content">
                        <a href="#">Nhóm flychips </a>thành viên của DLU.
                    </div>
                </div>
                <div class="ui-block-content">
                    <i class="ui-image icon-friend-req"></i>
                    <div class="ui-content">
                        <div>
                            TIEUHOC.NET</div>
                        <a href="#">Mạng xã hội ươm mầm ước mơ trẻ thơ</a>
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
