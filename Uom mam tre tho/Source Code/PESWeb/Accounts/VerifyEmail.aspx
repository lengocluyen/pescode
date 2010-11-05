<%@ Page Title="" Language="C#" MasterPageFile="~/AuthMaster.Master" AutoEventWireup="true"
    CodeBehind="VerifyEmail.aspx.cs" Inherits="PESWeb.Accounts.VerifyEmail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="BoxTitle">
        <h2>
            Xác nhận Email</h2>
    </div>
    <asp:Label ID="lblMsg" runat="server" />
</asp:Content>
