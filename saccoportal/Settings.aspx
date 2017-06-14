<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" MasterPageFile="Site.Master" Inherits="SACCOPortal.Settings" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 20px">&nbsp;</div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading text-danger"><i class="fa fa-user"></i>Reset your Password</div>
   <div class="form-group form-inline">
                                 <table style="width: 100%;">
                                <tr>
                                    <td><small>Old Password</small></td>
                                    <td><asp:TextBox ID="txtPasswordOld" runat="server" CssClass="form-control" placeholder="Enter Member Number" TextMode="Password"></asp:TextBox></td>
                                </tr>
                                
                                <tr>
                                    <td><small>New Password</small></td>
                                    <td><asp:TextBox ID="txtPasswordNew" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox></td>
                                </tr>
                                
                                <tr>
                                    <td>Confirm Password</td>
                                    <td style="margin-left: 80px"><asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox></td>
                                </tr>
                                
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="margin-left: 80px">
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" OnClick="btnSubmit_Click" Text="Submit" />
                                    </td>
                                </tr>
                            </table>
                    </div>
                </div>
            </div>
        </div>
 </asp:Content>
