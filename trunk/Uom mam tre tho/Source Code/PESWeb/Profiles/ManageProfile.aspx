<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ManageProfile.aspx.cs" Inherits="PESWeb.Profiles.ManageProfile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_24">
        <div id="title">
            <h1>
                Cập nhật thông tin cá nhân</h1>
        </div>
    </div>
    <div class="grid_5">
        <div class="widget">
            <div class="widget-content">
                <div class="w-photo">
                    <asp:Image CssClass="main" ID="Image1" runat="server" ImageUrl="~/images/profileavatar/profileimage.aspx" />
                </div>
                <ul>
                    <li>
                        <asp:HyperLink runat="server" ID="lnkChangePicture" Text="Cập nhật avatar" NavigateUrl="~/Profiles/UploadAvatar.aspx"></asp:HyperLink></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="grid_12">
        <div id="profile-info">
            <div class="widget">
                <h2>
                    <a href="#" class="hidden" id="toggle-tankinfo">Thông tin cá nhân</a></h2>
                <div class="widget-content" id="tankinfo">
                    <div class="comment-form">
                        <div class="form-input">
                            <b>Tên trường học:</b>
                            <asp:TextBox ID="txtYearOfFirstTank" runat="server" CssClass="pi-input"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <b>Địa chỉ : </b>
                            <asp:TextBox ID="txtNumberOfTanksOwned" runat="server" CssClass="pi-input"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <b>Sở thích: </b>
                            <asp:TextBox ID="txtNumberOfFishOwned" runat="server" CssClass="pi-input" TextMode="MultiLine"
                                Rows="3"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <b>Lớp: </b>
                            <asp:DropDownList ID="ddlLevelOfExperience" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="widget">
                <h2>
                    <a href="#" class="hidden" id="toggle-signature">Chữ ký</a></h2>
                <div class="widget-content" id="signature">
                    <div class="comment-form">
                        <div class="form-input">
                            <asp:TextBox ID="txtSignature" TextMode="MultiLine" Columns="20" Rows="4" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="widget">
                <h2>
                    <a href="#" class="hidden" id="toggle-im">Địa chỉ trực tuyến</a></h2>
                <div class="widget-content" id="im">
                    <div class="comment-form">
                        <div class="form-input">
                            <b>Google IM:</b>
                            <asp:TextBox ID="txtIMGIM" runat="server" CssClass="pi-input"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <b>Yahoo IM:</b>
                            <asp:TextBox ID="txtIMYIM" runat="server" CssClass="pi-input"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <b>MSN:</b>
                            <asp:TextBox ID="txtIMMSN" runat="server" CssClass="pi-input"></asp:TextBox></div>
                        <div class="form-input">
                            <b>AOL:</b>
                            <asp:TextBox ID="txtIMAOL" runat="server" CssClass="pi-input"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <b>ICQ #:</b>
                            <asp:TextBox ID="txtIMICQ" runat="server" CssClass="pi-input"></asp:TextBox>
                        </div>
                        <div class="form-input">
                            <b>Skype:</b>
                            <asp:TextBox ID="txtIMSkype" runat="server" CssClass="pi-input"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="widget">
                <h2>
                    <a href="#" class="hidden" id="toggle-about">Thông tin khác về bạn</a></h2>
                <div class="widget-content" id="about">
                    <div class="comment-form">
                        <asp:PlaceHolder ID="phAttributes" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
            <asp:Panel CssClass="mb error" ID="pnlError" runat="server" Visible="false">
                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
            </asp:Panel>
            <div class="form-submit form_submit_right">
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="button green" />
                <div>
                    <asp:Label ID="lblProfileID" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblProfileTimestamp" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function MaxLength2000(sender, args) {
            if (args.Value.length > 2000) {
                args.IsValid = false;
                return;
            }
            args.IsValid = true;
        }
        jQuery(document).ready(function($) {
            $('#profile-info textarea').elastic();
        });
       
    </script>

</asp:Content>
