<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SACCOPortal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
              <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" CssClass="text-center hidden"></asp:Label>
              <div class="row">
                  <div class="col-md-3"></div>
                  <div class="col-md-8">
                      <span class="text-center text-danger"><small><%=lblError.Text %></small></span>  
                  </div>
                  <div class="col-md-1"></div>
              </div> 
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                         
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-6"><h3 class="text-center text-danger"><i class="glyphicon glyphicon-lock"></i> User Login </h3></div>
                            <div class="col-md-2">
                               
                            </div>
                           
                        </div>
                        <div class="form-group form-inline">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                     <table style="width: 100%;">
                                <tr>
                                    <td><small>Member  No</small></td>
                                    <td><asp:TextBox ID="txtStaffNo" runat="server" CssClass="form-control" placeholder="Enter Member Number"></asp:TextBox></td>
                                </tr>
                                
                                <tr>
                                    <td><small>Password</small></td>
                                    <td><asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox></td>
                                </tr>
                            </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                     <table style="width: 100%;">
                                <tr>
                                    <td><small>Member No</small></td>
                                    <td><asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control" placeholder="Enter Member Number" required></asp:TextBox></td>

                                </tr>
                                          <tr>
                                    <td><small>ID. No.</small></td>
                                    <td><asp:TextBox ID="idNo" runat="server" CssClass="form-control" placeholder="Enter ID Number" required></asp:TextBox></td>

                                </tr>
                            </table>
                                </asp:View>
                            </asp:MultiView>
                           
                    </div>
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-10">
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-4"><asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-sm" OnClick="btnLogin_Click"/>&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Send" CssClass="btn btn-warning btn-sm" OnClick="btnSubmit_Click"/><asp:Button ID="btnBack" runat="server" Text="&lt;&lt; Back" CssClass="btn btn-success btn-sm" OnClick="btnBack_Click"/></div>
                                    <div class="col-md-4"> <asp:Button ID="btnPassword" runat="server" Text="Forgot Password" CssClass="btn btn-warning btn-sm" OnClick="btnPassword_Click"/></div>
                                </div>
                             
                            </div>
                            <div class="col-md-2"></div>
                           
                        </div>
                            </div>
                    </div>
                    <div class="col-md-1"></div>
                </div>
               
            </div>
            <div class="col-md-3"></div>
       
            </div>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10 sure_font"> 
             <div class="row">
        <h2 class="text-center text-danger"> HOW IT WORKS </h2>
        <div class="col-md-4">
            <h2 class="text-warning"><i class="fa fa-recycle"></i> Rest Credentials</h2>
            <p style="text-align: justify">
                Use your new Member number or Old Member Number and the password to access the portal.Kindly change your password monthly ensure
                your security cannot be compromised. 
            </p>
            
        </div>
        <div class="col-md-4">
            <h2 class="text-warning"><i class="fa fa-clipboard"></i> First Time Use</h2>
            <p style="text-align: justify">
               Click on the forgot password button to generate a password. You must have provided a valid email address to the sacco. If not, please submit your email address to the
                sacco so that you can enjoy this service
            </p>
           
        </div>
        <div class="col-md-4">
           <h2 class="text-warning"><i class="fa fa-briefcase"></i> Simplicity</h2>
            <p style="text-align: justify">
                This Portal is built to be simple and precise. However, you can seek guidance from the Sacco ICT Department in case you need any help
            </p>
            
        </div>
        <p>&nbsp;</p>
        
        <div class="col-md-1"></div>
    </div>
  

</asp:Content>
