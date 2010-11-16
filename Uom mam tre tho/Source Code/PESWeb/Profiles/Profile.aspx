<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="PESWeb.Profiles.ViewProfile" %>

<%@ Import Namespace="Pes.Core" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="Fisharoo" TagName="ProfileDisplay" %>
<%@ Register Src="~/UserControls/Comments.ascx" TagPrefix="PES" TagName="Comments" %>
<%--<%@ Register Src="~/UserControls/Friends.ascx" TagPrefix="PES" TagName="Friends" %>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_18">
        <div id="title">
            <h1>
                Thông tin cá nhân</h1>
        </div>
    </div>
    <div class="clear"></div>
    <div class="grid_5 alpha">
        <div class="widget">
            <div class="widget-content">
                <div class="w-photo">
                    <asp:Image CssClass="main" ID="imgAvatar" runat="server" ImageUrl="~/images/profileavatar/profileimage.aspx" />
                </div>
                <ul>
                    <li>
                        <asp:HyperLink runat="server" ID="lnkViewInfo" Text="Xem thông tin cá nhân" NavigateUrl="~/Profiles/ProfileInfo.aspx"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink runat="server" ID="lnkChangePicture" Text="Cập nhật avatar" NavigateUrl="~/Profiles/UploadAvatar.aspx"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink runat="server" ID="lnkEditProfile" Text="Cập nhật thông tin cá nhân"
                            NavigateUrl="~/Profiles/ManageProfile.aspx"></asp:HyperLink></li>
                </ul>
            </div>
        </div>
        <asp:Panel ID="pnlPrivacyAccountInfo" runat="server" CssClass="widget">
            <h2>
                Thông tin cá nhân</h2>
            <div class="widget-content">
                <dl class="w-info">
                    <%--  <dt>Giới tính:</dt>
                <dd><asp:Literal ID="litSex" runat="server"></asp:Literal></dd>--%>
                    <dt>Ngày sinh:</dt>
                    <dd class="last">
                        <asp:Literal ID="litBirthDate" runat="server"></asp:Literal></dd>
                    <dt>Tỉnh thành:</dt>
                    <dd>
                        <asp:Literal ID="litZip" runat="server"></asp:Literal></dd>
                </dl>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlPrivacyIM" runat="server" CssClass="widget">
            <h2>
                Thông tin liên hệ</h2>
            <div class="widget-content">
                <dl class="w-info">
                    <dt>Google:</dt>
                    <dd>
                        <asp:Literal ID="litIMGIM" runat="server"></asp:Literal></dd>
                    <dt>Yahoo:</dt>
                    <dd class="last">
                        <asp:Literal ID="litIMYIM" runat="server"></asp:Literal></dd>
                </dl>
            </div>
            <%-- <div class="divInnerRowHeader">AOL:</div>
        <div class="divInnerRowCell"><asp:Literal ID="litIMAOL" runat="server"></asp:Literal>&nbsp;</div>
        <div class="divInnerRowHeader">MSN:</div>
        <div class="divInnerRowCell"><asp:Literal ID="litIMMSN" runat="server"></asp:Literal>&nbsp;</div>
        <div class="divInnerRowHeader">ICQ:</div>
        <div class="divInnerRowCell"><asp:Literal ID="litIMICQ" runat="server"></asp:Literal>&nbsp;</div>
        <div class="divInnerRowHeader">Skype:</div>
        <div class="divInnerRowCell"><asp:Literal ID="litIMSkype" runat="server"></asp:Literal>&nbsp;</div>--%>
        </asp:Panel>
        <asp:Panel ID="pnlPrivacyTankInfo" runat="server" CssClass="widget">
            <h2>
                Thông tin về bé</h2>
            <div class="widget-content">
                <dl class="w-info">
                    <dt>Tên trường:</dt>
                    <dd>
                        <asp:Literal ID="litYearOfFirstTank" runat="server"></asp:Literal></dd>
                    <dt>Địa chỉ:</dt>
                    <dd>
                        <asp:Literal ID="litNumberOfTanksOwned" runat="server"></asp:Literal></dd>
                    <dt>Sở thích:</dt>
                    <dd class="last">
                        <asp:Literal ID="litNumberOfFishOwned" runat="server"></asp:Literal></dd>
                </dl>
            </div>
        </asp:Panel>
        <%--<asp:PlaceHolder ID="phAttributes" runat="server" />--%>
    </div>
    <div class="grid_14 ">
     <%--   <div id="categories">
            <ul>
                <li class="current-cat"><a>Tường nhà</a></li>
                <li class="cat-item">
                    <asp:HyperLink runat="server" ID="lnkProfileInfo" NavigateUrl="~/Profiles/ManageProfile.aspx"
                        Text="Thông tin cá nhân" />
                </li>
                <li class="cat-item">
                    <asp:HyperLink runat="server" ID="lnkMyPhotos" NavigateUrl="~/Photos/MyPhotos.aspx"
                        Text="Hình ảnh" />
                </li>
            </ul>
        </div>--%>
        <div id="composer" class="composer_wrapper">
            <div id="c-mention">
                <textarea>Bạn đang nghĩ gì?</textarea>
            </div>
            <div id="c-form" style="display: none">
                <div id="c-input">
                    <textarea class="focus"></textarea>
                </div>
                <div id="c-buttons" class="alignright">
                    <input type="button" class="submit" value="Chia sẽ" id="addstatus" />
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="post-container">
            <div id="posts">
                <div class="post-list">
                    <asp:Repeater ID="repFilter" runat="server">
                        <ItemTemplate>
                            <div class="post" id='post-<%#Eval("AlertID")  %>'>
                                <div class="post-gravatar">
                                    <a href='/profiles/profile.aspx?AccountID=<%#Eval("AccountID")%>'>
                                        <img alt="" src="/images/ProfileAvatar/ProfileImage.aspx?AccountID=<%#Eval("AccountID")%>"
                                            width="50" height="50" class="avatar" />
                                    </a>
                                </div>
                                <div class="post-text">
                                    <%# Eval("Message")  %>
                                    <div class="meta">
                                        <%# Eval("CreateDate", "{0:dd-MM-yyyy lúc HH:mm}")  %>
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
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="grid_5 omega">
        <div class="widget">
            <h2>
                Bạn bè</h2>
            <div class="widget-content">
                <div class="h-list">
                    <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
                        <ItemTemplate>
                            <Fisharoo:ProfileDisplay ShowFriendRequestButton="false" ShowDeleteButton="false"
                                ID="pdProfileDisplay" runat="server" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
