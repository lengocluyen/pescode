<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Questions.ascx.cs" Inherits="Testad.Questions" %>

<div class="divContainerRow">
    <div style="text-align: left; width: 16%; display: block; font-weight: bold; float: left;">
        Số lượng câu trả lời:</div>
    <div class="divContainerCell">
        <asp:DropDownList ID="NumAw" runat="server" AutoPostBack="true" OnSelectedIndexChanged="NumAw_SelectedIndexChanged1"
            Width="10%">
        </asp:DropDownList>
    </div>
</div>
<div class="divContainerRow">
    <div style="text-align: left; width: 8%; display: block; font-weight: bold;">
        Đáp án:</div>
    <div class="divContainerCell">
        <div id="danswer" style="padding: 5px 0 0 20px" runat="server">
        </div>
    </div>
</div>
<div class="divContainerRow">
    <div style="text-align: left; width: 11%; display: block; font-weight: bold; float: left;">
        Đáp án đúng:</div>
    <div class="divContainerCell">
        <asp:DropDownList Enabled="true" ID="awcs" runat="server" Width="10%">
        </asp:DropDownList>
    </div>
</div>
