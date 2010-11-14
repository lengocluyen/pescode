<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster1.master" AutoEventWireup="true"
    CodeFile="ReviewPhoto.aspx.cs" Inherits="ReviewPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="grid_18">
        <div id="title">
            <h1>
                Album Name</h1>
            <div class="alignright">
                <a href="#" class="button gray">Add more photo</a>
            </div>
            <div id="desc">
                <div class="alignleft">
                    <a href="#">View photos</a>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="photos">
            <table class="photo-grid">
                <tr>
                    <td>
                        <a href="#">
                            <div class="pg-wrapper">
                                <img alt="" src="../images/photosample.jpg" /></div>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <div class="pg-wrapper">
                                <img alt="" src="../images/photosample.jpg" /></div>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <div class="pg-wrapper">
                                <img alt="" src="../images/photosample.jpg" /></div>
                        </a>
                    </td>
                    <td>
                        <a href="#">
                            <div class="pg-wrapper">
                                <img alt="" src="../images/photosample.jpg" /></div>
                        </a>
                    </td>
                </tr>
            </table>
        </div>
        
        
        <!-- Comment cua p-->
        <div class="comments">
            <div class="meta">
                4 June 2008 at 22:40 -
                 <a href="#" id="respondlink-2" class="respondlink">Comments</a>
            </div>
            <div class="commentcontainer">
            </div>
            <div class="index-comment">
                <textarea class="respondtext">Write a comment ...</textarea>
            </div>
            <div id="commentform-2" class="index-comment comment-form" style="display: none">
                <div class="form_comment">
                    <textarea class="focus" name="comment"></textarea>
                </div>
                <div class="form_submit form_submit_right">
                    <input class="submit" type="submit" value="Comment" name="submit" />
                </div>
                <!-- ID cua bai viet -->
                <input type="hidden" value="2" name="comment_post_ID" />
            </div>
        </div>
    </div>
</asp:Content>
