<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Defaults.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SACCOPortal._Default" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="login-wrap" style="display:none;">
       
</div>
<div class="container-fluid">
    <div class="row row-eq-height">					                    
            
<div class="col-md-4"></div>
<div class="col-md-4">
    <div class="home-form-container">

	<div class="section">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-4">
                <img class="img img-circle login-img" style="background-color:#fff;" src="siteimages/kentourslogo.ico" />
            </div>
            <div class="col-md-4"></div>
        </div>
		<div class="mobile-form-toggle">
			<br>
    				<div class="field-error" id="Div1">
                        <div class="row">
                        <div class="col-md-12"> 
                                <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" CssClass="text-left hidden"></asp:Label>  
                                <span class="text-center text-danger"><small><%=lblError.Text %></small></span>                                                        
                            <h2 class="text-center text-primary" style="font-weight:bold; color: white">User Login </h2>                                
                        </div>
                                          
                    </div>
    				</div>

					</div>
                     
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i> Member No/ID:</span>
                    <asp:TextBox ID="txtStaffNo" runat="server" CssClass="form-control" placeholder="Member number or ID No"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-key"></i> Password:</span>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                    </div>
                    <label class="checkbox">
                        <input type="checkbox" value="remember-me"> First login 
                        <span class="pull-right"> <asp:LinkButton ID="forgotPass" runat="server" OnClick="btnPassword_Click" ForeColor="white">Reset Password</asp:LinkButton></span>
                    </label>
                    <br/>
                     <div style="transform:scale(1.0); -webkit-transform:scale(1.0);transform-origin:0 0;-webkit-transform-origin:0 0;">
                    <cc1:CaptchaControl ID="cptCaptcha" runat="server" 
                        CaptchaBackgroundNoise="Low" CaptchaLength="5" 
                        CaptchaHeight="60" CaptchaWidth="250" 
                        CaptchaLineNoise="None" CaptchaMinTimeout="5" 
                        CaptchaMaxTimeout="240" FontColor = "#529E00" />
                    </div>
                    <br/>
                    <div class="input-group">
                         <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control" Width="370px" placeholder="Enter the above Text"></asp:TextBox>
                          <br/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required!" ControlToValidate = "txtCaptcha" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i> Member  No:</span>
                    <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control" placeholder="Enter Member Number" ></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-id-card"></i> National ID:</span>
                        <asp:TextBox ID="idNo" runat="server" CssClass="form-control" placeholder="Enter ID Number" ></asp:TextBox>
                    </div>
                </asp:View>
            </asp:MultiView>
           
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-info btn-lg btn-block" OnClick="btnLogin_Click"/>&nbsp;&nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Send" CssClass="btn btn-success btn-lg btn-block" OnClick="btnSubmit_Click"/>&nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
               <%-- <asp:Button ID="btnSignup" runat="server" Text="Signup" CssClass="btn btn-info btn-lg btn-block" OnClick="btnSignup_Click"/>--%>
                <asp:Button ID="btnBack" runat="server" Text="&lt;&lt; Back" CssClass="btn btn-warning btn-lg btn-block" OnClick="btnBack_Click"/>
            </div>
        </div>

	</div>

</div>

</div>
<div class="col-md-4">
   
</div>

</div>
  
    <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="mymodal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button aria-hidden="true" data-dismiss="modal" class="close" type="button">×</button>
                            <h4 class="modal-title">Loan Payment Schedule</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div id="calculations" runat="server">
                     
                                </div>
                   
                            </div>
                                                  
                                <%--<asp:Button ID="btnBOSATransfer" CssClass="btn btn-primary" runat="server" Text="Transfer" OnClick="btnBOSATransfer_click" />--%>
                                             
                        </div>
                    </div>
                </div>
            </div> 
        </div>       
</asp:Content>
