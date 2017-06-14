<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FosaStatement.aspx.cs" MasterPageFile="Site.Master" Inherits="SACCOPortal.FosaStatement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 40px"></div>
    <div class="row">
        <div class="col-md-3">&nbsp;</div>
        <div class="col-md-6">

            <div class="panel panel-default">
                <div class="panel-heading">Fosa Statement</div>
                <div class="panel-body">

                    <p>Select Fosa Account <asp:DropDownList ID="ddFosaAccount" runat="server" CssClass="form-control"></asp:DropDownList></p>
                    <asp:Button OnClientClick="btnView_Click" ID="btnView" runat="server" Text="View Statement" CssClass="btn btn-warning" OnClick="btnView_Click" />
                </div>
            </div>
        </div>
        <div class="col-md-3">&nbsp;</div>
    </div>
</asp:Content>
