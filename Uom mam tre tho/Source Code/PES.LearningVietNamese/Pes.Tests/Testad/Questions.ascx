<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Questions.ascx.cs" Inherits="Testad.Questions" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<h1>Soan Cau Hoi trac Nghiem</h1>
<h2> Cau Hoi</h2>
<FCKeditorV2:FCKeditor ID="FCKeditorQA" runat="server" Height="300" Width="100%"
                    BasePath="~/fckeditor/" SkinPath="skins/office2003/" ToolbarSet="ITBusToolbar">
</FCKeditorV2:FCKeditor>
<div>
So luong cua tra loi:
<asp:DropDownList Enabled="true" ID="NumAw" runat="server" AutoPostBack="true" 
        onselectedindexchanged="NumAw_SelectedIndexChanged1" >
</asp:DropDownList>
</div>
<h2>Tra Loi</h2>
<div id="danswer" runat="server">

</div>
<div>
Dap an dung:
<asp:DropDownList Enabled="true" ID="awcs" runat="server">
</asp:DropDownList>

</div>
