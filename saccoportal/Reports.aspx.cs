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
                LoadLoans(nav);
            }
            if (Request.QueryString["r"] == "ms")
            {
                printMemberStatement();
            }
            if (Request.QueryString["r"] == "fs")
            {
                printFosaStatement();
            }
            if (Request.QueryString["r"] == "bs")
            {
                printBosaStatement();
            }
            if (Request.QueryString["r"] == "lg")
            {
                printLoanGuranteedStatement();
            }
            if (Request.QueryString["r"] == "lo")
            {
                printLoanGurantortatement();
            }
            if (Request.QueryString["r"] == "lr")
            {
               // printLoanRepayment();
            }
        }


        public void printMemberStatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnMemberStatement(Session["username"].ToString(),String.Format("MS{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("MS{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }

        public void printFosaStatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnFosaStatement(Session["account"].ToString(), String.Format("FS{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("FS{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }
        public void printBosaStatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnMemberStatement(Session["username"].ToString(), String.Format("BS{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("BS{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }
        public void printLoanGuranteedStatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnLoanGuranteed(Session["username"].ToString(), String.Format("LG{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LG{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
        }
        public void printLoanGurantortatement()
        {
            var filename = Session["username"].ToString().Replace(@"/", @"");
            try
            {
                WSConfig.ObjNav.FnLoanGurantorsReport(Session["username"].ToString(), String.Format("LO{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LO{0}.pdf", filename)));

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
                WSConfig.ObjNav.FnFosaStatement(Session["account"].ToString(), String.Format("LR{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LR{0}.pdf", filename)));

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
                WSConfig.ObjNav.FnLoanRepaymentShedule(ddFosaAccount.SelectedValue, String.Format("LR{0}.pdf", filename));
                //CopyFile(ConfigurationManager.AppSettings["SRC_FILE"] + String.Format("PAYSLIP{0}.pdf", filename), ConfigurationManager.AppSettings["DEST_FILE"] + String.Format("PAYSLIP{0}.pdf", filename));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LR{0}.pdf", filename)));

            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }

        }

       public void LoadLoans(NAV navData)
       {
            var objFosaAccount = navData.LoansReg.Where(r => r.Client_Code == Session["username"]).ToList();
            ddFosaAccount.DataSource = objFosaAccount;
            ddFosaAccount.DataTextField = "Loan_Product_Type";
            ddFosaAccount.DataValueField = "Loan_No";
            ddFosaAccount.DataBind();
        }
    }
}