<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowGroup.ascx.cs" Inherits="PESWeb.LearningVietNamese.UserControls.ShowGroup" %>
div class="gMain">
    <div>    
    <center>
        <asp:Repeater ID="rptShowGroup" runat="server">
            <ItemTemplate>
                <div class="items">
                    <div class="img"><a href="#"><img src='<%# Commons.GetImageURL(Eval("LessionGroupImg"))%>' alt="" /></a></div>
                    <div class="gName"><%#Eval("LessionGroupName")%></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </center>
    </div>
</div>