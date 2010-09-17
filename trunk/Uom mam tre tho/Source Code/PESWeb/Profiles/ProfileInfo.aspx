<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ProfileInfo.aspx.cs" Inherits="PESWeb.Profiles.ProfileInfo" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="Fisharoo" TagName="ProfileDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<div class="grid_13">
    <div class="page-heading hr">
	    <h2>Thông tin cá nhân</h2>
    </div>
</div>

<div class="grid_4">
    <div class="box">
        <div class="avatar-profile">
            <div class="photo">
                <asp:Image CssClass="main" ID="imgAvatar" runat="server" ImageUrl="~/images/profileavatar/profileimage.aspx"/>
            </div>
            <asp:HyperLink runat="server" ID="lnkChangePicture" Text="Cập nhật avatar" NavigateUrl="~/Profiles/UploadAvatar.aspx"></asp:HyperLink>
            <asp:HyperLink runat="server" ID="lnkEditProfile" Text="Cập nhật thông tin cá nhân" NavigateUrl="~/Profiles/ManageProfile.aspx"></asp:HyperLink>
        </div>
    </div>
    <div class="box">
        <h2>Bạn bè</h2>
        <div class="block-c">
               <div class="h-list">
             
                  <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
                        <ItemTemplate>
                            <Fisharoo:ProfileDisplay ShowFriendRequestButton="false" ShowDeleteButton="false" ID="pdProfileDisplay" runat="server" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clear"></div>
            </div>
        </div>
        
    </div>
</div>
<div class="grid_8">

  <asp:Panel ID="pnlPrivacyAccountInfo" runat="server" CssClass="box profile">
        <h2><a href="#" class="hidden" id="toggle-account-info">Account Info</a></h2>
         <div class="block-c" id="account-info">
            <dl class="profile-info">
                <dt>Email:</dt>
                <dd><asp:Literal ID="litEmail" runat="server"></asp:Literal></dd>
                <dt>Ngày sinh:</dt>
                <dd  class="last"><asp:Literal ID="litBirthDate" runat="server"></asp:Literal></dd>
                <dt>Tỉnh thành:</dt>
                <dd><asp:Literal ID="litZip" runat="server"></asp:Literal></dd>
            </dl>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlPrivacyIM" runat="server" CssClass="box profile">
        <h2><a href="#" class="hidden" id="toggle-contact-info">Contact Information</a></h2>
        <div class="block-c" id="contact-info">
            <dl class="profile-info">
                <dt>Google:</dt>
                <dd><asp:Literal ID="litIMGIM" runat="server"></asp:Literal></dd>
                <dt>Yahoo:</dt>
                <dd class="last"><asp:Literal ID="litIMYIM" runat="server"></asp:Literal></dd>
            </dl>
        </div>
    </asp:Panel>
                    
    <asp:Panel ID="pnlPrivacyTankInfo" runat="server" CssClass="box profile">
        <h2><a href="#" class="hidden" id="toggle-tank-info">Fish Facts</a></h2>
        <div class="block-c" id="tank-info">
            <dl>
                <dt>Year of tank:</dt>
                <dd><asp:Literal ID="litYearOfFirstTank" runat="server"></asp:Literal></dd>
                <dt>#Tanks owned:</dt>
                <dd><asp:Literal ID="litNumberOfTanksOwned" runat="server"></asp:Literal></dd>
                <dt>#Fish owned:</dt>
                <dd class="last"><asp:Literal ID="litNumberOfFishOwned" runat="server"></asp:Literal></dd>
            </dl>
        </div>
    </asp:Panel>
    
    <asp:PlaceHolder ID="phAttributes" runat="server" />
</div>

</asp:Content>