<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPagesMaster.Master" CodeBehind="Tests.aspx.cs" Inherits="Testad.Tests" %>
<%@ Register Src="~/Questions.ascx" TagName="Qusestion" TagPrefix="pes" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <pes:Qusestion ID="pqus" runat="server" />
 </asp:Content>
