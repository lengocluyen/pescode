<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PESWeb.Profiles.ViewProfile" %>
<%@ Import Namespace="Pes.Core" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="Fisharoo" TagName="ProfileDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<div class="grid_13">
    <div class="page-heading hr">
	    <h2>Thông tin cá nhân</h2>
    </div>
</div>

<div class="grid_3">
    <div class="box">
        <div class="avatar-profile">
            <div class="photo">
                <asp:Image CssClass="main" ID="imgAvatar" runat="server" ImageUrl="~/images/profileavatar/profileimage.aspx"/>
            </div>
            <asp:HyperLink runat="server" ID="lnkViewInfo" Text="Xem thông tin cá nhân" NavigateUrl="~/Profiles/ProfileInfo.aspx"></asp:HyperLink>
            <asp:HyperLink runat="server" ID="lnkChangePicture" Text="Cập nhật avatar" NavigateUrl="~/Profiles/UploadAvatar.aspx"></asp:HyperLink>
            <asp:HyperLink runat="server" ID="lnkEditProfile" Text="Cập nhật thông tin cá nhân" NavigateUrl="~/Profiles/ManageProfile.aspx"></asp:HyperLink>
        </div>
    </div>
    
     <asp:Panel ID="pnlPrivacyAccountInfo" runat="server" CssClass="box profile">
        <h2>Thông tin cá nhân</h2>
        <div class="block-c" id="account-info">
            <dl class="profile-info">
              <%--  <dt>Giới tính:</dt>
                <dd><asp:Literal ID="litSex" runat="server"></asp:Literal></dd>--%>
                <dt>Ngày sinh:</dt>
                <dd  class="last"><asp:Literal ID="litBirthDate" runat="server"></asp:Literal></dd>
                <dt>Tỉnh thành:</dt>
                <dd><asp:Literal ID="litZip" runat="server"></asp:Literal></dd>
            </dl>
        </div>
    </asp:Panel>
            
            
     
    <asp:Panel ID="pnlPrivacyIM" runat="server" CssClass="box profile">
        <h2>Contact Information</h2>
        <div class="block-c" id="contact-info">
            <dl class="profile-info">
                <dt>Google:</dt>
                <dd><asp:Literal ID="litIMGIM" runat="server"></asp:Literal></dd>
                <dt>Yahoo:</dt>
                <dd class="last"><asp:Literal ID="litIMYIM" runat="server"></asp:Literal></dd>
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
                    
    <asp:Panel ID="pnlPrivacyTankInfo" runat="server" CssClass="box profile">
        <h2>Fish Facts</h2>
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
    
    <%--<asp:PlaceHolder ID="phAttributes" runat="server" />--%>
   
</div>

<div class="grid_7">
     <div class="box">
        <div class="block">
           <div class="status">
				<asp:TextBox ID="txtStatus" runat="server" TextMode="MultiLine"/>
				<div class="yui-g">
					<div class="yui-u first">
					</div>
					<div class="yui-u align-right">
					    <asp:Button ID="btnAddStatus" runat="server" CssClass="button" Text="Chia sẽ"/>
					</div>
				</div>
			</div>
        </div>
    </div>
    
    <div class="box">
        <asp:Repeater ID="repFilter" runat="server">
            <ItemTemplate>
                <div class="Alert">
                    <asp:Label ID="lblMessage" runat="server" Text='<%# ((Alert)Container.DataItem).Message  %>'></asp:Label>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <div class="AlertSeparator"></div>
            </SeparatorTemplate>
         </asp:Repeater>
         <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
   
</div>


<div class="grid_3">
    <div class="box">
        <h2>Bạn bè</h2>
        <div class="block-c">
              <%--   <asp:Label CssClass="ProfileName" ID="lblFirstName" runat="server"></asp:Label>
                <asp:Label CssClass="ProfileName" ID="lblLastName" runat="server"></asp:Label>
                <asp:Literal ID="litLevelOfExperience" runat="server"></asp:Literal>--%>
               
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
</asp:Content>
