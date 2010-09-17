<%@ Page EnableEventValidation="false" ValidateRequest="true" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/SiteMaster.Master" CodeBehind="Tests.aspx.cs" Inherits="PESWeb.Tests" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Tests/Questions.ascx" TagPrefix="PES" TagName="Qsn" %>
<asp:Content ID="content1" ContentPlaceHolderID="Content" runat="server">
    <div class="grid_13">
        <div class="page-heading hr">
            <h2>
                Soạn Câu Hỏi Trắc Nghiệm</h2>
        </div>
        <asp:Panel ID="pnlSendMessage" runat="server">
            <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="server" ID="ToolkitScriptManager1" />
            <div class="divContainerRow">
                <div style="padding-left: 5px; text-align: left; width: 14%; display: block; font-weight: bold;
                    float: left">
                    Chương trình học:</div>
                <div class="divContainerCell">
                    <asp:DropDownList ID="ddlProgrameStudy" runat="server" Width="45%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divContainerRow">
                <div class="divContainerCellHeader">
                    Lớp học:</div>
                <div class="divContainerCell">
                    <asp:DropDownList ID="ddlClass" runat="server" Width="50%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divContainerRow">
                <div class="divContainerCellHeader">
                    Môn học:</div>
                <div class="divContainerCell">
                    <asp:DropDownList ID="ddlSubject" runat="server" Width="50%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divContainerRow">
                <div class="divContainerCellHeader">
                    Phần học:</div>
                <div class="divContainerCell">
                    <asp:DropDownList ID="ddlParts" runat="server" Width="50%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divContainerRow">
                <div class="divContainerCellHeader">
                    Bài học:</div>
                <div class="divContainerCell">
                    <asp:DropDownList ID="ddlLesson" runat="server" Width="50%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divContainerRow">
                <div style="padding-left: 5px; text-align: left; width: 11%; display: block; font-weight: bold;
                    float: left">
                    Bài Kiểm Tra:</div>
                <div class="divContainerCell">
                    <asp:DropDownList ID="ddlTest" runat="server" Width="48%">
                    </asp:DropDownList>
                </div>
            </div>
            <ajaxToolkit:CascadingDropDown ID="ccddProgamming" runat="server" TargetControlID="ddlProgrameStudy"
                Category="ProgamStudy" PromptText="Chọn chương trình học" LoadingText="[Đang tải...]"
                ServicePath="~/Services/PESServicesSession.asmx" ServiceMethod="GetProgrammingDropDownContents" />
            <ajaxToolkit:CascadingDropDown ID="ccddStudyLevel" runat="server" TargetControlID="ddlClass"
                Category="studyLevel" PromptText="Chọn lớp học" LoadingText="[Đang tải...]" ServicePath="~/Services/PESServicesSession.asmx"
                ServiceMethod="GetStudyLevelDropdow" ParentControlID="ddlProgrameStudy" />
            <ajaxToolkit:CascadingDropDown ID="ccddSubject" runat="server" TargetControlID="ddlSubject"
                Category="Subject" PromptText="Chọn môn học" LoadingText="[Đang tải...]" ServicePath="~/Services/PESServicesSession.asmx"
                ServiceMethod="GetSubjectDropdow" ParentControlID="ddlClass" />
            <ajaxToolkit:CascadingDropDown ID="ccddPart" runat="server" TargetControlID="ddlParts"
                Category="Part" PromptText="Chọn phần học" LoadingText="[Đang tải...]" ServicePath="~/Services/PESServicesSession.asmx"
                ServiceMethod="GetSPartDropdow" ParentControlID="ddlSubject" />
            <ajaxToolkit:CascadingDropDown ID="ccddLesson" runat="server" TargetControlID="ddlLesson"
                Category="Lesson" PromptText="Chọn bài học" LoadingText="[Đang tải...]" ServicePath="~/Services/PESServicesSession.asmx"
                ServiceMethod="GetLessonDropdow" ParentControlID="ddlParts" />
            <ajaxToolkit:CascadingDropDown ID="ccddTest" runat="server" TargetControlID="ddlTest"
                Category="Test" PromptText="Chọn bài kiểm tra" LoadingText="[Đang tải...]" ServicePath="~/Services/PESServicesSession.asmx"
                ServiceMethod="GetTestDropdow" ParentControlID="ddlLesson" />
            <div class="divContainerRow">
                <textarea id="txtMessageHK" name="txtMessageHK" cols="92" rows="20" runat="server" />
                <br />
                Âm thanh:<asp:up
            </div>
            <div class="divContainerRow">
                <div style="padding-left: 5px; text-align: left; width: 16%; display: block; font-weight: bold;
                    float: left;">
                    Số lượng câu trả lời:</div>
                <div class="divContainerCell">
                    <div id="divchooseAN" runat="server">
                        <select id="chooseAN" style="width: 10%" onchange="chooseANum()">
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                            <option>6</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="divContainerRow">
                <div style="padding-left: 5px; text-align: left; width: 8%; display: block; font-weight: bold;">
                    Đáp án:</div>
                <div class="divContainerCell">
                    <div id="divanswers" style="padding: 5px 0 0 30px;" runat="server">
                        <div id="divas">
                            Đáp án 1:
                            <input type='text' id="aw1" style='width: 50%; margin-top: 5px;' />&nbsp;&nbsp;&nbsp;Âm
                            thanh:<input id='af1' type='file' /><br />
                            Đáp án 2:
                            <input type='text' id="aw2" style='width: 50%; margin-top: 5px;' />&nbsp;&nbsp;&nbsp;Âm
                            thanh:<input id='af2' type='file' /><br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="divContainerRow">
                <div style="padding-left: 5px; text-align: left; width: 11%; display: block; font-weight: bold;
                    float: left;">
                    Đáp án đúng:</div>
                <div class="divContainerCell">
                    <div id="divchooseAC" runat="server">
                        <div id="divcho">
                            <select style="width: 10%" id="chooseCA">
                                <option>1</option>
                                <option>2</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
            <div class="divContainerRow">
                <input type="hidden" name="hidden1" id="hidden1" runat="server" />
                <asp:Button ID="btAdd" runat="server" OnClientClick="SetDataAnswers()" Text="Add"
                    OnClick="btAdd_Click" />
            </div>
        </asp:Panel>
        <asp:Panel Visible="false" runat="server" ID="pnlSent">
            <div class="divContainer">
                <div class="divContainerBox">
                    <div class="divContainerRow">
                        <div class="divContainerCell">
                            Your message was sent!
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>

    <script type="text/javascript">

       

      

        function applyOnSubmitToForms() {
            elementsForms = document.getElementsByTagName("form");
            for (var intCounter = 0; intCounter < elementsForms.length; intCounter++) {
                elementsForms[intCounter].onsubmit = function() {
                if (!Validate_form(elementsForms[intCounter])) {
                        return false;
                    }
                }
            }
        }
        function addLoadEvent(func) {
            var oldonload = window.onload;
            if (typeof window.onload != 'function') {
                window.onload = func;
            }
            else {
                window.onload = function() {
                    oldonload();
                    func();
                }
            }
        }

        addLoadEvent(applyOnSubmitToForms);
        
        function Validate_required(field, atext) {
            with (field) {
                if (value == null || value == "") {
                    alert(atext);
                    return false;
                }
                else
                    return true;
            }
        }

        function Validate_form(thisform) {
            with (thisform) {
                if (Validate_required("<%=txtMessageHK.Name%>", "Nhập Câu Hỏi!") == false) {
                    "<%=txtMessageHK.Name%>".focus();return false;
                }
                if (Validate_required("<%=afq.Name%>", "Nhập file âm thanh!") == false) {
                    "<%=afq.Name%>".focus(); return false;
                }
            return true;
            }
        }

        function SetDataAnswers() {
            for(var i=1;i<=numGlobal;i++){
                var id="aw"+i
                var id2 = "af"+i;
                document.getElementById("<%=hidden1.ClientID%>").value += document.getElementById(id).value + "[]" + document.getElementById(id2).value + "---";
            }
            document.getElementById("<%=hidden1.ClientID%>").value += document.getElementById("chooseCA").value;
            return true;
         }
        
        function chooseANum() {
            var a = document.getElementById("chooseAN");

            var index = a.selectedIndex;
            var num = a.options[index].text;
            addValues(num);
        }
        var numGlobal = 2;
        function addValues(num) {
            numGlobal = num;
            var rs = "";
            var rs0 = "<select style='width:10%' id='chooseCA'>"
            for (var i = 1; i <= num; i++) {
                rs0 += "<option>" + i + "</option>";
                rs += "Đáp án " + i + ": <input id= aw" + i + " type='text' style='width:50%;margin-top:5px;'/><br/>";
            }
            rs0 += "</select>"
            document.getElementById("divas").innerHTML = rs;
            document.getElementById("divcho").innerHTML = rs0;
        }
    </script>

</asp:Content>
