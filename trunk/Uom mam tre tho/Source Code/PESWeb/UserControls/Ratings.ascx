<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ratings.ascx.cs" Inherits="PESWeb.UserControls.Ratings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<asp:ToolkitScriptManager ID="id" EnablePartialRendering="true" runat="server" />--%>
<asp:Panel runat="server" ID="panel_Rating">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Rating ID="Rating1" runat="server"
                    CurrentRating="0"
                    MaxRating="5"
                    StarCssClass="ratingStar"
                    WaitingStarCssClass="savedRatingStar"
                    FilledStarCssClass="filledRatingStar"
                    EmptyStarCssClass="emptyRatingStar"
                    OnChanged="Rating_Changed"
                    style="float: left;">
            </asp:Rating>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
