using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACCOPortal.NavOData;

namespace SACCOPortal
{
    public partial class Reports : System.Web.UI.Page
    {
        public NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]))
        {
            Credentials =
            new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"],
                ConfigurationManager.AppSettings["DOMAIN"])
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                LoadLoans(nav, ddFosaAccount);
            }
            if (Request.QueryString["r"] == "ms")
            {
                printMemberStatement();
            }
            //if (Request.QueryString["r"] == "ds")
            //{
            //    printDepositsStatement();
            //}
            if (Request.QueryString["r"] == "ls")
            {
                printLoansStatement();
            }
            if (Request.QueryString["r"] == "lg")
            {
                printLoanGuranteedStatement();
            }
            if (Request.QueryString["r"] == "lo")
            {
                printLoanGurantortatement();
            }
           
        }


        public void printMemberStatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnMemberStatement(Session["username"].ToString(),String.Format("MEMBER STATEMENT{0}.pdf", filename));
				pdfReport.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("MEMBER STATEMENT{0}.pdf", filename)));
              
            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }

        public void printLoansStatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnLoanStatement(Session["username"].ToString(), String.Format("LOAN STATEMENT{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfReport.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LOAN STATEMENT{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }
        public void printBosaStatement( NAV navData)
        {
    //        var filename = Session["username"].ToString().Replace(@"/", @"");
    //        var test = Session["username"].ToString();
    //        try
    //        {
    //            var objFosaAccount =
    //            navData.FosaAccounts.Where(r => r.BOSA_Account_No == Session["username"].ToString()).Select(r => r.No).FirstOrDefault();
    //            WSConfig.ObjNav.FnFosaStatement(objFosaAccount.ToString(), String.Format("LS{0}.pdf", filename));

				////CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
				//pdfReport.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LS{0}.pdf", filename)));

    //        }
    //        catch (Exception exception)
    //        {
    //            exception.Data.Clear();
    //        }
        }
        public void printLoanGuranteedStatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnLoanGuranteed(Session["username"].ToString(), String.Format("LOANS GUARANTEED{0}.pdf", filename));
				//CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
				pdfReport.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LOANS GUARANTEED{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }

        //public void printDepositsStatement() {
        //    var filename = Session["username"].ToString().Replace(@"/", @"");
        //    try
        //    {
        //        WSConfig.ObjNav.FnDepositsStatement(Session["username"].ToString(), String.Format("DEPOSITS STATEMENT{0}.pdf", filename));
        //        //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
        //        pdfReport.Attributes.Add("src", ResolveUrl("http://192.168.1.2:801/" + String.Format("DEPOSITS STATEMENT{0}.pdf", filename)));

        //    }
        //    catch (Exception exception)
        //    {
        //        exception.Data.Clear();
        //    }
        //}

        public void printLoanGurantortatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnLoanGurantorsReport(Session["username"].ToString(), String.Format("LOAN GUARANTORS{0}.pdf", filename));
				//CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
				pdfReport.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LOAN GUARANTORS{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }
        public void printLoanRepayment()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnFosaStatement(Session["username"].ToString(), String.Format("LOAN REPAYMENT{0}.pdf", filename));
				//CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
				pdfReport.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LOAN REPAYMENT{0}.pdf", filename)));


            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnLoanRepaymentShedule(ddFosaAccount.SelectedValue, String.Format("REPAYMENT SCHEDULE{0}.pdf", filename));
				//CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
				pdfReport.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("REPAYMENT SCHEDULE{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }

        }

       public void LoadLoans(NAV navData, DropDownList ddlist)
       {
           var objFosaAccount = navData.LoansR
                .ToList().Where( n => n.Client_Code == Session["username"].ToString());

           ddlist.DataSource = objFosaAccount;
           ddlist.DataTextField = "Loan_No";
           ddlist.DataValueField = "Loan_No";
           ddlist.DataBind();
        }
    }
}