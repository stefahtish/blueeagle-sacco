<%@ Page Title="Dashboard" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.cs" Inherits="SACCOPortal.Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 20px">&nbsp;</div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading text-danger"><i class="fa fa-user"></i>Welcome, <%=Member.Name %></div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                            <img src="hr-img.png" class="img-circle img-responsive" />
                        </div>
                        <div class="col-md-4"></div>
                    </div>
                    <div class="row" style="height: 20px">&nbsp;</div>
                    <table class="table table-bordered table-condensed table-striped">
                        <tr>
                            <th colspan="2" style="font-size: large"><i class="glyphicon glyphicon-user"></i> Member Information</th>
                        </tr>

                        <tr>
                            <td>Member No</td>
                            <td><%=Member.No %></td>
                        </tr>
                        <tr>
                            <td>Name </td>
                            <td><%=Member.Name %></td>
                        </tr>
                        <tr>
                            <td>Payroll/staff No</td>
                            <td><%=Member.PayrollstaffNo %></td>
                        </tr>
                        <tr>
                            <td>Account Category </td>
                            <td><%=Member.Accountcategory %></td>
                        </tr>
                        <tr>
                            <td>Email </td>
                            <td><%=Member.Email %></td>
                        </tr>
                       
                        <tr>
                            <td>Bank Account </td>
                            <td><%=Member.BankAccount %></td>
                        </tr>
                    </table>
        
                    
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading text-danger"><i class="glyphicon glyphicon-list"></i> Other Details</div>
                        <div class="panel-body">
                            <table class="table table-bordered table-condensed table-striped">
                        <tr>
                            <th colspan="2" style="font-size: large"><i class="glyphicon glyphicon-signal"></i> Member Statistics</th>
                        </tr>
                        <tr>
                            <td>Share Retained</td>
                            <td><%=Member.Share %></td>
                        </tr>
                        <tr>
                            <td>Current Share</td>
                            <td><%=Member.currentshare %></td>
                        </tr>
                        <tr>
                            <td>Un-allocated Funds</td>
                            <td><%=Member.unallocatedfund %></td>
                        </tr>
                       <tr>
                           <td>Benevolent Funds </td>
                          <td><%=Member.Benevolent %></td>
                      </tr>
                        <tr>
                            <td>Dividend Amount </td>
                            <td><%=Member.Dividend %></td>
                        </tr>
                        <tr>
                            <td>Outstanding Loan Balance </td>
                            <td><%=Member.Oustandandingbal %></td>
                        </tr>
                        <tr>
                            <td>Accrued Interest </td>
                            <td><%=Member.interest %></td>
                        </tr>
                       <tr>
                           <td>FOSA Account Bal </td>
                           <td><%=Member.FOSAbal %></td>
                        </tr>
                    </table>
                            <asp:GridView ID="gvKins" runat="server" CssClass="table table-condensed table-responsive table-striped fa-table" Caption="Next of kins" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                    <asp:BoundField DataField="Telephone" HeaderText="Telephone	" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Relationship" HeaderText="Relationship" />
<%--                                    <asp:BoundField DataField="Type" HeaderText="Type" />--%>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="GvBeneficiary" runat="server" CssClass="table table-condensed table-responsive table-striped fa-table" Caption="My Beneficiaries" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                    <asp:BoundField DataField="Telephone" HeaderText="Telephone	" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Allocation" HeaderText="Allocation" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                   <div class="row">
                       <div class="col-md-12">
                           <div class="panel panel-default">
                                <div class="panel-heading text-danger"><i class="glyphicon glyphicon-list"></i> Mini Statement</div>
                              <div class="panel-body">
                                  <asp:GridView ID="gvMinistatement" runat="server" CssClass="table table-condensed table-responsive table-striped" Width="100%"></asp:GridView>
                                </div>
                           </div>
                       </div>
                  </div>

        </div>
    </div>
        </div>
        
  
    
<%--    /.row 2 --%>

    </div>
        <div class="row">
        <div class="col-md-3">
            <div class="panel panel-default">
               <div class="panel-heading"><i class="fa fa-pie-chart"></i> Performance Summary</div>
               <div class="panel-body"><div>
                <canvas id="chart-area2" width="200" height="200"></canvas>
             </div>
                  

               </div> 
            </div>
        </div>
        <div class="col-md-6">
         <div class="panel panel-default">
             <div class="panel-heading"><i class="fa fa-bar-chart"></i>   Progress analysis</div>
            <div class="panel-body"><div><canvas id="canvas" height="134"></canvas></div></div>
          </div>
         </div>
        <div class="col-md-3">
          <div class="panel panel-default">
   <div class="panel-heading"><i class="fa fa-leaf"></i>  Charts Legend</div>
                <div class="panel-body">
                    <ul class="doughnut-legend">
                        <li><span style="background-color:rgba(39,174,97,0.75)"></span>Total Deposits</li>
                        <li><span style="background-color:rgba(26,26,136,0.75)"></span>Total Repayments</li>
                        <li><span style="background-color:rgba(112,31,133,0.75)"></span>Total Shares</li>
                        
                    </ul>
   </div>
      </div>
    </div>
  </div>



</asp:Content>
