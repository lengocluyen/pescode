<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PESBanner.ascx.cs" Inherits="PESWeb.UserControls.PESBanner" %>
<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>
<%--<contenttemplate>--%>
<asp:Silverlight InitParameters=<%#this.webURL%> runat="server" Height="160px" Width="950px" Source="../ClientBin/PesBanner.xap"
    MinimumVersion="3.0.40624.0" />
<%--</contenttemplate>--%>
