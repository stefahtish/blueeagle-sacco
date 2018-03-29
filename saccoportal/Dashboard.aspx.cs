using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACCOPortal.NavOData;
using System.Data;
using System.Drawing;
using SACCOPortal.NAVWS;
using System.EnterpriseServices;
using System.Web.Services;

namespace SACCOPortal
{
    public partial class Dashboard : System.Web.UI.Page
    {
        //decimal subTotal = 0;
        //decimal total = 0;
        //int subTotalRowIndex = 0;
       

        public NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]))
        {
            Credentials =
             new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"],
                 ConfigurationManager.AppSettings["DOMAIN"])
        };
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack){ 
            if (Session["username"] == null)
            {
                Response.Redirect("~/Default");

            }  
            ReturnMember();
            LoadMinistatement();
            NoOfGuanteedLoans();
            //loanDetails(nav);
            FreeShares();
            checkPassDate();
            }
        }


        protected void checkPassDate()
        {
            var passDt = nav.MemberList.ToList().Where(r => r.No == Session["username"].ToString());
            string pdT = passDt.Select(r => r.Password_Set_Date).SingleOrDefault().ToString();

            string idNo = passDt.Select(r => r.ID_No).SingleOrDefault().ToString();
            string passWDInit = passDt.Select(k => k.Password).SingleOrDefault().ToString();

            DateTime Pexpires = Convert.ToDateTime(pdT);
            var expDay = DateTime.Today;

            int daysT = (expDay - Pexpires).Days;
            //SACCOFactory.ShowAlert("pass " + passWDInit);
            if (daysT >= 25 && daysT <= 30 || idNo.Equals(passWDInit) || Pexpires == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else if (daysT > 30)
            {
                // Response.Redirect("Logout");
                SACCOFactory.ShowAlert("Sorry, your password has expired, reset first!");

            }
        }

        protected Member ReturnMember()
        {

            return new Member(Session["username"].ToString());
        }

        protected void FreeShares()
        {
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
            Portals fShares = new Portals();
            fShares.Credentials = credentials;
            fShares.PreAuthenticate = true;
            fShares.FnFreeShares(Session["username"].ToString());
            Session["Shares"] = fShares.FnFreeShares(Session["username"].ToString());
            var freeSh = String.Format(Session["Shares"].ToString());
            decimal fshrs = Convert.ToDecimal(freeSh);
            lblfreeShares.Text = fshrs.ToString();
        }

        protected void NoOfGuanteedLoans() {
            //var countGuarantors = nav.numberofgurantors.ToList().Where(r => r.Member_No == Session["username"].ToString()).ToList()
            //    .GroupBy(r => r.Member_No).Select(r => r.Key);          
            //    gLns.Text= countGuarantors.ToList().Count().ToString();
           
        }
        //protected void loanDetails( NAV nav) {
        //    var objLoans = nav.LoansR.ToList().Where(l => l.Client_Code == Session["username"].ToString());

        //    dispLoans.DataSource= objLoans.ToList().Select(r => new {LoanNumber=r.Loan_No, LoanType = r.Loan_Product_Type, OutstandingBal = r.Outstanding_Balance });
        //    dispLoans.AutoGenerateColumns = false;
        //    dispLoans.DataBind();

        //}

        protected void LoadMinistatement()
        {
            var finalList = new List<Statement>();
            foreach (var item in MiniStatement())
            {
                string[] ministmtArray = item.Split(new string[] { ":::" }, StringSplitOptions.None);
                finalList.Add(new Statement { Date = ministmtArray[0], Description = ministmtArray[1], Amount = ministmtArray[2] });
            }
            gvMinistatement.DataSource = finalList;
            gvMinistatement.AutoGenerateColumns = true;
            gvMinistatement.DataBind();
        }

        public List<string> MiniStatement()
        {
            var ministmtList = new List<string>();
            try
            {
                string ministmt = WSConfig.ObjNav.MiniStatement(Session["username"].ToString());
                string[] ministmtArray = ministmt.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                ministmtList = ministmtArray.ToList();
                
            }
            catch (Exception e)
            {
                e.Data.Clear();
            }
            return ministmtList;
        }

       
        //protected void dispLoans_DataBound(object sender, EventArgs e)
        //{
        //    for (int i = subTotalRowIndex; i < dispLoans.Rows.Count; i++)
        //    {
        //        total += Convert.ToDecimal(dispLoans.Rows[i].Cells[2].Text);
        //    }
        // this.AddTotalRow("Sub Total", subTotal.ToString("N2"));
        //    this.AddTotalRow("<h4><font color=black>Total Outstanding Balance:</font></h4>", total.ToString("N2"));
        //}

        //private void AddTotalRow(string labelText, string value)
        //{
        //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
        //    row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
        //    row.Cells.AddRange(new TableCell[3] { new TableCell (), //Empty Cell
        //                       new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right},
        //                       new TableCell { Text = value, HorizontalAlign = HorizontalAlign.Right } });
        //    dispLoans.Controls[0].Controls.Add(row);
        //}

       protected void changePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings");
        }

        protected void ddlMyLoan_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

       
    }

    class Statement
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        //public string currentShares { get; set; }
    }
}