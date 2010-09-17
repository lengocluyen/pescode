<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="StatusUpdates.aspx.cs" Inherits="PESWeb.Profiles.StatusUpdates" %>

<%@ Import Namespace="Pes.Core" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_10">
        <div class="page-heading hr">
            <h2>
                Status</h2>
        </div>
        <div class="clear"></div>
            <asp:Repeater ID="repStatusUpdates" runat="server">
                <ItemTemplate>
                    <%# ((StatusUpdate)Container.DataItem).CreateDate.ToString() %>
                    -
                    <%# ((StatusUpdate)Container.DataItem).Status %>
                </ItemTemplate>
                <SeparatorTemplate>
                    <div class="divContainerSeparator">
                    </div>
                </SeparatorTemplate>
            </asp:Repeater>
    </div>
</asp:Content>
