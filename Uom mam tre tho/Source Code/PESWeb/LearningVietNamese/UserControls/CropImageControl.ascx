<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CropImageControl.ascx.cs" Inherits="PESWeb.LearningVietNamese.UserControls.CropImageControl" %>

<script language="javascript" type="text/javascript">

    // Remember to invoke within jQuery(window).load(...)
    // If you don't, Jcrop may not initialize properly
    jQuery(document).ready(function() {

        jQuery('#<%=this.imgCrop.ClientID %>').Jcrop({
            onChange: showCoords,
            onSelect: showCoords,
            //aspectRatio: 1,
            setSelect: [10, 10, 50, 50]

        });

    });

    // Our simple event handler, called from onChange and onSelect
    // event handlers, as per the Jcrop invocation above
    function showCoords(c) {
        var pic = jQuery('#<%=this.imgCrop.ClientID %>')

        var temp = new Image();
        temp.src = pic.attr('src');

        var width_percent = pic.width() / temp.width;
        var height_percent = pic.height() / temp.height;

        jQuery('#<%=this.x.ClientID %>').val(Math.round(c.x / width_percent));
        jQuery('#<%=this.y.ClientID %>').val(Math.round(c.y / height_percent));
        jQuery('#<%=this.Hidden_X.ClientID %>').val(Math.round(c.x / width_percent));
        jQuery('#<%=this.Hidden_Y.ClientID %>').val(Math.round(c.y / height_percent));
        jQuery('#<%=this.x2.ClientID %>').val(Math.round(c.x2 / width_percent));
        jQuery('#<%=this.y2.ClientID %>').val(Math.round(c.y2 / height_percent));
        jQuery('#<%=this.w.ClientID %>').val(Math.round(c.w / width_percent));
        jQuery('#<%=this.h.ClientID %>').val(Math.round(c.h / height_percent));
        jQuery('#<%=this.Hidden_Width.ClientID %>').val(Math.round(c.w / width_percent));
        jQuery('#<%=this.Hidden_Height.ClientID %>').val(Math.round(c.h / height_percent));

        
    };

</script>

<div>
    <asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>Chọn vùng cắt hình:</legend>
            <div id="left">
                <asp:Image ID="imgCrop" runat="server" CssClass="imgCrop" />
            </div>
            <div id="toolBar">
                <div class="box">
                Thông tin vùng cắt:
                    <p>
                        <asp:Label ID="lb_x" runat="server" Text="X:"></asp:Label><asp:TextBox ID="x" runat="server"
                            Width="35px" ReadOnly="true"></asp:TextBox><asp:Label ID="lb_y" runat="server" Text="Y:"></asp:Label>
                        <asp:TextBox ID="y" runat="server" Width="39px" ReadOnly="true"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="lb_x2" runat="server" Text="X2:"></asp:Label>
                        <asp:TextBox ID="x2" runat="server" Width="41px" ReadOnly="true"></asp:TextBox><asp:Label
                            ID="lb_y2" runat="server" Text="Y2:"></asp:Label>
                        <asp:TextBox ID="y2" runat="server" Width="40px" ReadOnly="true"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="lb_w" runat="server" Text="Rộng:"></asp:Label>
                        <asp:TextBox ID="w" runat="server" Width="39px" ReadOnly="true"></asp:TextBox><asp:Label
                            ID="lb_h" runat="server" Text="Cao:"></asp:Label>
                        <asp:TextBox ID="h" runat="server" Width="40px" ReadOnly="true"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="bn_Crop" runat="server" OnClick="bn_Crop_Click" Text="Cắt và Lưu" />
                        <asp:Button
                            ID="btn_Cancel" runat="server" Text="Hủy Bỏ" onclick="btn_Cancel_Click" />
                    </p>
                </div>
            </div>
            <div>
                <asp:HiddenField ID="Hidden_X" runat="server" />
                <asp:HiddenField ID="Hidden_Y" runat="server" />
                <asp:HiddenField ID="Hidden_Width" runat="server" />
                <asp:HiddenField ID="Hidden_Height" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>
</div>
<asp:Panel ID="Panel2" runat="server">
    <fieldset>
        <legend>Hình sau khi cắt:</legend>
        <asp:Image ID="imgCropped" runat="server" CssClass="imgCropped" />
        <p><asp:Button ID="btn_Close" runat="server" Text="Đóng Cửa Sổ" 
                onclick="btn_Close_Click" /></p>
    </fieldset>
</asp:Panel>
