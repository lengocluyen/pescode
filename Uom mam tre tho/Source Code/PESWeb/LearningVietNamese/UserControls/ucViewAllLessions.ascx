<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViewAllLessions.ascx.cs" Inherits="PESWeb.LearningVietNamese.UserControls.ucViewAllLessions" %>
<asp:DataList ID="dlViewAllLessions" runat="server" RepeatColumns = "3" Width = "100%" RepeatDirection = "Horizontal">
    <ItemTemplate>
        <div>
            <img id  = "imgLession" src = '<%# Commons.GetImageURL(Eval("LessionImg"))%>' class = "imgLessions" alt = "Test" title = "Test"/>
        </div>
        <div>
            <asp:Label ID = "lblLessionName" runat = "server" CssClass = "lblLessionName" Text = <%#Eval("LessionName")%> ></asp:Label>
        </div>
    </ItemTemplate>
</asp:DataList>