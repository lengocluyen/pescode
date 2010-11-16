<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PESWeb.Friends.Default" %>

<%@ Import Namespace="Pes.Core" %>
<%@ Register Src="~/UserControls/ProfileDisplay.ascx" TagPrefix="uc" TagName="ProfileDisplay" %>
<asp:Content ID="Content6" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_14">
        <div id="title">
            <h1>
                Danh sách bạn bè</h1>
        </div>
        <div class="clear">
        </div>
        <div class="toolbar">
            <div class="alignleft">
                <span class="gray">
                    <asp:Label ID="lbCountFriends" runat="server"></asp:Label></span>
                <%--<select>
                    <option>Tat ca ban be</option>
                    <option>Ban be moi</option>
                    <option>Tinh</option>
                    <option>Thanh pho</option>
                    <option>Truong</option>
                    <option>So thich</option>
                </select>--%>
            </div>
            <div class="alignright">
                <%-- <div class="comment-form">
                    <input type="text" size="30" />
                </div>--%>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="friend-container">
            <div id="friends">
                <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
                    <ItemTemplate>
                        <uc:ProfileDisplay ShowFriendRequestButton="false" ID="pdProfileDisplay" runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="f-pager">
            <div class="alignleft">
               
            </div>
            <%--   <div class="alignright">
                <a href="#">< Trước</a> | <a href="#">Sau ></a>
            </div>--%>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
