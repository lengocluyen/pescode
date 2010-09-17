<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="PESWeb.Profiles.ManageProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="grid_13">
	    <div class="page-heading hr">
		    <h2>Quản lý thông tin cá nhân</h2>
        </div>
    </div>

    <div class="grid_3">
        <p>
            <asp:Image ID="imgAvatar" runat="server" ImageUrl="~/images/profileAvatar/profileImage.aspx" Width="100%"/>
        </p>
        <div class="align-center">
            <a href="/profiles/uploadavatar.aspx">Cập nhật avatar</a>
        </div>
    </div>
    <div class="grid_9">
    
        <div class="box profile">
            <fieldset>
			<h2><a href="#" class="hidden" id="toggle-tankinfo">Tank Info</a></h2>
			<div class="block-c" id="tankinfo">
			    <div class="divContainer">
				    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            Year of first tank:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtYearOfFirstTank" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" 
                                runat="server"
                                ForeColor="Red" 
                                ControlToValidate="txtYearOfFirstTank" 
                                MinimumValue="1900" 
                                MaximumValue="2020" 
                                Display="Dynamic" 
                                ErrorMessage="Please enter the 4 digit year that you started your first tank!">*</asp:RangeValidator>
                        </div>
                    </div>
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            Number of tanks owned:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtNumberOfTanksOwned" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" SetFocusOnError="true"
                                runat="server"
                                ForeColor="Red"
                                Operator="DataTypeCheck"
                                ControlToValidate="txtNumberOfTanksOwned" 
                                Type="Integer" 
                                ErrorMessage="Must be a number">*</asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            Number of fish owned:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtNumberOfFishOwned" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2"
                                runat="server"
                                ForeColor="Red" 
                                Operator="DataTypeCheck"
                                ControlToValidate="txtNumberOfFishOwned" 
                                Type="Integer" 
                                ErrorMessage="Must be a number">*</asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divContainerRow">
                    <div class="divContainerCellHeader">
                        Level of experience:
                    </div>
                    <div class="divContainerCell">
                        <asp:DropDownList ID="ddlLevelOfExperience" runat="server"></asp:DropDownList>
                    </div>
                </div>
                </div>
			</div>
	        <h2><a href="#" class="hidden" id="toggle-signature">Signature</a></h2>
		    <div class="block-c" id="signature">
                <asp:TextBox ID="txtSignature" TextMode="MultiLine" Columns="20" Rows="4" runat="server"></asp:TextBox>
		    </div>
						
			<h2><a href="#" class="hidden" id="toggle-im">Instant Messaging</a></h2>
			<div class="block-c" id="im">
			    <div class="divContainer">
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            MSN:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtIMMSN" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            AOL:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtIMAOL" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            Google IM:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtIMGIM" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            Yahoo IM:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtIMYIM" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            ICQ #:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtIMICQ" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divContainerRow">
                        <div class="divContainerCellHeader">
                            Skype:
                        </div>
                        <div class="divContainerCell">
                            <asp:TextBox ID="txtIMSkype" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
			</div>
						
			<h2><a href="#" class="hidden" id="toggle-about">All about you</a></h2>
			<div class="block-c" id="about">
                <asp:PlaceHolder ID="phAttributes" runat="server"></asp:PlaceHolder>
			</div>
            
            <div class="divContainer align-center">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>  
                <asp:Label ID="lblProfileID" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblProfileTimestamp" runat="server" Visible="false"></asp:Label>
    	        <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="button"/>
	        </div>
	        </fieldset>
        </div>
            			
		
			
			
					
        
    </div>
    <script type="text/javascript">
    function MaxLength2000(sender, args)
      {
        if(args.Value.length > 2000)
        {
            args.IsValid = false;
            return;
        }
        args.IsValid = true;
      }
        
    </script>
</asp:Content>
