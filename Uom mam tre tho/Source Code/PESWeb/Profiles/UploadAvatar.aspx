<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UploadAvatar.aspx.cs" Inherits="PESWeb.Profiles.UploadAvatar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/js/cropper/lib/prototype.js" language="javascript"></script>
<script type="text/javascript" src="/js/cropper/lib/scriptaculous.js?load=builder,dragdrop" language="javascript"></script>
<script type="text/javascript" src="/js/cropper/cropper.js" language="javascript"></script>
        <script type="text/javascript">
            function onEndCrop(coords, dimensions) {
                $('ctl00_Content_hidX1').value = coords.x1;
                $('ctl00_Content_hidY1').value = coords.y1;
                $('ctl00_Content_hidX2').value = coords.x2;
                $('ctl00_Content_hidY2').value = coords.y2;
                $('ctl00_Content_hidWidth').value = dimensions.width;
                $('ctl00_Content_hidHeight').value = dimensions.height;
            }
         </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_13">
		<div class="page-heading hr">
				<h2>Sửa Avatar</h2>
	    </div>
    </div>
    <div class="grid_13">
        <div class="box">
            <h2><a href="#" id="toggle-gravatar" class="visible">Sử dụng Gravatar</a></h2>
            <div class="block" id="gravatar">
                <%--<asp:Image ID="Image2" ImageUrl="~/images/ProfileAvatar/ProfileImage.aspx?ShowGravatar=1" runat="server" />--%>
                <p>
                    <asp:CheckBox ID="cbUseGravatar" runat="server" Text="Sử dụng Gravatar" />
                    <asp:Button ID="btnUseGravatar" runat="server" Text="Áp dụng" CssClass="button" />
                    <asp:Label ForeColor="Red" ID="lblGravatarMsg" runat="server"></asp:Label>
                
                </p>
                  <a href="#" id="toggle-gravatar-info" class="hidden"><b>Gravatar là gì?</b></a>
                <div id="gravatar-info" style="display:none">
                    <p>
                    Gravatar, viết cách điệu hay viết tắt của Global Recognized Avatar, tức hình đại diện toàn cầu. Nó là một hình ảnh đại diện 80 x 80 có thể tuỳ biến, điều chỉnh. Gravatar nhận dạng và tương tác qua e-mail.
                    </p>

                    <b>Làm thế nào để tôi có Gravatar?</b>
                    <p>
                    Để có Gravatar, bạn phải đăng ký một account ở địa chỉ <a href="http://www.gravatar.com">Gravatar.com</a>. Việc đăng ký chỉ yêu cầu email (do nó tương tác qua cái này). Có tài khoản xong, bạn hãy up hình từ máy hay lấy từ 1 URL nào đấy, cắt nó thành hình vuông (Bạn hoàn toàn yên tâm vì Gravatar có tính năng Crop ảnh chất lượng cao). Sau đó, chọn lấy 1 ảnh.
                    </p>
                </div>
            </div>
        </div>
       
        <asp:Panel ID="pnlUpload" runat="server" Visible="true" CssClass="box">
            <h2>Upload avatar khác</h2>
            <div class="block">
                <p>Bạn có thể tải tập tin <b>JPG, GIF</b> hoặc <b>PNG</b>, tối đa là <b>1MB</b>, kích cỡ tối thiểu <b>200x200px</b></p>
                <p>
                    <asp:FileUpload ID="fuAvatarUpload" runat="server" />
                    <asp:Label ForeColor="Red" ID="lblMessage" runat="server"></asp:Label>
                </p>
                <asp:Button ID="btnSubmit" runat="server" Text="Đăng ảnh" CssClass="button" />
                 
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlCrop" runat="server" Visible="false" CssClass="box crop-image">
            <h2>Chỉnh sửa hình ảnh</h2>
            <div class="block">
                <asp:HiddenField ID="hidX1" runat="server" />
                <asp:HiddenField ID="hidY1" runat="server" />
                <asp:HiddenField ID="hidX2" runat="server" />
                <asp:HiddenField ID="hidY2" runat="server" />
                <asp:HiddenField ID="hidWidth" runat="server" />
                <asp:HiddenField ID="hidHeight" runat="server" />
                <script type="text/javascript">
                  Event.observe(window, 'load', function() {
                      new Cropper.ImgWithPreview(
                                'ctl00_Content_imgCropImage',
                                {
                                    previewWrap: 'previewWrap',
                                    minWidth: 80,
                                    minHeight: 80,
                                    ratioDim: { x: 100, y: 100 },
                                    displayOnInit: true,
                                    onEndCrop: onEndCrop
                                }
                            );
                  });
                </script>
                <div class="yui-ge">
                    <div class="yui-u first align-center">
                        <h5>Avatar mới đăng</h5>
                        <asp:Image ImageUrl="~/images/ProfileAvatar/ProfileImage.aspx" id="imgCropImage" runat="server" />
                    </div>
                    <div class="yui-u align-center">
                        <h5>Hình xem trước</h5>
                        <div id="previewWrap"></div>
                        <p class="hint">
                              Di chuyển, phóng lớn hoặc thu nhỏ để chọn khung hình mà bạn muốn sử dụng làm avatar
                        </p>
                        <asp:Button ID="btnCrop" Text="Cắt" runat="server" CssClass="button"/>
                        <asp:Button ID="btnComplete" runat="server" Text="Chọn ảnh gốc"  CssClass="button"/>
                        <%--<asp:Button ID="btnIgnorCrop" Text="Lấy hình gốc" runat="server" CssClass="button"/>--%>
                        <asp:Label ID="lblCropInfo" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>    
            </div>
        </asp:Panel>
        
        <%-- <asp:Panel ID="pnlApprove" runat="server" Visible="false" CssClass="box">
            <h2>Hoàn tất chỉnh sửa avatar</h2>
            <div class="block-c">
                <p>
                    <asp:Image ID="Image1" ImageUrl="~/images/ProfileAvatar/ProfileImage.aspx" runat="server"/>
                </p>
                <br />
                <p>
                    <asp:Button ID="btnStartNew" runat="server" Text="Đăng ảnh khác ?" CssClass="button" />
                    <asp:Button ID="btnComplete" runat="server" Text="Chọn ảnh này!"  CssClass="button"/>
                </p>
            </div>
        </asp:Panel>--%>
        
    </div>
</asp:Content>
