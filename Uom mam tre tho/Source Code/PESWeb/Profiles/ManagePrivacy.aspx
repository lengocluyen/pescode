<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ManagePrivacy.aspx.cs" Inherits="PESWeb.Profiles.ManagePrivacy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<div class="grid_13">
	<div class="page-heading hr">
	    <div class="ui-block-link">
			<i class="ui-image icon-friend-req"></i>
			<h2>Cài đặt quyền riêng tư</h2>
		</div>
		<%--<h2 id="page-heading">Cài đặt quyền riêng tư</h2>--%>
    </div>
</div>
<div class="grid_13">
    <div class="box">
        <div class="block" id="personal-info">
            <div class="profile">
                <h4>Thông tin cá nhân</h4>
                    <p class="hint">
                        Bạn hãy sử dụng các cài đặt bên dưới để kiểm quyền truy cập hoặc xem thông tin trên trang cá nhân của bạn.
                    </p>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="message" />
                    <div class="divContainerRow">
                        <asp:PlaceHolder ID="phPrivacyFlagTypes" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="divContainerRow"> 
                        <div class="divContainerCellHeader">
                        &nbsp;
                        </div>
                        <div class="divContainerCell">
                            <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="button"/>
                        </div>
                    </div>
                    
            </div>
        </div>
    </div>
</div>

</asp:Content>
